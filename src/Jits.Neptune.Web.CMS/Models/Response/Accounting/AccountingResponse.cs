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
    public class ActBankAccountDefinitionSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_classification")] public string accls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_group")] public string acgrp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_level")] public int? aclvl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance_side")] public string bside { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency_code")] public string ccrcd { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ActAccountMapTableSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapping_id")] public string mapid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapping_table_name")] public string mapname { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActAccountLinkageSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("map_id")] public string mapid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bac_no1")] public string bacno1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("map_name")] public string mapname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name_ac1")] public string nameac1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sac_no")] public string sacno { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActGroupDefinitionSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_id")] public int? grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("o9module")] public string o9module { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_group_def")] public string acgrpdef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("module")] public string mdlname { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActModuleAccountListSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("system_account_name")] public string acgrpname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_define_account_name")] public string bacgrpname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("o9module")] public string o9module { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("module")] public string mdlname { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActAccountOfGroupSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_group_def")] public string acgrpdef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("desc")] public string descr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_id")] public int grpid { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActAccountOfGroupMappingSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ac_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ac_no")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bac_name")] public string bacname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bac_no")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("grp_id")] public int? grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_acno")] public string refacno { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActCommonAccountDefinitionSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_account_number")] public string refacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_account_number2")] public string refacno2 { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActClearAccountDefinitionSearchResponse : BaseNeptuneModel
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_code")] public int? branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_name")] public string brname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency_code")] public string ccrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_branch_code")] public int? clrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_branch_name")] public string clridct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type")] public string clrtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type_caption")] public string clrtypect { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActForeignExchangeAccountDefinitionSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_currency")] public string acccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_id")] public int branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_code")] public string branchcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_name")] public string brname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_currency")] public string clrccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type")] public string clrtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type_caption")] public string clrtypect { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetAndToolSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("booking_currency_code")] public string bkccrcd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")] public string defacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_status")] public string fasts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_type")] public string fatype { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetCatalogueDefinitionSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")] public int catid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_name")] public string catname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_status")] public string catsts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("depreciation_method")] public string depmode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_classification")] public string faclass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_type")] public string fatype { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActCommonAccountMappingSearchResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ac_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bac_no")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_acno")] public string refacno { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActBankAccountDefinitionViewResponse : BaseNeptuneModel
    {
          /// <summary>
          /// 
          /// </summary>
        [JsonProperty("id")] 
        public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] 
        public string bacno { get; set; }

        /// <summary>
        /// CurrencyCode
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }
        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcode { get; set; }
        /// <summary>
        /// ParentAccountId
        /// </summary>
        [JsonProperty("parent_account_id")]
        public string parentid { get; set; }
        /// <summary>
        /// AccountLevel
        /// </summary>
        [JsonProperty("account_level")]
        public int aclvl { get; set; }
        /// <summary>
        /// IsAccountLeave
        /// </summary>
        [JsonProperty("is_account_leave")]
        public string isleave { get; set; }
        /// <summary>
        /// BalanceSide
        /// </summary>
        [JsonProperty("balance_side")]
        public string bside { get; set; }
        /// <summary>
        /// ReverseBalance 
        /// </summary>
        [JsonProperty("reverse_balance")]
        public string rbal { get; set; }
        /// <summary>
        /// PostingSide
        /// </summary>
        [JsonProperty("posting_side")]
        public string pside { get; set; }
        /// <summary>
        /// AccountName
        /// </summary>
        [JsonProperty("account_name")]
        public string acname { get; set; }
        /// <summary>
        /// ShortAccountName
        /// </summary>
        [JsonProperty("short_account_name")]
        public string sname { get; set; }

        /// <summary>
        /// MultiValueName
        /// </summary>
        [JsonProperty("multi_value_name")]
        public MultiValueName multivaluename { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mname")]
        public string mname { get; set; }

        /// <summary>
        /// AccountClassification
        /// </summary>
        [JsonProperty("account_classification")]
        public string accls { get; set; }
        /// <summary>
        /// AccountCategories
        /// </summary>
        [JsonProperty("account_categories")]
        public string accat { get; set; }
        /// <summary>
        /// AccountGroup
        /// </summary>
        [JsonProperty("account_group")]
        public string acgrp { get; set; }
        /// <summary>
        /// DirectPosting
        /// </summary>
        [JsonProperty("direct_posting")]
        public string isdirect { get; set; }
        /// <summary>
        /// IsVisible
        /// </summary>
        [JsonProperty("is_visible")]
        public string isvisible { get; set; }
        /// <summary>
        /// IsMultiCurrency
        /// </summary>
        [JsonProperty("is_multi_currency")]
        public string ismulticcy { get; set; }
        /// <summary>
        /// JobProcessOption
        /// </summary>
        [JsonProperty("job_process_option")]
        public string jobopt { get; set; }
        /// <summary>
        /// RefAccountNumber
        /// </summary>
        [JsonProperty("ref_account_number")]
        public string refac { get; set; }
        /// <summary>
        /// ReferencesNumber
        /// </summary>
        [JsonProperty("references_number")]
        public string refnum { get; set; }
        /// <summary>
        /// Is Cash Account
        /// </summary>
        [JsonProperty("is_cash_account")]
        public bool iscashaccount { get; set; }
        /// <summary>
        /// Is Master Account
        /// </summary>
        [JsonProperty("is_master_account")]
        public bool ismasteraccount { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class ActClearAccountDefinitionViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// BranchId
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }

        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcd { get; set; }
        /// <summary>
        /// BranchName
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }
        /// <summary>
        /// CurrencyId
        /// </summary>
        [JsonProperty("currency_id")]
        public string ccrid { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// ClearingBranchCode
        /// </summary>
        [JsonProperty("clearing_branch_code")]
        public int clrid { get; set; }
        /// <summary>
        /// ClearingBranchName
        /// </summary>
        [JsonProperty("clearing_branch_name")]
        public string clridct { get; set; }
        /// <summary>
        /// ClearingType
        /// </summary>
        [JsonProperty("clearing_type")]
        public string clrtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type_caption")] public string clrtypect { get; set; }
        /// <summary>
        /// AccountNumber
        /// </summary>
        [JsonProperty("id")]
        public string acno { get; set; }
        /// <summary>
        /// Account Name
        /// </summary>
        [JsonProperty("account_name")]
        public string acname { get; set; }
        /// <summary>
        /// Bank Account Number
        /// </summary>
        [JsonProperty("bank_account_number")]
        public string bacno { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ActGroupDefinitionViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_id")] public int grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("o9module")] public string o9module { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_group_def")] public string acgrpdef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("module")] public string mdlname { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActModuleAccountListViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("system_account_name")] public string acgrpname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_define_account_name")] public string bacgrpname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("o9module")] public string o9module { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("module")] public string mdlname { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActAccountOfGroupViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_group_def")] public string acgrpdef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("desc")] public string descr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_id")] public int grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_account_number")] public string refacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_account_number2")] public string refacno2 { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActCommonAccountDefinitionViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_account_number")] public string refacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ref_account_number2")] public string refacno2 { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActForeignExchangeAccountDefinitionViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_currency")] public string acccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_id")] public int branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_code")] public string branchcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_name")] public string brname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_currency")] public string clrccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type")] public string clrtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type_caption")] public string clrtypect { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetAndToolViewResponse : BaseNeptuneModel
    {
        /// <summary>
        /// Defacno
        /// </summary>
        [JsonProperty("id")]
        public string defacno { get; set; }
        /// <summary>
        /// Acno
        /// </summary>
        [JsonProperty("account_number")]
        public string acno { get; set; }
        /// <summary>
        /// Branchid
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }
        /// <summary>
        /// Ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// Acname
        /// </summary>
        [JsonProperty("fixed_asset_account_name")]
        public string acname { get; set; }
        /// <summary>
        /// Owner
        /// </summary>
        [JsonProperty("owner")]
        public string owner { get; set; }
        /// <summary>
        /// Customerid
        /// </summary>
        [JsonProperty("customer_id")]
        public int? customerid { get; set; }
        /// <summary>
        /// Ctmtype
        /// </summary>
        [JsonProperty("customer_type")]
        public string ctmtype { get; set; }
        /// <summary>
        /// Catid
        /// </summary>
        [JsonProperty("catalog_id")]
        public int catid { get; set; }
        /// <summary>
        /// Refnum
        /// </summary>
        [JsonProperty("reference_number")]
        public string refnum { get; set; }
        /// <summary>
        /// Fatype
        /// </summary>
        [JsonProperty("fixed_asset_type")]
        public string fatype { get; set; }
        /// <summary>
        /// Faclass
        /// </summary>
        [JsonProperty("fixed_asset_classification")]
        public string faclass { get; set; }
        /// <summary>
        /// Depmode
        /// </summary>
        [JsonProperty("depreciation_method")]
        public string depmode { get; set; }
        /// <summary>
        /// Fagrp
        /// </summary>
        [JsonProperty("fixed_asset_group")]
        public string fagrp { get; set; }
        /// <summary>
        /// Falife
        /// </summary>
        [JsonProperty("fixed_asset_life_time")]
        public int? falife { get; set; }
        /// <summary>
        /// Falifeun
        /// </summary>
        [JsonProperty("fixed_asset_life_time_unit")]
        public string falifeun { get; set; }
        /// <summary>
        /// Fadrate
        /// </summary>
        [JsonProperty("depreciation_rate")]
        public decimal fadrate { get; set; }
        /// <summary>
        /// Buydt
        /// </summary>
        [JsonProperty("buydt")]
        public DateTime buydt { get; set; }
        /// <summary>
        /// Dprdt
        /// </summary>
        [JsonProperty("dprdt")]
        public DateTime dprdt { get; set; }
        /// <summary>
        /// Prname
        /// </summary>
        [JsonProperty("provider_name")]
        public string prname { get; set; }
        /// <summary>
        /// Bkccrcd
        /// </summary>
        [JsonProperty("booking_currency_code")]
        public string bkccrcd { get; set; }
        /// <summary>
        /// Wrfrdt
        /// </summary>
        [JsonProperty("wrfrdt")]
        public DateTime wrfrdt { get; set; }
        /// <summary>
        /// Wrtodt
        /// </summary>
        [JsonProperty("wrtodt")]
        public DateTime wrtodt { get; set; }
        /// <summary>
        /// Wrsrn
        /// </summary>
        [JsonProperty("wrsrn")]
        public string wrsrn { get; set; }
        /// <summary>
        /// Orgprice
        /// </summary>
        [JsonProperty("original_price")]
        public decimal orgprice { get; set; }
        /// <summary>
        /// Bkamt
        /// </summary>
        [JsonProperty("booking_amount")]
        public decimal bkamt { get; set; }
        /// <summary>
        /// Nbv
        /// </summary>
        [JsonProperty("net_booking_value")]
        public decimal nbv { get; set; }
        /// <summary>
        /// Acmamt
        /// </summary>
        [JsonProperty("accummulate_amount")]
        public decimal acmamt { get; set; }
        /// <summary>
        /// Expamt
        /// </summary>
        [JsonProperty("expense_amount")]
        public decimal expamt { get; set; }
        /// <summary>
        /// Insval
        /// </summary>
        [JsonProperty("insurrance_value")]
        public decimal insval { get; set; }
        /// <summary>
        /// Insfee
        /// </summary>
        [JsonProperty("insurrance_fee")]
        public decimal insfee { get; set; }
        /// <summary>
        /// Slvgamt
        /// </summary>
        [JsonProperty("salvage_amount")]
        public decimal slvgamt { get; set; }
        /// <summary>
        /// Inamt
        /// </summary>
        [JsonProperty("income_amount")]
        public decimal inamt { get; set; }
        /// <summary>
        /// Wdr
        /// </summary>
        [JsonProperty("week_debit")]
        public decimal wdr { get; set; }
        /// <summary>
        /// Wcr
        /// </summary>
        [JsonProperty("week_credit")]
        public decimal wcr { get; set; }
        /// <summary>
        /// Mdr
        /// </summary>
        [JsonProperty("month_debit")]
        public decimal mdr { get; set; }
        /// <summary>
        /// Mcr
        /// </summary>
        [JsonProperty("month_credit")]
        public decimal mcr { get; set; }
        /// <summary>
        /// Qdr
        /// </summary>
        [JsonProperty("quater_debit")]
        public decimal qdr { get; set; }
        /// <summary>
        /// Qcr
        /// </summary>
        [JsonProperty("quater_credit")]
        public decimal qcr { get; set; }
        /// <summary>
        /// Hdr
        /// </summary>
        [JsonProperty("semiannual_debit")]
        public decimal hdr { get; set; }
        /// <summary>
        /// Hcr
        /// </summary>
        [JsonProperty("semiannual_credit")]
        public decimal hcr { get; set; }
        /// <summary>
        /// Ydr
        /// </summary>
        [JsonProperty("year_debit")]
        public decimal ydr { get; set; }
        /// <summary>
        /// Ycr
        /// </summary>
        [JsonProperty("year_credit")]
        public decimal ycr { get; set; }
        /// <summary>
        /// Usrid
        /// </summary>
        [JsonProperty("user_id")]
        public int? usrid { get; set; }
        /// <summary>
        /// Apuser
        /// </summary>
        [JsonProperty("approve_user")]
        public int apuser { get; set; }
        /// <summary>
        /// Rmkfld
        /// </summary>
        [JsonProperty("remark")]
        public string rmkfld { get; set; }
        /// <summary>
        /// Refid
        /// </summary>
        [JsonProperty("old_id_of_customer")]
        public string refid { get; set; }
        /// <summary>
        /// Udfield1
        /// </summary>
        [JsonProperty("udfield1")]
        public string udfield1 { get; set; }
        /// <summary>
        /// Fasts
        /// </summary>
        [JsonProperty("fixed_asset_status")]
        public string fasts { get; set; }
        /// <summary>
        /// Ccrrate
        /// </summary>
        [JsonProperty("cross_rate")]
        public decimal ccrrate { get; set; }
        /// <summary>
        /// Exdate
        /// </summary>
        [JsonProperty("expire_date")]
        public DateTime exdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_created_code")]
        public string usrcd { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_created_name")]
        public string usrname { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_approved_code")]
        public string aprcd { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_approved_name")]
        public string aprname { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("staff_code")]
        public int crmid { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("staff_name")]
        public string crmname { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("catalog_code")]
        public string catcd { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("catalog_name")]
        public string catname { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetCatalogueDefinitionViewResponse : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")] public int catid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_name")] public string catname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_status")] public string catsts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("depreciation_method")] public string depmode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_classification")] public string faclass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_type")] public string fatype { get; set; }
        /// <summary>
        /// USRID
        /// </summary>
        [JsonProperty("user_id")]
        public int? usrid { get; set; }
        /// <summary>
        /// GRPID
        /// </summary>
        [JsonProperty("group_id")]
        public int grpid { get; set; }
        /// <summary>
        /// APUSER
        /// </summary>
        [JsonProperty("approve_user")]
        public int apuser { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_created_code")]
        public string usrcd { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_created_name")]
        public string usrname { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_approved_code")]
        public string aprcd { get; set; }
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("user_approved_name")]
        public string aprname { get; set; }

    }
}