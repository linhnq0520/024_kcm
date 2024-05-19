using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class DesignGroup : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public DesignGroup() { }
    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonPropertyName("order")]
    public string DisplayOrder { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonPropertyName("isActive")]
    public bool isActive { get; set; } = true;

}