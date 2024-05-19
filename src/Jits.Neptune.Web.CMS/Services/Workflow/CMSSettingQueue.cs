using JITS.NeptuneClient.Scheme.Workflow;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Framework.Helpers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.Framework.Services.Queue;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Web.Framework.Services;
using System;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.Services.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public partial class CMSSettingQueueService : BaseQueueService
{
    /// <summary>
    /// Create
    /// </summary>
    /// /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<WorkflowScheme> Create(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<SettingCreateModel>();
        return await Invoke<SettingCreateModel>(workflow, async () =>
        {
            var valuee = await EngineContext.Current.Resolve<ICMSSettingService>().Create(model);
            return valuee;
        });
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<WorkflowScheme> Update(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<SettingUpdateModel>();
        return await Invoke<SettingUpdateModel>(workflow, async () =>
        {
            var rs = await EngineContext.Current.Resolve<ICMSSettingService>().Update(model, model.ReferenceId);
            return rs;
        });
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<WorkflowScheme> Delete(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<ModelWithId>();
        return await Invoke<ModelWithId>(workflow, async () =>
        {
            var rs = await EngineContext.Current.Resolve<ICMSSettingService>().Delete(model.Id, model.ReferenceId);
            return rs;
        });
    }

    /// <summary>
    /// View
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>View
    public async Task<WorkflowScheme> View(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<ModelWithId>();
        return await Invoke<ModelWithId>(workflow, async () =>
        {
            var group = await EngineContext.Current.Resolve<ICMSSettingService>().View(model.Id);
            return group;
        });
    }


    /// <summary>
    /// SimpleSearch
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<WorkflowScheme> SimpleSearch(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<SimpleSearchModel>();
       
        return await Invoke<SimpleSearchModel>(workflow, async () =>
        {
            try
            {
            var value = await EngineContext.Current.Resolve<ICMSSettingService>().Search(model);
            //System.Console.WriteLine("value setting"+ value.ToSerialize());
            //System.Console.WriteLine("value convert setting"+ value.ToPagedListModel<Setting, SettingSearchResponse>().ToSerialize());
            return value.ToPagedListModel<Setting, SettingSearchResponse>();

            }
            catch(Exception ex)
            {
                System.Console.WriteLine("error: " + ex);
                throw;
            }
        });
    }

    /// <summary>
    /// AdvanceSearch
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<WorkflowScheme> AdvanceSearch(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<SettingSearchModel>();
        return await Invoke<SettingSearchModel>(workflow, async () =>
        {
            var value = await EngineContext.Current.Resolve<ICMSSettingService>().Search(model);
            return value.ToPagedListModel<Setting, SettingSearchResponse>();
        });
    }

    /// <summary>
    /// GetListAuditSetting
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<WorkflowScheme> GetListAuditSetting(WorkflowScheme workflow)
    {
        var model = await workflow.ToModel<ListAuditModel>();
        return await Invoke<ListAuditModel>(workflow, async () =>
        {
            var setting = await EngineContext.Current.Resolve<ICMSSettingService>().GetById(model.Id) ?? new Setting();
            var settingResponse = await EngineContext.Current.Resolve<ITransactionService>().ListAuditTransactions(setting, model.PageIndex, model.PageSize);
            return settingResponse;
        });
    }
}
