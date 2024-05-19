using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Web.Framework.Services.Localization;
using System;

namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Base64Extension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static double GetOriginalLengthInBytes(string base64String)
        {
            var length = base64String.Contains("base64,") ? base64String.Split(',')[1].Length : base64String.Length;
            return Math.Ceiling((double)length / 4) * 3;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
