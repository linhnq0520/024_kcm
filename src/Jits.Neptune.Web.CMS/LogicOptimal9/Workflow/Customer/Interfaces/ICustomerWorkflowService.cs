using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerWorkflowService
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
        Task<JToken> Insert(WorkflowRequestModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> Update(WorkflowRequestModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<JToken> LookupDataCommune(WorkflowExecuteModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<JToken> GetInforCdname(WorkflowExecuteModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<JToken> LookupDataForPrimaryKey(WorkflowExecuteModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<JToken> LookupDataSUBINDUSTRYOrSSRCINCOME(WorkflowExecuteModel workflow);
    }
}
