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
    public class FormOfRoleModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormOfRoleModel() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("role_id")] public int RoleId { get; set; }
        /// <summary>
        /// </summary>
        [JsonPropertyName("form")] public string Form { get; set; }
        /// <summary>
        /// </summary>
        [JsonPropertyName("access_form")] public bool AccessForm { get; set; }
        /// <summary>
        /// </summary>
        [JsonPropertyName("app")] public string App { get; set; }


    }
}


