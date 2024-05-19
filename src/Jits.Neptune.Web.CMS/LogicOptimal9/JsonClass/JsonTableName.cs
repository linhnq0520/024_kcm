using System.Collections.Generic;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
/// <summary>
/// 
/// </summary>
public class JsonTableName
{
    /// <summary>
    /// 
    /// </summary>
    public List<JsonData> TXBODY { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public JsonTableName() { 
        TXBODY = new List<JsonData>();
    }
}