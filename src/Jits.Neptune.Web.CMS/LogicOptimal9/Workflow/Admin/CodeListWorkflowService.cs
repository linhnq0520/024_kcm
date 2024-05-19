
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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Domain;
using JITS.NeptuneClient.Scheme.Workflow;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.Framework;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Microsoft.Extensions.Caching.Memory;
using LinqToDB.Common.Internal.Cache;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class CodeListWorkflowService : ICodeListWorkflowService
{
    private readonly ICodeListService _codeListService;
    private readonly ICdlistService _cdlistService;
    private readonly IMemoryCache _memoryCache;
    /// <summary>
    /// 
    /// </summary>
    public CodeListWorkflowService(ICodeListService codeListService, ICdlistService cdlistService
        , IMemoryCache memoryCache)
    {
        _codeListService = codeListService;
        _cdlistService = cdlistService;
        _memoryCache = memoryCache;
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

        var model = workflow.fields.ToModel<CodeListModel>();

        var value = await _codeListService.Search(model);
        var response = value.ToPagedListModel<Cdlist, CdlistModel>();
        return JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
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
    public async Task<JToken> GetByPrimaryKey(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        var model = workflow.fields.ToModel<CodeListPrimaryKey>();

        var value =  _codeListService.GetByPrimaryKey(model);
        var response = value.BuildWorkflowResponseSuccess(false);
        return JToken.FromObject(response);
    }
}
