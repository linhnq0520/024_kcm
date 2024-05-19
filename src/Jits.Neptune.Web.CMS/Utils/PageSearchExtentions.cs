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
    public static class PageSearchExtentions
    {
        /// <summary>
        /// Returns a value constain in string
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this PageSearchModel wf)
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
        public static PageSearchModel ToPageSearchModel(this JToken pageSearch)
        {
           var items=pageSearch.SelectToken("items")!=null && pageSearch.SelectToken("items").Type != JTokenType.Null?pageSearch.SelectToken("items").ToList<object>():pageSearch.SelectToken("result").ToList<object>();
            return new PageSearchModel()
            {
                Items = items,
                TotalCount = pageSearch.SelectToken("total_count")!= null?Int32.Parse(pageSearch.SelectToken("total_count").ToString()):items.Count,
                TotalPages = pageSearch.SelectToken("total_pages")!= null?Int32.Parse(pageSearch.SelectToken("total_pages").ToString()):0,
                HasPreviousPage = pageSearch.SelectToken("has_previous_page") != null ? (bool)pageSearch.SelectToken("has_previous_page") : false,
                HasNextPage =pageSearch.SelectToken("has_next_page") != null ? (bool)pageSearch.SelectToken("has_next_page") : false,

            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSearch"></param>
        /// <returns></returns>
        public static SearchResponseModel ToSearchResponsePortalModel(this JToken pageSearch)
        {
            return new SearchResponseModel()
            {
                current_page = Int32.Parse(pageSearch.SelectToken("current_page").ToString()),
                from_index = Int32.Parse(pageSearch.SelectToken("from_index").ToString()),
                items_per_page = Int32.Parse(pageSearch.SelectToken("items_per_page").ToString()),
                to_index = Int32.Parse(pageSearch.SelectToken("to_index").ToString()),
                total_items = Int32.Parse(pageSearch.SelectToken("total_items").ToString()),
                total_pages = Int32.Parse(pageSearch.SelectToken("total_pages").ToString()),
                results = pageSearch.SelectToken("results").ToList<object>()
            };
        }
    }
}

