using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// FileModel
    /// </summary>
    public partial class FileModel : BaseNeptuneModel
    {

        /// <summary>
        /// FileModel
        /// </summary>
        public FileModel()
        {
        }

        /// <summary>
        /// /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// FileContent
        /// </summary>
        public string FileContent { get; set; }
    }

    /// <summary>
    /// BoExportDataModel
    /// </summary>
    public partial class BoExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// Txcode
        /// </summary>
        public string Txcode { get; set; }

        /// <summary>
        /// App
        /// </summary>
        /// <value></value>
        public string App { get; set; }
    }

    /// <summary>
    /// FoExportDataModel
    /// </summary>
    public partial class FoExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// Txcode
        /// </summary>
        public string Txcode { get; set; }

        /// <summary>
        /// App
        /// </summary>
        /// <value></value>
        public string App { get; set; }
    }

    /// <summary>
    /// AppExportDataModel
    /// </summary>
    public partial class AppExportDataModel : BaseNeptuneModel
    {
        /// <summary>
        /// ListApplicationId
        /// </summary>
        public string ListApplicationId { get; set; }

    }

    /// <summary>
    /// AppExportDataModel
    /// </summary>
    public partial class AppOfRoleExportDataModel : BaseNeptuneModel
    {
        /// <summary>
        /// RoleId
        /// </summary>
        public int RoleId { get; set; }
    }

    /// <summary>
    /// DesignGroupExportDataModel
    /// </summary>
    public partial class DesignGroupExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// GroupId
        /// </summary>
        /// <value></value>
        public string GroupId { get; set; }
    }

    /// <summary>
    /// DesignItemExportDataModel
    /// </summary>
    public partial class DesignItemExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AttId { get; set; }
    }

    /// <summary>
    /// FormExportDataModel
    /// </summary>
    public partial class FormExportDataModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string FormId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string App { get; set; }

    }

    /// <summary>
    /// LangExportDataModel
    /// </summary>
    public partial class LangExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; }
    }

    /// <summary>
    /// LearApiExportDataModel
    /// </summary>
    public partial class LearnApiExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// LearnApiId
        /// </summary>
        public string LearnApiId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; }
    }

    /// <summary>
    /// ParaServerExportDataModel
    /// </summary>
    public partial class ParaServerExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string App { get; set; }
    }

    /// <summary>
    /// TemplateVoucherExportDataModel
    /// </summary>
    public partial class TemplateVoucherExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; }
    }

    /// <summary>
    /// TemplateVoucherExportDataModel
    /// </summary>
    public partial class CdlistExportDataModel : BaseNeptuneModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Cdgrp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Cdname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Cdid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; }
    }

}


