using System;
using System.Linq;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class MediaExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this MediaModel wf)
        {
            return JsonConvert.SerializeObject(wf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
        public static MediaModel ToMediaModel(this JToken media)
        {
            return new MediaModel()
            {
                MediaName = media.SelectToken("media_name").ToString(),
                MediaData = media.SelectToken("media_data").ToString(),
                MediaType = media.SelectToken("media_type").ToString(),
                CustomerCode = media.SelectToken("customer_code").ToString(),
                ReferenceType = media.SelectToken("reference_type").ToString(),
                ExpireDate = media.SelectToken("expire_date").ToString(),
                Other = media.SelectToken("other").ToString(),
                Infor1 = media.SelectToken("infor1")?.ToString(),
                Infor2 = media.SelectToken("infor2")?.ToString(),

            };
        }
    }
}
