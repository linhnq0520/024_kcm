
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface;
using System;
using Jits.Neptune.Web.CMS.Models.Request.Mortgage;
using Jits.Neptune.Web.CMS.Models.Request.Job;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Microsoft.VisualStudio.Services.WebApi;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class MortgageAccountInformationWorkflowService : IMortgageAccountInformationWorkflowService
{
    private readonly IMortgageAccountInformationService _mortgageService;
    /// <summary>
    /// 
    /// </summary>
    public MortgageAccountInformationWorkflowService(IMortgageAccountInformationService mortgageService)
    {
        _mortgageService = mortgageService;
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
        var response = await _mortgageService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<MTGAccountInformationSearch>();
        var response = await _mortgageService.AdvanceSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> ViewAccount(WorkflowRequestModel workflow)
    {
        try

        {
            var request = new MTGAccountViewRequest
            {
                acno = workflow.fields["acno"].ToString(),
                workflowFun = workflow.WorkflowFunc
            };

            var value = new MTGAccountInformationViewResponse();
            var usrid = workflow.user_sessions.Usrid;
            DateTime date = workflow.user_sessions.Txdt;
            var userSessions = new UserSessions
            {
                Usrid = usrid,
                Lang = workflow.user_sessions.Lang,
                Ssesionid = workflow.user_sessions.Ssesionid,
                Txdt = date,
                UsrBranchid = workflow.user_sessions.UsrBranchid

            };
            await Task.CompletedTask;
            var model = workflow.fields.ToModel<MTGAccountViewRequest>();
            var objectView = _mortgageService.ViewAccount(request, userSessions);
            var response = objectView.BuildWorkflowResponseSuccess(false);
            return response;
        }
        catch(Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }   

    }

}
