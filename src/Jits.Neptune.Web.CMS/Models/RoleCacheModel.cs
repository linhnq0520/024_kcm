#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleCacheModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleCacheModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string FormId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Invoke { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Approve { get; set; } = true;



    }
}
