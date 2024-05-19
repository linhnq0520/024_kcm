using Jits.Neptune.Web.CMS.Domain;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public interface IWorkflowDefinitionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflowId"></param>
    /// <returns></returns>
    Task<WorkflowDefinition> GetByWorkflowId(string workflowId);
}

