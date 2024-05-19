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
    public class PageSearchMediaModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PageSearchMediaModel() { }
        /// <summary>
        /// </summary>
        public int total_count { get; set; }
/// <summary>
/// 
/// </summary>
/// <value></value>

        public int total_pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool has_previous_page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool has_next_page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<object> items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<object> MEDIA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public object PAGING { get; set; }
    }
}


