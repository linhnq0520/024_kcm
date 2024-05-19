using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core.Events;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Configuration;
using Jits.Neptune.Web.Framework.Services.Events;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Services.Logging;
using Jits.Neptune.Web.Framework.Services.Security;
using JITS.Neptune.NeptuneClient.Events;
using JITS.Neptune.NeptuneClient.Events.EventData;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Microsoft.Extensions.Caching.Memory;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// PostAPI service
/// </summary>
public partial class PostAPIService
    : IPostAPIService,
        IConsumer<WorkflowEvent>,
        IConsumer<WorkflowServiceToServiceEvent>
{
    #region Fields

    // private ListExecuteModel _listWorkflowExecute = new ListExecuteModel();
    private readonly ILogger _logger;
    private readonly ILocalizationService _localizationService;
    private readonly ILearnApiService _learnApiService;
    private readonly IAdminGrpcService _adminGrpcService;
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly IGrpcClientService _grpcClientService;
    private readonly IMediaUploadService _mediaUploadService;
    private readonly CMSSetting _cMSSetting;
    private readonly ILogServiceService _logServiceService;
    private readonly IWebSocketsService _webSocketsService;

    //
    private readonly IAdminServices _adminService;
    //

    // int ZERO = 0;
    int TIMEOUT = 60000;
    string NameSpaceFlowApi = "Jits.Neptune.Web.CMS.FlowApi";

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public JWebUIObjectContextModel context { get; set; }
    Stopwatch timer = new Stopwatch();

    #endregion

    #region Ctor
    /// <summary>
    ///
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="learnApiService"></param>
    /// <param name="adminService"></param>
    /// <param name="adminGrpcService"></param>
    /// <param name="cMSSetting"></param>
    /// <param name="authenticationGrpcService"></param>
    /// <param name="grpcClientService"></param>
    /// <param name="mediaUploadService"></param>
    /// <param name="logger"></param>
    /// <param name="logServiceService"></param>
    /// <param name="webSocketsService"></param>
    public PostAPIService(
        ILocalizationService localizationService,
        ILearnApiService learnApiService,
        IAdminServices adminService,
        IAdminGrpcService adminGrpcService,
        CMSSetting cMSSetting,
        IAuthenticationGrpcService authenticationGrpcService,
        IGrpcClientService grpcClientService,
        IMediaUploadService mediaUploadService,
        ILogger logger,
        ILogServiceService logServiceService,
        IWebSocketsService webSocketsService
    )
    {
        _localizationService = localizationService;
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _learnApiService = learnApiService;
        _adminService = adminService;
        _adminGrpcService = adminGrpcService;
        _cMSSetting = cMSSetting;
        _authenticationGrpcService = authenticationGrpcService;
        _grpcClientService = grpcClientService;
        _mediaUploadService = mediaUploadService;
        _logger = logger;
        _logServiceService = logServiceService;
        _webSocketsService = webSocketsService;

        if (Singleton<ListExecuteModel>.Instance == null)
            Singleton<ListExecuteModel>.Instance = new ListExecuteModel();

        // if (Singleton<GrpcClientExecuteModel>.Instance == null)
        // {
        //     Singleton<GrpcClientExecuteModel>.Instance = new GrpcClientExecuteModel();
        //     if (!Singleton<GrpcClientExecuteModel>.Instance.isRegistered)
        //     {
        //         System.Console.WriteLine("ONLY ONCE---");
        //         Singleton<GrpcClientExecuteModel>.Instance.isRegistered = true;
        //         Singleton<GrpcClientExecuteModel>.Instance.grpcClient.RegisterGrpcService();
        //     }
        // }

        TIMEOUT = _cMSSetting.TimeoutApi;
    }

    #endregion

    private async Task<JToken> BuildResponseWithCoreApiWithoutKeyReadData(
        ICoreAPIService coreApi,
        LearnApiModel learnApiModel,
        string data
    )
    {
        if (data != null)
        {
            try
            {
                var responseExecute = JsonConvert.DeserializeObject<ExecuteResponseModel>(data);
                // System.Console.WriteLine("responseExecute====>" + responseExecute.ToSerialize());
                //xử ly cho api portal có lỗi (cụ thể view monitering)
                if (responseExecute.ErrorMessage != "")
                {
                    var executionRequest =
                    JsonConvert.DeserializeObject<JITS.Neptune.NeptuneClient.Workflow.WorkflowExecutionInquiry>(
                        data
                    );
                    if (!coreApi.CheckHasError(executionRequest).GetAwaiter().GetResult())
                        return (await coreApi.BuildResponse(JToken.Parse(data)));
                    else
                    {
                        context.Bo.AddActionErrorAll(
                           await coreApi.BuildError(executionRequest)
                        );
                        return null;
                    }

                }

                if (responseExecute.Status == null)
                {
                    if (!coreApi.CheckHasError(responseExecute).GetAwaiter().GetResult())
                        return (await coreApi.BuildResponse(responseExecute)).ToJToken();
                    else
                    {
                        context.Bo.AddActionErrorAll(await coreApi.BuildError(responseExecute));
                        return null;
                    }
                }

                if (responseExecute.ExecutionId != null)
                {
                    if (responseExecute.Data != null)
                        return await coreApi.BuildResponse(JToken.FromObject(responseExecute.Data));
                    try
                    {
                        int elapsed = 0;
                        Singleton<ListExecuteModel>.Instance.listExecuteModel[
                            responseExecute.ExecutionId
                        ] = null;
                        while (
                            (
                                Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                    responseExecute.ExecutionId
                                ] == null
                            ) && (elapsed < TIMEOUT)
                        )
                        {
                            await Task.Delay(50);

                            elapsed += 50;
                        }

                        if (elapsed >= TIMEOUT)
                        {
                            context.Bo.AddActionErrorAll(BuildErrorTimeout(responseExecute));
                            return null;
                        }
                        ;

                        switch (
                            Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                responseExecute.ExecutionId
                            ].EventName
                        )
                        {
                            case "EventWorkflowReversed":
                                return null;
                            case "EventWorkflowCompensated":
                                return null;
                            case "EventWorkflowTimeout":
                                return null;
                            default:
                                break;
                        }

                        if (
                            Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                responseExecute.ExecutionId
                            ].EventData == null
                        )
                        {
                            context.Bo.AddActionErrorAll(BuildErrorTimeout(responseExecute));
                            return null;
                        }

                        if (
                            Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                responseExecute.ExecutionId
                            ].EventData.execution.is_timeout.Equals("Y")
                        )
                        {
                            context.Bo.AddActionErrorAll(BuildErrorTimeout(responseExecute));
                            return null;
                        }
                        var responseInfoExecute = Singleton<ListExecuteModel>
                            .Instance
                            .listExecuteModel[
                            responseExecute.ExecutionId
                        ].EventData.ToWorkflowExecutionInquiry();

                        if (responseInfoExecute != null)
                        {

                            if (
                                !coreApi.CheckHasError(responseInfoExecute).GetAwaiter().GetResult()
                            )
                                return await coreApi.BuildResponse(
                                    JToken.Parse(responseInfoExecute.ToSerialize())
                                );
                            else
                            {
                                context.Bo.AddActionErrorAll(
                                    coreApi.BuildError(responseInfoExecute).GetAwaiter().GetResult()
                                );
                                return null;
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine(
                            "InquireWorkflowExecution Exception======" + ex.StackTrace
                        );
                        // TODO
                    }
                    finally
                    {
                        WorkflowEvent wf_event = new WorkflowEvent();
                        Singleton<ListExecuteModel>.Instance.listExecuteModel.TryRemove(
                            responseExecute.ExecutionId,
                            out wf_event
                        );
                    }

                }
                else
                {
                    if (!coreApi.CheckHasError(responseExecute).GetAwaiter().GetResult())
                        return (await coreApi.BuildResponse(responseExecute)).ToJToken();
                    else
                    {
                        context.Bo.AddActionErrorAll(await coreApi.BuildError(responseExecute));
                        return null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                // TODO
                // TODO
                var executionRequest =
                    JsonConvert.DeserializeObject<JITS.Neptune.NeptuneClient.Workflow.WorkflowExecutionInquiry>(
                        data
                    );
                // Console.WriteLine("======executionRequest=====" + JsonConvert.SerializeObject(executionRequest));
                if (executionRequest.execution != null)
                {
                    if (executionRequest.execution.execution_id != null)
                    {
                        if (!coreApi.CheckHasError(executionRequest).GetAwaiter().GetResult())
                            return (await coreApi.BuildResponse(JToken.Parse(data)));
                        else
                        {
                            context.Bo.AddActionErrorAll(
                                await coreApi.BuildError(executionRequest)
                            );
                            return null;
                        }
                    }
                }

                return await coreApi.BuildResponse(JToken.Parse(data));
            }
        }
        return null;
    }

    private async Task<JToken> BuildResponseWithCoreApi(
        ICoreAPIService coreApi,
        LearnApiModel learnApiModel,
        string data
    )
    {
        if (data != null)
        {
            try
            {
                var responseExecute = JsonConvert.DeserializeObject<ExecuteResponseModel>(data);
                if (responseExecute.Status == null)
                {
                    if (!coreApi.CheckHasError(responseExecute).GetAwaiter().GetResult())
                        //     return (await coreApi.BuildResponse(responseExecute));
                        return (
                            await coreApi.BuildResponse(
                                JToken
                                    .Parse(responseExecute.ToSerialize())
                                    .SelectToken(learnApiModel.KeyReadData)
                            )
                        );
                    else
                    {
                        context.Bo.AddActionErrorAll(await coreApi.BuildError(responseExecute));
                        return null;
                    }
                }

                if (responseExecute.ExecutionId != null)
                {
                    if (responseExecute.Data != null)
                        return await coreApi.BuildResponse(JToken.FromObject(responseExecute.Data));
                    try
                    {
                        int elapsed = 0;
                        System.Console.WriteLine(
                            "responseExecute=====" + responseExecute.ToSerialize()
                        );
                        Singleton<ListExecuteModel>.Instance.listExecuteModel[
                            responseExecute.ExecutionId
                        ] = null;
                        while (
                            (
                                Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                    responseExecute.ExecutionId
                                ] == null
                            ) && (elapsed < TIMEOUT)
                        )
                        {
                            await Task.Delay(50);
                            elapsed += 50;
                        }
                        Console.WriteLine("======elapsed===" + elapsed);

                        timer.Stop();

                        if (elapsed >= TIMEOUT)
                        {
                            context.Bo.AddActionErrorAll(BuildErrorTimeout(responseExecute));
                            return null;
                        }
                        ;

                        switch (
                            Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                responseExecute.ExecutionId
                            ].EventName
                        )
                        {
                            case "EventWorkflowReversed":
                                return null;
                            case "EventWorkflowCompensated":
                                return null;
                            case "EventWorkflowTimeout":
                                return null;
                            default:
                                break;
                        }

                        if (
                            Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                responseExecute.ExecutionId
                            ].EventData == null
                        )
                        {
                            context.Bo.AddActionErrorAll(BuildErrorTimeout(responseExecute));
                            return null;
                        }

                        if (
                            Singleton<ListExecuteModel>.Instance.listExecuteModel[
                                responseExecute.ExecutionId
                            ].EventData.execution.is_timeout.Equals("Y")
                        )
                        {
                            context.Bo.AddActionErrorAll(BuildErrorTimeout(responseExecute));
                            return null;
                        }

                        var responseInfoExecute = Singleton<ListExecuteModel>
                            .Instance
                            .listExecuteModel[
                            responseExecute.ExecutionId
                        ].EventData.ToWorkflowExecutionInquiry();

                        if (responseInfoExecute != null)
                        {
                            if (
                                !coreApi.CheckHasError(responseInfoExecute).GetAwaiter().GetResult()
                            )
                                return (
                                    await coreApi.BuildResponse(
                                        JToken
                                            .Parse(responseInfoExecute.ToSerialize())
                                            .SelectToken(learnApiModel.KeyReadData)
                                    )
                                );
                            else
                            {
                                context.Bo.AddActionErrorAll(
                                    coreApi.BuildError(responseInfoExecute).GetAwaiter().GetResult()
                                );
                                return null;
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine(
                            "InquireWorkflowExecution Exception======" + ex.StackTrace
                        );

                        // TODO
                    }
                    finally
                    {
                        WorkflowEvent wf_event = new WorkflowEvent();
                        Singleton<ListExecuteModel>.Instance.listExecuteModel.TryRemove(
                            responseExecute.ExecutionId,
                            out wf_event
                        );
                    }
                }
                else
                {
                    if (!coreApi.CheckHasError(responseExecute).GetAwaiter().GetResult())
                        //     return (await coreApi.BuildResponse(responseExecute));
                        return (
                            await coreApi.BuildResponse(
                                JToken
                                    .Parse(responseExecute.ToSerialize())
                                    .SelectToken(learnApiModel.KeyReadData)
                            )
                        );
                    else
                    {
                        context.Bo.AddActionErrorAll(await coreApi.BuildError(responseExecute));
                        return null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception IsSuccessStatusCode " + ex.StackTrace);
                Console.WriteLine("Fail parsing ExecuteResponseModel for data==" + data);
                // TODO
                // var executionRequest = JsonConvert.DeserializeObject<JITS.Neptune.NeptuneClient.Workflow.WorkflowExecutionInquiry>(data);
                // if (executionRequest.execution.execution_id != null)
                // {
                //     if (!coreApi.CheckHasError(executionRequest).GetAwaiter().GetResult())
                //         return (await coreApi.BuildResponse(JToken.Parse(data).SelectToken(learnApiModel.KeyReadData)));
                //     else
                //     {
                //         context.Bo.AddActionErrorAll(await coreApi.BuildError(executionRequest));
                //         return null;
                //     }
                // }
                return await coreApi.BuildResponse(JToken.Parse(data));
            }
        }
        return null;
    }

    private async Task<JToken> BuildResponseWithCoreApiDownload(
        ICoreAPIService coreApi,
        LearnApiModel learnApiModel,
        string data
    )
    {
        if (data != null)
        {
            return await coreApi.BuildResponse(JToken.Parse(data));
        }
        return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="coreApi"></param>
    /// <param name="learnApiModel"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private async Task<JToken> BuildResponseWithCoreApiUploadMasterFile(
        ICoreAPIService coreApi,
        LearnApiModel learnApiModel,
        string data
    )
    {
        if (data != null)
        {
            Type tp = data.GetType();
            if (tp.Equals(typeof(string)))
            {
                if (data == "\"Success\"")
                    return await coreApi.BuildResponse(JToken.Parse("{ \"Success\": true}"));
                else
                {
                    try
                    {
                        return await coreApi.BuildResponse(JToken.Parse(data));
                    }
                    catch (System.Exception ex)
                    {
                        // TODO
                        System.Console.WriteLine(ex);
                        return null;
                    }
                }
            }
            else
                return await coreApi.BuildResponse(JToken.Parse(data));
        }
        return null;
    }

    private async Task<HttpResponseMessage> CallAPI(
        ICoreAPIService coreApi,
        LearnApiModel learnApiModel
    )
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (
            sender,
            cert,
            chain,
            sslPolicyErrors
        ) =>
        {
            return true;
        };

        HttpClient httpClient = new HttpClient(clientHandler);
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

        var pHeaders = JsonConvert.DeserializeObject<Dictionary<string, string>>(
            learnApiModel.LearnApiHeader
        );
        var requestContent = new StringContent(
            await coreApi.BuildRequest(learnApiModel.LearnApiMapping),
            Encoding.UTF8,
            "application/json"
        );
        var requestMessage = new HttpRequestMessage(
            new HttpMethod(learnApiModel.LearnApiMethod),
            learnApiModel.LearnApiLink
        )
        {
            Content = requestContent
        };
        foreach (var head in pHeaders)
        {
            requestMessage.Headers.TryAddWithoutValidation(head.Key, head.Value);
        }
        httpClient.Timeout = TimeSpan.FromMinutes(10);

        System.Console.WriteLine("learnApiModel ===" + learnApiModel.ToSerialize());
        System.Console.WriteLine("requestMessage ===" + requestMessage.ToSerialize());

        return await httpClient.SendAsync(requestMessage);
    }

    private async Task<HttpResponseMessage> CallAPIWithPortalToken(
        ICoreAPIService coreApi,
        LearnApiModel learnApiModel,
        string portalToken
    )
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (
            sender,
            cert,
            chain,
            sslPolicyErrors
        ) =>
        {
            return true;
        };

        HttpClient httpClient = new HttpClient(clientHandler);
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        // var pHeaders = JsonConvert.DeserializeObject<Dictionary<string, string>>(learnApiModel.LearnApiHeader);

        var requestContent = new StringContent(
            await coreApi.BuildRequest(learnApiModel.LearnApiMapping),
            Encoding.UTF8,
            "application/json"
        );
        var requestMessage = new HttpRequestMessage(
            new HttpMethod(learnApiModel.LearnApiMethod),
            learnApiModel.LearnApiLink
        )
        {
            Content = requestContent
        };
        requestMessage.Headers.TryAddWithoutValidation("Authorization", "Bearer " + portalToken);

        // foreach (var head in pHeaders)
        // {
        //     requestMessage.Headers.TryAddWithoutValidation(head.Key, head.Value);
        // }
        return await httpClient.SendAsync(requestMessage);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiModel"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> PostHttpsWithStatusCodeDownload(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            ICoreAPIService coreApi = (ICoreAPIService)
                Activator.CreateInstance(
                    Type.GetType(
                        NameSpaceFlowApi
                            + ".Api"
                            + Utils.StringExtensions.CaptializeFirstLetterRemoveUnderScore(
                                learnApiModel.FlowApi
                            )
                    )
                );
            if (coreApi != null)
            {
                timer.Start();

                var response = await CallAPI(coreApi, learnApiModel);
                //  var response = await Request(_client, learnApiModel.LearnApiMethod, learnApiModel.LearnApiLink, , headerApi);
                System.Console.WriteLine("response.StatusCode ===" + response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return await BuildResponseWithCoreApiDownload(coreApi, learnApiModel, data);
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        await ExtendPortalToken();
                        var response_retry = await CallAPIWithPortalToken(
                            coreApi,
                            learnApiModel,
                            context.InfoUser.GetUserLogin().PortalToken
                        );

                        var data_retry = await response_retry.Content.ReadAsStringAsync();

                        return await BuildResponseWithCoreApiDownload(
                            coreApi,
                            learnApiModel,
                            data_retry
                        );
                    }
                    else
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        context.Bo.AddActionErrorAll(
                            BuildErrorStatusCode(data, response.StatusCode + "")
                        );
                        return null;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("PostHttps======" + ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiModel"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> PostHttpsWithStatusCodeUploadMasterFile(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            ICoreAPIService coreApi = (ICoreAPIService)
                Activator.CreateInstance(
                    Type.GetType(
                        NameSpaceFlowApi
                            + ".Api"
                            + Utils.StringExtensions.CaptializeFirstLetterRemoveUnderScore(
                                learnApiModel.FlowApi
                            )
                    )
                );
            if (coreApi != null)
            {
                timer.Start();

                var response = await CallAPI(coreApi, learnApiModel);
                //  var response = await Request(_client, learnApiModel.LearnApiMethod, learnApiModel.LearnApiLink, , headerApi);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return await BuildResponseWithCoreApiUploadMasterFile(
                        coreApi,
                        learnApiModel,
                        data
                    );
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        await ExtendPortalToken();
                        var response_retry = await CallAPIWithPortalToken(
                            coreApi,
                            learnApiModel,
                            context.InfoUser.GetUserLogin().PortalToken
                        );

                        var data_retry = await response_retry.Content.ReadAsStringAsync();

                        return await BuildResponseWithCoreApiUploadMasterFile(
                            coreApi,
                            learnApiModel,
                            data_retry
                        );
                    }
                    else
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        context.Bo.AddActionErrorAll(
                            BuildErrorStatusCode(data, response.StatusCode + "")
                        );
                        return null;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("PostHttps======" + ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;PostAPI&gt;.</returns>
    ///
    public async Task<JToken> PostHttpsWithStatusCode(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            ICoreAPIService coreApi = (ICoreAPIService)
                Activator.CreateInstance(
                    Type.GetType(
                        NameSpaceFlowApi
                            + ".Api"
                            + Utils.StringExtensions.CaptializeFirstLetterRemoveUnderScore(
                                learnApiModel.FlowApi
                            )
                    )
                );
            if (coreApi != null)
            {
                timer.Start();

                var response = await CallAPI(coreApi, learnApiModel);
                //  var response = await Request(_client, learnApiModel.LearnApiMethod, learnApiModel.LearnApiLink, , headerApi);
                System.Console.WriteLine("response.StatusCode=====" + response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return await BuildResponseWithCoreApi(coreApi, learnApiModel, data);
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        System.Console.WriteLine("learnApiModel=====" + learnApiModel.ToSerialize());

                        await ExtendPortalToken();
                        var response_retry = await CallAPIWithPortalToken(
                            coreApi,
                            learnApiModel,
                            context.InfoUser.GetUserLogin().PortalToken
                        );

                        var data_retry = await response_retry.Content.ReadAsStringAsync();

                        return await BuildResponseWithCoreApi(coreApi, learnApiModel, data_retry);
                    }
                    else
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        context.Bo.AddActionErrorAll(
                            BuildErrorStatusCode(data, response.StatusCode + "")
                        );
                        return null;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("PostHttps======" + ex.StackTrace);
        }
        return null;
    }

    private async Task ExtendPortalToken()
    {
        var new_token = await GetNeptuneToken("ncbs");

        if (!string.IsNullOrEmpty(new_token))
        {
            var obj_token = new JObject();
            obj_token["portal_token"] = new_token;
            var info = Utils.Utils
                .CreateFoQuick("#sys:fo-set-portal-token", obj_token)
                .ToSerialize();
            await _webSocketsService.SendMessageWithToken(
                context.InfoUser.GetUserLogin().Token,
                info
            );
            context.InfoUser.GetUserLogin().PortalToken = new_token;
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public List<ErrorInfoModel> BuildErrorTimeout(ExecuteResponseModel packApi)
    {
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        listError.Add(
            AddActionError(
                ErrorType.errorForm,
                ErrorMainForm.warning,
                "Timeout after " + TIMEOUT + "(ms) for ExecutionId : " + packApi.ExecutionId,
                "",
                "#ERROR_EXECUTE: "
            )
        );
        return listError;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    public List<ErrorInfoModel> BuildErrorStatusCode(string msg, string statusCode)
    {
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        listError.Add(
            AddActionError(
                ErrorType.errorForm,
                ErrorMainForm.warning,
                statusCode,
                "",
                "#ERROR_STATUSCODE: "
            )
        );
        listError.Add(
            AddActionError(ErrorType.errorForm, ErrorMainForm.warning, msg, "", "#ERROR_API: ")
        );
        return listError;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="type"></param>
    /// <param name="typeError"></param>
    /// <param name="info"></param>
    /// <param name="code"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public ErrorInfoModel AddActionError(
        string type,
        string typeError,
        string info,
        string code,
        string key
    )
    {
        return new ErrorInfoModel()
        {
            type = type,
            type_error = typeError,
            key = key,
            info = info,
            code = code
        };
        ;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiModel"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> PostHttpsWithStatusCodeWithoutKeyReadData(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            ICoreAPIService coreApi = (ICoreAPIService)
                Activator.CreateInstance(
                    Type.GetType(
                        NameSpaceFlowApi
                            + ".Api"
                            + Utils.StringExtensions.CaptializeFirstLetterRemoveUnderScore(
                                learnApiModel.FlowApi
                            )
                    )
                );

            if (coreApi != null)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (
                    sender,
                    cert,
                    chain,
                    sslPolicyErrors
                ) =>
                {
                    return true;
                };

                HttpClient httpClient = new HttpClient(clientHandler);
                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                var pHeaders = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                    learnApiModel.LearnApiHeader
                );
                System.Console.WriteLine("LearnApiMapping=========="+ learnApiModel.LearnApiMapping);

                var LearnApiMapping=await coreApi.BuildRequest(learnApiModel.LearnApiMapping);
                System.Console.WriteLine("BuildRequest=========="+ LearnApiMapping);
                var requestContent = new StringContent(
                    await coreApi.BuildRequest(learnApiModel.LearnApiMapping),
                    Encoding.UTF8,
                    "application/json"
                );
                string content = await requestContent.ReadAsStringAsync();
                System.Console.WriteLine("requestContent=========="+ content);
                var requestMessage = new HttpRequestMessage(
                    new HttpMethod(learnApiModel.LearnApiMethod),
                    learnApiModel.LearnApiLink
                )
                {
                    Content = requestContent
                };
                foreach (var head in pHeaders)
                {
                    requestMessage.Headers.TryAddWithoutValidation(head.Key, head.Value);
                }
                timer.Start();
                var response = await httpClient.SendAsync(requestMessage);
                //Console.WriteLine("learnApiModel == " + learnApiModel.ToSerialize());
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return await BuildResponseWithCoreApiWithoutKeyReadData(
                        coreApi,
                        learnApiModel,
                        data
                    );
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        await ExtendPortalToken();
                        var response_retry = await CallAPIWithPortalToken(
                            coreApi,
                            learnApiModel,
                            context.InfoUser.GetUserLogin().PortalToken
                        );

                        var data_retry = await response_retry.Content.ReadAsStringAsync();

                        return await BuildResponseWithCoreApiWithoutKeyReadData(
                            coreApi,
                            learnApiModel,
                            data_retry
                        );
                    }
                    else
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        context.Bo.AddActionErrorAll(
                            BuildErrorStatusCode(data, response.StatusCode + "")
                        );
                        return null;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("PostHttps======" + ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="client"></param>
    /// <param name="pMethod"></param>
    /// <param name="pUrl"></param>
    /// <param name="pJsonContent"></param>
    /// <param name="pHeaders"></param>
    /// <returns></returns>
    private async Task<HttpResponseMessage> Request(
        HttpClient client,
        string pMethod,
        string pUrl,
        string pJsonContent,
        Dictionary<string, string> pHeaders
    )
    {
        var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.RequestUri = new Uri(pUrl);
        foreach (var head in pHeaders)
        {
            httpRequestMessage.Headers.TryAddWithoutValidation(head.Key, head.Value);
        }
        httpRequestMessage.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );

        switch (pMethod)
        {
            case "POST":
                httpRequestMessage.Method = HttpMethod.Post;

                HttpContent httpContent = new StringContent(
                    pJsonContent,
                    Encoding.UTF8,
                    "application/json"
                );
                httpRequestMessage.Content = httpContent;
                break;
            case "PUT":
                httpRequestMessage.Method = HttpMethod.Put;

                HttpContent httpContentPut = new StringContent(
                    pJsonContent,
                    Encoding.UTF8,
                    "application/json"
                );
                httpRequestMessage.Content = httpContentPut;
                break;
            default:
                httpRequestMessage.Method = HttpMethod.Get;
                break;
        }

        return await client.SendAsync(httpRequestMessage);
    }

    /// <summary>
    /// ** Call Rest API function
    /// </summary>
    /// <param name="path"></param>
    /// <param name="method"></param>
    /// <param name="content"></param>
    /// <param name="headerToken"></param>
    /// <returns></returns>
    private async Task<string> CallAPI(
        string path,
        string method,
        object content,
        string headerToken = ""
    )
    {
        try
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (
                sender,
                cert,
                chain,
                sslPolicyErrors
            ) =>
            {
                return true;
            };

            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            if (!string.IsNullOrEmpty(headerToken))
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + headerToken);

            var requestString = JsonConvert.SerializeObject(content);
            var requestContent = new StringContent(
                requestString,
                Encoding.Default,
                "application/json"
            );
            var requestMessage = new HttpRequestMessage(new HttpMethod(method), path)
            {
                Content = requestContent
            };
            var httpResponse = await httpClient.SendAsync(requestMessage);
            httpResponse.EnsureSuccessStatusCode();
            var result = await httpResponse.Content.ReadAsStringAsync();

            return result;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiModel"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> PostHttpWithStatusCode(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        await Task.CompletedTask;
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetNewNeptuneToken()
    {
        var requestPath = GetRestAPILink(
            "https://$API_SERVER$.$API_PORT_DATA$/api/auth/get-token",
            "ncbs"
        );
        // var requestPath = "https://neptuneserver:105/api/auth/get-token";
        var result = await CallAPI(
            requestPath,
            "POST",
            new { user_code = _cMSSetting.UserPortal, password = EngineContext.Current.Resolve<IEncryptionService>().DecryptText(_cMSSetting.PasswordPoral) }
        );
        var jsResult = JsonConvert.DeserializeObject<JObject>(result);
        var token = jsResult["data"]["token"].ToString();
        return token;
    }
    private async Task<string> GetNeptuneToken(string app)
    {
        var requestPath = GetRestAPILink(
            "https://$API_SERVER$.$API_PORT_DATA$/api/auth/get-token",
            app
        );
        // var requestPath = "https://neptuneserver:105/api/auth/get-token";
        var result = await CallAPI(
            requestPath,
            "POST",
            new { user_code = _cMSSetting.UserPortal, password = EngineContext.Current.Resolve<IEncryptionService>().DecryptText(_cMSSetting.PasswordPoral) }
        );
        var jsResult = JsonConvert.DeserializeObject<JObject>(result);
        var token = jsResult["data"]["token"].ToString();
        return token;
    }

    /// <summary>
    /// ///
    /// </summary>
    /// <param name="file"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public async Task<string> PostZipFileNeptune(IFormFile file, string app)
    {
        var requestPath = GetRestAPILink(
            "https://$API_SERVER$.$API_PORT_DATA$/api/workflow-definition/upload-workflow-zip-files",
            app
        );
        try
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (
                sender,
                cert,
                chain,
                sslPolicyErrors
            ) =>
            {
                return true;
            };
            var token = await GetNeptuneToken("ncbs");
            HttpClient httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept,
                "application/x-zip-compressed"
            );
            var multiPartStream = new MultipartFormDataContent();
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();

                multiPartStream.Add(new ByteArrayContent(fileBytes), "data", file.FileName);
            }

            var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), requestPath)
            {
                Content = multiPartStream
            };
            var httpResponse = await httpClient.SendAsync(requestMessage);
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = await httpResponse.Content.ReadAsStringAsync();
                return JToken.Parse(data).ToSerialize();
            }
            else
            {
                if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return "401";
                }
                else
                {
                    return "400";
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            Console.WriteLine("PostZipFileNeptune exceiption==" + ex.StackTrace);
            return "400";
            ;
        }
    }

    private static string ConvertToLowerCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input.Contains('{') || input.Contains('['))
            return input;

        bool containsUppercase = false;
        Parallel.For(0, input.Length, (i, state) =>
        {
            if (char.IsUpper(input[i]))
            {
                containsUppercase = true;
                state.Stop();
            }
        });

        if (!containsUppercase)
            return input;

        if (input.Length > 100)
        {
            return input;
        }

        if (IsAllUpper(input))
        {
            return input.ToLower();
        }

        if (IsDotSeparated(input))
        {
            int dotIndex = input.IndexOf('.');
            if (dotIndex >= 0 && dotIndex < input.Length - 1)
            {
                string result = input.Substring(0, dotIndex + 1) + input.Substring(dotIndex + 1).ToLower();
                return result;
            }
        }
        return input;
    }

    private static bool IsDotSeparated(string input)
    {
        int dotCount = 0;
        foreach (char c in input)
        {
            if (c == '.')
            {
                dotCount++;
                if (dotCount > 1)
                {
                    return false;
                }
            }
        }
        return dotCount == 1;
    }

    private static bool IsAllUpper(string input)
    {
        input = new string(input.Where(char.IsLetter).ToArray());

        return !string.IsNullOrEmpty(input) && input.All(char.IsUpper);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="obMapp_"></param>
    /// <param name="mapKey"></param>
    /// <param name="para"></param>
    /// <param name="app_"></param>
    /// <param name="uid"></param>
    /// <param name="dataMap"></param>
    /// <param name="learnApiData"></param>
    /// <param name="isO9Mapping"></param>
    /// <returns></returns>
    protected async Task<int> CallMapSAsync(
        JObject obMapp_,
        string mapKey,
        string para,
        string app_,
        string uid,
        JObject dataMap,
        string learnApiData,
        bool isO9Mapping = false
    )
    {
        var requestJson = context.InfoRequest.GetRequestJson();
        int startIndexFunc = 0;
        string function_ = para[startIndexFunc..para.IndexOf("(")];

        int startIndexFunctionPara = para.IndexOf("(") + 1;
        string functionPara = para[startIndexFunctionPara..para.LastIndexOf(")")];

        if (startIndexFunctionPara == para.LastIndexOf(")"))
        {
            functionPara = learnApiData + "." + mapKey;
        }
        if (isO9Mapping) 
            functionPara = ConvertToLowerCase(functionPara);

        var userLogin = context.InfoUser.GetUserLogin();
        try
        {
            switch (function_)
            {
                case "getLicenseToken":
                    var packApiGetToken = await GetNeptuneToken("ncbsLicense");
                    if (functionPara.Equals(""))
                        obMapp_[mapKey] = packApiGetToken;
                    else
                        obMapp_[mapKey] = functionPara + packApiGetToken;
                    break;
                case "getToken":
                    // var loginPortalResponse = await _authenticationGrpcService.GetAuthenticationToken(_cMSSetting.UserPortal, _cMSSetting.PasswordPortal);
                    // var dataLoginPortal = JObject.Parse(loginPortalResponse);
                    System.Console.WriteLine("userLogin.PortalToken===" + userLogin.PortalToken);
                    if (functionPara.Equals(""))
                        obMapp_[mapKey] = userLogin.PortalToken;
                    else
                        obMapp_[mapKey] = functionPara + userLogin.PortalToken;
                    break;
                case "context":
                    if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                    {
                        var loginResponseContext = await _adminService.GetUserAccountById(userLogin.UserId.ToString());
                        var loginResponseContext_ = loginResponseContext.ToDictionary();
                        var userLogin_ = userLogin.ToDictionary();

                        var mergeContext = Utils.Utils.MergeDictionary(
                            loginResponseContext_,
                            userLogin_
                        );
                        //Console.WriteLine("==mergeContext=" + JsonConvert.SerializeObject(mergeContext));
                        if (mergeContext != null)
                        {
                            var dataKey = JObject.FromObject(mergeContext).SelectToken(functionPara);
                            if (dataKey != null)
                                obMapp_[mapKey] = dataKey;
                            else
                                obMapp_[mapKey] = JObject
                                    .FromObject(mergeContext)
                                    .SelectToken(Utils.StringExtensions.ToUnderscoreCase(functionPara));
                        }
                    }
                    else
                    {
                        var loginResponseContext = await _adminGrpcService.GetUserAccountById(
                        userLogin.UserId.ToString()
                    );
                        var loginResponseContext_ = loginResponseContext.ToDictionary();
                        var userLogin_ = userLogin.ToDictionary();

                        var mergeContext = Utils.Utils.MergeDictionary(
                            loginResponseContext_,
                            userLogin_
                        );
                        //Console.WriteLine("==mergeContext=" + JsonConvert.SerializeObject(mergeContext));
                        if (mergeContext != null)
                        {
                            var dataKey = JObject.FromObject(mergeContext).SelectToken(functionPara);
                            if (dataKey != null)
                                obMapp_[mapKey] = dataKey;
                            else
                                obMapp_[mapKey] = JObject
                                    .FromObject(mergeContext)
                                    .SelectToken(Utils.StringExtensions.ToUnderscoreCase(functionPara));
                        }
                    }
                    break;
                case "dataFileJson":

                    var getFile = await _mediaUploadService.GetByUserIdAndFileName(
                        userLogin.UserId.ToString(),
                        dataMap.SelectToken(functionPara).ToString()
                    );

                    if (getFile != null)
                    {
                        byte[] byteArray = Convert.FromBase64String(getFile.MediaData);

                        string jsonBack = Encoding.UTF8.GetString(byteArray);
                        obMapp_[mapKey] = JsonConvert.DeserializeObject(jsonBack).ToJToken();
                    }
                    break;
                case "dataFile":
                    //Console.WriteLine("==file_name=" + dataMap.SelectToken(functionPara).ToString());
                    var getdataFile = await _mediaUploadService.GetByUserIdAndFileName(
                        userLogin.UserId.ToString(),
                        dataMap.SelectToken(functionPara).ToString()
                    );
                    //Console.WriteLine("==getFile=" + JsonConvert.SerializeObject(getdataFile));
                    if (getdataFile != null)
                    {
                        // byte[] byteArray = Convert.FromBase64String(getdataFile.MediaData);

                        // string jsonBack = Encoding.UTF8.GetString(byteArray);
                        //Console.WriteLine("==getdataFile.MediaData=" + getdataFile.MediaData);
                        obMapp_[mapKey] = getdataFile.MediaData;
                    }
                    break;
                case "dataFileBinary":
                    //Console.WriteLine("==file_name=" + dataMap.SelectToken(functionPara).ToString());
                    var getdataFile_ = await _mediaUploadService.GetByUserIdAndFileName(
                        userLogin.UserId.ToString(),
                        dataMap.SelectToken(functionPara).ToString()
                    );
                    //Console.WriteLine("==getFile=" + JsonConvert.SerializeObject(getdataFile));
                    if (getdataFile_ != null)
                    {
                        byte[] byteArray_ = Convert.FromBase64String(getdataFile_.MediaData);
                        System.Console.WriteLine("byteArray_" + byteArray_);
                        System.Console.WriteLine("getdataFile_.MediaData" + getdataFile_.MediaData);
                        // string jsonBack = Encoding.UTF8.GetString(byteArray);
                        //Console.WriteLine("==getdataFile.MediaData=" + getdataFile.MediaData);
                        obMapp_[mapKey] = byteArray_;
                    }
                    break;
                case "stringSplitArrayJson":
                    string[] para_stringSplitArrayJson = functionPara.Split(separator: "|");
                    string para_0 = para_stringSplitArrayJson[0];
                    string para_1 = para_stringSplitArrayJson[1];
                    var arr_json = dataMap.SelectToken(para_0);
                    if (arr_json != null)
                    {
                        try
                        {
                            obMapp_[mapKey] = "";
                            foreach (var item in arr_json.ToJArray())
                            {
                                obMapp_[mapKey] += item.SelectToken(para_1).ToString() + ";";
                            }
                        }
                        catch (System.Exception ex)
                        {
                            // TODO
                            System.Console.WriteLine(
                                "stringSplitArrayJson Error ===" + ex.ToString()
                            );
                            obMapp_[mapKey] = null;
                        }
                    }
                    break;
                case "arrayJson":
                    string[] para_convert = functionPara.Split(separator: "|");
                    string para_data = para_convert[0];
                    string para_arr = para_convert[1];

                    //JObject json_map = JObject.Parse(para_arr);
                    var data_arr = getDataJsonForKeyOfContext(para_data, dataMap);
                    if (data_arr != null)
                    {
                        if (data_arr is JArray)
                        {
                            JArray data_arr_is_array = data_arr.ToJArray();
                            JArray data_result = new JArray();
                            //Console.WriteLine("=====data_arr_is_array====="+JsonConvert.SerializeObject(data_arr_is_array));
                            for (int i = 0; i < data_arr_is_array.Count; i++)
                            {
                                var data_elm_arr = data_arr_is_array[i];
                                // Console.WriteLine("=====data_elm_arr====="+JsonConvert.SerializeObject(data_elm_arr));
                                var json_config_elm_arr = JToken
                                    .Parse(para_arr)
                                    .DeepClone()
                                    .ToJObject();

                                // JsonObject ob_new_aray =

                                json_config_elm_arr = LoopConfigMapping(
                                    ref json_config_elm_arr,
                                    app_,
                                    uid,
                                    data_elm_arr.ToJObject(),
                                    learnApiData
                                );
                                data_result.Add(json_config_elm_arr);
                            }
                            obMapp_[mapKey] = data_result;
                        }
                    }
                    else
                    {
                        obMapp_[mapKey] = new JArray();
                    }

                    break;
                case "mergeDataWithJson":
                    string[] para_json = functionPara.Split(separator: "|");
                    string json1Key = para_json[0];
                    string json2Config = para_json[1];

                    //JObject json_map = JObject.Parse(para_arr);
                    var json1 = getDataJsonForKeyOfContext(json1Key, dataMap);
                    var json2_config = JToken
                                    .Parse(json2Config)
                                    .DeepClone()
                                    .ToJObject();
                    var json2 = LoopConfigMapping(
                                    ref json2_config,
                                    app_,
                                    uid,
                                    dataMap,
                                    learnApiData
                                );
                    var new_json = new JObject();
                    if (json1 != null && json2.ToSerialize() != json2Config)
                        new_json = JObject.FromObject(Utils.Utils.MergeDictionary(json1.ToDictionary(), json2.ToDictionary()));
                    obMapp_[mapKey] = new_json;
                    break;
                case "arrayDynamic":
                    var array = dataMap.SelectToken(functionPara);
                    obMapp_[mapKey] = array;
                    break;
                case "arrayNumber":
                    string[] para_convert_number = functionPara.Split(separator: "|");
                    string para_data_number = para_convert_number[0];
                    string para_arr_number = para_convert_number[1];

                    //JObject json_map = JObject.Parse(para_arr);
                    var data_arr_number = getDataJsonForKeyOfContext(para_data_number, dataMap);
                    if (data_arr_number != null)
                    {
                        if (data_arr_number is JArray)
                        {
                            JArray data_result = new JArray();
                            var data_arr_is_array = data_arr_number.ToJArray();
                            for (int i = 0; i < data_arr_is_array.Count; i++)
                            {
                                var data_elm_arr = data_arr_is_array[i];
                                // Console.WriteLine("=====data_elm_arr====="+JsonConvert.SerializeObject(data_elm_arr));
                                if (data_elm_arr.ToJObject() != null)
                                {
                                    data_result.Add(data_elm_arr.SelectToken(para_arr_number));
                                }
                                else
                                    data_result.Add(data_elm_arr);
                            }
                            obMapp_[mapKey] = data_result;
                        }
                    }
                    else
                    {
                        obMapp_[mapKey] = new JArray();
                    }
                    break;

                case "dateYYYY-MM-DD":
                    if (!string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        long date1 = long.Parse(dataMap.SelectToken(functionPara).ToString());

                        obMapp_[mapKey] = Utils.Utils
                            .ConvertFromUnixTimestampMilisecond(date1, false)
                            .ToString("yyyy-MM-dd");
                    }
                    break;
                case "dateDD-MM-YYYY":
                    if (!string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        long date1 = long.Parse(dataMap.SelectToken(functionPara).ToString());
                        obMapp_[mapKey] = Utils.Utils
                            .ConvertFromUnixTimestampMilisecond(date1, false)
                            .ToString("dd-MM-yyyy");
                    }
                    break;
                case "date_dd-MM-yyyy":
                    if (!string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        DateTime date1 = DateTime.Parse(dataMap.SelectToken(functionPara).ToString());
                        obMapp_[mapKey] = date1
                            .ToString("dd/MM/yyyy");
                    }
                    break;
                case "date_dd-MM-yyyy_Null":
                    if (!string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        DateTime date1 = DateTime.Parse(dataMap.SelectToken(functionPara).ToString());
                        obMapp_[mapKey] = date1
                            .ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        obMapp_[mapKey] = null;
                    }
                    break;        
                case "date_yyyy-MM-dd":
                    if (!string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        DateTime date1 = DateTime.Parse(dataMap.SelectToken(functionPara).ToString());
                        obMapp_[mapKey] = date1
                            .ToString("yyyy/MM/dd");
                    }    
                    break;
                case "date_yyyy-MM-dd_Null":
                    if (!string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        DateTime date1 = DateTime.Parse(dataMap.SelectToken(functionPara).ToString());
                        obMapp_[mapKey] = date1
                            .ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        obMapp_[mapKey] = null;
                    }
                    break;    
                case "arrayString":
                    string[] para_convert_string = functionPara.Split(separator: "|");
                    string para_data_string = para_convert_string[0];
                    string para_arr_string = para_convert_string[1];

                    //JObject json_map = JObject.Parse(para_arr);
                    var data_arr_string = dataMap.SelectToken(para_data_string);
                    if (data_arr_string != null)
                    {
                        if (data_arr_string is JArray)
                        {
                            JArray data_result = new JArray();
                            var data_arr_is_array = data_arr_string.ToJArray();
                            for (int i = 0; i < data_arr_is_array.Count; i++)
                            {
                                var data_elm_arr = data_arr_is_array[i];
                                // Console.WriteLine("=====data_elm_arr====="+JsonConvert.SerializeObject(data_elm_arr));
                                if (Utils.Utils.IsValidJsonObject(data_elm_arr.ToSerialize()))
                                {
                                    data_result.Add(data_elm_arr.SelectToken(para_arr_string));
                                }
                                else
                                    data_result.Add(data_elm_arr);
                            }
                            obMapp_[mapKey] = data_result;
                        }
                        else
                        {
                            JArray data_result = new JArray();
                            if (Utils.Utils.IsValidJsonObject(data_arr_string.ToSerialize()))
                            {
                                data_result.Add(data_arr_string.SelectToken(para_arr_string));
                            }
                            obMapp_[mapKey] = data_result;
                        }
                    }
                    else
                    {
                        obMapp_[mapKey] = new JArray();
                    }
                    break;

                case "dataSumColumn":
                    string[] para_convert_num_sum = functionPara.Split("|");
                    string para_data_sum = para_convert_num_sum[0];
                    string para_arr_sum = para_convert_num_sum[1];

                    //JObject json_map = JObject.Parse(para_arr);
                    var data_arr_sum = dataMap.SelectToken(para_data_sum);
                    try
                    {
                        if (data_arr_sum != null)
                        {
                            if (data_arr_sum is JArray)
                            {
                                double data_result = 0;
                                var data_arr_is_array = data_arr_sum.ToJArray();
                                for (int i = 0; i < data_arr_is_array.Count; i++)
                                {
                                    var data_elm_arr = data_arr_is_array[i];
                                    Console.WriteLine("=====data_elm_arr=====" + JsonConvert.SerializeObject(data_elm_arr));
                                    if (data_elm_arr.ToJObject() != null)
                                    {
                                        data_result += double.Parse(data_elm_arr.SelectToken(para_arr_sum).ToString());
                                    }
                                    else
                                        data_result += double.Parse(data_elm_arr.ToString());
                                }
                                obMapp_[mapKey] = data_result;
                            }
                            else
                            {
                                double data_result = 0;
                                if (Utils.Utils.IsValidJsonObject(data_arr_sum.ToSerialize()))
                                {
                                    data_result += double.Parse(data_arr_sum.SelectToken(para_arr_sum).ToString());

                                }
                                obMapp_[mapKey] = data_result;
                            }
                        }
                        else
                        {
                            obMapp_[mapKey] = 0;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        // TODO
                        Console.WriteLine("=====exDatasum=====" + ex.StackTrace);

                    }

                    break;

                case "DataBoolean":
                    if (dataMap.SelectToken(functionPara) != null)
                        obMapp_[mapKey] = ((bool)dataMap.SelectToken(functionPara));
                    else
                        obMapp_[mapKey] = false;
                    break;
                case "dataNZero":
                    string rsNZero = "";
                    try
                    {
                        var data_ = dataMap.SelectToken(functionPara);
                        if (data_ != null)
                        {
                            if (!data_.ToString().Equals(""))
                            {
                                rsNZero = data_.ToString();
                            }
                        }
                        if (!rsNZero.Equals(""))
                            obMapp_[mapKey] = Double.Parse(rsNZero, CultureInfo.InvariantCulture);
                        else
                            obMapp_[mapKey] = 0;
                    }
                    catch (System.Exception)
                    {
                        obMapp_[mapKey] = 0;
                    }
                    // if (!rsNZero.Equals(""))
                    //     obMapp_[mapKey] = Double.Parse(rsNZero);
                    // else obMapp_[mapKey] = 0;
                    break;
                case "dataNZeroSub1":
                    string rsNZeroSub = "";
                    if (!dataMap.SelectToken(functionPara).ToString().Equals(""))
                        rsNZeroSub = dataMap.SelectToken(functionPara).ToString();
                    if (!rsNZeroSub.Equals(""))
                        obMapp_[mapKey] = Double.Parse(rsNZeroSub, CultureInfo.InvariantCulture) - 1;
                    else
                        obMapp_[mapKey] = 0.0;
                    break;
                case "dataIZeroSub1":
                    string rsIZeroSub = "";
                    if (!dataMap.SelectToken(functionPara).ToString().Equals(""))
                        rsIZeroSub = dataMap.SelectToken(functionPara).ToString();
                    if (!rsIZeroSub.Equals(""))
                        obMapp_[mapKey] = Int32.Parse(rsIZeroSub) - 1;
                    else
                        obMapp_[mapKey] = 0;
                    break;
                case "PageSizeDataDefault":
                    string rsPageSize = "";
                    if (!dataMap.SelectToken(functionPara).ToString().Equals(""))
                        rsPageSize = dataMap.SelectToken(functionPara).ToString();
                    if (!rsPageSize.Equals(""))
                        obMapp_[mapKey] = Int32.Parse(rsPageSize);
                    else
                        obMapp_[mapKey] = 5;
                    break;
                case "dataSelectNull":
                    var dataSelect = dataMap.SelectToken(functionPara).ToString();
                    if (dataSelect.Equals("select_null") || dataSelect.Equals("All"))
                        obMapp_[mapKey] = "";
                    else
                        obMapp_[mapKey] = dataSelect;
                    break;
                case "dataSelectOneNull":
                    try
                    {
                        if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                            obMapp_[mapKey] = null;
                        else
                            obMapp_[mapKey] = dataMap.SelectToken(functionPara);
                    }
                    catch (System.Exception)
                    {
                        // TODO
                        obMapp_[mapKey] = null;
                    }
                    break;
                case "dataSelectINull":
                    var dataSelectINull = dataMap.SelectToken(functionPara).ToString();
                    if (dataSelectINull.Equals("select_null"))
                        obMapp_[mapKey] = null;
                    else
                        obMapp_[mapKey] = Int32.Parse(dataSelectINull);
                    break;
                case "dataS":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                        obMapp_[mapKey] = "";
                    else
                        obMapp_[mapKey] = dataMap.SelectToken(functionPara);
                    break;
                case "dataSNull":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                        obMapp_[mapKey] = null;
                    else
                        obMapp_[mapKey] = dataMap.SelectToken(functionPara);
                    break;
                case "dataSTrim":
                    var selectedToken = dataMap.SelectToken(functionPara)?.ToString()?.Trim();
                    if (string.IsNullOrEmpty(selectedToken))
                        obMapp_[mapKey] = "";
                    else
                        obMapp_[mapKey] = selectedToken;
                    break;
                case "dataN":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                    {
                        obMapp_[mapKey] = 0;
                    }
                    else
                    {
                        var tokenMap = dataMap.SelectToken(functionPara);
                        var stringMap = tokenMap?.ToString();
                        var valueMap = Convert.ToDouble(tokenMap);
                        obMapp_[mapKey] = valueMap;
                    }
                    break;
                case "dataL":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                        obMapp_[mapKey] = 0;
                    else
                        obMapp_[mapKey] = Int64.Parse(
                            dataMap.SelectToken(functionPara)?.ToString()
                        );
                    break;
                case "dataI":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                        obMapp_[mapKey] = 0;
                    else
                        obMapp_[mapKey] = Int32.Parse(
                            dataMap.SelectToken(functionPara)?.ToString()
                        );
                    break;
                case "dataINull":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                        obMapp_[mapKey] = null;
                    else
                        obMapp_[mapKey] = Int32.Parse(
                            dataMap.SelectToken(functionPara)?.ToString()
                        );
                    break;
                case "dataIZero":
                    try
                    {
                        if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                            obMapp_[mapKey] = 0;
                        else
                            obMapp_[mapKey] = Int32.Parse(
                                dataMap.SelectToken(functionPara)?.ToString()
                            );
                    }
                    catch (System.Exception ex)
                    {
                        // TODO
                        System.Console.WriteLine(ex.StackTrace);
                        obMapp_[mapKey] = 0;
                    }
                    break;
                case "dataNNull":
                    if (string.IsNullOrEmpty(dataMap.SelectToken(functionPara)?.ToString()))
                        obMapp_[mapKey] = null;
                    else
                        obMapp_[mapKey] = Double.Parse(dataMap.SelectToken(functionPara)?.ToString(), CultureInfo.InvariantCulture);
                    break;
                case "dataLongNumber":
                var stringValue=dataMap.SelectToken(functionPara)?.ToString();
                System.Console.WriteLine("dataLongNumber===="+stringValue);
                    if (string.IsNullOrEmpty(stringValue))
                        obMapp_[mapKey] = 0;
                    else if (Decimal.TryParse(stringValue, out decimal decimalValue))
                    {
                        System.Console.WriteLine("dataLongNumber====decimalValue===="+decimalValue);
                        obMapp_[mapKey] =  decimalValue;
                    }
                       
                    break;
                case "dataJsonObject":
                    var dataObj = dataMap.SelectToken(functionPara);
                    if (dataObj != null)
                        obMapp_[mapKey] = JObject.FromObject(dataObj);
                    else
                        obMapp_[mapKey] = new JObject();
                    break;
                case "dataJsonArray":
                    var dataObjArray = dataMap.SelectToken(functionPara);
                    if (dataObjArray != null)
                        obMapp_[mapKey] = JArray.FromObject(dataObjArray);
                    else
                        obMapp_[mapKey] = new JArray();
                    break;
                case "stringSplit":
                    var datastringSplit = dataMap.SelectToken(functionPara).ToJArray();
                    if (datastringSplit != null)
                    {
                        obMapp_[mapKey] = "";
                        foreach (var item in datastringSplit)
                            obMapp_[mapKey] += item.ToString() + ";";
                    }
                    else
                        obMapp_[mapKey] = "";
                    break;
                case "infoRequest":
                    if (userLogin != null)
                    {
                        var dataKey = JObject.FromObject(userLogin).SelectToken(functionPara);
                        if (dataKey != null)
                            obMapp_[mapKey] = dataKey;
                        else
                            obMapp_[mapKey] = JObject
                                .FromObject(userLogin)
                                .SelectToken(Utils.StringExtensions.ToTitleCase(functionPara));
                    }
                    break;
                case "dataSerializeJson":
                    var dataSerializeJson = dataMap.SelectToken(functionPara);
                    if (dataSerializeJson != null)
                        obMapp_[mapKey] = JObject.Parse(dataSerializeJson.ToString());
                    else
                        obMapp_[mapKey] = new JObject();
                    break;
                case "SerializeJArray":
                    var dataSerializeJArray = dataMap.SelectToken(functionPara);
                    if (dataSerializeJArray != null)
                        obMapp_[mapKey] = JArray.Parse(dataSerializeJArray.ToString());
                    else
                        obMapp_[mapKey] = new JArray();
                    break;
                case "getNewToken":
                    if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
                    {
                        var newToken = await _adminService.CreateOtherToken(
                            context.InfoUser.GetUserLogin().Token
                        );
                        if (newToken != null)
                            obMapp_[mapKey] = newToken;
                    }
                    else
                    {
                        var newToken = await _adminGrpcService.CreateOtherToken(
                            context.InfoUser.GetUserLogin().Token
                        );
                        if (newToken != null)
                            obMapp_[mapKey] = newToken;
                    }
                    break;
                case "ToSerialize":
                    var ToSerialize = dataMap.SelectToken(functionPara);
                    if (ToSerialize != null)
                        obMapp_[mapKey] = ToSerialize.ToSerialize();
                    else
                        obMapp_[mapKey] = new JObject().ToSerialize();
                    break;
                case "stringObject":
                    var arr = functionPara.Split(".");
                    if (!string.IsNullOrEmpty(arr[0]) && !string.IsNullOrEmpty(arr[1]))
                    {
                        var obj = dataMap.SelectToken(arr[0]);
                        if (obj != null)
                        {
                            var jdata = JObject.Parse(obj.ToString()).ConvertToJObject();
                            obMapp_[mapKey] = jdata.SelectToken(arr[1]);
                        }
                    }
                    break;
                case "userSession":
                    var requestHeader = context?.InfoUser.GetUserLogin();
                    var user = EngineContext.Current.Resolve<IMemoryCache>().Get<UserSessions>(requestHeader.Token);
                    if (user != null)
                    {
                        var property = user.GetType().GetProperties()
                            .FirstOrDefault(key => key.Name.ToLower() == functionPara.ToLower());
                        if (property != null)
                        {
                            obMapp_[mapKey] = property.GetValue(user).ToJToken();
                        }
                    }
                    else
                    {
                        obMapp_[mapKey] = null;
                    }
                    break;
                default:
                    break;
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            Console.WriteLine("MapS exceiption==" + ex.StackTrace);
            return -1;
        }
        return 1;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="data_key"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    protected JToken getDataJsonForKeyOfContext(string data_key, JObject data)
    {
        if (data_key.Contains("."))
        {
            string[] s_ = data_key.Split(separator: ".");
            if (s_.Length > 0)
            {
                var ob_loop = data;
                for (int i = 0; i < s_.Length; i++)
                {
                    if (i == (s_.Length - 1))
                    {
                        // vÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¹ trÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â­ cuÃƒÆ’Ã‚Â¡Ãƒâ€šÃ‚Â»ÃƒÂ¢Ã¢â€šÂ¬Ã‹Å“i cÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¹ng
                        return ob_loop.GetValue(s_[i]);
                    }
                    else if (ob_loop.ContainsKey(s_[i]))
                    {
                        // ÃƒÆ’Ã¢â‚¬Å¾ÃƒÂ¢Ã¢â€šÂ¬Ã‹Å“i nÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â o
                        ob_loop = ob_loop.GetValue(s_[i]).ToJObject();
                    }
                }
            }
        }
        else
        {
            if (data.ContainsKey(data_key))
                return data.GetValue(data_key);
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obMapp_"></param>
    /// <param name="mapKey"></param>
    /// <param name="para"></param>
    /// <param name="app_"></param>
    /// <param name="uid"></param>
    /// <param name="dataMap"></param>
    /// <param name="learnApiData"></param>
    /// <param name="isO9Mapping"></param>
    /// <returns></returns>
    protected Task<int> CallMapS(
        ref JObject obMapp_,
        string mapKey,
        string para,
        string app_,
        string uid,
        JObject dataMap,
        string learnApiData,
        bool isO9Mapping = false
    )
    {
        return CallMapSAsync(obMapp_, mapKey, para, app_, uid, dataMap, learnApiData, isO9Mapping);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obMapp_"></param>
    /// <param name="appRequest"></param>
    /// <param name="uid"></param>
    /// <param name="dataMap"></param>
    /// <param name="learnApiData"></param>
    /// <param name="isO9Mapping"></param>
    /// <returns></returns>
    public JObject LoopConfigMapping(
        ref JObject obMapp_,
        string appRequest,
        string uid,
        JObject dataMap,
        string learnApiData,
        bool isO9Mapping = false
    )
    {
        var requestJson = context.InfoRequest.GetRequestJson();
        try
        {
            foreach (var itemObMap_ in obMapp_)
            {
                if (itemObMap_.Value != null)
                {
                    if (Utils.Utils.IsValidJsonArray(itemObMap_.Value.ToString())) { }
                    else if (Utils.Utils.IsValidJsonObject(itemObMap_.Value.ToString()))
                    {
                        JObject newObMap = JObject.FromObject(itemObMap_.Value);
                        obMapp_[itemObMap_.Key] = LoopConfigMapping(
                            ref newObMap,
                            appRequest,
                            uid,
                            dataMap,
                            learnApiData,
                            isO9Mapping
                        );
                    }
                    else
                    {
                        string rs_ = itemObMap_.Value.ToString();
                        if (rs_ != null)
                        {
                            rs_ = rs_.Trim();
                            if (rs_.Contains("MapS."))
                            {
                                rs_ = rs_.ReplaceFirst("MapS.", "");
                                int iRs = CallMapS(
                                        ref obMapp_,
                                        itemObMap_.Key,
                                        rs_,
                                        appRequest,
                                        uid,
                                        dataMap,
                                        learnApiData,
                                        isO9Mapping
                                    )
                                    .GetAwaiter()
                                    .GetResult();
                                // if (iRs == -1) obMapp_.Remove(itemObMap_.Key);
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("LoopConfigMapping exception()==" + ex.StackTrace);
        }

        return obMapp_;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obMapp_"></param>
    /// <param name="appRequest"></param>
    /// <param name="uid"></param>
    /// <param name="dataMap"></param>
    /// <param name="learnApiData"></param>
    /// <param name="isO9Mapping"></param>
    /// <returns></returns>
    public JArray LoopConfigMappingArray(
        ref JArray obMapp_,
        string appRequest,
        string uid,
        JObject dataMap,
        string learnApiData,
        bool isO9Mapping = false
    )
    {
        // System.Console.WriteLine("obMapp_obMapp_LoopConfigMapping==" + JsonConvert.SerializeObject(obMapp_));

        var requestJson = context.InfoRequest.GetRequestJson();
        try
        {
            for (var i = 0; i < obMapp_.Count; i++)
            {
                var itemObmapInstance = obMapp_[i].ToJObject();
                foreach (var itemObMap_ in itemObmapInstance)
                {
                    if (itemObMap_.Value != null)
                    {
                        if (Utils.Utils.IsValidJsonArray(itemObMap_.Value.ToString())) { }
                        else if (Utils.Utils.IsValidJsonObject(itemObMap_.Value.ToString()))
                        {
                            JObject newObMap = JObject.FromObject(itemObMap_.Value);
                            obMapp_[itemObMap_.Key] = LoopConfigMapping(
                                ref newObMap,
                                appRequest,
                                uid,
                                dataMap,
                                learnApiData,
                                isO9Mapping
                            );
                        }
                        else
                        {
                            string rs_ = itemObMap_.Value.ToString();
                            if (rs_ != null)
                            {
                                rs_ = rs_.Trim();
                                if (rs_.Contains("MapS."))
                                {
                                    rs_ = rs_.Replace("MapS.", "");
                                    int iRs = CallMapS(
                                            ref itemObmapInstance,
                                            itemObMap_.Key,
                                            rs_,
                                            appRequest,
                                            uid,
                                            dataMap,
                                            learnApiData,
                                            isO9Mapping
                                        )
                                        .GetAwaiter()
                                        .GetResult();
                                    obMapp_[i] = itemObmapInstance;

                                    // if (iRs == -1) obMapp_.Remove(itemObMap_.Key);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("LoopConfigMapping exception()==" + ex.StackTrace);
        }

        return obMapp_;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="link"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public string GetRestAPILink(string link, string app)
    {
        var gatewayInfo = _cMSSetting.AppGatewaySetting;
        if (gatewayInfo != null)
        {
            var gatewayInfoByApp = gatewayInfo.GetValueOrDefault(app);
            string apiLinkSuffix = "";
            string apiPortDataKey = "$API_PORT_DATA$";
            string apiPortLoginKey = "$API_PORT_LOGIN";
            string importIpKey = "$IMP_API_URL$";
            string reportIpKey = "$RPM_API_URL$";
            if (link.IndexOf(apiPortDataKey) != -1)
            {
                apiLinkSuffix = link[
                    ((byte)(link.IndexOf(apiPortDataKey) + apiPortDataKey.Length + 1))..link.Length
                ];
                link = gatewayInfoByApp.IP + ":" + gatewayInfoByApp.PortData + "/" + apiLinkSuffix;
            }
            else if (link.IndexOf(apiPortLoginKey) != -1)
            {
                apiLinkSuffix = link[
                    (
                        (byte)(link.IndexOf(apiPortLoginKey) + apiPortLoginKey.Length + 1)
                    )..link.Length
                ];
                link = gatewayInfoByApp.IP + ":" + gatewayInfoByApp.PortLogin + "/" + apiLinkSuffix;
            }
            else if (link.IndexOf(importIpKey) != -1)
            {
                apiLinkSuffix = link[
                    ((byte)(link.IndexOf(importIpKey) + importIpKey.Length + 1))..link.Length
                ];
                link = _cMSSetting.ImportApiUrl + apiLinkSuffix;
            }
            else if (link.IndexOf(reportIpKey) != -1)
            {
                apiLinkSuffix = link[
                    ((byte)(link.IndexOf(reportIpKey) + reportIpKey.Length + 1))..link.Length
                ];
                link = _cMSSetting.ReportApiUrl + apiLinkSuffix;
            }
        }
        return link;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApi"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    public async Task<LearnApiModel> TxMapData(string learnApi, JObject dataMap, string appRequest)
    {
        var learnApiContent = await _learnApiService.GetByAppAndId(appRequest, learnApi);
        if (learnApiContent != null)
        {
            var uid = context.InfoUser.GetUserLogin().Token;

            try
            {
                if (learnApiContent.LearnApiMapping != null)
                {
                    string strLearnApiMapping = learnApiContent.LearnApiMapping.Trim();

                    string learnApiData = "";
                    if (!string.IsNullOrEmpty(learnApiContent.LearnApiData))
                        learnApiData = learnApiContent.LearnApiData;

                    // strLearnApiMapping = strLearnApiMapping.Replace("pdatap", learnApiData);
                    LearnApiModel obPackApi = learnApiContent;

                    if (Utils.Utils.IsValidJsonObject(learnApiContent.LearnApiMapping.Trim()))
                    {
                        JObject obMapp_ = JsonConvert
                            .DeserializeObject(learnApiContent.LearnApiMapping.Trim())
                            .ToJObject();

                        if (obMapp_ == null)
                            obMapp_ = new JObject();

                        LoopConfigMapping(ref obMapp_, appRequest, uid, dataMap, learnApiData);
                        //body
                        obPackApi.LearnApiMapping = JsonConvert.SerializeObject(obMapp_);
                    }
                    else if (Utils.Utils.IsValidJsonArray(learnApiContent.LearnApiMapping.Trim()))
                    {
                        JArray obMapp_ = JArray.FromObject(
                            JsonConvert.DeserializeObject(learnApiContent.LearnApiMapping.Trim())
                        );

                        if (obMapp_ == null)
                            obMapp_ = new JArray();

                        LoopConfigMappingArray(ref obMapp_, appRequest, uid, dataMap, learnApiData);
                        //body
                        obPackApi.LearnApiMapping = JsonConvert.SerializeObject(obMapp_);
                    }

                    //header
                    if (!string.IsNullOrEmpty(learnApiContent.LearnApiHeader))
                    {
                        JObject headerApi = JsonConvert.DeserializeObject<JObject>(
                            learnApiContent.LearnApiHeader
                        );
                        LoopConfigMapping(ref headerApi, appRequest, uid, dataMap, learnApiData);

                        obPackApi.LearnApiHeader = JsonConvert.SerializeObject(headerApi);
                    }
                    else
                        obPackApi.LearnApiHeader = null;

                    //method

                    //rest url
                    var getLinkApi = GetRestAPILink(learnApiContent.LearnApiLink, appRequest);
                    if (getLinkApi != "")
                    {
                        getLinkApi = ReplaceData(getLinkApi, dataMap);
                    }
                    obPackApi.LearnApiLink = getLinkApi;

                    return obPackApi;
                }
            }
            catch (System.Exception ex)
            {
                if ((bool)context.InfoUser.GetUserLogin().isDebug)
                {
                    JObject errorApi = new JObject();
                    errorApi.Add(new JProperty("data", learnApiContent.LearnApiMapping));
                    errorApi.Add(new JProperty("mess", "Cant not parse learn_api_mapping"));
                    errorApi.Add(new JProperty("function", "BasicAction.txMapData"));
                    context.Bo.AddPackFo("error_api", errorApi);
                }
                // TODO
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="learnApi"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    public async Task<string> TxMapDataOutPut(string learnApi, JObject dataMap, string appRequest)
    {
        var learnApiContent = await _learnApiService.GetByAppAndId(appRequest, learnApi);
        if (learnApiContent != null)
        {
            try
            {
                if (learnApiContent.LearnApiMappingResponse != null)
                {
                    string learnApiData = "";
                    if (!string.IsNullOrEmpty(learnApiContent.LearnApiData))
                        learnApiData = learnApiContent.LearnApiData;

                    // strLearnApiMapping = strLearnApiMapping.Replace("pdatap", learnApiData);
                    var obPackApi = learnApiContent.LearnApiMappingResponse;

                    if (Utils.Utils.IsValidJsonObject(learnApiContent.LearnApiMappingResponse.Trim()))
                    {
                        JObject obMapp_ = JsonConvert
                            .DeserializeObject(learnApiContent.LearnApiMappingResponse.Trim())
                            .ToJObject();

                        if (obMapp_ == null)
                            obMapp_ = new JObject();

                        LoopConfigMapping(ref obMapp_, appRequest, "", dataMap, learnApiData);
                        //body
                        obPackApi = JsonConvert.SerializeObject(obMapp_);
                    }
                    else if (Utils.Utils.IsValidJsonArray(learnApiContent.LearnApiMappingResponse.Trim()))
                    {
                        JArray obMapp_ = JArray.FromObject(
                            JsonConvert.DeserializeObject(learnApiContent.LearnApiMappingResponse.Trim())
                        );

                        if (obMapp_ == null)
                            obMapp_ = new JArray();

                        LoopConfigMappingArray(ref obMapp_, appRequest, "", dataMap, learnApiData);
                        //body
                        obPackApi = JsonConvert.SerializeObject(obMapp_);
                    }

                    return obPackApi;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }
        return null;
    }

    private string ReplaceData(string para, JObject data)
    {
        if (para == null || data == null)
            return "";

        string pattern = "@\\{([^\\{]*)\\}";

        foreach (Match match in Regex.Matches(para, pattern))
        {
            if (match.Success && match.Groups.Count > 0)
            {
                var text = match.Groups[1].Value;
                para = para.Replace(match.Groups[0].Value, data.SelectToken(text).ToString());
            }
        }
        return para;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiMapping"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    public async Task<JObject> TxMapDataBody(
        string learnApiMapping,
        JObject dataMap,
        string appRequest
    )
    {
        JObject bodyResult = new JObject();

        try
        {
            var obMapp = JObject.Parse(learnApiMapping);
            if (obMapp == null)
                obMapp = new JObject();

            LoopConfigMapping(
                ref obMapp,
                appRequest,
                context.InfoUser.GetUserLogin().Token,
                dataMap,
                ""
            );
            await Task.CompletedTask;
            return obMapp;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("exception TxMapDataBody===" + ex.StackTrace);
        }
        return null;
    }

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
            if (boInput != null)
            {
                if (boInput.ContainsKey("learn_api"))
                {
                    string learnApi__ = boInput.GetValue("learn_api").ToString();
                    var arrLearnApi = learnApi__
                        .Split(';')
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToArray();
                    learnApi__ = arrLearnApi[0];

                    JObject obDataForMap = boInput;

                    if (obDataForMap.ContainsKey("data_select"))
                        obDataForMap = JObject.FromObject(obDataForMap["data_select"]);
                    System.Console.WriteLine("learnApi__" + learnApi__);
                    System.Console.WriteLine("appCodeRequest" + appCodeRequest);

                    var ob_ = await TxMapData(learnApi__, obDataForMap, appCodeRequest);
                    if (ob_ != null)
                    {
                        JToken obRss = null;
                        if (ob_.LearnApiLink.Contains("https://"))
                            obRss = await PostHttpsWithStatusCode(ob_, actionName, context);
                        else
                            obRss = await PostHttpWithStatusCode(ob_, actionName, context);
                        if (ob_ != null)
                            return obRss;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> GetDataPostAPIDownload(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            var boInput = context.Bo.GetBoInput();
            if (boInput != null)
            {
                if (boInput.ContainsKey("learn_api"))
                {
                    string learnApi__ = boInput.GetValue("learn_api").ToString();
                    var arrLearnApi = learnApi__
                        .Split(';')
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToArray();
                    learnApi__ = arrLearnApi[0];

                    JObject obDataForMap = boInput;

                    if (obDataForMap.ContainsKey("data_select"))
                        obDataForMap = JObject.FromObject(obDataForMap["data_select"]);
                    System.Console.WriteLine("learnApi__" + learnApi__);
                    System.Console.WriteLine("appCodeRequest" + appCodeRequest);

                    var ob_ = await TxMapData(learnApi__, obDataForMap, appCodeRequest);
                    if (ob_ != null)
                    {
                        JToken obRss = null;
                        if (ob_.LearnApiLink.Contains("https://"))
                            obRss = await PostHttpsWithStatusCodeDownload(ob_, actionName, context);
                        else
                            obRss = await PostHttpWithStatusCode(ob_, actionName, context);
                        if (ob_ != null)
                            return obRss;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> GetDataPostAPIUploadMasterFile(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            var boInput = context.Bo.GetBoInput();
            if (boInput != null)
            {
                if (boInput.ContainsKey("learn_api"))
                {
                    string learnApi__ = boInput.GetValue("learn_api").ToString();
                    var arrLearnApi = learnApi__
                        .Split(';')
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToArray();
                    learnApi__ = arrLearnApi[0];

                    JObject obDataForMap = boInput;

                    if (obDataForMap.ContainsKey("data_select"))
                        obDataForMap = JObject.FromObject(obDataForMap["data_select"]);
                    System.Console.WriteLine("learnApi__" + learnApi__);
                    System.Console.WriteLine("appCodeRequest" + appCodeRequest);

                    var ob_ = await TxMapData(learnApi__, obDataForMap, appCodeRequest);

                    if (ob_ != null)
                    {
                        JToken obRss = null;
                        if (ob_.LearnApiLink.Contains("https://"))
                            obRss = await PostHttpsWithStatusCodeUploadMasterFile(
                                ob_,
                                actionName,
                                context
                            );
                        else
                            obRss = await PostHttpsWithStatusCodeUploadMasterFile(
                                ob_,
                                actionName,
                                context
                            );
                        if (ob_ != null)
                            return obRss;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<JToken> GetDataPostAPIWithoutKeyReadData(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    )
    {
        try
        {
            var boInput = context.Bo.GetBoInput();
            if (boInput != null)
            {
                if (boInput.ContainsKey("learn_api"))
                {
                    string learnApi__ = boInput.GetValue("learn_api").ToString();
                    var arrLearnApi = learnApi__
                        .Split(';')
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToArray();
                    learnApi__ = arrLearnApi[0];

                    JObject obDataForMap = boInput;

                    if (obDataForMap.ContainsKey("data_select"))
                        obDataForMap = JObject.FromObject(obDataForMap["data_select"]);
                    System.Console.WriteLine("learnApi__" + learnApi__);
                    System.Console.WriteLine("appCodeRequest" + appCodeRequest);
                    System.Console.WriteLine("obDataForMap" + obDataForMap.ToSerialize());
                    System.Console.WriteLine("learnApi__" + learnApi__.ToSerialize());

                    var ob_ = await TxMapData(learnApi__, obDataForMap, appCodeRequest);
                    System.Console.WriteLine("ob_" + ob_.ToSerialize());

                    if (ob_ != null)
                    {
                        JToken obRss = null;
                        if (ob_.LearnApiLink.Contains("https://"))
                            obRss = await PostHttpsWithStatusCodeWithoutKeyReadData(
                                ob_,
                                actionName,
                                context
                            );
                        else
                            obRss = await PostHttpWithStatusCode(ob_, actionName, context);

                        return obRss;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
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
    public async Task<JToken> CallAPIAsync(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context,
        string learn_api
    )
    {
        try
        {
            var boInput = context.Bo.GetBoInput();
            if (boInput != null)
            {
                if (learn_api != "")
                {
                    string learnApi__ = learn_api;
                    var arrLearnApi = learnApi__
                        .Split(';')
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToArray();
                    learnApi__ = arrLearnApi[0];

                    JObject obDataForMap = boInput;

                    if (obDataForMap.ContainsKey("data_select"))
                        obDataForMap = JObject.FromObject(obDataForMap["data_select"]);
                    System.Console.WriteLine("learnApi__" + learnApi__);
                    System.Console.WriteLine("appCodeRequest" + appCodeRequest);

                    var ob_ = await TxMapData(learnApi__, obDataForMap, appCodeRequest);

                    if (ob_ != null)
                    {
                        JToken obRss = null;
                        if (ob_.LearnApiLink.Contains("https://"))
                            obRss = await PostHttpsWithStatusCodeWithoutKeyReadData(
                                ob_,
                                actionName,
                                context
                            );
                        else
                            obRss = await PostHttpWithStatusCode(ob_, actionName, context);

                        return obRss;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
        }
        return null;
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
