#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using System.Collections.Generic;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchResponseModel() { }
        /// <summary>
        /// </summary>
        public long total_items { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long items_per_page { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long total_pages { get; set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long current_page { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long from_index { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long to_index { get; set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<object> results { get; set; } = null;


    }

}


