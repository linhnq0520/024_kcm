#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextInfoUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        string token = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public ContextInfoUserModel()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RequestHeaderModel UserLogin = new RequestHeaderModel();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RequestHeaderModel GetUserLogin()
        {
            return UserLogin;
        }

    }
}
