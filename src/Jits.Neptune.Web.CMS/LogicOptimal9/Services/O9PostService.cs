using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Services.Events;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Services.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Jits.Neptune.Web.CMS.Domain;
using System;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;


namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// Bo Schema Migration
/// </summary>
public partial class O9PostService : IO9PostService, IConsumer<WorkflowEvent>, IConsumer<WorkflowServiceToServiceEvent>
{
    private readonly ILogger _logger;
    private readonly ILocalizationService _localizationService;
    private readonly ILearnApiService _learnApiService;
    private readonly IMediaUploadService _mediaUploadService;
    private readonly CMSSetting _cMSSetting;
    private readonly ILogServiceService _logServiceService;
    private readonly IWebSocketsService _webSocketsService;
    private readonly IPostAPIService _postAPIService;
    private readonly IMemoryCache _memoryCache;
    private readonly IBaseWorkflowService _boService;
    private readonly IMappingService _mappingService;
    private readonly IApiService _coreService;

    // int ZERO = 0;
    /// <summary>
    /// The timeout
    /// </summary>
    int TIMEOUT = 60000;

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public JWebUIObjectContextModel context { get; set; }

    #region Ctor
    /// <summary>
    ///
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="learnApiService"></param>
    /// <param name="cMSSetting"></param>
    /// <param name="mediaUploadService"></param>
    /// <param name="logger"></param>
    /// <param name="logServiceService"></param>
    /// <param name="webSocketsService"></param>
    /// <param name="postAPIService"></param>
    /// <param name="memoryCache"></param>
    /// <param name="mappingService"></param>
    /// <param name="boService"></param>
    /// <param name="coreService"></param>
    public O9PostService(
        ILocalizationService localizationService,
        ILearnApiService learnApiService,
        CMSSetting cMSSetting,
        IMediaUploadService mediaUploadService,
        ILogger logger,
        ILogServiceService logServiceService,
        IWebSocketsService webSocketsService,
        IPostAPIService postAPIService,
        IMemoryCache memoryCache, IMappingService mappingService,
        IBaseWorkflowService boService, IApiService coreService)
    {
        _localizationService = localizationService;
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _learnApiService = learnApiService;
        _cMSSetting = cMSSetting;
        _mediaUploadService = mediaUploadService;
        _logger = logger;
        _logServiceService = logServiceService;
        _webSocketsService = webSocketsService;
        _postAPIService = postAPIService;
        _memoryCache = memoryCache;
        _boService = boService;

        if (Singleton<ListExecuteModel>.Instance == null)
            Singleton<ListExecuteModel>.Instance = new ListExecuteModel();

        TIMEOUT = _cMSSetting.TimeoutApi;
        _mappingService = mappingService;
        _coreService = coreService;
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> GetDataPostAPI(
    string appCodeRequest,
    string actionName,
    JWebUIObjectContextModel context
)
    {
        try
        {
            var boInput = context.Bo.GetBoInput();
            if (boInput != null && boInput.ContainsKey("learn_api"))
            {
                var learnApi__ = boInput["learn_api"].ToString();
                
                var response = await Optimal9Router(learnApi__, appCodeRequest, context);

                return response;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            throw new Exception(ex.Message);
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <param name="learn_api"></param>
    /// <returns></returns>
    public async Task<JToken> O9CallAPIAsync(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context,
        string learn_api
    )
    {
        try
        {
            if (!string.IsNullOrEmpty(learn_api))
            {
                return await Optimal9Router(learn_api, appCodeRequest, context);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            throw new Exception(ex.Message);
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="learnApi"></param>
    /// <param name="appCodeRequest"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> Optimal9Router(
        string learnApi,
        string appCodeRequest,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var arrLearnApi = learnApi.Split(';').Where(s => !string.IsNullOrEmpty(s)).ToArray();
            learnApi = arrLearnApi[0];

            var boInput = context.Bo.GetBoInput();

            JObject obDataForMap = boInput;

            if (obDataForMap.ContainsKey("data_select"))
               obDataForMap = JObject.FromObject(obDataForMap["data_select"]);
            // if (obDataForMap.ContainsKey("form_child"))
            //     obDataForMap = JObject.FromObject(obDataForMap["form_child"]);

            Console.WriteLine("learnApi__" + learnApi);
            Console.WriteLine("appCodeRequest" + appCodeRequest);

            var ob_ = await _postAPIService.TxMapData(learnApi, obDataForMap, appCodeRequest);

            if (ob_ != null)
            {
                var learnApiMapping = JsonConvert.DeserializeObject<WorkflowRequestModel>(ob_.LearnApiMapping);
                learnApiMapping.user_sessions = _memoryCache.Get<UserSessions>(learnApiMapping.token);
                learnApiMapping.MappingResponse = ob_.LearnApiMappingResponse;
                learnApiMapping.ObjectField = JObject.Parse(learnApiMapping.fields.ToSerialize());
                learnApiMapping.StringWorkingDate = learnApiMapping.user_sessions?.Txdt.ToString("dd/MM/yyyy") ?? null;

                bool isCommonApi = learnApi switch
                {
                    "ncbsCBS_workflow_execute" => true,
                    "ncbsCBS_workflow_execute_new" => true,
                    "ncbsCBS_workflow_get_execution_info_new" => true,
                    _ => false
                };

                JToken result = null;
                if (isCommonApi || 
                    string.IsNullOrEmpty(learnApiMapping.ActionType) || 
                    learnApiMapping.ActionType.ToLower() == "workflow")
                {
                    
                    result = await ExecuteWorkflow(learnApiMapping, JObject.Parse(ob_.LearnApiMapping), context);
                }
                else
                {
                    result = await ExecuteLearnApiAction(learnApiMapping, ob_.LearnApiMapping);
                }

                var processedResult = await ProcessResponse(result, learnApiMapping);

                if (Singleton<ExecutionTimer>.Instance == null)
                {
                    Singleton<ExecutionTimer>.Instance = new ExecutionTimer();
                }
                stopwatch.Stop();
                //Singleton<ExecutionTimer>.Instance.ExecutionTime += stopwatch.ElapsedMilliseconds;
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync($"Execution time total =={stopwatch.ElapsedMilliseconds}");
                Console.ResetColor();
                return processedResult;
            }
        }
        catch (Exception ex)
        {
            var errorModel = ex.Message.BuildWorkflowResponseError();
            var processedError = await ProcessResponse(errorModel, new WorkflowRequestModel());
            return processedError;
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExecutionTimer
    {
        /// <summary>
        /// 
        /// </summary>
        public long ExecutionTime { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowRequestModel : WorkflowExecuteModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("workflow_func")]
        public string WorkflowFunc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("table_name")]
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_field_name")]
        public string IdFieldName {  get; set; }

        /// <summary>
        /// Gets or sets the value of the action type
        /// </summary>
        [JsonProperty("action_type")]
        public string ActionType { get; set; }

        /// <summary>
        /// Sets or gets the value of the module
        /// </summary>
        [JsonProperty("module")]
        public string Module { set; get; } = "";
        
        /// <summary>
        /// Sets or gets the value of the module
        /// </summary>
        [JsonProperty("tx_code")]
        public string TxCode { set; get; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string MappingResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JObject ObjectField { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("use_learn_api_config")]
        public bool UseLearnApiConfig { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public string StringWorkingDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWorkflow = false;
    }
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowResponseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkflowResponseModel(){}
        /// <summary>
        /// 
        /// </summary>
        public WorkflowResponseModel(int _status, string _error_message, JToken _result = null, bool _needs_mapping = false)
        {
            result = _result;
            error_message = _error_message;
            status = _status;
            needs_mapping = _needs_mapping;
        }
        /// <summary>
        /// 
        /// </summary>
        public JToken result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string error_message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int status{get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool needs_mapping { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflowRequest"></param>
    /// <param name="dataRequest"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NeptuneException"></exception>
    public async Task<JToken> ExecuteWorkflow(WorkflowRequestModel workflowRequest, JObject dataRequest, JWebUIObjectContextModel context)
    {
        try
        {
            var workflowInfo = GetWorkflowInfo(workflowRequest);

            if (workflowInfo == null)
            {
                string errorMessage = $"Invalid workflow [{workflowRequest.workflowid}]!";
                return errorMessage.BuildWorkflowResponseError();
            }

            JToken obRss = workflowRequest.ObjectField;
            if (workflowRequest.CheckCondition())
            {
                obRss = await ExecuteWorkflowInfo(workflowInfo, workflowRequest, dataRequest);
            }

            return obRss;
        }
        catch(Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    private static WorkflowInfo GetWorkflowInfo(WorkflowRequestModel workflowRequest)
    {
        var workflows = Singleton<ConfigureWorkflow>.Instance.Workflows;

        if (workflows.TryGetValue(workflowRequest.workflowid, out var workflowInfo))
            return workflowInfo;

        return EngineContext.Current.Resolve<WorkflowStartup>().TryGetWorkflow(workflowRequest.workflowid);
    }

    private async Task<JToken> ProcessResponse(JToken response, WorkflowRequestModel model)
    {
        if (response == null)
        {
            var errorMessage = "Null response received from the service.";
            var err = await _coreService.BuildError(model.workflowid, new WorkflowResponseModel { status = ExecutionStatus.ERROR, error_message = errorMessage });
            context.Bo.AddActionErrorAll(err);
            return null;
        }

        var responseModel = response.ToObject<WorkflowResponseModel>();
        if (responseModel.status != ExecutionStatus.SUCCESS)
        {
            var err = await _coreService.BuildError(model.workflowid, responseModel, string.Empty);
            context.Bo.AddActionErrorAll(err);
            return null;
        }
        else
        {
            var jsResult = responseModel.result;
            JToken mapping;
            if (responseModel.needs_mapping)
            {
                mapping = await _mappingService.MappingResponse(model.MappingResponse, jsResult);
            }
            else
            {
                mapping = jsResult;
            }
            return mapping;
        }
    }

    private async Task<JToken> ExecuteWorkflowInfo(WorkflowInfo workflowInfo, WorkflowRequestModel workflowRequest, JObject dataRequest)
    {
        if (workflowInfo.IsCommonProcess == 1)
        {
            var learnApiModel = await _mappingService.MappingRequest(workflowInfo, dataRequest);

            workflowRequest.ObjectField = JObject.Parse(learnApiModel.LearnApiMapping);
            workflowRequest.fields = learnApiModel.LearnApiMapping.MapToModel<Dictionary<string, object>>();
            //workflowRequest.WorkflowFunc = workflowInfo.BoInfo.WorkflowFunc;
            //workflowRequest.TableName = workflowInfo.BoInfo.TableName;
            //workflowRequest.IdFieldName = workflowInfo.BoInfo.IdFieldName;
            //workflowRequest.MappingResponse = workflowInfo.MappingResponse;
        }

        if (!workflowRequest.UseLearnApiConfig)
        {
            workflowRequest.WorkflowFunc = workflowInfo.BoInfo.WorkflowFunc;
            workflowRequest.TableName = workflowInfo.BoInfo.TableName;
            workflowRequest.IdFieldName = workflowInfo.BoInfo.IdFieldName;
            workflowRequest.MappingResponse = workflowInfo.MappingResponse;
        }

        workflowRequest.IsWorkflow = true;
        var result = await workflowInfo.InvokeWorkflow(workflowRequest);

        //var processedResult = await ProcessResponse(result, workflowRequest);
        return result;
    }

    private async Task<JToken> ExecuteLearnApiAction(WorkflowRequestModel model, string requestData)
    {
        JToken obRss = null;
        
        switch (Enum.Parse<ActionType>(model.ActionType))
        {
            case ActionType.RuleFunc:
                obRss = await _boService.RuleFunc(model);
                break;
            case ActionType.ExecuteRuleFunc:
                    obRss = await _boService.ExecuteRuleFunc(model);
                break;
            case ActionType.CreateFo:
                 obRss = await _boService.FrontOffice(model);
                break;
            case ActionType.UpdateBo:
                model.ObjectField = JObject.Parse(JsonConvert.SerializeObject(model.fields));
                obRss = await _boService.UpdateBO(model);
                break;
            case ActionType.CreateBo:
                model.ObjectField = JObject.Parse(JsonConvert.SerializeObject(model.fields));
                obRss = await _boService.CreateBO(model);
                break;
            case ActionType.Search:
                var search = await _boService.SimpleSearch(model);
                obRss = search;
                break;
            case ActionType.SearchAd:
                var searchAd = await _boService.AdvanceSearch(model);
                obRss = searchAd;
                break;
            case ActionType.ViewBo:
                model.ObjectField = JObject.Parse(JsonConvert.SerializeObject(model.fields));
                var view = await _boService.View(model);
                obRss = view;
                break;
            case ActionType.Delete:
                model.ObjectField = JObject.Parse(JsonConvert.SerializeObject(model.fields));
                await _boService.Delete(model);
                break;
            case ActionType.SearchList:
                model.ObjectField = JObject.Parse(JsonConvert.SerializeObject(model.fields));
                obRss = await _boService.SearchList(model);
                break;
            case ActionType.SearchInfo:
                model.ObjectField = JObject.Parse(JsonConvert.SerializeObject(model.fields));
                obRss = await _boService.SearchInfo(model);
                break;
            default:
                string message = "Invalid Learn Api Action Type!";
                obRss = message.BuildWorkflowResponseError();
                break;
        }

        //var processedResult = await ProcessResponse(obRss, model);
        return obRss;
    }

    /// <summary>
    ///
    /// /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public Task HandleEvent(WorkflowEvent e)
    {
        //System.Console.WriteLine("event=====>"+e.EventName);
        switch (e.EventName)
        {
            case "EventWorkflowCompleted":
                Singleton<ListExecuteModel>.Instance.listExecuteModel[e.ExecutionId] = e;
                break;
            case "EventWorkflowError":
                Singleton<ListExecuteModel>.Instance.listExecuteModel[e.ExecutionId] = e;
                break;
            // case "EventWorkflowTimeout":
            //     Singleton<ListExecuteModel>.Instance.listExecuteModel[e.ExecutionId] = e;
            //     context.Bo.AddActionErrorAll(BuildErrorStatusCode("EventWorkflowTimeout", "200"));
            //     break;
            // case "EventWorkflowCompensated":
            //     Singleton<ListExecuteModel>.Instance.listExecuteModel[e.ExecutionId] = e;
            //     context.Bo.AddActionErrorAll(BuildErrorStatusCode("EventWorkflowCompensated", "200"));
            //     break;
            // case "EventWorkflowReversed":
            //     Singleton<ListExecuteModel>.Instance.listExecuteModel[e.ExecutionId] = e;
            //     context.Bo.AddActionErrorAll(BuildErrorStatusCode("EventWorkflowReversed", "200"));
            //     break;
            default:
                break;
        }

        return Task.CompletedTask;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public Task HandleEvent(WorkflowServiceToServiceEvent e)
    {
        switch (e.EventName)
        {
            case "EventServiceToService":
                switch (e.EventData.event_type)
                {
                    case "JITS.Neptune.NeptuneClient.Log.CentralizedLog":
                        var dataLog = e.EventData.text_data.DerializeSystemTextWithModel<
                            List<JITS.Neptune.NeptuneClient.Log.CentralizedLog>
                        >();
                        if (dataLog != null)
                        {
                            foreach (var item in dataLog)
                            {
                                _logServiceService.WriteCentralizedLog(item).GetAwaiter();
                            }
                        }

                        break;
                    case "SendWebsocketByInstanceID":
                        var datMessageWebsocket =
                            e.EventData.text_data.DerializeSystemTextWithModel<MessageWebsocketModel>();
                        if (datMessageWebsocket != null)
                            _webSocketsService.SendMessageAsyncInternal(
                                datMessageWebsocket.token,
                                datMessageWebsocket.message
                            );

                        break;
                    default:
                        break;
                }

                break;
            default:
                break;
        }

        return Task.CompletedTask;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public Task BuildWorkflowResponse(WorkflowEvent e)
    {
        return Task.CompletedTask;
    }
}