
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.Framework.Services.Queue;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Web.Framework.Services;
using System;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class ActClearAccountWorkflowService : IActClearAccountWorkflowService
{
    private readonly IActClearAccountService _ClearAccountService;
    /// <summary>
    /// 
    /// </summary>
    public ActClearAccountWorkflowService(IActClearAccountService ClearAccountService)
    {
        _ClearAccountService = ClearAccountService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> AdvanceSearch(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;

        var model = workflow.fields.ToModel < ActClearAccountDefinitionSearch>();

        JToken response = null;

        var searchResult = O9Utils.AdvanceSearchCommon<ActClearAccountDefinitionSearch, ActClearAccountDefinitionSearchResponse>(model, "ACT_IBT_CLEARING");

        response = JToken.FromObject(searchResult.ToPagedListModel<ActClearAccountDefinitionSearchResponse, ActClearAccountDefinitionSearchResponse>());

        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SimpleSearch(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<SimpleSearchModel>();
        var response = await _ClearAccountService.SimpleSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> View(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<ModelViewActClearAccount>();
        var response = _ClearAccountService.ViewByAcno(model);
        return JToken.FromObject(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> Create(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<ModelInsertClearAccount>();

        var response = _ClearAccountService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
}
