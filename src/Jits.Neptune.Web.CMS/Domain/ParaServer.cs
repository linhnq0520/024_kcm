using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class ParaServer : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public ParaServer() { }
    /// <summary>
    /// </summary>
    [JsonProperty("code")] public string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("des")] public string Des { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("value")] public string Value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("data_type")] public string Data_Type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("isAdmin")] public bool Isadmin { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("app")] public string App { get; set; }


}