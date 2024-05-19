#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LoadDataModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LoadDataModel() { }
        /// <summary>
        /// </summary>
        [JsonProperty("table_code")] public string table_code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("request_data")] public RequestDataModel request_data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("data_select")] public Dictionary<string, object> data_select { get; set; } = new Dictionary<string, object>();

    }
    /// <summary>
    /// 
    /// </summary>
    public class RequestDataModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public RequestDataModel()
        {
            // data_form = request_data.ContainsKey("data_form") ? request_data.GetValueOrDefault("data_form").ToString() : "";
            // learnapi_form = request_data.ContainsKey("learnapi_form") ? request_data.GetValueOrDefault("learnapi_form").ToString() : "";
            // learnsql_form = request_data.ContainsKey("learnsql_form") ? request_data.GetValueOrDefault("learnsql_form").ToString() : "";
            // lazy_load = request_data.ContainsKey("lazy_load") ? JsonConvert.DeserializeObject<Dictionary<string, object>>(request_data.GetValueOrDefault("lazy_load").ToString()) : null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("data_form")] public string data_form { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("learnapi_form")] public string learnapi_form { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("learnsql_form")] public string learnsql_form { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("lazy_load")] public LazyLoadModel lazy_load { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
    public class LazyLoadModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LazyLoadModel()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ItemLazyLoadCdlistModel> c_cdlist { get; set; } = new List<ItemLazyLoadCdlistModel>();
    }
}


