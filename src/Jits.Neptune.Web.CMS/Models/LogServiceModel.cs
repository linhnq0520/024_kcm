#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LogServiceModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LogServiceModel()
        {
         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long LogUtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string LogType { get; set; }

        /// <summary>
        /// ExecutionID
        /// </summary>
        public string ExecutionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string StepExecutionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string StepCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ServiceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string LogText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string JsonDetails { get; set; } = "{}";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public double RelativeDuration { get; set; } = 0;


    }
    /// <summary>
    /// 
    /// </summary>
    public class LogServiceSearchModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LogServiceSearchModel()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long  FromDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long ToDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string LogType { get; set; } = string.Empty;

        /// <summary>
        /// ExecutionID
        /// </summary>
        public string ExecutionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string StepExecutionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string StepCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ServiceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Subject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string LogText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string JsonDetails { get; set; } = "{}";


    }

   
}


