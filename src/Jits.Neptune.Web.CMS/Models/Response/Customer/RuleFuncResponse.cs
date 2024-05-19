#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null

// Jits.Neptune.Web.Framework.dll

#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Models
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ModelResponseLookupIndustry : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("code")]
        public int? cdid { get; set; }
        /// <summary>
        /// Gets or sets the value of the customer_code
        /// </summary>
        [JsonProperty("name")]
        public string captione { get; set; }

    }

}