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
    public class ImportDataUploadModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ImportDataUploadModel() { }
        /// <summary>
        /// </summary>
        public string cpn_code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool isMore { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string data_array { get; set; } = string.Empty;


    }

}


