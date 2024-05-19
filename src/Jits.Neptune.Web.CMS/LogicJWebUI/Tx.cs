using System;
using System.Collections.Generic;
using System.Globalization;
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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Services.Logging;
using Jits.Neptune.Web.Framework.Services.Security;
using LinqToDB.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Microsoft.VisualStudio.Services.CircuitBreaker;
using static Jits.Neptune.Web.CMS.Models.O9Model.ResponseToCMS.LoginResponseToCMSModel;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using System.Linq.Dynamic.Core.Tokenizer;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;

namespace Jits.Neptune.Web.CMS.Jwebui.Logic;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class Tx
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
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly IFormOfRoleService _formOfRoleService;
    private readonly IFormService _formService;
    private readonly IPostAPIService _postAPIService;
    private readonly IMediaUploadService _mediaUploadService;
    private readonly IGroupMenuService _groupMenuService;
    private readonly IWebSocketsService _webSocketsService;
    private readonly CMSSetting _cMSSetting;
    private readonly ILogger _logger;
    private readonly ILogServiceService _logServiceService;
    private readonly IShortcutConfigService _shortcutConfigService;
    private readonly IFormShortcutService _formShortcutService;
    private readonly ILocalizationService _localizationService;
    private readonly IO9PostService _o9PostService;
    private readonly IMemoryCache _memoryCache;

    //
    private readonly IAdminServices _adminService;
    //private readonly AuthenticateService _authenticateService;
    //

    //private readonly IConnectionMultiplexer _redisContext =
    //    Singleton<IConnectionMultiplexer>.Instance;

    private readonly IUserSessionsService _userSessions;
    private readonly IUserCommandService _userCommand;


    /// <summary>
    ///Tx
    /// </summary>

    public Tx(
        IFoService foService,
        IAppService appService,
        ILangService langService,
        IParaServerService paraServerService,
        IAdminServices adminService,
        IAdminGrpcService adminGrpcService,
        IAuthenticationGrpcService authenticationGrpcService,
        IFormOfRoleService formOfRoleService,
        IFormService formService,
        IPostAPIService postAPIService,
        IMediaUploadService mediaUploadService,
        IGroupMenuService groupMenuService,
        CMSSetting cMSSetting,
        IWebSocketsService webSocketsService,
        ILogger logger,
        ILogServiceService logServiceService,
        IShortcutConfigService shortcutConfigService,
        IFormShortcutService formShortcutService,
        ILocalizationService localizationService,
        IO9PostService o9PostService,
        IUserSessionsService userSessions,
        IUserCommandService userCommand,
        IMemoryCache memoryCache
    )
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminService = adminService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _formOfRoleService = formOfRoleService;
        _formService = formService;
        _postAPIService = postAPIService;
        _mediaUploadService = mediaUploadService;
        _groupMenuService = groupMenuService;
        _cMSSetting = cMSSetting;
        _webSocketsService = webSocketsService;
        _logger = logger;
        _logServiceService = logServiceService;
        _shortcutConfigService = shortcutConfigService;
        _formShortcutService = formShortcutService;
        _localizationService = localizationService;
        _o9PostService = o9PostService;
        _userSessions = userSessions;
        _userCommand = userCommand;
        _memoryCache = memoryCache;
    }

    /// <summary>
    ///getDevice
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loadTxCodeFo()
    {
        JObject boInput = context?.Bo?.GetBoInput();

        if (boInput != null)
        {
            if (boInput.ContainsKey("list_tx"))
            {
                string[] ss_ = boInput.GetValue("list_tx").ToString().Split(";");
                JArray listTxFo = new JArray();
                foreach (var s in ss_)
                {
                    string txCodeFo = s;
                    string cross_application = context.InfoApp.GetApp();
                    if (txCodeFo.Contains("#") && txCodeFo.Contains(":"))
                    {
                        string[] cross_1 = txCodeFo.Split(":");
                        if (cross_1.Length > 1)
                        {
                            cross_application = cross_1[0].Substring(1, cross_1[0].Length - 1);
                            txCodeFo = txCodeFo.Replace("#" + cross_application + ":", "").Trim();
                        }
                    }
                    try
                    {
                        var fo = await _foService.GetByTxcodeAndApp(txCodeFo, cross_application);
                        if (fo == null)
                        {
                            JObject mapError = new JObject();
                            mapError.Add(
                                new JProperty(
                                    "loadTxCodeFo_ERR",
                                    $"Cant not read txFO file: {cross_application}:{txCodeFo}"
                                )
                            );
                            context.Bo.AddPackFo("loadTxCodeFo_ERR", mapError);
                        }
                        else
                        {
                            fo.Txcode = "#" + cross_application + ":" + fo.Txcode;
                            listTxFo.Add(JToken.FromObject(fo));
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine(ex.StackTrace);
                        AddErrorSystem("CMS.String.CantConnectDb");
                        // TODO
                    }
                }
                context.Bo.AddPackFo("txClient", listTxFo);
            }
        }
        return "true";
    }

    private async Task<Dictionary<string, Dictionary<string, GetDeviceModel>>> getDevicesByUserId(
        string user_id
    )
    {
        Dictionary<string, Dictionary<string, GetDeviceModel>> devices =
            new Dictionary<string, Dictionary<string, GetDeviceModel>>();

        context.Bo.GetBoInput()["usrid"] = Int32.Parse(user_id);
        context.Bo.GetBoInput()["learn_api"] = "SQL_ADVANCED_SEARCH_USER_SESSION";
        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postAPIService.GetDataPostAPI("ncbs", "getDevice", context);
        }
        if (obData != null)
        {
            var listSession = obData
                .ToObject<List<UserSessionSearchResponseModel>>()
                .Where(s => !string.IsNullOrEmpty(s.ApplicationCode));


            // 20240404 - NhanTH
            GetUserAccountByIdResponse getInfoAccount = null;
            List<RoleOfUser> rolesOfUser = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                getInfoAccount = await _adminService.GetUserAccountById(user_id);
                rolesOfUser = await _adminService.GetListRoleByUserId(user_id);
            }
            else
            {
                getInfoAccount = await _adminGrpcService.GetUserAccountById(user_id);
                rolesOfUser = await _adminGrpcService.GetListRoleByUserId(user_id);
            }
            // 
            string listRoles = "";

            foreach (var item in rolesOfUser)
            {
                listRoles += ";" + item.RoleId.ToString();
            }

            List<GetDeviceModel> devicesApp = new List<GetDeviceModel>();

            foreach (var itemSession in listSession)
            {
                if (!string.IsNullOrEmpty(itemSession.ApplicationCode))
                {
                    var dataDevice = new GetDeviceModel()
                    {
                        app_name = itemSession.ApplicationCode,
                        email = getInfoAccount.LoginName,
                        user_id = user_id,
                        token_webui = itemSession.Token,
                        info = itemSession.Info,
                        role_user = JsonConvert.SerializeObject(
                            listRoles.Split(";").Where(s => !s.Equals(""))
                        ),
                        status = itemSession.Acttype.Equals("I")
                            ? "Active"
                            : (itemSession.Acttype.Equals("L") ? "Locked" : itemSession.Acttype),
                        logined = itemSession.Ssntime.ToString("dd/MM/yyyy hh:mm tt")
                    };
                    devicesApp.Add(dataDevice);
                }
            }

            foreach (var itemApp in (await _appService.GetAll()).Where(s => s.status.Equals("A")))
            {
                devices[itemApp.ListApplicationId] = new Dictionary<string, GetDeviceModel>();
                foreach (
                    var itemSession in devicesApp.Where(
                        s => s.app_name.Equals(itemApp.ListApplicationId)
                    )
                )
                {
                    devices[itemApp.ListApplicationId][itemSession.token_webui] = itemSession;
                }
            }
        }
        return devices;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="user_id"></param>
    /// <returns></returns>
    public async Task<string> getDevice(string user_id)
    {
        try
        {
            if (!string.IsNullOrEmpty(user_id))
            {
                Dictionary<string, Dictionary<string, GetDeviceModel>> devices =
                    await getDevicesByUserId(user_id);
                context.Bo.AddPackFo("device", devices);
                return "true";
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("Exception get device===" + ex.StackTrace);
        }

        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> reLoginOfToken()
    {
        var statusLogin = new JObject();
        var boInput = context.Bo.GetBoInput();
        if (boInput["p"] != null)
        {
            var password = boInput["p"].ToString();

            // 20240404 - NhanTH
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var username = (await _adminService.GetUserAccountById(context.InfoUser.GetUserLogin().UserId.ToString())).LoginName;

                if (await _adminService.VerifyPassword(username, password))
                {
                    await _adminService.UpdateActtype(context.InfoUser.GetUserLogin().Token, "I");

                    statusLogin["status_login"] = "login#127";
                }
                else
                {
                    statusLogin["status_login"] = "login#101";
                }
            }
            else
            {
                var username = (await _adminGrpcService.GetUserAccountById(context.InfoUser.GetUserLogin().UserId.ToString())).LoginName;

                if (await _adminGrpcService.VerifyPassword(username, password))
                {
                    if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                    {
                        await _adminService.UpdateActtype(context.InfoUser.GetUserLogin().Token, "I");

                        statusLogin["status_login"] = "login#127";
                    }
                    else
                    {
                        await _adminGrpcService.UpdateActtype(context.InfoUser.GetUserLogin().Token, "I");

                        statusLogin["status_login"] = "login#127";
                    }

                }
                else
                {
                    statusLogin["status_login"] = "login#101";
                }
            }
            //

        }
        else
        {
            statusLogin["status_login"] = "login#405";
        }
        context.Bo.AddPackFo("login-status", statusLogin);
        return "true";
    }

    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getUserProfileDefaultSys()
    {
        var configUserDefault = new ListLangConfigModel();
        try
        {
            // var getParas = await _paraServerService.GetByApp(context.InfoApp.GetApp());
            // if (getParas != null)
            // {
            //     foreach (var itemPara in getParas)
            //     {
            //         if (itemPara.Code.Equals("list_lang_config"))
            //         {
            //             System.Console.WriteLine("itemPara.Value===" + itemPara.Value);
            //             configUserDefault.ListLangConfig = JToken.Parse(itemPara.Value).ToObject<List<LangConfig>>();

            //         }
            //     }
            // }
            configUserDefault.ListLangConfig = JToken
                .Parse(_cMSSetting.ListLangConfig)
                .ToObject<List<LangConfig>>();

            if (configUserDefault.ListLangConfig.Count == 0)
            {
                configUserDefault.ListLangConfig.Add(
                    new LangConfig()
                    {
                        key = "en",
                        img = "../rs/global/img/uk.png",
                        view = "English",
                        selected = true
                    }
                );
                configUserDefault.ListLangConfig.Add(
                    new LangConfig()
                    {
                        key = "vi",
                        view = "Tiếng Việt",
                        img = "../rs/global/img/vietnam.png"
                    }
                );
            }

            context.Bo.AddPackFo<ListLangConfigModel>("UserProfileDefaultSys", configUserDefault);
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("?what happend===" + ex.StackTrace);
            AddErrorSystem("CMS.String.CantConnectDb");
            return "false";

        }
        await Task.CompletedTask;
        return "true";
    }

    /// <summary>
    ///getListAll
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getListAll()
    {
        try
        {
            context.Bo.AddPackFo(
                "list_appliaction",
                Utils.Utils.BuildTableCodeForArray(
                    _appService
                        .GetAll()
                        .GetAwaiter()
                        .GetResult()
                        .FindAll(s => s.status.Equals("A"))
                        .ToJArray(),
                    "list_appliaction"
                )
            );
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("getListAll--Exception---" + ex.StackTrace);
            AddErrorSystem("CMS.String.CantConnectDb");
            return "false";
            // TODO
        }
        await Task.CompletedTask;

        return "true";
    }

    /// <summary>
    ///  lang_data
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> lang_data()
    {
        try
        {
            var boInput = context?.Bo?.GetBoInput();
            if (boInput.ContainsKey("lang_data"))
            {
                var strLang = boInput["lang_data"].ToString();

                if (boInput.ContainsKey("isStart"))
                {
                    if ((bool)boInput["isStart"]) { }
                }
                if (strLang.Contains(";"))
                {
                    string[] s_strLang = strLang.ToString().Split(";");
                    foreach (var sItem in s_strLang)
                    {
                        if (sItem.Trim() != "")
                        {
                            //get sys lang
                            var strLangSys = await _langService.GetByApp("sys");
                            if (strLangSys != null)
                                if (strLangSys.ContainsKey(sItem))
                                    context.Bo.AddPackFo(
                                        "sys_lang_data_" + sItem,
                                        JObject.FromObject(strLangSys[sItem])
                                    );
                                else
                                    context.Bo.AddPackFo("sys_lang_data_" + sItem, new JObject());

                            //get app lang
                            var strLangApp = await _langService.GetByApp(context.InfoApp.GetApp());
                            if (strLangApp != null)
                                if (strLangApp.ContainsKey(sItem))
                                    context.Bo.AddPackFo(
                                        "lang_data_" + sItem,
                                        strLangApp[sItem].ToJObject()
                                    );
                                else
                                    context.Bo.AddPackFo("lang_data_" + sItem, new JObject());
                        }
                    }
                    return "true";
                }
                else
                {
                    if (strLang.ToString().Trim() != "")
                    {
                        //get sys lang
                        var strLangSys = await _langService.GetByApp("sys");

                        if (strLang != null)
                            context.Bo.AddPackFo(
                                "sys_lang_data",
                                strLangSys[strLang.ToString().Trim()].ToJObject()
                            );
                        else
                            context.Bo.AddPackFo("sys_lang_data", new JObject());
                        //get app lang
                        var strLangApp = _langService.GetByApp(context.InfoApp.GetApp()).Result;
                        if (strLangApp != null)
                            context.Bo.AddPackFo(
                                "lang_data",
                                strLangApp[strLang.ToString().Trim()].ToJObject()
                            );
                        else
                            context.Bo.AddPackFo("lang_data", new JObject());
                    }
                    return "true";
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.ToString());
            AddErrorSystem("CMS.String.CantConnectDb");
            return "false";
        }

        // EngineContext.Current.Resolve<JWebUIObjectContextModel>() = context;

        return "false";
    }

    /// <summary>
    ///loadAllParaServer
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loadAllParaServer()
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();

        Dictionary<string, ParaServerModel> paraApp = new Dictionary<string, ParaServerModel>();
        List<ParaServerModel> dataParaRs = new List<ParaServerModel>();
        try
        {
            var listPara = _paraServerService
            .GetByApp(context.InfoApp.GetApp())
            .GetAwaiter()
            .GetResult();
            if (listPara.Count > 0)
            {
                foreach (var itemPara in listPara)
                {
                    // var itemPara_ = itemPara.ToDictionary();
                    // itemPara_.Remove("app");
                    paraApp.Add(itemPara.Code, itemPara);
                }
            }

            //get para app sys and merge
            var listParaSys = _paraServerService.GetByApp("sys").GetAwaiter().GetResult();

            if (listParaSys.Count > 0)
            {
                foreach (var itemParasys in listParaSys)
                {
                    if (paraApp.ContainsKey(itemParasys.Code))
                    {
                        dataParaRs.Add(paraApp.GetValueOrDefault(itemParasys.Code));
                        paraApp.Remove(itemParasys.Code);
                    }
                    else
                    {
                        dataParaRs.Add(itemParasys);
                    }
                }
            }

            foreach (var item in paraApp)
            {
                dataParaRs.Add(item.Value);
            }

            context.Bo.AddPackFo("paraServer", dataParaRs.ToJToken());
        }
        catch (System.Exception)
        {

            AddErrorSystem("CMS.String.CantConnectDb");
            return "false";
        }

        await Task.CompletedTask;

        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [JwebuiFunctionAttribute]
    public async Task<string> login()
    {

        JObject boInput = JObject.FromObject(context.Bo.GetBoInput());
        string LOGIN_SUCCESS = "login#127";

        if (boInput == null)
            return "false";
        JObject statusLogin = new JObject();

        //26/1/2022
        //thì không cho đăng nhập
        if (!boInput["e"].ToString().Trim().Equals(""))
        {
            string email = boInput["e"].ToString().Trim();
            //lấy sys/data/<email.txt>
            //nếu user_status == I -> status_login.error_login : login#104
        }

        if (boInput.ContainsKey("session_id"))
        {
            //
            //Khôi phục đăng nhập từ session_id
            var infoUser = context.InfoUser.GetUserLogin();

            string token = boInput.GetValue("session_id").ToString();

            System.Console.WriteLine("login=UpdateSessionApplicationCode====" + context.InfoApp.GetApp());

            try
            {
                string _actionType = "";
                string _listCommand = "";

                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    await _userSessions.UpdateSessionMacAndApplicationCode(
                                                token,
                                                context.InfoRequest.DeviceID,
                                                context.InfoApp.GetApp()
                    );

                    var sessionRecord = await _userSessions.GetByToken(infoUser.Token);

                    _actionType = sessionRecord.Acttype;
                    _listCommand = sessionRecord.CommandList;
                }
                else
                {

                    await _adminGrpcService.UpdateSessionMacAndApplicationCode(
                                                token,
                                                context.InfoRequest.DeviceID,
                                                context.InfoApp.GetApp()
                    );

                    var sessionRecord = await _adminGrpcService.GetSessionByToken(infoUser.Token);

                    _actionType = sessionRecord.Acttype;
                }

                var obUser = new LoadUserIDModel()
                {
                    Id = infoUser.Token,
                    PortalToken = infoUser.PortalToken,
                    UserIdFind = infoUser.UserId.ToString(),
                    status = _actionType
                };

                context.Bo.AddPackFo<LoadUserIDModel>("loadUserID", obUser);
                var configUserDefault = new ListLangConfigModel();

                configUserDefault.ListLangConfig = JToken
                    .Parse(_cMSSetting.ListLangConfig)
                    .ToObject<List<LangConfig>>();

                if (configUserDefault.ListLangConfig.Count == 0)
                {
                    configUserDefault.ListLangConfig.Add(new LangConfig());
                    configUserDefault.ListLangConfig.Add(
                        new LangConfig()
                        {
                            key = "vi",
                            view = "Tiếng Việt",
                            img = "../rs/global/img/vietnam.png"
                        }
                    );
                }

                context.Bo.AddPackFo<ListLangConfigModel>("loadUserConfigDefault", configUserDefault);


                string listRoles = "";
                Dictionary<string, bool> loadRoleCache = new Dictionary<string, bool>();
                Dictionary<string, bool> loadRoleApprove = new Dictionary<string, bool>();

                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    var listAllCommand = await _userCommand.GetAllUserCommandModel(context.InfoApp.GetApp());
                    foreach (var item in listAllCommand)
                    {
                        if (_listCommand.Split(",").Where(s => s.Equals(item.CommandId)).Any())
                        {
                            string formId = item.GroupMenuId.HasValue() ? item.GroupMenuId : item.CommandId;

                            if (!loadRoleCache.ContainsKey(formId) && !loadRoleApprove.ContainsKey(formId))
                            {
                                loadRoleCache.Add(formId, true);
                                loadRoleApprove.Add(formId, true);
                            }
                            else
                            {
                                if (loadRoleCache[formId])
                                    loadRoleCache[formId] = true;
                                if (loadRoleApprove[formId])
                                    loadRoleApprove[formId] = true;
                            }
                        }
                    }
                }

                List<RoleOfUser> rolesOfUser = null;
                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    rolesOfUser = await _adminService.GetListRoleByUserId(infoUser.UserId.ToString());
                }
                else
                {
                    rolesOfUser = await _adminGrpcService.GetListRoleByUserId(infoUser.UserId.ToString());
                }
                //var rolesOfUser = await _adminGrpcService.GetListRoleByUserId(
                //    infoUser.UserId.ToString()
                //);

                foreach (var item in rolesOfUser)
                {
                    listRoles += ";" + item.RoleId.ToString();
                    var listRoleUserRight = await BuildRoleCacheOfUser(item.RoleId, context.InfoApp.GetApp());
                    foreach (var item_ in listRoleUserRight)
                    {
                        if (!loadRoleCache.ContainsKey(item_.FormId) && !loadRoleApprove.ContainsKey(item_.FormId))
                        {
                            loadRoleCache.Add(item_.FormId, item_.Invoke);
                            loadRoleApprove.Add(item_.FormId, item_.Approve);
                        }
                        else
                        {
                            if (loadRoleCache[item_.FormId] || item_.Invoke)
                                loadRoleCache[item_.FormId] = true;
                            if (loadRoleApprove[item_.FormId] || item_.Approve)
                                loadRoleApprove[item_.FormId] = true;
                        }
                    }
                }
                context.Bo.AddPackFo("loadRoleCache", JObject.FromObject(loadRoleCache));
                context.Bo.AddPackFo("loadRoleApprove", JObject.FromObject(loadRoleApprove));

                context.Bo.AddPackFo(
                    "loadUserRole",
                    JArray.FromObject(listRoles.Split(";").Where(s => !s.Equals("")))
                );

                statusLogin.Add(new JProperty("status_login", LOGIN_SUCCESS));
            }
            catch (System.Exception ex)
            {
                // TODO
                System.Console.WriteLine(ex.ToString());
                AddErrorSystem("CMS.String.CantCallGrpcAdmin");
                return "false";
            }
        }
        else
        {
            try
            {
                string inputEmail = boInput["e"].ToString().Trim();
                string inputPwd = boInput["p"].ToString().Trim();
                string inputADPwd = boInput["ad_p"].ToString().Trim();

                if (inputEmail.Equals(""))
                {
                    statusLogin.Add(new JProperty("error_login", "login#101"));
                    context.Bo.AddPackFo("login-status", statusLogin);
                    return "true";
                }

                //validate session-device mode

                if (!GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    var validateUserSession = await ValidateSessionMode(
                        inputEmail,
                        context.InfoRequest.DeviceID
                    );

                    if (!validateUserSession.IsValid)
                    {
                        statusLogin.Add(new JProperty("error_login", validateUserSession.ErrorCode));
                        statusLogin.Add(new JProperty("message", validateUserSession.ErrorMsg));
                        context.Bo.AddPackFo("login-status", statusLogin);
                        return "false";
                    }

                    var loginPortalResponse = await _authenticationGrpcService.GetAuthenticationToken(
                        _cMSSetting.UserPortal,
                       EngineContext.Current.Resolve<IEncryptionService>().DecryptText(_cMSSetting.PasswordPoral)
                    );

                    var dataLoginPortal = JObject.Parse(loginPortalResponse);

                    context.InfoUser.GetUserLogin().PortalToken = dataLoginPortal["token"]?.ToString();
                }

                //End update 23/03/2024

                context.Bo.GetBoInput()["username"] = inputEmail;
                context.Bo.GetBoInput()["password"] = inputPwd;
                context.Bo.GetBoInput()["ad_password"] = inputADPwd;

                context.Bo.GetBoInput()["learn_api"] = "ncbsCBS_workflow_execute";

                JToken loginResponseObj = null;

                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    loginResponseObj = await _o9PostService.GetDataPostAPI(
                        "ncbsCbs",
                        "login",
                        context
                    );
                }
                else
                {
                    loginResponseObj = await _postAPIService.GetDataPostAPI(
                        "ncbsCbs",
                        "login",
                        context
                    );
                }


                //var loginResponse = await _adminGrpcService.Authenticate(inputEmail, inputPwd);
                if (loginResponseObj != null)
                {
                    var loginResponse = loginResponseObj["login"].ToObject<AuthenticateResponse>();
                    //Encode password to SHA256 format
                    if (loginResponse != null)
                    {
                        //update session when login app
                        if (string.IsNullOrEmpty(context.InfoRequest.DeviceID))
                        {
                            context.InfoRequest.DeviceID = Guid.NewGuid().ToString();
                            context.InfoRequest.SessionExpired = loginResponse.ExpireTime;

                            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                            {
                                await _userSessions.UpdateSessionMac(
                                    loginResponse.Token,
                                    context.InfoRequest.DeviceID
                                );
                            }
                            else
                            {
                                await _adminGrpcService.UpdateSessionMac(
                                    loginResponse.Token,
                                    context.InfoRequest.DeviceID
                                );
                            }
                        }
                        else
                        {
                            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                            {
                                await _userSessions.UpdateSessionMac(
                                    loginResponse.Token,
                                    context.InfoRequest.DeviceID
                                );
                            }
                            else
                            {
                                await _adminGrpcService.UpdateSessionMac(
                                    loginResponse.Token,
                                    context.InfoRequest.DeviceID
                                );
                            }
                        }

                        statusLogin.Add(new JProperty("status_login", LOGIN_SUCCESS));
                        var obUser = new LoadUserIDModel()
                        {
                            Id = loginResponse.Token,
                            //PortalToken = dataLoginPortal["token"]?.ToString(),
                            UserIdFind = loginResponse.Id.ToString()
                        };
                        context.Bo.AddPackFo<LoadUserIDModel>("loadUserID", obUser);

                        context.Bo.AddPackFo<AuthenticateResponse>("loadUserConfig", loginResponse);

                        //if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                        //{
                        //    string listRoles = "2";

                        //    context.Bo.AddPackFo(
                        //        "loadUserRole",
                        //        JArray.FromObject(listRoles.Split(";").Where(s => !s.Equals("")))
                        //    );
                        //}
                        //else
                        //{

                        //}
                        List<RoleOfUser> rolesOfUser = null;
                        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                        {
                            rolesOfUser = await _adminService.GetListRoleByUserId(loginResponse.Id.ToString());
                        }
                        else
                        {
                            rolesOfUser = await _adminGrpcService.GetListRoleByUserId(loginResponse.Id.ToString());
                        }
                        //
                        //var rolesOfUser = await _adminGrpcService.GetListRoleByUserId(
                        //    loginResponse.Id.ToString()
                        //);

                        string listRoles = "";
                        foreach (var item in rolesOfUser)
                        {
                            listRoles += ";" + item.RoleId.ToString();
                        }

                        context.Bo.AddPackFo(
                            "loadUserRole",
                            JArray.FromObject(listRoles.Split(";").Where(s => !s.Equals("")))
                        );
                    }
                    else
                    {
                        var list_error = context.Bo.GetActionErrors();
                        var errorMsg = "";
                        foreach (var err in list_error)
                        {
                            errorMsg += err.info + "\n";
                        }

                        if (errorMsg.HasValue())
                            statusLogin.Add(new JProperty("message", errorMsg));
                        statusLogin.Add(new JProperty("error_login", "login#101"));
                    }
                }
                else
                {
                    var list_error = context.Bo.GetActionErrors();
                    var errorMsg = "";
                    foreach (var err in list_error)
                    {
                        errorMsg += err.info + "\n";
                    }

                    if (errorMsg.HasValue())
                        statusLogin.Add(new JProperty("message", errorMsg));
                    statusLogin.Add(new JProperty("error_login", "login#101"));
                }
            }
            catch (System.Exception ex)
            {
                // TODO
                System.Console.WriteLine("login=Exception====" + ex.StackTrace);

                var list_error = context.Bo.GetActionErrors();
                var errorMsg = "";
                foreach (var err in list_error)
                {
                    errorMsg += err.info + "\n";
                }

                if (errorMsg.HasValue())
                    statusLogin.Add(new JProperty("message", errorMsg));
                statusLogin.Add(new JProperty("error_login", "login#500"));
            }
        }

        context.Bo.AddPackFo("login-status", statusLogin);

        return "true";
    }

    private async Task<ValidateSessionModel> ValidateSessionMode(string loginName, string sSID)
    {
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var result = await _adminService.CheckValidSingleSession(loginName, sSID);

            switch (result.SessionMode)
            {
                case "SL":
                    var listSessions = await _adminService.ListUserSessionByLoginNameAndNotEqualMac(
                        loginName,
                        sSID
                    );
                    foreach (var item in listSessions)
                    {
                        var info = Utils.Utils
                            .CreateFoQuick("#sys:fo-goto-pageLogin", new JObject())
                            .ToSerialize();
                        await _webSocketsService.SendMessageWithToken(item.Token, info);
                    }
                    break;
                default:
                    break;
            }

            return result;
        }
        else
        {
            var result = await _adminGrpcService.CheckValidSingleSession(loginName, sSID);

            switch (result.SessionMode)
            {
                case "SL":
                    var listSessions = await _adminGrpcService.ListUserSessionByLoginNameAndNotEqualMac(
                        loginName,
                        sSID
                    );
                    foreach (var item in listSessions)
                    {
                        var info = Utils.Utils
                            .CreateFoQuick("#sys:fo-goto-pageLogin", new JObject())
                            .ToSerialize();
                        await _webSocketsService.SendMessageWithToken(item.Token, info);
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

    }
    private async void AddErrorSystem(string keyError)
    {
        try
        {
            var Error_string = await _localizationService.GetResource(keyError, context.InfoUser.GetUserLogin().Lang);

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
            var Error_string = "Can't connect to database. Please check your database!";
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
    /// <param name="emailLogin"></param>
    /// <param name="tokenWebuiOld"></param>
    /// <returns></returns>
    private async Task LoadUserConfig(string emailLogin, string tokenWebuiOld)
    {
        //Check pin
        if (true)
        {
            JObject obHasPin = new JObject();
            obHasPin.Add(new JProperty("hasPin", "false"));
            context.Bo.AddPackFo("pin", obHasPin);
        }
        //Check chat profile --> bỏ

        //Load user config --> không cần thiết

        //Load role of user -> gọi neptune

        //Load role cache để load menu --> gọi neptune

        //Load dyJs--> làm sau

        //
        var obPackRequest = context.InfoUser.GetUserLogin();

        var loadUserId = new LoadUserIDModel()
        {
            Id = obPackRequest.Token,
            PortalToken = obPackRequest.PortalToken,
            UserIdFind = emailLogin
        };

        context.Bo.AddPackFo("loadUserID", loadUserId.ToJObject());
        var configUserDefault = new ListLangConfigModel();

        // var getParas = await _paraServerService.GetByApp(context.InfoApp.GetApp());
        // if (getParas != null)
        // {
        //     foreach (var itemPara in getParas)
        //     {
        //         if (itemPara.Code.Equals("list_lang_config"))
        //         {
        //             System.Console.WriteLine("itemPara.Value===" + itemPara.Value);
        //             configUserDefault.ListLangConfig = JToken.Parse(itemPara.Value).ToObject<List<LangConfig>>();

        //         }
        //     }
        // }
        configUserDefault.ListLangConfig = JToken
            .Parse(_cMSSetting.ListLangConfig)
            .ToObject<List<LangConfig>>();

        if (configUserDefault.ListLangConfig.Count == 0)
        {
            configUserDefault.ListLangConfig.Add(
                new LangConfig()
                {
                    key = "en",
                    img = "../rs/global/img/uk.png",
                    view = "English",
                    selected = true
                }
            );
            configUserDefault.ListLangConfig.Add(
                new LangConfig()
                {
                    key = "vi",
                    view = "Tiếng Việt",
                    img = "../rs/global/img/vietnam.png"
                }
            );
        }

        context.Bo.AddPackFo<ListLangConfigModel>("loadUserConfigDefault", configUserDefault);
        await Task.CompletedTask;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="screen_id"></param>
    /// <returns></returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loadScreen(string screen_id)
    {
        try
        {
            var appInfor = await _appService.GetByAppCode(context.InfoApp.GetApp());
            if (appInfor != null)
            {
                context.Bo.AddPackFo("loadScreen", appInfor.ConfigTemplate.ToJToken());
            }
            var list_shortcut = await _shortcutConfigService.GetByUserIdAndApp(
                context.InfoUser.UserLogin.UserId,
                context.InfoApp.GetApp()
            );
            if (list_shortcut != null)
                context.Bo.AddPackFo<List<ShortcutConfigModel>>("listShortcut", list_shortcut);
            var list_form_shortcut = await _formShortcutService.GetByApp(context.InfoApp.GetApp());
            if (list_form_shortcut != null)
                context.Bo.AddPackFo<List<FormShortcutModel>>("listFormShortcut", list_form_shortcut);

        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.ToString());
            AddErrorSystem("CMS.String.CantConnectDb");
            context.Bo.AddPackFo<List<ShortcutConfigModel>>("listShortcut", new List<ShortcutConfigModel>());
            context.Bo.AddPackFo<List<FormShortcutModel>>("listFormShortcut", new List<FormShortcutModel>());

        }
        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [JwebuiFunctionAttribute]
    public async Task<string> saveMyKeyboard()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput.ContainsKey("shortcut"))
        {
            var new_shortcut = boInput.SelectToken("shortcut");
            var shortcut_save = new Jits.Neptune.Web.CMS.Domain.ShortcutConfig()
            {
                App = new_shortcut["app"].ToString(),
                ShortcutId = new_shortcut["shortcut_id"].ToString(),
                UserId = new_shortcut["user_id"].ToString(),
                FormCode = new_shortcut["form_code"].ToString(),
                Keystrokes = new_shortcut["keystrokes"].ToString(),
                Name = new_shortcut["name"].ToString()
            };
            var shortcut_check = await _shortcutConfigService.GetBy_Id_UserId_App(
                new_shortcut["shortcut_id"].ToString(),
                context.InfoUser.UserLogin.UserId,
                new_shortcut["app"].ToString()
            );
            if (shortcut_check == null)
                await _shortcutConfigService.Insert(shortcut_save);
            else
            {
                shortcut_save.Id = shortcut_check.Id;

                await _shortcutConfigService.Update(shortcut_save);
            }
            var list_shortcut = await _shortcutConfigService.GetByUserIdAndApp(
                context.InfoUser.UserLogin.UserId,
                context.InfoApp.GetApp()
            );
            if (list_shortcut != null)
                context.Bo.AddPackFo<List<ShortcutConfigModel>>("listShortcut", list_shortcut);
            return "true";
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getDyJs()
    {
        await Task.CompletedTask;
        return "false";
    }

    // private async Task<List<UserLimitSearchResponseModel>> getUserLimitByRole(int roleId) {
    //     context.Bo.GetBoInput()["id"] = roleId;
    //     context.Bo.GetBoInput()["learn_api"] = "advance_user_limit";
    //     var obDataUserLimit = await _postAPIService.GetDataPostAPI("ncbsCbs", "getUserLimit", context);
    //     System.Console.WriteLine("obdatauserlimit==="+obDataUserLimit.ToSerialize());
    //     if (obDataUserLimit != null) {
    //         return obDataUserLimit.ToObject<List<UserLimitSearchResponseModel>>();
    //     }
    //     return null;
    // }
    /// <summary>
    ///
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public async Task<List<RoleCacheModel>> BuildRoleCacheOfUser(int roleId, string app)
    {
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var getUserCommandInfoFromRoleId = await _adminService.GetUserCommandInfoFromRoleId(app, roleId.ToString());
            var getListMenuRightFromRole = getUserCommandInfoFromRoleId.Where(s => s.CommandType.Equals("T") || s.CommandType.Equals("M")).ToList();

            List<RoleCacheModel> listLeftJoin = new List<RoleCacheModel>();

            if (getListMenuRightFromRole.Count > 0)
                listLeftJoin = (
                    from listMenuRole in getListMenuRightFromRole
                    select new RoleCacheModel()
                    {
                        FormId = listMenuRole.GroupMenuId.HasValue() ? listMenuRole.GroupMenuId : listMenuRole.CommandId,
                        Invoke = listMenuRole != null ? listMenuRole.Invoke == 1 : false,
                        Approve = listMenuRole != null ? listMenuRole.Approve == 1 : false

                    }
                ).ToList();

            return listLeftJoin;
        }
        else
        {
            var getListMenuRightFromRole = (
                await _adminGrpcService.GetUserCommandInfoFromRoleId(app, roleId.ToString())
            )
                .Where(s => s.CommandType.Equals("T") || s.CommandType.Equals("M"))
                .ToList();


            List<RoleCacheModel> listLeftJoin = new List<RoleCacheModel>();

            if (getListMenuRightFromRole.Count > 0)
                listLeftJoin = (
                    from listMenuRole in getListMenuRightFromRole
                    select new RoleCacheModel()
                    {
                        FormId = listMenuRole.GroupMenuId.HasValue() ? listMenuRole.GroupMenuId : listMenuRole.CommandId,
                        Invoke = listMenuRole != null ? listMenuRole.Invoke == 1 : false,
                        Approve = listMenuRole != null ? listMenuRole.Approve == 1 : false

                    }
                ).ToList();

            return listLeftJoin;
        }
        // foreach (var item in listLeftJoin)
        // {
        //     if (!string.IsNullOrEmpty(item.FormId))
        //         result[item.FormId] = item.Invoke;
        // }

        // return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="listRoleId"></param>
    /// <param name="app"></param>
    /// <param name="formCode"></param>
    /// <param name="formConfig"></param>
    /// <returns></returns>
    public async Task<Dictionary<string, object>> BuildRoleTaskOfForm(List<int> listRoleId, string app, string formCode, FormModel formConfig
    )
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        // var getFormOfRole = await _formOfRoleService.GetByRoleId(roleId, app);
        if (formConfig == null)
            formConfig = await _formService.GetByIdAndApp(formCode, app);
        if (formConfig == null)
            return null;
        var listLayout = formConfig.ListLayout;
        try
        {

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var getMenuByFormCode = (await _adminService.GetUserCommandInfoFromFormCode(app, formCode)).FirstOrDefault();
                var getListMenuRight = new List<CommandIdInfoModel>();
                var getListParentID = new List<CommandIdInfoModel>();
                var userLogin = context.InfoUser.GetUserLogin();
                var userSession = _memoryCache.Get<UserSessions>(userLogin.Token);
                if (getMenuByFormCode != null)
                {
                    getListMenuRight = await _adminService.GetUserCommandInfoFromCommandId(app, getMenuByFormCode.CommandId);
                    getListParentID = await _adminService.GetUserCommandInfoFromParentId(app, getMenuByFormCode.CommandId);
                    
                }
                Console.WriteLine("getListMenuRight====" + getListMenuRight.ToSerialize());

                for (var i = 0; i < listRoleId.Count; i++)
                {
                    JObject roleTaskRole = new JObject();

                    if (getMenuByFormCode != null)
                    {
                        if (!string.IsNullOrEmpty(getMenuByFormCode.CommandId))
                        {
                            //var getListCommandRight = getListParentID.FindAll(
                            //    s => s.RoleId == listRoleId[i]
                            //);
                            var commandRights = O9Utils.GetCommandRight(userSession.Usrid.ToString(), getMenuByFormCode.CommandId);
                            var getListCommandRight = (from cmd in getListParentID
                                                       from bi in commandRights
                                                       where bi.CommandId == cmd.CommandId && bi.IsVisible
                                                       select new CommandIdInfoModel
                                                       {
                                                           RoleId = listRoleId[i],
                                                           RoleName = cmd.RoleName,
                                                           ParentId = cmd.ParentId,
                                                           CommandId = cmd.CommandId,
                                                           CommandName = cmd.CommandName,
                                                           CommandIdDetail = cmd.CommandIdDetail,
                                                           Invoke = bi.IsEnabled ? 1 : 0,
                                                           Approve = cmd.Approve,
                                                           ApplicationCode = cmd.ApplicationCode,
                                                           CommandType = cmd.CommandType,
                                                           GroupMenuIcon = cmd.GroupMenuIcon,
                                                           GroupMenuVisible = cmd.GroupMenuVisible,
                                                           GroupMenuId = cmd.GroupMenuId,
                                                           GroupMenuListAuthorizeForm = cmd.GroupMenuListAuthorizeForm
                                                       }).ToList();



                            foreach (var itemRight in getListCommandRight)
                            {
                                roleTaskRole[itemRight.CommandId] = (
                                    new ComponentRoleModel()
                                    {
                                        component = new RoleTaskModel()
                                        {
                                            install = itemRight.Invoke == 1
                                        }
                                    }
                                ).ToJToken();
                            }


                            roleTaskRole[formCode] = (new FormRoleModel { }).ToJToken();
                            System.Console.WriteLine("listRoleId[i]====" + listRoleId[i]);

                            //var getRightForm = getListMenuRight.Find(s => s.RoleId == listRoleId[i]);
                            var getRightForm = getListMenuRight.Where(x => userSession.CommandList.Contains(x.CommandId)).FirstOrDefault();
                            System.Console.WriteLine("getRightForm before====" + getRightForm.ToSerialize());

                            if (getRightForm != null)
                            {
                                getRightForm.Invoke = 1;
                                roleTaskRole[formCode] = (
                                    new FormRoleModel
                                    {
                                        form = new FormRoleInfoModel()
                                        {
                                            accept = getRightForm.Invoke == 1
                                        }
                                    }
                                ).ToJToken();

                                roleTaskRole[getMenuByFormCode.CommandId] = (
                                    new ComponentRoleModel()
                                    {
                                        component = new RoleTaskModel()
                                        {
                                            install = getRightForm.Invoke == 1
                                        }
                                    }
                                ).ToJToken();
                            }


                            foreach (var layout in listLayout)
                            {
                                roleTaskRole[layout["codeHidden"].ToString()] = (
                                    new LayoutRoleModel() { }
                                ).ToJToken();

                                foreach (
                                    var view in JsonConvert.DeserializeObject<
                                        List<Dictionary<string, object>>
                                    >(layout.GetValueOrDefault("list_view").ToString())
                                )
                                {
                                    roleTaskRole[view["codeHidden"].ToString()] = (
                                        new ViewRoleModel() { }
                                    ).ToJToken();

                                    foreach (
                                        var component in JsonConvert.DeserializeObject<
                                            List<Dictionary<string, object>>
                                        >(view.GetValueOrDefault("list_input").ToString())
                                    )
                                    {
                                        var configDefaultCpn = JObject.FromObject(
                                            component.GetValueOrDefault("default")
                                        );
                                        var commandId = configDefaultCpn["codeHidden"].ToString();


                                        if (roleTaskRole[commandId] == null)
                                            roleTaskRole[commandId] = (
                                                new ComponentRoleModel() { }
                                            ).ToJToken();
                                    }
                                }
                            }
                            System.Console.WriteLine("roleTaskRole after====" + roleTaskRole.ToSerialize());

                        }
                        else
                        {
                            roleTaskRole[formCode] = (new FormRoleModel { }).ToJToken();

                            foreach (var layout in listLayout)
                            {
                                roleTaskRole[layout["codeHidden"].ToString()] = (
                                    new LayoutRoleModel() { }
                                ).ToJToken();

                                foreach (
                                    var view in JsonConvert.DeserializeObject<
                                        List<Dictionary<string, object>>
                                    >(layout.GetValueOrDefault("list_view").ToString())
                                )
                                {
                                    roleTaskRole[view["codeHidden"].ToString()] = (
                                        new ViewRoleModel() { }
                                    ).ToJToken();
                                    foreach (
                                        var component in JsonConvert.DeserializeObject<
                                            List<Dictionary<string, object>>
                                        >(view.GetValueOrDefault("list_input").ToString())
                                    )
                                    {
                                        var configDefaultCpn = JObject.FromObject(
                                            component.GetValueOrDefault("default")
                                        );
                                        var commandId = configDefaultCpn["codeHidden"].ToString();
                                        roleTaskRole[commandId] = (
                                            new ComponentRoleModel() { }
                                        ).ToJToken();
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        roleTaskRole[formCode] = (new FormRoleModel { }).ToJToken();

                        foreach (var layout in listLayout)
                        {
                            roleTaskRole[layout["codeHidden"].ToString()] = (
                                new LayoutRoleModel() { }
                            ).ToJToken();

                            foreach (
                                var view in JsonConvert.DeserializeObject<
                                    List<Dictionary<string, object>>
                                >(layout.GetValueOrDefault("list_view").ToString())
                            )
                            {
                                roleTaskRole[view["codeHidden"].ToString()] = (
                                    new ViewRoleModel() { }
                                ).ToJToken();
                                foreach (
                                    var component in JsonConvert.DeserializeObject<
                                        List<Dictionary<string, object>>
                                    >(view.GetValueOrDefault("list_input").ToString())
                                )
                                {
                                    var configDefaultCpn = JObject.FromObject(
                                        component.GetValueOrDefault("default")
                                    );
                                    var commandId = configDefaultCpn["codeHidden"].ToString();
                                    roleTaskRole[commandId] = (new ComponentRoleModel() { }).ToJToken();
                                }
                            }

                        }
                    }
                    result[listRoleId[i].ToString()] = roleTaskRole;
                }
            }
            else
            {
                var getMenuByFormCode = (
                    await _adminGrpcService.GetUserCommandInfoFromFormCode(app, formCode)
                ).FirstOrDefault();
                var getListMenuRight = new List<CommandIdInfoModel>();
                var getListParentID = new List<CommandIdInfoModel>();
                if (getMenuByFormCode != null)
                {
                    getListMenuRight = await _adminGrpcService.GetUserCommandInfoFromCommandId(
                        app,
                        getMenuByFormCode.CommandId
                    );
                    getListParentID = await _adminGrpcService.GetUserCommandInfoFromParentId(
                        app,
                        getMenuByFormCode.CommandId
                    );
                }

                System.Console.WriteLine("getListMenuRight====" + getListMenuRight.ToSerialize());

                for (var i = 0; i < listRoleId.Count; i++)
                {
                    JObject roleTaskRole = new JObject();

                    if (getMenuByFormCode != null)
                    {
                        if (!string.IsNullOrEmpty(getMenuByFormCode.CommandId))
                        {
                            var getListCommandRight = getListParentID.FindAll(
                                s => s.RoleId == listRoleId[i]
                            );


                            foreach (var itemRight in getListCommandRight)
                            {
                                roleTaskRole[itemRight.CommandId] = (
                                    new ComponentRoleModel()
                                    {
                                        component = new RoleTaskModel()
                                        {
                                            install = itemRight.Invoke == 1
                                        }
                                    }
                                ).ToJToken();
                            }


                            roleTaskRole[formCode] = (new FormRoleModel { }).ToJToken();
                            System.Console.WriteLine("listRoleId[i]====" + listRoleId[i]);

                            var getRightForm = getListMenuRight.Find(s => s.RoleId == listRoleId[i]);
                            System.Console.WriteLine("getRightForm before====" + getRightForm.ToSerialize());

                            if (getRightForm != null)
                            {
                                roleTaskRole[formCode] = (
                                    new FormRoleModel
                                    {
                                        form = new FormRoleInfoModel()
                                        {
                                            accept = getRightForm.Invoke == 1
                                        }
                                    }
                                ).ToJToken();

                                roleTaskRole[getMenuByFormCode.CommandId] = (
                                    new ComponentRoleModel()
                                    {
                                        component = new RoleTaskModel()
                                        {
                                            install = getRightForm.Invoke == 1
                                        }
                                    }
                                ).ToJToken();
                            }


                            foreach (var layout in listLayout)
                            {
                                roleTaskRole[layout["codeHidden"].ToString()] = (
                                    new LayoutRoleModel() { }
                                ).ToJToken();

                                foreach (
                                    var view in JsonConvert.DeserializeObject<
                                        List<Dictionary<string, object>>
                                    >(layout.GetValueOrDefault("list_view").ToString())
                                )
                                {
                                    roleTaskRole[view["codeHidden"].ToString()] = (
                                        new ViewRoleModel() { }
                                    ).ToJToken();

                                    foreach (
                                        var component in JsonConvert.DeserializeObject<
                                            List<Dictionary<string, object>>
                                        >(view.GetValueOrDefault("list_input").ToString())
                                    )
                                    {
                                        var configDefaultCpn = JObject.FromObject(
                                            component.GetValueOrDefault("default")
                                        );
                                        var commandId = configDefaultCpn["codeHidden"].ToString();


                                        if (roleTaskRole[commandId] == null)
                                            roleTaskRole[commandId] = (
                                                new ComponentRoleModel() { }
                                            ).ToJToken();
                                    }
                                }
                            }
                            System.Console.WriteLine("roleTaskRole after====" + roleTaskRole.ToSerialize());

                        }
                        else
                        {
                            roleTaskRole[formCode] = (new FormRoleModel { }).ToJToken();

                            foreach (var layout in listLayout)
                            {
                                roleTaskRole[layout["codeHidden"].ToString()] = (
                                    new LayoutRoleModel() { }
                                ).ToJToken();

                                foreach (
                                    var view in JsonConvert.DeserializeObject<
                                        List<Dictionary<string, object>>
                                    >(layout.GetValueOrDefault("list_view").ToString())
                                )
                                {
                                    roleTaskRole[view["codeHidden"].ToString()] = (
                                        new ViewRoleModel() { }
                                    ).ToJToken();
                                    foreach (
                                        var component in JsonConvert.DeserializeObject<
                                            List<Dictionary<string, object>>
                                        >(view.GetValueOrDefault("list_input").ToString())
                                    )
                                    {
                                        var configDefaultCpn = JObject.FromObject(
                                            component.GetValueOrDefault("default")
                                        );
                                        var commandId = configDefaultCpn["codeHidden"].ToString();
                                        roleTaskRole[commandId] = (
                                            new ComponentRoleModel() { }
                                        ).ToJToken();
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        roleTaskRole[formCode] = (new FormRoleModel { }).ToJToken();

                        foreach (var layout in listLayout)
                        {
                            roleTaskRole[layout["codeHidden"].ToString()] = (
                                new LayoutRoleModel() { }
                            ).ToJToken();

                            foreach (
                                var view in JsonConvert.DeserializeObject<
                                    List<Dictionary<string, object>>
                                >(layout.GetValueOrDefault("list_view").ToString())
                            )
                            {
                                roleTaskRole[view["codeHidden"].ToString()] = (
                                    new ViewRoleModel() { }
                                ).ToJToken();
                                foreach (
                                    var component in JsonConvert.DeserializeObject<
                                        List<Dictionary<string, object>>
                                    >(view.GetValueOrDefault("list_input").ToString())
                                )
                                {
                                    var configDefaultCpn = JObject.FromObject(
                                        component.GetValueOrDefault("default")
                                    );
                                    var commandId = configDefaultCpn["codeHidden"].ToString();
                                    roleTaskRole[commandId] = (new ComponentRoleModel() { }).ToJToken();
                                }
                            }

                        }
                    }
                    result[listRoleId[i].ToString()] = roleTaskRole;
                }
            }

            // processor.Complete();
            // await processor.Completion;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("ExceptionBuildRoleTask==" + ex.StackTrace);
        }
        return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="formId"></param>
    /// <returns></returns>
    public async Task<string> load_form(string formId)
    {
        System.Console.WriteLine("formId===" + formId);

        if (formId.Contains('-'))
        {
            var slipApp = formId.Split('-');
            if (slipApp.Length > 0)
                if (!slipApp[0].Equals("") && !slipApp[1].Equals(""))
                {
                    var configForm = await _formService.GetByIdAndApp(slipApp[1], slipApp[0]);
                    if (configForm != null)
                    {
                        context.Bo.AddPackFo<FormModel>("form_design_detail", configForm);
                        return "true";
                    }
                }
        }
        else
        {
            var configForm = await _formService.GetByIdAndApp(formId, context.InfoApp.GetApp());
            if (configForm != null)
            {
                context.Bo.AddPackFo<FormModel>("form_design_detail", configForm);

                return "true";
            }
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="formId"></param>
    /// <returns></returns>
    public async Task<string> loadRoleTask(string formId)
    {
        var roleTask = await BuildRoleTaskWithListRole(context.InfoApp.GetApp(), formId, null);
        if (roleTask != null)
        {
            context.Bo.AddPackFo<Dictionary<string, object>>("loadRoleTask", roleTask);
            return "true";
        }

        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="formId"></param>
    /// <returns></returns>
    public async Task<string> loadFormAndRoleTask(string formId)
    {
        System.Console.WriteLine("formId===" + formId);
        if (formId.Contains('-'))
        {
            var slipApp = formId.Split('-');
            if (slipApp.Length > 0)
                if (!slipApp[0].Equals("") && !slipApp[1].Equals(""))
                {
                    var configForm = await _formService.GetByIdAndApp(slipApp[1], slipApp[0]);
                    if (configForm != null)
                    {
                        var roleTask = await BuildRoleTaskWithListRole(
                            context.InfoApp.GetApp(),
                            formId,
                            configForm
                        );
                        if (roleTask != null)
                        {
                            context.Bo.AddPackFo<Dictionary<string, object>>(
                                "loadRoleTask",
                                roleTask
                            );

                            context.Bo.AddPackFo<FormModel>("form_design_detail", configForm);
                            return "true";
                        }

                        return "false";
                    }
                }
        }
        else
        {
            var configForm = await _formService.GetByIdAndApp(formId, context.InfoApp.GetApp());
            if (configForm != null)
            {
                var roleTask = await BuildRoleTaskWithListRole(
                    context.InfoApp.GetApp(),
                    formId,
                    configForm
                );
                if (roleTask != null)
                {
                    context.Bo.AddPackFo<Dictionary<string, object>>("loadRoleTask", roleTask);

                    context.Bo.AddPackFo<FormModel>("form_design_detail", configForm);


                    return "true";
                }

                return "false";
            }
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> loadAllFormAndRoleTask()
    {
        var listRoleId = await _formService.GetByApp(context.InfoApp.GetApp());
        JObject list_form = new JObject();
        List<Dictionary<string, object>> list_role = new List<Dictionary<string, object>>();
        if (listRoleId != null)
        {
            var totalForm = listRoleId.Count;
            var connectionCount = 10;

            async Task Action(int i)
            {
                list_role.Add(
                    await BuildRoleTaskWithListRole(
                        context.InfoApp.GetApp(),
                        listRoleId[i].FormId,
                        listRoleId[i]
                    )
                );
                list_form[listRoleId[i].FormId] = JToken.FromObject(listRoleId[i]);
            }

            var processor = new ActionBlock<int>(
                Action,
                new ExecutionDataflowBlockOptions()
                {
                    MaxDegreeOfParallelism = connectionCount,
                    SingleProducerConstrained = true
                }
            );

            for (var i = 0; i < totalForm; i++)
                await processor.SendAsync(i);

            processor.Complete();
            await processor.Completion;
        }
        context.Bo.AddPackFo<List<Dictionary<string, object>>>("list_role", list_role);
        context.Bo.AddPackFo<JObject>("list_form", list_form);
        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <param name="formId"></param>
    /// <param name="form_config"></param>
    /// <returns></returns>
    public async Task<Dictionary<string, object>> BuildRoleTaskWithListRole(string app, string formId, FormModel form_config)
    {
        //
        List<RoleOfUser> rolesOfUser = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            rolesOfUser = await _adminService.GetListRoleByUserId(context.InfoUser.GetUserLogin().UserId.ToString());
        }
        else
        {
            rolesOfUser = await _adminGrpcService.GetListRoleByUserId(context.InfoUser.GetUserLogin().UserId.ToString());
        }
        //
        //var rolesOfUser = await _adminGrpcService.GetListRoleByUserId(
        //    context.InfoUser.GetUserLogin().UserId.ToString()
        //);
        var listRoleId = rolesOfUser.Select(s => s.RoleId).ToList();
        Dictionary<string, object> roleTask = new Dictionary<string, object>();
        roleTask.MergeDictionary(await BuildRoleTaskOfForm(listRoleId, app, formId, form_config));

        return roleTask;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> updateDataImportFile()
    {
        var boInput = context.Bo.GetBoInput();
        try
        {
            var updateImportFile = new ImportDataUploadModel()
            {
                cpn_code = boInput["cpn_code"]?.ToString(),
                data_array = boInput["data_array"]?.ToString(),
                isMore = boInput["isMore"] != null ? (bool)boInput["isMore"] : false
            };

            var methodCode = updateImportFile.data_array.Split(".");
            string tableCode = methodCode[0];
            string dataArrCode = methodCode[1];
            var dataTableCode = boInput[tableCode];

            JArray listFile = new JArray();
            if (updateImportFile.isMore && dataTableCode[dataArrCode] != null)
            {
                listFile = dataTableCode[dataArrCode].ToJArray();
            }

            var uploadMedia = boInput[updateImportFile.cpn_code]
                .SelectToken("uploadFile")
                .ToUploadResponseModel();

            ImportDataResponseModel importDataResponse = new ImportDataResponseModel();
            importDataResponse.file_name = uploadMedia.name;
            if (uploadMedia != null)
            {
                var size_type = boInput["size_type"]?.ToString();
                var getFile = await _mediaUploadService.GetByUserIdAndFileName(
                    uploadMedia.user_id,
                    uploadMedia.name
                );

                switch (size_type)
                {
                    case "bytes":
                        importDataResponse.size_type = "bytes";
                        importDataResponse.file_size = (long)
                            Base64Extension.GetOriginalLengthInBytes(getFile.MediaData);
                        importDataResponse.size_type_caption =
                            Base64Extension.GetOriginalLengthInBytes(getFile.MediaData) + " Bytes";
                        break;
                    default:
                        break;
                }

                //build data to table
                JObject newDataArr = new JObject();
                newDataArr.Add(dataArrCode, JToken.FromObject(importDataResponse));

                //add data to table
                listFile.Add(newDataArr);
                context.Bo.AddPackFo(dataArrCode, listFile);

                var nodeDataJson = boInput["node_data_json"]?.ToString();
                if (!string.IsNullOrEmpty(nodeDataJson))
                {
                    context.Bo.AddPackFo(nodeDataJson, JToken.FromObject(importDataResponse));
                }
                return "true";
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            await _logger.Error("updateDataImportFile=====" + ex.StackTrace);
        }

        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> loadAllGroupMenuByApp()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["app"] != null)
        {

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var getCommands = await _adminService.GetUserCommandByApplicationCode(boInput["app"].ToString());

                if (getCommands != null)
                {
                    context.Bo.AddPackFo(
                        "data",
                        getCommands.FindAll(e => e.CommandType.Equals("M")).ToJToken()
                    );
                }
                return "true";
            }
            else
            {
                var getCommands = await _adminGrpcService.GetUserCommandByApplicationCode(boInput["app"].ToString());

                if (getCommands != null)
                {
                    context.Bo.AddPackFo(
                        "data",
                        getCommands.FindAll(e => e.CommandType.Equals("M")).ToJToken()
                    );
                }
                return "true";
            }
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> load_multiform(string form_arr)
    {
        var boInput = context.Bo.GetBoInput();
        string app = boInput["app"] != null ? boInput["app"].ToString() : context.InfoApp.GetApp();
        List<object> listForms = new List<object>();
        foreach (var formId in form_arr.Split(";"))
        {
            Dictionary<string, object> itemForm = new Dictionary<string, object>();
            if (formId.Contains('-'))
            {
                var slipApp = formId.Split('-');
                if (slipApp.Length > 0)
                    if (!slipApp[0].Equals("") && !slipApp[1].Equals(""))
                    {
                        var configForm = _formService
                            .GetByIdAndApp(slipApp[1], slipApp[0])
                            .GetAwaiter()
                            .GetResult();
                        if (configForm != null)
                        {
                            itemForm.Add("form_design_detail", JObject.FromObject(configForm));
                            itemForm.Add(
                                "form_role_task",
                                (
                                    await BuildRoleTaskWithListRole(slipApp[0], slipApp[1], null)
                                ).ToJObject()
                            );
                        }
                    }
            }
            else
            {
                var configForm = _formService.GetByIdAndApp(formId, app).GetAwaiter().GetResult();
                if (configForm != null)
                {
                    itemForm.Add("form_design_detail", JObject.FromObject(configForm));
                    itemForm.Add(
                        "form_role_task",
                        (await BuildRoleTaskWithListRole(app, formId, null)).ToJObject()
                    );
                }
            }
            listForms.Add(itemForm);
        }

        if (listForms.Count > 0)
        {
            context.Bo.AddPackFo("list_authorize_forms", listForms.ToJToken());
            return "true";
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCode"></param>
    /// <returns></returns>
    public async Task<string> createNewSessionID(string appCode)
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput.ContainsKey("session_id"))
        {
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var newSessionToken = await _adminService.CreateOtherToken(boInput["session_id"].ToString());

                //string newPortalToken = null;//await _authenticationGrpcService.GetAuthenticationToken(_cMSSetting.UserPortal, EngineContext.Current.Resolve<IEncryptionService>().DecryptText(_cMSSetting.PasswordPoral));
                if (!string.IsNullOrEmpty(newSessionToken))
                {

                    await _adminService.UpdateSessionApplicationCode(newSessionToken, appCode);
                    // await _adminService.UpdateSessionInfo(newSessionToken, newPortalToken);

                    var session_ = new JObject();
                    session_["session_id"] = newSessionToken;
                    // session_["session_id_portal"] = JObject.Parse(newPortalToken)["token"].ToString();
                    context.Bo.AddPackFo("session_id", session_);
                }

                return "true";
            }
            else
            {
                var newSessionToken = await _adminGrpcService.CreateOtherToken(
                    boInput["session_id"].ToString()
                );
                var newPortalToken = await _authenticationGrpcService.GetAuthenticationToken(
                    _cMSSetting.UserPortal,
                    EngineContext.Current.Resolve<IEncryptionService>().DecryptText(_cMSSetting.PasswordPoral)
                );
                if (!string.IsNullOrEmpty(newSessionToken) && !string.IsNullOrEmpty(newPortalToken))
                {
                    await _adminGrpcService.UpdateSessionApplicationCode(newSessionToken, appCode);
                    // await _adminGrpcService.UpdateSessionInfo(newSessionToken, newPortalToken);

                    var session_ = new JObject();
                    session_["session_id"] = newSessionToken;
                    session_["session_id_portal"] = JObject.Parse(newPortalToken)["token"].ToString();
                    context.Bo.AddPackFo("session_id", session_);

                }

                return "true";
            }
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> LoadMenuTableByApp()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["app_select"] != null && boInput["command_id"] != null)
        {
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var getCommandsFromParent = await _adminService.GetUserCommandInfoFromParentId(
                    boInput["app_select"].ToString(),
                    boInput["command_id"].ToString()
                );

                if (getCommandsFromParent != null)
                {
                    context.Bo.AddPackFo(
                        "data",
                        getCommandsFromParent.FindAll(e => e.CommandType.Equals("C")).ToJToken()
                    );
                }
                return "true";
            }
            else
            {
                var getCommandsFromParent = await _adminGrpcService.GetUserCommandInfoFromParentId(
                    boInput["app_select"].ToString(),
                    boInput["command_id"].ToString()
                );

                if (getCommandsFromParent != null)
                {
                    context.Bo.AddPackFo(
                        "data",
                        getCommandsFromParent.FindAll(e => e.CommandType.Equals("C")).ToJToken()
                    );
                }
                return "true";
            }
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> lockToken()
    {
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            await _adminService.LockScreen(context.InfoUser.GetUserLogin().Token);
            return "true";
        }
        else
        {
            await _adminGrpcService.LockScreen(context.InfoUser.GetUserLogin().Token);
            return "true";
        }

    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="token_webui"></param>
    /// <param name="delete_all"></param>
    /// <returns></returns>
    public async Task<string> deleteSession(string token_webui, bool delete_all)
    {
        var boInput = context.Bo.GetBoInput();
        bool noReload = false;

        if (boInput["no_reload"] != null)
            noReload = ((bool)boInput["no_reload"]);

        if (delete_all) { }
        else
        {
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {// var admToken = new JObject();
             // admToken["token"] = token_webui;
             // boInput["adm_token_search"] = admToken;
             // boInput["learn_api"] = "adm_token_delete";
                var infoUser = await _adminService.GetSessionByToken(token_webui);
                // var obDataDelete = await _postAPIService.GetDataPostAPI("ncbs", "DeleteToken", context);
                await _adminService.DeleteToken(token_webui);
                // System.Console.WriteLine("obDataDelete==" + obDataDelete.ToSerialize());
                var info = Utils.Utils
                    .CreateFoQuick("#sys:fo-goto-pageLogin", new JObject())
                    .ToSerialize();
                await _webSocketsService.SendMessageWithToken(token_webui, info);


                context.Bo.AddPackFo("device", await getDevicesByUserId(context.InfoUser.GetUserLogin().UserId.ToString()));
                return "true";
            }
            else
            { // var admToken = new JObject();
              // admToken["token"] = token_webui;
              // boInput["adm_token_search"] = admToken;
              // boInput["learn_api"] = "adm_token_delete";
                var infoUser = await _adminGrpcService.GetSessionByToken(token_webui);
                // var obDataDelete = await _postAPIService.GetDataPostAPI("ncbs", "DeleteToken", context);
                await _adminGrpcService.DeleteToken(token_webui);
                // System.Console.WriteLine("obDataDelete==" + obDataDelete.ToSerialize());
                var info = Utils.Utils
                    .CreateFoQuick("#sys:fo-goto-pageLogin", new JObject())
                    .ToSerialize();
                await _webSocketsService.SendMessageWithToken(token_webui, info);


                context.Bo.AddPackFo("device", await getDevicesByUserId(context.InfoUser.GetUserLogin().UserId.ToString()));
                return "true";
            }

        }

        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="delete_all"></param>
    /// <returns></returns>
    public async Task<string> deleteSessionUserId(string user_id, bool delete_all)
    {
        var boInput = context.Bo.GetBoInput();

        if (boInput["logout_app"] != null)
        {
            var logoutApp = boInput["logout_app"].ToString();

            context.Bo.GetBoInput()["usrid"] = Int32.Parse(user_id);
            context.Bo.GetBoInput()["app"] = logoutApp;
            context.Bo.GetBoInput()["learn_api"] = "SQL_ADVANCED_SEARCH_USER_SESSION_byApp";
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obData = await _postAPIService.GetDataPostAPI("ncbs", "getDevice", context);
            }

            if (obData != null)
            {
                var listSession = obData
                    .ToObject<List<UserSessionSearchResponseModel>>()
                    .Where(s => !string.IsNullOrEmpty(s.ApplicationCode));
                foreach (var itemSession in listSession)
                {
                    var info = Utils.Utils
                        .CreateFoQuick("#sys:fo-goto-pageLogin", new JObject())
                        .ToSerialize();
                    await _webSocketsService.SendMessageWithToken(itemSession.Token, info);
                }

                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    await _adminService.DeleteAllAppToken(user_id, logoutApp, context.InfoUser.GetUserLogin().Token);
                }
                else
                {
                    await _adminGrpcService.DeleteAllAppToken(
                    user_id,
                    logoutApp,
                    context.InfoUser.GetUserLogin().Token
                );
                }

            }
            context.Bo.AddPackFo("device", await getDevicesByUserId(user_id));
            return "true";
        }
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> saveUserConfigDefault()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["content"] != null)
        {
            var content = boInput["content"].ToString();
        }
        await Task.CompletedTask;
        return "false";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<string> saveLangData()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["lang_detail"] != null)
        {
            var lang_detail = boInput["lang_detail"].ToJArray();
            foreach (var item in lang_detail)
            {
                var itemLang = item.ToJObject();
                if (itemLang["content"] != null && itemLang["key"] != null)
                {
                    await _langService.FindAndSaveLang(
                        context.InfoApp.GetApp(),
                        itemLang["key"].ToString(),
                        itemLang["content"].ToJObject()
                    );
                    return "true";
                }
            }
        }
        return "false";
    }
}
