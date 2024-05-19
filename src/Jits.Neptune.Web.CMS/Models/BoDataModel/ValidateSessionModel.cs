#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateSessionModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ValidateSessionModel() { }
        /// <summary>
        /// </summary>
        public string SessionMode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool IsValid { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ErrorMsg { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ErrorCode { get; set; } = string.Empty;
    }
}


