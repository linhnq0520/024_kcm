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
public partial class ApiNcbsDashBoardChart : ICoreAPIService
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

        if (responseApiModel.execution_steps != null)
        {
            foreach (var itemStep in responseApiModel.execution_steps)
            {
                var dataProcess = itemStep.p2_content.ToExecutionStepProcess();

                if (dataProcess != null && dataProcess.response != null)
                {
                    if (dataProcess.response.status != 0)
                    {
                        var errorMeg = itemStep.step_code + " : " + dataProcess.response.data.GetErrorMessage();
                        listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, errorMeg, "", ""));
                    }
                }
            }
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
        var response = packApi.ToJToken();

        if (response.SelectToken("data.results") != null)
        {
            var results = response.SelectToken("data.results");
            JArray new_results = new JArray();
            foreach (var item in results)
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                item["utc_from_time"] = start.AddMilliseconds(Double.Parse(item.SelectToken("utc_from_time").ToString())).ToLocalTime().ToString();
                item["utc_to_time"] = start.AddMilliseconds(Double.Parse(item.SelectToken("utc_to_time").ToString())).ToLocalTime().ToString();
                //System.Console.WriteLine("item ======" + item);
                new_results.Add(item);
            }
            response["data"]["results"] = new_results;
        }
        await Task.CompletedTask;
        //System.Console.WriteLine("response ======" + response);
        return response;
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