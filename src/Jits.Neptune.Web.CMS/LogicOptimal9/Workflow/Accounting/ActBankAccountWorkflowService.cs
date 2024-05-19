
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
using System.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class ActBankAccountWorkflowService : IActBankAccountWorkflowService
{
    private readonly IActBankAccountService _BankAccountService;
    /// <summary>
    /// 
    /// </summary>
    public ActBankAccountWorkflowService(IActBankAccountService BankAccountService)
    {
        _BankAccountService = BankAccountService;
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

        var model = workflow.fields.ToModel<ActBankAccountDefinitionSearch>();

        //model.aclvl = model.aclvl ==0 ? null : model.aclvl;

        JToken response = null;

        var searchResult = O9Utils.AdvanceSearchCommon<ActBankAccountDefinitionSearch, ActBankAccountDefinitionSearchResponse>(model, "ACT_BANK_ACCOUNT_DEFINITION");

        response = JToken.FromObject(searchResult.ToPagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>());
        
        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SimpleSearch(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<SimpleSearchModel>();
        var response = await _BankAccountService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<ModelWithAcno>();
        var response = _BankAccountService.ViewByAcno(model.id);
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
        var model = workflow.fields.ToModel<ModelInsertBankAccountDefinition>();

        var response = _BankAccountService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
}
