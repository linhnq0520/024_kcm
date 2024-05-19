#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="InputValueType"></typeparam>
    public class FoResponseModel<InputValueType> : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FoResponseModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("txcode")]
        public string txcode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("input")]
        public Dictionary<string, InputValueType> input { get; set; } = new Dictionary<string, InputValueType>();


    }
}