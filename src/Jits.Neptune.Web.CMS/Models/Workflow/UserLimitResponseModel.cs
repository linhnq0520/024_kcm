#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserLimitResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public UserLimitResponseModel() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("currency")] public List<string> currency { get; set; } = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("data")] public List<object> data { get; set; } = new List<object>();


    }
}


