using System;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// The credit fo worklow serivce class
/// </summary>
public class CreditFoWorklowSerivce
{
    /// <summary>
    /// Dpts the opn using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>A task containing the token</returns>
    public async Task<JToken> DPT_OPN(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        // var a = O9Utils.GenJsonFrontOfficeRequest(workflow.user_sessions, "DPT_OPN", workflow.fields.ToJObject());
        var b = FrontOffice(workflow.user_sessions, "DPT_OPN", workflow.fields.ToJObject());
        return workflow.ToJToken();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userSessions"></param>
    /// <param name="txCode"></param>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static JsonFrontOffice FrontOffice(UserSessions userSessions, string txCode,
        JObject requestModel)
    {
        string result = O9Utils.GenJsonFrontOfficeRequest(userSessions, txCode, requestModel);

        var convert = JsonConvert.DeserializeObject<JsonFrontOfficeResponse>(result);
        if (convert == null || convert.R > 0)
        {
            throw new Exception("Error FrontOfficeRequest:" + (convert == null ? "Null data" : convert.M.ToString()));
        }

        return new JsonFrontOffice(JsonConvert.DeserializeObject<JsonFrontOfficeMapping>(convert.M.ToString()!));
    }
}