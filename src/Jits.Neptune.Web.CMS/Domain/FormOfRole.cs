using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class FormOfRole : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public FormOfRole() { }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("role_id")] public int RoleId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("form")] public string Form { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("access_form")] public bool AccessForm { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("app")] public string App { get; set; }






}