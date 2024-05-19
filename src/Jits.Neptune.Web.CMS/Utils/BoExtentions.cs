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
    public static class BoExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSearch"></param>
        /// <returns></returns>
      
        public static Bo ToBoEntity(this JToken pageSearch)
        {
            var id = pageSearch["id"]?.ToString();
            if (!string.IsNullOrEmpty(id))
           return new Bo()
            {
               Id = int.Parse(id) ,
                Actions= pageSearch["actions"]?.ToString(),
                App=pageSearch["app"]?.ToString(),
                Input=pageSearch["input"]?.ToString(),
                Response=pageSearch["response"]?.ToString(),
                Txcode=pageSearch["txcode"]?.ToString(),
               Txname = pageSearch["txname"]?.ToString(),
               Txtype = pageSearch["txtype"]?.ToString(),
                Status=pageSearch["status"]?.ToString(),
                Updatetime= DateTime.Now.Ticks
            };
            else return new Bo()
            {
                Actions= pageSearch["actions"]?.ToString(),
                App=pageSearch["app"]?.ToString(),
                Input=pageSearch["input"]?.ToString(),
                Response=pageSearch["response"]?.ToString(),
                Txcode=pageSearch["txcode"]?.ToString(),
               Txname = pageSearch["txname"]?.ToString(),
               Txtype = pageSearch["txtype"]?.ToString(),
                Status=pageSearch["status"]?.ToString(),
                Updatetime= DateTime.Now.Ticks
            };
        }
        
    }
}

