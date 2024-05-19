
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System;
using System.Threading.Tasks;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class UserPolicyWorkflowService : IUserPolicyWorkflowService
{
    private readonly IUserPolicyService _policyService;
    /// <summary>
    /// 
    /// </summary>
    public UserPolicyWorkflowService(IUserPolicyService policyService)
    {
        _policyService = policyService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> AdvanceSearch(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        var model = workflow.fields.ToModel<UserPolicySearchModel>();
        model.effrom = model.EffectiveFrom?.ToString("dd/MM/yyyy");
        model.efto = model.EffectiveTo?.ToString("dd/MM/yyyy");

        var response = _policyService.AdvanceSearch(model);

        return JToken.FromObject(response.ToPagedListModel<UserPolicySearchResponseModel, UserPolicySearchResponseModel>());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<JToken> Create(WorkflowRequestModel workflow)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<JToken> Delete(WorkflowRequestModel workflow)
    {
        throw new NotImplementedException();
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
        var response = _policyService.SimpleSearch(model);

        return JToken.FromObject(response.ToPagedListModel<UserPolicySearchResponseModel, UserPolicySearchResponseModel>());
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<JToken> Update(WorkflowRequestModel workflow)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> View(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        var model = workflow.fields.ToModel<ModelWithId>();
        var response = _policyService.GetById(model.Id);

        return JToken.FromObject(response);
    }
}
