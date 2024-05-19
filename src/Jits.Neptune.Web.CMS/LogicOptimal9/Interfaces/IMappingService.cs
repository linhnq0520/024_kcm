using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public partial interface IMappingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mappingResponse"></param>
    /// <param name="data"></param>
    /// <param name="learnApiData"></param>
    /// <returns></returns>
    Task<JToken> MappingResponse(string mappingResponse, JToken data, string learnApiData = "");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflowInfo"></param>
    /// <param name="dataRequest"></param>
    /// <returns></returns>
    Task<LearnApiModel> MappingRequest(WorkflowInfo workflowInfo, JObject dataRequest);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="learnApiContent"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    Task<LearnApiModel> O9MapData(LearnApiModel learnApiContent, JObject dataMap, string appRequest);
}
