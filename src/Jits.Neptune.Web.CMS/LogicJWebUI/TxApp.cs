using System;
using System.Collections.Generic;
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
using LinqToDB.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Jwebui.Logic;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxApp
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
    private readonly ILearnApiService _learnApiService;
    private readonly CMSSetting _cMSSetting;
    private readonly IO9PostService _o9PostService;

    /// <summary>
    ///Tx
    /// </summary>

    public TxApp(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IFormOfRoleService formOfRoleService, IFormService formService, IPostAPIService postAPIService, CMSSetting cMSSetting, 
    ILearnApiService learnApiService,
    IO9PostService o9PostService)
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
        _learnApiService = learnApiService;
        _cMSSetting = cMSSetting;
        _o9PostService = o9PostService;
    }

    /// <summary>
    ///getDevice
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> postAPIForApp()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "GetInfo",
                context
            );
        }
        else
        {
            obData = await _postAPIService.GetDataPostAPI(context.InfoApp.GetApp(), "GetInfo", context);
        }
        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            if (learnApiContent.LearnApiData.Equals("")) context.Bo.AddPackFo("data", obData);
            else
            {
                JObject obDataRs = new JObject();
                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    //obDataRs.Add(learnApiContent.LearnApiData, obData); // by linhnq 27/4
                    var nodeData = learnApiContent.LearnApiNodeData;
                    if (string.IsNullOrEmpty(nodeData))
                    {
                       obDataRs.Add(learnApiContent.LearnApiData, obData);
                    }
                    else
                    {
                       //linhnq tam thoi fix, nghien cuu them sau
                       var keySelect = nodeData.Substring(nodeData.LastIndexOf('.') + 1);
                       if(keySelect != "data" && keySelect != "items")
                       {
                           obDataRs.Add(learnApiContent.LearnApiData, obData.SelectToken(keySelect));
                       }
                       else
                       {
                           obDataRs.Add(learnApiContent.LearnApiData, obData);
                       }
                    }
                }
                else
                {
                    obDataRs.Add(learnApiContent.LearnApiData, obData);
                }
                context.Bo.AddPackFo("data", obDataRs);
            }
            return "true";

        }
        return "false";
    }
    /// <summary>
    ///getDevice
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> searchForApp()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "executeWorkflow",
                context
            );
        }
        else
        {
            obData = await _postAPIService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "executeWorkflow", context);
        }
        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            if (!learnApiContent.LearnApiNodeData.Equals(""))
                obData = obData.SelectToken(learnApiContent.LearnApiNodeData);
            if (Utils.Utils.IsValidJsonObject(JsonConvert.SerializeObject(obData)))
            {
                if (!learnApiContent.LearnApiData.Equals(""))
                {
                    if (learnApiContent.SaveTo.Equals("client"))
                    {
                        JObject obDataRs = new JObject();
                        obDataRs.Add(learnApiContent.LearnApiData, obData);
                        context.Bo.AddPackFo("data", obDataRs);
                        //context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);
                    }
                }
            }
            else
            { //Json Array
                if (!learnApiContent.LearnApiData.Equals(""))
                {
                    if (learnApiContent.SaveTo.Equals("client"))
                    {
                        JObject obDataRs = new JObject();
                        obDataRs.Add(learnApiContent.LearnApiData, Utils.Utils.BuildTableCodeForArray(JArray.FromObject(obData), learnApiContent.LearnApiData));
                        context.Bo.AddPackFo("data", obDataRs);
                    }
                }

            }
            return "true";
        }
        return "false";
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
            JArray listApp_ = new JArray();
            foreach (var item in JArray.FromObject(_appService.GetAll().GetAwaiter().GetResult().FindAll(s => s.status.Equals("A"))))
            {
                JObject itemObj = new JObject();
                itemObj.Add(new JProperty("list_appliaction", item));
                listApp_.Add(itemObj);
            }
            context.Bo.AddPackFo("list_appliaction", listApp_);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("getListAll--Exception---" + ex.StackTrace);
            // TODO
        }
        await Task.CompletedTask;

        return "true";
    }



    /// <summary>
    ///loadAllParaServer
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loadAllParaServer()
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();

        Dictionary<string, object> paraApp = new Dictionary<string, object>();
        JArray dataParaRs = new JArray();

        var listPara = _paraServerService.GetByApp(context.InfoApp.GetApp()).GetAwaiter().GetResult();
        if (listPara.Count > 0)
        {
            foreach (var itemPara in listPara)
            {
                var itemPara_ = itemPara.ToDictionary();
                itemPara_.Remove("app");
                paraApp.Add(itemPara.Code, itemPara_);
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
                    var itemParaSys_ = itemParasys.ToDictionary();
                    itemParaSys_.Remove("app");
                    dataParaRs.Add(JObject.FromObject(itemParaSys_));
                }
            }
        }

        foreach (var item in paraApp)
        {
            dataParaRs.Add(JObject.FromObject(item.Value));
        }

        context.Bo.AddPackFo("paraServer", dataParaRs);
        await Task.CompletedTask;

        return "true";
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="screen_id"></param>
    /// <returns></returns>
    [JwebuiFunctionAttribute]
    public async Task<string> loadScreen(string screen_id)
    {
        var appInfor = _appService.GetByAppCode(context.InfoApp.GetApp()).GetAwaiter().GetResult();
        if (appInfor != null)
        {
            context.Bo.AddPackFo("loadScreen", JObject.FromObject(appInfor.ConfigTemplate));
        }
        await Task.CompletedTask;

        return "true";
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public async Task<Dictionary<string, bool>> BuildRoleCacheOfUser(int roleId, string app)
    {
        Dictionary<string, bool> result = new Dictionary<string, bool>();
        var getFormOfRole = await _formOfRoleService.GetByRoleId(roleId, app);
        foreach (var item in getFormOfRole)
        {
            result.Add(item.Form, item.AccessForm);
        }
        return result;
    }

}
