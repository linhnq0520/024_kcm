using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models.AdminModels;

/// <summary>
/// 
/// </summary>
public class ButtonInfo
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("cmdid")]
    public string CommandId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("caption")]
    public string Caption { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("isvisible")]
    public bool IsVisible { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("isenable")]
    public bool IsEnabled { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("hkcmd")]
    public object HkCmd { get; set; }
}
