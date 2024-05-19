using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class DesignTemplateForm : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public DesignTemplateForm() { }
    /// <summary>
    /// </summary>
    public string TemplateId { get; set; }
    /// <summary>
    /// </summary>
    public string Template { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Info { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ListLayout { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ReactTxt { get; set; }

}