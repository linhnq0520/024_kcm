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
public partial class ApiNcbsCbsViewModifyCrd : ICoreAPIService
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(JToken packApi)
    {
        var workflow = packApi.ToWorkflowExecutionInquiry();
        string step_codes = workflow.execution.workflow_id + ";IFC_VIEWMODIFY_IFCBALANCE;SQL_VIEW_MODIFY_PAYMENT_SCHEDULE;SQL_VIEW_MODIFY_PRINCIPAL_PAYMENT";
        var new_data = new JObject();
        var steps = workflow.execution_steps;
        for (int i = 0; i < steps.Count; i++)
        {
            var step = steps[i];
            if (step_codes.IndexOf(step.step_code) == -1) continue;
            else
            {
                var content = JsonConvert.DeserializeObject<WorkflowStep>(step.p2_content.ToString());
                var data_res = JObject.Parse(content.response.data.ToString());

                new_data = Utils.Utils.MergeDictionary(new_data.ToDictionary(), data_res.ToDictionary()).ToJObject();
            }

        }
        await Task.CompletedTask;
        return new_data;
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
        await Task.CompletedTask;
        //Console.WriteLine("======packApi" +JsonConvert.SerializeObject(packApi));
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        if (!packApi.execution.is_success.Equals("Y")) return true;
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
        if (packApi.Status.ToUpper() == "ERROR") return true;
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
