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
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.NcbsCbs.Core;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxCdlist
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
    private readonly IO9PostService _o9PostService;


    /// <summary>
    ///Tx
    /// </summary>

    public TxCdlist(IFoService foService, IAppService appService, ILangService langService, 
    IParaServerService paraServerService, IAdminGrpcService adminGrpcService, 
    IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, 
    ICdlistService cdlistService, IO9PostService o9PostService)
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
        _o9PostService = o9PostService;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> viewCdlist()
    {

        var boInput = context?.Bo?.GetBoInput();
        string tableCode = "";

        if (boInput != null)
        {
            if (boInput.ContainsKey("table_code"))
                tableCode = boInput.GetValue("table_code").ToString();
            if (tableCode != null)
            {
                var tableCodeData = boInput.SelectToken(tableCode);

                if (tableCodeData != null)
                {
                    var cdlistContent = tableCodeData.ToCdlist();
                    var getCdlist = await _cdlistService.GetByCd(cdlistContent.Cdgrp, cdlistContent.Cdname, cdlistContent.Cdid);

                    if (getCdlist == null)
                    {
                        getCdlist = new CdlistModel();
                    }

                    BuildDataJsonResponse(tableCode, getCdlist);
                    BuildErrorRunRule(new ErrorStatusModel(((int)ErrorStatus.successView)));
                    return "true";
                }
            }
        }
        BuildErrorRunRule(new ErrorStatusModel((int)ErrorStatus.errorView));
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> updateInternalCdlist()
    {
        var boInput = context?.Bo?.GetBoInput();

        var tableCodeData = boInput.SelectToken("BO_015001001_Search");
        var newCdlistAdd = tableCodeData.ToCdlist(); ;
        if (newCdlistAdd != null) await _cdlistService.Update(newCdlistAdd);


        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="table_code"></param>
    /// <param name="data"></param>
    public void BuildDataJsonResponse(string table_code, object data)
    {
        JObject obData = new JObject();
        obData.Add(table_code, JToken.FromObject(data));
        context.Bo.AddPackFo(table_code, obData);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="err"></param>
    public void BuildErrorRunRule(ErrorStatusModel err)
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", err.GetCode()));
        context.Bo.AddPackFo("errorJWebUI", obErr);
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
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
        if (string.IsNullOrEmpty(context.Bo.GetBoInput()["learn_api"].ToString()))
            context.Bo.GetBoInput()["learn_api"] = "ncbsCBS_workflow_execute_new";
        JToken rs = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            rs = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            rs = await _postApiService.GetDataPostAPI("ncbsCbs", "executeWorkflow", context);
        }
        return rs;
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
