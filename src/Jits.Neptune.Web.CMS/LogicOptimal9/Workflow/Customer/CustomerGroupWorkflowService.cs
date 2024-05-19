
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class CustomerGroupWorkflowService : ICustomerGroupWorkflowService
{
    private readonly ICustomerGroupService _customerGroupService;
    private readonly IBaseWorkflowService _baseService;
    private readonly IMappingService _mappingService;
    /// <summary>
    /// 
    /// </summary>
    public CustomerGroupWorkflowService(ICustomerGroupService customerGroupService, IBaseWorkflowService baseService, 
        IMappingService mappingService)
    {
        _customerGroupService = customerGroupService;
        _baseService = baseService;
        _mappingService = mappingService;
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
        var response = await _customerGroupService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<AdvanceSearchCustomerGroupRequest>();
        var response = await _customerGroupService.AdvanceSearch(model);
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
        var response = _customerGroupService.GetById(model.Id);
        var jtokenRespone = JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
        return jtokenRespone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SearchCustomerProfile(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var data = await _baseService.SearchData(workflow, false);
        return data["data"].BuildWorkflowResponseSuccess(true);
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

            var modelRequest = workflow.fields.ToModel<CustomerGroupRequestUpdateModel>();

            var model = modelRequest.ToModel<CustomerGroupRequestUpdateModel>();

            var userResponse = _customerGroupService.Update(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);

            var objectView = _customerGroupService.GetById(userResponse["grpid"].ToObject<int>());
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
    /// <exception cref="Exception"></exception>
    public async Task<JToken> Create(WorkflowRequestModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            var modelRequest = workflow.fields.ToModel<CustomerGroupRequestInsertModel>();

            var model = modelRequest.ToModel<CustomerGroupRequestInsertModel>();

            var userResponse = _customerGroupService.Create(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);

            var objectView = _customerGroupService.GetById(userResponse["grpid"].ToObject<int>());
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
