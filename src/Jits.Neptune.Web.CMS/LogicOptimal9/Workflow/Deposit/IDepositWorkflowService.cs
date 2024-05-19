using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public partial interface IDepositWorkflowService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task<JToken> UpdateAccount(WorkflowRequestModel workflow);
}
