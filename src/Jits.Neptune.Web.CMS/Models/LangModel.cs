#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LangModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LangModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// User code
        /// </summary>
        public Dictionary<string, object> LangData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; }

    }
}


