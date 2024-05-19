using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;
using System;
using Jits.Neptune.Web.CMS.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class CreditIfcWorkflowService : ICreditIfcWorkflowService
{
    private readonly ICreditIFCService _service;

    /// <summary>
    /// 
    /// </summary>
    public CreditIfcWorkflowService(ICreditIFCService service )
    {
        _service = service;
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
        var response = _service.SimpleSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> AdvanceSearch(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<CrdIfcDenfinitionSearch>();
        // model.dob = model.day_of_birth?.ToString("dd/MM/yyyy");
        var response = _service.AdvanceSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
}