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
    public class GroupMenuModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public GroupMenuModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
        /// <returns></returns>
        [JsonProperty("group_menu_lang")] public Dictionary<string, string> GroupMenuLang { get; set; } = new Dictionary<string, string>();
        // public Dictionary<string, string> GroupMenuLangDictionary
        // {
        //     get => JsonConvert.DeserializeObject<Dictionary<string, string>>(GroupMenuLang);
        //     set => GroupMenuLang = JsonConvert.SerializeObject(value);
        // }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_name")] public string GroupMenuName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_order")] public int GroupMenuOrder { get; set; } = 1;


        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("group_menu_icon")]
        public string GroupMenuIcon { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("group_menu_parent")]
        public string GroupMenuParent { get; set; } = string.Empty;
        ///
        [JsonProperty("group_menu_status")] public string GroupMenuStatus { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_function_code")] public string GroupMenuFunctionCode { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_visible")] public string GroupMenuVisible { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_id")] public string GroupMenuId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_module_form")] public string GroupMenuModuleForm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("group_menu_list_authorize_form")] public string GroupMenuListAuthorizeForm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app")] public string App { get; set; } = string.Empty;

    }
}


