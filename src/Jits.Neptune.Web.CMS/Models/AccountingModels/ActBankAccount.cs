using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MultiValueName : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("laos_name")]
        public string L { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("thai_name")]
        public string T { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("khmer_name")]
        public string K { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vietnamese_name")]
        public string V { get; set; } = null;
    }
}
