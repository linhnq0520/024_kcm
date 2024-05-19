using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Utils
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataFormatAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Format { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        public DataFormatAttribute(string format)
        {
            Format = format;
        }
    }
}
