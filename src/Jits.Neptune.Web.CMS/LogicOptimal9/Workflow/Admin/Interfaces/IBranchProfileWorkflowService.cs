﻿using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBranchProfileWorkflowService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> SimpleSearch(WorkflowRequestModel workflow);

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
        Task<JToken> View(WorkflowRequestModel workflow);
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
        Task<JToken> Create(WorkflowRequestModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> Delete(WorkflowRequestModel workflow);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> RefreshBranch(WorkflowRequestModel workflow);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        Task<JToken> BranchProcess(WorkflowRequestModel workflow);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<JToken> GetHostBranchId(WorkflowRequestModel workflow);
    }
}