using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerMediaWorkflowService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> SimpleSearch(WorkflowExecuteModel workflow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> AdvanceSearch(WorkflowExecuteModel workflow);
    }
}
