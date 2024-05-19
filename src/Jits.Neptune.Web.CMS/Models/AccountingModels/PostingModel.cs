using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jits.Neptune.Web.CMS.Models.AccountingModels;

/// <summary>
/// 
/// </summary>
public partial class EntryPostingReponse : BaseNeptuneModel
{
    /// <summary>
    /// Constructor
    /// </summary>
    public EntryPostingReponse()
    {
        this.EntryJournals = new List<TemporaryPosting>() { };
        this.ErrorEntryJournals = new List<TemporaryPosting>() { };
    }
    /// <summary>
    /// EntryJournals
    /// </summary>
    [JsonProperty("entry_journals")]
    public List<TemporaryPosting> EntryJournals { get; set; }
    /// <summary>
    /// ErrorEntryJournals
    /// </summary>
    [JsonProperty("error_entry_journals")]
    public List<TemporaryPosting> ErrorEntryJournals { get; set; }

    /// <summary>
    /// ErrorCode
    /// </summary>
    [JsonProperty("error_code")]
    public string ErrorCode { get; set; } = PostingErrorCode.New;
    /// <summary>
    /// IsReverse
    /// </summary>
    [JsonProperty("is_reverse")]
    public bool IsReverse { get; set; } = false;

    /// <summary>
    /// ErrorMessage
    /// </summary>
    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; }

}

/// <summary>
/// 
/// </summary>
public partial class TemporaryPosting : BaseNeptuneModel
{
    /// <summary>
    /// AccountNumber
    /// </summary>
    [JsonProperty("account_number")]
    public string bacno { get; set; } = "";

    /// <summary>
    /// BranchAccountNumber
    /// </summary>
    [JsonProperty("branch_gl_bank_account_number")]
    public string acno { get; set; }

    /// <summary>
    /// CurrencyCodeGLBankAccountNumber
    /// </summary>
    [JsonProperty("currency_code_gl_bank_account_number")]
    public string CurrencyCodeGLBankAccountNumber { get; set; }

    /// <summary>
    /// CurrencyCode
    /// </summary>
    [JsonProperty("currency_code")]
    public string ccrcd { get; set; }

    /// <summary>
    /// OriginalAmount
    /// </summary>
    [JsonProperty("original_amount")]
    public decimal OriginalAmount { get; set; }

    /// <summary>
    /// Amount
    /// </summary>
    [JsonProperty("amount")]
    public decimal amt { get; set; }

    /// <summary>
    /// AccountName
    /// </summary>
    [JsonProperty("account_name")]
    public string acname { get; set; }

    /// <summary>
    /// DebitOrCredit
    /// </summary>
    [JsonProperty("debit_or_credit")]
    public string action { get; set; }

    /// <summary>
    /// BalanceSide
    /// </summary>
    [JsonProperty("balance_side")]
    public string BalanceSide { get; set; }

    /// <summary>
    /// AccountLevel
    /// </summary>
    [JsonProperty("account_level")]
    public int AccountLevel { get; set; }

    /// <summary>
    /// AccountingEntryGroup
    /// </summary>
    [JsonProperty("accounting_entry_group")]
    public int acgrp { get; set; } = 1;

    /// <summary>
    /// AccountingEntryIndex
    /// </summary>
    [JsonProperty("accounting_entry_index")]
    public int acidx { get; set; } = 1;

    /// <summary>
    /// BaseAmount
    /// </summary>
    [JsonProperty("base_amount")]
    public string BaseAmount { get; set; }

    /// <summary>
    /// MasterBranchCode
    /// </summary>
    [JsonProperty("master_branch_code")]
    public string MasterBranchCode { get; set; }

    /// <summary>
    /// IsCashAccount
    /// </summary>
    [JsonProperty("is_cash_account")]
    public bool IsCashAccount { get; set; } = false;

    /// <summary>
    /// ClearingType
    /// </summary>
    [JsonProperty("clearing_type")]
    public string ClearingType { get; set; } = "O";

    /// <summary>
    /// SysAccountName
    /// </summary>
    [JsonProperty("sys_account_name")]
    public string SysAccountName { get; set; }

    /// <summary>
    /// PostGL
    /// </summary>
    [JsonProperty("post_gl")]
    public bool PostGL { get; set; } = false;

    /// <summary>
    /// GroupOfSendingTemplate
    /// </summary>
    [JsonProperty("group_of_sending_template")]
    public int GroupOfSendingTemplate { get; set; }

    /// <summary>
    /// TransId
    /// </summary>
    [JsonProperty("trans_id")]
    public string TransId { get; set; }

    /// <summary>
    /// TransTableName
    /// </summary>
    [JsonProperty("trans_table_name")]
    public string TransTableName { get; set; }
}
