using System;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using JITS.Neptune.NeptuneClient.Workflow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class JTokenExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this object wf)
        {
            return JsonConvert.SerializeObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerializeSystemText(this object wf)
        {
            return System.Text.Json.JsonSerializer.Serialize(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ToSerializeSystemTextWithModel<T>(this object wf) where T : BaseNeptuneModel
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(wf.ToSerializeSystemText());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DerializeSystemTextWithModel<T>(this string s)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static JObject ToJObject(this object wf)
        {
            return JObject.FromObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static JArray ToJArray(this object wf)
        {
            return JArray.FromObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static JToken ToJToken(this object wf)
        {
            return JToken.FromObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jT"></param>
        /// <returns></returns>
        public static UploadResponseModel ToUploadResponseModel(this JToken jT)
        {
            return new UploadResponseModel()
            {
                name = jT.SelectToken("name")?.ToString(),
                status = (int)jT.SelectToken("status"),
                user_id = jT.SelectToken("user_id").ToString()
            };
        }
        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="jT"></param>
        /// <returns></returns>
        public static int getAsInt(this JToken jT)
        {
            return int.Parse(jT.ToString());
        }



    }
}

