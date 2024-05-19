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

namespace Jits.Neptune.Web.CMS.Ncbs.Core;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxNcbsLogin
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
    private readonly IUserSessionsService _userSessions;

    /// <summary>
    ///Tx
    /// </summary>

    public TxNcbsLogin(IFoService foService, 
                        IAppService appService, 
                        ILangService langService, 
                        IParaServerService paraServerService, 
                        IAdminGrpcService adminGrpcService, 
                        IAuthenticationGrpcService authenticationGrpcService,
                        IUserSessionsService userSessions
        )
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _userSessions = userSessions;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loginApi(string a)
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


}
