using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// Represents an Bo
/// </summary>
public partial class WorkflowDefinition : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public WorkflowDefinition()
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string WorkflowId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string WorkflowFunc {  get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string TableName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string FullInterfaceName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string MethodName { get; set;}
    /// <summary>
    /// 
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string MappingRequest { get; set;}

    /// <summary>
    /// 
    /// </summary>
    public string MappingResponse { get; set;}
    /// <summary>
    /// 
    /// </summary>
    public int IsCommonProcess { get; set; } = 1;
    /// <summary>
    /// 
    /// </summary>
    public string IdFieldName { get; set; }
}