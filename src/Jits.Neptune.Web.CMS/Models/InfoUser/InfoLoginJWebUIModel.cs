#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class InfoLoginJWebUIModel
    {
        /// <summary>
        /// 
        /// </summary>
        public InfoLoginJWebUIModel() { }
        /// <summary>
        /// User code
        /// </summary>
        public string AppName { get; set; } = "";

        /// <summary>
        /// Username
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// User code
        /// </summary>
        public string RoleUser { get; set; } = "";

        /// <summary>
        /// Username
        /// </summary>
        public string UserID { get; set; } = "";
        /// <summary>
        /// User code
        /// </summary>
        public string TokenWebui { get; set; } = "";

        /// <summary>
        /// Status active/lock
        /// </summary>
        public string Status { get; set; } = "active";
        /// <summary>
        /// Status active/lock
        /// </summary>
        public long Logined { get; set; } = 0;
        /// <summary>
        /// Status active/lock
        /// </summary>
        public bool IsDebug { get; set; } = false;
        
        // private int OncePacked = 1;
        /// <summary>
        /// 
        /// </summary>
        // private int OncePackedMax = 20;
        private List<string> OncePackedID = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public InfoLoginJwebUIInfoModel Info = new InfoLoginJwebUIInfoModel();


    }

    /// <summary>
    /// 
    /// </summary>
    public class InfoLoginJwebUIInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        public InfoLoginJwebUIInfoModel() { }
        /// <summary>
        /// 
        /// </summary>
        public string d = "";
        /// <summary>
        /// 
        /// </summary>
        public string u = "";
        /// <summary>
        /// 
        /// </summary>
        public string lang = "";
        /// <summary>
        /// 
        /// </summary>
        public string app = "";
        /// <summary>
        /// 
        /// </summary>
        public string uid = "";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JObject my_device = new JObject();
        /// <summary>
        /// 
        /// </summary>
        /// //
        // 16 07 2019 code protectPost
        public string protect_request = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool setJson(JObject info)
        {
            if (info.ContainsKey("d") && info.ContainsKey("u") && info.ContainsKey("lang") && info.ContainsKey("app") && info.ContainsKey("uid")
                && info.ContainsKey("my_device"))
            {
                d = info.GetValue("d").ToString();
                u = info.GetValue("u").ToString();
                lang = info.GetValue("lang").ToString();
                app = info.GetValue("app").ToString();
                uid = info.GetValue("uid").ToString();

                if (info.ContainsKey("protect_request"))
                    protect_request = info.GetValue("protect_request").ToString();

                my_device = info.GetValue("my_device").ToObject<JObject>();
            }
            return false;
        }

    }
}


