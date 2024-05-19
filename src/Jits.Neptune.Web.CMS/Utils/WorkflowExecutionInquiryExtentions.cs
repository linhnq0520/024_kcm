using JITS.Neptune.NeptuneClient.Events.EventData;
using JITS.Neptune.NeptuneClient.Workflow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class WorkflowExecutionInquiryExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this WorkflowExecutionInquiry wf)
        {
            return System.Text.Json.JsonSerializer.Serialize(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>p
        public static WorkflowExecutionInquiry ToWorkflowExecutionInquiry(this JToken wf)
        {

            return System.Text.Json.JsonSerializer.Deserialize<WorkflowExecutionInquiry>(JsonConvert.SerializeObject(wf));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static WorkflowExecutionInquiry ToWorkflowExecutionInquiry(this WorkflowExecutionDataEvent wf)
        {
            return new WorkflowExecutionInquiry()
            {
                execution = wf.execution,
                execution_steps = wf.execution_steps
            };
            // return System.Text.Json.JsonSerializer.Deserialize<WorkflowExecutionInquiry>(wf.ToSerialize());
        }
    }
}

