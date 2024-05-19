using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class ShortcutConfig : BaseEntity
{
    /// <summary>
    ///
    /// </summary>
    public ShortcutConfig() { }

    /// <summary>
    /// </summary>
    [JsonPropertyName("shortcut_id")]
    public string ShortcutId { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("keystrokes")]
    public string Keystrokes { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("app")]
    public string App { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("user_id")]
    public string UserId { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonPropertyName("form_code")]
    public string FormCode { get; set; }
}
