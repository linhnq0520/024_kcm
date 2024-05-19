
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

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class ActFixedAssetAndToolWorkflowService : IActFixedAssetAndToolWorkflowService
{
    private readonly IActFixedAssetAndToolService _FixedAssetAndToolService;
    /// <summary>
    /// 
    /// </summary>
    public ActFixedAssetAndToolWorkflowService(IActFixedAssetAndToolService FixedAssetAndToolService)
    {
        _FixedAssetAndToolService = FixedAssetAndToolService;
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

        var model = workflow.fields.ToModel <ActFixedAssetAndToolSearch>();

        JToken response = null;

        var searchResult = O9Utils.AdvanceSearchCommon<ActFixedAssetAndToolSearch, ActFixedAssetAndToolSearchResponse>(model, "FAC_FIXED_ASSET_AND_TOOL");

        response = JToken.FromObject(searchResult.ToPagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>());

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
        var response = await _FixedAssetAndToolService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<ModelViewActFixedAssetAndTool>();
        var response = _FixedAssetAndToolService.View(model);
        return JToken.FromObject(response);
    }
}
