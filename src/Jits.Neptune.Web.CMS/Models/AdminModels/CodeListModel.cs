using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;
using System;
using System.Security.Claims;

namespace Jits.Neptune.Web.Admin.Models
{
    /// <summary>
    /// MultiCaption
    /// </summary>
    public class MultiCaption : BaseNeptuneModel
    {
        /// <summary>
        /// English
        /// </summary>
        [JsonProperty("en")]
        public string en { get; set; } = null;

        /// <summary>
        /// Vietnamese
        /// </summary>
        [JsonProperty("vi")]
        public string vi { get; set; } = null;

        /// <summary>
        /// Laothian
        /// </summary>
        [JsonProperty("lo")]
        public string lo { get; set; } = null;

        /// <summary>
        /// Khmer
        /// </summary>
        [JsonProperty("km")]
        public string km { get; set; } = null;

        /// <summary>
        /// Myanmar
        /// </summary>
        [JsonProperty("mn")]
        public string mn { get; set; } = null;

    }

    /// <summary>
    /// 
    /// </summary>
    public class MCaption : BaseNeptuneModel
    {
        /// <summary>
        /// English
        /// </summary>
        [JsonProperty("en")]
        public string English { get; set; } = null;

        /// <summary>
        /// Vietnamese
        /// </summary>
        [JsonProperty("vi")]
        public string Vietnamese { get; set; } = null;

        /// <summary>
        /// Laothian
        /// </summary>
        [JsonProperty("lo")]
        public string Laothian { get; set; } = null;

        /// <summary>
        /// Khmer
        /// </summary>
        [JsonProperty("km")]
        public string Khmer { get; set; } = null;

        /// <summary>
        /// Myanmar
        /// </summary>
        [JsonProperty("mn")]
        public string Myanmar { get; set; } = null;

    }
    /// <summary>
    /// codelist create model
    /// </summary>
    public partial class CodeListCreateModel : BaseTransactionModel
    {

        /// <summary>
        /// codelist create model constructor
        /// </summary>
        public CodeListCreateModel()
        {
        }
        /// <summary>
        /// Code Id
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// Code Name
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// mcaption
        /// </summary>
        public MultiCaption Mcaption { get; set; }

        /// <summary>
        /// Code Group
        /// </summary>
        public string CodeGroup { get; set; }

        /// <summary>
        /// Code Index
        /// </summary>
        public int CodeIndex { get; set; }

        /// <summary>
        /// Code Value
        /// </summary>
        public string CodeValue { get; set; }

        /// <summary>
        /// Ftag
        /// </summary>
        public string Ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public int? Visible { get; set; }
    }

    /// <summary>
    /// codelist delete model
    /// </summary>
    public partial class CodeListDeleteModel : BaseTransactionModel
    {

        /// <summary>
        /// codelist delete model constructor
        /// </summary>
        public CodeListDeleteModel()
        {
        }

        /// <summary>
        /// code list id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// code list search model
    /// </summary>
    public partial class CodeListSearchModel : SearchBaseModel
    {
        /// <summary>
        /// Code ID
        /// </summary>
        [JsonProperty("code_id")]
        public string cdid { get; set; }

        /// <summary>
        /// Code Name
        /// </summary>
        [JsonProperty("code_name")]
        public string cdname { get; set; }

        /// <summary>
        /// Caption
        /// </summary>
        [JsonProperty("caption")]
        public string caption { get; set; }

        /// <summary>
        /// Code Group
        /// </summary>
        [JsonProperty("code_group")]
        public string cdgrp { get; set; }

        /// <summary>
        /// Code Index
        /// </summary>
        [JsonProperty("code_index")]
        public int? cdidx { get; set; }

        /// <summary>
        /// Code Index From
        /// </summary>
        [JsonProperty("code_index_from")]
        public int? CodeIndexFrom { get; set; }

        /// <summary>
        /// Code Index To
        /// </summary>
        [JsonProperty("code_index_to")]
        public int? CodeIndexTo { get; set; }

