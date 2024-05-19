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
public partial class ApiNcbsCbsFoF8ViewInput : ICoreAPIService
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

    private JToken buildF8FromWorkflowInput(JToken packApi)
    {
        var workflow = packApi.ToWorkflowExecutionInquiry();
        var workflowInput = JObject.Parse(workflow.execution.input.ToString());
        if (workflow != null)
        {
            if (EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput().SelectToken("user.username") != null)
            {
                EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput()["execution_id"] = workflow.execution.execution_id;
                // workflowInput["fields"]["user_approve"] = EngineContext.Current.Resolve<JWebUIObjectContextModel>().Bo.GetBoInput().SelectToken("user.username").ToString();
            }
            else
            {
                workflowInput["fields"]["ref_id"] = workflow.execution.execution_id;
            }
        }

        return workflowInput;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(JToken packApi)
    {
        await Task.CompletedTask;
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
                return buildF8FromWorkflowInput(packApi);
            }
        }

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
        //Console.WriteLine("======packApi" +JsonConvert.SerializeObject(packApi));
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
