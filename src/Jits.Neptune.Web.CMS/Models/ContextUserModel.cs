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
    public class ContextUserModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ContextUserModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_jwebui")]
        public UserJWebUIModel user_jwebui { get; set; } = new UserJWebUIModel();
        /// <summary>
        /// 
        /// </summary>
       
        /// <returns></returns>
        [JsonProperty("user_acc")]
        public Dictionary<string, object> user_acc { get; set; } = new Dictionary<string, object>();
    }
    /// <summary>
    /// 
    /// </summary>
    public class UserJWebUIModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public UserJWebUIModel() { }
        /// <summary>
        /// 
        /// </summary>

        [JsonProperty("email")]
        public string email { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>

        [JsonProperty("user_id")]
        public int user_id { get; set; } = 0;
    }
    /// <summary>
    /// 
    /// </summary>
    public class UserPortalModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public UserPortalModel() { }
        /// <summary>
        /// 
        /// </summary>

        [JsonProperty("user_portal")]
        public Dictionary<string, object> user_portal { get; set; } = new Dictionary<string, object>();

    }


}


