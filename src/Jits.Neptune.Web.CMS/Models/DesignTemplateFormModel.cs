#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DesignTemplateFormModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public DesignTemplateFormModel() { }
        /// <summary>
        /// </summary>
         [JsonProperty("info")]
        public InfoForm Info { get; set; } = new InfoForm();
        /// <summary>
        /// </summary>
         [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("list_layout")]
        public List<Dictionary<string, object>> ListLayout { get; set; } = new List<Dictionary<string, object>>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("react_txt")]
        public string ReactTxt { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("template")]
        [JsonProperty("template")]
        public Dictionary<string, object> Template { get; set; } = new Dictionary<string, object>();


    }
    

}


