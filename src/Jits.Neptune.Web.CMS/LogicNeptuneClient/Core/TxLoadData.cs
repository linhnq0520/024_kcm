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
public class TxLoadData
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

    public TxLoadData(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, 
        ICdlistService cdlistService,
        IO9PostService o9PostService)
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
    public async Task<string> getDataSearch()
    {
        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();

        string learnApi = "";
        string tableCode = "";
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "executeWorkflow",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "executeWorkflow", context);
        }
        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        var obDataModel = new PageSearchModel()
        {
            Items = obData.SelectToken("items").ToList<object>(),
            TotalCount = obData.SelectToken("total_count") != null ? Int32.Parse(obData.SelectToken("total_count")?.ToString()) : 0,
            TotalPages = obData.SelectToken("total_pages") != null ? Int32.Parse(obData.SelectToken("total_pages")?.ToString()) : 0,
            HasPreviousPage = obData.SelectToken("has_previous_page") != null ? (bool)obData.SelectToken("has_previous_page") : false,
            HasNextPage = obData.SelectToken("has_next_page") != null ? (bool)obData.SelectToken("has_next_page") : false,

        };


        if (obDataModel == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }
        context.Bo.AddPackFo(tableCode, Utils.Utils.BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), tableCode));

        var searchResponseCMS = new SearchResponseCMSModel()
        {
            search_advanced = "false",
            total_items = obDataModel.TotalCount != 0 ? obDataModel.TotalCount : obDataModel.Items.Count
        };

        context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
        // JObject obPaging = new JObject();
        // obPaging.Add(new JProperty("total_items",));
        // obPaging.Add(new JProperty("search_advanced", "false"));

        // context.Bo.AddPackFo("table_paging", obPaging);

        JObject obErr_ = new JObject();
        obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        context.Bo.AddPackFo("errorJWebUI", obErr_);

        if (obDataModel.TotalCount == 0) return "empty";
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
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
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> loadCdlistMediaFile()
    {
        List<CdlistModel> listCdlist = new List<CdlistModel>();

        var getCdlistMEDIASTS = await _cdlistService.GetByCdgrpAndCdname("CTM", "MEDIASTS");
        if (getCdlistMEDIASTS != null && getCdlistMEDIASTS.Count > 0) listCdlist.AddRange(getCdlistMEDIASTS);
        var getCdlistCTMCATEGORIES = await _cdlistService.GetByCdgrpAndCdname("CTM", "CATEGORIES");
        if (getCdlistCTMCATEGORIES != null && getCdlistCTMCATEGORIES.Count > 0) listCdlist.AddRange(getCdlistCTMCATEGORIES);

        var getCdlistCTMTYPE = await _cdlistService.GetByCdgrpAndCdname("SYS", "CTMTYPE");
        if (getCdlistCTMTYPE != null && getCdlistCTMTYPE.Count > 0) listCdlist.AddRange(getCdlistCTMTYPE);

        context.Bo.AddPackFo("data", JArray.FromObject(listCdlist));
        return "true";
    }


}
