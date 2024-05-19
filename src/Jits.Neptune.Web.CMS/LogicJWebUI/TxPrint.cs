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
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
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
public class TxPrint
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
    private readonly IO9PostService _o9PostService;

    /// <summary>
    ///TxPrint
    /// </summary>

    public TxPrint(IFoService foService, IAppService appService, ILangService langService, 
    IParaServerService paraServerService, IAdminGrpcService adminGrpcService, 
    IAuthenticationGrpcService authenticationGrpcService, IFormOfRoleService formOfRoleService, 
    IFormService formService,ITemplateVoucherService templateVoucherService, 
    IPostAPIService postAPIService, IMediaUploadService mediaUploadService,
    IGroupMenuService groupMenuService,CMSSetting cMSSetting, IO9PostService o9PostService)
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
        _o9PostService = o9PostService;
    }

    /// <summary>
    ///getDevice
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getTemplatePrint()
    {
        var boInput = context?.Bo?.GetBoInput();

		JArray templates = new JArray();

		if (boInput.ContainsKey("templates")) {
            if(boInput.GetValue("templates").ToString()!="")
			{
                string[] list_templates = boInput.GetValue("templates").ToString().Split(",");
			foreach (var template in list_templates){
                var voucher = await _templateVoucherService.GetByIdAndApp(template,context.InfoApp.GetApp());
				
				if (voucher!=null) {
					if (voucher.HtmlCode!="") {
						templates.Add(JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(voucher)));
					} else {
						JObject error = new JObject();
                        error["code"]= template;
                        templates.Add(error);
					}
				} else {
					JObject error = new JObject();
					error["code"]= template;
					templates.Add(error);
				}
			}
            }
		}
		// Tải thêm dữ liệu cần cho template
		if (boInput.ContainsKey("learn_api")) {
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
			    rs = await _postAPIService.GetDataPostAPI(context.InfoApp.GetApp(), "create", context);
            }

             context.Bo.AddPackFo("ob_data", rs);
		}
        context.Bo.AddPackFo("list_templates", templates);
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createDataPrintPassbook()
    {
        var boInput = context?.Bo?.GetBoInput();
		if (boInput.ContainsKey("learn_api")) {
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
			    rs = await _postAPIService.GetDataPostAPIWithoutKeyReadData
                (context.InfoApp.GetApp(), "create", context);
            }    

             context.Bo.AddPackFo("ref_id", rs);
		}
        // context.Bo.AddPackFo("list_templates", templates);
        return "true";
    }
    // public async Task<string> getReportConfig()
    // {
    //     var boInput = context?.Bo?.GetBoInput();

	
	// 	if (boInput.ContainsKey("report_code")) {
    //         if(boInput.GetValue("report_code").ToString()!="")
	// 		{
    //             var report_code = boInput.GetValue("report_code").ToString();
			
    //             var report = await _reportService.GetByAppAndCode(context.InfoApp.GetApp(),report_code);
				
	// 			if (report!=null) {
	// 				 context.Bo.AddPackFo("report_config", JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(report)));
    //                   return "true";
	// 			} else {
	// 				JObject error = new JObject();
	// 				error["code"]= JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(report));
    //                 context.Bo.AddPackFo("report_config", error);
    //                   return "true";
	// 			}
	// 		}
    //     }
    //     return "true";
    // }
}
