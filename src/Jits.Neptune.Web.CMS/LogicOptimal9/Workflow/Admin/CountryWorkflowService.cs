
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
public class CountryWorkflowService : ICountryWorkflowService
{
    private readonly ICountryService _countryService;
    /// <summary>
    /// 
    /// </summary>
    public CountryWorkflowService(ICountryService countryService)
    {
        _countryService = countryService;
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

        var model = workflow.fields.ToModel<CountrySearchModel>();

        //var response = __countryService.AdvanceSearch(model);
        var response = O9Utils.AdvanceSearchCommon<CountrySearchModel, CountrySearchResponseModel>(model, "ADM_COUNTRY");

        return JToken.FromObject(response.ToPagedListModel<CountrySearchResponseModel, CountrySearchResponseModel>());
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
        //var response = __countryService.SimpleSearch(model);
        var response = O9Utils.SimpleSearchCommon<CountrySearchResponseModel>(model, "ADM_COUNTRY");
        return JToken.FromObject(response.ToPagedListModel<CountrySearchResponseModel, CountrySearchResponseModel>());
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

        var model = workflow.fields.ToModel<CountrySearchModel>();
        var response = _countryService.GetByIso3Alpha(model.ctrycd3);

        return JToken.FromObject(response);
    }
}
