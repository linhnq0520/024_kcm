#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileDetailModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ProfileDetailModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("chat")]
        public ChatDetail chatDetail = new ChatDetail();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("profile_app")]
        public GetUserAccountByIdResponse profileAppDetail = new GetUserAccountByIdResponse();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_map")]
        public Dictionary<string, object> userMap = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isHasPin")]
        public bool isHasPin = false;
    }
    /// <summary>
    /// 
    /// </summary>
    public class ChatDetail : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ChatDetail() { }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hidden_mobi")]
        public bool hiddenMobi = true;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("avatar")]
        public string avatar = "../rs/global/img/avatar.jpg";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bgrelogin")]
        public string bgrelogin = "../rs/global/img/lock_screen.jpg";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string name = "Hi";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("status")]
        public string status = "Welcome";
    }

}


