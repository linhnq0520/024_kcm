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
    public class DesignItemModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public DesignItemModel() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("title")]
        [JsonProperty("title")]
        public Dictionary<string, object> Title { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("group_id")]
        public string GroupId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("order")]
        public string DisplayOrder { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("isActive")]
        public bool isActive { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("img")]
        public string Img { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("att_id")]
        public string AttId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonPropertyName("template")]
        [JsonProperty("template")]
        public Dictionary<string, object> Template { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("keynew")]
        public string KeyNew { get; set; } = string.Empty;

    }

}


