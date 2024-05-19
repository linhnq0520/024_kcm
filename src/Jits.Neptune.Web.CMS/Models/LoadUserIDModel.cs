#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LoadUserIDModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LoadUserIDModel() { }
        /// <summary>
        /// User code
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("portal_token")]
        public string PortalToken { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("user_id_find")]
        public string UserIdFind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string status { get; set; } = "I";

    }
}


