using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Models.Response.Deposit
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogueDefinitionSearchResponse:BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>
        [JsonProperty("catalog_code")]
        public string catcd { get; set; }
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("catid")]
        public int catid { get; set; }
        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>
        [JsonProperty("catalog_name")]
        public string catname { get; set; }
        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>
        [JsonProperty("catalog_status")]
        public string catstsct { get; set; }
        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// Gets or sets the value of the crdfacility
        /// </summary>
        [JsonProperty("deposit_type")]
        public string dpttypect { get; set; }
        /// <summary>
        /// Gets or sets the value of the crdtype
        /// </summary>
        [JsonProperty("passbook_or_statement_or_receipt")]
        public string pbstct { get; set; }
       
        /// <summary>
        /// Gets or sets the value of the tntype
        /// </summary>
        [JsonProperty("tenor")]
        public int TENOR { get; set; }

        /// <summary>
        /// Gets or sets the value of the tntype
        /// </summary>
        [JsonProperty("tenor_unit")]
        public string tenorunct { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CatalogSearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>
        [JsonProperty("catalog_code")]
        public string catcd { get; set; }
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("catid")]
        public int catid { get; set; }
        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>
        [JsonProperty("catalog_name")]
        public string catname { get; set; }
        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>
        [JsonProperty("catalog_status")]
        public string catstsct { get; set; }
        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// Gets or sets the value of the crdfacility
        /// </summary>
        [JsonProperty("deposit_type")]
        public string dpttypect { get; set; }
        /// <summary>
        /// Gets or sets the value of the crdtype
        /// </summary>
        [JsonProperty("passbook_or_statement_or_receipt")]
        public string pbstct { get; set; }

        /// <summary>
        /// Gets or sets the value of the tntype
        /// </summary>
        [JsonProperty("tenor")]
        public int TENOR { get; set; }

        /// <summary>
        /// Gets or sets the value of the tntype
        /// </summary>
        [JsonProperty("tenor_unit")]
        public string tenorunct { get; set; }
    }
}
