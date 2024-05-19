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
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
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
public class TxNcbsAPI
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
    private readonly IPostAPIService _postApiService;
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly ILearnApiService _learnApiService;
    private readonly IWebSocketsService _webSocketsService;
    private readonly IO9PostService _o9PostService;

    /// <summary>
    ///Tx
    /// </summary>

    public TxNcbsAPI(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, ILearnApiService learnApiService, 
        IWebSocketsService webSocketsService,
        IO9PostService o9PostService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _postApiService = postAPIService;
        _learnApiService = learnApiService;
        _webSocketsService = webSocketsService;
        _o9PostService = o9PostService;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> postAPI()
    {

        var boInput = context?.Bo?.GetBoInput();

        int numberOfSteps = 1;


        if (boInput.ContainsKey("number_of_step"))
            // numberOfSteps = Int32.Parse(boInput.GetValue("number_of_step").ToString());
            numberOfSteps = Int32.Parse(boInput["number_of_step"].ToString());

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "postAPI",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "postAPI", context);
        }

        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
        Console.WriteLine("=====obData======" + JsonConvert.SerializeObject(obData));

        if (obData == null)
        {
            BuildStatusErrorResponse();
            return "false";
        }

        string selectTokenKey = $"execution_steps[{numberOfSteps - 1}].p2_content.response.data";
        JObject ob_data = new JObject();
        ob_data.Add(new JProperty(learnApiContent.LearnApiData, obData.SelectToken(selectTokenKey)));

        context.Bo.AddPackFo(name_: "data", ob_data);
        boInput[learnApiContent.LearnApiData] = obData.SelectToken(selectTokenKey);

        return "true";

    }
    /// <summary>
    /// /// 
    /// </summary>
    public void BuildStatusErrorResponse()
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        context.Bo.AddPackFo("errorJWebUI", obErr);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> changePassword()
    {
        var boInput = context?.Bo?.GetBoInput();
        boInput["learn_api"] = "O9_change_password";
        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "Change Password",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI("ncbsCbs", "Change Password", context);
        }

        if (obData != null)
        {
            var apiInfo = new ApiInfoChangePassModel()
            {
                info = "changePassOk",
                type = obData["update"].ToString().Equals("Y"),
                api_info = obData.ToDictionary()
            };
            context.Bo.AddPackFo<ApiInfoChangePassModel>("data", apiInfo);
            // logout after change password

            // if (obData["update"].ToString().Equals("Y")) {
            //     boInput["learn_api"] = "O9_delete_session";
            //     var obData2 = await _postApiService.GetDataPostAPI("ncbsCbs", "Logout", context);
            //     if (obData2 != null)
            //     {
            //         //logout session websocket
            //         var foInfo = Utils.Utils.CreateFoQuick("#sys:fo-goto-pageLogin", new JObject());
            //         await _webSocketsService.ServerSendToClient(context.InfoUser.GetUserLogin().Token, foInfo.ToSerialize());
            //         return "true";
            //     }
            // }
            BuildStatusErrorResponse();
            return "true";
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> deleteSessionO9()
    {
        await Task.CompletedTask;

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> logoutO9()
    {
        await Task.CompletedTask;

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="executeId"></param>
    /// <returns></returns>
    public async Task<JObject> getExecutionInfo(string executeId)
    {
        JObject rs = new JObject();
        await Task.CompletedTask;
        return rs;
    }


}
