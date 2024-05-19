#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecutionStepProcessModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ExecutionStepProcessModel() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("request")]
        public object request { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("response")]
        public ResponseStepModel response { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ResponseStepModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseStepModel() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("status")]
        public int status { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("data")]
        public object data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("error_message")]
        public string error_message { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("error_code")]
        public string error_code { get; set; } = string.Empty;
    }
}
