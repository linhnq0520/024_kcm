using System;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class CashFlowResponse
    {

        /// <summary>
        /// Gets or sets the value of the open balance
        /// </summary>open_balance
        [JsonProperty("open_balance")] public int BDAY { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>currency
        [JsonProperty("currency")] public string CCRCD { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer_deposit
        /// </summary>customer_deposit
        [JsonProperty("customer_deposit")] public int CTMCDP { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer_withdrawl
        /// </summary>customer_withdrawl
        [JsonProperty("customer_withdrawl")] public int CTMWDR { get; set; }

        /// <summary>
        /// Gets or sets the value of the close_balance
        /// </summary>close_balance
        [JsonProperty("close_balance")] public int EDAY { get; set; }

        /// <summary>
        /// Gets or sets the value of the group_id
        /// </summary>group_id
        [JsonProperty("group_id")] public int GROUPID { get; set; }

        /// <summary>
        /// Gets or sets the value of the internal_in
        /// </summary>internal_in
        [JsonProperty("internal_in")] public int ITNIN { get; set; }

        /// <summary>
        /// Gets or sets the value of the internal_out
        /// </summary>internal_out
        [JsonProperty("internal_out")] public int ITNOUT { get; set; }

        /// <summary>
        /// Gets or sets the value of the type
        /// </summary>type
        [JsonProperty("type")] public string TYPE { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CashFlowSearchResponseModel : BaseNeptuneModel
    {

        /// <summary>
        /// Gets or sets the value of the open balance
        /// </summary>open_balance
        [JsonProperty("open_balance")] public int bday { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>currency
        [JsonProperty("currency")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer_deposit
        /// </summary>customer_deposit
        [JsonProperty("customer_deposit")] public int ctmcdp { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer_withdrawl
        /// </summary>customer_withdrawl
        [JsonProperty("customer_withdrawl")] public int ctmwdr { get; set; }

        /// <summary>
        /// Gets or sets the value of the close_balance
        /// </summary>close_balance
        [JsonProperty("close_balance")] public int eday { get; set; }

        /// <summary>
        /// Gets or sets the value of the group_id
        /// </summary>group_id
        [JsonProperty("group_id")] public int groupid { get; set; }

        /// <summary>
        /// Gets or sets the value of the internal_in
        /// </summary>internal_in
        [JsonProperty("internal_in")] public int itnin { get; set; }

        /// <summary>
        /// Gets or sets the value of the
        /// </summary>
        [JsonProperty("itnin_ctmcdp")] public int itnin_ctmcdp { get; set; }

        /// <summary>
        /// Gets or sets the value of the
        /// </summary>
        [JsonProperty("itnout_ctmwdr")] public int itnout_ctmwdr { get; set; }

        /// <summary>
        /// Gets or sets the value of the internal_out
        /// </summary>internal_out
        [JsonProperty("internal_out")] public int itnout { get; set; }

        /// <summary>
        /// Gets or sets the value of the type
        /// </summary>type
        [JsonProperty("type")] public string type { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CashExchangeSearchResponseModel : BaseNeptuneModel
    {

        /// <summary>
        /// Gets or sets the value of the open balance
        /// </summary>open_balance
        [JsonProperty("open_balance")] public int bday { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>currency
        [JsonProperty("currency")] public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer_deposit
        /// </summary>customer_deposit
        [JsonProperty("customer_deposit")] public int ctmcdp { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer_withdrawl
        /// </summary>customer_withdrawl
        [JsonProperty("customer_withdrawl")] public int ctmwdr { get; set; }

        /// <summary>
        /// Gets or sets the value of the close_balance
        /// </summary>close_balance
        [JsonProperty("close_balance")] public int eday { get; set; }

        /// <summary>
        /// Gets or sets the value of the group_id
        /// </summary>group_id
        [JsonProperty("group_id")] public int groupid { get; set; }

        /// <summary>
        /// Gets or sets the value of the internal_in
        /// </summary>internal_in
        [JsonProperty("internal_in")] public int itnin { get; set; }

        /// <summary>
        /// Gets or sets the value of the
        /// </summary>
        [JsonProperty("itnin_ctmcdp")] public int itnin_ctmcdp { get; set; }

        /// <summary>
        /// Gets or sets the value of the
        /// </summary>
        [JsonProperty("itnout_ctmwdr")] public int itnout_ctmwdr { get; set; }

        /// <summary>
        /// Gets or sets the value of the internal_out
        /// </summary>internal_out
        [JsonProperty("internal_out")] public int itnout { get; set; }

        /// <summary>
        /// Gets or sets the value of the type
        /// </summary>type
        [JsonProperty("type")] public string type { get; set; }
    }
}