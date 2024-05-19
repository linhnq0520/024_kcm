using System;
using Newtonsoft.Json;
using Jits.Neptune.Core;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// </summary>
public partial class GroupMenu : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    public GroupMenu() { }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_lang")] public string GroupMenuLang { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_name")] public string GroupMenuName { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_order")] public int GroupMenuOrder { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_icon")] public string GroupMenuIcon { get; set; }
  /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_parent")] public string GroupMenuParent { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_status")] public string GroupMenuStatus { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_function_code")] public string GroupMenuFunctionCode { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_visible")] public string GroupMenuVisible { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_id")] public string GroupMenuId { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_module_form")] public string GroupMenuModuleForm { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("group_menu_list_authorize_form")] public string GroupMenuListAuthorizeForm { get; set; }
      /// <summary>
    /// </summary>
    [JsonPropertyName("app")] public string App { get; set; }

}