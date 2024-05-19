#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public UploadResponseModel() { }
        /// <summary>
        /// </summary>
        public string user_id { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string name { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int status { get; set; } = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int statusCode { get; set; } = 200;


    }

}


