using JITS.Neptune.NeptuneClient.Workflow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using System;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class CdlistExtentions
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="wf"></param>
       /// <returns></returns>
        public static string ToSerialize(this Cdlist wf)
        {
            return JsonConvert.SerializeObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Cdlist FromModel(this CdlistModel model)
        {
            Cdlist codeList = new Cdlist();
            codeList = model.ToEntity(codeList);
            codeList.Visible = model.Visible == null ? 1 : (int)model.Visible;
            codeList.Mcaption = JsonConvert.SerializeObject(model.Mcaption);
            return codeList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableCodeData"></param>
        /// <returns></returns>
        public static Cdlist ToCdlist(this JToken tableCodeData)
        {

            return new Cdlist()
            {
                Cdid = tableCodeData["cdid"]?.ToString(),
                App = tableCodeData["app"]?.ToString(),
                Caption = tableCodeData["caption"]?.ToString(),
                Cdgrp = tableCodeData["cdgrp"]?.ToString(),
                Cdidx = Int32.Parse(tableCodeData["cdidx"]?.ToString()),
                Cdname = tableCodeData["cdname"]?.ToString(),
                Ftag = tableCodeData["ftag"]?.ToString(),
                Cdval = tableCodeData["cdval"]?.ToString(),
                Mcaption = tableCodeData.SelectToken("mcaption") != null ? JsonConvert.SerializeObject(tableCodeData["mcaption"]) : "{}",
                Visible = Int32.Parse(tableCodeData["visible"]?.ToString())

            };
            // return System.Text.Json.JsonSerializer.Deserialize<WorkflowExecutionInquiry>(System.Text.Json.JsonSerializer.Serialize(wf));
            // return wf.ToObject<WorkflowExecutionInquiry>();
        }
    }
}

