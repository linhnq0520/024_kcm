
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;
using System;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Newtonsoft.Json;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;
using System.Collections.Generic;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class CustomerWorkflowService : ICustomerWorkflowService
{
    private readonly ICustomerProfileService _customerService;
    /// <summary>
    /// 
    /// </summary>
    public CustomerWorkflowService(ICustomerProfileService customerService)
    {
        _customerService = customerService;
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
        var response = await _customerService.SimpleSearch(model);
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
        var model = workflow.fields.ToModel<SimpleSearchCustomerProfileRequest>();
        model.dob = model.day_of_birth?.ToString("dd/MM/yyyy");
        var response = await _customerService.AdvanceSearch(model);
        var jtokenRespone = JToken.FromObject(response);
        return jtokenRespone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> View (WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<ModelWithId>();
        var response = await _customerService.View(model.Id);
        var jtokenRespone = JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
        return jtokenRespone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> Insert(WorkflowRequestModel workflow)
    {
        try
        {
            await Task.CompletedTask;
            var model = workflow.fields.ToModel<CustomerInsertRequestModel>();

            var response = _customerService.Insert(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);
            var result = await _customerService.View((int)response);
            var jtokenRespone = JToken.FromObject(result).BuildWorkflowResponseSuccess(false);
            return jtokenRespone;
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
    public async Task<JToken> Update(WorkflowRequestModel workflow)
    {
        try
        {
            await Task.CompletedTask;
            var model = workflow.fields.ToModel<CustomerUpdateRequestModel>();

            var response = _customerService.Update(model, workflow.user_sessions, workflow.TableName, workflow.WorkflowFunc);
            var result = await _customerService.View(response.CUSTOMERID);
            var jtokenRespone = JToken.FromObject(result).BuildWorkflowResponseSuccess(false);
            return jtokenRespone;
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
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> LookupDataCommune(WorkflowExecuteModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            var model = workflow.fields.ToModel<CodeListModel>();

            var value = await _customerService.LookupDataCommune(model);
            var response = value.ToPagedListModel<Cdlist, CdlistModel>();
            return JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
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
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> GetInforCdname(WorkflowExecuteModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            var model = workflow.fields.ToModel<CodeListPrimaryKey>();

            if (model.cdid == "")
            {
                return JToken.FromObject(model.cdid).BuildWorkflowResponseSuccess(false);
            }

            var value = _customerService.GetInforCdname(model);
           
            var response = JToken.FromObject(value).BuildWorkflowResponseSuccess(false);
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
    public async Task<JToken> LookupDataForPrimaryKey(WorkflowExecuteModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            var model = workflow.fields.ToModel<CodeListModel>();

            var value = await _customerService.LookupDataforPrimarykey(model);
            var response = value.ToPagedListModel<Cdlist, CdlistModel>();
            return JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
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
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> LookupDataSUBINDUSTRYOrSSRCINCOME(WorkflowExecuteModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            var model = workflow.fields.ToModel<CodeListModel>();

            var value = await _customerService.LookupDataSUBINDUSTRYOrSSRCINCOME(model);
            var response = value.ToPagedListModel<Cdlist, CdlistModel>();
            return JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
        
    }
}
