using JITS.Neptune.NeptuneClient.Workflow;
using Jits.Neptune.Web.CMS.Models;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class ExecutionStepProcessExtentions
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="wf"></param>
       /// <returns></returns>
        public static string ToSerialize(this ExecutionStepProcessModel wf)
        {
            return System.Text.Json.JsonSerializer.Serialize(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static ExecutionStepProcessModel ToExecutionStepProcess(this object wf)
        {
            return System.Text.Json.JsonSerializer.Deserialize<ExecutionStepProcessModel>(System.Text.Json.JsonSerializer.Serialize(wf));
            // return (ExecutionStepProcessModel) wf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string GetErrorMessage(this object wf)
        {
            string result_ = "";

            if (wf != null)
                foreach (var itemData in wf.ToDictionarySystemText())
                {
                    result_ += itemData.Value.ToString() + " ; ";
                }
            return result_;
        }
    }
}

