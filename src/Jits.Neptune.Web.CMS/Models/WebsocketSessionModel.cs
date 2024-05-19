#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WebsocketSessionModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public WebsocketSessionModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ApplicationCode { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public System.Net.WebSockets.WebSocket webSocket { get; set; }
    }
}


