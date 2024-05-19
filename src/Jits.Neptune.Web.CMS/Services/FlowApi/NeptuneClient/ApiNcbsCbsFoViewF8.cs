using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Services;
using JITS.Neptune.NeptuneClient.Workflow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.FlowApi;

/// <summary>
/// ICoreAPIService service
/// </summary>
public partial class ApiNcbsCbsFoViewF8 : ICoreAPIService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="typeError"></param>
    /// <param name="info"></param>
    /// <param name="code"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    protected ErrorInfoModel AddActionError(string type, string typeError, string info, string code, string key)
    {
        return new ErrorInfoModel()
        {
            type = type,
            type_error = typeError,
            key = key,
            info = info,
            code = code
        }; ;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JObject> BuildHeader(JObject packApi)
    {
        await Task.CompletedTask;
        return packApi;
    }
    private JToken buildF8FromResponse(JToken packApi)
    {
        var data_response = new JObject();
        try
        {
            var workflow = packApi.ToWorkflowExecutionInquiry();

            var step_code = workflow.execution.workflow_id;
            //if(step_code=="PMT_OITT") step_code="PMT_OITT_PMT";
            string step_fo = step_code + ";ACT_EXECUTE_POSTING;VOUCHER;VOUCHER_A4;POSTING_CSH_BMOV";
            var new_data = new object();
            var steps = workflow.execution_steps;
            for (int i = 0; i < steps.Count; i++)
            {
                var step = steps[i];
                if (step_fo.IndexOf(step.step_code) == -1) continue;
                else
                {
                    var content = JsonConvert.DeserializeObject<WorkflowStep>(step.p2_content.ToString());
                    var data_res = JObject.Parse(content.response.data.ToString());

                    new_data = Utils.Utils.MergeDictionary(new_data.ToDictionary(), data_res.ToDictionary());
                }

            }
            data_response = JObject.FromObject(new_data);

            //17/03/2023 lấy transaction_number từ tx_context . 

            var responseWorkflow = JsonConvert.DeserializeObject<JITS.NeptuneClient.Scheme.Workflow.WorkflowScheme>(workflow.execution_steps[0].p2_content.ToString());
            if (responseWorkflow.request.request_header.tx_context != null)
            {
                if (responseWorkflow.request.request_header.tx_context["transaction_number"] != null)
                    data_response["transaction_number"] = responseWorkflow.request.request_header.tx_context["transaction_number"].ToString();
            }

            if (data_response.ContainsKey("dataset"))
            {
                JArray dataset = data_response.GetValue("dataset").DeepClone().ToJArray();
                JArray new_dataset = new JArray();
                foreach (var item in dataset)
                {
                    var new_item = new JObject();
                    new_item.Add("dataset", item);
                    new_dataset.Add(new_item);
                }
                data_response["dataset"] = new_dataset;
            }
            else if (data_response.ContainsKey("list_credit_history") && data_response.SelectToken("list_credit_history").Type != JTokenType.Null)
            {
                JArray dataset = data_response.GetValue("list_credit_history").DeepClone().ToJArray();
                JArray new_dataset = new JArray();
                foreach (var item in dataset)
                {
                    var new_item = new JObject();
                    new_item.Add("dataset", item);
                    new_dataset.Add(new_item);
                }
                data_response["dataset"] = new_dataset;
            }
            else if (data_response.ContainsKey("transaction_list") && data_response.SelectToken("transaction_list").Type != JTokenType.Null)
            {
                JArray dataset = data_response.GetValue("transaction_list").DeepClone().ToJArray();
                JArray new_dataset = new JArray();
                foreach (var item in dataset)
                {
                    var new_item = new JObject();
                    new_item.Add("dataset", item);
                    new_dataset.Add(new_item);
                }
                data_response["dataset"] = new_dataset;
            }
            if (data_response.ContainsKey("result"))
            {
                JArray result = data_response.GetValue("result").DeepClone().ToJArray();
                JArray new_result = new JArray();
                foreach (var item in result)
                {
                    var new_item = new JObject();
                    new_item.Add("result", item);
                    new_result.Add(new_item);
                }
                data_response["result"] = new_result;
            }
            if (data_response.ContainsKey("cash_denom"))
            {
                JArray cash_denom = data_response.GetValue("cash_denom").DeepClone().ToJArray();
                JArray new_cash_denom = new JArray();
                foreach (var item in cash_denom)
                {
                    var new_item = new JObject();
                    new_item.Add(propertyName: "cash_denom", item);
                    new_cash_denom.Add(new_item);
                }
                data_response["cash_denom"] = new_cash_denom;
            }


            if (data_response.ContainsKey(propertyName: "entry_journals") && data_response.SelectToken("entry_journals").Type != JTokenType.Null)
            {
                JArray postings = data_response.GetValue("entry_journals").DeepClone().ToJArray();
                JArray postings_debit = new JArray();
                JArray postings_credit = new JArray();
                foreach (var posting in postings)
                {
                    var ob_posting = new JObject();
                    if (posting.SelectToken("debit_or_credit") != null)
                    {
                        if (posting.SelectToken("debit_or_credit").ToString() == "D")
                        {
                            ob_posting.Add("postings_debit", posting);
                            postings_debit.Add(ob_posting);
                        }
                        else if (posting.SelectToken("debit_or_credit").ToString() == "C")
                        {
                            ob_posting.Add("postings_credit", posting);
                            postings_credit.Add(ob_posting);
                        }
                    }
                }
                // JArray new_postings_debit = new JArray();
                // JArray new_postings_credit = new JArray();
                // int index_credit = 0;
                // for (var i = 0; i < postings_debit.Count; i++)
                // {
                //     var ob_debit = postings_debit[i].SelectToken("postings_debit");
                //     var ob_posting = new JObject();
                //     int group = -1;
                //     if (ob_debit.SelectToken("accounting_entry_group") != null)
                //     {
                //         group = Int32.Parse(ob_debit.SelectToken("accounting_entry_group").ToString());
                //     }
                //     if (index_credit < postings_credit.Count)
                //     {
                //         var elm_postings_credit = postings_credit[index_credit].SelectToken("postings_credit");
                //         int group_credit = Int32.Parse(elm_postings_credit.SelectToken("accounting_entry_group").ToString());
                //         if (group_credit < group)
                //         {
                //             var ob_ = new JObject();
                //             ob_.Add("postings_debit", new JObject());
                //             new_postings_debit.Add(ob_);
                //             index_credit++;
                //             i--;
                //             continue;
                //         }
                //         else
                //         {
                //             index_credit++;
                //         }
                //     }
                //     JObject ob = new JObject();
                //     ob.Add("postings_debit", postings_debit[i].SelectToken("postings_debit"));
                //     new_postings_debit.Add(ob);
                // }

                // int index_debit = 0;
                // for (var i = 0; i < postings_credit.Count; i++)
                // {
                //     var ob_credit = postings_credit[i].SelectToken("postings_credit");
                //     var ob_posting = new JObject();
                //     int group = -1;
                //     if (ob_credit.SelectToken("accounting_entry_group") != null)
                //     {
                //         group = Int32.Parse(ob_credit.SelectToken("accounting_entry_group").ToString());
                //     }
                //     if (index_debit < postings_debit.Count)
                //     {
                //         var elm_postings_debit = postings_debit[index_debit].SelectToken("postings_debit");
                //         int group_debit = Int32.Parse(elm_postings_debit.SelectToken(path: "accounting_entry_group").ToString());
                //         if (group_debit < group)
                //         {
                //             var ob_ = new JObject();
                //             ob_.Add(propertyName: "postings_credit", new JObject());
                //             new_postings_credit.Add(ob_);
                //             index_debit++;
                //             i--;
                //             continue;
                //         }
                //         else
                //         {
                //             index_debit++;
                //         }
                //     }
                //     JObject ob = new JObject();
                //     ob.Add("postings_credit", postings_credit[i].SelectToken("postings_credit"));
                //     new_postings_credit.Add(ob);
                // }
                while (postings_credit.Count < postings_debit.Count)
                {
                    var ob = new JObject();
                    ob.Add("postings_credit", new JObject());
                    postings_credit.Add(ob);
                }
                while (postings_debit.Count < postings_credit.Count)
                {
                    var ob = new JObject();
                    ob.Add("postings_debit", new JObject());
                    postings_debit.Add(ob);
                }

                data_response["postings_debit"] = postings_debit;
                data_response["postings_credit"] = postings_credit;
            }
            if (data_response.ContainsKey(propertyName: "vouchers"))
            {
                data_response.Remove("vouchers");
            }

            // thêm transaction_code = workflowid

            data_response["transaction_code"] = workflow.execution.workflow_id;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("Exception===" + ex.StackTrace);
        }
        return data_response;

    }
    private JToken buildF8FromWorkflowInput(JToken packApi)
    {
        var workflow = packApi.ToWorkflowExecutionInquiry();
        var workflowInput = JObject.Parse(workflow.execution.input.ToString());
        if (workflow != null)
        {
            workflowInput["fields"]["transaction_code"] = workflowInput["workflowid"];
            workflowInput["fields"]["ref_id"] = workflow.execution.execution_id;

            var content = JsonConvert.DeserializeObject<WorkflowStep>(workflow.execution_steps[0].p2_content.ToString());
            var data_res = JObject.Parse(content.request.ToString());

            if (data_res["request_header"] != null)
                if (data_res["request_header"]["tx_context"] != null)
                    if (data_res["request_header"]["tx_context"]["transaction_number"] != null)
                        workflowInput["fields"]["transaction_number"] = data_res["request_header"]["tx_context"]["transaction_number"].ToString();
        }


        return workflowInput["fields"];
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(JToken packApi)
    {
        if (packApi.SelectToken("error_message") != null)
        {
            var errorMsg = packApi.SelectToken("error_message").ToString();
            if (errorMsg.HasValue())
            {
                List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
                string[] list_error = errorMsg.Split("\n");
                for (var i = 0; i < list_error.Length; i++)
                {
                    listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, list_error[i], "", ""));
                }
                EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.AddActionErrorAll(listError);
                return null;
            }
        }

        if (EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput()["fof_transaction_journal"] != null)
        {
            var tran_status = EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput()["fof_transaction_journal"]["tran_status"];
            if (tran_status != null)
            {
                // switch (tran_status.ToString())
                switch (packApi.SelectToken("execution.is_success").ToString())
                {
                    case "Y":
                        return buildF8FromResponse(packApi);
                    // case "R":
                    //     return buildF8FromResponse(packApi);
                    default:
                        return buildF8FromWorkflowInput(packApi);
                }

            }
        }
        await Task.CompletedTask;
        return packApi;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseApiModel"></param>
    /// <returns></returns>
    public async Task<List<ErrorInfoModel>> BuildError(WorkflowExecutionInquiry responseApiModel)
    {
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        try
        {
            if (responseApiModel.execution_steps != null)
            {
                foreach (var itemStep in responseApiModel.execution_steps)
                {
                    var dataProcess = itemStep.p2_content.ToExecutionStepProcess();

                    if (dataProcess != null && dataProcess.response != null)
                    {
                        if (dataProcess.response.status != 0)
                        {
                            // var errorMeg = itemStep.step_code + " : " + dataProcess.response.data.GetErrorMessage();
                            // listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, errorMeg, "", ""));
                            string[] list_error = dataProcess.response.error_message.Split("\n");
                            for (var i = 0; i < list_error.Length; i++)
                            {
                                listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, list_error[i], itemStep.step_code, dataProcess.response.error_code));
                            }

                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
            if (responseApiModel.execution.is_timeout.Equals("Y")) listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, "Timeout execute workflow with execution_id : " + responseApiModel.execution.execution_id, "", ""));
        }
        await Task.CompletedTask;
        return listError;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<bool> CheckHasError(WorkflowExecutionInquiry packApi)
    {
        // List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        // if (!packApi.execution.is_success.Equals("Y")) return true;
        await Task.CompletedTask;
        return false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<bool> CheckHasError(ExecuteResponseModel packApi)
    {
        // if(packApi.Status.ToUpper()=="ERROR") return true;
        await Task.CompletedTask;
        return false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseApiModel"></param>
    /// <returns></returns>
    public async Task<List<ErrorInfoModel>> BuildError(ExecuteResponseModel responseApiModel)
    {
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        string[] list_error = responseApiModel.Description.Split("\n");
        for (var i = 0; i < list_error.Length; i++)
        {
            listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, list_error[i], "", ""));
        }
        await Task.CompletedTask;
        return listError;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(ExecuteResponseModel packApi)
    {
        var result = packApi;
        await Task.CompletedTask;
        return result.ToJToken();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<string> BuildRequest(string packApi)
    {
        var workflowExecute = JObject.Parse(packApi).ToObject<WorkflowExecuteModel>();
        await Task.CompletedTask;
        return workflowExecute.ToSerialize();
    }
}
