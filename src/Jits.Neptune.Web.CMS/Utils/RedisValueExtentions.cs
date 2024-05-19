using Jits.Neptune.Web.CMS.GrpcServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Domain;
using StackExchange.Redis;
using System;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class RedisValueExtentions
    {
        static readonly string[] nix = new string[0];
/// <summary>
/// 
/// </summary>
/// <param name="values"></param>
/// <returns></returns>
        public static string[] ToStringArray(this RedisValue[] values)
        {
            if (values == null) return null;
            if (values.Length == 0) return nix;
            return Array.ConvertAll(values, x => (string)x);
        }
    }
}

