using System.Collections.Generic;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using JITS.Neptune.NeptuneClient.Workflow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class ParaServerExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this ParaServerModel wf)
        {
            return JsonConvert.SerializeObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static ParaServerModel ToParaServerModel(this Dictionary<string, object> dict)
        {
            return new ParaServerModel()
            {
                Code = dict.GetValueOrDefault("code")?.ToString(),
                DataType = dict.GetValueOrDefault("data_type")?.ToString(),
                Des = dict.GetValueOrDefault("des")?.ToString(),
                IsAdmin = (bool)dict.GetValueOrDefault("isAdmin"),
                Value = dict.GetValueOrDefault("value")?.ToString(),
                App = dict.GetValueOrDefault("app")?.ToString()
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSearch"></param>
        /// <returns></returns>
        public static ParaServer ToParaServerEntity(this JToken pageSearch)
        {
            var id = pageSearch["id"]?.ToString();
            if (!string.IsNullOrEmpty(id))
                return new ParaServer()
                {
                    Id = int.Parse(id),
                    Code = pageSearch["code"]?.ToString(),
                    App = pageSearch["app"]?.ToString(),
                    Data_Type = pageSearch["data_type"]?.ToString(),
                    Des = pageSearch["des"]?.ToString(),
                    Isadmin = ((bool)pageSearch["isAdmin"]),
                    Value = pageSearch["value"]?.ToString()
                };
            else return new ParaServer()
            {
                Code = pageSearch["code"]?.ToString(),
                App = pageSearch["app"]?.ToString(),
                Data_Type = pageSearch["data_type"]?.ToString(),
                Des = pageSearch["des"]?.ToString(),
                Isadmin = ((bool)pageSearch["isAdmin"]),
                Value = pageSearch["value"]?.ToString()
            };
        }
    }
}

