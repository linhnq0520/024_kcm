using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System;

namespace Jits.Neptune.Web.CMS.Models.Request.Job
{    /// <summary>
     /// 
     /// </summary>
    public class MTGAccountInformationSearch : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the acname
        /// </summary>acname
        [JsonProperty("account_name")] 
        public string acname { get; set; }

        /// <summary>
        /// Gets or sets the value of the acno
        /// </summary>acno
        [JsonProperty("account_number")] 
        public string acno { get; set; }

        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] 
        public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] 
        public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the customercd
        /// </summary>customercd
        [JsonProperty("customer_code")] 
        public string customercd { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("collateral_asset_classification")] 
        public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] 
        public string matype { get; set; }

        /// <summary>
        /// Gets or sets the value of the mtgsts
        /// </summary>mtgsts
        [JsonProperty("collateral_account_status")] 
        public string mtgsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the refid
        /// </summary>refid
        [JsonProperty("reference_number")] 
        public string refid { get; set; }

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
    public class MTGAccountViewRequest : BaseNeptuneModel
    {

        /// <summary>
        /// Gets or sets the value of the defacno
        /// </summary>defacno
        public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string workflowFun { get; set; }

    }
        /// <summary>
        /// 
        /// </summary>
        public class MTGAccountInsertRequest : BaseNeptuneModel
    {
        /// <summary>
        /// AccountNumberDef
        /// </summary>
        [JsonProperty("account_number_def")]
        public string  DEFACNO { get; set; }

        /// <summary>
        /// AccountNumber
        /// </summary>
        [JsonProperty("account_number")]
        public string ACNO { get; set; }

        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("branch_code")]
        public string BRANCHID { get; set; }

        /// <summary>
        /// CurrencyCode
        /// </summary>
        [JsonProperty("currency_code")]
        public string CCRCD { get; set; }

        /// <summary>
        /// BookCurrencyCode
        /// </summary>
        [JsonProperty("book_currency_code")]
        public string BKCCRCD { get; set; }

        /// <summary>
        /// AccountName
        /// </summary>
        [JsonProperty("account_name")]
        public string ACNAME { get; set; }

        /// <summary>
        /// CustomerCode
        /// </summary>
        [JsonProperty("customer_code")]
        public string CUSTOMERID { get; set; }

        /// <summary>
        /// CustomerType
        /// </summary>
        [JsonProperty("customer_type")]
        public string CTMTYPE { get; set; }

        /// <summary>
        /// CatalogCode
        /// </summary>
        [JsonProperty("catalog_code")]
        public string CATID { get; set; }

        /// <summary>
        /// BookScope
        /// </summary>
        [JsonProperty("book_scope")]
        public string BKSCOPE { get; set; }

        /// <summary>
        /// CollateralAssetType
        /// </summary>
        [JsonProperty("collateral_asset_type")]
        public string MATYPE { get; set; }

        /// <summary>
        /// CollateralRate
        /// </summary>
        [JsonProperty("collateral_rate")]
        public int? MARATE { get; set; }

        /// <summary>
        /// CollateralAssetClassification
        /// </summary>
        [JsonProperty("collateral_asset_classification")]
        public string MACLASS { get; set; }

        /// <summary>
        /// RiskAllocationRate
        /// </summary>
        [JsonProperty("risk_allocation_rate")]
        public int? RKRATE { get; set; }

        /// <summary>
        /// CollateralAccountStatus
        /// </summary>
        [JsonProperty("collateral_account_status")]
        public string MTGSTS { get; set; }

        /// <summary>
        /// SecurityPaperType
        /// </summary>
        [JsonProperty("security_paper_type")]
        public string PPTYPE { get; set; }

        /// <summary>
        /// SecurityPaperNumber
        /// </summary>
        [JsonProperty("security_paper_number")]
        public string PPNO { get; set; }

        /// <summary>
        /// OtherPaperData
        /// </summary>
        [JsonProperty("other_paper_data")]
        public string OPAPER { get; set; }

        /// <summary>
        /// CollateralAssetValue
        /// </summary>
        [JsonProperty("collateral_asset_value")]
        public int? MAVALUE { get; set; }

        /// <summary>
        /// MarketValue
        /// </summary>
        [JsonProperty("market_value")]
        public int? MAMKVAL { get; set; }

        /// <summary>
        /// BookValue
        /// </summary>
        [JsonProperty("book_value")]
        public int? MABV { get; set; }

        /// <summary>
        /// MortgageAmount
        /// </summary>
        [JsonProperty("mortgage_amount")]
        public int? MAMT { get; set; }

        /// <summary>
        /// ReleasedCollateralAmount
        /// </summary>
        [JsonProperty("released_collateral_amount")]
        public int? RLAMT { get; set; }

        /// <summary>
        /// KeepingAmount
        /// </summary>
        [JsonProperty("keeping_amount")]
        public int? KPAMT { get; set; }

        /// <summary>
        /// KeepingReleaseAmount
        /// </summary>
        [JsonProperty("keeping_release_amount")]
        public int? KPRL { get; set; }

        /// <summary>
        /// OtherCounterPartyCollateralAmount
        /// </summary>
        [JsonProperty("other_counter_party_collateral_amount")]
        public int? OPAMT { get; set; }

        /// <summary>
        /// OtherCounterPartyCollateralReleased
        /// </summary>
        [JsonProperty("other_counter_party_collateral_released")]
        public int? OPRL { get; set; }

        /// <summary>
        /// SumInsuranceAmount
        /// </summary>
        [JsonProperty("sum_insurance_amount")]
        public int? ISVAL { get; set; }

        /// <summary>
        /// PremiumAmount
        /// </summary>
        [JsonProperty("premium_amount")]
        public int? ISAMT { get; set; }

        /// <summary>
        /// WasRegisterAtCollateralCenter
        /// </summary>
        [JsonProperty("was_register_at_collateral_center")]
        public bool ISREG { get; set; }

        /// <summary>
        /// DepreciationOption
        /// </summary>
        [JsonProperty("depreciation_option")]
        public string ISDEP { get; set; }

        /// <summary>
        /// OriginalAmount
        /// </summary>
        [JsonProperty("original_amount")]
        public int? OAMT { get; set; }

        /// <summary>
        /// AccumulateOfDepreciationAmount
        /// </summary>
        [JsonProperty("accumulate_of_depreciation_amount")]
        public int? ACMAMT { get; set; }

        /// <summary>
        /// NetBookValueAfterDepreciation
        /// </summary>
        [JsonProperty("net_book_value_after_depreciation")]
        public int? DNBV { get; set; }

        /// <summary>
        /// WeekDebit
        /// </summary>
        [JsonProperty("week_debit")]
        public int? WDR { get; set; }

        /// <summary>
        /// WeekCredit
        /// </summary>
        [JsonProperty("week_credit")]
        public int? WCR { get; set; }

        /// <summary>
        /// MonthDebit
        /// </summary>
        [JsonProperty("month_debit")]
        public int? MDR { get; set; }

        /// <summary>
        /// MonthCredit
        /// </summary>
        [JsonProperty("month_credit")]
        public int? MCR { get; set; }

        /// <summary>
        /// QuarterDebit
        /// </summary>
        [JsonProperty("quarter_debit")]
        public int? QDR { get; set; }

        /// <summary>
        /// QuarterCredit
        /// </summary>
        [JsonProperty("quarter_credit")]
        public int? QCR { get; set; }

        /// <summary>
        /// SemiAnnualDebit
        /// </summary>
        [JsonProperty("semi_annual_debit")]
        public int? HDR { get; set; }

        /// <summary>
        /// SemiAnnualCredit
        /// </summary>
        [JsonProperty("semi_annual_credit")]
        public int? HCR { get; set; }

        /// <summary>
        /// YearDebit
        /// </summary>
        [JsonProperty("year_debit")]
        public int? YDR { get; set; }

        /// <summary>
        /// YearCredit
        /// </summary>
        [JsonProperty("year_credit")]
        public int? YCR { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        [JsonProperty("created_by")]
        public string USRID { get; set; }

        /// <summary>
        /// ApprovedBy
        /// </summary>
        [JsonProperty("approved_by")]
        public string APUSER { get; set; }

        /// <summary>
        /// AccountManagerStaffCode
        /// </summary>
        [JsonProperty("account_manager_staff_code")]
        public string CRMID { get; set; }

        /// <summary>
        /// OpenDate
        /// </summary>
        [JsonProperty("open_date")]
        public DateTime OPNDT { get; set; }

        /// <summary>
        /// CloseDate
        /// </summary>
        [JsonProperty("close_date")]
        public DateTime CLSDT { get; set; }

        /// <summary>
        /// LastTransactionDate
        /// </summary>
        [JsonProperty("last_transaction_date")]
        public DateTime LASTDT { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        [JsonProperty("remark")]
        public string RMKFLD { get; set; }

        /// <summary>
        /// ReferenceNumber
        /// </summary>
        [JsonProperty("reference_number")]
        public string REFID { get; set; }

        /// <summary>
        /// CCContract
        /// </summary>
        [JsonProperty("cc_contract")]
        public string CCONTRACT { get; set; }

        /// <summary>
        /// CCAmount
        /// </summary>
        [JsonProperty("cc_amount")]
        public int? CCAMT { get; set; }

        /// <summary>
        /// OtherAddress
        /// </summary>
        [JsonProperty("other_address")]
        public string MADDR { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [JsonProperty("location")]
        public string LOCATION { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        [JsonProperty("owner")]
        public string OWNER { get; set; }

        /// <summary>
        /// UserDefine1
        /// </summary>
        [JsonProperty("user_define1")]
        public string UD1 { get; set; }

        /// <summary>
        /// UserDefine2
        /// </summary>
        [JsonProperty("user_define2")]
        public string UD2 { get; set; }

        /// <summary>
        /// UserDefine3
        /// </summary>
        [JsonProperty("user_define3")]
        public string UD3 { get; set; }

        /// <summary>
        /// UserDefine4
        /// </summary>
        [JsonProperty("user_define4")]
        public string UD4 { get; set; }

        /// <summary>
        /// UserDefine5
        /// </summary>
        [JsonProperty("user_define5")]
        public string UD5 { get; set; }

        /// <summary>
        /// CompanyIssuesPolicy
        /// </summary>
        [JsonProperty("company_issues_policy")]
        public string CIPLCY { get; set; }

        /// <summary>
        /// ExpiryDate
        /// </summary>
        [JsonProperty("expiry_date")]
        public DateTime? EXPRDT { get; set; }

        /// <summary>
        /// PolicyAmount
        /// </summary>
        [JsonProperty("policy_amount")]
        public int? PLCYAMT { get; set; }

        /// <summary>
        /// PolicyNumber
        /// </summary>
        [JsonProperty("policy_number")]
        public string PLCYNO { get; set; }

        /// <summary>
        /// LegalLocalAddress
        /// </summary>
        [JsonProperty("legal_local_address")]
        public string LADDR { get; set; }

        /// <summary>
        /// LocalAddress
        /// </summary>
        [JsonProperty("local_address")]
        public string ADDRESS { get; set; }

        /// <summary>
        /// EvaluateBy
        /// </summary>
        [JsonProperty("evaluate_by")]
        public string EVABY { get; set; }

        /// <summary>
        /// EvaluateMethod
        /// </summary>
        [JsonProperty("evaluate_method")]
        public string EVAME { get; set; }

        /// <summary>
        /// EvaluateDate
        /// </summary>
        [JsonProperty("evaluate_date")]
        public DateTime EVADT { get; set; }

        /// <summary>
        /// NewEvaluateDate
        /// </summary>
        [JsonProperty("new_evaluate_date")]
        public DateTime EVANDT { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MTGAccountUpdateRequest : BaseNeptuneModel
    {

        /// <summary>
        /// Gets or sets the value of the defacno
        /// </summary>defacno
        [JsonProperty("account_number_def")] 
        public string defacno { get; set; }
        /// <summary>
        /// Gets or sets the value of the acname
        /// </summary>acname
        [JsonProperty("account_name")] 
        public string acname { get; set; }

        /// <summary>
        /// Gets or sets the value of the acno
        /// </summary>acno
        [JsonProperty("account_number")] 
        public string acno { get; set; }

        /// <summary>
        /// Gets or sets the value of the catcd
        /// </summary>catcd
        [JsonProperty("catalog_code")] 
        public string catcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the ccrcd
        /// </summary>ccrcd
        [JsonProperty("currency_code")] 
        public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the customercd
        /// </summary>customercd
        [JsonProperty("customer_code")] 
        public string customercd { get; set; }

        /// <summary>
        /// Gets or sets the value of the maclass
        /// </summary>maclass
        [JsonProperty("collateral_asset_classification")] 
        public string maclass { get; set; }

        /// <summary>
        /// Gets or sets the value of the matype
        /// </summary>matype
        [JsonProperty("collateral_asset_type")] 
        public string matype { get; set; }

        /// <summary>
        /// Gets or sets the value of the mtgsts
        /// </summary>mtgsts
        [JsonProperty("collateral_account_status")] 
        public string mtgsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the refid
        /// </summary>refid
        [JsonProperty("reference_number")] 
        public string refid { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MTGAccountDeleteRequest : BaseNeptuneModel
    {

        /// <summary>
        /// Gets or sets the value of the defacno
        /// </summary>
        [JsonProperty("account_number_def")] 
        public string defacno { get; set; }
    }
}