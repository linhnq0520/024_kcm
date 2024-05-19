#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextAppModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ContextAppModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetApp() => App;
    }
}
