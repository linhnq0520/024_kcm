#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Concurrent;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ListExecuteModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ListExecuteModel() { }
        /// <summary>
        /// </summary>
        public ConcurrentDictionary<string, Jits.Neptune.Web.Framework.Services.Events.WorkflowEvent> listExecuteModel { get; set; } = new ConcurrentDictionary<string, Jits.Neptune.Web.Framework.Services.Events.WorkflowEvent>();

    }
}


