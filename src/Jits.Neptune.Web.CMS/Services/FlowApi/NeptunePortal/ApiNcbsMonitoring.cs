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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.FlowApi;

/// <summary>
/// ICoreAPIService service
/// </summary>
public partial class ApiNcbsMonitoring : ICoreAPIService
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
        // try
        // {
        //     var executeResult = packApi.ToSerializeSystemTextWithModel<ExecuteResponseModel>();
        //     if (executeResult != null && executeResult.Data != null)
        //         return JToken.FromObject(executeResult.Data);
        //     else return packApi;
        // }
        // catch (System.Exception ex)
        // {
        //     // TODO
        //     return packApi;
        // }
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

        listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, responseApiModel.error_message, "", ""));
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
        // System.Console.WriteLine(packApi.ToSerialize());
        await Task.CompletedTask;
        if(packApi.execution==null || packApi.execution_steps==null||packApi.error_message!=null && packApi.error_message!="") return true;
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
        if (packApi.Status.Equals("ERROR")) return true;
        return false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseApiModel"></param>
    /// <returns></returns>
    public async Task<List<ErrorInfoModel>> BuildError(ExecuteResponseModel responseApiModel)
    {
        await Task.CompletedTask;
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, responseApiModel.Description, "", "Error : "));
        return listError;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(ExecuteResponseModel packApi)
    {
        await Task.CompletedTask;
        var result = packApi;

        return result.ToJToken();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<string> BuildRequest(string packApi)
    {
        await Task.CompletedTask;
        return packApi;
    }
}
