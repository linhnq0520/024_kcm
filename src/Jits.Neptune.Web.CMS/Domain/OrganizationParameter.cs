using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class OrganizationParameter : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public OrganizationParameter() { }
    /// <summary>
    /// </summary>
    /// <summary>
    /// role id
    /// </summary>
    public string OrganizationCode { get; set; }

    /// <summary>
    /// rolename
    /// </summary>
    public string ParamaterCode { get; set; }

    /// <summary>
    /// Parent command Id
    /// </summary>
    public string ParameterValue { get; set; }
   

}