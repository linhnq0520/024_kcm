#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LearnApiModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LearnApiModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
         public int Id { get; set; } 
         /// <summary>
         /// 
         /// </summary>
        [JsonProperty("learn_api_id")] public string LearnApiId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_name")] public string LearnApiName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_link")] public string LearnApiLink { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_data")] public string LearnApiData { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_node_data")] public string LearnApiNodeData { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_app")] public string LearnApiApp { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_method")] public string LearnApiMethod { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("flow_api")] public string FlowApi { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("save_to")] public string SaveTo { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_header")] public string LearnApiHeader { get; set; } = "{}";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_mapping")] public string LearnApiMapping { get; set; } = "{}";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("number_of_steps")] public string NumberOfSteps { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learn_api_get_info")] public string LearnApiGetInfo { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key_read_data")] public string KeyReadData { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("JWebUI_UserCreate")] public string JwebuiUsercreate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app")] public string App { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("learn_api_mapping_archive")]

        public string LearnApiMappingArchive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("learn_api_mapping_response")]

        public string LearnApiMappingResponse { get; set; }
    }

}


