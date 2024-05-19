namespace Jits.Neptune.Web.CMS.LogicOptimal9.Utils;

/// <summary>
/// 
/// </summary>
public static class ObjectExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int ToInt(this object obj)
    {
        return int.Parse(obj.ToString());
    }
}
