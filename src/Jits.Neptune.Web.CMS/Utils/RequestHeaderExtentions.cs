using System;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class RequestHeaderExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wf"></param>
        /// <returns></returns>
        public static string ToSerialize(this RequestHeaderModel wf)
        {
            return JsonConvert.SerializeObject(wf);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static RequestHeaderModel ToModel(this object model)
        {
            RequestHeaderModel requestHeader = new RequestHeaderModel();

            return requestHeader;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableCodeData"></param>
        /// <returns></returns>
        public static AuthenticateResponse ToAuthenticateResponseModel(this JToken tableCodeData)
        {

            return JsonConvert.DeserializeObject<AuthenticateResponse>(tableCodeData.ToSerialize());
            // return System.Text.Json.JsonSerializer.Deserialize<WorkflowExecutionInquiry>(System.Text.Json.JsonSerializer.Serialize(wf));
            // return wf.ToObject<WorkflowExecutionInquiry>();
        }
    }
}

