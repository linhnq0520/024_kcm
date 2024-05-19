#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvanceSearchTokenModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public AdvanceSearchTokenModel() { }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("usrid")]
        public int usrid = 0;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page_index")]
        public int page_index = 0;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page_size")]
        public int page_size = 0;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("acttype")]
        public string acttype = "I";
    }



}


