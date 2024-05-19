using System.Collections.Generic;

namespace Jits.Neptune.Web.CMS.Models.AdminModels;

/// <summary>
/// 
/// </summary>
public class PagingData
{
    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, int> Paging { get; set; } = new Dictionary<string, int>();
}
