using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
/// <summary>
/// 
/// </summary>
public class JsonGetDataById
{
    /// <summary>
    /// 
    /// </summary>
    public Object I { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Boolean M { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public JsonGetDataById(Object i = null, Boolean m = true) { 
        I = i; 
        M = m; 
    }
}