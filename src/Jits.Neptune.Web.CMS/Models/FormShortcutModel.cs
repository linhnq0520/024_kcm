#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    ///
    /// </summary>
    public class FormShortcutModel : BaseNeptuneModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormShortcutModel() { }

        /// <summary>
        /// </summary>
        [JsonPropertyName("form_id")]
        public string FormId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("form_name")]
        public string FormName { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("group_code")]
        public string GroupCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("app")]
        public string App { get; set; }
    }
}
