#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class FormStaticPostApiModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormStaticPostApiModel() { }
        /// <summary>
        /// </summary>
        public string learn_api { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string key_convert_data { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public object api_data { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string app { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int number_of_step { get; set; } = 2;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string table_code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string workflow_id { get; set; } = string.Empty;


    }
}


