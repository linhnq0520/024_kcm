using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models.FrontOfficeModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Utils;
using System.Collections.Generic;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using System;
using System.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class TransactionJournalWorkflowService : ITransactionJournalWorkflowService
{
    private readonly IBaseWorkflowService _baseWorkflow;
    private readonly IWorkflowDefinitionService _workflowDefinitionService;
    private readonly IMappingService _mappingService;
    /// <summary>
    /// 
    /// </summary>
    public TransactionJournalWorkflowService(IWorkflowDefinitionService workflowDefinitionService, IMappingService mappingService, IBaseWorkflowService baseWorkflow)
    {
        _workflowDefinitionService = workflowDefinitionService;
        _mappingService = mappingService;
        _baseWorkflow = baseWorkflow;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> ViewF8(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;

        var jsRequest = new Dictionary<string, object>();
        jsRequest["I"] = workflow.fields["I"].ToString();
        jsRequest["B"] = workflow.fields["B"].ToString();
        jsRequest["P"] = false;

        string strJsonResult = O9Utils.GenJsonDataRequest(jsRequest, "FOF_GET_TXBODY");

        if (!string.IsNullOrEmpty(strJsonResult))
        {
            var workflowid = workflow.fields["tran_name"].ToString();
            var workflowDefinition = await _workflowDefinitionService.GetByWorkflowId(workflowid);
            JObject jsResult = JObject.Parse(strJsonResult)["txbody"].ToObject<JObject>();
            var txBodyData = jsResult["TXBODY"] ?? new JObject();
            txBodyData["transaction_number"] = jsResult["TXREFID"].ToString();
            txBodyData["tran_reference"] = workflowid;
            
            var mappingResponse = await _mappingService.MappingResponse(workflowDefinition.MappingResponse, txBodyData);
            TransactionJournalModel journal = jsResult.MapToModel<TransactionJournalModel>();
            var response = JObject.Parse(journal.ToSerialize());
            var resultView = response.ToDictionary().MergeDictionary(mappingResponse.ToDictionary());
            return resultView.BuildWorkflowResponseSuccess(false);
        }

        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SimpleSearch(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        string search_text = workflow.fields["search_text"].ToString() ?? string.Empty;
        var resultSearchAll = await _baseWorkflow.SearchData(workflow, true);
        var data = resultSearchAll["data"];

        if (data is JArray dataSearch)
        {
            var filteredData = dataSearch
                .Where(row => row.Values<string>()
                    .Any(value => value.Contains(search_text, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            JArray resultArray = new JArray(filteredData);

            return resultArray;
        }

        return null;
    }

}
