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
    public class ListLangConfigModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListLangConfigModel() { }
        /// <summary>
        /// User code
        /// </summary>
        [JsonProperty("list_lang_config")]
        public List<LangConfig> ListLangConfig { get; set; } = new List<LangConfig>();

    }

    /// <summary>
    /// 
    /// </summary>
    public class LangConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public LangConfig() { }
        /// <summary>
        /// User code
        /// </summary>
        [JsonProperty("key")]
        public string key { get; set; } = "en";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("view")]
        public string view { get; set; } = "English";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("img")]
        public string img { get; set; } = "../rs/global/img/uk.png";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("selected")]
        public bool selected { get; set; } = false;

    }
}


