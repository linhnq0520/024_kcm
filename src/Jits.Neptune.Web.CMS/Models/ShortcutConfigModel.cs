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
    public class ShortcutConfigModel : BaseNeptuneModel
    {
        /// <summary>
        ///
        /// </summary>
        public ShortcutConfigModel() { }

        /// <summary>
        /// ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("shortcut_id")]
        public string ShortcutId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("keystrokes")]
        public string Keystrokes { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("app")]
        public string App { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [JsonPropertyName("form_code")]
        public string FormCode { get; set; }
    }
}
