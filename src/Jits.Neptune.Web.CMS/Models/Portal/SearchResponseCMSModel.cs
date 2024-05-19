#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchResponseCMSModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchResponseCMSModel() { }
        /// <summary>
        /// </summary>
        public long total_items { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string search_advanced { get; set; } = "false";


    }

}


