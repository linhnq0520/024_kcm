using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Services.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class WebchannelController : BaseController
{
    #region Fields
    readonly IWebchannelService _webchannelService;
    readonly IPostAPIService _postAPIService;
    readonly ILocalizationService _localizationService;
    readonly ILogServiceService _logServiceService;
    readonly ILogger _logger;
    private readonly PortalApiHttpClient _portalClient;
    private readonly CMSSetting _cmsSetting;

    string NeptuneHttpURL = Singleton<AppSettings>.Instance
        .Get<NeptuneConfiguration>()
        .NeptuneHttpURL;

    #endregion
    /// <summary>
    /// Ctor
    /// </summary>
    public WebchannelController(
        IWebchannelService webchannelService,
         IPostAPIService postAPIService,
        ILocalizationService localizationService,
        ILogger logger,
        ILogServiceService logServiceService,
        PortalApiHttpClient portalApiHttpClient,
        CMSSetting cMSSetting
    )
    {
        _webchannelService = webchannelService;
        _localizationService = localizationService;
        _logger = logger;
        _logServiceService = logServiceService;
        _portalClient = portalApiHttpClient;
        _cmsSetting = cMSSetting;
        _postAPIService = postAPIService;
        if (Singleton<ListExecuteModel>.Instance == null)
            Singleton<ListExecuteModel>.Instance = new ListExecuteModel();
    }

    /// <summary>
    /// Get config-client
    /// </summary>
    /// <returns>IActionResult.</returns>
    [HttpGet]
    public virtual async Task<IActionResult> ConfigClient()
    {
        var config_client = await _webchannelService.GetConfigClient();
        return new ContentResult
        {
            Content = "window.mainstart = " + config_client.ToString(),
            ContentType = "text/html"
        };
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<IActionResult> TemplateDynamic()
    {
        var config_client = await _webchannelService.GetHTMLDynamic(
            HttpContext.Request.Host.ToString(),
            HttpContext.Request.Scheme
        );

        return new ContentResult { Content = config_client, ContentType = "text/html" };
    }

    /// <summary>
    /// Post
    /// </summary>
    /// <param name="bo">.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] BoRequestModel bo)
    {
        //   System.Console.WriteLine(
        //     "begin Post txcode ======"+bo.Bo + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
        // );
        
        var response = await _webchannelService.StartRequest(bo, HttpContext);
        var getAllCookies = Utils.Utils.GetCookies(HttpContext);
        bool checkedSession = false;
        if (!getAllCookies.ContainsKey("device_id"))
        {
            checkedSession = true;
        }
        else
        {
            var oldCookie = getAllCookies["device_id"].ToString();
            if (oldCookie != EngineContext.Current.Resolve<JWebUIObjectContextModel>().InfoRequest.DeviceID)
                checkedSession = true;
        }
        // foreach (var item in getAllCookies)
        // {
        //     HttpContext.Response.Cookies.Append(item.Key, item.Value, new CookieOptions()
        //     {
        //         HttpOnly = true,
        //         SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
        //         Secure = true,
        //     });
        // }

        if (checkedSession
            && !string.IsNullOrEmpty(EngineContext.Current.Resolve<JWebUIObjectContextModel>().InfoRequest.DeviceID))
            HttpContext.Response.Cookies.Append(
                "device_id",
                EngineContext.Current.Resolve<JWebUIObjectContextModel>().InfoRequest.DeviceID,
                new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                    Secure = true,
                    Expires = EngineContext.Current
                        .Resolve<JWebUIObjectContextModel>()
                        .InfoRequest.SessionExpired
                }
            );

        // System.Console.WriteLine(
        //     "done Post txcode ======" + DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
        // );
        return Ok(response);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="formDataUpload"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(UploadResponseModel), StatusCodes.Status200OK)]
    public virtual async Task<IActionResult> UploadFile(
        [FromForm] FormDataUploadModel formDataUpload
    )
    {
        var response = await _webchannelService.UploadFile(formDataUpload, HttpContext);

        return Ok(response);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<IActionResult> UploadFileZipNeptune(IFormFile file)
    {
        System.Console.WriteLine("formDataUpload===>" + file.ToSerialize());

        var response = await _webchannelService.UploadFileZipNeptune(file);
        if (response == "401")
            return Unauthorized();
        if (response == "400")
            return BadRequest();
        return Ok(response);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<IActionResult> BuildMenuModuleForm()
    {
        await _webchannelService.BuildMenuModuleForm();
        return Ok("response");
    }

    /// <summary>
    /// GenDataMigrationBo
    /// </summary>
    /// <param name="path">MigrationFromFile.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public virtual async Task<IActionResult> MigrationFromFile(string path)
    {
        var arr_rs = await _webchannelService.MigrationFromFile(path);

        return Ok(arr_rs.ToString());
    }

    /// <summary>
    /// Copy to app Jwebui
    /// </summary>
    /// <param name="from_app">CopyFromApp.</param>
    /// <param name="to_app">CopyToApp.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public virtual async Task<IActionResult> CopyAppTo(string from_app, string to_app)
    {
        var arr_rs = await _webchannelService.CopyAppTo(from_app, to_app);

        return Ok(arr_rs.ToString());
    }

    /// <summary>
    /// GenDataMigrationBo
    /// </summary>
    /// <param name="path">GenDataMigrationBo.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public virtual async Task<IActionResult> MigrationCdlist(string path)
    {
        var arr_rs = await _webchannelService.MigrationCdlist(path);

        return Ok(arr_rs.ToString());
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="workflow_id"></param>
    /// <param name="wf"></param>
    /// <returns></returns>
    [HttpPost("/api/workflow/execute/{workflow_id}")]
    public virtual async Task<IActionResult> ExecuteWorkflow(
        string workflow_id,
        [FromBody] WorkflowExecuteModel wf
    )
    {
        try
        {
            var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
            _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();

            wf.workflowid = workflow_id;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        try
        {
            var execution_obj = await _portalClient.CallAPI(
                             $"{NeptuneHttpURL}api/workflow/execute/",
                             "POST",
                             wf
                         );

            if (!string.IsNullOrEmpty(execution_obj))
                if (JObject.Parse(execution_obj) != null)
                {
                    var execution_id = JObject.Parse(execution_obj)["execution_id"].ToString();
                    if (!string.IsNullOrEmpty(execution_id))
                    {
                        int elapsed = 0;
                        Singleton<ListExecuteModel>.Instance.listExecuteModel[execution_id] = null;
                        while (
                            (
                                Singleton<ListExecuteModel>.Instance.listExecuteModel[execution_id]
                                == null
                            ) && (elapsed < _cmsSetting.TimeoutApi)
                        )
                        {
                            await Task.Delay(50);
                            elapsed += 50;
                        }

                        if (elapsed >= _cmsSetting.TimeoutApi)
                        {
                            return StatusCode((int)HttpStatusCode.RequestTimeout, $"Request timeout for execution id : [{execution_id}]");
                        }
                        ;
                        var getExecutionStatus = await _portalClient.CallAPI(
                            $"{NeptuneHttpURL}api/workflow/get-execution-status/{execution_id}",
                            "GET",
                            new object()
                        );

                        if (!string.IsNullOrEmpty(getExecutionStatus))
                            if (JObject.Parse(getExecutionStatus) != null)
                                return Ok(JObject.Parse(getExecutionStatus));
                    }
                }
            return Ok(JObject.Parse(execution_obj));
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.ToString());
            return StatusCode((int)ex.StatusCode);
        }



    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="revertTransactionModel"></param>
    /// <returns></returns>
    [HttpPost("/api/workflow/reverse")]
    public virtual async Task<IActionResult> ReverseTransaction(
        [FromBody] RevertTransactionModel revertTransactionModel
    )
    {
        try
        {
            var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
            _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        var newToken = revertTransactionModel.Token;

        try
        {
            var postReverse = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/workflow/reverse",
                "POST",
                new { execution_id = revertTransactionModel.TransactionId, token = newToken }
            );
            var obj = JToken.Parse(postReverse).ToObject<ExecuteResponseModel>();
            if (obj.Status == "COMPLETED")
            {
                int elapsed = 0;
                Singleton<ListExecuteModel>.Instance.listExecuteModel[obj.ExecutionId] = null;

                while (
                    (Singleton<ListExecuteModel>.Instance.listExecuteModel[obj.ExecutionId] == null)
                    && (elapsed < _cmsSetting.TimeoutApi)
                )
                {
                    await Task.Delay(50);
                    elapsed += 50;
                }

                if (elapsed >= _cmsSetting.TimeoutApi)
                {
                    return StatusCode((int)HttpStatusCode.RequestTimeout, $"Request timeout for execution id : [{obj.ExecutionId}]");
                }


                var getExecutionStatus = await _portalClient.CallAPI(
                    $"{NeptuneHttpURL}api/workflow/get-execution-status/{obj.ExecutionId}",
                    "GET",
                    new object()
                );

                if (!string.IsNullOrEmpty(getExecutionStatus))
                    if (JObject.Parse(getExecutionStatus) != null)
                    {
                        var executionStatusObj = JToken
                            .Parse(getExecutionStatus)
                            .ToObject<ExecuteResponseModel>();
                        if (obj.Status == "COMPLETED")
                            executionStatusObj.Data = (
                                new RevertTransactionResponseModel
                                {
                                    TransactionDate = revertTransactionModel.TransactionDate,
                                    TransactionId = revertTransactionModel.TransactionId,
                                    TransactionStatus = executionStatusObj.Status
                                }
                            ).ToDictionary();

                        return Ok(executionStatusObj);
                    }
            }

            return Ok(obj);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.ToString());
            return StatusCode((int)ex.StatusCode);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="revertTransactionModel"></param>
    /// <returns></returns>
    [HttpPost("/api/workflow/reverse-by-reference-id")]
    public virtual async Task<IActionResult> ReverseTransaction(
        [FromBody] ReverseByReferenceIdModel revertTransactionModel
    )
    {
        try
        {
            var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
            _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        var newToken = revertTransactionModel.token;
        try
        {
            var postReverse = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/workflow/reverse-by-reference-id",
                "POST",
                new { reference_id = revertTransactionModel.reference_id, token = newToken }
            );
            var obj = JToken.Parse(postReverse).ToObject<ExecuteResponseModel>();
            if (obj.Status == "COMPLETED")
            {
                int elapsed = 0;
                Singleton<ListExecuteModel>.Instance.listExecuteModel[obj.ExecutionId] = null;

                while (
                    (Singleton<ListExecuteModel>.Instance.listExecuteModel[obj.ExecutionId] == null)
                    && (elapsed < _cmsSetting.TimeoutApi)
                )
                {
                    await Task.Delay(50);
                    elapsed += 50;
                }

                if (elapsed >= _cmsSetting.TimeoutApi)
                {
                    return StatusCode((int)HttpStatusCode.RequestTimeout, $"Request timeout for execution id : [{obj.ExecutionId}]");
                }


                var getExecutionStatus = await _portalClient.CallAPI(
                    $"{NeptuneHttpURL}api/workflow/get-execution-status/{obj.ExecutionId}",
                    "GET",
                    new object()
                );

                if (!string.IsNullOrEmpty(getExecutionStatus))
                    if (JObject.Parse(getExecutionStatus) != null)
                    {
                        var executionStatusObj = JToken
                            .Parse(getExecutionStatus)
                            .ToObject<ExecuteResponseModel>();

                        return Ok(executionStatusObj);
                    }
            }

            return Ok(obj);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.ToString());
            return StatusCode((int)ex.StatusCode);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/workflow/get-execution-status/{pChannelID}/{pReferenceID}")]
    public virtual async Task<IActionResult> GetExecutionStatusByChannelIDAndReferenceID(
        string pChannelID,
        string pReferenceID
    )
    {
        try
        {
            var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
            _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        try
        {
            System.Console.WriteLine(
                "url---"
                    + $"{NeptuneHttpURL}api/workflow/get-execution-status/{pChannelID}/{pReferenceID}"
            );
            var postReverse = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/workflow/get-execution-status/{pChannelID}/{pReferenceID}",
                "GET",
                new { }
            );
            var obj = JToken.Parse(postReverse).ToObject<ExecuteResponseModel>();

            return Ok(obj);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.ToString());
            return StatusCode((int)ex.StatusCode);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet("/api/cache/get-by-key/{key}")]
    public virtual async Task<IActionResult> GetCacheByKey(string key)
    {
        var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
        _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();
        // var getCoreToken = await EngineContext.Current.Resolve<IAdminGrpcService>().Authenticate(_cmsSetting.UserAdmin, _cmsSetting.PasswordAdmin);

        try
        {
            System.Console.WriteLine("====>" + $"{NeptuneHttpURL}api/cache/get-by-key/{key}");
            var response = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/cache/get-by-key/{key}",
                "GET",
                new { }
            );
            System.Console.WriteLine("response====>" + response);

            var obj = JToken.Parse(response).ToObject<ExecuteResponseVer2Model>();

            return Ok(obj);
        }
        catch (System.Exception ex)
        {
            //
            // TODO
            System.Console.WriteLine("ex====>" + ex);
            var new_token = await _postAPIService.GetNewNeptuneToken();
            _portalClient.PortalToken = new_token;
            var response_retry = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/cache/get-by-key/{key}",
                "GET",
                new { }
            );
            System.Console.WriteLine("response_retry====>" + response_retry);

            var obj = JToken.Parse(response_retry).ToObject<ExecuteResponseVer2Model>();

            return Ok(obj);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/download-workflow-zip")]
    public virtual async Task<IActionResult> DownloadWorkflowZip()
    {
        var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
        System.Console.WriteLine("portalToken====>" + portalToken);
        _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();
        // var getCoreToken = await EngineContext.Current.Resolve<IAdminGrpcService>().Authenticate(_cmsSetting.UserAdmin, _cmsSetting.PasswordAdmin);

        try
        {
            System.Console.WriteLine("====>" + $"{NeptuneHttpURL}api/workflow-definition/download/all/zip-base64?pIncludeServiceData=true");
            var response = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/workflow-definition/download/all/zip-base64?pIncludeServiceData=true",
                "GET",
                new { }
            );
            //System.Console.WriteLine("response====>" + response);

            // var obj = JToken.Parse(response).ToObject<ExecuteResponseVer2Model>();
            var obj = JToken.Parse(response).ToObject<ExecuteResponseVer2Model>();

            return Ok(obj);
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("ex====>" + ex);
            var new_token = await _postAPIService.GetNewNeptuneToken();
            _portalClient.PortalToken = new_token;

            var response_retry = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/workflow-definition/download/all/zip-base64?pIncludeServiceData=true",
                "GET",
                new { }
            );
            var obj_ = JToken.Parse(response_retry).ToObject<ExecuteResponseVer2Model>();

            return Ok(obj_);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpPost("/api/auth/get-static-token")]
    public virtual async Task<IActionResult> GetStaticToken([FromBody] GetStaticTokenModel model)
    {

        try
        {
            var portalToken = HttpContext.Request.Headers[HeaderNames.Authorization];
            _portalClient.PortalToken = portalToken.ToString().Split(" ")[1].ToString();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        try
        {

            var postReverse = await _portalClient.CallAPI(
                $"{NeptuneHttpURL}api/auth/get-static-token",
                "POST",
                model);
            var obj = JToken.Parse(postReverse).ToObject<ExecuteResponseVer2Model>();
            return Ok(obj);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.ToString());
            return StatusCode((int)ex.StatusCode);
        }
    }
}
