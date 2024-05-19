using System;

/// <summary>
/// 
/// </summary>
public class TimeUtils
{
    private static readonly DateTime Jan1st1970 = new DateTime
    (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static long CurrentTimeMillis()
    {
        return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
    }
}