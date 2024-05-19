#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Microsoft.AspNetCore.Http;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FormDataUploadModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormDataUploadModel() { }
        /// <summary>
        /// </summary>
        public string username { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string new_name_file { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IFormFile attachment { get; set; } 


    }
    
}


