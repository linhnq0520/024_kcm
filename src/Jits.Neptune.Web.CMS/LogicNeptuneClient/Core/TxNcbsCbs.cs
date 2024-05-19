using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
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
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Services.Logging;
using LinqToDB.Common.Internal.Cache;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Jits.Neptune.Web.CMS.NcbsCbs.Core;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxNcbsCbs
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
    private readonly ICdlistService _cdlistService;
    private readonly ILearnApiService _learnApiService;
    private readonly ILogger _logger;
    private readonly IWebSocketsService _webSocketsService;
    private readonly ILocalizationService _localizationService;
    private readonly IO9PostService _o9PostService;
    private readonly ICodeListService _codeListService;
    private readonly IMemoryCache _memoryCache;
    // variables for batch
    Timer myTimer = new Timer();
    int batchRunningDays = 0;
    string dayRunningBatch = "";
    string form_code = "";
    bool isStopBatch = false;

    /// <summary>
    ///Tx
    /// </summary>

    public TxNcbsCbs(ILocalizationService localizationService, IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, ICdlistService cdlistService, ILearnApiService learnApiService, ILogger logger, 
    IWebSocketsService webSocketsService,
    IO9PostService o9PostService,
    ICodeListService codeListService,
    IMemoryCache memoryCache)
    {
        _localizationService = localizationService;
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _postApiService = postAPIService;
        _cdlistService = cdlistService;
        _learnApiService = learnApiService;
        _logger = logger;
        _webSocketsService = webSocketsService;
        _o9PostService = o9PostService;
        _codeListService = codeListService;
        _memoryCache = memoryCache;
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

        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new"))
        {
            Dictionary<string, object> idInput = new Dictionary<string, object>();
            WorkflowExecuteModel execution = new WorkflowExecuteModel();
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

            idInput.Add("page_index", pageIndex);
            idInput.Add("page_size", pageSize);
            idInput.Add("search_text", searchText);

            execution.fields = idInput;
            execution.workflowid = boInput["workflow_id"].ToString();
            execution.lang = context.InfoUser.GetUserLogin().Lang;
            execution.reference_id = System.Guid.NewGuid().ToString();
            context.Bo.GetBoInput()["execution"] = execution.ToJToken();

            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obData = await executeWorkflow();
            }

            // System.Console.WriteLine("obData===" + obData.ToSerialize());
            if (obData != null)
            {
                var item = obData.SelectToken("items").ToList<object>();
                var obDataModel = new PageSearchModel()
                {
                    Items = obData.SelectToken("items").ToList<object>(),
                    TotalCount = Int32.Parse(obData.SelectToken("total_count").ToString()),
                    TotalPages = Int32.Parse(obData.SelectToken("total_pages").ToString())
                };

                if (obDataModel == null)
                {
                    JObject obErr = new JObject();
                    obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                    context.Bo.AddPackFo("errorJWebUI", obErr);
                    return "false";
                }
                context.Bo.AddPackFo(tableCode, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), tableCode));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "false",
                    total_items = obDataModel.TotalCount
                };

                context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);


                if (obDataModel.TotalCount == 0) return "empty";

                return "true";
            }
            else
            {
                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);
                return "false";
            }



        }
        else
        {
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
            // System.Console.WriteLine("searchAPI==" + boInput.ToSerialize());
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "search", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
            // System.Console.WriteLine("obDatasearchAPI==" + obData.ToSerialize());

            var obDataModel = obData.ToPageSearchModel();

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
            if (!learnApiContent.LearnApiData.Equals(""))
            {
                context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "false",
                    total_items = obDataModel.TotalCount
                };
                if (boInput["key_table_paging"] != null) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
                else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
                // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);

                if (obDataModel.TotalCount == 0) return "empty";
                return "true";
            }



        }
        return "false";
    }
    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getDataArray()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();

        string learnApi = "";
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();


        context.Bo.GetBoInput()["learn_api"] = learnApi;


        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "search", context);

        }
        // System.Console.WriteLine("searchAPI==" + boInput.ToSerialize());

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }
        // System.Console.WriteLine("obDatasearchAPI==" + obData.ToSerialize());

        var obDataModel = obData.ToPageSearchModel();

        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
        if (!learnApiContent.LearnApiData.Equals(""))
        {
            context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

            var searchResponseCMS = new SearchResponseCMSModel()
            {
                search_advanced = "false",
                total_items = obDataModel.TotalCount
            };
            if ((boInput["key_table_paging"] != null)) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
            else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
            // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
            if (boInput.ContainsKey("component_result"))
                context.Bo.GetActionInput().Add("component_result", boInput["component_result"].ToString());
            //JObject obErr_ = new JObject();
            // obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            // context.Bo.AddPackFo("errorJWebUI", obErr_);

            // if (obDataModel.TotalCount == 0) return "empty";
            return "true";
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> searchAdvanced()
    {


        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string tableCode = "";
        // Console.WriteLine("=====boInput======" + JsonConvert.SerializeObject(boInput));
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new"))
        {
            Dictionary<string, object> idInput = new Dictionary<string, object>();
            WorkflowExecuteModel execution = new WorkflowExecuteModel();
            int pageSize = 5;
            int pageIndex = 0;


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
            //anc.asd
            if (boInput.SelectToken(tableCode) != null && boInput.SelectToken(tableCode).Type != JTokenType.Null)
            {

                var tableCodeSearch = JObject.FromObject(boInput).SelectToken(tableCode).ToObject<JObject>();


                if (tableCodeSearch.ContainsKey("learn_api_mapping"))
                {

                    var learnApiMapping = tableCodeSearch["learn_api_mapping"].ToString();

                    if (boInput.ContainsKey("table_code_replace"))
                    {
                        learnApiMapping = learnApiMapping.Replace(boInput["table_code_replace"].ToString(), tableCode);
                    }


                    idInput = (await _postApiService.TxMapDataBody(learnApiMapping, boInput, context.InfoApp.GetApp())).ToDictionary();

                }
                else
                {
                    foreach (var (key, value) in tableCodeSearch.ToDictionary())
                    {
                        idInput[key] = value;
                    }
                }
            }
            idInput.Add("page_index", pageIndex);
            idInput.Add("page_size", pageSize);

            execution.fields = idInput;
            execution.workflowid = boInput["workflow_id"].ToString();
            execution.lang = context.InfoUser.GetUserLogin().Lang;
            execution.reference_id = System.Guid.NewGuid().ToString();
            context.Bo.GetBoInput()["execution"] = JToken.FromObject(execution);

            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "searchAd",
                    context
                );
            }
            else{
                obData = await executeWorkflow();
            }
            
            if (obData != null)
            {
                var obDataModel = obData.ToPageSearchModel();

                if (boInput.ContainsKey("api_map_code"))
                    tableCode = boInput["api_map_code"].ToString();
                if (obDataModel == null)
                {
                    JObject obErr = new JObject();
                    obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                    context.Bo.AddPackFo("errorJWebUI", obErr);
                    return "false";
                }
                context.Bo.AddPackFo(tableCode, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), tableCode));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "true",
                    total_items = obDataModel.TotalCount
                };

                context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);

                if (obDataModel.TotalCount == 0) return "empty";

                return "true";
            }
            else
            {
                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);
                return "false";
            }
        }
        else
        {
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "searchAd",
                    context
                );
            }
            else
            {

                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "searchAd", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }

            var obDataModel = obData.ToPageSearchModel();

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
            if (!learnApiContent.LearnApiData.Equals(""))
            {
                context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "true",
                    total_items = obDataModel.TotalCount
                };
                if ((boInput["key_table_paging"] != null)) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
                else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
                // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);

                if (obDataModel.TotalCount == 0) return "empty";
                return "true";
            }



        }
        return "false";
    }
    /// <summary>
    /// 
    /// /// </summary>
    /// <returns></returns>
    public async Task<string> searchAdvancedMulti()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        String[] listLearnApi = new String[] { };
        string tableCode = "";
        // Console.WriteLine("=====boInput======" + JsonConvert.SerializeObject(boInput));
        if (boInput.ContainsKey("learn_api"))
            listLearnApi = boInput.GetValue("learn_api").ToString().Split(";");
        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();
        for (int i = 0; i < listLearnApi.Length; i++)
        {
            string learnApi = listLearnApi[i];
            context.Bo.GetBoInput()["learn_api"] = learnApi;
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "searchAd", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }

            var obDataModel = obData.ToPageSearchModel();

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
            if (!learnApiContent.LearnApiData.Equals(""))
            {
                context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));
                // JObject obErr_ = new JObject();
                // obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                // context.Bo.AddPackFo("errorJWebUI", obErr_);
            }
        }



        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> view()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string formSearchKey = "";
        WorkflowExecuteModel execution = new WorkflowExecuteModel();
        Dictionary<string, object> idInput = new Dictionary<string, object>();

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("form_search_key"))
            formSearchKey = boInput.GetValue("form_search_key").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;
        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new"))
        {
            if (boInput.ContainsKey(formSearchKey))
            {
                if (boInput.ContainsKey("view_id"))
                {
                    var tableCodeSearch = boInput[formSearchKey];
                    foreach (var (key, value) in tableCodeSearch.ToDictionary())
                    {

                        if (key.Equals(boInput["view_id"].ToString())) idInput[key] = value;
                    }
                }
            }

            execution.fields = idInput;
            execution.workflowid = boInput["workflow_id"].ToString();
            execution.lang = context.InfoUser.GetUserLogin().Lang;
            execution.reference_id = System.Guid.NewGuid().ToString();
            context.Bo.GetBoInput()["execution"] = JToken.FromObject(execution);

            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "searchAd",
                    context
                );
            }
            else{
                obData = await executeWorkflow();
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }

            if (boInput.ContainsKey("form_key"))
                context.Bo.GetActionInput().Add("form_key", boInput["form_key"].ToString());

            if (boInput.ContainsKey("table_code"))
                context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());


            JObject obItem = new JObject();
            obItem.Add(boInput["table_code"].ToString(), obData);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);

            return "true";
        }
        else
        {
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "searchAd",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "searchAd", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }

            if (boInput.ContainsKey("form_key"))
                context.Bo.GetActionInput().Add("form_key", boInput["form_key"].ToString());

            if (boInput.ContainsKey("table_code"))
                context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());
            if (boInput.ContainsKey("is_reversed"))
                context.Bo.GetActionInput().Add("is_reversed", boInput["is_reversed"].ToString());

            JObject obItem = new JObject();
            obItem.Add(boInput["table_code"].ToString(), obData);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);

            return "true";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> viewTableDetailImportFile()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";


        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "searchAd", context);
        }

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("form_key"))
            context.Bo.GetActionInput().Add("form_key", boInput["form_key"].ToString());

        if (boInput.ContainsKey("table_code"))
            context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());


        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
        if (!learnApiContent.LearnApiData.Equals(""))
        {
            var data = BuildTableCodeForArray(JArray.FromObject(obData), learnApiContent.LearnApiData);
            JObject obItem = new JObject();
            obItem.Add(boInput["table_code"].ToString(), data);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);
        }
        else
        {
            JObject obItem = new JObject();
            obItem.Add(boInput["table_code"].ToString(), obData);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);
        }


        return "true";

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> viewImportFile()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";


        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "searchAd", context);
        }
        if (obData == null || obData.Type == JTokenType.Null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("form_key"))
            context.Bo.GetActionInput().Add("form_key", boInput["form_key"].ToString());

        if (boInput.ContainsKey("table_code"))
            context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());


        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
        if (!learnApiContent.LearnApiData.Equals(""))
        {
            var data = BuildTableCodeForArray(JArray.FromObject(obData), learnApiContent.LearnApiData);
            JObject obItem = new JObject();
            obItem.Add(boInput["table_code"].ToString(), data);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);
        }
        else
        {
            JObject obItem = new JObject();
            //obItem.Add(boInput["table_code"].ToString(), obData);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obData);
        }


        return "true";

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> viewMasterFile()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";


        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;
        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPIUploadMasterFile(context.InfoApp.GetApp(), "searchAd", context);
        }
        if (obData == null || obData.Type == JTokenType.Null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("form_key"))
            context.Bo.GetActionInput().Add("form_key", boInput["form_key"].ToString());

        if (boInput.ContainsKey("table_code"))
            context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());


        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
        if (!learnApiContent.LearnApiData.Equals(""))
        {
            var data = BuildTableCodeForArray(JArray.FromObject(obData), learnApiContent.LearnApiData);
            JObject obItem = new JObject();
            obItem.Add(boInput["table_code"].ToString(), data);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);
        }
        else
        {
            JObject obItem = new JObject();
            //obItem.Add(boInput["table_code"].ToString(), obData);

            context.Bo.AddPackFo(boInput["table_code"].ToString(), obData);
        }


        return "true";

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> confirmDelete()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string formSearchKey = "";
        string deleteId = "id";
        WorkflowExecuteModel execution = new WorkflowExecuteModel();
        Dictionary<string, object> idInput = new Dictionary<string, object>();

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new"))
        {
            if (boInput.ContainsKey("form_search_key"))
                formSearchKey = boInput.GetValue("form_search_key").ToString();


            if (boInput.ContainsKey("delete_id"))
                deleteId = boInput.GetValue("delete_id").ToString();

            if (boInput.ContainsKey(formSearchKey))
            {

                var tableCodeSearch = boInput[formSearchKey];
                foreach (var (key, value) in tableCodeSearch.ToDictionary())
                {
                    if (key.Equals(deleteId)) idInput[key] = value;
                }

            }
            execution.fields = idInput;
            execution.workflowid = boInput["workflow_id"].ToString();
            execution.lang = context.InfoUser.GetUserLogin().Lang;
            execution.reference_id = System.Guid.NewGuid().ToString();
            context.Bo.GetBoInput()["execution"] = JToken.FromObject(execution);
            context.Bo.GetBoInput()["learn_api"] = learnApi;
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "confirmDelete",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirmDelete", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }


            if (boInput.ContainsKey("learn_api"))
                context.Bo.GetActionInput().Add("learn_api", boInput["learn_api"].ToString());

            if (boInput.ContainsKey("workflow_id_search"))
                context.Bo.GetActionInput().Add("workflow_id", boInput["workflow_id_search"].ToString());


            if (boInput.ContainsKey("form_search_key"))
                context.Bo.GetActionInput().Add("table_code", boInput["form_search_key"].ToString());

            if (boInput.ContainsKey("lang_confirm"))
                context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

            return "true";
        }
        else
        {
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "confirmDelete",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirmDelete", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }

            if (boInput.ContainsKey("lang_confirm"))
                context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

            if (boInput.ContainsKey("learn_api_search"))
                context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());


            return "true";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> confirmDeleteUserProfile()
    {
        var boInput = context.Bo.GetBoInput();
        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "confirmDelete",
                context
            );
        }
        else
        {    
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirmDelete", context);
        }

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("lang_confirm"))
            context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

        if (boInput.ContainsKey("learn_api_search"))
            context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> callListApi()
    {
        var boInput = context.Bo.GetBoInput();

        var listLearnApi = boInput["learn_api"].ToString().Split(";");
        foreach (var itemLearnApi in listLearnApi)
        {
            var item = itemLearnApi.Trim();

            if (!item.Equals(""))
            {
                boInput["learn_api"] = item;
                JToken obData = null;
                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                {
                    obData = await _o9PostService.GetDataPostAPI(
                        "ncbsCbs",
                        "search",
                        context
                    );
                }
                else
                {
                    obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "" +
                    "callListApi" +
                    "", context);
                }

                if (obData == null)
                {
                    JObject obErr = new JObject();
                    obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                    context.Bo.AddPackFo("errorJWebUI", obErr);
                    return "false";
                }

                foreach (var itemData in obData.ToJObject())
                {
                    boInput[itemData.Key] = itemData.Value;
                }
            }
        }
        if (boInput.ContainsKey("lang_confirm"))
            context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

        if (boInput.ContainsKey("learn_api_search"))
            context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());
        if (boInput.ContainsKey("learn_api_search_advanced"))
            context.Bo.GetActionInput().Add("learn_api_search_advanced", boInput["learn_api_search_advanced"].ToString());
          if (boInput.ContainsKey("component_code_parent"))
            context.Bo.GetActionInput().Add("component_code_parent", boInput["component_code_parent"].ToString());
          if (boInput.ContainsKey("node_get"))
            context.Bo.GetActionInput().Add("node_get", boInput["node_get"].ToString());
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> searchCondition()
    {
        var boInput = context.Bo.GetBoInput();

        var learn_api = boInput["learn_api"].ToString();
        
        var isSearchAdvanced=false;
        if (boInput.ContainsKey("table_search"))
        {
            var tableSearch = JObject.FromObject(boInput["table_search"]);
            if (tableSearch.ContainsKey("paging"))
            {
                var paging = JObject.FromObject(tableSearch["paging"]);
                if (paging.ContainsKey("isSearchAdvanced"))
                {
                    isSearchAdvanced = Boolean.Parse(paging["isSearchAdvanced"].ToString());
                }
            }
        }
        if(isSearchAdvanced){
            learn_api=boInput["learn_api_search_advanced"].ToString();
            boInput["learn_api"] = learn_api;
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "searchAd", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }

            var obDataModel = obData.ToPageSearchModel();

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
            if (!learnApiContent.LearnApiData.Equals(""))
            {
                context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "true",
                    total_items = obDataModel.TotalCount
                };
                if ((boInput["key_table_paging"] != null)) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
                else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
                // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);

                if (obDataModel.TotalCount == 0) return "empty";
                return "true";
            }
        } 
        else {
            boInput["learn_api"] = learn_api;
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "search", context);
            }

            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
            // System.Console.WriteLine("obDatasearchAPI==" + obData.ToSerialize());

            var obDataModel = obData.ToPageSearchModel();

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
            if (!learnApiContent.LearnApiData.Equals(""))
            {
                context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "false",
                    total_items = obDataModel.TotalCount
                };
                if ((boInput["key_table_paging"] != null)) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
                else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
                // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);

                if (obDataModel.TotalCount == 0) return "empty";
                return "true";
            }
        }
        return "true";
    }
    /// <summary>
    /// searchSys
    /// </summary>
    /// <returns></returns>
    public async Task<string> searchSys()
    {
        var boInput = context.Bo.GetBoInput();
        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirmDelete", context);
        }

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        var obDataModel = obData.ToPageSearchModel();

        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
        if (!learnApiContent.LearnApiData.Equals(""))
        {
            context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

            var searchResponseCMS = new SearchResponseCMSModel()
            {
                search_advanced = "false",
                total_items = obDataModel.TotalCount
            };
            if ((boInput["key_table_paging"] != null)) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
            else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
            // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

            JObject obErr_ = new JObject();
            obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr_);

            if (obDataModel.TotalCount == 0) return "empty";
            return "true";
        }
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> create()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        string tableCode = "";
        Dictionary<string, object> idInput = new Dictionary<string, object>();
        WorkflowExecuteModel execution = new WorkflowExecuteModel();

        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        if (boInput.ContainsKey(tableCode))
        {

            var tableCodeSearch = JObject.FromObject(boInput).SelectToken(tableCode).ToObject<JObject>();

            if (tableCodeSearch.ContainsKey("learn_api_mapping"))
            {

                var learnApiMapping = tableCodeSearch["learn_api_mapping"].ToString();

                if (boInput.ContainsKey("table_code_replace"))
                {
                    learnApiMapping = learnApiMapping.Replace(boInput["table_code_replace"].ToString(), tableCode);
                }


                idInput = (await _postApiService.TxMapDataBody(learnApiMapping, boInput, context.InfoApp.GetApp())).ToDictionary();

            }
            else
            {
                foreach (var (key, value) in tableCodeSearch.ToDictionary())
                {
                    idInput[key] = value;
                }
            }
        }

        execution.fields = idInput;
        execution.workflowid = boInput["workflow_id"].ToString();
        execution.lang = context.InfoUser.GetUserLogin().Lang;
        execution.reference_id = System.Guid.NewGuid().ToString();
        boInput["execution"] = JToken.FromObject(execution);

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await executeWorkflow();
        }
        
        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }
        JObject obResult = new JObject();

        JObject obErr_ = new JObject();
        obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        obResult.Add("errorJWebUI", obErr_);

        obResult.Add(tableCode, obData);
        context.Bo.AddPackFo(tableCode, obResult);

        boInput[tableCode] = obData;

        if (!string.IsNullOrEmpty(boInput["learn_api"]?.ToString())) context.Bo.GetActionInput()["learn_api"] = boInput["learn_api"].ToString();

        if (!string.IsNullOrEmpty(boInput["workflow_id_search"]?.ToString())) context.Bo.GetActionInput()["workflow_id"] = boInput["workflow_id_search"].ToString();
        if (!string.IsNullOrEmpty(boInput["table_code"]?.ToString())) context.Bo.GetActionInput()["table_code"] = boInput["table_code"].ToString();



        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createFO()
    {

        var boInput = context?.Bo?.GetBoInput();
        var bo_input_old = context.Bo.GetBoInput().DeepClone();
        string learn_api = "";
        string table_code = "";
        if (boInput.ContainsKey("learn_api"))
            learn_api = boInput.GetValue("learn_api").ToString();

        if (boInput.ContainsKey("table_code"))
            table_code = boInput.GetValue("table_code").ToString();

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "create",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), actionName: "create", context);
        }
        if (obData == null)
        {
            string error_approve = "OverLimit;ApprovalRequired";
            var list_error = context.Bo.GetActionErrors();
            for (int i = 0; i < list_error.Count; i++)
            {
                var error_item = list_error[i];
                string key_err_api = error_item.info;
                string[] error_keys = error_approve.Split(";");
                for (var index_key = 0; index_key < error_keys.Length; index_key++)
                {
                    var error_key = error_keys[index_key];
                    if (key_err_api.IndexOf(error_key) > -1)
                    {
                        error_item.info = key_err_api.Replace(error_key, await _localizationService.GetResource("CMS.String." + error_key, context.InfoUser.GetUserLogin().Lang));
                        list_error[i] = error_item;

                        JObject fo_info = new JObject();
                        fo_info["isOpen"] = true;
                        if (context.Bo.GetBoInput().ContainsKey("fo_execution_id"))
                            fo_info["fo_ref_id"] = context.Bo.GetBoInput().GetValue("fo_execution_id");
                        context.Bo.AddPackFo("JWEBUI_O9_approve", fo_info);
                        // JsonObject
                        context.Bo.GetActionInput()["learn_api"] = context.Bo.GetBoInput().GetValue("learn_api");
                        // context.Bo.setActionErrorAll(list_error);
                        break;

                    }
                }
            }



            context.Bo.GetActionInput()["user_approve"] = new JObject();
            // Clear user id đã đăng nhập để lần sau hiện modal ko tự điền
            // JObject obErr = new JObject();
            // obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            // context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }
        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput[propertyName: "learn_api"].ToString());



        if (learnApiContent.LearnApiData != "")
        {

            if (obData.SelectToken("fee_data") != null)
            {
                try
                {
                    obData["fee_data"] = bo_input_old.SelectToken(learnApiContent.LearnApiData).SelectToken("fee_data");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("exception fee===" + e.StackTrace);
                }

            }
            JObject ob_item = new JObject();
            if (!string.IsNullOrEmpty( learnApiContent.LearnApiNodeData))
            {

                ob_item[learnApiContent.LearnApiData] = obData.SelectToken(learnApiContent.LearnApiNodeData);
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                ob_item["errorJWebUI"] = obErr;

                context.Bo.AddPackFo(learnApiContent.LearnApiData, ob_item);
                context.Bo.AddPackFo(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.LearnApiNodeData));
            }
            else
            {
                // no note data
                // get all struct json

                ob_item[learnApiContent.LearnApiData] = obData;

                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                ob_item["errorJWebUI"] = obErr;

                context.Bo.AddPackFo(learnApiContent.LearnApiData, ob_item);
            }
        }
        else
        {
            JObject ob_item = new JObject();
            ob_item[table_code] = obData;

            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            ob_item["errorJWebUI"] = obErr;
            context.Bo.AddPackFo(table_code, ob_item);
            context.Bo.AddPackFo(table_code, obData);
        }
        //call api 2
        try
        {
            string learnApi2 = boInput["learn_api"].ToString().Split(";")[1];
            context.Bo.GetBoInput()["learn_api"] = learnApi2;
            JToken obDataApprove = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obDataApprove = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "create",
                    context
                );
            }
            else
            {
                obDataApprove = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "create", context);
            }

            if (obDataApprove == null)
            {

                return "approve_faild";
            }
        }
        catch { }


        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> uploadMasterFile()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        JToken obDataUpload = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obDataUpload = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obDataUpload = await _postApiService.GetDataPostAPIUploadMasterFile(context.InfoApp.GetApp(), "Create", context);
        }

        if (obDataUpload != null)
        {
            // var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            // var tempContext = context;
            // // Utils.Utils.BuildStatusErrorResponse(ref tempContext);
            // // if (!learnApiContent.LearnApiData.Equals(""))
            // // {

            // //     context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);

            // //     return "true";
            // // }
            // if (obData.SelectToken("data_body") != null)
            // {
            //     context.Bo.AddPackFo("data_body", obData.SelectToken("data_body"));
            // }
            // if (obData.SelectToken("data_header") != null)
            // {
            //     context.Bo.AddPackFo("data_header", obData.SelectToken("data_header"));
            // }
            context.Bo.GetBoInput()["learn_api"] = boInput.GetValue("learn_api_search").ToString(); ;
            JToken obData = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obData = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "search", context);
            }
            if (obData == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
            // System.Console.WriteLine("obDatasearchAPI==" + obData.ToSerialize());

            var obDataModel = obData.ToPageSearchModel();

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput["learn_api"].ToString());
            if (!learnApiContent.LearnApiData.Equals(""))
            {
                context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), learnApiContent.LearnApiData));

                var searchResponseCMS = new SearchResponseCMSModel()
                {
                    search_advanced = "false",
                    total_items = obDataModel.TotalCount
                };
                if ((boInput["key_table_paging"] != null)) context.Bo.AddPackFo<SearchResponseCMSModel>(boInput["key_table_paging"].ToString(), searchResponseCMS);
                else context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);
                // context.Bo.AddPackFo<SearchResponseCMSModel>("table_paging", searchResponseCMS);

                JObject obErr_ = new JObject();
                obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr_);

                return "true";
            }
            return "true";
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> checkLoginApprove_printF8()
    {
        var boInput = context?.Bo?.GetBoInput();

        context.Bo.GetBoInput()["learn_api"] = "UMG_LOGIN_APPROVE_F8";
        JToken apiResult = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            apiResult = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "CheckLoginApprove",
                context
            );
        }
        else
        {
            apiResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "CheckLoginApprove", context);
        }

        if (apiResult != null)
        {
            if (context.Bo.GetBoInput().ContainsKey("login"))
            {
                context.Bo.GetActionInput()["login"] = boInput["login"];
            }

            return "true";
        }
        else
        {
            return "false";
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createApproveLater()
    {
        var boInput = context?.Bo?.GetBoInput();
        // Console.WriteLine("==createApproveLater===" + JsonConvert.SerializeObject(boInput));
        string learn_api = "";
        if (boInput.ContainsKey("learn_api"))
            learn_api = boInput.GetValue("learn_api").ToString();


        boInput["learn_api"] = "FOF_APPROVE_LATER";

        JToken apiResult = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            apiResult = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            apiResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "ApproveLater", context);
        }

        if (apiResult != null)
        {
            // Console.WriteLine("==apiResult===" + JsonConvert.SerializeObject(apiResult));
            //  Console.WriteLine("==learn_api===" + learn_api);
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learn_api);
            JObject ob_item = new JObject();
            ob_item[learnApiContent.LearnApiData] = apiResult;

            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            ob_item["errorJWebUI"] = obErr;

            context.Bo.AddPackFo(learnApiContent.LearnApiData, ob_item);
            return "true";

        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createAPIApprove()
    {

        var boInput = context?.Bo?.GetBoInput();
        string learn_api = "";
        string table_code = "";
        if (boInput.ContainsKey("learn_api"))
            learn_api = boInput.GetValue("learn_api").ToString();

        if (boInput.ContainsKey("table_code"))
            table_code = boInput.GetValue("table_code").ToString();


        var bo_input_old = context.Bo.GetBoInput().DeepClone();
        if (bo_input_old.SelectToken("user") != null)
        {
            context.Bo.GetBoInput()["learn_api"] = "UMG_LOGIN_APPROVE";
            JToken apiResult = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                apiResult = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                apiResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "CheckLoginApprove", context);
            }

            if (apiResult != null)
            {
                context.Bo.GetActionInput()["user_approve"] = boInput["user"];
                context.Bo.GetBoInput()["user_approve"] = boInput["user"];

                context.Bo.GetBoInput()["static_token"] = apiResult["static_token"].ToString();
                context.Bo.GetActionInput()["static_token"] = apiResult["static_token"].ToString();
            }
            else
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
        }

        context.Bo.GetBoInput()["learn_api"] = learn_api.Split(";")[0];
        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "create",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), actionName: "create", context);
        }
        Console.WriteLine("=====obData======" + JsonConvert.SerializeObject(obData));
        if (obData == null)
        {
            string error_approve = "OverLimit;ApprovalRequired";
            var list_error = context.Bo.GetActionErrors();
            for (int i = 0; i < list_error.Count; i++)
            {
                var error_item = list_error[i];
                string key_err_api = error_item.info;
                string[] error_keys = error_approve.Split(";");
                for (var index_key = 0; index_key < error_keys.Length; index_key++)
                {
                    var error_key = error_keys[index_key];
                    if (key_err_api.IndexOf(error_key) > -1)
                    {
                        error_item.info = key_err_api.Replace(error_key, await _localizationService.GetResource("CMS.String." + error_key, context.InfoUser.GetUserLogin().Lang));
                        list_error[i] = error_item;

                        JObject fo_info = new JObject();
                        fo_info["isOpen"] = true;
                        if (context.Bo.GetBoInput().ContainsKey("fo_execution_id"))
                            fo_info["fo_ref_id"] = context.Bo.GetBoInput().GetValue("fo_execution_id");
                        context.Bo.AddPackFo("JWEBUI_O9_approve", fo_info);
                        // JsonObject
                        context.Bo.GetActionInput()["learn_api"] = context.Bo.GetBoInput().GetValue("learn_api");
                        // context.Bo.setActionErrorAll(list_error);
                        break;

                    }
                }
            }

            context.Bo.GetActionInput()["user_approve"] = new JObject();
            // Clear user id đã đăng nhập để lần sau hiện modal ko tự điền
            // JObject obErr = new JObject();
            // obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            // context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }
        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), boInput[propertyName: "learn_api"].ToString());


        if (learnApiContent.LearnApiData != "")
        {

            if (obData["fee_data"] != null)
            {
                try
                {
                    obData["fee_data"] = bo_input_old.SelectToken(learnApiContent.LearnApiData).SelectToken("fee_data");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("exception fee data====" + e.StackTrace);
                }

            }
            JObject ob_item = new JObject();
            if (learnApiContent.LearnApiNodeData != "")
            {

                ob_item[learnApiContent.LearnApiData] = obData.SelectToken(learnApiContent.LearnApiNodeData);
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);

                context.Bo.AddPackFo(learnApiContent.LearnApiData, ob_item);
                context.Bo.AddPackFo(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.LearnApiNodeData));
            }
            else
            {
                // no note data
                // get all struct json

                ob_item[learnApiContent.LearnApiData] = obData;

                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);

                context.Bo.AddPackFo(learnApiContent.LearnApiData, ob_item);
            }
        }
        else
        {
            JObject ob_item = new JObject();
            ob_item[table_code] = obData;

            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            // ob_item["errorJWebUI"] = obErr;
            context.Bo.AddPackFo(table_code, ob_item);
            context.Bo.AddPackFo("errorJWebUI", obErr);
        }
        //call api 2
        try
        {
            string learnApi2 = boInput["learn_api"].ToString().Split(";")[1];
            context.Bo.GetBoInput()["learn_api"] = learnApi2;
            JToken obDataApprove = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                obDataApprove = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                obDataApprove = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "create", context);
            }

            if (obDataApprove == null)
            {

                return "approve_faild";
            }
        }
        catch { }


        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> checkSanction()
    {
        await Task.CompletedTask;

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> checkValidateFO()
    {
        var boInput = context?.Bo?.GetBoInput();
        // Console.WriteLine("==createApproveLater===" + JsonConvert.SerializeObject(boInput));
        string learn_api_validate = "";
        string learn_api = "";
        string table_code = "";
        if (boInput.ContainsKey("check_validate_api"))
            learn_api_validate = boInput.GetValue("check_validate_api").ToString();
        if (boInput.ContainsKey("learn_api"))
            learn_api = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("table_code"))
            table_code = boInput.GetValue("table_code").ToString();

        boInput["learn_api"] = learn_api_validate;

        JToken apiResult = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            apiResult = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "ApproveLater",
                context
            );
        }
        else
        {
            apiResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "ApproveLater", context);
        }

        if (apiResult == null || apiResult.Type == JTokenType.Null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }
        else
        {
            context.Bo.GetActionInput().Add("learn_api", learn_api);
            if (boInput.ContainsKey("table_code"))
                context.Bo.GetActionInput().Add("table_code", table_code);
            if (boInput.ContainsKey(table_code))
                context.Bo.GetActionInput().Add(table_code, boInput.SelectToken(table_code));

            return "true";
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> autoFeeGetIFCFromAPI()
    {
        try
        {
            JToken ob_data = null;
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                ob_data = await _o9PostService.GetDataPostAPI(
                    "ncbsCbs",
                    "search",
                    context
                );
            }
            else
            {
                ob_data = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), actionName: "create", context);
            }
            if (ob_data == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
            JArray data = new JArray();
            string API_NODE_DATA = "data";
            string API_NODE_DATA_CONVERT = "data";
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), context.Bo.GetBoInput()["learn_api"].ToString());


            API_NODE_DATA = learnApiContent.LearnApiNodeData;



            API_NODE_DATA_CONVERT = learnApiContent.LearnApiData;

            context.Bo.AddPackFo(API_NODE_DATA_CONVERT, ob_data);
            return "true";



        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.StackTrace);
            // TODO: handle exception
        }

        return "false";

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> reviewImportFile()
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
                "search",
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
            // Utils.Utils.BuildStatusErrorResponse(ref tempContext);
            // if (!learnApiContent.LearnApiData.Equals(""))
            // {

            //     context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);

            //     return "true";
            // }
            if (obData.SelectToken("data_body") != null)
            {
                context.Bo.AddPackFo("data_body", obData.SelectToken("data_body"));
            }
            if (obData.SelectToken("data_header") != null)
            {
                context.Bo.AddPackFo("data_header", obData.SelectToken("data_header"));
            }
            return "true";
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> loadDataMasterFile()
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
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPIUploadMasterFile(context.InfoApp.GetApp(), "Create", context);
        }
        if (obData != null)
        {
            // var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            // var tempContext = context;
            // Utils.Utils.BuildStatusErrorResponse(ref tempContext);
            // if (!learnApiContent.LearnApiData.Equals(""))
            // {

            //     context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);

            //     return "true";
            // }
            // if (obData.SelectToken("data_body") != null)
            // {
            //     context.Bo.AddPackFo("data_body", obData.SelectToken("data_body"));
            // }
            // if (obData.SelectToken("data_header") != null)
            // {
            //     context.Bo.AddPackFo("data_header", obData.SelectToken("data_header"));
            // }
            context.Bo.AddPackFo("data_api", obData);
            return "true";
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> feeCCL()
    {
        JArray fees_data = new JArray();
        var boInput = context?.Bo?.GetBoInput();
        string key_form = "";
        if (boInput.ContainsKey("key_form"))
            key_form = boInput.GetValue("key_form").ToString();

        try
        {
            if (boInput.ContainsKey(key_form))
            {
                var form_data = boInput.GetValue(key_form);

                fees_data = form_data.SelectToken("fee_data").ToJArray();

                try
                {
                    for (int i = 0; i < fees_data.Count; i++)
                    {
                        var fee = fees_data[i].SelectToken(path: "fee_data");
                        var currency1 = fee.SelectToken("rule_ccl_0").ToString();
                        var currency2 = fee.SelectToken("rule_ccl_1")?.ToString();
                        context.Bo.GetBoInput()["rule_ccl_0"] = currency1;
                        context.Bo.GetBoInput()["rule_ccl_1"] = currency2;

                        // Add cross_rate
                        context.Bo.GetBoInput()["learn_api"] = "GET_api_bank_cross_rate";

                        JToken obData = null;
                        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                        {
                            obData = await O9Utils.GetCrossRate(currency1, currency2);
                        }
                        else
                        {
                            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), actionName: "create", context);
                        }

                        if (obData == null)
                        {
                            JObject obErr = new()
                            {
                                new JProperty("count", context.Bo.GetActionErrors().Count)
                            };
                            context.Bo.AddPackFo("errorJWebUI", obErr);
                            return "false";
                        }
                        fee["crossrate"] = obData.SelectToken("cross_rate");

                        // Add base rate
                        var fee_currency = context.Bo.GetBoInput()["rule_ccl_1"];
                        decimal baserate = 0;
                        if (fee_currency != null)
                        {
                            if (fee_currency.ToString().HasValue())
                            {
                                context.Bo.GetBoInput()["learn_api"] = "GET_api_bank_base_rate";

                                JToken obData_base = null;
                                if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                                {
                                    obData_base = await O9Utils.GetBaseRate(currency2);
                                }
                                else
                                {
                                    obData_base = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), actionName: "create", context);
                                }

                                if (obData_base == null)
                                {
                                    JObject obErr = new()
                                    {
                                        new JProperty("count", context.Bo.GetActionErrors().Count)
                                    };
                                    context.Bo.AddPackFo("errorJWebUI", obErr);
                                    return "false";
                                }
                                decimal.TryParse(obData_base.SelectToken("bk_rate_currency").ToString(), out baserate);
                            }
                        }
                        fee["baserate"] = baserate;

                    }
                    form_data["fee_data"] = fees_data;
                    //Console.WriteLine("-===form_data=" +JsonConvert.SerializeObject(form_data));
                    context.Bo.AddPackFo(name_: "data", context.Bo.GetBoInput());
                    Console.WriteLine("-===context.Bo=" + JsonConvert.SerializeObject(context.Bo.GetBoInput()));
                    return "true";
                    //context.BO.addPackFo("data", this.context.BO.getBO_input());

                }
                catch (Exception e)
                {
                    Console.WriteLine("===========Lỗi======" + e.StackTrace);
                }
            }
        }
        catch (Exception e)
        {
            await Console.Out.WriteLineAsync(e.StackTrace);
        }


        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> callApiSaveCdlist()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        string tableCode = "c_cdlist";
        Dictionary<string, object> idInput = new Dictionary<string, object>();
        WorkflowExecuteModel execution = new WorkflowExecuteModel();

        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        if (boInput.SelectToken(tableCode + ".cdgrp").ToString().Equals("JWEBUI")) return "true";

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "AddCdlist", context);
        }
        if (obData == null)
        {
            BuildStatusErrorResponse();
            return "false";
        }

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> addInternalCdlist()
    {
        var boInput = context?.Bo?.GetBoInput();
        string tableCode = "c_cdlist";

        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        var tableCodeData = boInput.SelectToken(tableCode);
        var newCdlistAdd = tableCodeData.ToCdlist();
        newCdlistAdd.App = context.InfoApp.GetApp();
        if (newCdlistAdd != null)
        {
            newCdlistAdd.Mcaption = _cdlistService.convertToMCaptionEntity(newCdlistAdd.Mcaption);
            await _cdlistService.Insert(newCdlistAdd);

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var token = context.InfoUser.GetUserLogin().Token;
                var userSessions = _memoryCache.Get<UserSessions>(token);
                _codeListService.O9Insert(newCdlistAdd, userSessions);
            }
        }


        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> updateInternalCdlist()
    {
        var boInput = context?.Bo?.GetBoInput();

        string tableCode = "c_cdlist";

        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        var tableCodeData = boInput.SelectToken(tableCode);
        var newCdlistUpdate = tableCodeData.ToCdlist(); ;
        newCdlistUpdate.Mcaption = _cdlistService.convertToMCaptionEntity(newCdlistUpdate.Mcaption);

        if (newCdlistUpdate != null) await _cdlistService.Update(newCdlistUpdate);

        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var token = context.InfoUser.GetUserLogin().Token;
            var userSessions = _memoryCache.Get<UserSessions>(token);
            _codeListService.O9Update(newCdlistUpdate, userSessions);
        }
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> modifyUserProfile()
    {
        await Task.CompletedTask;

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> addUserProfile()
    {
        await Task.CompletedTask;

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> requestResetPassword()
    {
        var learnApi = "O9_change_password";
        context.Bo.GetBoInput()["learn_api"] = learnApi;
        JObject statusLogin = new JObject();

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "ChangePass", context);
        }

        if (obData == null)
        {
            BuildStatusErrorResponse();
            statusLogin.Add("error_login", obData["e"]?.ToString());
            context.Bo.AddPackFo("loginApp", statusLogin);
            return "false";
        }
        // add status login respost
        //and logout

        statusLogin.Add("status_login", "login#127");
        context.Bo.AddPackFo("loginApp", statusLogin);

        //logout

        context.Bo.GetBoInput()["learn_api"] = "O9_delete_session";
        JToken dataLogoutApi = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            dataLogoutApi = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            dataLogoutApi = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "Logout", context);
        }
        if (dataLogoutApi == null) return "false";
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> deleteCdlist()
    {
        var boInput = context?.Bo?.GetBoInput();

        var tableCodeData = boInput.SelectToken("c_cdlist");
        var newCdlistDelete = tableCodeData.ToCdlist();
        if (newCdlistDelete != null)
        {
            var findCdlistDelete = await _cdlistService.GetByCodeGroup(newCdlistDelete.Cdgrp, newCdlistDelete.Cdname, newCdlistDelete.Cdid);

            if (findCdlistDelete != null) await _cdlistService.Delete(findCdlistDelete);

            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var token = context.InfoUser.GetUserLogin().Token;
                var userSessions = _memoryCache.Get<UserSessions>(token);
                _codeListService.O9Delete(findCdlistDelete, userSessions);
            }
        };

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> checkLoginApprove()
    {
        var boInput = context?.Bo?.GetBoInput();

        boInput["learn_api"] = "UMG_LOGIN_APPROVE";
        JToken apiResult = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            apiResult = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "CheckLoginApprove",
                context
            );
        }
        else
        {
            apiResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "CheckLoginApprove", context);
        }

        if (apiResult != null)
        {

            context.Bo.GetActionInput()["user"] = boInput["user"];
            if (apiResult["static_token"] != null)
            {
                context.Bo.GetActionInput()["static_token"] = apiResult["static_token"].ToString();
            }
            return "true";
            // }
            // else
            // {
            //     JObject obErr_ = new JObject();
            //     obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            //     context.Bo.AddPackFo("errorJWebUI", obErr_);
            //     return "false";
            // }
        }
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        context.Bo.AddPackFo("errorJWebUI", obErr);
        return "false";



    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> saveResetPassword()
    {
        var boInput = context?.Bo?.GetBoInput();
        await Task.CompletedTask;

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
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
        if (string.IsNullOrEmpty(context.Bo.GetBoInput()["learn_api"].ToString()))
            context.Bo.GetBoInput()["learn_api"] = "ncbsCBS_workflow_execute_new";
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
            rs = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "executeWorkflow", context);
        }
        return rs;
    }



    private JArray BuildTableCodeForArray(JArray arr, string tableCode)
    {
        JArray arrRes = new JArray();
        foreach (var itemArr in arr)
        {
            JObject obj = new JObject();
            obj.Add(new JProperty(tableCode, itemArr));
            arrRes.Add(obj);
        }
        return arrRes;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public async void IntervalUpdateJobProcess(object source, ElapsedEventArgs e)
    {
        // code here will run every second
        if (await RefreshAndUpdateBatch())
        {
            if (isStopBatch)
            {
                System.Console.WriteLine("stop batch===");
                myTimer.Stop();

                // var foInput = new JObject();
                // foInput["list_component"] = "*";
                // foInput["list_view"] = "*";
                // foInput["learn_api"] = "O9_job_process_refesh_table_summary_jobProcess;O9_job_process_stop_error_mess";

                // System.Console.WriteLine("foInput===" + foInput.ToSerialize());
                // var info = Utils.Utils.CreateFoQuick("fo-refresh-job-process", new JObject()).ToSerialize();
                // await _webSocketsService.SendMessageWithToken(context.InfoUser.GetUserLogin().Token, info);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<bool> RefreshAndUpdateBatch()
    {
        try
        {
            context.Bo.GetBoInput()["learn_api"] = "O9_job_process_refesh_table_summary_jobProcess";
            var batchRefreshResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "RefreshBatch", context);

            context.Bo.GetBoInput()["learn_api"] = "O9_job_process_stop_error_mess";
            var batchStopErrorResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "StopErrorBatch", context);

            if (batchRefreshResult == null || batchStopErrorResult == null) return false;

            System.Console.WriteLine("batchRefreshResult===" + batchRefreshResult.ToSerialize());

            if (batchStopErrorResult["stop_at"] != null)
                if (!string.IsNullOrEmpty(batchStopErrorResult["stop_at"].ToString()))
                    isStopBatch = true;

            if (batchRefreshResult["O9_job_process_summary"] != null)
            {
                var batchSummaryModel = batchRefreshResult["O9_job_process_summary"].ToObject<BatchSumnaryModel>();

                DateTime date2;
                DateTime.TryParse(dayRunningBatch, out date2);

                System.Console.WriteLine("date2==" + date2);

                var days = (int)(batchSummaryModel.BatchDate.Date - date2.Date).TotalDays;

                System.Console.WriteLine("days========" + days);

                if (batchSummaryModel.Current == "100")
                {
                    isStopBatch = true;
                    myTimer.Stop();
                }

                batchSummaryModel.DaysRunning = (batchRunningDays - days).ToString();

                var foInput = batchRefreshResult;
                foInput["O9_job_process_summary"] = batchSummaryModel.ToJObject();
                foInput["form_code"] = form_code;
                foInput["O9_job_process_stop_error_mess"] = batchStopErrorResult;
                var info = Utils.Utils.CreateFoQuick("fo-jobProcess-onStartProcess_handleInterval", foInput.ToJObject()).ToSerialize();
                await _webSocketsService.SendMessageWithToken(context.InfoUser.GetUserLogin().Token, info);
                // }

                return true;
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            await _logger.Information(ex.StackTrace);
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>    
    public virtual async Task<string> RefreshBatch()
    {
        context.Bo.GetBoInput()["learn_api"] = "O9_job_process_refesh_table_summary_jobProcess_interval";
        var batchRefreshResult = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "RefreshBatch", context);

        context.Bo.GetBoInput()["learn_api"] = "O9_job_process_stop_error_mess";
        var batchStopErrorResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "StopErrorBatch", context);

        if (batchRefreshResult == null || batchStopErrorResult == null) return "false";

        context.Bo.AddPackFo("O9_job_process_summary", batchRefreshResult["O9_job_process_summary"]);
        context.Bo.AddPackFo("O9_job_process_refesh_table_summary", batchRefreshResult["O9_job_process_refesh_table_summary"]);
        context.Bo.AddPackFo("O9_job_process_stop_error_mess", batchStopErrorResult);

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> startJobProcess()
    {
        var bo_input_old = context.Bo.GetBoInput().DeepClone();
        if (bo_input_old.SelectToken("user") != null)
        {
            context.Bo.GetBoInput()["learn_api"] = "UMG_LOGIN_APPROVE";
            var apiResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "CheckLogin", context);

            if (apiResult != null) // pass the login
            {
                if (bo_input_old["learn_api_start"] != null)
                {
                    var learn_api_start = bo_input_old["learn_api_start"].ToString();
                    if (bo_input_old.SelectToken("working_date") != null) dayRunningBatch = bo_input_old.SelectToken("working_date").ToString();

                    if (bo_input_old.SelectToken("days") != null) batchRunningDays = int.Parse(bo_input_old.SelectToken("days").ToString());
                    if (bo_input_old.SelectToken("form_code") != null) form_code = bo_input_old.SelectToken("form_code").ToString();

                    context.Bo.GetBoInput()["learn_api"] = learn_api_start;
                    var startBatchResult = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "StartBatch", context);

                    if (startBatchResult != null)
                    {
                        myTimer.Elapsed += new ElapsedEventHandler(IntervalUpdateJobProcess);
                        myTimer.Interval = 1700; // 1000 ms is one second
                        myTimer.Start();

                        // send messsage logout all other session
                        var info = Utils.Utils.CreateFoQuick("#sys:fo-send-logout-all", new JObject()).ToSerialize();
                        await _webSocketsService.SendMessageAllExceptToken(context.InfoUser.GetUserLogin().Token, info);
                    }
                }
            }
            else
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
        }
        return "false";
    }


}
