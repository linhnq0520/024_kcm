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
    public class BatchSumnaryModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public BatchSumnaryModel() { }
        /// <summary>
        /// </summary>
        public string Current { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime BatchDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool IsFailed { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DaysRunning { get; set; }
    }
}
