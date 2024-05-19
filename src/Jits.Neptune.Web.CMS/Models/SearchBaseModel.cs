using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SearchBaseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page_size")]
        public int PageSize { get; set; } = int.MaxValue;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("page_index")]
        public int PageIndex { get; set; } = 0;
    }
}
