#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FoModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FoModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("input")]
        public Dictionary<string, object> Input { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("actions")]
        public List<Dictionary<string, object>> Actions { get; set; } = new List<Dictionary<string, object>>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("request")]
        public Dictionary<string, object> Request { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("status")]
        public string Status { get; set; } = "A";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("txtype")]
        public string Txtype { get; set; } = "fo";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("txcode")]
        public string Txcode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("version")]
        public int Version { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; } = new DateTime().Ticks;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("txname")]
        public string Txname { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("hasRole")]
        public string HasRole { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("isOld")]
        public bool IsOld { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("order")]
        public int DisplayOrder { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("app")]
        public string App { get; set; } = string.Empty;
    }
    /// <summary>
    /// 
    /// </summary>
    public class FoCreateModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FoCreateModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonProperty("input")]
        public Dictionary<string, object> Input { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonProperty("actions")]
        public List<Dictionary<string, object>> Actions { get; set; } = new List<Dictionary<string, object>>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonProperty("request")]
        public Dictionary<string, object> Request { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("status")]
        public string Status { get; set; } = "A";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("txtype")]
        public string Txtype { get; set; } = "fo";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("txcode")]
        public string Txcode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("version")]
        public int Version { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; } = new DateTime().Ticks;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("txname")]
        public string Txname { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("hasRole")]
        public string HasRole { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("isOld")]
        public bool IsOld { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("order")]
        public int Order { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("app")]
        public string App { get; set; } = string.Empty;
    }
    /// <summary>
    /// 
    /// </summary>

    public partial class FoAction : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FoAction() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("function")]
        public string Function { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("para")]
        public List<object> Para { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>

        [JsonProperty("request")]
        public Dictionary<string, BoRequestModel> Request { get; set; }

    }
}




