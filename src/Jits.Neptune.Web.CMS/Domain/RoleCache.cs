using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class RoleCache : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public RoleCache() { }
    /// <summary>
    /// </summary>
    /// <summary>
    /// role id
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// rolename
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    /// Parent command Id
    /// </summary>
    public string ParentId { get; set; }

    /// <summary>
    /// /// Command Id
    /// </summary>
    public string CommandId { get; set; }

    /// <summary>
    /// Command Name
    /// </summary>
    public string CommandName { get; set; }

    /// <summary>
    /// Command Id Detail
    /// </summary>
    public string CommandIdDetail { get; set; }

    /// <summary>
    /// Invoke
    /// </summary>
    public int Invoke { get; set; }

    /// <summary>
    /// Approve
    /// </summary>
    public int Approve { get; set; }

    /// <summary>
    /// ApplicationCode
    /// </summary>
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Command Type
    /// </summary>
    /// <value></value>
    public string CommandType { get; set; }

}