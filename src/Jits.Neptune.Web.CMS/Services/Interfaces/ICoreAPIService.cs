using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using JITS.Neptune.NeptuneClient.Workflow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// ICoreAPIService service
/// </summary>
public partial interface ICoreAPIService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<JObject> BuildHeader(JObject packApi);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<JToken> BuildResponse(JToken packApi);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<string> BuildRequest(string packApi);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<JToken> BuildResponse(ExecuteResponseModel packApi);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<List<ErrorInfoModel>> BuildError(WorkflowExecutionInquiry packApi);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<bool> CheckHasError(WorkflowExecutionInquiry packApi);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<bool> CheckHasError(ExecuteResponseModel packApi);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    Task<List<ErrorInfoModel>> BuildError(ExecuteResponseModel packApi);


}
