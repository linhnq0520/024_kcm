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
public partial class ApiNcbsCbsFoPrint : ICoreAPIService
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <param name="typeError"></param>
    /// <param name="info"></param>
    /// <param name="code"></param>
    ///  <param name="key"></param>
    /// <returns></returns>
    protected ErrorInfoModel AddActionError(
        string type,
        string typeError,
        string info,
        string code,
        string key
    )
    {
        return new ErrorInfoModel()
        {
            type = type,
            type_error = typeError,
            key = key,
            info = info,
            code = code
        };
        ;
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

    /// <summary>
    ///
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(JToken packApi)
    {
        try
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
                        listError.Add(
                            AddActionError(
                                ErrorType.errorForm,
                                ErrorMainForm.warning,
                                list_error[i],
                                "",
                                ""
                            )
                        );
                    }
                    EngineContext.Current
                        .Resolve<JWebUIObjectContextModel>()
                        .Bo.AddActionErrorAll(listError);
                    return null;
                }
            }
            var workflow = packApi.ToWorkflowExecutionInquiry();

            var step_code = workflow.execution.workflow_id;
            //if(step_code=="PMT_OITT") step_code="PMT_OITT_PMT";
            string step_fo = step_code + ";ACT_EXECUTE_POSTING;VOUCHER;VOUCHER_A4;POSTING_CSH_BMOV";
            var new_data = new object();
            var steps = workflow.execution_steps;
            for (int i = 0; i < steps.Count; i++)
            {
                var step = steps[i];
                if (step_fo.IndexOf(step.step_code) == -1)
                    continue;
                else
                {
                    var content = JsonConvert.DeserializeObject<WorkflowStep>(
                        step.p2_content.ToString()
                    );
                    var data_res = JObject.Parse(content.response.data.ToString());

                    new_data = Utils.Utils.MergeDictionary(
                        new_data.ToDictionary(),
                        data_res.ToDictionary()
                    );
                }
            }
            var data_response = JObject.FromObject(new_data);

            //17/03/2023 lấy transaction_number từ tx_context .

            var responseWorkflow =
                JsonConvert.DeserializeObject<JITS.NeptuneClient.Scheme.Workflow.WorkflowScheme>(
                    workflow.execution_steps[0].p2_content.ToString()
                );

            if (responseWorkflow.request.request_header.tx_context != null)
            {
                if (
                    responseWorkflow.request.request_header.tx_context["transaction_number"] != null
                )
                    if (
                        !string.IsNullOrEmpty(
                            responseWorkflow.request.request_header.tx_context[
                                "transaction_number"
                            ].ToString()
                        )
                    )
                        data_response["transaction_number"] = responseWorkflow
                            .request
                            .request_header
                            .tx_context["transaction_number"].ToString();
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
            else if (
                data_response.ContainsKey("list_credit_history")
                && data_response.SelectToken("list_credit_history").Type != JTokenType.Null
            )
            {
                JArray dataset = data_response
                    .GetValue("list_credit_history")
                    .DeepClone()
                    .ToJArray();
                JArray new_dataset = new JArray();
                foreach (var item in dataset)
                {
                    var new_item = new JObject();
                    new_item.Add("dataset", item);
                    new_dataset.Add(new_item);
                }
                data_response["dataset"] = new_dataset;
            }
            else if (
                data_response.ContainsKey("transaction_list")
                && data_response.SelectToken("transaction_list").Type != JTokenType.Null
            )
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
            if (
                data_response.ContainsKey(propertyName: "entry_journals")
                && data_response.SelectToken("entry_journals").Type != JTokenType.Null
            )
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
                JArray vouchers = data_response.GetValue("vouchers").DeepClone().ToJArray();
                JArray new_vouchers = new JArray();
                for (var index = 0; index < vouchers.Count; index++)
                {
                    var voucher = vouchers[index];
                    var voucher_code = voucher.SelectToken("code").ToString();

                    var tags = voucher.SelectToken("tags");

                    //hard code cho phần print voucher A4
                    if (voucher_code == "A4")
                    {
                        if (tags.SelectToken("transaction_body.deposit_sub_type") != null)
                        {
                            //var deposit_type=tags.SelectToken("transaction_body.deposit_type").ToString();
                            var deposit_sub_type = tags.SelectToken(
                                    "transaction_body.deposit_sub_type"
                                )
                                .ToString();
                            switch (deposit_sub_type)
                            {
                                case "S1":
                                case "S4":
                                case "S5":
                                case "S6":
                                    voucher["code"] = "A4SA";
                                    break;
                                case "S3":
                                    voucher["code"] = "A4SB";
                                    break;
                                case "S2":
                                    voucher["code"] = "A4SC";
                                    break;
                                case "T1":
                                case "T2":
                                case "T3":
                                case "T4":
                                case "T5":
                                case "T6":
                                    voucher["code"] = "A4T";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    // if (tags.SelectToken("dataset") != null)
                    // {
                    //     JArray dataset = tags.SelectToken("dataset").DeepClone().ToJArray();
                    //     JArray new_dataset = new JArray();
                    //     foreach (var item in dataset)
                    //     {
                    //         var new_item = new JObject();
                    //         new_item.Add("dataset", item);
                    //         new_dataset.Add(new_item);
                    //     }
                    //     tags["dataset"] = new_dataset;
                    // }
                    // if (tags.SelectToken("result") != null)
                    // {
                    //     JArray result = tags.SelectToken("result").DeepClone().ToJArray();
                    //     JArray new_result = new JArray();
                    //     foreach (var item in result)
                    //     {
                    //         var new_item = new JObject();
                    //         new_item.Add("result", item);
                    //         new_result.Add(new_item);
                    //     }
                    //     tags["result"] = new_result;
                    // }
                    // if (tags.SelectToken("cash_denom") != null)
                    // {
                    //     JArray cash_denom = tags.SelectToken("cash_denom").DeepClone().ToJArray();
                    //     JArray new_cash_denom = new JArray();
                    //     foreach (var item in cash_denom)
                    //     {
                    //         var new_item = new JObject();
                    //         new_item.Add(propertyName: "cash_denom", item);
                    //         new_cash_denom.Add(new_item);
                    //     }
                    //     tags["cash_denom"] = new_cash_denom;
                    // }

                    // if (tags.SelectToken("posting") != null && tags.SelectToken("posting").Type != JTokenType.Null && tags.SelectToken("posting").Type == JTokenType.Array && tags.SelectToken("posting").HasValues)
                    // {
                    //     JArray postings = tags.SelectToken("posting").DeepClone().ToJArray();
                    //     JArray postings_debit = new JArray();
                    //     JArray postings_credit = new JArray();
                    //     foreach (var posting in postings)
                    //     {
                    //         var ob_posting = new JObject();
                    //         if (posting.SelectToken("action") != null)
                    //         {
                    //             if (posting.SelectToken("action").ToString() == "D")
                    //             {
                    //                 ob_posting.Add("postings_debit", posting);
                    //                 postings_debit.Add(ob_posting);
                    //             }
                    //             else if (posting.SelectToken("action").ToString() == "C")
                    //             {
                    //                 ob_posting.Add("postings_credit", posting);
                    //                 postings_credit.Add(ob_posting);
                    //             }
                    //         }
                    //     }
                    //     JArray new_postings_debit = new JArray();
                    //     JArray new_postings_credit = new JArray();
                    //     int index_credit = 0;
                    //     for (var i = 0; i < postings_debit.Count; i++)
                    //     {
                    //         var ob_debit = postings_debit[i].SelectToken("postings_debit");
                    //         var ob_posting = new JObject();
                    //         int group = -1;
                    //         if (ob_debit.SelectToken("accounting_entry_group") != null)
                    //         {
                    //             group = Int32.Parse(ob_debit.SelectToken("accounting_entry_group").ToString());
                    //         }
                    //         if (index_credit < postings_credit.Count)
                    //         {
                    //             var elm_postings_credit = postings_credit[index_credit].SelectToken("postings_credit");
                    //             int group_credit = Int32.Parse(elm_postings_credit.SelectToken("accounting_entry_group").ToString());
                    //             if (group_credit < group)
                    //             {
                    //                 var ob_ = new JObject();
                    //                 ob_.Add("postings_debit", new JObject());
                    //                 new_postings_debit.Add(ob_);
                    //                 index_credit++;
                    //                 i--;
                    //                 continue;
                    //             }
                    //             else
                    //             {
                    //                 index_credit++;
                    //             }
                    //         }
                    //         JObject ob = new JObject();
                    //         ob.Add("postings_debit", postings_debit[i].SelectToken("postings_debit"));
                    //         new_postings_debit.Add(ob);
                    //     }

                    //     int index_debit = 0;
                    //     for (var i = 0; i < postings_credit.Count; i++)
                    //     {
                    //         var ob_credit = postings_credit[i].SelectToken("postings_credit");
                    //         var ob_posting = new JObject();
                    //         int group = -1;
                    //         if (ob_credit.SelectToken("accounting_entry_group") != null)
                    //         {
                    //             group = Int32.Parse(ob_credit.SelectToken("accounting_entry_group").ToString());
                    //         }
                    //         if (index_debit < postings_debit.Count)
                    //         {
                    //             var elm_postings_debit = postings_debit[index_debit].SelectToken("postings_debit");
                    //             int group_debit = Int32.Parse(elm_postings_debit.SelectToken(path: "accounting_entry_group").ToString());
                    //             if (group_debit < group)
                    //             {
                    //                 var ob_ = new JObject();
                    //                 ob_.Add(propertyName: "postings_credit", new JObject());
                    //                 new_postings_credit.Add(ob_);
                    //                 index_debit++;
                    //                 i--;
                    //                 continue;
                    //             }
                    //             else
                    //             {
                    //                 index_debit++;
                    //             }
                    //         }
                    //         JObject ob = new JObject();
                    //         ob.Add("postings_credit", postings_credit[i].SelectToken("postings_credit"));
                    //         new_postings_credit.Add(ob);
                    //     }
                    //     while (new_postings_credit.Count < new_postings_debit.Count)
                    //     {
                    //         var ob = new JObject();
                    //         ob.Add("postings_credit", new JObject());
                    //         new_postings_credit.Add(ob);
                    //     }
                    //     while (new_postings_debit.Count < new_postings_credit.Count)
                    //     {
                    //         var ob = new JObject();
                    //         ob.Add("postings_debit", new JObject());
                    //         new_postings_debit.Add(ob);
                    //     }

                    //     tags["postings_debit"] = new_postings_debit;
                    //     tags["postings_credit"] = new_postings_credit;
                    // }

                    voucher["tags"] = tags;
                    new_vouchers.Add(voucher);
                }

                data_response["vouchers"] = new_vouchers;
            }

            return data_response;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
            var responseApiModel = packApi.ToObject<ExecuteResponseModel>();

            List<ErrorInfoModel> listError = new List<ErrorInfoModel>();

            string[] list_error = responseApiModel.Description.Split("\n");
            for (var i = 0; i < list_error.Length; i++)
            {
                listError.Add(
                    AddActionError(
                        ErrorType.errorForm,
                        ErrorMainForm.warning,
                        list_error[i],
                        "",
                        ""
                    )
                );
            }
            EngineContext.Current
                .Resolve<JWebUIObjectContextModel>()
                .Bo.AddActionErrorAll(listError);
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

        EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput()[
            "fo_execution_id"
        ] = responseApiModel.execution.execution_id;
        if (!string.IsNullOrEmpty(responseApiModel.execution.approved_execution_id))
            EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput()[
                "fo_execution_id"
            ] = responseApiModel.execution.approved_execution_id;

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
                                listError.Add(
                                    AddActionError(
                                        ErrorType.errorForm,
                                        ErrorMainForm.warning,
                                        list_error[i],
                                        itemStep.step_code,
                                        dataProcess.response.error_code
                                    )
                                );
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
            System.Console.WriteLine("BuildError====" + responseApiModel.ToSerialize());
            // TODO
            if (responseApiModel.execution.is_timeout.Equals("Y"))
                listError.Add(
                    AddActionError(
                        ErrorType.errorForm,
                        ErrorMainForm.warning,
                        "Timeout execute workflow with execution_id : "
                            + responseApiModel.execution.execution_id,
                        "",
                        ""
                    )
                );
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
        string[] list_error = responseApiModel.Description
            .Split("\n")
            .Where(s => !string.IsNullOrEmpty(s))
            .ToArray();
        for (var i = 0; i < list_error.Length; i++)
        {
            listError.Add(
                AddActionError(ErrorType.errorForm, ErrorMainForm.warning, list_error[i], "", "")
            );
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
        Console.WriteLine("=====packApi======" + JsonConvert.SerializeObject(packApi));
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
        try
        {
            var workflowExecute = JObject.Parse(packApi).ToObject<WorkflowExecuteModel>();
            var boInput = EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput();
            if (boInput["static_token"] != null)
            {
                workflowExecute.workflow_type = 2;
                workflowExecute.token = boInput["static_token"].ToString();
                if (boInput["JWEBUI_O9_approve"] != null)
                    if (boInput["JWEBUI_O9_approve"]["fo_ref_id"] != null)
                        workflowExecute.approved_execution_id = boInput["JWEBUI_O9_approve"][
                            "fo_ref_id"
                        ].ToString();
            }

            if (workflowExecute.fields != null)
                if (workflowExecute.fields.GetValueOrDefault("description") != null)
                    workflowExecute.description = workflowExecute.fields["description"].ToString();

            return workflowExecute.ToSerialize();
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("Exception request fo===" + ex.StackTrace);
        }

        await Task.CompletedTask;
        return packApi;
    }
}
