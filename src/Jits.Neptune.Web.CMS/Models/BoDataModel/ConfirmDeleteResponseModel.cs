#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfirmDeleteResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ConfirmDeleteResponseModel() { }
        /// <summary>
        /// </summary>
        [JsonProperty("status")] public int status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")] public object data { get; set; }

    }
}


