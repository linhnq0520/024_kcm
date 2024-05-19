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
    public partial class UserLimitSearchResponseModel : BaseNeptuneModel
    {

        /// <summary>
        /// user limit id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RoleId
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// CommandId
        /// </summary>
        public string CommandId { get; set; }

        /// <summary>
        /// CurrencyCode
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// ULimit
        /// </summary>
        public decimal? ULimit { get; set; }

        /// <summary>
        /// CvTable
        /// </summary>
        public string CvTable { get; set; }

        /// <summary>
        /// LimitType
        /// </summary>
        public string LimitType { get; set; }

        /// <summary>
        /// Margin
        /// </summary>
        public int? Margin { get; set; }

        /// <summary>
        /// Module
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// TranName
        /// </summary>
        public string TranName { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public partial class UserLimitAdvancedSearchResponseModel : BaseNeptuneModel
    {

        /// <summary>
        /// user limit id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RoleId
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// CommandId
        /// </summary>
        public string CommandId { get; set; }

        /// <summary>
        /// CurrencyCode
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// ULimit
        /// </summary>
        public decimal? ULimit { get; set; }

        /// <summary>
        /// CvTable
        /// </summary>
        public string CvTable { get; set; }

        /// <summary>
        /// LimitType
        /// </summary>
        public string LimitType { get; set; }

        /// <summary>
        /// Margin
        /// </summary>
        public int? Margin { get; set; }

        /// <summary>
        /// Module
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// TranName
        /// </summary>
        public string TranName { get; set; }
    }



}


