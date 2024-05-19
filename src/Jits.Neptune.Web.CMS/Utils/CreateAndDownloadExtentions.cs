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
    public static class CreateAndDownloadExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this CreateAndDownloadFileModel wf)
        {
            return JsonConvert.SerializeObject(wf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jT"></param>
        /// <returns></returns>
        public static CreateAndDownloadFileModel ToCreateAndDownloadFileModel(this JToken jT)
        {
            return new CreateAndDownloadFileModel()
            {
                file_name = jT.SelectToken("file_name")?.ToString(),
                key_api_convert = jT.SelectToken("key_api_convert")?.ToString(),
                lang_confirm = jT.SelectToken("lang_confirm")?.ToString(),
                table_code = jT.SelectToken("table_code")?.ToString(),
                key_val = jT.SelectToken("key_val")?.ToString()

            };
        }
     
    }
}

