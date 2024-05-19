using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System;

namespace Jits.Neptune.Web.CMS.Models.Request.Job
{    /// <summary>
     /// 
     /// </summary>
    public class MTGAccountInformationResponse : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the acname
        /// </summary>acname
        [JsonProperty("account_name")] public string acname { get; set; }

        /// <summary>
        /// Gets or sets the value of the acno
        /// </summary>acno
        [JsonProperty("account_number")] public string acno { get; set; }

        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the customercd
        /// </summary>customercd
        [JsonProperty("customer_code")] public string customercd { get; set; }

        ///// <summary>
        ///// Gets or sets the value of the defacno
        ///// </summary>defacno
       // [JsonProperty("defacno")] public string defacno { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("collateral_asset_classification")] 
        public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] public string matype { get; set; }

        /// <summary>
        /// Gets or sets the value of the mtgsts
        /// </summary>mtgsts
        [JsonProperty("collateral_account_status")] public string mtgsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the refid
        /// </summary>refid
        [JsonProperty("reference_number")] public string refid { get; set; }

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
    public class MTGAccountInformationViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number_def")]
        public string DEFACNO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")]
        public string ACNO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_id")]
        public int? BRANCHID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("customer_code")] 
        public string CUSTOMERCD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency_code")]
        public string CCRCD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("approved_by_code")]
        public string APRCD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_code")]
        public string BRANCHCD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_code")]
        public string CATCD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("evaluate_date")]
        public DateTime evaluate_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VALRDT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("evaluate_by")]
        public string VALRNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("net_book_value_after_depreciation")]
        public int? DNBV { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("book_currency_code")]
        public string BKCRRCD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")]
        public string ACNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("customer_type")]
        public string CTMTYPE { get; set; }
        

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("book_scope")]
        public string BKSCOPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("collateral_asset_type")]
        public string MATYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("collateral_rate")]
        public decimal MARATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("collateral_asset_classification")]
        public string MACLASS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("risk_allocation_rate")]
        public int? RKRATE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("collateral_account_status")]
        public string MTGSTS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("security_paper_type")]
        public string PPTYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("paper_number")] 
        public string PPNO { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("other_paper_data")]
        public MultiOtherPaperData OPAPER { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("other_address")]
        public MultiOtherAddress MADDR { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("collateral_asset_value")]
        public int? MAVALUE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("market_value")]
        public int? MAMKVAL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("book_value")]
        public int? MABV { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mortage_amount")]
        public decimal? MAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("released_collateral_amount")]
        public int? RLAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keeping_amount")]
        public int? KPAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("keeping_release_amount")]
        public int? KPRL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("other_counter_party_collateral_amount")]
        public int? OPAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("other_counter_party_collateral_released")]
        public int? OPRL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sum_insurance_amount")]
        public int? ISVAL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("premium_amount")]
        public int? ISAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("was_register_at_collateral_center")]
        public string ISREG { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("depreciation_option")]
        public string ISDEP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("original_amount")]
        public int? OAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("accumulate_of_depreciation_amount")]
        public int? ACMAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("week_debit")]
        public int? WDR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("week_credit")]
        public int? WCR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("month_debit")]
        public int? MDR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("month_credit")]
        public int? MCR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quarter_debit")]
        public int? QDR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quarter_credit")]
        public int? QCR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("semi_annual_debit")]
        public int? HDR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("semi_annual_credit")]
        public int? HCR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("year_debit")]
        public int? YDR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("year_credit")]
        public int? YCR { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_by_code")]
        public string USRCD { get; set; }

        //[JsonProperty("approved_by")]
        //public int APUSER { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_manager_staff_code")]
        public string CRMCD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("open_date")]
        public DateTime open_date { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string OPNDT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("close_date")]
        public DateTime close_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CLSDT { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_transaction_date")]
        public DateTime last_transaction_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LASTDT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("remark")]
        public string RMKFLD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reference_number")]
        public string REFID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cc_contract")]
        public string CCONTRACT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cc_amount")]
        public int? CCAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("location")]
        public string LOCATION { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("owner")]
        public string OWNER { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_define1")]
        public string UD1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_define2")]
        public string UD2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_define3")]
        public string UD3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_define4")]
        public string UD4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_define5")]
        public string UD5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiry_date")]
        public DateTime expiry_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EXPRDT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("company_issues_policy")]
        public string CIPLCY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("policy_amount")]
        public int? PLCYAMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("policy_number")]
        public string PLCYNO { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("receiv_date")]
        public DateTime receiv_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string REIVDT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("receiv_sts")]
        public string REIVSTT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("owner_security_type")]
        public string OSTYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("guarantor_security_type")]
        public string GSTYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;
    }


}