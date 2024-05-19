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
    public class PageSearchModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public PageSearchModel() { }
        /// <summary>
        /// </summary>
        public int TotalCount { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int TotalPages { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool HasPreviousPage { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool HasNextPage { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<object> Items { get; set; }


    }
}


