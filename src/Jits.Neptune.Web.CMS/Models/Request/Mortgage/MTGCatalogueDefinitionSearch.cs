using Newtonsoft.Json;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Core;

namespace Jits.Neptune.Web.CMS.Models.Request.Mortgage
{
    /// <summary>
    /// Request module of MTG Catalogue Definition Search
    /// </summary>
    public class MTGCatalogueDefinitionSearch : SearchBaseModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("id")] public int catid { get; set; }

        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>
        [JsonProperty("catalog_name")] public string catname { get; set; }

        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>
        [JsonProperty("catalog_status")] public string catsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>
        [JsonProperty("currency_code")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>
        [JsonProperty("classification")] public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>
        [JsonProperty("collateral_rate_to")] public int marate { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>
        [JsonProperty("oprtval_marate")] public string oprtval_marate { get; set; }

        /// <summary>
        /// Gets or sets the value of the risk_rate
        /// </summary>
        [JsonProperty("risk_rate")] public int rkrate { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>
        [JsonProperty("collateral_asset_type")] public string matype { get; set; }

        ///// <summary>
        ///// PageIndex
        ///// </summary>
        //public int PageIndex { get; set; } = 0;

        ///// <summary>
        ///// PageSize
        ///// </summary>
        //public int PageSize { get; set; } = int.MaxValue;
    }

    /// <summary>
    /// Module View  By catid
    /// </summary>
    public class ViewModelWithCatId : BaseTransactionModel
    {   
         /// <summary>
         ///  catid
         /// </summary>
        public int id { get; set; }
    }

    /// <summary>
    /// Insert Module
    /// </summary>
    public class MTGCatalogueDefinitionUpdateRequest : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>catid
        [JsonProperty("id")] public int CATID { get; set; }

        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] public string CATCD { get; set; }

        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>catname
        [JsonProperty("catalog_name")] public string CATNAME { get; set; }

        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>catsts
        [JsonProperty("catalog_status")] public string CATSTS { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] public string CCRCD { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("classification")] public string MACLASS { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>marate
        [JsonProperty("collateral_rate")] public int MARATE { get; set; }

        /// <summary>
        /// Gets or sets the value of the risk_rate
        /// </summary>risk_rate
        [JsonProperty("risk_rate")] public int RKRATE { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] public string MATYPE { get; set; }
        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        /// 
        [JsonProperty("book_scope")] public string BKSCOPE { get; set; }
        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        /// 
        [JsonProperty("depreciation_option")] public string ISDEP { get; set; }

        /// <summary>
        /// Gets or sets the value of the USRID
        /// </summary>matype
        [JsonProperty("created_by")] public int USRID { get; set; }

        /// <summary>
        /// Gets or sets the value of the owner_stype
        /// </summary>owner_stype
        [JsonProperty("owner_stype")] public string OSTYPE { get; set; }

        /// <summary>
        /// Gets or sets the value of the guarantor_stype
        /// </summary>guarantor_stype
        [JsonProperty("guarantor_stype")] public string GSTYPE { get; set; }

    }


    /// <summary>
    /// Insert Module
    /// </summary>
    public class MTGCatalogueDefinitionInsertRequest : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("id")] public int? CATID { get; set; }

        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>
        [JsonProperty("catalog_code")] public string CATCD { get; set; }

        /// <summary>
        /// Gets or sets the value of the catname
        /// </summary>
        [JsonProperty("catalog_name")] public string CATNAME { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>
        [JsonProperty("currency_code")] public string CCRCD { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>
        [JsonProperty("collateral_asset_type")] public string MATYPE { get; set; }

        /// <summary>
        /// Gets or sets the value of the marate
        /// </summary>
        [JsonProperty("collateral_rate")] public int? MARATE { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>
        [JsonProperty("classification")] public string MACLASS { get; set; }

        /// <summary>
        /// Gets or sets the value of the risk_rate
        /// </summary>
        [JsonProperty("risk_rate")] public int? RKRATE { get; set; }

        /// <summary>
        /// Gets or sets the value of the USRID
        /// </summary>
        [JsonProperty("created_by")] public int? USRID { get; set; }
        /// <summary>
        /// Gets or sets the value of the BKSCOPE
        /// </summary>
        /// 
        [JsonProperty("book_scope")] public string BKSCOPE { get; set; }

        /// <summary>
        /// Gets or sets the value of the ISDEP
        /// </summary>
        [JsonProperty("depreciation_option")] public string ISDEP { get; set; }

        /// <summary>
        /// Gets or sets the value of the APUSER
        /// </summary>
        [JsonProperty("approved_by")] public int APUSER   { get; set; }

        /// <summary>
        /// Gets or sets the value of the catsts
        /// </summary>catsts
        [JsonProperty("catalog_status")] public string CATSTS { get; set; }

        /// <summary>
        /// Gets or sets the value of the owner_stype
        /// </summary>owner_stype
        [JsonProperty("owner_stype")] public string OSTYPE { get; set; }

        /// <summary>
        /// Gets or sets the value of the guarantor_stype
        /// </summary>guarantor_stype
        [JsonProperty("guarantor_stype")] public string GSTYPE { get; set; }
        

    }
    /// <summary>
    /// update Module
    /// </summary>
    public  class MTGCatalogueDefinitionDeleteRequest : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("id")] public int CATID { get; set; }
        /// <summary>
        /// Gets or sets the value of the USRID
        /// </summary>
        [JsonProperty("created_by")] public int USRID { get; set; }

    }
}