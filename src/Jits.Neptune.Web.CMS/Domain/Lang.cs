using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// Represents an Bo
/// </summary>
public partial class Lang : BaseEntity
{
    /// <summary>
    /// User code
    /// </summary>
    [JsonProperty("lang_data")]

    public string LangData { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("app")]

    public string App { get; set; }


}
/// <summary>
/// 
/// </summary>
public enum EnumSupportLanguages
{
    /// 
    en,
    /// <summary>
    /// 
    /// </summary>
    vi,
    /// <summary>
    /// 
    /// </summary>
    la, 
    /// <summary>
    /// 
    /// </summary>
    kr,
    /// <summary>
    /// 
    /// </summary>
    mm,
    /// <summary>
    /// 
    /// </summary>
    th
}
