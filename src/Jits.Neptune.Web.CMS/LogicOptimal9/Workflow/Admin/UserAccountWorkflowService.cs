
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using System;
using System.Threading.Tasks;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Services;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class UserAccountWorkflowService : IUserAccountWorkflowService
{
    private readonly IUserAccountService _userAccountService;
    private readonly ILocalizationService _localizationService;
    private readonly IUserSessionsService _userSessionsService;

    /// <summary>
    /// 
    /// </summary>
    public UserAccountWorkflowService(IUserAccountService userAccountService, 
        ILocalizationService localizationService,
        IUserSessionsService userSessionsService)
    {
        _userAccountService = userAccountService;
        _localizationService = localizationService;
        _userSessionsService = userSessionsService;
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
        var model = workflow.fields.ToModel<UserAccountSearchModel>();
        JToken response = null;
        try
        {
            var searchResult = O9Utils.AdvanceSearchCommon<UserAccountSearchModel, UserAccountSearchResponseModel>(model, "ADM_USER_PROFILE");

            response= JToken.FromObject(searchResult.ToPagedListModel<UserAccountSearchResponseModel, UserAccountSearchResponseModel>());
        }
        catch (Exception e)
        {
            await Console.Out.WriteLineAsync(e.Message);
        }
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
        var response = O9Utils.SimpleSearchCommon<UserAccountSearchResponseModel>(model, workflow.WorkflowFunc);

        return JToken.FromObject(response.ToPagedListModel<UserAccountSearchResponseModel, UserAccountSearchResponseModel>());
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
        var response = _userAccountService.GetById(model.Id);

        return JToken.FromObject(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> Update(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        try
        {
            var value = await _userAccountService.Update(workflow);
            var response = value.BuildWorkflowResponseSuccess();
            return response;
        }
        catch(Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> Create(WorkflowRequestModel workflow)
    {
        try
        {
            await Task.CompletedTask;
            var modelRequest = workflow.fields.ToModel<UserAccountCreateRequestModel>();

            var model = modelRequest.ToModel<UserAccountCreateModel>();
            model.mphone = modelRequest.MultiPhone.JsonConvertToModel<MultiPhoneNumber>();
            model.position = modelRequest.MultiPosition.JsonConvertToModel<MultiPosition>();
            model.branchid = int.Parse(modelRequest.BranchCode);
            model.deprtid = int.Parse(modelRequest.DepartmentCode);

            var userResponse = _userAccountService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);

            var objectView = _userAccountService.GetById(userResponse["usrid"].ToObject<int>());
            var response = objectView.BuildWorkflowResponseSuccess();
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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
    public async Task<JToken> LogOutUser(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        
        try
        {
            JObject dataRequest = workflow.ObjectField;
            string userId = dataRequest.SelectToken(workflow.IdFieldName.ToLower()).ToObject<string>();
            if (string.IsNullOrEmpty(userId))
            {
                var message = _localizationService.GetResource("UserAccount.InvalidUserId");
                return message.BuildWorkflowResponseSuccess();
            }
            await _userSessionsService.DeleteAllById(userId);
            string strResult = O9Utils.GenJsonBodyRequest(
                objJsonBody: null, functionId: workflow.WorkflowFunc, 
                isResultCaching: EnmCacheAction.NoCached, usrId: userId);

            var result = strResult.BuildWorkflowResponseSuccess(false);

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
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> ResetPassword(WorkflowRequestModel workflow)
    {
        try
        {
            var result = await _userAccountService.ResetPassword(workflow);
            var viewResult = _userAccountService.GetById(workflow.ObjectField["id"].ToObject<int>());
            var response = viewResult.BuildWorkflowResponseSuccess();
            return response;
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> ChangePassword(WorkflowRequestModel workflow)
    {
        try
        {
            var result = await _userAccountService.ChangePassword(workflow);
            var response = result;
            return response;
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }
}
