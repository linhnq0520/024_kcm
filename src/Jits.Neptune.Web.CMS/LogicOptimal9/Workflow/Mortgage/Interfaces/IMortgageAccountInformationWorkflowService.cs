using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMortgageAccountInformationWorkflowService
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
        Task<JToken> ViewAccount(WorkflowRequestModel workflow);


       // Task<JToken> CreateBO(WorkflowExecuteModel workflow);

        //Task<JToken> UpdateBO(WorkflowExecuteModel workflow);

        //Task<JToken> Delete(WorkflowExecuteModel workflow);
    }
}
