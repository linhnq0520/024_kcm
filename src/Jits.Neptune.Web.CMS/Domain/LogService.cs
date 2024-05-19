using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class LogService : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public LogService() {
         
     }
    /// <summary>
    /// </summary>
    /// <summary>
    /// role id
    /// </summary>
    public long LogUtc { get; set; } =DateTime.UtcNow.Ticks;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string LogType { get; set; } = string.Empty;

    /// <summary>
    /// ExecutionID
    /// </summary>
    public string ExecutionId { get; set; }= string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string StepExecutionId { get; set; }= string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string StepCode { get; set; }= string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ServiceId { get; set; }= string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Subject { get; set; }= string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string LogText { get; set; }= string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string JsonDetails { get; set; }= "{}";



}