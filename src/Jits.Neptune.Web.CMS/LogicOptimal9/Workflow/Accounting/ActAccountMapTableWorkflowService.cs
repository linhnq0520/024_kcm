
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

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class ActAccountMapTableWorkflowService : IActAccountMapTableWorkflowService
{
    private readonly IActAccountMapTableService _AccountMapTableService;
    /// <summary>
    /// 
    /// </summary>
    public ActAccountMapTableWorkflowService(IActAccountMapTableService AccountMapTableService)
    {
        _AccountMapTableService = AccountMapTableService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> AdvanceSearch(WorkflowExecuteModel workflow)
    {
        //throw new NotImplementedException();
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<ActAccountMapTableSearch>();
        var response = await _AccountMapTableService.AdvancedSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
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
        var response = await _AccountMapTableService.SimpleSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
}
