using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public interface IActClearAccountWorkflowService
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> View(WorkflowExecuteModel workflow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> Create(WorkflowRequestModel workflow);
    }
}
