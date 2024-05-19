#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAndDownloadFileModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAndDownloadFileModel() { }
        /// <summary>
        /// </summary>
        public string lang_confirm { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string key_api_convert { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string table_code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string key_val { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string file_name { get; set; } = string.Empty;



    }

}


