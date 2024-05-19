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
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
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
public class TxLogin
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
    private readonly IWebSocketsService _webSocketsService;
    private readonly IPostAPIService _postAPIService;
    private readonly CMSSetting _cMSSetting;
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly IUserSessionsService _userSessions;

    //
    private readonly IAdminServices _adminService;
    //

    /// <summary>
    ///Tx
    /// </summary>

    public TxLogin(IFoService foService, 
                    IAppService appService,
                    ILangService langService, 
                    IParaServerService paraServerService,
                    IAdminServices adminService,
                    IAdminGrpcService adminGrpcService, 
                    IAuthenticationGrpcService authenticationGrpcService, 
                    IWebSocketsService webSocketsService, 
                    IPostAPIService postAPIService, 
                    CMSSetting cMSSetting,
                    IUserSessionsService userSessions
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
        _webSocketsService = webSocketsService;
        _postAPIService = postAPIService;
        _cMSSetting = cMSSetting;
        _userSessions = userSessions;
    }

    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loginApi(string a, string b)
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        if (!infoUserLogin.UserId.ToString().Equals(""))
        {

            JObject statusLogin = new JObject();


            statusLogin.Add(new JProperty("status_login", "login#127"));

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var sessionRecord = await _userSessions.GetByToken(infoUserLogin.Token);

                if (sessionRecord != null)
                {
                    if (sessionRecord.ResetPassword)
                        statusLogin["client_open_form_resetpwd"] = true;
                }
            }
            else
            {
                var getUserInfo = await _adminGrpcService.GetUserAccountById(infoUserLogin.UserId.ToString());

                if (getUserInfo != null)
                {
                    if (getUserInfo.ResetPassword)
                        statusLogin["client_open_form_resetpwd"] = true;
                }
            }

            context.Bo.AddPackFo("loginApp", statusLogin);

            return "true";
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> ExtendToken()
    {
        if (_cMSSetting.AUTO_EXTEND_SESSION.Equals("Yes"))
        {
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var createNewToken = await _adminService.CreateOtherToken(context.InfoUser.GetUserLogin().Token);
                if (!string.IsNullOrEmpty(createNewToken))
                {
                    var getOldSessionByToken = await _adminService.GetSessionByToken(context.InfoUser.GetUserLogin().Token);
                    await _adminService.UpdateSessionApplicationCode(createNewToken, getOldSessionByToken.ApplicationCode);
                    await _adminService.UpdateSessionInfo(createNewToken, getOldSessionByToken.Info);
                    await _adminService.UpdateSessionMac(createNewToken, getOldSessionByToken.Mac);
                    context.Bo.AddPackFo("extend_token", createNewToken);
                    return "true";
                }
            }
            else
            {
                var createNewToken = await _adminGrpcService.CreateOtherToken(context.InfoUser.GetUserLogin().Token);
                if (!string.IsNullOrEmpty(createNewToken))
                {

                    var getOldSessionByToken = await _adminGrpcService.GetSessionByToken(context.InfoUser.GetUserLogin().Token);
                    await _adminGrpcService.UpdateSessionApplicationCode(createNewToken, getOldSessionByToken.ApplicationCode);
                    await _adminGrpcService.UpdateSessionInfo(createNewToken, getOldSessionByToken.Info);
                    await _adminGrpcService.UpdateSessionMac(createNewToken, getOldSessionByToken.Mac);
                    context.Bo.AddPackFo("extend_token", createNewToken);
                    return "true";
                }
            }
        }

        return "false";
    }


}
