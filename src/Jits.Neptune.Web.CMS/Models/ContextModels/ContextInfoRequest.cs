#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextInfoRequestModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ContextInfoRequestModel() { }

        private string Ip = "";
        private string ClientOs = "";
        private string ClientBrowser = "";
        private BoRequestModel RequestJson = new BoRequestModel();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetIp() => Ip;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetClientOs() => ClientOs;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetClientBrowser() => ClientBrowser;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BoRequestModel GetRequestJson() => RequestJson;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DeviceID { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PortalToken { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTimeOffset SessionExpired { get; set; }




    }
}


