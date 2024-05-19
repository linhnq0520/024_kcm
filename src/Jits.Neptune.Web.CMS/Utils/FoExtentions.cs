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
    public static class FoExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSearch"></param>
        /// <returns></returns>
      
        public static Fo ToFoEntity(this JToken pageSearch)
        {
            var id = pageSearch["id"]?.ToString();
            if (!string.IsNullOrEmpty(id))
            return new Fo()
            {
                Id=  int.Parse(id) ,
                Actions= pageSearch["actions"]?.ToString(),
                App=pageSearch["app"]?.ToString(),
                Input=pageSearch["input"]?.ToString(),
                Request=pageSearch["request"]?.ToString(),
                Txcode=pageSearch["txcode"]?.ToString(),
               Txname = pageSearch["txname"]?.ToString(),
               Txtype = pageSearch["txtype"]?.ToString(),
                Status=pageSearch["status"]?.ToString(),
               Updatetime = DateTime.Now.Ticks
           };
           else return new Fo()
           {
               Actions = pageSearch["actions"]?.ToString(),
               App = pageSearch["app"]?.ToString(),
               Input = pageSearch["input"]?.ToString(),
               Request = pageSearch["request"]?.ToString(),
               Txcode = pageSearch["txcode"]?.ToString(),
               Txname = pageSearch["txname"]?.ToString(),
               Txtype = pageSearch["txtype"]?.ToString(),
               Status = pageSearch["status"]?.ToString(),
               Updatetime = DateTime.Now.Ticks
           };
        }
        
    }
}

