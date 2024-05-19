
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.Framework.Services.Queue;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Web.Framework.Services;
using System;
using System.Threading.Tasks;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System.Linq;
using Jits.Neptune.Web.CMS.Utils;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using static LinqToDB.Common.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class BankWorkflowService : IBankWorkflowService
{
    /// <summary>
    /// 
    /// </summary>
    public BankWorkflowService()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> BankProcess(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        JObject jsObjControls = new();
        var userSession = workflow.user_sessions;
        try
        {
            jsObjControls.Add("BDATE", userSession.Txdt.ToString("dd/MM/yyyy"));
            string strResult = O9Utils.GenJsonFrontOfficeRequest(userSession, workflow.WorkflowFunc, jsObjControls);
            var result = O9Utils.AnalysisBOResultSingle(strResult, null, false);
            //var result = jsObjControls.BuildWorkflowResponseSuccess(false);
            return result;
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }
}
