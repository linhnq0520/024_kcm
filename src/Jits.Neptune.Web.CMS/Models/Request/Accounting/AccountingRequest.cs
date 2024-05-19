#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null

// Jits.Neptune.Web.Framework.dll

#endregion

using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ActBankAccountDefinitionSearch : SearchBaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ac_no")] public string acno { get; set; }
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
        [JsonProperty("oprtval_aclvl")] public string oprtval_aclvl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_level_to")] public int? aclvl { get; set; }
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
    public class ActAccountMapTableSearch : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapping_id")] public string mapid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mapping_table_name")] public string mapname { get; set; }

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
    public class ActAccountLinkageSearch : BaseNeptuneModel
    {
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
    public class ActGroupDefinitionSearch : SearchBaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_id")] public int? grpid { get; set; }
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
    public class ActModuleAccountListSearch : SearchBaseModel
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
        [JsonProperty("module")] public string mdlname { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActAccountOfGroupSearch : SearchBaseModel
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
        [JsonProperty("group_id")] public int? grpid { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActAccountOfGroupMappingSearch : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ac_name")] public string acname { get; set; }
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
    public class ActCommonAccountDefinitionSearch : SearchBaseModel
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
    public class ActClearAccountDefinitionSearch : SearchBaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] public string bacno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_name")] public string brname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("currency_id")] public string ccrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_branch_name")] public string clridct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type")] public string clrtypect { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActForeignExchangeAccountDefinitionSearch : SearchBaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_currency")] public string acccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bank_account_number")] public string bacno { get; set; }
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
        [JsonProperty("clearing_type")] public string clrtypect { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetAndToolSearch : SearchBaseModel
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
        [JsonProperty("fixed_asset_status")] public string fasts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fixed_asset_type")] public string fatype { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetCatalogueDefinitionSearch : SearchBaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }
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
    public class ActCommonAccountMappingSearch : BaseNeptuneModel
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
    public class ModelWithAcno : BaseTransactionModel
    {/// <summary>
     /// 
     /// </summary>
        public string id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActClearAccount : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ccrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int clrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clrtype { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActGroup : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string acgrpdef { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActModuleAccountList : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string acgrpname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string o9module { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActAccountOfGroup : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string acname { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActCommonAccountDefinition : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string account_name { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActForeignExchangeAccountDefinition : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string acccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clrccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clrtype { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelViewActFixedAssetAndTool : BaseTransactionModel
    {
        /// <summary>
        /// Defacno
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }      
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelInsertBankAccountDefinition : BaseNeptuneModel
    {

        /// <summary>
        /// BankAccountNumber
        /// </summary>
        [JsonProperty("bank_account_number")]
        public string bacno { get; set; }

        /// <summary>
        /// CurrencyCode
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }

        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }

        /// <summary>
        /// AllBrand
        /// </summary>
        [JsonProperty("allbranch")]
        public int allbranch { get; set; }

        /// <summary>
        /// AccountLevel
        /// </summary>
        [JsonProperty("account_level")]
        public int aclvl { get; set; }

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
        public MultiValueName mname { get; set; }

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
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelInsertGroupDefinition : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_id")]
        public int? grpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_group_def")]
        public string acgrpdef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("o9module")]
        public string o9module { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelInsertModuleAccountList : BaseNeptuneModel
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
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelInsertAccountOfGroup : BaseNeptuneModel
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
    public class ModelInsertCommonAccount : BaseNeptuneModel
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
    public class ModelInsertClearAccount : BaseNeptuneModel
    {
        /// <summary>
        /// BranchId
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }
               
        /// <summary>
        /// CurrencyId
        /// </summary>
        [JsonProperty("currency_id")]
        public string ccrid { get; set; }
       
        /// <summary>
        /// ClearingBranchCode
        /// </summary>
        [JsonProperty("clearing_branch_id")]
        public int clrid { get; set; }
        
        /// <summary>
        /// ClearingType
        /// </summary>
        [JsonProperty("clearing_type")]
        public string clrtype { get; set; }
        
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

    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelInsertForeignExchangeAccount : BaseNeptuneModel
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
        [JsonProperty("account_name")] public string acname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branch_id")] public int branchid { get; set; }       
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_currency")] public string clrccr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("clearing_type")] public string clrtype { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ModelInsertFixedAssetCatalogue : BaseNeptuneModel
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
    }
}