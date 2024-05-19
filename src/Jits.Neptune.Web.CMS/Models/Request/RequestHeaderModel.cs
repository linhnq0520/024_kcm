#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestHeaderModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestHeaderModel() { }

/// <summary>
/// 
/// </summary>
/// <value></value>
        public string Domain { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Url { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Lang { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> MyDevice { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long RequestTime { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int OncePacked { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string OncePackedId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string FromActionCode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string FromActionName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string FormCode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string FormName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int UserId { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PortalToken { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool isDebug { get; set; } = false;
    }
}


