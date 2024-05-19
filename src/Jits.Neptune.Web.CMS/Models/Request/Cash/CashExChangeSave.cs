using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Models.Request.Cash
{
    /// <summary>
    /// 
    /// </summary>
    public class CashExChangeSave : BaseNeptuneModel
    {
        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("atm")] public int atm { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("branch_id")] public int branchid { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("cashsheet")] public int cashsheet { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("ccrid")] public string ccrid { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("facetype")] public string facetype { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("faceval")] public int faceval { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("sheet")] public int sheet { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        [JsonProperty("usrid")] public int usrid { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; } = 0;
        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;
    }

}