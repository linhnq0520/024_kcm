using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System.Threading.Tasks;
namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public partial interface IBaseWorkflowService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task<JToken> AdvanceSearch(WorkflowRequestModel workflow);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task<JToken> SimpleSearch(WorkflowRequestModel workflow);

    /// <summary>
    /// Rules the func using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>A task containing the token</returns>
    Task<JToken> RuleFunc(WorkflowRequestModel workflow);

    /// <summary>
    /// Executes the rule func using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>A task containing the token</returns>
    Task<JToken> ExecuteRuleFunc(WorkflowRequestModel workflow);   
  
    /// <summary>
    /// Fronts the office using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>A task containing the token</returns>
    Task<JToken> FrontOffice(WorkflowRequestModel workflow);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<JToken> View(WorkflowRequestModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<JToken> Delete(WorkflowRequestModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<JToken> CreateBO(WorkflowRequestModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<JToken> UpdateBO(WorkflowRequestModel model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <param name="isAdvanceSearch"></param>
    /// <returns></returns>
    Task<JToken> SearchData(WorkflowRequestModel workflow, bool isAdvanceSearch = false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task<JToken> SearchList(WorkflowRequestModel workflow);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    Task<JToken> SearchInfo(WorkflowRequestModel workflow);
}
