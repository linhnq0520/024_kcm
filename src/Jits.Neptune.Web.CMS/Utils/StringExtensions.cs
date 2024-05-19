using System;
using System.Linq;
using StackExchange.Redis;


namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class StringExtensions
    {
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CaptializeFirstLetter(this string s) {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CaptializeFirstLetterRemoveUnderScore(this string str)
        {
            var rs = "";
            foreach (var s in str.Split("_"))
            {
                rs += char.ToUpper(s[0]) + s.Substring(1);
            }
            return rs;
        }
        /// <summary>
        /// Returns a value constain in string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In(this string value, string[] values)
        {
            foreach (var item in values)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Write line value console
        /// </summary>
        /// <param name="value"></param>
        public static void Print(this string value)
        {
            System.Console.WriteLine(value);
        }

        /// <summary>
        /// Convert string to title casse (text sample -> Text Sample)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="culTureInfro"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string str, string culTureInfro = "en-US")
        {
            string strReturn = str;
            System.Globalization.TextInfo info = new System.Globalization.CultureInfo(culTureInfro, false).TextInfo;
            return info.ToTitleCase(strReturn);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="culTureInfro"></param>
        /// <returns></returns>
        public static string ToTitleCaseRemoveUnderScore(this string str, string culTureInfro = "en-US")
        {
            string strReturn = str;
            System.Globalization.TextInfo info = new System.Globalization.CultureInfo(culTureInfro, false).TextInfo;
            return info.ToTitleCase(strReturn).Replace("_", "");
        }

        /// <summary>
        /// Convert string to Underscore case (Snack case)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUnderscoreCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T MapToModel<T>(this string str)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(str);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string st) 
        { 
            int n; 
            return int.TryParse(st, out n); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpaceAndUpper(this string st)
        {
            return st.ToUpper().Replace(" ", "").Trim();
        }
    }

    /// <summary>
    /// OptionFormatString
    /// </summary>
    public enum OptionFormatString
    {
        /// <summary>
        /// Default
        /// </summary>
        Default = 0,

        /// <summary>
        /// UnderscoreCase (Snack case)
        /// </summary>
        UnderscoreCase = 1,

        /// <summary>
        /// TitleCase
        /// </summary>
        TitleCase = 2
    }
}
