using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class SessionLoginJWebUI : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public SessionLoginJWebUI() { }
    /// <summary>
    /// </summary>
    [JsonPropertyName("user_id")] public string UserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("app")] public string App { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("token_webui")] public string TokenWebui { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("info_user_login")] public string infoUserLogin { get; set; }

}