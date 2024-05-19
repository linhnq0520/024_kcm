using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Services.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial class WebchannelService : IWebchannelService
{
    #region Fields

    private readonly ILogger _logger;
    private readonly ILocalizationService _localizationService;
    private readonly INeptuneFileProvider _fileProvider;
    private readonly IBoService _boService;
    private readonly IFoService _foService;
    private readonly IFormService _formService;
    private readonly IFormOfRoleService _formOfRoleService;
    private readonly ILearnApiService _learnApiService;
    private readonly ICdlistService _cdlistService;
    private readonly IParaServerService _paraServerService;

    private readonly IMediaUploadService _mediaUploadService;
    private readonly IGroupMenuService _groupMenuService;
    private readonly IDesignGroupService _designGroupService;
    private readonly IDesignItemService _designItemService;
    private readonly CMSSetting _cmsSeting;
    private readonly ILogServiceService _logServiceService;
    private readonly ILangService _langService;
    private readonly ITemplateVoucherService _templateVoucherService;
    private readonly IShortcutConfigService _shortcutConfigService;
    private readonly IPostAPIService _postApiService;
    private readonly IUserSessionsService _userSessions;


    //string BO_GUID = "";

    JWebUIObjectContextModel context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
    #endregion

    #region Ctor
    /// <summary>
    ///
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="postAPIService"></param>
    /// <param name="fileProvider"></param>
    /// <param name="langService"></param>
    /// <param name="templateVoucherService"></param>
    /// <param name="shortcutConfigService"></param>
    /// <param name="paraServerService"></param>
    /// <param name="boService"></param>
    /// <param name="foService"></param>
    /// <param name="cMSSetting"></param>
    /// <param name="formService"></param>
    /// <param name="formOfRoleService"></param>
    /// <param name="learnApiService"></param>
    /// <param name="cdlistService"></param>
    /// <param name="mediaUploadService"></param>
    /// <param name="groupMenuService"></param>
    /// <param name="designGroupService"></param>
    /// <param name="designItemService"></param>
    /// <param name="logger"></param>
    /// <param name="logServiceService"></param>
    /// <param name="userSessions"></param>
    public WebchannelService(
        ILocalizationService localizationService,
        IPostAPIService postAPIService,
        INeptuneFileProvider fileProvider,
        ILangService langService,
        ITemplateVoucherService templateVoucherService,
        IShortcutConfigService shortcutConfigService,
        IParaServerService paraServerService,
        IBoService boService,
        IFoService foService,
        CMSSetting cMSSetting,
        IFormService formService,
        IFormOfRoleService formOfRoleService,
        ILearnApiService learnApiService,
        ICdlistService cdlistService,
        IMediaUploadService mediaUploadService,
        IGroupMenuService groupMenuService,
        IDesignGroupService designGroupService,
        IDesignItemService designItemService,
        ILogger logger,
        ILogServiceService logServiceService,
        IUserSessionsService userSessions
    )
    {
        _localizationService = localizationService;
        _fileProvider = fileProvider;
        _boService = boService;
        _foService = foService;
        _formService = formService;
        _cmsSeting = cMSSetting;
        _formOfRoleService = formOfRoleService;
        _learnApiService = learnApiService;
        _cdlistService = cdlistService;
        _mediaUploadService = mediaUploadService;
        _groupMenuService = groupMenuService;
        _designGroupService = designGroupService;
        _designItemService = designItemService;
        _logger = logger;
        _logServiceService = logServiceService;
        _langService = langService;
        _paraServerService = paraServerService;
        _templateVoucherService = templateVoucherService;
        _shortcutConfigService = shortcutConfigService;
        _postApiService = postAPIService;
        _userSessions = userSessions;
    }

    #endregion
    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public virtual async Task<JObject> GetConfigClient()
    {

        var text = _fileProvider.ReadAllText("./App_Data/configOfDomain.json", Encoding.UTF8);
        // Console.WriteLine("read file start==" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
        //                                    CultureInfo.InvariantCulture));
        if (text.Contains("system_host_port"))
            text = text.Replace("system_host_port", _cmsSeting.Hostport);

        var configOfDomain = JObject.Parse(text);

        // bổ xung các config bị thiếu từ configWizData
        var configDomainResult = configOfDomain
            .ToDictionary()
            .MergeDictionary(
                new ConfigOfDomainModel()
                {
                    rsa = _cmsSeting.ClientRsaPublicKey,
                    template_host_dev = _cmsSeting.TemplateHostDev,
                    server_version = Constants.ServerVersion,
                    server_name = Constants.ServerName,
                    isDev = _cmsSeting.Isdev,
                    // gatewayInfo=_cmsSeting.AppGatewaySetting
                }.ToDictionary()
            );

        await Task.CompletedTask;
        return configDomainResult.ToJObject();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="host"></param>
    /// <param name="scheme"></param>
    /// <returns></returns>
    public virtual async Task<string> GetHTMLDynamic(string host, string scheme)
    {
        string jsReactProject = "";
        string serverPathFolder = Constants.ServerTemplate + "/index.html";
        string contentJsTemplate = "";
        try
        {
            contentJsTemplate = _fileProvider.ReadAllText(serverPathFolder, Encoding.UTF8);

            contentJsTemplate = contentJsTemplate.Replace(
                "template_auto_ip_port",
                scheme + "://" + host + "/fwcss"
            );
            if (!contentJsTemplate.Equals(""))
            {
                string scriptStart = "<script>!";
                string scriptEnd = "</script>";
                int startLen = contentJsTemplate.IndexOf(scriptStart) + scriptStart.Length;
                contentJsTemplate =
                    "!"
                    + contentJsTemplate.Substring(
                        startLen,
                        contentJsTemplate.LastIndexOf(scriptEnd) - startLen
                    );
                // bắt đầu cắt từng phần js và chuyển về content và import

                string[] splitContentJs = contentJsTemplate.Split(scriptEnd);
                foreach (string s in splitContentJs)
                {
                    if (jsReactProject.Equals(""))
                        jsReactProject = s;
                    else
                    {
                        string s_ = s.Replace("<script src=\"", "");
                        s_ = s_.Replace("\">", "");
                        jsReactProject += ";addSriptTemplate('" + s_ + "')";
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("ex===" + ex);
        }

        await Task.CompletedTask;
        return jsReactProject;
    }


    private static string BuildMigrationFromJson(JObject js)
    {
        string response = "";
        var result = $" new Form" + " { ";
        foreach (var item in js.Properties())
        {
            switch (item.Name)
            {
                case "AFGHkeyIndexWJ":
                    continue;
                case "AFGHkeyTime":
                    continue;
                case "AFGHkeyWorkFlow":
                    continue;
                case "AFGHTimeWJ":
                    continue;
                case "AFGHkeyUserCreateWJ":
                    continue;
                case "AFGHkeysercreateWJ":
                    continue;
                    // case "learn_api_header":
                    //     var header_ = item.Value.ToString().Split("\n");
                    //     JObject headerAdd = new JObject();
                    //     foreach (var itemHeader in header_)
                    //     {
                    //         string headerKey = itemHeader.Substring(0, itemHeader.IndexOf(':'));
                    //         string headerValue = itemHeader.Substring(itemHeader.IndexOf(':') + 1, itemHeader.Length - itemHeader.IndexOf(':'));
                    //         System.Console.WriteLine("headerKey==" + headerKey);
                    //         System.Console.WriteLine("headerValue==" + headerValue);

                    //         headerAdd.Add(new JProperty(headerValue, headerValue));
                    //     }
                    //     result += $"{item.Name.ToTitleCase()} = '{JsonConvert.SerializeObject(headerAdd)}'  , ";
                    //     continue;
            }
            var obj = "";
            switch (item.Value.Type + "")
            {
                case "Object":
                    obj =
                        $"{item.Name.ToTitleCaseRemoveUnderScore()} = '{JsonConvert.SerializeObject(item.Value)}'  , ";
                    break;
                case "Array":
                    obj =
                        $"{item.Name.ToTitleCaseRemoveUnderScore()} = '{JsonConvert.SerializeObject(item.Value)}'  , ";
                    break;
                case "Integer":
                    obj = $"{item.Name.ToTitleCaseRemoveUnderScore()} = {item.Value}  , ";
                    break;
                case "Boolean":
                    obj =
                        $"{item.Name.ToTitleCaseRemoveUnderScore()} = {item.Value.ToString().ToLower()} , ";
                    break;
                default:
                    obj = $"{item.Name.ToTitleCaseRemoveUnderScore()} = '{item.Value}' , ";
                    break;
            }

            result += obj;
            result += $" App = 'ncbsCbs'" + '}' + ',';
            response += result;
        }
        return response;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<string> BuildFormOfRole(string app)
    {
        var getAllForm = await _formService.GetByApp(app);
        if (getAllForm != null)
        {
            foreach (var item in getAllForm)
            {
                System.Console.WriteLine("item===" + JsonConvert.SerializeObject(item));

                var _dataAdd = new FormOfRole
                {
                    RoleId = 1,
                    App = app,
                    Form = item.FormId,
                    AccessForm = true
                };
                await _formOfRoleService.Insert(_dataAdd);
            }
        }
        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public virtual async Task<string> MigrationCdlist(string path)
    {
        var arrPath = path.Split("/");
        string app = "ncbsCbs";
        string type = "c_cdlist";
        string[] arr_rs = new string[70000];
        if (arrPath.Length > 1)
        {
            app = arrPath[0];
            arr_rs = _fileProvider.GetDirectories("./data/" + app + "/" + type);
        }

        string rs = "";
        try
        {
            foreach (var itemGrp in arr_rs)
            {
                var cdgrp = "";
                if (_fileProvider.IsDirectory(itemGrp))
                {
                    cdgrp = _fileProvider.GetDirectoryNameOnly(itemGrp);

                    var cdname = "";
                    foreach (var itemName in _fileProvider.GetDirectories(itemGrp))
                    {
                        cdname = _fileProvider.GetDirectoryNameOnly(itemName);
                        foreach (var itemCdlist in _fileProvider.GetFiles(itemName))
                        {
                            var contentJs = _fileProvider.ReadAllText(itemCdlist, Encoding.UTF8);
                            if (!string.IsNullOrEmpty(contentJs))
                            {
                                try
                                {
                                    var objectCdlist = JsonConvert.DeserializeObject<JObject>(
                                        contentJs
                                    );

                                    var objectCdlistAdd = new Cdlist()
                                    {
                                        Caption = objectCdlist["caption"]?.ToString(),
                                        Cdgrp = cdgrp,
                                        Cdname = cdname,
                                        Cdid = objectCdlist["cdid"]?.ToString(),
                                        Cdidx = Int32.Parse(objectCdlist["cdidx"]?.ToString()),
                                        Cdval = objectCdlist["cdval"]?.ToString(),
                                        Ftag = objectCdlist["ftag"]?.ToString(),
                                        Mcaption =
                                            objectCdlist["mcaption"] != null
                                                ? JsonConvert.SerializeObject(
                                                    objectCdlist["mcaption"]
                                                )
                                                : "{}",
                                        Visible = Int32.Parse(objectCdlist["visible"]?.ToString()),
                                        App = app
                                    };
                                    await _cdlistService.Insert(objectCdlistAdd);
                                }
                                catch (System.Exception ex)
                                {
                                    System.Console.WriteLine("ex===" + ex);

                                }
                            }
                        }
                    }
                }
                // var contentJs = new StreamReader(item.ToString(), true).ReadToEnd();
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("ex===" + ex);

        }
        return rs;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public virtual async Task<string> FixKeyReadData()
    {
        // var getAllLearnApi = await _learnApiService.GetByApp("ncbsCbs");
        // foreach (var item in getAllLearnApi)
        // {
        //     var itemTemp = item;
        //     itemTemp.KeyReadData = itemTemp.KeyReadData.Replace("..", ".");
        //     await _learnApiService.Update(item.ToEntity<LearnApi>());
        // }
        await Task.CompletedTask;

        return "done";
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public virtual async Task BuildMenuModuleForm()
    {
        var menus = await _groupMenuService.GetAll();
        foreach (var menu in menus)
        {
            if (menu.GroupMenuModuleForm == null)
            {
                var prefixModule = menu.GroupMenuId.Split('_')[0];

                switch (prefixModule)
                {
                    case "FO":
                        menu.GroupMenuModuleForm = menu.GroupMenuId.Replace("FO_", "");
                        break;
                    case "BO":
                        menu.GroupMenuModuleForm = menu.GroupMenuId.Split('_')[1];
                        break;
                    default:
                        menu.GroupMenuModuleForm = menu.GroupMenuId;
                        break;
                }
                await _groupMenuService.Update(menu.ToJToken().ToGroupMenuEntity());
            }
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public virtual async Task<string> MigrationFromFile(string path)
    {
        var arrPath = path.Split("/");
        string app = "ncbsCbs";
        string type = path;
        string[] arr_rs = new string[10000];
        if (arrPath.Length > 1)
        {
            app = arrPath[0];
            type = arrPath[1];
            arr_rs = _fileProvider.GetFiles("./data/" + app + "/" + type);
        }
        else
            arr_rs = _fileProvider.GetFiles("./data/" + type);

        string rs = "";
        try
        {
            foreach (var item in arr_rs)
            {
                var contentJs = _fileProvider.ReadAllText(item.ToString(), Encoding.UTF8);
                // var contentJs = new StreamReader(item.ToString(), true).ReadToEnd();

                if (!string.IsNullOrEmpty(contentJs))
                {
                    try
                    {
                        switch (type)
                        {
                            case "design_tool_groups":
                                var objectDesginGroupJs = JsonConvert.DeserializeObject<JObject>(
                                    contentJs
                                );

                                var designGroupAdd = new DesignGroup()
                                {
                                    GroupId = objectDesginGroupJs["group_id"]?.ToString(),
                                    isActive = true,
                                    DisplayOrder = objectDesginGroupJs["order"]?.ToString(),
                                    Title = JsonConvert.SerializeObject(
                                        objectDesginGroupJs["title"]
                                    )
                                };
                                await _designGroupService.Insert(designGroupAdd);
                                break;
                            case "design_tool_items":
                                var objectDesginItemJs = JsonConvert.DeserializeObject<JObject>(
                                    contentJs
                                );

                                var designItemAdd = new DesignItem()
                                {
                                    GroupId = objectDesginItemJs["group_id"]?.ToString(),
                                    isActive = true,
                                    DisplayOrder = objectDesginItemJs["order"]?.ToString(),
                                    Title = JsonConvert.SerializeObject(
                                        objectDesginItemJs["title"]
                                    ),
                                    AttId = objectDesginItemJs["att_id"]?.ToString(),
                                    Img = objectDesginItemJs["img"]?.ToString(),
                                    KeyNew = objectDesginItemJs["key_new"]?.ToString(),
                                    Template = JsonConvert.SerializeObject(
                                        objectDesginItemJs["template"]
                                    ),
                                    Type = objectDesginItemJs["type"]?.ToString()
                                };
                                await _designItemService.Insert(designItemAdd);
                                break;
                            case "group_menu":
                                var objectGroupmenuJs = JsonConvert.DeserializeObject<JObject>(
                                    contentJs
                                );

                                var groupmenuAdd = new GroupMenu()
                                {
                                    GroupMenuFunctionCode = objectGroupmenuJs[
                                        "group_menu_function_code"
                                    ]?.ToString(),
                                    GroupMenuIcon = objectGroupmenuJs[
                                        "group_menu_icon"
                                    ]?.ToString(),
                                    GroupMenuId = objectGroupmenuJs["group_menu_id"]?.ToString(),
                                    GroupMenuLang =
                                        objectGroupmenuJs["group_menu_lang"] != null
                                            ? JsonConvert.SerializeObject(
                                                objectGroupmenuJs["group_menu_lang"]
                                            )
                                            : "{}",
                                    GroupMenuListAuthorizeForm = objectGroupmenuJs[
                                        "group_menu_list_authorize_form"
                                    ]?.ToString(),
                                    GroupMenuModuleForm = "",
                                    GroupMenuName = objectGroupmenuJs[
                                        "group_menu_name"
                                    ]?.ToString(),
                                    GroupMenuOrder = Int32.Parse(
                                        objectGroupmenuJs["group_menu_order"]?.ToString()
                                    ),
                                    GroupMenuParent = objectGroupmenuJs[
                                        "group_menu_parent"
                                    ]?.ToString(),
                                    GroupMenuStatus = objectGroupmenuJs[
                                        "group_menu_status"
                                    ]?.ToString(),
                                    GroupMenuVisible = objectGroupmenuJs[
                                        "group_menu_visible"
                                    ]?.ToString(),
                                    App = app
                                };
                                await _groupMenuService.Insert(groupmenuAdd);
                                break;
                            case "form":

                                var objectJs = JsonConvert.DeserializeObject<JObject>(contentJs);

                                var formAdd = new Form()
                                {
                                    Info = JsonConvert.SerializeObject(objectJs["info"]),
                                    ListLayout = JsonConvert.SerializeObject(
                                        objectJs["list_layout"]
                                    ),
                                    FormId = JsonConvert.DeserializeObject<JObject>(
                                        objectJs["info"].ToString()
                                    )["form_code"].ToString(),
                                    App = app
                                };
                                await _formService.Insert(formAdd);
                                break;
                            case "learn_api":
                                var objectLearnApi = JsonConvert.DeserializeObject<JObject>(
                                    contentJs
                                );
                                var number_of_steps =
                                    objectLearnApi["number_of_steps"] != null
                                        ? objectLearnApi["number_of_steps"]?.ToString()
                                        : "";
                                // string key_read_data = "";
                                // if (!number_of_steps.Equals("1")) key_read_data = "execution_steps[1].p2_content.response.data";
                                // else key_read_data = "execution_steps[0].p2_content.response.data";

                                var learnApiAdd = new LearnApi()
                                {
                                    LearnApiData = objectLearnApi["learn_api_data"]?.ToString(),
                                    FlowApi = objectLearnApi["app_code"]?.ToString(),
                                    LearnApiApp = "BO",
                                    LearnApiHeader =
                                        "{\"Authorization\":\"MapS.getToken(Bearer )\"}",
                                    LearnApiId = objectLearnApi["learn_api_id"]?.ToString(),
                                    LearnApiLink = objectLearnApi["learn_api_link"]?.ToString(),
                                    LearnApiMapping = objectLearnApi["learn_api_mapping"]
                                        ?.ToString()
                                        .Replace("login.token", "token"),
                                    LearnApiMethod = objectLearnApi["learn_api_method"]?.ToString(),
                                    LearnApiName = objectLearnApi["learn_api_name"]?.ToString(),
                                    LearnApiNodeData = objectLearnApi[
                                        "learn_api_node_data"
                                    ]?.ToString(),
                                    SaveTo = objectLearnApi["save_to"]?.ToString(),
                                    NumberOfSteps = number_of_steps,
                                    KeyReadData = objectLearnApi["learn_api_node_data"]?.ToString(),
                                    App = app
                                };
                                // if (!learnApiAdd.LearnApiNodeData.Equals(""))
                                // {
                                //     learnApiAdd.KeyReadData = learnApiAdd.KeyReadData.Replace(learnApiAdd.LearnApiNodeData, "");
                                //     learnApiAdd.KeyReadData += "." + learnApiAdd.LearnApiNodeData;
                                // }
                                await _learnApiService.Insert(learnApiAdd);
                                break;
                            case "fo":
                                var objectFo = JsonConvert.DeserializeObject<JObject>(contentJs);

                                var objectFoAdd = new Fo()
                                {
                                    Actions = JsonConvert.SerializeObject(objectFo["actions"]),
                                    Input = JsonConvert.SerializeObject(objectFo["input"]),
                                    Request = JsonConvert.SerializeObject(objectFo["request"]),
                                    Status = objectFo["status"].ToString(),
                                    Txcode = objectFo["txcode"].ToString(),
                                    Txname = objectFo["txname"].ToString(),
                                    Txtype = objectFo["txtype"].ToString(),
                                    App = app
                                };
                                await _foService.Insert(objectFoAdd);
                                break;
                            case "bo":
                                var objectBo = JsonConvert.DeserializeObject<JObject>(contentJs);

                                var objectBoAdd = new Bo()
                                {
                                    Actions = JsonConvert.SerializeObject(objectBo["actions"]),
                                    Input = JsonConvert.SerializeObject(objectBo["input"]),
                                    Response = JsonConvert.SerializeObject(objectBo["response"]),
                                    Status = objectBo["status"].ToString(),
                                    Txcode = objectBo["txcode"].ToString(),
                                    Txname = objectBo["txname"].ToString(),
                                    Txtype = objectBo["txtype"].ToString(),
                                    App = app
                                };
                                await _boService.Insert(objectBoAdd);
                                break;

                            default:
                                break;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        // TODO
                        System.Console.WriteLine("ex===" + ex);

                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("ex===" + ex);

        }
        return rs;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="from_app"></param>
    /// <param name="to_app"></param>
    /// <returns></returns>
    public virtual async Task<string> CopyAppTo(string from_app, string to_app)
    {
        string rs = "";
        try
        {
            //Convert BO
            var list_bo = await _boService.GetByApp(from_app);
            if (list_bo != null)
                foreach (var bo in list_bo)
                {
                    var objectBoAdd = new Bo()
                    {
                        Actions = JsonConvert.SerializeObject(bo.Actions),
                        Input = JsonConvert.SerializeObject(bo.Input),
                        Response = JsonConvert.SerializeObject(bo.Response),
                        Status = bo.Status,
                        Txcode = bo.Txcode,
                        Txname = bo.Txname,
                        Txtype = bo.Txtype,
                        App = to_app
                    };
                    await _boService.Insert(objectBoAdd);
                }
            //Convert FO
            var list_fo = await _foService.GetByApp(from_app);
            if (list_fo != null)
                foreach (var fo in list_fo)
                {
                    var objectFoAdd = new Fo()
                    {
                        Actions = JsonConvert.SerializeObject(fo.Actions),
                        Input = JsonConvert.SerializeObject(fo.Input),
                        Request = JsonConvert.SerializeObject(fo.Request),
                        Status = fo.Status,
                        Txcode = fo.Txcode,
                        Txname = fo.Txname,
                        Txtype = fo.Txtype,
                        App = to_app
                    };
                    await _foService.Insert(objectFoAdd);
                }
            //Convert Form
            var list_form = await _formService.GetByApp(from_app);
            if (list_form != null)
            {
                foreach (var form in list_form)
                {
                    var formAdd = new Form()
                    {
                        Info = JsonConvert.SerializeObject(form.Info),
                        ListLayout = JsonConvert.SerializeObject(form.ListLayout),
                        FormId = form.FormId,
                        App = to_app
                    };
                    await _formService.Insert(formAdd);
                }
            }
            //Convert GroupMenu
            var list_groupMenu = await _groupMenuService.SearchByApp(from_app);
            if (list_groupMenu != null)
            {
                foreach (var groupMenu in list_groupMenu)
                {
                    var groupmenuAdd = new GroupMenu()
                    {
                        GroupMenuFunctionCode = groupMenu.GroupMenuFunctionCode,
                        GroupMenuIcon = groupMenu.GroupMenuIcon,
                        GroupMenuId = groupMenu.GroupMenuIcon,
                        GroupMenuLang = JsonConvert.SerializeObject(groupMenu.GroupMenuLang),
                        GroupMenuListAuthorizeForm = groupMenu.GroupMenuListAuthorizeForm,
                        GroupMenuModuleForm = groupMenu.GroupMenuModuleForm,
                        GroupMenuName = groupMenu.GroupMenuName,
                        GroupMenuOrder = groupMenu.GroupMenuOrder,
                        GroupMenuParent = groupMenu.GroupMenuParent,
                        GroupMenuStatus = groupMenu.GroupMenuStatus,
                        GroupMenuVisible = groupMenu.GroupMenuVisible,
                        App = to_app
                    };
                    await _groupMenuService.Insert(groupmenuAdd);
                }
            }
            //Convert Lang
            var lang = await _langService.SearchByApp(from_app);
            if (lang != null)
            {
                lang.App = to_app;
                await _langService.Insert(lang);
            }
            //Convert LearnApi
            var list_learnApi = await _learnApiService.GetByApp(from_app);
            if (list_learnApi != null)
            {
                foreach (var learnApi in list_learnApi)
                {
                    var learnApiAdd = new LearnApi()
                    {
                        LearnApiData = learnApi.LearnApiData,
                        FlowApi = learnApi.FlowApi,
                        LearnApiApp = learnApi.LearnApiApp,
                        LearnApiHeader = learnApi.LearnApiHeader,
                        LearnApiId = learnApi.LearnApiId,
                        LearnApiLink = learnApi.LearnApiLink,
                        LearnApiMapping = learnApi.LearnApiMapping,
                        LearnApiMethod = learnApi.LearnApiMethod,
                        LearnApiName = learnApi.LearnApiName,
                        LearnApiNodeData = learnApi.LearnApiNodeData,
                        SaveTo = learnApi.SaveTo,
                        NumberOfSteps = learnApi.NumberOfSteps,
                        KeyReadData = learnApi.KeyReadData,
                        App = to_app
                    };
                    await _learnApiService.Insert(learnApiAdd);
                }
            }
            //Convert ParaServer
            var list_paraServer = await _paraServerService.GetByApp(from_app);
            if (list_paraServer != null)
            {
                foreach (var paraServer in list_paraServer)
                {
                    paraServer.App = to_app;
                    await _paraServerService.Insert(paraServer.FromModel<ParaServer>());
                }
            }
            //Convert TemplateVoucher
            var list_voucher = await _templateVoucherService.GetByApp(from_app);
            if (list_voucher != null)
            {
                foreach (var voucher in list_voucher)
                {
                    voucher.App = to_app;
                    await _templateVoucherService.Insert(voucher);
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("ex===" + ex);

        }

        return rs;
    }

    /// <summary>
    ///StartRequest
    /// </summary>
    /// <returns>Task&lt;FoResponseModel&gt;.</returns>
    public virtual async Task<ActionsResponseModel<object>> StartRequest(
        BoRequestModel request,
        HttpContext httpContext
    )
    {
        // System.Console.WriteLine(
        //     "begin StartRequest ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
    
        if (request.Bo == null)
        {
            return new ActionsResponseModel<object>();
        }

        var infoHeaderDictionary = Utils.Utils.GetHeaders(httpContext);
        RequestHeaderModel infoHeaderModel = new RequestHeaderModel();
        if (infoHeaderDictionary != null)
        {
            infoHeaderModel = new RequestHeaderModel()
            {
                Token = infoHeaderDictionary.GetValueOrDefault("uid"),
                Domain = infoHeaderDictionary.GetValueOrDefault("d"),
                Lang = infoHeaderDictionary.GetValueOrDefault("lang"),
                App = infoHeaderDictionary.GetValueOrDefault("app"),
                MyDevice =
                    infoHeaderDictionary.GetValueOrDefault("my_device") != null
                        ? JsonConvert.DeserializeObject<Dictionary<string, object>>(
                            infoHeaderDictionary.GetValueOrDefault("my_device")
                        )
                        : new Dictionary<string, object>(),
                OncePacked = Int32.Parse(infoHeaderDictionary.GetValueOrDefault("oncepacked")),
                OncePackedId = infoHeaderDictionary.GetValueOrDefault("oncepacked_id"),
                FormCode = infoHeaderDictionary.GetValueOrDefault("form_code"),
                FormName = infoHeaderDictionary.GetValueOrDefault("form_name"),
                FromActionCode = infoHeaderDictionary.GetValueOrDefault("from_action_code"),
                FromActionName = infoHeaderDictionary.GetValueOrDefault("from_action_name"),
                Url = infoHeaderDictionary.GetValueOrDefault("u"),
                // RequestTime = Int64.Parse(infoHeaderDictionary.GetValueOrDefault("request_time")),
                // PortalToken = infoHeaderDictionary.GetValueOrDefault("portal_token")
            };
        }
        // BO_GUID = Guid.NewGuid().ToString().Substring(0, 7);
        return await RunBo(request, infoHeaderModel, httpContext);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="formDataUpload"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public virtual async Task<UploadResponseModel> UploadFile(
        FormDataUploadModel formDataUpload,
        HttpContext httpContext
    )
    {
        var infoHeaderDictionary = Utils.Utils.GetHeaders(httpContext);
        RequestHeaderModel infoHeaderModel = new RequestHeaderModel();
        if (infoHeaderDictionary != null)
        {
            infoHeaderModel = new RequestHeaderModel()
            {
                Token = infoHeaderDictionary.GetValueOrDefault("uid"),
                Domain = infoHeaderDictionary.GetValueOrDefault("d"),
                Lang = infoHeaderDictionary.GetValueOrDefault("lang"),
                App = infoHeaderDictionary.GetValueOrDefault("app"),
                MyDevice =
                    infoHeaderDictionary.GetValueOrDefault("my_device") != null
                        ? JsonConvert.DeserializeObject<Dictionary<string, object>>(
                            infoHeaderDictionary.GetValueOrDefault("my_device")
                        )
                        : new Dictionary<string, object>(),
                FormCode = infoHeaderDictionary.GetValueOrDefault("form_code"),
                FormName = infoHeaderDictionary.GetValueOrDefault("form_name"),
                FromActionCode = infoHeaderDictionary.GetValueOrDefault("from_action_code"),
                FromActionName = infoHeaderDictionary.GetValueOrDefault("from_action_name"),
                Url = infoHeaderDictionary.GetValueOrDefault("u"),
                // PortalToken = infoHeaderDictionary.GetValueOrDefault("portal_token")
            };
        }

        // phaan quyeefn sau...

        UploadResponseModel response = new UploadResponseModel();

        if (formDataUpload.username != null)
        {
            response.user_id = formDataUpload.username;
            if (formDataUpload.new_name_file != null)
                response.name = formDataUpload.new_name_file;

            var dataFile = formDataUpload.attachment.ConvertToBase64();
            await _mediaUploadService.Insert(
                new MediaUpload()
                {
                    Token = infoHeaderModel.Token,
                    UserId = Int32.Parse(formDataUpload.username),
                    MediaName = formDataUpload.attachment.FileName,
                    MediaType = formDataUpload.attachment.GetExtension(),
                    MediaData = await formDataUpload.attachment.ConvertToBase64()
                }
            );
            response.status = (int)ErrorStatus.successUploadFile;
        }

        return response;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public virtual async Task<string> UploadFileZipNeptune(IFormFile file)
    {

        var response = await _postApiService.PostZipFileNeptune(file, "ncbs");
        return response;
    }

    /// <summary>
    ///RunBo
    /// </summary>
    /// <returns>Task&lt;FoResponseModel&gt;.</returns>
    public virtual async Task<ActionsResponseModel<object>> RunBo(
        BoRequestModel request_json,
        RequestHeaderModel infoHeader,
        HttpContext httpContext
    )
    {
        // System.Console.WriteLine(
        //     "begin RunBo ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
        // );
        List<BoRequest> BoArrays = request_json.Bo;
        ActionsResponseModel<object> result = new ActionsResponseModel<object>();
        var infoUserLogin = GetUserInfoLoginFromUID(infoHeader);

        string app_post = infoHeader.App;
        // AddErrorSystem("CMS.String.CantCallGrpcAdmin");
        // get SSID 13/2/2023
        var requestCookies = Utils.Utils.GetCookies(httpContext);
        var getSSIDFromCookies = "";
        var sSIDStr = "device_id";
        if (requestCookies.ContainsKey(sSIDStr))
            getSSIDFromCookies = requestCookies[sSIDStr];
        //validate device id and session
        var portalToken = "";
        var checkedSession = true;
        // ================================================================================
        // =================================infoUser======================================
        // ================================================================================
        SetPrivateFieldValue(context.InfoUser, infoUserLogin, "UserLogin");
        context.InfoUser.UserLogin = infoUserLogin;
        string list_bo_login = ";bo-protected-checkParameter;bo-projectLogin-start;bo-projectLogin-signIn;bo-login-start;bo-login-signIn;bo-app-O9;bo-relogin-login;bo-relogin-loginPin;bo-web-loadTemplate;bo-projectCreate-start;bo-creatApp-createDomain;bo-delete-session;bo-web-postData;bo-scheduleJob-extendToken;bo-projectLogin-blockUser;bo-load-txFo;bo-load-dyjs;bo-load-jlang;bo-login-loadApp;bo-projectLogin-listApplication;bo-login-ncbsCbs;bo-login-ncbs;";
        if(!String.IsNullOrEmpty(infoHeader.Token)){
            try
            {
                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    var userSessions = await _userSessions.GetByToken(infoHeader.Token);

                    if (userSessions != null)
                    {
                        // adminToken = getSessionByToken.Token;
                        if (getSSIDFromCookies != userSessions.Mac && !string.IsNullOrEmpty(userSessions.Token))
                        {
                            checkedSession = false;
                        }

                        if (userSessions.Acttype == "L")
                        {
                            checkedSession = false;
                        }


                        if (userSessions.Info.HasValue())
                        {
                            var sessionInfo = JObject.Parse(userSessions.Info);
                            if (sessionInfo != null) portalToken = sessionInfo["token"]?.ToString();

                            if (!portalToken.HasValue())
                                System.Console.WriteLine("portalToken!@#!@====" + portalToken);

                        }
                    }
                }
                else
                {
                    var getSessionByToken = await EngineContext.Current
                    .Resolve<IAdminGrpcService>()
                    .GetSessionByToken(infoHeader.Token);
                    if (getSessionByToken != null)
                    {
                        // adminToken = getSessionByToken.Token;
                        if (getSSIDFromCookies != getSessionByToken.Mac && !string.IsNullOrEmpty(getSessionByToken.Token))
                        {
                            checkedSession = false;
                        }

                        if (getSessionByToken.Acttype == "L")
                        {
                            checkedSession = false;
                        }


                        if (getSessionByToken.Info.HasValue())
                        {
                            var sessionInfo = JObject.Parse(getSessionByToken.Info);
                            if (sessionInfo != null) portalToken = sessionInfo["token"]?.ToString();

                            if (!portalToken.HasValue())
                                System.Console.WriteLine("portalToken!@#!@====" + portalToken);

                        }


                        // if (!checkedSession)
                        // {
                        //     var listMsgSystem = new List<MessageSystemModel>();
                        //     listMsgSystem.Add(
                        //         new MessageSystemModel() { title = "Invalid authorization session." }
                        //     );

                        //     Dictionary<string, object> foInput = new Dictionary<string, object>();
                        //     foInput.Add("listMsgSystem", listMsgSystem);

                        //     result.fo.Add(
                        //         new FoResponseModel<object>()
                        //         {
                        //             txcode = "#sys:fo-addMsgSystem",
                        //             input = foInput
                        //         }
                        //     );
                        //     return result;
                        // }
                    }

                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
                AddErrorSystem("CMS.String.CantCallGrpcAdmin");
            }
        }
        
        //
        // ================================================================================
        //===============================================IP,OS,BROWSER===============================================
        // ================================================================================
        SetPrivateFieldValue(
            context.InfoRequest,
            Utils.Utils.GetClientIPAddress(httpContext),
            "Ip"
        );
        SetPrivateFieldValue(context.InfoRequest, Utils.Utils.GetClientOs(httpContext), "ClientOs");
        SetPrivateFieldValue(
            context.InfoRequest,
            Utils.Utils.GetClientBrowser(httpContext),
            "ClientBrowser"
        );
        SetPrivateFieldValue(context.InfoRequest, request_json, "RequestJson");
        context.InfoRequest.DeviceID = getSSIDFromCookies;
        context.InfoRequest.PortalToken = portalToken;

        // ================================================================================
        //===============================================infoApp===============================================
        // ================================================================================
        // SetPrivateFieldValue(context.InfoApp, app_post, "App");
        context.InfoApp.App = app_post;
        context.InfoUser.UserLogin.PortalToken = portalToken;
        context.InfoUser.UserLogin.Token = infoHeader.Token;

// System.Console.WriteLine(
//             "done build config BO======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
//         );
        foreach (var bo_ in BoArrays)
        {
            //For bo crossing app
            string tx_code_bo = bo_.Txcode.Trim();

            string cross_application = "";
            if (tx_code_bo.Contains("#") && tx_code_bo.Contains(":"))
            {
                string[] cross_1 = tx_code_bo.Split(":");
                if (cross_1.Length > 1)
                {
                    cross_application = cross_1[0].Substring(1, cross_1[0].Length - 1);
                    tx_code_bo = tx_code_bo.Replace("#" + cross_application + ":", "").Trim();
                }
            }

            string app_get_file_bo = app_post;
            if (!cross_application.Equals(""))
                app_get_file_bo = cross_application;


            //check bo in list_bo_login
            if (list_bo_login.Contains($";{tx_code_bo};"))
                checkedSession = true;
            //
            if (!checkedSession)
            {
                var listMsgSystem = new List<MessageSystemModel>();
                listMsgSystem.Add(
                    new MessageSystemModel() { title = "Invalid authorization session." }
                );
                Dictionary<string, object> foInput_ = new Dictionary<string, object>();

                foInput_.Add("listMsgSystem", listMsgSystem);

                result.fo.Add(
                    new FoResponseModel<object>()
                    {
                        txcode = "#sys:fo-addMsgSystem",
                        input = foInput_
                    }
                );
                return result;
            }
            var boModel=new BoModel();
            try
            {   
                boModel  = await _boService.GetByTxcodeAndApp(tx_code_bo, app_get_file_bo);
            }
            catch (System.Exception ex)
            {
                 // TODO
                 System.Console.WriteLine("Can't connect to database===>"+ex);
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
                result.error.AddRange(listError);
            }
           

            if (boModel != null)
            {

                var bo_input = bo_.Input;

                FoResponseModel<object> foInput = new FoResponseModel<object>();
                foInput.txcode = tx_code_bo;
                // foInput.Add("input", new JObject());

                var actions = boModel.Actions;
                if (actions != null)
                {
                    var input_config = JObject.FromObject(boModel.Input);
                    foreach (var action_ in actions)
                    {
                        var function = action_.Function;
                        var status = action_.Status;
                        if (status == "A")
                        {
                            string class_name = "";
                            string function_name = "";
                            object[] para_f = action_.Para.Cast<object>().ToArray();

                            string[] function_ = action_.Function.Split('.');

                            if (function_.Length == 2)
                            {
                                class_name = Constants.PackageDefault + function_[0];
                                function_name = function_[1];
                            }
                            else
                            {
                                function_name = function_[function_.Length - 1];
                                function_ = function_.SkipLast(1).ToArray();
                                class_name = String.Join(".", function_);
                            }
                            System.Console.WriteLine("function_name===" + function_name);
                            System.Console.WriteLine("class_name===" + class_name);

                            //
        //                     System.Console.WriteLine(
        //     "start call BO ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
        // );
                            JObject boInput = JObject.FromObject(bo_input);
                            if (
                                !RunFunction(
                                    ref result,
                                    class_name,
                                    function_name,
                                    app_post,
                                    para_f,
                                    input_config,
                                    ref boInput,
                                    ref foInput,
                                    action_,
                                    false,
                                    tx_code_bo
                                )
                            )
                                break;
                        }
                    }

                    foInput = context.Bo.GetFoInput();
                    if (foInput.input != null && boModel.Response.fo != null)
                    {
                        if (boModel.Response.fo.Count > 0)
                        {
                            var arrayFoResponseTx = CreateFo(
                                boModel.Response.fo,
                                JObject.FromObject(foInput.input)
                            );

                            result.fo.AddRange(arrayFoResponseTx);
                        }
                    }

                    // else
                    // {
                    //     if (result.fo != null && result.fo.Count > 0)
                    //         arrayFo.AddRange(CreateFo(result.fo, new JObject()));
                    // }
                }
            }
        }
        System.Console.WriteLine("result.error===" + result.error.ToSerialize());
        if (result.error != null)
        {
            if (result.error.Count > 0)
            {
                result.fo.Add(CreateFoError(result.error));
            }
        }
        return result;
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
               System.Console.WriteLine("AddErrorSystem======="+ ex.ToString());
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
    /// <param name="resultFo"></param>
    /// <param name="name_space"></param>
    /// <param name="class_function"></param>
    /// <param name="app"></param>
    /// <param name="para_dynamic"></param>
    /// <param name="input_config"></param>
    /// <param name="boInput"></param>
    /// <param name="foInput"></param>
    /// <param name="action_config"></param>
    /// <param name="isDebug"></param>
    /// <param name="tx_code_bo"></param>
    /// <returns></returns>
    public bool RunFunction(
        ref ActionsResponseModel<object> resultFo,
        string name_space,
        string class_function,
        string app,
        object[] para_dynamic,
        JObject input_config,
        ref JObject boInput,
        ref FoResponseModel<object> foInput,
        BoAction action_config,
        bool isDebug,
        string tx_code_bo
    )
    {
        name_space = Constants.NameSpaceDefault + BuildCMSNamespace(name_space);
        JObject actionInput = new JObject();
        //take the class
        string class_name = name_space.Split(".")[name_space.Split(".").Length - 1]
            .CaptializeFirstLetter()
            .Replace("_", "");
        // var responseFunc = "";
        Task<string> responseFunc = null;

        bool rsFunc = true;
        para_dynamic = BuildParaWithBoInput(ref para_dynamic, boInput);
        try
        {
            // ====================== BO ===========================
            SetPrivateFieldValue(context.Bo, boInput, "boInput");
            SetPrivateFieldValue(context.Bo, foInput, "foInput");
            SetPrivateFieldValue(context.Bo, actionInput, "actionInput");

            System.Console.WriteLine("name_space---" + name_space);
            System.Console.WriteLine("class_function---" + class_function);

            if (para_dynamic != null)
            {
                responseFunc = ReflectionHelper.DynamicInvokeAsync<string>(name_space, class_function, para_dynamic);
            }
            else
            {
                responseFunc = ReflectionHelper.DynamicInvokeAsync<string>(name_space, class_function, new object[] { });
            }
            // responseFunc = ReflectionHelper.DynamicInvoke<Task<string>>(name_space, class_function, new object[] { });
            // }
            string responseFunc_ = "";
            if (responseFunc != null)
            {
        //         System.Console.WriteLine(
        //     "start call function BO ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
        // );
                responseFunc_ = responseFunc.GetAwaiter().GetResult();
                List<FoResponseModel<object>> foArray = new List<FoResponseModel<object>>();
                actionInput = context.Bo.GetActionInput();
                if (action_config.Response != null)
                {
                    var ActionResponse = action_config.Response;

                    ActionsResponseModel<object> rsFo = new ActionsResponseModel<object>();
                    if (ActionResponse.ContainsKey(responseFunc_))
                    {
                        ActionResponse.TryGetValue(responseFunc_, out rsFo);
                    }
                    else if (ActionResponse.ContainsKey("_default_"))
                    {
                        ActionResponse.TryGetValue("_default_", out rsFo);
                    }
                    if (rsFo.fo != null)
                    {
                        foArray = CreateFo(rsFo.fo, actionInput);

                        JObject JObjRsFo = JObject.FromObject(rsFo);
                        if (JObjRsFo.ContainsKey("cmd"))
                            if (JObjRsFo.GetValue("cmd").Equals("stop"))
                                rsFunc = false; // stop all
                    }
                }
                // Add action error
                if (foArray != null)
                    resultFo.fo.AddRange(foArray);
                if (context.Bo.GetActionErrors() != null)
                    resultFo.error.AddRange(context.Bo.GetActionErrors());



                return rsFunc;
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("System.Exception---" + ex.StackTrace);

            // TODO
        }

        return false;
    }

    // /// <summary>
    // ///
    // /// </summary>
    // /// <param name="name_space"></param>
    // /// <param name="class_function"></param>
    // /// <param name="para_dynamic"></param>
    // /// <returns></returns>
    // public async Task<string> DynamicInvokeAsync(
    //     string name_space,
    //     string class_function,
    //     object[] para_dynamic
    // )
    // {
    //     return await ReflectionHelper.DynamicInvokeAsync<string>(
    //         name_space,
    //         class_function,
    //         para_dynamic
    //     );
    // }

    private static object[] BuildParaWithBoInput(ref object[] para, JObject boInput)
    {
        for (int i = 0; i < para.Length; i++)
        {
            string paraStr = para[i].ToString();
            if (paraStr.Contains('@'))
            {
                paraStr = paraStr.Replace("@", "");
                if (boInput.ContainsKey(paraStr))
                {
                    var itemPara = boInput.GetValue(paraStr);
                    para.SetValue(itemPara.ToString(), i);
                }
            }
        }
        return para;
    }

    private static string BuildCMSNamespace(string oldNameSpace)
    {
        string newNameSpace = "";
        string[] name_space_ = oldNameSpace.Split('.');
        for (var i = 0; i < name_space_.Length; i++)
        {
            name_space_[i] = name_space_[i].CaptializeFirstLetter().Replace("_", "");
        }
        newNameSpace = string.Join(".", name_space_);
        return newNameSpace;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="arrayFo"></param>
    /// <param name="actionInput"></param>
    /// <returns></returns>
    public List<FoResponseModel<object>> CreateFo(
        List<FoResponseModel<object>> arrayFo,
        JObject actionInput
    )
    {
        List<FoResponseModel<object>> rs_ = new List<FoResponseModel<object>>();
        foreach (FoResponseModel<object> obj in arrayFo)
        {
            FoResponseModel<object> obRs = new FoResponseModel<object>();
            if (obj.txcode != null)
            {
                if (!obj.txcode.Trim().Equals(""))
                {
                    obRs.txcode = obj.txcode.Trim();

                    if (obj.input != null)
                    {
                        Dictionary<string, object> obJoin = new Dictionary<string, object>();
                        foreach (var itemObj in obj.input)
                        {
                            obJoin.Add(itemObj.Key, itemObj.Value);
                            // obJoin.Add(itemObj.Key, JObject.FromObject(itemObj.Value));
                        }
                        foreach (var itemActionInput in actionInput)
                        {
                            if (obJoin.ContainsKey(itemActionInput.Key))
                                obJoin[itemActionInput.Key] = itemActionInput.Value;
                            else
                                obJoin.Add(itemActionInput.Key, itemActionInput.Value);
                            // else obJoin[itemActionInput.Key] = itemActionInput.Value;
                            // obJoin.Add(itemActionInput.Key, JObject.FromObject(itemActionInput.Value));
                        }
                        obRs.input = obJoin;
                        rs_.Add(obRs);
                    }
                    else if (!string.IsNullOrEmpty(obRs.txcode))
                    {
                        obRs.input = actionInput.ToDictionary();

                        rs_.Add(obRs);
                    }
                }
            }
        }
        return rs_;
    }

    private static FoResponseModel<object> CreateFoError(List<ErrorInfoModel> arr)
    {
        FoResponseModel<object> rs_ = new FoResponseModel<object>();
        rs_.txcode = "#sys:fo-sys-showError";
        Dictionary<string, object> errorInput = new Dictionary<string, object>();
        errorInput.Add("infoError", arr);
        rs_.input = errorInput;
        return rs_;
    }

    private bool checkJwebuiAttributeClass(string class_name)
    {
        Type type = Type.GetType(class_name);
        object instance = Activator.CreateInstance(type);
        foreach (var attr in instance.GetType().GetCustomAttributes(false))
        {
            JwebuiClassAttribute mota = attr as JwebuiClassAttribute;
            if (mota != null)
            {
                return true;
            }
        }

        return false;
    }

    private bool checkSetJwebuiAttributeContext(
        string class_name,
        string context_name,
        object value
    )
    {
        Type type = Type.GetType(class_name);
        object instance = Activator.CreateInstance(type);

        foreach (var field_ in instance.GetType().GetProperties())
        {
            if (field_.Name.Equals(context_name))
            {
                foreach (var attr in field_.GetCustomAttributes(false))
                {
                    JwebuiContextAttribute mota = attr as JwebuiContextAttribute;
                    if (mota != null)
                    {
                        // instance.GetType().GetProperty(context_name).SetValue(instance, value);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool checkJwebuiAttributeMethod(string class_name, string method)
    {
        Type type = Type.GetType(class_name);
        object instance = Activator.CreateInstance(type);
        foreach (var m in instance.GetType().GetMethods())
        {
            if (m.Name.Equals(method))
            {
                foreach (var attr in m.GetCustomAttributes(false))
                {
                    JwebuiFunctionAttribute mota = attr as JwebuiFunctionAttribute;
                    if (mota != null)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void SetPrivateFieldValue(object obj, object val, string propName)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
        Type t = obj.GetType();
        FieldInfo fi = null;
        while (fi == null && t != null)
        {
            fi = t.GetField(
                propName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
            );
            t = t.BaseType;
        }
        if (fi == null)
            throw new ArgumentOutOfRangeException(
                "propName",
                string.Format(
                    "Field {0} was not found in Type {1}",
                    propName,
                    obj.GetType().FullName
                )
            );
        fi.SetValue(obj, val);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="infoLogin"></param>
    /// <returns></returns>
    public virtual RequestHeaderModel GetUserInfoLoginFromUID(RequestHeaderModel infoLogin)
    {
        InfoUserLoginModel loginRs = new InfoUserLoginModel();
        if (!infoLogin.Token.Equals(""))
        {
            string token = infoLogin.Token;

            if (!token.Equals(""))
            {
                int userId = GetUserIdFromJWT(token);
                infoLogin.UserId = userId;
            }
        }

        return infoLogin;
    }

    private int GetUserIdFromJWT(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_cmsSeting.SecretKey);

            tokenHandler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                },
                out var validatedToken
            );

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);

            return userId;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
            // do nothing if jwt validation fails
            return 0;
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<string> BuildListAuthorizeForms(string app)
    {
        foreach (var item in (await _groupMenuService.SearchByApp(app)))
        {
            if (
                string.IsNullOrEmpty(item.GroupMenuListAuthorizeForm)
                && item.GroupMenuFunctionCode.StartsWith("BO_")
                && item.GroupMenuFunctionCode.EndsWith("_Search")
            )
            {
                switch (item.GroupMenuFunctionCode)
                {
                    case "BO_006002_Search":
                        item.GroupMenuListAuthorizeForm = "BO_006002;FO_CRD_OPN";
                        var itemUpdate = _groupMenuService.ToEntity(item);
                        await _groupMenuService.Update(itemUpdate);
                        break;
                    case "BO_005002_Search":
                        item.GroupMenuListAuthorizeForm = "BO_005002;FO_DPT_OPN;BO_005002_print";
                        var itemUpdate1 = _groupMenuService.ToEntity(item);
                        await _groupMenuService.Update(itemUpdate1);
                        break;
                    case "BO_010002_Search":
                        item.GroupMenuListAuthorizeForm = "BO_010002;FO_MTG_OPN";
                        var itemUpdate2 = _groupMenuService.ToEntity(item);
                        await _groupMenuService.Update(itemUpdate2);
                        break;
                    default:
                        var str = item.GroupMenuFunctionCode.Replace("_Search", "");
                        item.GroupMenuListAuthorizeForm = str + "_Add;" + str;
                        var itemUpdate3 = _groupMenuService.ToEntity(item);
                        await _groupMenuService.Update(itemUpdate3);
                        break;
                }
            }
        }
        return "true";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<string> BuildFormLangByFormName(string app)
    {
        foreach (var item in (await _formService.GetByApp(app)))
        {
            var form_ = item;
            form_.Info.Lang_Form["en"] = form_.Info.Title;
            await _formService.Update(
                new Form()
                {
                    Id = form_.Id,
                    App = app,
                    FormId = form_.FormId,
                    Info = JsonConvert.SerializeObject(form_.Info),
                    ListLayout = JsonConvert.SerializeObject(form_.ListLayout)
                }
            );
        }
        return "true";
    }


}
