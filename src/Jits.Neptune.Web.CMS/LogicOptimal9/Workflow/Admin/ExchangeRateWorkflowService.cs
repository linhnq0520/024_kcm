using Jits.Neptune.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.Framework.Services.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Common.O9Extensions;
using Jits.Neptune.Web.CMS.Models.AdminModels;
using System.Collections.Generic;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using static LinqToDB.Common.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// 
/// </summary>
public class ExchangeRateWorkflowService : IExchangeRateWorkflowService
{
    private readonly ISettingService _settingService;
    private readonly IBaseWorkflowService _baseWorkflowService;
    private readonly IMappingService _mappingService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingService"></param>
    /// <param name="baseWorkflowService"></param>
    /// <param name="mappingService"></param>
    public ExchangeRateWorkflowService(ISettingService settingService, 
        IBaseWorkflowService baseWorkflowService,
        IMappingService mappingService)
    {
        _settingService = settingService;
        _baseWorkflowService = baseWorkflowService;
        _mappingService = mappingService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> GetLastUpdateFxRate(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        try
        {
            var branchHost = await _settingService.GetSettingByKey<string>("Admin.HostBranch");
            JObject jsrequest = new()
            {
                { "B", branchHost }
            };
            string strResult = O9Utils.GenJsonBodyRequest(jsrequest, "ADM_UTIL_GET_FXRATELASTDATE");

            var result = strResult.ToJToken();//O9Utils.AnalysisBOResult(strResult);
            return result;
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> GetLastUpdateFxRateAtLocal(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        try
        {
            var branchId = workflow.user_sessions.UsrBranchid;
            JObject jsrequest = new()
            {
                { "B", branchId }
            };
            string strResult = O9Utils.GenJsonBodyRequest(jsrequest, workflow.WorkflowFunc);

            var result = O9Utils.AnalysisBOResult(strResult);
            return result;
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> GetLocalCurrencyRate(WorkflowRequestModel workflow)
    {
        try
        {
            var result = await _baseWorkflowService.SearchData(workflow, true);
            //var mappingResult = await _mappingService.MappingResponse(workflow.MappingResponse, result.SelectToken("data"));
            var fxRates = result.SelectToken("data")?.MapToModel<List<FXRate>>();
            var lastUpdated = await GetLastUpdateFxRate(workflow);
            var response = new ForeignExchangeRateViewResponseModel()
            {
                WorkingDate = CMS.Utils.Utils.ConvertFromUnixTimestampMilisecond(lastUpdated.ToObject<long>(), false),
                FXRateData = fxRates
            };
            return response.BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> Update(WorkflowRequestModel workflow)
    {
        try
        {
            JArray jsData = workflow.ObjectField["data_modify"] as JArray;
            if(jsData.Count == 0)
            {
                return jsData.BuildWorkflowResponseSuccess(false);
            }
            JArray jsCcrcd = new();
            JArray jsRttype = new();
            JArray jsBcyrate = new();

            foreach (var js in jsData.Children<JObject>())
            {
                jsCcrcd.Add(js.Value<string>("currency_code"));
                jsRttype.Add(js.Value<string>("exchange_rate_type"));
                jsBcyrate.Add(js.Value<decimal>("base_currency_rate"));
            }

            JObject jsRequest = new()
                {
                    { "CCRCD", jsCcrcd },
                    { "RTTYPE", jsRttype },
                    { "BCYRATE", jsBcyrate }
                };

            JsonTableName clsJsonTableName = new();
            clsJsonTableName.TXBODY.Add(new JsonData(workflow.TableName, jsRequest));

            string strResult = O9Utils.GenJsonBackOfficeRequest(workflow.user_sessions, workflow.WorkflowFunc, clsJsonTableName.TXBODY);

            var result = O9Utils.AnalysisBOResult(strResult);
            return result.BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }
}
