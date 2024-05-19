using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Configuration;
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
using Jits.Neptune.Web.Framework.Services.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static JITS.NeptuneClient.Scheme.Workflow.WorkflowScheme;

namespace Jits.Neptune.Web.CMS.Jwebui.Logic;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class Txdata
{
    /// <summary>
    ///context
    /// </summary>
    [JwebuiContextAttribute]
    public JWebUIObjectContextModel context { get; set; }
    private readonly IAppService _appService;
    private readonly IFoService _foService;
    private readonly IBoService _boService;
    private readonly ILangService _langService;
    private readonly IParaServerService _paraServerService;
    private readonly IAdminGrpcService _adminGrpcService;
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly IGroupMenuService _groupMenuService;
    private readonly IPostAPIService _postApiService;
    private readonly ICdlistService _cdlistService;
    private readonly CMSSetting _cMSSetting;
    private readonly ILearnApiService _learnApiService;
    private readonly ILogServiceService _logServiceService;
    private readonly ILogger _logger;
    private readonly IAppOfRoleService _appOfRoleService;
    private readonly ILocalizationService _localizationService;
    private readonly IUserCommandService _userCommandService;
    private readonly IO9PostService _o9PostService;


    /// <summary>
    ///Tx
    /// </summary>

    public Txdata(
        ILocalizationService localizationService,
        IFoService foService,
        IAppService appService,
        ILangService langService,
        IParaServerService paraServerService,
        IAdminGrpcService adminGrpcService,
        IAuthenticationGrpcService authenticationGrpcService,
        IGroupMenuService groupMenuService,
        IPostAPIService postAPIService,
        ILearnApiService learnApiService,
        ICdlistService cdlistService,
        IBoService boService,
        CMSSetting cMSSetting,
        ILogger logger,
        ILogServiceService logServiceService,
        IAppOfRoleService appOfRoleService,
        IUserCommandService userCommandService,
        IO9PostService o9PostService
    )
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _groupMenuService = groupMenuService;
        _postApiService = postAPIService;
        _learnApiService = learnApiService;
        _cdlistService = cdlistService;
        _boService = boService;
        _cMSSetting = cMSSetting;
        _logger = logger;
        _logServiceService = logServiceService;
        _appOfRoleService = appOfRoleService;
        _localizationService = localizationService;
        _userCommandService = userCommandService;
        _o9PostService = o9PostService;

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="tableSave"></param>
    /// <returns></returns>
    public async Task<string> save(string tableSave)
    {
        var boInput = context.Bo.GetBoInput();

        var tableSave_ = tableSave.Trim();
        if (!string.IsNullOrEmpty(tableSave_))
        {
            if (boInput[tableSave_] != null)
            {
                switch (tableSave_)
                {
                    case "fo":

                        var foSave = boInput[tableSave_].ToFoEntity();
                        if (foSave != null)
                        {
                            if (
                                await _foService.GetByTxcodeAndApp(foSave.Txcode, foSave.App)
                                != null
                            )
                            {
                                context.Bo.AddErrorRunRule(
                                    new ErrorStatusModel((int)ErrorStatus.errorDuplicateData)
                                );
                                return "false";
                            }
                            await _foService.Insert(foSave);
                            context.Bo.AddPackFo<FoModel>(tableSave_, _foService.ToModel(foSave));
                            context.Bo.AddPackFo("table_code", tableSave_);
                        }
                        break;
                    case "bo":

                        var boSave = boInput[tableSave_].ToBoEntity();
                        if (boSave != null)
                        {
                            if (
                                await _foService.GetByTxcodeAndApp(boSave.Txcode, boSave.App)
                                != null
                            )
                            {
                                context.Bo.AddErrorRunRule(
                                    new ErrorStatusModel((int)ErrorStatus.errorDuplicateData)
                                );
                                return "false";
                            }
                            await _boService.Insert(boSave);
                            context.Bo.AddPackFo<BoModel>(tableSave_, _boService.ToModel(boSave));
                            context.Bo.AddPackFo("table_code", tableSave_);
                        }
                        break;
                    case "group_menu":

                        var menuSave = boInput[tableSave_].ToGroupMenuEntity();
                        if (menuSave != null)
                        {
                            if (
                                await _groupMenuService.GetByIdAndApp(
                                    menuSave.GroupMenuId,
                                    menuSave.App
                                ) != null
                            )
                            {
                                context.Bo.AddErrorRunRule(
                                    new ErrorStatusModel((int)ErrorStatus.errorDuplicateData)
                                );
                                return "false";
                            }
                            await _groupMenuService.Insert(menuSave);
                            context.Bo.AddPackFo<GroupMenuModel>(
                                tableSave_,
                                _groupMenuService.ToModel(menuSave)
                            );
                            context.Bo.AddPackFo("table_code", "group_menu_all");
                        }
                        break;
                    case "learn_api":

                        var apiSave = boInput[tableSave_].ToLearnApiEntity();
                        if (apiSave != null)
                        {
                            if (
                                await _learnApiService.GetByAppAndId(
                                    apiSave.App,
                                    apiSave.LearnApiId
                                ) != null
                            )
                            {
                                context.Bo.AddErrorRunRule(
                                    new ErrorStatusModel((int)ErrorStatus.errorDuplicateData)
                                );
                                return "false";
                            }
                            await _learnApiService.Insert(apiSave);
                            context.Bo.AddPackFo<LearnApiModel>(
                                tableSave_,
                                apiSave.ToModel<LearnApiModel>()
                            );
                            context.Bo.AddPackFo("table_code", tableSave_);
                        }
                        break;

                    case "app":
                        var appSave = await _appService.ToAppEntity(boInput[tableSave_]);

                        // var appSave = boInput[tableSave_].ToAppEntity();
                        if (appSave != null)
                        {
                            if (await _appService.GetByAppCode(appSave.ListApplicationId) != null)
                            {
                                context.Bo.AddErrorRunRule(
                                    new ErrorStatusModel((int)ErrorStatus.errorDuplicateData)
                                );
                                return "false";
                            }
                            await _appService.Insert(appSave);
                            context.Bo.AddPackFo<AppModel>(
                                tableSave_,
                                _appService.ToModel(appSave)
                            );
                            context.Bo.AddPackFo("table_code", tableSave_);
                        }
                        break;
                    case "paraserver":

                        var paraSave = boInput[tableSave_].ToParaServerEntity();
                        if (paraSave != null)
                        {
                            if (
                                await _paraServerService.GetByAppAndCode(
                                    paraSave.App,
                                    paraSave.Code
                                ) != null
                            )
                            {
                                context.Bo.AddErrorRunRule(
                                    new ErrorStatusModel((int)ErrorStatus.errorDuplicateData)
                                );
                                return "false";
                            }
                            await _paraServerService.Insert(paraSave);
                            context.Bo.AddPackFo<ParaServer>(tableSave_, paraSave);
                            context.Bo.AddPackFo("table_code", tableSave_);
                        }
                        break;

                    default:
                        break;
                }
                context.Bo.AddPackFo(tableSave_, boInput[tableSave_]);
                context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.successUpdate));
                return "true";
            }
        }
        context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.errorSave));
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="tableSave"></param>
    /// <returns></returns>
    public async Task<string> update(string tableSave)
    {
        var boInput = context.Bo.GetBoInput();
        var tableSave_ = tableSave.Trim();
        if (!string.IsNullOrEmpty(tableSave_))
        {
            if (boInput[tableSave_] != null)
            {
                context.Bo.AddPackFo(tableSave_, boInput[tableSave_]);
                switch (tableSave_)
                {
                    case "fo":

                        var foSave = boInput[tableSave_].ToFoEntity();
                        if (foSave != null)
                        {
                            await _foService.Update(foSave);
                            context.Bo.AddPackFo<FoModel>(tableSave_, _foService.ToModel(foSave));
                        }
                        context.Bo.AddPackFo("table_code", tableSave_);

                        break;
                    case "bo":
                        var boSave = boInput[tableSave_].ToBoEntity();
                        if (boSave != null)
                        {
                            if (boSave != null)
                            {
                                await _boService.Update(boSave);
                                context.Bo.AddPackFo<BoModel>(
                                    tableSave_,
                                    _boService.ToModel(boSave)
                                );
                            }
                        }
                        context.Bo.AddPackFo("table_code", tableSave_);

                        break;
                    case "group_menu":

                        var menuSave = boInput[tableSave_].ToGroupMenuEntity();
                        if (menuSave != null)
                        {
                            if (menuSave != null)
                            {
                                await _groupMenuService.Update(menuSave);
                                context.Bo.AddPackFo<GroupMenuModel>(
                                    tableSave_,
                                    _groupMenuService.ToModel(menuSave)
                                );
                            }
                        }
                        context.Bo.AddPackFo("table_code", "group_menu_all");

                        break;
                    case "learn_api":

                        var apiSave = boInput[tableSave_].ToLearnApiEntity();
                        if (apiSave != null)
                        {
                            if (apiSave != null)
                            {
                                await _learnApiService.Update(apiSave);
                                context.Bo.AddPackFo<LearnApiModel>(
                                    tableSave_,
                                    apiSave.ToModel<LearnApiModel>()
                                );
                            }
                        }
                        context.Bo.AddPackFo("table_code", tableSave_);
                        break;
                    case "paraserver":

                        var paraserverSave = boInput[tableSave_].ToParaServerEntity();
                        if (paraserverSave != null)
                        {
                            await _paraServerService.Update(paraserverSave);
                            context.Bo.AddPackFo<ParaServer>(tableSave_, paraserverSave);
                        }
                        context.Bo.AddPackFo("table_code", tableSave_);
                        break;
                    case "app":
                        var appSave = await _appService.ToAppEntity(boInput[tableSave_]);

                        // var appSave = boInput[tableSave_].ToAppEntity();
                        if (appSave != null)
                        {
                            if (appSave != null)
                            {
                                await _appService.Update(appSave);
                                context.Bo.AddPackFo<AppModel>(
                                    tableSave_,
                                    _appService.ToModel(appSave)
                                );
                            }
                        }
                        context.Bo.AddPackFo("table_code", tableSave_);
                        break;
                    case "app_role":
                        // var appSave = boInput[tableSave_].ToAppEntity();
                        var role_id = boInput.SelectToken(tableSave_ + ".role").ToString();
                        if (role_id != null)
                        {
                            var listApp = "";
                            foreach (
                                var item in boInput
                                    .SelectToken("app_role.list_application")
                                    .Values<string>()
                                    .ToList()
                            )
                            {
                                listApp += item + ";";
                            }

                            var appOfRoleItem = await _appOfRoleService.GetByRoleId(
                                int.Parse(role_id)
                            );

                            if (appOfRoleItem != null)
                            {
                                appOfRoleItem.App = listApp;


                                await _appOfRoleService.Update(
                                    appOfRoleItem.FromModel<AppOfRole>()
                                );
                            }
                            else
                            {
                                await _appOfRoleService.Insert(
                                    new AppOfRole() { App = listApp, RoleId = int.Parse(role_id) }
                                );
                            }
                        }
                        context.Bo.AddPackFo("table_code", tableSave_);

                        break;
                    default:
                        break;
                }
                context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.successUpdate));
                return "true";
            }
        }
        context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.errorUpdate));
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> view()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["table_code"] != null && boInput["table_col_key"] != null)
        {
            var tableCode = boInput["table_code"].ToString();
            var tableColKey = boInput["table_col_key"].ToString();
            var key = boInput[tableColKey];
            if (tableCode.Contains("log_service"))
            {
                var findLog = await _logServiceService.GetById(int.Parse(key.ToString()));

                if (findLog != null)
                {
                    var model_ = _logServiceService.ToLogServiceModel(findLog);
                    JObject dataReturn = new JObject();
                    dataReturn["log_service"] = model_.ToJObject();
                    context.Bo.AddPackFo("log_service", dataReturn);
                }
            }
            switch (tableCode)
            {
                case "fo":
                    var findFo = await _foService.GetById(int.Parse(key.ToString()));
                    if (findFo != null)
                    {
                        var foReturn = _foService.ToModel(findFo);
                        JObject dataReturn = new JObject();
                        dataReturn[tableCode] = foReturn.ToJObject();
                        context.Bo.AddPackFo(tableCode, dataReturn);
                    }
                    break;
                case "bo":
                    var findBo = await _boService.GetById(int.Parse(key.ToString()));
                    if (findBo != null)
                    {
                        var boReturn = _boService.ToModel(findBo);
                        JObject dataReturn = new JObject();
                        dataReturn[tableCode] = boReturn.ToJObject();
                        context.Bo.AddPackFo(tableCode, dataReturn);
                    }
                    break;
                case "learn_api":
                    var findApi = await _learnApiService.GetById(int.Parse(key.ToString()));
                    if (findApi != null)
                    {
                        var apiReturn = findApi.ToModel<LearnApiModel>();
                        JObject dataReturn = new JObject();
                        dataReturn[tableCode] = apiReturn.ToJObject();
                        context.Bo.AddPackFo(tableCode, dataReturn);
                    }
                    break;
                case "paraserver":
                    var findparaserver = await _paraServerService.GetById(
                        int.Parse(key.ToString())
                    );
                    if (findparaserver != null)
                    {
                        // var apiReturn = findparaserver.ToModel<LearnApiModel>();
                        JObject dataReturn = new JObject();
                        dataReturn[tableCode] = findparaserver.ToJObject();
                        context.Bo.AddPackFo(tableCode, dataReturn);
                    }
                    break;
                case "group_menu":
                    var findMenu = await _groupMenuService.GetById(int.Parse(key.ToString()));
                    if (findMenu != null)
                    {
                        var menuReturn = _groupMenuService.ToModel(findMenu);
                        JObject dataReturn = new JObject();
                        dataReturn[tableCode] = menuReturn.ToJObject();
                        context.Bo.AddPackFo(tableCode, dataReturn);
                    }
                    break;
                case "app":
                    var findApp = await _appService.GetById(int.Parse(key.ToString()));
                    if (findApp != null)
                    {
                        var appReturn = _appService.ToModel(findApp);
                        JObject dataReturn = new JObject();
                        dataReturn[tableCode] = appReturn.ToJObject();
                        context.Bo.AddPackFo(tableCode, dataReturn);
                    }
                    break;
                case "log_service":

                    break;
                default:
                    break;
            }
            context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.successView));
            return "true";
        }
        context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.errorView));
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="para_data"></param>
    /// <returns></returns>
    public async Task<string> dataForApp(string para_data)
    {
        var boInput = context.Bo.GetBoInput();
        // await _logServiceService.WriteLog("FUNCTION PROCESSING", "START dataForApp = " + para_data, context.Bo.GetBoInput().ToSerializeSystemText(), "Info");
// System.Console.WriteLine(
//             "Start getData ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
//         );
        try
        {
            if (!para_data.Trim().Equals(""))
            {
                var tableCodes = para_data.Split(";");
                foreach (var tableCode in tableCodes)
                {
                    if (!tableCode.Trim().Equals(""))
                    {
                        try
                        {
                            switch (tableCode.Trim())
                            {
                                // case "group_menu_all":
                                //     context.Bo.AddPackFo("group_menu", Utils.Utils.BuildTableCodeForArray(JArray.FromObject(await _groupMenuService.GetAll()), "group_menu"));
                                //     break;
                                // case "group_menu":
                                //     context.Bo.AddPackFo("group_menu", Utils.Utils.BuildTableCodeForArray(JArray.FromObject(await _groupMenuService.SearchByApp(context.InfoApp.GetApp())), "group_menu"));
                                //     break;
                                case "list_cdlist":
                                    var list_cdlist = await _cdlistService.GetByApp(
                                        context.InfoApp.GetApp()
                                    );
                                    context.Bo.AddPackFo(
                                        "c_cdlist",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(list_cdlist),
                                            "c_cdlist"
                                        )
                                    );
                                    break;
                                case "c_cdlist":
                                    var getCdlist = await _cdlistService.GetByApp(
                                        context.InfoApp.GetApp()
                                    );
                                    context.Bo.AddPackFo(
                                        "c_cdlist",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getCdlist),
                                            "c_cdlist"
                                        )
                                    );
                                    break;
                                case "fo":
                                    var getFos = await _foService.GetAll();
                                    context.Bo.AddPackFo(
                                        "fo",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getFos),
                                            "fo"
                                        )
                                    );
                                    break;
                                case "bo":
                                    var getBos = await _boService.GetAll();
                                    context.Bo.AddPackFo(
                                        "bo",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getBos),
                                            "bo"
                                        )
                                    );
                                    break;
                                case "learn_api":
                                    var getLearnApis = await _learnApiService.GetAll();
                                    context.Bo.AddPackFo(
                                        "learn_api",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getLearnApis),
                                            "learn_api"
                                        )
                                    );
                                    break;
                                case "paraserver":
                                    var getParaservers = await _paraServerService.GetAll();
                                    context.Bo.AddPackFo(
                                        "paraserver",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getParaservers),
                                            "paraserver"
                                        )
                                    );
                                    break;
                                case "app":
                                    var getApps = await _appService.GetAll();
                                    context.Bo.AddPackFo(
                                        "app",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getApps),
                                            "app"
                                        )
                                    );
                                    break;
                                case "log_service":
                                    var getLogService = await _logServiceService.GetAll();
                                    context.Bo.AddPackFo(
                                        "log_service",
                                        Utils.Utils.BuildTableCodeForArray(
                                            JArray.FromObject(getLogService),
                                            "log_service"
                                        )
                                    );
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (System.Exception ex)
                        {
                            System.Console.WriteLine("group_menu--data---" + ex.StackTrace);
                            // TODO
                        }
                    }
                }
            }

            //continue....
            var loadDataObject = new LoadDataModel()
            {
                // request_data = boInput["request_data"]?.ToModel<RequestDataModel>(),
                request_data = new RequestDataModel()
                {
                    data_form =
                        boInput.SelectToken("request_data.data_form") != null
                            ? boInput.SelectToken("request_data.data_form").ToString()
                            : "",
                    lazy_load = new LazyLoadModel()
                    {
                        c_cdlist =
                            boInput.SelectToken("request_data.lazy_load.c_cdlist") != null
                                ? boInput
                                    .SelectToken("request_data.lazy_load.c_cdlist")
                                    .ToObject<List<ItemLazyLoadCdlistModel>>()
                                : null
                    },
                    learnapi_form =
                        boInput.SelectToken("request_data.learnapi_form") != null
                            ? boInput.SelectToken("request_data.learnapi_form").ToString()
                            : "",
                    learnsql_form =
                        boInput.SelectToken("request_data.learnsql_form") != null
                            ? boInput.SelectToken("request_data.learnsql_form").ToString()
                            : ""
                },
                data_select = boInput.ContainsKey("data_select")
                    ? JsonConvert.DeserializeObject<Dictionary<string, object>>(
                        boInput["data_select"]?.ToString()
                    )
                    : null,
                table_code = boInput.ContainsKey("table_code")
                    ? boInput["table_code"]?.ToString()
                    : ""
            };

            if (loadDataObject.request_data != null)
            {
                var requestData = loadDataObject.request_data;
                JObject dataSelectResult = new JObject();
                bool flagDataSelectResult = false;
                if (!string.IsNullOrEmpty(requestData.learnapi_form))
                {
                    var listLearnApi = requestData.learnapi_form.Split(";");
                    var totalLearnApi = listLearnApi.Length;
                    var connectionCount = 10;

                    async Task Action(int i)
                    {
                        if (!listLearnApi[i].Trim().Equals(""))
                        {
                            JToken obData = null;
                            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                            {
                                obData = await _o9PostService.O9CallAPIAsync(
                                    context.InfoApp.GetApp(),
                                    "executeWorkflow",
                                    context,
                                    listLearnApi[i].Trim()
                                );
                            }
                            else
                            {
                                obData = await _postApiService.CallAPIAsync(
                                    context.InfoApp.GetApp(),
                                    "executeWorkflow",
                                    context,
                                    listLearnApi[i].Trim()
                                );
                            }

                            if (obData != null)
                            {
                                var learnApiContent = await _learnApiService.GetByAppAndId(
                                                                context.InfoApp.GetApp(),
                                                                listLearnApi[i].Trim()
                                                            );
                                if (!string.IsNullOrEmpty( learnApiContent.LearnApiNodeData))
                                {
                                    if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                                    {
                                        if (!string.IsNullOrEmpty(learnApiContent.KeyReadData))
                                        {
                                            var nodeData = learnApiContent.KeyReadData;
                                            obData = string.IsNullOrEmpty(nodeData) ? obData : obData.SelectToken(nodeData.Substring(nodeData.LastIndexOf('.') + 1));
                                        }
                                        
                                    }
                                    else
                                    {
                                        obData = obData.SelectToken(learnApiContent.LearnApiNodeData);
                                    }
                                }
                                else if(string.IsNullOrEmpty( learnApiContent.LearnApiNodeData) && GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                                {   
                                    var nodeData = learnApiContent.LearnApiNodeData;
                                    obData = string.IsNullOrEmpty(nodeData) ? obData : obData.SelectToken(nodeData.Substring(nodeData.LastIndexOf('.') + 1));
                                }
                                    
                                if (Utils.Utils.IsValidJsonObject(JsonConvert.SerializeObject(obData)))
                                {
                                    if (!learnApiContent.LearnApiData.Equals(""))
                                    {
                                        if (learnApiContent.SaveTo.Equals("client"))
                                        {
                                            context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);
                                        }
                                        else
                                        {
                                            dataSelectResult.Add(learnApiContent.LearnApiData, obData);
                                            flagDataSelectResult = true;
                                        }
                                    }
                                    else
                                    {
                                        dataSelectResult = obData.ToJObject();
                                        flagDataSelectResult = true;
                                    }
                                }
                                else
                                { //Json Array
                                    if (!string.IsNullOrEmpty( learnApiContent.LearnApiData))
                                    {
                                        if (learnApiContent.SaveTo.Equals("client"))
                                        {
                                            context.Bo.AddPackFo(
                                                learnApiContent.LearnApiData,
                                                Utils.Utils.BuildTableCodeForArray(
                                                    JArray.FromObject(obData),
                                                    learnApiContent.LearnApiData
                                                )
                                            );
                                        }
                                        else
                                        {
                                            dataSelectResult.Add(
                                                learnApiContent.LearnApiData,
                                                Utils.Utils.BuildTableCodeForArray(
                                                    JArray.FromObject(obData),
                                                    learnApiContent.LearnApiData
                                                )
                                            );
                                            flagDataSelectResult = true;
                                        }
                                    }
                                    else
                                    {
                                        dataSelectResult.Add("data", obData);
                                        flagDataSelectResult = true;
                                    }
                                }
                            }

                        }
                    }

                    var processor = new ActionBlock<int>(
                        Action,
                        new ExecutionDataflowBlockOptions()
                        {
                            MaxDegreeOfParallelism = connectionCount,
                            SingleProducerConstrained = true
                        }
                    );

                    for (var i = 0; i < totalLearnApi; i++)
                        await processor.SendAsync(i);

                    processor.Complete();
                    await processor.Completion;
                    if (flagDataSelectResult)
                        context.Bo.AddPackFo("data_select_result", dataSelectResult);
                }

                //learnsql...
            }

            context.Bo.AddErrorRunRule(new ErrorStatusModel((int)ErrorStatus.noError));
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("dataForApp===Exception--" + ex.StackTrace);
        }

        // await _logServiceService.WriteLog("FUNCTION PROCESSING", "END dataForApp = " + para_data, context.Bo.GetActionInput().ToSerializeSystemText(), "Info");
        // System.Console.WriteLine(
        //     "Done getData ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
        // );
        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="para_data"></param>
    /// <returns></returns>
    public async Task<string> data(string para_data)
    {

        var boInput = context.Bo.GetBoInput();
        if (!para_data.Trim().Equals(""))
        {
            var tableCodes = para_data.Split(";");
            foreach (var tableCode in tableCodes)
            {
                if (!tableCode.Trim().Equals(""))
                {
                    try
                    {
                        switch (tableCode.Trim())
                        {
                            case "group_menu":
                                System.Console.WriteLine("group_menu-----");

                                JArray listgroupMenu = new JArray();

                                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                                {
                                    var listCommands = (
                                        await _userCommandService.GetAllUserCommands(
                                            context.InfoApp.GetApp()
                                        )
                                    )
                                        .Where(s => !string.IsNullOrEmpty(s.GroupMenuVisible))
                                        .ToList();

                                    foreach (var item in listCommands)
                                    {
                                        var itemObj = new JObject();
                                        itemObj.Add(
                                            new JProperty(
                                                "group_menu",
                                                item.ToGroupMenuModel().ToJObject()
                                            )
                                        );
                                        listgroupMenu.Add(itemObj);
                                    }
                                }
                                else
                                {
                                    var listCommands = (
                                        await _adminGrpcService.GetUserCommandByApplicationCode(
                                            context.InfoApp.GetApp()
                                        )
                                    )
                                        .Where(s => !string.IsNullOrEmpty(s.GroupMenuVisible))
                                        .ToList();

                                    foreach (var item in listCommands)
                                    {
                                        var itemObj = new JObject();
                                        itemObj.Add(
                                            new JProperty(
                                                "group_menu",
                                                item.ToGroupMenuModel().ToJObject()
                                            )
                                        );
                                        listgroupMenu.Add(itemObj);
                                    }
                                }

                                context.Bo.AddPackFo("group_menu", listgroupMenu);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine("group_menu--data---" + ex.StackTrace);
                        AddErrorSystem("CMS.String.CantCallGrpcAdmin");
                        // TODO
                    }
                }
            }
        }

        //continue....

        return "true";
    }
    private async void AddErrorSystem(string keyError)
    {
        try
        {
            var Error_string=await _localizationService.GetResource(keyError, context.InfoUser.GetUserLogin().Lang);
                
            List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
            listError.Add(
                Utils.Utils.AddActionError(
                        ErrorType.errorSystem,
                        ErrorMainForm.danger,
                        Error_string,
                        "",
                        "#ERROR_SYSTEM: "
                )
            );
            context.Bo.AddActionErrorAll(listError);
        }
        catch (System.Exception ex)
        {
             // TODO
               System.Console.WriteLine(ex.ToString());
             var Error_string="Can't connect to database. Please check your database!";
            List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
            listError.Add(
                Utils.Utils.AddActionError(
                        ErrorType.errorSystem,
                        ErrorMainForm.danger,
                        Error_string,
                        "",
                        "#ERROR_SYSTEM: "
                )
            );
            context.Bo.AddActionErrorAll(listError);
        }
    }
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> dataLazyLoad()
    {
        var boInput = JObject.FromObject(context.Bo.GetBoInput());
        // await _logServiceService.WriteLog("FUNCTION PROCESSING", "START dataLazyLoad cdlist", context.Bo.GetBoInput().ToSerializeSystemText(), "Info");

        if (boInput.ContainsKey("request_data"))
            if (boInput.GetValue("request_data") != null)
            {
                var requestData = JObject.FromObject(boInput.GetValue("request_data"));
                if (requestData.ContainsKey("lazy_load"))
                    if (requestData.GetValue("lazy_load") != null)
                    {
                        var lazyLoad = new LazyLoadModel()
                        {
                            c_cdlist =
                                boInput.SelectToken("request_data.lazy_load.c_cdlist") != null
                                    ? boInput
                                        .SelectToken("request_data.lazy_load.c_cdlist")
                                        .ToObject<List<ItemLazyLoadCdlistModel>>()
                                    : null
                        };

                        if (lazyLoad.c_cdlist != null)
                        {
                            List<CdlistModel> listCdlist = new List<CdlistModel>();
                            Dictionary<string, bool> cacheCdlist = new Dictionary<string, bool>();
                            var listCdlistLoop = lazyLoad.c_cdlist
                                .DistinctBy(m => new { m.dbcoffee_col1, m.dbcoffee_col2 })
                                .ToList();

                            foreach (var itemCdlist in listCdlistLoop)
                            {
                                if (
                                    !itemCdlist.dbcoffee_create
                                    && !itemCdlist.dbcoffee_col1.Equals("")
                                    && !itemCdlist.dbcoffee_col2.Equals("")
                                )
                                {
                                    var getCdlist_ = await _cdlistService.GetByCdgrpAndCdname(
                                        itemCdlist.dbcoffee_col1,
                                        itemCdlist.dbcoffee_col2
                                    );

                                    if (getCdlist_.Count > 0)
                                        listCdlist.AddRange(getCdlist_);
                                }
                            }

                            context.Bo.AddPackFo(
                                "c_cdlist",
                                Utils.Utils.BuildTableCodeForArray(
                                    JArray.FromObject(listCdlist),
                                    "c_cdlist"
                                )
                            );
                        }
                    }
            }
        // await _logServiceService.WriteLog("FUNCTION PROCESSING", "END dataLazyLoad cdlist", context.Bo.GetActionInput().ToSerializeSystemText(), "Info");

        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<string> dataBigbandwidth(string data)
    {
        await Task.CompletedTask;

        return "true";
    }
}
