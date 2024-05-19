using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;

/// <summary>
/// 
/// </summary>
public class JsonResponse
{
    /// <summary>
    /// 
    /// </summary>
    public int R { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public object M { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsERROR()
    {
        return R == (int)EnmJsonResponse.E ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsOK()
    {
        return R == (int)EnmJsonResponse.O ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsWARN()
    {
        return R == (int)EnmJsonResponse.W ? true : false;
    }

    /// <summary>
    /// 
    /// </summary>
    public string GetMessage()
    {
        if (M != null) return M.ToString();
        return string.Empty;
    }
}
