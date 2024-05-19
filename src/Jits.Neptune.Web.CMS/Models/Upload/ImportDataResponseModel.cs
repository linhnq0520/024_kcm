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
    public class ImportDataResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ImportDataResponseModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string size_type { get; set; } = string.Empty;
           /// <summary>
        /// </summary>
        public string file_name { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long file_size { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string size_type_caption { get; set; } = string.Empty;


    }

}


