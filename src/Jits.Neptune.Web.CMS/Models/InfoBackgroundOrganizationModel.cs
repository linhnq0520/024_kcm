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
    public class InfoBackgroundOrganizationModel
    {
        /// <summary>
        /// 
        /// </summary>
        public InfoBackgroundOrganizationModel() { }
        /// <summary>
        /// User code
        /// </summary>
        [JsonProperty("welcome_logo")]
        public string welcome_logo { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("login_background")]
        public string login_background { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("welcome_title")]
        public string welcome_title { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("welcome_sub_title")]
        public string welcome_sub_title { get; set; } = string.Empty;

    }

}


