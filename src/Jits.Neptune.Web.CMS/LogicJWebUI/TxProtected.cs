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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Jwebui.Logic;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxProtected
{
    /// <summary>
    ///context
    /// </summary>
    [JwebuiContextAttribute]
    public JWebUIObjectContextModel context { get; set; }

    private readonly IOrganizationParameterService _organizationParameterService;
    private readonly IAdminGrpcService _adminGrpcService;
    private readonly IPostAPIService _postApiService;
    private readonly ILocalizationService _localizationService;
    private readonly IUserSessionsService _userSessionsService = EngineContext.Current.Resolve<IUserSessionsService>();

    /// <summary>
    ///Tx
    /// </summary>
    public TxProtected(ILocalizationService localizationService, 
        IOrganizationParameterService organizationParameterService, 
        IAdminGrpcService adminGrpcService, 
        IPostAPIService postAPIService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _localizationService = localizationService;
        _organizationParameterService = organizationParameterService;
        _adminGrpcService = adminGrpcService;
        _postApiService = postAPIService;
    }

    /// <summary>
    ///getDevice
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> checkInfoRequest()
    {
        JObject obInfoClient = new();
        String ip_ = context.InfoRequest.GetIp();
        String client_os_ = context.InfoRequest.GetClientOs();
        String client_browser_ = context.InfoRequest.GetClientBrowser();

        if (!ip_.Equals("") && !client_os_.Equals("") && !client_browser_.Equals(""))
        {
            obInfoClient.Add("my_ip", ip_);
            obInfoClient.Add("osVersion", client_os_);
            obInfoClient.Add("browser", client_browser_);
        }
        var token = context.InfoUser.GetUserLogin().Token;
        var sessionInfo = new Dictionary<string, object>();
        if (!string.IsNullOrEmpty(token))
        {
            try
            {
                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    var userSessionInfo = await _userSessionsService.GetByToken(token);
                    if (userSessionInfo!= null && !string.IsNullOrEmpty(userSessionInfo.Info))
                    {
                        sessionInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(userSessionInfo.Info);
                    }
                    var objInfo = sessionInfo.MergeDictionary(obInfoClient.ToObject<Dictionary<string, object>>());
                    await _userSessionsService.UpdateInfo(token, objInfo.ToSerialize());
                }
                else
                {
                    var userSessionInfo = await _adminGrpcService.GetSessionByToken(token);
                    if (!string.IsNullOrEmpty(userSessionInfo.Info))
                    {
                        sessionInfo = JsonConvert.DeserializeObject<Dictionary<string, object>>(userSessionInfo.Info);
                    }
                    var objInfo = sessionInfo.MergeDictionary(obInfoClient.ToObject<Dictionary<string, object>>());
                    await _adminGrpcService.UpdateSessionInfo(token, objInfo.ToSerialize());
                }
            }
            catch (System.Exception)
            {
                AddErrorSystem("CMS.String.CantCallGrpcAdmin");
                return "false";
            }

        }
        context.Bo.AddPackFo("read_info_client", obInfoClient);
        return "true";
    }
    private async void AddErrorSystem(string keyError)
    {
        try
        {
            var Error_string = await _localizationService.GetResource(keyError, context.InfoUser.GetUserLogin().Lang);

            List<ErrorInfoModel> listError = new()
            {
                Utils.Utils.AddActionError(
                        ErrorType.errorSystem,
                        ErrorMainForm.danger,
                        Error_string,
                        "",
                        "#ERROR_SYSTEM: "
                )
            };
            context.Bo.AddActionErrorAll(listError);
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.ToString());
            var Error_string = "Can't connect to database. Please check your database!";
            List<ErrorInfoModel> listError = new()
            {
                Utils.Utils.AddActionError(
                        ErrorType.errorSystem,
                        ErrorMainForm.danger,
                        Error_string,
                        "",
                        "#ERROR_SYSTEM: "
                )
            };
            context.Bo.AddActionErrorAll(listError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="org_code"></param>
    /// <returns></returns>
    public async Task<string> getOrganization(string org_code)
    {
        // Lấy thông tin của organization để trả về client
        context.Bo.GetBoInput()["org_code"] = org_code;
        context.Bo.GetBoInput()["learn_api"] = "get_organization_info";
        string login_background = "";
        string welcome_logo = "";
        string welcome_title = "";
        string welcome_sub_title = "";
        if (!String.IsNullOrEmpty(org_code))
        {
            try
            {
                var orgInfo = await _postApiService.GetDataPostAPI("ncbs", "view", context);
                var getByOrg = await _organizationParameterService.GetByOrg(org_code);
                //System.Console.WriteLine("getByOrg" + getByOrg.ToSerialize());

                if (orgInfo != null)
                {
                    login_background = orgInfo.SelectToken("login_background").ToString();
                    welcome_logo = orgInfo.SelectToken("welcome_logo").ToString();
                }
                if (getByOrg != null)
                {
                    if (login_background == "")
                    {
                        login_background = getByOrg.Find(s => s.ParamaterCode.Equals("login_background")) != null ? getByOrg.Find(s => s.ParamaterCode.Equals("login_background")).ParameterValue : "";
                    }
                    if (welcome_logo == "")
                    {
                        welcome_logo = getByOrg.Find(s => s.ParamaterCode.Equals("welcome_logo")) != null ? getByOrg.Find(s => s.ParamaterCode.Equals("welcome_logo")).ParameterValue : "";
                    }
                    welcome_title = getByOrg.Find(s => s.ParamaterCode.Equals("welcome_title")) != null ? getByOrg.Find(s => s.ParamaterCode.Equals("welcome_title")).ParameterValue : "";
                    welcome_sub_title = getByOrg.Find(s => s.ParamaterCode.Equals("welcome_sub_title")) != null ? getByOrg.Find(s => s.ParamaterCode.Equals("welcome_sub_title")).ParameterValue : "";
                }
            }
            catch (System.Exception)
            {

                AddErrorSystem("CMS.String.CantCallGrpcAdmin");
            }

        }

        var infoOrg = new InfoBackgroundOrganizationModel()
        {
            login_background = login_background,
            welcome_logo = welcome_logo,
            welcome_title = welcome_title,
            welcome_sub_title = welcome_sub_title,
        };

        context.Bo.AddPackFo<InfoBackgroundOrganizationModel>("info_organization", infoOrg);
        return "true";
    }

}
