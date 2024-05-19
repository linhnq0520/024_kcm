using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public partial interface IApiService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflowId"></param>
    /// <param name="responseModel"></param>
    /// <param name="keyError"></param>
    /// <returns></returns>
    Task<List<ErrorInfoModel>> BuildError(string workflowId, WorkflowResponseModel responseModel, string keyError = "SYSTEM_ERROR");
}
