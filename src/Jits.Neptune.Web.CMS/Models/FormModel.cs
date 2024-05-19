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
    public class FormModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("info")]
        public InfoForm Info { get; set; } = new InfoForm();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("list_layout")]
        public List<Dictionary<string, object>> ListLayout { get; set; } = new List<Dictionary<string, object>>();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("react_txt")]
        public string ReactTxt { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("form_id")] public string FormId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("app")] public string App { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>
    public class FormFOModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FormFOModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("info")]
        public InfoForm Info { get; set; } = new InfoForm();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("has_fee")]
        public bool HasFee { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("react_txt")]
      
        public string ReactTxt { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("fee_status")]
        public string FeeStatus { get; set; } = "Form hasn't Fee";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("form_id")] public string FormId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("form_title")] public string FormTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app")] public string App { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>

    public class InfoForm : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public InfoForm() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public InfoForm(string info)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("des")] public string Des { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")] public string Data { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learnapi")] public string Learnapi { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("learnsql")] public string Learnsql { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_update")] public string LastUpdate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bodata")] public string Bodata { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("openOne")] public string Openone { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("url_input")] public string Url_Input { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lang_form")] public Dictionary<string, object> Lang_Form { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mode_form")] public ModeForm Mode_Form { get; set; } = new ModeForm();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("form_code")] public string Form_Code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ruleStrong")] public object Rulestrong { get; set; } = new object();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app")] public string App { get; set; } = string.Empty;


    }

    /// <summary>
    /// 
    /// </summary>
    public class ModeForm
    {
        /// <summary>
        /// 
        /// </summary>
        public ModeForm() { }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mode")] public string Mode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("col_text")] public string ColText { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("col_input")] public string ColInput { get; set; } = string.Empty;
    }
    /// <summary>
    /// 
    /// </summary>
    public class RuleStrong
    {
        /// <summary>
        /// 
        /// </summary>
        public RuleStrong() { }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")] public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("inUse")] public bool InUse { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isStart")] public bool IsStart { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isStatus")] public string IsStatus { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("order")] public int Order { get; set; } = 1;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("config")] public Dictionary<string, object> Config { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isDidStart")] public bool IsDidStart { get; set; } = false;
    }

}


