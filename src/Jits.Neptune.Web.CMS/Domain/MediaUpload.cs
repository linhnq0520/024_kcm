using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class MediaUpload : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public MediaUpload() { }
    /// <summary>
    /// </summary>

    /// <summary>
    /// </summary>
    public int UserId { get; set; } = 0;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Token { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string MediaName { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string MediaType { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string MediaData { get; set; } = string.Empty;


}