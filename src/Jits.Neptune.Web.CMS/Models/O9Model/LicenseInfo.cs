using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.O9Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LicenseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public LicenseInfo()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExpiryDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> ListModule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ListModuleMD5 { get; set; }
    }
}
