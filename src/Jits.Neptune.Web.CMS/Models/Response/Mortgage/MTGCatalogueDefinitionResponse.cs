using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models.Response.Mortgage
{   /// <summary>
    ///
    /// </summary>
    public class MTGCatalogueDefinitionResponse : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>catid
        [JsonProperty("id")] public int catid { get; set; }

        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>catname
        [JsonProperty("catalog_name")] public string catname { get; set; }

        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>catsts
        [JsonProperty("catalog_status")] public string catsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("classification")] public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>marate
        [JsonProperty("collateral_rate")] public int marate { get; set; }

        /// <summary>
        /// Gets or sets the value of the risk_rate
        /// </summary>risk_rate
        [JsonProperty("risk_rate")] public int? rkrate { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] public string matype { get; set; }

        /// <summary>
        /// Gets or sets the value of the owner_stype
        /// </summary>owner_stype
        [JsonProperty("owner_stype")] public string ostype { get; set; }

        /// <summary>
        /// Gets or sets the value of the guarantor_stype
        /// </summary>guarantor_stype
        [JsonProperty("guarantor_stype")] public string gstype { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class MTGCatalogueDefinitionViewResponse : BaseNeptuneModel
    {   /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>catid
        [JsonProperty("id")] public int catid { get; set; }

        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>catname
        [JsonProperty("catalog_name")] public string catname { get; set; }

        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>catsts
        [JsonProperty("catalog_status")] public string catsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("classification")] public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>marate
        [JsonProperty("collateral_rate")] public int marate { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>marate
        [JsonProperty("created_by")] public int usrid { get; set; }
        /// <summary>
        /// Gets or sets the value of the risk_rate
        /// </summary>risk_rate
        [JsonProperty("risk_rate")] public int? rkrate { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] public string matype { get; set; }

        /// <summary>
        /// Gets or sets the value of the owner_stype
        /// </summary>owner_stype
        [JsonProperty("owner_stype")] public string ostype { get; set; }

        /// <summary>
        /// Gets or sets the value of the guarantor_stype
        /// </summary>guarantor_stype
        [JsonProperty("guarantor_stype")] public string gstype { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;
    }
    /// <summary>
    /// 
    /// </summary>
    public partial class CatListDeleteResponseModel : BaseNeptuneModel
    {   /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>catid
        [JsonProperty("id")] public int catid { get; set; }

        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>catname
        [JsonProperty("catalog_name")] public string catname { get; set; }

        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>catsts
        [JsonProperty("catalog_status")] public string catsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("classification")] public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>marate
        [JsonProperty("collateral_rate")] public int marate { get; set; }

        /// <summary>
        /// Gets or sets the value of the risk_rate
        /// </summary>risk_rate
        [JsonProperty("risk_rate")] public int? rkrate { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] public string matype { get; set; }

        /// <summary>
        /// Gets or sets the value of the owner_stype
        /// </summary>owner_stype
        [JsonProperty("owner_stype")] public string ostype { get; set; }

        /// <summary>
        /// Gets or sets the value of the guarantor_stype
        /// </summary>guarantor_stype
        [JsonProperty("guarantor_stype")] public string gstype { get; set; }

    }
 }

