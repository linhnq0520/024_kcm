using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Models;

/// <summary>
/// 
/// </summary>
public partial class SettingSearchModel : BaseTransactionModel
{
    /// <summary>
    /// 
    /// </summary>
    public SettingSearchModel() { }


    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string OrganizationId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int PageIndex { get; set; } = 0;
    /// <summary>
    /// 
    /// </summary>
    public int PageSize { get; set; } = int.MaxValue;
}

/// <summary>
/// 
/// </summary>
public partial class SettingSearchResponse : BaseNeptuneModel
{
    /// <summary>
    /// 
    /// </summary>
    public SettingSearchResponse() { }

    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string OrganizationId { get; set; }

}


/// <summary>
/// 
/// </summary>
public partial class SettingViewByPrimaryKey : BaseTransactionModel
{
    /// <summary>
    /// 
    /// </summary>
    public SettingViewByPrimaryKey() { }


    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int OrganizationId { get; set; } = 0;


}


/// <summary>
/// 
/// </summary>
public partial class SettingCreateModel : BaseTransactionModel
{
    /// <summary>
    /// 
    /// </summary>
    public SettingCreateModel() { }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int OrganizationId { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class SettingUpdateModel : BaseTransactionModel
{
    /// <summary>
    /// 
    /// </summary>
    public SettingUpdateModel() { }

    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int OrganizationId { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class ListAuditModel : BaseTransactionModel
{
    /// <summary>
    ///  constructor
    /// </summary>
    public ListAuditModel()
    {
        this.PageIndex = 0;
        this.PageSize = int.MaxValue;
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// UserCreatedName
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// UserApprovedCode
    /// </summary>
    public int PageSize { get; set; }
}