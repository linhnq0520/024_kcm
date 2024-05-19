
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
public class ActFixedAssetCatalogueWorkflowService : IActFixedAssetCatalogueWorkflowService
{
    private readonly IActFixedAssetCatalogueService _FixedAssetCatalogueDefinitionService;
    /// <summary>
    /// 
    /// </summary>
    public ActFixedAssetCatalogueWorkflowService(IActFixedAssetCatalogueService FixedAssetCatalogueDefinitionService)
    {
        _FixedAssetCatalogueDefinitionService = FixedAssetCatalogueDefinitionService;
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

        var model = workflow.fields.ToModel <ActFixedAssetCatalogueDefinitionSearch>();

        JToken response = null;

        var searchResult = O9Utils.AdvanceSearchCommon<ActFixedAssetCatalogueDefinitionSearch, ActFixedAssetCatalogueDefinitionSearchResponse>(model, "FAC_FIXED_ASSET_CATALOGUE_DEFINITION");

        response = JToken.FromObject(searchResult.ToPagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>());

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
        var response = await _FixedAssetCatalogueDefinitionService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<ModelWithId>();
        var response = _FixedAssetCatalogueDefinitionService.View(model);
        return JToken.FromObject(response);
    }
}
