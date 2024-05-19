
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;
using Humanizer;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.Admin.Models;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class CustomerLinkageWorkflowService : ICustomerLinkageWorkflowService
{
    private readonly ICustomerLinkageService _customerLinkageService;
    /// <summary>
    /// 
    /// </summary>
    public CustomerLinkageWorkflowService(ICustomerLinkageService customerLinkageService)
    {
        _customerLinkageService = customerLinkageService;
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
        var response = await _customerLinkageService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<AdvanceSearchCustomerLinkageRequest>();
        var userid = workflow.user_sessions;
        var response = await _customerLinkageService.AdvanceSearch(model);
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
        var response =  _customerLinkageService.GetById(model.Id);
        var jtokenRespone = JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
        return jtokenRespone;
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
            var modelRequest = workflow.fields.ToModel<CustomerLinkageRequestInsertModel>();

            var model = modelRequest.ToModel<CustomerLinkageRequestInsertModel>();

            var userResponse = _customerLinkageService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);

            var objectView = _customerLinkageService.GetById(userResponse["lkgid"].ToObject<int>());
            //var response = await _mappingService.MappingResponse(workflow.MappingResponse, objectView);
            var response = objectView.BuildWorkflowResponseSuccess(false);
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
    public async Task<JToken> Update(WorkflowRequestModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            var modelRequest = workflow.fields.ToModel<CustomerLinkageRequestUpdateModel>();
            
            var model = modelRequest.ToModel<CustomerLinkageRequestUpdateModel>();

            var userResponse = _customerLinkageService.Update(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);

            var objectView = _customerLinkageService.GetById(userResponse["lkgid"].ToObject<int>());
            //var response = await _mappingService.MappingResponse(workflow.MappingResponse, objectView);
            var response = objectView.BuildWorkflowResponseSuccess(false);
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
