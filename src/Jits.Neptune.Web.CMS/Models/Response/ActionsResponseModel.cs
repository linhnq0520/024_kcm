#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using System;
using System.Collections.Generic;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="InputValueType"></typeparam>
    public class ActionsResponseModel<InputValueType> : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ActionsResponseModel()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("fo")]
        public List<FoResponseModel<InputValueType>> fo { get; set; } = new List<FoResponseModel<InputValueType>>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [JsonProperty("error")]
        public List<ErrorInfoModel> error { get; set; } = new List<ErrorInfoModel>();


    }
}