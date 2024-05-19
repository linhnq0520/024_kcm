#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecuteResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ExecuteResponseModel() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("time_in_miliseconds")] public long TimeInMiliseconds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("status")] public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("description")] public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("execution_id")] public string ExecutionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("transaction_number")] public string TransactionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")] public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error_code")] public string ErrorCode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error_message")] public string ErrorMessage { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExecuteResponseVer2Model : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ExecuteResponseVer2Model() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("time_in_miliseconds")] public long TimeInMiliseconds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("status")] public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("description")] public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("execution_id")] public string ExecutionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("transaction_number")] public string TransactionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")] public object Data { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error_code")] public string ErrorCode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error_message")] public string ErrorMessage { get; set; } = string.Empty;
    }
}
