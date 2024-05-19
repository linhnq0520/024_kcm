#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowExecuteModel
    {
        /// <summary>
        /// 
        /// </summary>
        public enum EnumSupportLanguages
        {
            /// <summary>
            /// 
            /// </summary>
            en,
            ///
            vi,
            /// <summary>
            /// 
            /// </summary>

            la,
            /// <summary>
            /// 
            /// </summary>
            kr,
            /// <summary>
            /// 
            /// </summary>
            /// 
            mm,
            /// <summary>
            /// 
            /// </summary>
            /// 
            th
        }
        /// <summary>
        /// 
        /// </summary>
        public WorkflowExecuteModel()
        {
            service_instances.Add(new ServiceInstance());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string workflowid = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string description = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string lang { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int workflow_type = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string reversal_execution_id = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string approved_execution_id = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string token = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ServiceInstance> service_instances { get; set; } = new List<ServiceInstance>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Dictionary<string, object> fields = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        public string reference_id = System.Guid.NewGuid().ToString();
        /// <summary>
        /// 
        /// </summary>
        public string reference_code = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string business_code = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public UserSessions user_sessions = new UserSessions();

    }
    /// <summary>
    /// 
    /// </summary>
    public class ServiceInstance
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string service_code { get; set; } = JITS.Neptune.NeptuneClient.GrpcClient.ClientConfig.YourServiceID;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string instance_id { get; set; } = JITS.Neptune.NeptuneClient.GrpcClient.ClientConfig.YourInstanceID;

    }

}
