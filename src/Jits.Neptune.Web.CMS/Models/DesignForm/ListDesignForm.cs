#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;

using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ListAppInDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListAppInDesignForm() { }
        /// <summary>
        /// </summary>
        public string App { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ListFormInDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListFormInDesignForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("designForm")]
        [JsonProperty("designForm")]
        public InfoFormInDesignForm DESIGNFORM_CODE_DATABASE { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class InfoFormInDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public InfoFormInDesignForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("info")]
        public InfoForm Info { get; set; } = new InfoForm();

    }

    /// <summary>
    /// 
    /// </summary>
    public class ListDesignGroupInDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListDesignGroupInDesignForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("designToolGroup")]
        [JsonProperty("designToolGroup")]

        public DesignGroupModel DESIGNFORM_CODE_TOOL_GROUPS { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
    public class ListDesignItemInDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListDesignItemInDesignForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("designToolItem")]
        [JsonProperty("designToolItem")]

        public DesignItemModel DESIGNFORM_CODE_TOOL_ITEMS { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ListDesignTemplateFormInDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListDesignTemplateFormInDesignForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("designFormTemplate")]
        [JsonProperty("designFormTemplate")]

        public DesignTemplateFormModel DESIGNFORM_CODE_FORM_TEMPLATE { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ListLoadDataForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListLoadDataForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("data_form")]
        [JsonProperty("data_form")]
        public DataFormModel DataForm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("error_code")]
        [JsonProperty("error_code")]
        public string error_code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("status")]
        [JsonProperty("status")]
        public bool Status { get; set; } = false;

    }
    /// <summary>
    /// 
    /// </summary>
    public class DataFormModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public DataFormModel() { }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("designForm")]
        [JsonProperty("designForm")]
        public FormModel formModel { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ListCdlistDesignForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListCdlistDesignForm() { }
        /// <summary>
        /// </summary>
        [JsonPropertyName("data_cdlist")]
        [JsonProperty("data_cdlist")]
        public List<CdlistDesignFormResponse> cdlistsResponse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("status")]
        [JsonProperty("status")]
        public bool Status { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("error_code")]
        [JsonProperty("error_code")]
        public string error_code { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>
    public class CdlistDesignFormResponse : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CdlistDesignFormResponse() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("c_cdlist")]
        public CdlistResponseModel cdlists { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class SaveDuplicateFormModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public SaveDuplicateFormModel() { }
        /// <summary>
        /// </summary>
        [JsonProperty("new_key_form")]
        public string new_key_form { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("old_key_form")]
        public string old_key_form { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("app_code")]
        public string app_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("old_app")]
        public string old_app { get; set; }

    }
}

