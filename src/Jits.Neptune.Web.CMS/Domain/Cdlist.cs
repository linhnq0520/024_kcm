using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class Cdlist : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public Cdlist() { }
    /// <summary>
    /// </summary>
    [JsonProperty("cdgrp")] public string Cdgrp { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("cdname")] public string Cdname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("cdid")] public string Cdid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("caption")] public string Caption { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("cdval")] public string Cdval { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("cdidx")] public int Cdidx { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("ftag")] public string Ftag { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("visible")] public int Visible { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("mcaption")] public string Mcaption { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("app")] public string App { get; set; }


}