        /// <summary>
        /// Ftag
        /// </summary>
        [JsonProperty("ftag")]
        public string ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        [JsonProperty("visible")]
        public int? visible { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CodeListModel : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CodeListModel() { }
        /// <summary>
        /// </summary>
        [JsonProperty("code_group")] 
        public string Cdgrp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code_name")]
        public string Cdname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("code_id")] 
        public string Cdid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caption")] 
        public string Caption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code_value")] 
        public string Cdval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code_index")] 
        public int? Cdidx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ftag")] 
        public string Ftag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("visible")] 
        public int? Visible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mcaption")] 
        public string Mcaption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app")] 
        public string App { get; set; }

        /// <summary>
        /// Code Index From
        /// </summary>
        [JsonProperty("code_index_from")]
        public int? CodeIndexFrom { get; set; }

        /// <summary>
        /// Code Index To
        /// </summary>
        [JsonProperty("code_index_to")]
        public int? CodeIndexTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;


        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; } = 0;
    }
    /// <summary>
    /// 
    /// </summary>
    public partial class CodeListUpdateByPrimaryKey : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CodeListUpdateByPrimaryKey() { }
        /// <summary>
        /// </summary>
        [JsonProperty("code_group")]
        public string Cdgrp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code_name")]
        public string Cdname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("code_id")]
        public string Cdid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code_value")]
        public string Cdval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code_index")]
        public int? Cdidx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ftag")]
        public string Ftag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("visible")]
        public int? Visible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mcaption")]
        public string Mcaption { get; set; }
    }
    /// <summary>
    /// CodeListSearchResponeModel
    /// </summary>
    public partial class CodeListSearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Code List ID
        /// </summary>
        [JsonProperty("rownum_cdid_cdname_cdgrp")]
        public string rownum_cdid_cdname_cdgrp { get; set; }

        /// <summary>
        /// Code ID
        /// </summary>
        [JsonProperty("code_id")]
        public string cdid { get; set; }

        /// <summary>
        /// Code Name
        /// </summary>
        [JsonProperty("code_name")]
        public string cdname { get; set; }

        /// <summary>
        /// Caption
        /// </summary>
        [JsonProperty("caption")]
        public string caption { get; set; }

        /// <summary>
        /// Code Group
        /// </summary>
        [JsonProperty("code_group")]
        public string cdgrp { get; set; }

        /// <summary>
        /// Code Index
        /// </summary>
        [JsonProperty("code_index")]
        public int? cdidx { get; set; }

        /// <summary>
        /// Ftag
        /// </summary>
        [JsonProperty("ftag")]
        public string ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        [JsonProperty("visible")]
        public int? visible { get; set; }
    }

    /// <summary>
    /// CodeListViewResponseModel
    /// </summary>
    public partial class CodeListViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Code List ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Code ID
        /// </summary>
        [JsonProperty("code_id")]
        public string cdid { get; set; }

        /// <summary>
        /// Code Name
        /// </summary>
        [JsonProperty("code_name")]
        public string cdname { get; set; }

        /// <summary>
        /// Caption
        /// </summary>
        [JsonProperty("caption")]
        public string caption { get; set; }

        /// <summary>
        /// Multi Caption
        /// </summary>
        [JsonProperty("mcaption")]
        public MultiCaption MultiCaption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mcaption { get; set; }

        /// <summary>
        /// Code Group
        /// </summary>
        [JsonProperty("code_group")]
        public string cdgrp { get; set; }

        /// <summary>
        /// Code Index
        /// </summary>
        [JsonProperty("code_index")]
        public int? cdidx { get; set; }

        /// <summary>
        /// Code Value
        /// </summary>
        [JsonProperty("code_value")]
        public string cdval { get; set; }

        /// <summary>
        /// Ftag
        /// </summary>
        [JsonProperty("ftag")]
        public string ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        [JsonProperty("visible")]
        public int? visible { get; set; }
    }


    /// <summary>
    /// codelist update model
    /// </summary>
    public partial class CodeListUpdateModel : BaseTransactionModel
    {

        /// <summary>
        /// codelist update model constructor
        /// </summary>
        public CodeListUpdateModel()
        {
        }

        /// <summary>
        /// codelist default id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Code Id
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// mcaption
        /// </summary>
        public MultiCaption Mcaption { get; set; }

        /// <summary>
        /// Code Index
        /// </summary>
        public int CodeIndex { get; set; }

        /// <summary>
        /// Code Value
        /// </summary>
        public string CodeValue { get; set; }

        /// <summary>
        /// Ftag
        /// </summary>
        public string Ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public int? Visible { get; set; }
    }

    /// <summary>
    /// CodeListPrimaryKey
    /// </summary>
    public partial class CodeListPrimaryKey : BaseNeptuneModel
    {
        /// <summary>
        /// </summary>
        [JsonProperty("cdgrp")] public string cdgrp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdname")] public string cdname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("cdid")] public string cdid { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public partial class ModelWithRownum : BaseNeptuneModel
    {
        /// <summary>
        /// Code List ID
        /// </summary>
        [JsonProperty("rownum_cdid_cdname_cdgrp")]
        public string rownum_cdid_cdname_cdgrp { get; set; }
    }

    /// <summary>
    /// CodeListPrimaryKey
    /// </summary>
    public partial class CodeListPrimaryKeyResponse
    {
        /// <summary>
        /// codeId
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// codeName
        /// </summary>

        public string CodeName { get; set; }

        /// <summary>
        /// CodeGroup
        /// </summary>
        public string CodeGroup { get; set; }
    }

    /// <summary>
    /// SyncCodeListRequest
    /// </summary>
    public class SyncCodeListRequest : BaseTransactionModel
    {
        /// <summary>
        /// PageIndex
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// PageSize
        /// </summary>
        public int? PageSize { get; set; }
    }

    /// <summary>
    /// SynCodeListResponse
    /// </summary>
    public class SyncCodeListItemResponse : BaseNeptuneModel
    {
        /// <summary>
        /// CodeId
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// CodeName
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// Caption
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Mcaption
        /// </summary>
        public MultiCaption Mcaption { get; set; }

        /// <summary>
        /// CodeGroup
        /// </summary>
        public string CodeGroup { get; set; }

        /// <summary>
        /// CodeIndex
        /// </summary>
        public int CodeIndex { get; set; }

        /// <summary>
        /// CodeValue
        /// </summary>
        public string CodeValue { get; set; }

        /// <summary>
        /// Ftag
        /// </summary>
        public string Ftag { get; set; }

        /// <summary>
        /// Visible
        /// </summary>
        public int Visible { get; set; }
    }

    /// <summary>
    /// CodeListExportDataModel
    /// </summary>
    public partial class CodeListExportDataModel : BaseNeptuneModel
    {
        /// <summary>
        /// Code Id
        /// </summary>
        /// <value></value>
        public string CodeId { get; set; }

        /// <summary>
        /// Code Name
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// Code Group
        /// </summary>
        public string CodeGroup { get; set; }

    }

    /// <summary>
    /// GetCodeListByCodeIdRequestModel
    /// </summary>
    public partial class GetCodeListByCodeIdRequestModel : BaseTransactionModel
    {
        /// <summary>
        /// Code Id
        /// </summary>
        /// <value></value>
        public string CodeId { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CdlistUpdateModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CdlistUpdateModel() { }
        /// <summary>
        /// </summary>
        [JsonProperty("cdgrp")] public string Cdgrp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdname")] public string Cdname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("cdid")] public string Cdid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caption")] public string Caption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdval")] public string Cdval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdidx")] public int Cdidx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ftag")] public string Ftag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("visible")] public int Visible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MultiCaption Mcaption { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CdlistCreateModel : BaseNeptuneModel
    {
        /// <summary>
        /// </summary>
        [JsonProperty("cdgrp")] public string Cdgrp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdname")] public string Cdname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [JsonProperty("cdid")] public string Cdid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caption")] public string Caption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdval")] public string Cdval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cdidx")] public int Cdidx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ftag")] public string Ftag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("visible")] public int Visible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MultiCaption Mcaption { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class JsonGetDataCdlist: BaseJsonGetData
    {

        /// <summary>
        /// 
        /// </summary>
        public JsonGetDataCdlist(string cdgrp = null, string cdname = null, string cdid = null,Boolean m = true)
        {
            CDGRP = cdgrp;
            CDNAME = cdname;
            CDID = cdid;
            M = m;
        }
        /// <summary>
        /// 
        /// </summary>
        public string CDGRP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CDNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CDID { get; set; }

    }
}