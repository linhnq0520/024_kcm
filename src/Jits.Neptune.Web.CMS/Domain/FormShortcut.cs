using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class FormShortcut : BaseEntity
{
    /// <summary>
    ///
    /// </summary>
    public FormShortcut() { }

    /// <summary>
    /// </summary>
    [JsonPropertyName("form_id")]
    public string FormId { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("form_name")]
    public string FormName { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("group_code")]
    public string GroupCode { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("app")]
    public string App { get; set; }
}
