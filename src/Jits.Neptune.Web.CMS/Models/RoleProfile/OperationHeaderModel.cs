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
    public class OperationHeaderModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public OperationHeaderModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("cmdid")]
        public string cmdid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("caption")]
        public string caption { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class OperationBodyModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public OperationBodyModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("cmdid")]
        public string cmdid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("caption")]
        public string caption { get; set; }

    }
}




