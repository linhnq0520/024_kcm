using System;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// Represents an Bo
/// </summary>
public partial class App : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>

    public string ListApplicationId { get; set; }

    /// <summary>
    /// ListApplicationName
    /// </summary>
    public string ListApplicationName { get; set; }
    /// <summary>
    /// ListApplicationDes
    /// </summary>
    public string ListApplicationDes { get; set; }

    /// <summary>
    /// ListApplicationImg
    /// </summary>
    public string ListApplicationImg { get; set; }
    /// <summary>
    ///ListApplicationBo
    /// </summary>
    public string ListApplicationBo { get; set; }

    /// <summary>
    /// ListApplicationOrder
    /// </summary>
    public string ListApplicationOrder { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ListApplicationBoLogoutAll { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ListApplicationBoLogout { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ConnectOtherSystemStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string ConfigTemplate
    {
        get; set;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string status { get; set; }
}