using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Ncbs.Core;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxServiceLog
{
    /// <summary>
    ///context
    /// </summary>
    [JwebuiContextAttribute]
    public JWebUIObjectContextModel context { get; set; }
    private readonly IAppService _appService;
    private readonly IFoService _foService;
    private readonly ILangService _langService;
    private readonly IParaServerService _paraServerService;
    private readonly IAdminGrpcService _adminGrpcService;
    private readonly IPostAPIService _postApiService;
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly ICdlistService _cdlistService;
    private readonly ILearnApiService _learnApiService;
    private readonly IMediaUploadService _mediaUploadService;

    private readonly IWebSocketsService _webSocketsService;

    private readonly ILogServiceService _logServiceService;


    /// <summary>
    ///Tx
    /// </summary>

    public TxServiceLog(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, ICdlistService cdlistService, ILearnApiService learnApiService, IMediaUploadService mediaUploadService, IWebSocketsService webSocketsService, ILogServiceService logServiceService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _postApiService = postAPIService;
        _cdlistService = cdlistService;
        _learnApiService = learnApiService;
        _mediaUploadService = mediaUploadService;
        _webSocketsService = webSocketsService;
        _logServiceService = logServiceService;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<string> search()
    {
        var boInput = context.Bo.GetBoInput();

        var log = boInput["log_service"].ToObject<LogServiceSearchModel>();
        System.Console.WriteLine("getloginout..." + log.ToSerialize());



        if (log != null)
        {
            var getLog = (await _logServiceService.GetAll()).Where(l =>
             (l.LogText.Contains(log.LogText)) &&
            (l.ExecutionId.Contains(log.ExecutionId)) &&
            (l.JsonDetails.Contains(log.JsonDetails)) &&
            (l.ServiceId.Contains(log.ServiceId)) &&
            (l.StepCode.Contains(log.StepCode)) &&
            (l.StepExecutionId.Contains(log.StepExecutionId)) &&
            (l.Subject.Contains(log.Subject)) &&
            (l.LogUtc >= log.FromDate * 10000 && l.LogUtc <= log.ToDate * 10000)).ToList();

            // foreach (string name in Enum.GetNames(typeof(JITS.NeptuneClient.Scheme.Workflow.WorkflowScheme.CentralizedLogType)))
            // {
            //     System.Console.WriteLine("name===" + name);
            //     var dataLogs = getLog.FindAll(s => s.LogType.Equals(name));
            //     for (var i = 0; i < dataLogs.Count; i++)
            //     {
            //         if (i == 0) dataLogs[i].RelativeDuration = 0;
            //         else
            //         {
            //             dataLogs[i].RelativeDuration = Math.Abs(dataLogs[i].LogUtc - dataLogs[i - 1].LogUtc) / 10000;
            //         }
            //     }
            //     var obData = new JObject();
            //     obData["total_items"] = dataLogs.Count;
            //     context.Bo.AddPackFo("log_service_" + name, BuildTableCodeForArray(dataLogs.ToJArray(), "log_service_" + name));
            //     context.Bo.AddPackFo("count_" + name + "_paging", obData);

            // }

            for (var i = 0; i < getLog.Count; i++)
            {
                if (i == 0) getLog[i].RelativeDuration = 0;
                else
                {
                    getLog[i].RelativeDuration = Math.Abs(getLog[i].LogUtc - getLog[i - 1].LogUtc) / 10000;
                }
            }

            context.Bo.AddPackFo("log_service", BuildTableCodeForArray(getLog.ToJArray(), "log_service"));
            var obDataCount = new JObject();
            obDataCount["total_items"] = getLog.Count;
            context.Bo.AddPackFo("count_paging", obDataCount);
            return "true";
        }
        return "false";
    }


    /// <summary>
    /// 
    /// </summary>
    public void BuildStatusErrorResponse()
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        context.Bo.AddPackFo("errorJWebUI", obErr);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public JObject ReturnStatusPacked()
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        return obErr;
    }

    private JArray BuildTableCodeForArray(JArray arr, string tableCode)
    {
        JArray arrRes = new JArray();
        foreach (var itemArr in arr)
        {
            JObject obj = new JObject();
            obj.Add(new JProperty(tableCode, itemArr));
            arrRes.Add(obj);
        }
        return arrRes;
    }

}
