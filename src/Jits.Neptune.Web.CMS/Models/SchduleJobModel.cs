#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ScheduleJobModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ScheduleJobModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// </summary>
        /// <summary>
        /// role id
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// rolename
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ContentRun { get; set; }
        /// <summary>
        /// ApplicationCode
        /// </summary>
        public string ApplicationCode { get; set; }

    }

}


