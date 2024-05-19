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
/// TxPrint
/// </summary>
[JwebuiClassAttribute]
public class TxSchedule
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
    private readonly ITemplateVoucherService _templateVoucherService;
    private readonly CMSSetting _cMSSetting;
    private readonly ILocalizationService _localizationService;

    /// <summary>
    ///TxPrint
    /// </summary>

    public TxSchedule(ILocalizationService localizationService,IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IFormOfRoleService formOfRoleService, IFormService formService, ITemplateVoucherService templateVoucherService, IPostAPIService postAPIService, IMediaUploadService mediaUploadService, IGroupMenuService groupMenuService, CMSSetting cMSSetting)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _formOfRoleService = formOfRoleService;
        _formService = formService;
        _postAPIService = postAPIService;
        _mediaUploadService = mediaUploadService;
        _groupMenuService = groupMenuService;
        _templateVoucherService = templateVoucherService;
        _cMSSetting = cMSSetting;
        _localizationService = localizationService;
    }

    /// <summary>
    ///getDevice
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loadScheduleStatusStart()
    {
        var boInput = context?.Bo?.GetBoInput();
        try
        {
            var getScheduleJobByApp = await EngineContext.Current.Resolve<IScheduleJobService>().GetByApp(context.InfoApp.GetApp());
            var templates = new List<ScheduleJobModel>();
            if (getScheduleJobByApp != null)
            {
                context.Bo.AddPackFo("scheduleJob"
                , Utils.Utils.BuildTableCodeForArray(getScheduleJobByApp.FindAll(s => s.Status.Equals("start")).ToJArray(), "scheduleJob"));
                return "true";
            }
        }
        catch (System.Exception ex)
        {
             // TODO
               System.Console.WriteLine(ex.ToString());
               AddErrorSystem("CMS.String.CantConnectDb");
        }
        
        return "false";
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
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<string> loadScheduleID(string id)
    {
        var getScheduleById = await EngineContext.Current.Resolve<IScheduleJobService>().GetByAppAndId(context.InfoApp.GetApp(), int.Parse(id));
        if (getScheduleById != null)
        {
            var obData = new JObject();
            obData["scheduleJob"] = getScheduleById.ToJObject();
            context.Bo.AddPackFo("loadScheduleID", obData);
            return "true";
        }
        return "false";
    }


}
