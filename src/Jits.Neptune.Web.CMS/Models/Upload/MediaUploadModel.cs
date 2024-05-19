#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MediaUploadModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public MediaUploadModel() { }
        /// <summary>
        /// </summary>
        public int UserId { get; set; } =0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string MediaName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string MediaType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string MediaData { get; set; } = string.Empty;


    }
    
}


