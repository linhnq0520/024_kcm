using System.Collections.Generic;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class Optimal9Settings
    {
        /// <summary>
        /// 
        /// </summary>
        public string Memcached { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PoolConnection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CoreConfig Configure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LbName { get; set; } = "API";
        /// <summary>
        /// 
        /// </summary>
        public string ncbsCbsMode { get; set; }
    }
}