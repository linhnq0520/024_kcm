#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchPortalRequestModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchPortalRequestModel() { }
        /// <summary>
        /// </summary>
        public string key_table_paging { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string search_advanced { get; set; } = "false";


    }

}


