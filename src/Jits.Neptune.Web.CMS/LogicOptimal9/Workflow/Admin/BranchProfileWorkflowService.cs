
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
using JITS.NeptuneClient.Scheme.Workflow;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Framework.Services.Configuration;
using Jits.Neptune.Web.CMS.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class BranchProfileWorkflowService : IBranchProfileWorkflowService
{
    private readonly IBranchProfileService _branchService;
    private readonly ISettingService _settingService;
    /// <summary>
    /// 
    /// </summary>
    public BranchProfileWorkflowService(IBranchProfileService branchService, ISettingService settingService)
    {
        _branchService = branchService;
        _settingService = settingService;
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

        var model = workflow.fields.ToModel<BranchSearchModel>();

        var response = _branchService.AdvanceSearch(model);

        return JToken.FromObject(response.ToPagedListModel<BranchSearchResponseModel, BranchSearchResponseModel>());
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
        var response = _branchService.SimpleSearch(model);

        return JToken.FromObject(response.ToPagedListModel<BranchSearchResponseModel, BranchSearchResponseModel>());
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
        var response = _branchService.GetById(model.Id);

        return JToken.FromObject(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> RefreshBranch(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        var model = workflow.ObjectField.ToModel<BranchSearchModel>();

        if (workflow.ObjectField.TryGetValue("show_user_branch_only", out var showUserBranchOnly) && 
            bool.Parse(showUserBranchOnly.ToString()))
        {
            model.branchcd = workflow.user_sessions.UsrBranch;
        }

        var listBranch = _branchService.AdvanceSearch(model);

        var pagedList = listBranch.ToPagedListModel<BranchSearchResponseModel, BranchSearchResponseModel>();
        var response = JToken.FromObject(pagedList).BuildWorkflowResponseSuccess(false);

        return response;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> BranchProcess(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        var id = workflow.ObjectField.SelectToken("id").ToObject<int>();

        JObject jsObjControls = new();
        var userSession = workflow.user_sessions;
        try
        {
            jsObjControls.Add("BRID", id);
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<JToken> GetHostBranchId(WorkflowRequestModel workflow)
    {
        var code = await _settingService.GetSettingByKey<string>("Admin.HostBranch");
        return new { branch_code_ho = code }.BuildWorkflowResponseSuccess(false);
    }

}
