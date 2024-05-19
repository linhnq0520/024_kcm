
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
using Jits.Neptune.Web.CMS.Models.Response.Mortgage;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.Domain;
using Apache.NMS.ActiveMQ.Commands;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using Jits.Neptune.Core.Infrastructure;
using System.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class MortgageCatalogueDefinitionWorkflowService : IMortgageCatalogueDefinitionWorkflowService
{
    private readonly IMortgageCatalogueDefinitionService _mortgageService;
    private readonly IUserAccountService _useraccountService = EngineContext.Current.Resolve<IUserAccountService>();
    /// <summary>
    /// 
    /// </summary>
    public MortgageCatalogueDefinitionWorkflowService(IMortgageCatalogueDefinitionService mortgageService)
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
        var model = workflow.fields.ToModel<MTGCatalogueDefinitionSearch>();
        JToken response = null;
        var searchResult = O9Utils.AdvanceSearchCommon<MTGCatalogueDefinitionSearch, MTGCatalogueDefinitionResponse>(model, "MTG_CATALOGUE_DEFINITION");
        response = JToken.FromObject(searchResult.ToPagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>());

        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> View(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        var moldel = workflow.fields.ToModel<ViewModelWithCatId>();
        var response = _mortgageService.ViewByCatId(moldel.id);
        return JToken.FromObject(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> Create(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<MTGCatalogueDefinitionInsertRequest>();
        var response = _mortgageService.Insert(model, workflow.user_sessions);
        return JToken.FromObject(response);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> UpdateBO(WorkflowExecuteModel workflow)
    {
        var userSessions = new UserSessions
        {
            Usrid = workflow.user_sessions.Usrid,
            Ssesionid = workflow.user_sessions.Ssesionid,

        };
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<MTGCatalogueDefinitionUpdateRequest>();
        var response = _mortgageService.Update(model, userSessions);
        return JToken.FromObject(response);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> Delete(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();

    }

}
