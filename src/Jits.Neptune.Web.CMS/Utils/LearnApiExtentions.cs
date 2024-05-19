using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class LearnApiExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSearch"></param>
        /// <returns></returns>
      
        public static LearnApi ToLearnApiEntity(this JToken pageSearch)
        {
            var id = pageSearch["id"]?.ToString();
            if (!string.IsNullOrEmpty(id))
           return new LearnApi()
            {
                Id=int.Parse(id),
               LearnApiId =pageSearch["learn_api_id"]?.ToString(),
                LearnApiName = pageSearch["learn_api_name"]?.ToString(),
                App=pageSearch["app"]?.ToString(),
               LearnApiLink =pageSearch["learn_api_link"]?.ToString(),
               LearnApiData =pageSearch["learn_api_data"]?.ToString(),
               LearnApiNodeData =pageSearch["learn_api_node_data"]?.ToString(),
               LearnApiApp = pageSearch["learn_api_app"]?.ToString(),
               LearnApiMethod = pageSearch["learn_api_method"]?.ToString(),
               FlowApi =pageSearch["flow_api"]?.ToString(),
               SaveTo = pageSearch["save_to"]?.ToString(),
               LearnApiHeader = pageSearch["learn_api_header"]?.ToString(),
               LearnApiMapping = pageSearch["learn_api_mapping"]?.ToString(),
               NumberOfSteps = pageSearch["number_of_steps"]?.ToString(),
               KeyReadData = pageSearch["key_read_data"]?.ToString()
            }; 
            else return new LearnApi()
            {
               LearnApiId =pageSearch["learn_api_id"]?.ToString(),
                LearnApiName = pageSearch["learn_api_name"]?.ToString(),
                App=pageSearch["app"]?.ToString(),
               LearnApiLink =pageSearch["learn_api_link"]?.ToString(),
               LearnApiData =pageSearch["learn_api_data"]?.ToString(),
               LearnApiNodeData =pageSearch["learn_api_node_data"]?.ToString(),
               LearnApiApp = pageSearch["learn_api_app"]?.ToString(),
               LearnApiMethod = pageSearch["learn_api_method"]?.ToString(),
               FlowApi =pageSearch["flow_api"]?.ToString(),
               SaveTo = pageSearch["save_to"]?.ToString(),
               LearnApiHeader = pageSearch["learn_api_header"]?.ToString(),
               LearnApiMapping = pageSearch["learn_api_mapping"]?.ToString(),
               NumberOfSteps = pageSearch["number_of_steps"]?.ToString(),
               KeyReadData = pageSearch["key_read_data"]?.ToString()
            }; 
        }
        
    }
}

