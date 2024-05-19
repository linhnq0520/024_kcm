#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ParaServerModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ParaServerModel()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("code")] public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("des")] public string Des { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("value")] public string Value { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data_type")] public string DataType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("isAdmin")] public bool IsAdmin { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("app")] public string App { get; set; } = string.Empty;


    }
}


