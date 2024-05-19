using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using System;
using System.Linq;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class PageSearchMediaExtentions
    {
        /// <summary>
        /// Returns a value constain in string
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this PageSearchMediaModel wf)
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
        /// <param name="pageSearch"></param>
        /// <returns></returns>
        public static PageSearchMediaModel ToPageSearchMediaModel(this JToken pageSearch)
        {
            
           return new PageSearchMediaModel()
            {
                items = pageSearch.SelectToken("items").ToList<object>(),
                total_count = Int32.Parse(pageSearch.SelectToken("total_count").ToString()),
                total_pages = Int32.Parse(pageSearch.SelectToken("total_pages").ToString()),
                has_previous_page = (bool)pageSearch.SelectToken("has_previous_page"),
                has_next_page = (bool)pageSearch.SelectToken("has_next_page"),
                MEDIA=pageSearch.SelectToken("MEDIA")?.ToList<object>(),
                PAGING=pageSearch.SelectToken("PAGING"),
            };
        }
        
    }
}

