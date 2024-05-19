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
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Jwebui.Logic;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxContext
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
    private readonly IGroupMenuService _groupMenuService;
    private readonly CMSSetting _cMSSetting;
    private readonly ILocalizationService _localizationService;

    private readonly IMemoryCache _memoryCache;
    //
    private readonly IAdminServices _adminService;
    //


    /// <summary>
    ///Tx
    /// </summary>

    public TxContext(ILocalizationService localizationService, IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminServices adminService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IGroupMenuService groupMenuService, CMSSetting cMSSetting, IMemoryCache memoryCache)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminService = adminService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _groupMenuService = groupMenuService;
        _cMSSetting = cMSSetting;
        _memoryCache = memoryCache;
        _localizationService = localizationService;

    }
    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>

    [JwebuiFunctionAttribute]
    public async Task<string> getContext()
    {
        var context_ = new ContextUserModel();
        try
        {
            var dataUserLogin = context?.InfoUser.GetUserLogin();

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {   
                var loginResponse = await _adminService.GetUserAccountById(dataUserLogin.UserId.ToString());

                var loginPortalResponse = await _adminService.GetSessionByToken(dataUserLogin.Token);
                loginResponse.WorkingDate = loginPortalResponse.Txdt;

                if (loginResponse != null && loginPortalResponse != null)
                {
                    var context_portal = new UserPortalModel()
                    {
                        user_portal = JsonConvert.DeserializeObject<Dictionary<string, object>>(loginPortalResponse.Info)
                    };

                    context_.user_acc = context_portal.ToDictionary().MergeDictionary(loginResponse.ToDictionary());

                    var userJwebui = new UserJWebUIModel
                    {
                        email = loginResponse.LoginName,
                        user_id = dataUserLogin.UserId
                    };
                    context_.user_jwebui = userJwebui;

                    context.Bo.AddPackFo("context", context_);
                }
            }
            else
            {
                var loginResponse = await _adminGrpcService.GetUserAccountById(dataUserLogin.UserId.ToString());
                var loginPortalResponse = await _adminGrpcService.GetSessionByToken(dataUserLogin.Token);
                if (loginResponse != null && loginPortalResponse != null)
                {
                    var context_portal = new UserPortalModel()
                    {
                        user_portal = JsonConvert.DeserializeObject<Dictionary<string, object>>(loginPortalResponse.Info)
                    };

                    context_.user_acc = context_portal.ToDictionary().MergeDictionary(loginResponse.ToDictionary());

                    var userJwebui = new UserJWebUIModel
                    {
                        email = loginResponse.LoginName,
                        user_id = dataUserLogin.UserId
                    };
                    context_.user_jwebui = userJwebui;

                    context.Bo.AddPackFo("context", context_);
                }
            }
            //
        }
        catch (System.Exception ex)
        {
             // TODO
            System.Console.WriteLine(ex.ToString());
            context.Bo.AddPackFo("context", context_);
            AddErrorSystem("CMS.String.CantCallGrpcAdmin");
        }
        
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
}
