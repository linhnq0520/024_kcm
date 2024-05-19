using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.FlowApi;

/// <summary>
/// ICoreAPIService service
/// </summary>
public partial class ApiNcbsCbsDirectlyCallService : ICoreAPIService
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
        JToken result = packApi;
        await Task.CompletedTask;

        return result;
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
                            string[] list_error = dataProcess.response.error_message.Split("\n").Where(s => !string.IsNullOrEmpty(s)).ToArray();
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

        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<bool> CheckHasError(ExecuteResponseModel packApi)
    {
        // if (packApi.Status == null) return true;
        // if (packApi.Status.Equals("ERROR")) return true;
        await Task.CompletedTask;

        return true;
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
    /// <returns></returns>
    public async Task<string> BuildRequest(string packApi)
    {
        await Task.CompletedTask;

        return packApi;
    }

}
