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
    public class JWebUIObjectContextModel
    {
        /// <summary>
        /// 
        /// </summary>
        public JWebUIObjectContextModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContextInfoRequestModel InfoRequest = new ContextInfoRequestModel();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContextBoInputModel Bo = new ContextBoInputModel();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContextAppModel InfoApp = new ContextAppModel();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContextInfoUserModel InfoUser = new ContextInfoUserModel();


    }


}


