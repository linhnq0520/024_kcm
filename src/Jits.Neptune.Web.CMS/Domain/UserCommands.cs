using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain;

/// <summary>
/// 
/// </summary>
public partial class UserCommands : BaseEntity
{

    /// <summary>
    /// Application code
    /// </summary>
    [JsonProperty("application_code")]
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Command Id
    /// </summary>
    [JsonProperty("command_id")]
    public string CommandId { get; set; }

#nullable enable
    /// <summary>
    /// Parent command Id
    /// </summary>
    [JsonProperty("parent_id")]
    public string? ParentId { get; set; }

    /// <summary>
    /// Command Name
    /// </summary>
    [JsonProperty("command_name")]
    public string? CommandName { get; set; }

    /// <summary>
    /// Command Name Multi language
    /// </summary>
    [JsonProperty("command_name_language")]
    public string? CommandNameLanguage { get; set; }
#nullable disable

    /// <summary>
    /// Command Type
    /// </summary>
    [JsonProperty("command_type")]
    public string CommandType { get; set; }

    /// <summary>
    /// Is Enabled
    /// </summary>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Order
    /// </summary>
    [JsonProperty("display_order")]
    public int DisplayOrder { get; set; }

    /// <summary>
    /// GroupMenuIcon
    /// </summary>
    [JsonProperty("group_menu_icon")]
    public string GroupMenuIcon { get; set; }

    /// <summary>
    /// GroupMenuVisible
    /// </summary>
    [JsonProperty("group_menu_visible")]
    public string GroupMenuVisible { get; set; }

    /// <summary>
    /// GroupMenuId
    /// </summary>
    [JsonProperty("group_menu_id")]
    public string GroupMenuId { get; set; }

    /// <summary>
    /// GroupMenuListAuthorizeForm
    /// </summary>
    [JsonProperty("group_menu_list_authorize_form")]
    public string GroupMenuListAuthorizeForm { get; set; }

    /// <summary>
    /// Last update date
    /// </summary>
    [JsonProperty("updated_on_utc")]
    public DateTime? UpdatedOnUtc { get; set; }

    /// <summary>
    /// Last update date
    /// </summary>
    [JsonProperty("created_on_utc")]
    public DateTime? CreatedOnUtc { get; set; }
}