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
public class TxSys
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
    private readonly IO9PostService _o9PostService;

    /// <summary>
    ///Tx
    /// </summary>

    public TxSys(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, 
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
        _postApiService = postAPIService;
        _learnApiService = learnApiService;
        _o9PostService = o9PostService;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> search()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string tableCode = "";
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new") )
        {
            JObject idInput = new JObject();
            JObject execution = new JObject();
            int pageSize = 5;
            int pageIndex = 0;
            string searchText = "";
            // JObject tableSearch = new JObject();

            if (boInput.ContainsKey("table_search"))
            {
                var tableSearch = JObject.FromObject(boInput["table_search"]);
                if (tableSearch.ContainsKey("paging"))
                {
                    var paging = JObject.FromObject(tableSearch["paging"]);
                    if (paging.ContainsKey("recordItem") && paging.ContainsKey("pagingIndex"))
                    {
                        pageSize = Int32.Parse(paging["recordItem"].ToString());
                        pageIndex = Int32.Parse(paging["pagingIndex"].ToString()) - 1;
                    }
                }
            }

            if (boInput.ContainsKey(tableCode))
            {
                if (JObject.FromObject(boInput[tableCode]).ContainsKey("search_text"))
                    searchText = JObject.FromObject(boInput[tableCode])["search_text"].ToString();
            }

            idInput.Add(new JProperty("page_size", pageSize));
            idInput.Add(new JProperty("page_index", pageIndex));
            idInput.Add(new JProperty("search_text", searchText));

            execution.Add(new JProperty("fields", idInput));
            execution.Add(new JProperty("workflowid", boInput["workflow_id"].ToString()));
            execution.Add(new JProperty("lang", context.InfoUser.GetUserLogin().Lang));
            context.Bo.GetBoInput()["execution"] = execution;

            var obData = await executeWorkflow();
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
        context.Bo.GetBoInput()["learn_api"] = "ncbsCBS_workflow_execute_new";

        JToken rs = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            rs = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "postAPI",
                context
            );
        }
        else
        {
            rs = await _postApiService.GetDataPostAPI("ncbsCbs", "executeWorkflow", context);
        }
        return rs;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> searchAdvanced()
    {
        await Task.CompletedTask;

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> view()
    {
        await Task.CompletedTask;

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> save()
    {
        await Task.CompletedTask;

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> delete()
    {
        await Task.CompletedTask;

        return "false";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> removeEvent()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["dataType"] != null && boInput["dataContent"] != null)
        {
            switch (boInput["dataType"].ToString())
            {
                case "LearnApi":
                    context.Bo.GetBoInput()["learn_api"] = boInput["dataContent"].ToString();
                    System.Console.WriteLine("dataContent===");

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
                        obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "removeEvent", context);
                    }
                    if (obData != null)
                    {
                        BuildStatusErrorResponse();
                        return "true";
                    }
                    return "false";
                default:
                    break;
            }

        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createListApi()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        foreach (var itemApi in learnApi.Split(';').Distinct().Where(s => !s.Equals("")))
        {
            context.Bo.GetBoInput()["learn_api"] = itemApi;

            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "Create",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "Create", context);
            }
            if (obData != null)
            {
                var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), itemApi);
                var tempContext = context;
                Utils.Utils.BuildStatusErrorResponse(ref tempContext);
                if (!learnApiContent.LearnApiData.Equals(""))
                {

                    if (Utils.Utils.IsValidJsonArray(obData.ToSerialize()))
                    {
                        var obDataArray = JArray.FromObject(obData);
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, Utils.Utils.BuildTableCodeForArray(obDataArray, learnApiContent.LearnApiData));
                        if (obDataArray.Count == 0) return "empty";
                    }
                    else context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);


                }
            }
            else return "false";
        }
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> create()
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
                "postAPI",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "Create", context);
        }
        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            var tempContext = context;
            Utils.Utils.BuildStatusErrorResponse(ref tempContext);
            if (!learnApiContent.LearnApiData.Equals(""))
            {

                if (Utils.Utils.IsValidJsonArray(obData.ToSerialize()))
                {
                    var obDataArray = JArray.FromObject(obData);
                    context.Bo.AddPackFo(learnApiContent.LearnApiData, Utils.Utils.BuildTableCodeForArray(obDataArray, learnApiContent.LearnApiData));
                    if (obDataArray.Count == 0) return "empty";
                }
                else context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);

                return "true";
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createDataObject()
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
                "postAPI",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "Create", context);
        }
        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            var tempContext = context;
            Utils.Utils.BuildStatusErrorResponse(ref tempContext);
            if (!learnApiContent.LearnApiData.Equals(""))
            {

                context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);

                return "true";
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> callAPI()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
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
            obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "PostApi", context);
        }

        BuildStatusErrorResponse();
        if (obData == null) return "false";

        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
        if (!learnApiContent.LearnApiData.Equals(""))
        {
            JObject obItem = new JObject();
            obItem.Add(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.LearnApiNodeData));
            context.Bo.AddPackFo(learnApiContent.LearnApiData, obItem);
            boInput[learnApiContent.LearnApiData] = obData;
        }
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    public void BuildStatusErrorResponse()
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        context.Bo.AddPackFo("errorJWebUI", obErr);
    }
}
