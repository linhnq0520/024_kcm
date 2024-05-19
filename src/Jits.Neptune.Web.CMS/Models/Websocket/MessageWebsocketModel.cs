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
    public class MessageWebsocketModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageWebsocketModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string message { get; set; }
    }

    

}


