#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
        /// <summary>
        /// 
        /// </summary>
    public class BoRequestModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public BoRequestModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("bo")]
        public List<BoRequest> Bo { get; set; } = new List<BoRequest>();


    }
    /// <summary>
    /// 
    /// </summary>
    public class BoRequest : BaseNeptuneModel
    {
        /// <summary>
         /// 
         /// </summary>
        public BoRequest() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("txcode")]
        public string Txcode { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("input")]
        public Dictionary<string, object> Input { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("form_code")]
        public string FormCode { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("from_action_code")]
        public string FromActionCode { get; set; } = string.Empty;

    }
}


