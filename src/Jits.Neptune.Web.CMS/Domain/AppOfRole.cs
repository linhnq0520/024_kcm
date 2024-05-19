using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class AppOfRole : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public AppOfRole() { }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("role_id")] public int RoleId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("app")] public string App { get; set; }

}