using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class ScheduleJob : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public ScheduleJob() { }
    /// <summary>
    /// </summary>
    /// <summary>
    /// role id
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// rolename
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public long Time { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ContentRun { get; set; }
    /// <summary>
    /// Parent command Id
    /// </summary>
    public string ApplicationCode { get; set; }


}