#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleTaskModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleTaskModel() { }
        /// <summary>
        /// User code
        /// </summary>
        [JsonProperty("install")]
        public bool install { get; set; } = true;

    }
    /// <summary>
    /// 
    /// </summary>
    public class ComponentRoleModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentRoleModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RoleTaskModel component { get; set; } = new RoleTaskModel();

    }
    /// <summary>
    /// 
    /// </summary>
    public class ViewRoleModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewRoleModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RoleTaskModel view { get; set; } = new RoleTaskModel();

    }
    /// <summary>
    /// 
    /// </summary>
    public class LayoutRoleModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LayoutRoleModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RoleTaskModel layout { get; set; } = new RoleTaskModel();

    }
    /// <summary>
    /// 
    /// </summary>
    public class FormRoleModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormRoleModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FormRoleInfoModel form { get; set; } = new FormRoleInfoModel();

    }
    /// <summary>
    /// 
    /// </summary>
    public class FormRoleInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormRoleInfoModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool accept { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool follow { get; set; } = false;
    }

}


