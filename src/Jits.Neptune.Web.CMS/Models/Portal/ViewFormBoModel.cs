#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewFormBoModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewFormBoModel() { }
        /// <summary>
        /// </summary>
        public string form_key { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string table_code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string node_src_convert { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string key_src_convert_block { get; set; } = string.Empty;
    }

}


