#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SSIDModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SSIDModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int UsrId { get; set; }
        /// <summary>
        /// ListToken
        /// </summary>
        public List<string> ListToken { get; set; }

    }
}


