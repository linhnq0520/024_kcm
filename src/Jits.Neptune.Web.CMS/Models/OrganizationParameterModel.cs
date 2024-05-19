#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationParameterModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public OrganizationParameterModel()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrganizationCode { get; set; }

        /// <summary>
        /// rolename
        /// </summary>
        public string ParamaterCode { get; set; }

        /// <summary>
        /// Parent command Id
        /// </summary>
        public string ParameterValue { get; set; }



    }
}


