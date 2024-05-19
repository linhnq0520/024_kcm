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

namespace Jits.Neptune.Web.CMS.Jwebui.Logic;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxManagerUser
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
    private readonly IAppOfRoleService _appOfRoleService;

    //
    private readonly IAdminServices _adminService;
    //

    /// <summary>
    ///Tx
    /// </summary>

    public TxManagerUser(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminServices adminService, IAdminGrpcService adminGrpcService, IAppOfRoleService appOfRoleService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminService = adminService;
        _adminGrpcService = adminGrpcService;
        _appOfRoleService = appOfRoleService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getListAppOfRole()
    {
        var infoUserLogin = context.InfoUser.GetUserLogin();
        try
        {
            // System.Console.WriteLine("infoUserLogin"+infoUserLogin.UserId.ToString());
            string listAppInRole = "";
            JArray listApplication = new JArray();

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {

                var listApp = await _appOfRoleService.GetByRoleId(2);

                if (listApp != null)
                {
                    if (!listApp.App.Equals(""))
                    {
                        listAppInRole += listApp.App + ";";
                    }
                }
            }
            else
            {
                var listRole = await _adminGrpcService.GetListRoleByUserId(infoUserLogin.UserId.ToString());
                foreach (var itemRole in listRole)
                {

                    var listApp = await _appOfRoleService.GetByRoleId(itemRole.RoleId);

                    if (listApp != null)
                    {
                        if (!listApp.App.Equals(""))
                        {
                            listAppInRole += listApp.App + ";";
                        }
                    }

                }
            }

            foreach (var item in listAppInRole.Split(";").Distinct().Where(s => !s.Equals("")))
            {
                var appInfor = _appService.GetByAppCode(item).GetAwaiter().GetResult();
                if (appInfor != null)
                {
                    JObject dataAdd = new JObject();
                    dataAdd.Add(new JProperty("list_application", JObject.FromObject(appInfor)));
                    listApplication.Add(dataAdd);
                }

            }

            context.Bo.AddPackFo("list_application", listApplication);
            return "true";

        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("getListAppOfRole--Exception---" + ex.StackTrace);

        }

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> getProfileUser()
    {
        ProfileDetailModel profileModel = new ProfileDetailModel();
        var dataUserLogin = context?.InfoUser.GetUserLogin();
        // 20240404 - NhanTH
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var loginResponse = await _adminService.GetUserAccountById(dataUserLogin.UserId.ToString());
            if (loginResponse != null)
            {
                profileModel.profileAppDetail = loginResponse;
                context.Bo.AddPackFo<ProfileDetailModel>("profile", profileModel);

                return "true";
            }

            return "false";
        }
        else
        {
            var loginResponse = await _adminGrpcService.GetUserAccountById(dataUserLogin.UserId.ToString());
            if (loginResponse != null)
            {
                profileModel.profileAppDetail = loginResponse;
                context.Bo.AddPackFo<ProfileDetailModel>("profile", profileModel);

                return "true";
            }

            return "false";
        }
        //
    }

}
