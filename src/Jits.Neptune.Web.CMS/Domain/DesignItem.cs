using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class DesignItem : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public DesignItem() { }
    /// <summary>
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string GroupId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string DisplayOrder { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public bool isActive { get; set; } = true;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Img { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string AttId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Template { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string KeyNew { get; set; }

}