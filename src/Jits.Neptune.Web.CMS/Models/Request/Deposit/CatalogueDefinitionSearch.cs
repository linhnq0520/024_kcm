using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models.Request.Deposit
{
    /// <summary>
    /// 
    /// </summary>
     public  class CatalogueDefinitionSearch : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>
        [JsonProperty("catalog_code")]
        public string CATCD { get; set; }
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("catid")] 
        public string CATID { get; set; }
        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>
        [JsonProperty("catalog_name")] 
        public string CATNAME { get; set; }
        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>
        [JsonProperty("catalog_status")] 
        public string CATSTS { get; set; }
        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>
        [JsonProperty("currency_code")] 
        public string CCRCD { get; set; }
        /// <summary>
        /// Gets or sets the value of the crdfacility
        /// </summary>
        [JsonProperty("deposit_type")] 
        public string DPTTYPECT { get; set; }
        /// <summary>
        /// Gets or sets the value of the crdtype
        /// </summary>
        [JsonProperty("passbook_or_statement_or_receipt")] 
        public string PBSTCT { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the tntype
        /// </summary>
        [JsonProperty("tenor")]
        public string TENOR { get; set; }

            /// <summary>
        /// Gets or sets the value of the tntype
        /// </summary>
        [JsonProperty("tenor_unit")] 
        public string TENORUNCT { get; set; }


        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;

    }
}
