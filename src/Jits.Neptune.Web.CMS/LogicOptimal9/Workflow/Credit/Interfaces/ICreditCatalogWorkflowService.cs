using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreditCatalogWorkflowService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> SimpleSearch(O9PostService.WorkflowRequestModel workflow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> AdvanceSearch(O9PostService.WorkflowRequestModel workflow);
        


        /// <summary>
        /// CRD_TARIFF_CONFIGURATION
        /// </summary>
        /// <param name="workflow">The workflow</param>
        /// <returns>The token</returns>
        Task<JToken> TariffConfigguration(WorkflowExecuteModel workflow);

        /// <summary>
        /// CRD_CATALOGUE_DEFINITION_TARIFF
        /// </summary>
        /// <param name="workflow">The workflow</param>
        /// <returns>The token</returns>
        Task<JToken>  CattalogDefinitionTariff(WorkflowExecuteModel workflow);
    }
}
