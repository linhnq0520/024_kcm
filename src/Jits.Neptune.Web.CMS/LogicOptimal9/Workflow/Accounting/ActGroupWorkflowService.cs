
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
using Microsoft.AspNetCore.Http.HttpResults;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class ActGroupWorkflowService : IActGroupWorkflowService
{
    private readonly IActGroupService _GroupService;
    /// <summary>
    /// 
    /// </summary>
    public ActGroupWorkflowService(IActGroupService GroupService)
    {
        _GroupService = GroupService;
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

        var model = workflow.fields.ToModel <ActGroupDefinitionSearch>();

        JToken response = null;

        var searchResult = O9Utils.AdvanceSearchCommon<ActGroupDefinitionSearch, ActGroupDefinitionSearchResponse>(model, "ACT_ACCOUNTING_GROUP_DEFINITION");

        response = JToken.FromObject(searchResult.ToPagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>());

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
        var response = await _GroupService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<ModelViewActGroup>();
        var response = _GroupService.View(model);
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
        var model = workflow.fields.ToModel<ModelInsertGroupDefinition>();

        var response = _GroupService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
}
