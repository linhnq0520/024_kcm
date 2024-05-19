using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// Represents an Bo
/// </summary>
public partial class LearnApi : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public LearnApi() { }
    /// <summary>
    /// User code
    /// </summary>
    [JsonProperty("learn_api_id")]
    public string LearnApiId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_name")]

    public string LearnApiName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_link")]

    public string LearnApiLink { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_data")]

    public string LearnApiData { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_node_data")]

    public string LearnApiNodeData { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_app")]

    public string LearnApiApp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_method")]

    public string LearnApiMethod { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("flow_api")]

    public string FlowApi { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("save_to")]

    public string SaveTo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_header")]

    public string LearnApiHeader { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("learn_api_mapping")]

    public string LearnApiMapping { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("number_of_steps")]

    public string NumberOfSteps { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string LearnApiGetInfo { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("key_read_data")]

    public string KeyReadData { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string JwebuiUsercreate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("app")]

    public string App { get; set; }

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