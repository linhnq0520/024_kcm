using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Jits.Neptune.Web.CMS.Models.AdminModels;
/// <summary>
/// 
/// </summary>
public partial class ForeignExchangeRateViewResponseModel : BaseNeptuneModel
{
    /// <summary>
    /// 
    /// </summary>
    public ForeignExchangeRateViewResponseModel()
    {
        this.FXRateData = new List<FXRate>() { };
    }
    /// <summary>
    /// BranchCode
    /// </summary>
    [JsonProperty("branch_code")]
    public string BranchCode { get; set; }
    /// <summary>
    /// WorkingDate
    /// </summary>
    [JsonProperty("last_update_date")]
    public DateTime WorkingDate { get; set; }
    /// <summary>
    /// FXRate
    /// </summary>
    [JsonProperty("fx_rate_data")]
    public List<FXRate> FXRateData { get; set; }

}

/// <summary>
/// 
/// </summary>
public class FXRate : BaseNeptuneModel
{
    /// <summary>
    /// Contructoer
    /// </summary>
    public FXRate() { }
    /// <summary>
    /// CurencyCode
    /// </summary>
    [JsonProperty("currency_code")]
    public string ccrcd { get; set; }
    /// <summary>
    /// ShortCurrencyId
    /// </summary>
    [JsonProperty("short_id")]
    public string shrtid { get; set; }
    /// <summary>
    /// BKRate
    /// </summary>
    [JsonProperty("book_rate")]
    public decimal bk_rate { get; set; }
    /// <summary>
    /// CBRate
    /// </summary>
    [JsonProperty("cash_bid_big_rate")]
    public decimal cb_rate { get; set; }
    /// <summary>
    /// CSRate
    /// </summary>
    [JsonProperty("cash_bid_small_rate")]
    public decimal cs_rate { get; set; }
    /// <summary>
    /// CARate
    /// </summary>
    [JsonProperty("cash_ask_rate")]
    public decimal ca_rate { get; set; }

    /// <summary>
    /// TBRate
    /// </summary>
    [JsonProperty("transfer_bid_rate")]
    public decimal tb_rate { get; set; }
    /// <summary>
    /// TARate
    /// </summary>
    [JsonProperty("transfer_ask_rate")]
    public decimal ta_rate { get; set; }

    /// <summary>
    /// CMRate
    /// </summary>
    [JsonProperty("medium_bill_rate")]
    public decimal cm_rate { get; set; }
}
