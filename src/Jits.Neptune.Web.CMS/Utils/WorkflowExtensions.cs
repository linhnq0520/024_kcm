using JITS.NeptuneClient.Scheme.Workflow;
using System.Collections.Generic;
using System.Linq;

namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// Workflow Extensions
    /// </summary>
    public static class WorkflowExtensions
    {
        /// <summary>
        /// Return error value
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static WorkflowScheme ResponseError(this WorkflowScheme workflow, Dictionary<string, object> error)
        {
            var first = error.First();
            workflow.response.data = error[first.Key];
            workflow.response.status = WorkflowScheme.RESPONSE.EnumReponseStatus.ERROR;

            return workflow;
        }

        /// <summary>
        /// Return success value
        /// </summary>
        /// <param name="workflow"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WorkflowScheme ResponseOk(this WorkflowScheme workflow, Dictionary<string, object> value)
        {
            var first = value.First();
            workflow.response.data = value[first.Key];
            workflow.response.status = WorkflowScheme.RESPONSE.EnumReponseStatus.SUCCESS;

            return workflow;
        }
    }
}