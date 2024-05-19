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
    public class CdlistModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CdlistModel() { }
        /// <summary>
        /// </summary>
        /// 
        [JsonPropertyName("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cdgrp")] public string Cdgrp { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cdname")] public string Cdname { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cdid")] public string Cdid { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("caption")] public string Caption { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cdval")] public string Cdval { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cdidx")] public int Cdidx { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ftag")] public string Ftag { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("visible")] public int? Visible { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("mcaption")] public MultiCaption Mcaption { get; set; } = new MultiCaption();
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("app")] public string App { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>
    public class CdlistResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CdlistResponseModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("id")] public int Id { get; set; } = 0;

        /// <summary>
        /// </summary>
        [JsonPropertyName("cdgrp")] public string Cdgrp { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("cdname")] public string Cdname { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("cdid")] public string Cdid { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("caption")] public string Caption { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("cdval")] public string Cdval { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("cdidx")] public int Cdidx { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("ftag")] public string Ftag { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("visible")] public int Visible { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("mcaption")] public MultiCaption Mcaption { get; set; } = new MultiCaption();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonPropertyName("app")] public string App { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>
    public class MultiCaptionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public MultiCaptionEntity()
        {

        }
        /// <summary>
        /// English
        /// </summary>
        public string English { get; set; } = string.Empty;

        /// <summary>
        /// Vietnamese
        /// </summary>
        public string Vietnamese { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Laothian { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Khmer { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Myanmar { get; set; } = string.Empty;
    }
    /// <summary>
    /// 
    /// </summary>
    public class MultiCaption : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public MultiCaption()
        {

        }
        /// <summary>
        /// English
        /// </summary>
        [JsonProperty("en")]
        public string English { get; set; } = string.Empty;

        /// <summary>
        /// Vietnamese
        /// </summary>
        [JsonProperty("vi")]
        public string Vietnamese { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("lo")]
        public string Laothian { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("km")]
        public string Khmer { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("mn")]
        public string Myanmar { get; set; } = string.Empty;

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CodeListSearchModel : BaseTransactionModel
    {

        /// <summary>
        /// codelist search model constructor
        /// </summary>

        /// <summary>
        /// cdid
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// cdname
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// cdgrp
        /// </summary>
        public string CodeGroup { get; set; }

        /// <summary>
        /// cdidxFrom
        /// </summary>
        public int? CodeIndex { get; set; }

        /// <summary>
        /// cdidxFrom
        /// </summary>
        public int? CodeIndexFrom { get; set; }

        /// <summary>
        /// cdidxTo
        /// </summary>
        public int? CodeIndexTo { get; set; }

        /// <summary>
        /// ftag
        /// </summary>
        public string Ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public int? Visible { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;

    }
}


