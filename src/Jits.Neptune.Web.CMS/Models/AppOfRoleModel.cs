#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AppOfRoleModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AppOfRoleModel() { }
        /// <summary>
        /// </summary>
        /// 
        public int Id { get;set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("role_id")] public int RoleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("app")] public string App { get; set; } = string.Empty;

    }
}


