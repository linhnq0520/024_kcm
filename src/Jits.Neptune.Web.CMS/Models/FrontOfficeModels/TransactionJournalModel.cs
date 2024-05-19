using Jits.Neptune.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Jits.Neptune.Web.CMS.Models.FrontOfficeModels
{
    /// <summary>
    /// Represents a transaction journal
    /// </summary>
    public partial class TransactionJournalModel : BaseEntity
    {
        /// <summary>
        /// Transaction number
        /// </summary>
        [JsonProperty("transaction_number")]
        public string TXREFID { get; set; }

        /// <summary>
        /// Transaction code
        /// </summary>
        [JsonProperty("transaction_code")]
        public string TXCODE { get; set; }

        /// <summary>
        /// Transaction date
        /// </summary>
        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Reference id
        /// </summary>
        [JsonProperty("ref_id")]
        public string RefId { get; set; }

        /// <summary>
        /// User created
        /// </summary>
        [JsonProperty("user_created")]
        public int USRID { get; set; }

#nullable enable
        /// <summary>
        /// Reference id
        /// </summary>
        [JsonProperty("reference_id")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// User approve
        /// </summary>
        [JsonProperty("user_approve")]
        public int? APUSER { get; set; }

        /// <summary>
        /// User approve
        /// </summary>
        [JsonProperty("user_reject")]
        public string? UserReject { get; set; }
#nullable disable

        /// <summary>
        /// Status
        /// R: Reverse
        /// J: Reject
        /// C: Completed
        /// E: Error
        /// P: Pending to approve
        /// </summary>
        [JsonProperty("status")]
        public string STATUS { get; set; }

        /// <summary>
        /// Is reverse
        /// </summary>
        [JsonProperty("is_reverse")]
        public string ISREVERSE { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [JsonProperty("amount1")]
        public decimal AMT1 { get; set; }

        /// <summary>
        /// Transaction account
        /// </summary>
        [JsonProperty("string1")]
        public string STRING1 { get; set; }

        /// <summary>
        /// Transaction body
        /// </summary>
        [JsonProperty("transaction_body")]
        public string transactionBody { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("descs")]
        public string descs { get; set; }

        /// <summary>
        /// Has posting
        /// </summary>
        [JsonProperty("has_posting")]
        public string IBT { get; set; }

        /// <summary>
        /// Cash amount
        /// </summary>
        public decimal CashAmount { get; set; }

        /// <summary>
        /// Channel
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }
    } 
}
