#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemCalendarModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemCalendarModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// rolename
        /// </summary>
        public string start { get; set; }

        /// <summary>
        /// Parent command Id
        /// </summary>
        public bool allDay { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string color { get; set; } = "#257e4a";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string constraint { get; set; } = "availableForMeeting";



    }
}


