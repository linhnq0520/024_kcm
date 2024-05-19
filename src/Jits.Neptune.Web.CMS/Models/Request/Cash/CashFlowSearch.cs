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
    public class CashFlowSearch : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the group_id
        /// </summary>group_id
        [JsonProperty("group_id")] public int groupid { get; set; }

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