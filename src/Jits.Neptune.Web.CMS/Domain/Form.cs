using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// Represents an Bo
/// </summary>
public partial class Form : BaseEntity
{
    /// <summary>
    /// User code
    /// </summary>
    [JsonProperty("info")] public string Info { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("list_layout")] public string ListLayout { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("react_txt")] public string ReactTxt { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("form_id")] public string FormId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("app")] public string App { get; set; }

}