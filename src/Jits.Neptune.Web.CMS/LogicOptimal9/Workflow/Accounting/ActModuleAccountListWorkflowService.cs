
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
public class ActModuleAccountListWorkflowService : IActModuleAccountListWorkflowService
{
    private readonly IActModuleAccountListService _ModuleAccountListService;
    /// <summary>
    /// 
    /// </summary>
    public ActModuleAccountListWorkflowService(IActModuleAccountListService ModuleAccountListService)
    {
        _ModuleAccountListService = ModuleAccountListService;
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

        var model = workflow.fields.ToModel <ActModuleAccountListSearch>();

        JToken response = null;

        var searchResult = O9Utils.AdvanceSearchCommon<ActModuleAccountListSearch, ActModuleAccountListSearchResponse>(model, "ACT_ACCOUNT_OF_GROUP_DEFINITION");

        response = JToken.FromObject(searchResult.ToPagedListModel<ActModuleAccountListSearchResponse, ActModuleAccountListSearchResponse>());

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
        var response = await _ModuleAccountListService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<ModelViewActModuleAccountList>();
        var response = _ModuleAccountListService.View(model);
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
        var model = workflow.fields.ToModel<ModelInsertModuleAccountList>();

        var response = _ModuleAccountListService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
}
