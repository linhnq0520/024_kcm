using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseO9Model
    {
    }
    /// <summary>
    /// 
    /// </summary>
    public class BaseO9TransactionModel:BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_code")]
        public string txcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txdt")]
        public DateTime txdt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_number")]
        public string txrefid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value_date")]
        public DateTime valuedt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("current_branch_code")]
        public string branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("usrid")]
        public string usrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("language")]
        public string lang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("usrws")]
        public string usrws { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_approve")]
        public string apuser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apusrip")]
        public string apusrip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apusrws")]
        public string apusrws { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apdt")]
        public DateTime apdt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isreverse")]
        public bool isreverse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hbranchid")]
        public string hbranchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rbranchid")]
        public string rbranchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apreason")]
        public string apreason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("prn")]
        public string prn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txbody")]
        public List<JsonData> txbody { get; set; } = new List<JsonData>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseO9TransactionModel1:BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txcode")]
        public string txcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txdt")]
        public DateTime txdt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txrefid")]
        public string txrefid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("valuedt")]
        public DateTime valuedt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("branchid")]
        public string branchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("usrid")]
        public string usrid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lang")]
        public string lang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("usrws")]
        public string usrws { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apuser")]
        public string apuser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apusrip")]
        public string apusrip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apusrws")]
        public string apusrws { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apdt")]
        public DateTime apdt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isreverse")]
        public bool isreverse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hbranchid")]
        public string hbranchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rbranchid")]
        public string rbranchid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("apreason")]
        public string apreason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("prn")]
        public string prn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txbody")]
        public List<JsonData> txbody { get; set; } = new List<JsonData>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
