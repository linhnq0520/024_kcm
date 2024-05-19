using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class TemplateVoucher : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public TemplateVoucher() { }
    /// <summary>
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonPropertyName("html_code")]
    public string HtmlCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonPropertyName("app")]
    public string App { get; set; }

}