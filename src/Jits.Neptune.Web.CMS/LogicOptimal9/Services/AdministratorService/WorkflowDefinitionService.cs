using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class WorkflowDefinitionService : IWorkflowDefinitionService
{
    private readonly IRepository<WorkflowDefinition> _contextRepository;

    /// <summary>
    /// 
    /// </summary>
    public WorkflowDefinitionService(IRepository<WorkflowDefinition> contextRepository)
    {
        _contextRepository = contextRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflowId"></param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public async Task<WorkflowDefinition> GetByWorkflowId(string workflowId)
    {
        var workflow = await _contextRepository.Table.Where(s => s.WorkflowId == workflowId && 
                        s.Status == Constants.WorkflowStatus.Inactive)
                        .FirstOrDefaultAsync();
        return workflow;
    }
}
