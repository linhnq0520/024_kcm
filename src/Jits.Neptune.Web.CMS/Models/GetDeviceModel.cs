#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.GrpcServices;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GetDeviceModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public GetDeviceModel() { }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app_name")]
        public string app_name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("email")]
        public string email = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user_id")]
        public string user_id = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("role_user")]
        public string role_user = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_webui")]
        public string token_webui = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string status = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("info")]
        public string info = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logined")]
        public string logined = string.Empty;
    }



}


