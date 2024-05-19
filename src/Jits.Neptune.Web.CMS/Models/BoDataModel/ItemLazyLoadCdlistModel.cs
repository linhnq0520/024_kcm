#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemLazyLoadCdlistModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemLazyLoadCdlistModel() { }
        /// <summary>
        /// </summary>
        [JsonProperty("dbcoffee_create")] public bool dbcoffee_create { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dbcoffee_col1")] public string dbcoffee_col1 { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dbcoffee_col2")] public string dbcoffee_col2 { get; set; } = string.Empty;

    }


}


