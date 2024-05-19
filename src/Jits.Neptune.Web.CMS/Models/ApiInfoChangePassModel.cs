#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiInfoChangePassModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ApiInfoChangePassModel() { }
        /// <summary>
        /// User code
        /// </summary>
        [JsonProperty("info")]
        public string info { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
         [JsonProperty("type")]
        public bool type { get; set; } = false;
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        [JsonProperty("api_info")]
        public Dictionary<string, object> api_info { get; set; } = new Dictionary<string, object>();
       
    }
    
}


