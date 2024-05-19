using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class DepositRuleFuncService : IDepositRuleFuncService
{
    private readonly IBaseWorkflowService _baseWorkflow;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseWorkflow"></param>
    public DepositRuleFuncService(IBaseWorkflowService baseWorkflow) { 
        _baseWorkflow = baseWorkflow;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> GetListIfcByTariffCode(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var data = await _baseWorkflow.SearchData(workflow, true);
        return data["data"].BuildWorkflowResponseSuccess(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> GetListGlsByGroupId(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var data = await _baseWorkflow.SearchData(workflow, true);
        return data["data"].BuildWorkflowResponseSuccess(true);
    }
}
