using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.CMS.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;

using Jits.Neptune.Web.CMS.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Helpers;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;

/// <summary>
/// SettingQueueService
/// </summary>
public class CreditCatalogWorkflowService : ICreditCatalogWorkflowService
{
    /// <summary>
    /// The credit catalog service
    /// </summary>
    private readonly ICreditCatalogService _creditCatalogService;

    /// <summary>
    /// 
    /// </summary>
    public CreditCatalogWorkflowService(ICreditCatalogService creditCatalogService)
    {
        _creditCatalogService = creditCatalogService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SimpleSearch(O9PostService.WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<SimpleSearchModel>();
        var response = O9Utils.SimpleSearchCommon<CrdCatalogueDefinitionResponse>(model, workflow.WorkflowFunc);
        var jtokenRespone = JToken.FromObject(response.ToPagedListModel<CrdCatalogueDefinitionResponse,CrdCatalogueDefinitionResponse>());
        return jtokenRespone;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> AdvanceSearch(O9PostService.WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        var model = workflow.fields.ToModel<CrdCatalogueDefinitionSearch>();
        var response = O9Utils.AdvanceSearchCommon<CrdCatalogueDefinitionSearch,CrdCatalogueDefinitionResponse>(model, workflow.WorkflowFunc);
        var jtokenRespone = JToken.FromObject(response.ToPagedListModel<CrdCatalogueDefinitionResponse,CrdCatalogueDefinitionResponse>());
        return jtokenRespone;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> Insert(O9PostService.WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        // var model = workflow.fields.ToModel<CrdCatalogInsertRequest>();
        // model.TRFCD = 178;
        // model.GRPID = 500;
        workflow.ObjectField["TRFCD"] = 178;
        workflow.ObjectField["GRPID"] = 500;
     
        var backOffice = O9Utils.BackOffice(workflow.user_sessions, "006001000002", "O9DATA.D_CRDCAT",  workflow.ObjectField);
        // var response = _creditCatalogService.Insert(workflow.fields,workflow.user_sessions);
        var jtokenRespone = JToken.FromObject(backOffice);
        return jtokenRespone;
    }

    
    
    /// <summary>
    /// CRD_TARIFF_CONFIGURATION
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>The token</returns>
    public async Task<JToken> TariffConfigguration(WorkflowExecuteModel workflow)
    {
        await Task.CompletedTask;
        // var resultTariff = O9Utils.RuleFunc<CrediTariffCatalogResponse>("TARIFF_CONFIGURATION", "IFC");
        //     return JToken.FromObject(resultTariff);
        JToken a = null;
        return a;
    }
    
    /// <summary>
    /// CRD_CATALOGUE_DEFINITION_TARIFF
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>The token</returns>
    public  async Task<JToken> CattalogDefinitionTariff(WorkflowExecuteModel workflow)
    {   
        await Task.CompletedTask;
        // var model = workflow.fields.ToModel<CattalogDefinitionTariffRequest>();
        // var resultIfc =  O9Utils.RuleFunc<CrediIfcCatalogResponse>("CATALOGUE_DEFINITION_TARIFF", "SYS",model.TariffCode);
        // return JToken.FromObject(resultIfc);
        JToken a = null;
        return a;
    }
    
}