using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;
using System.Linq;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.Utils;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Core;
using Jits.Neptune.Web.Framework.Models.Extensions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jits.Neptune.Web.CMS.Models.AccountingModels;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Models.AdminModels;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class BaseWorkflowService : IBaseWorkflowService
{
    /// <summary>
    /// The mapping service
    /// </summary>
    private readonly IMappingService _mappingService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mappingService"></param>
    public BaseWorkflowService(IMappingService mappingService)
    {
        _mappingService = mappingService;
        if (Singleton<PagingData>.Instance == null) Singleton<PagingData>.Instance = new PagingData();
    }

    /// <summary>
    /// Searches the workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <param name="isAdvanceSearch">The is advance search</param>
    /// <returns>A task containing the token</returns>
    private async Task<JToken> Search(WorkflowRequestModel workflow, bool isAdvanceSearch = false)
    {
        try
        {
            var pageIndex = workflow.fields["page_index"].ToInt();
            var pageSize = workflow.fields["page_size"].ToInt();
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = await SearchData(workflow, isAdvanceSearch);
            var pageList = result.SelectToken("data").ToPagedList<JObject>(pageIndex, pageSize);

            int totalCount = pageList.TotalCount;

            if (Singleton<PagingData>.Instance == null) Singleton<PagingData>.Instance = new PagingData();

            if (Singleton<PagingData>.Instance.Paging.TryGetValue(workflow.WorkflowFunc, out int total))
            {
                totalCount = total;
            }

            var pageListModel = pageList.ToPageListModel(totalCount);

            var mappingItems =
                await _mappingService.MappingResponse(workflow.MappingResponse, pageListModel.Items.ToJToken());
            pageListModel.Items = mappingItems.ToObject<List<JObject>>();

            return pageListModel.BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <param name="isAdvanceSearch"></param>
    /// <returns></returns>
    public async Task<JToken> SearchData(WorkflowRequestModel workflow, bool isAdvanceSearch = false)
    {
        try
        {
            var searchFunc = O9Utils.SearchFunc(workflow.fields, workflow.WorkflowFunc);

            string strSql;
            if (isAdvanceSearch)
            {
                strSql = searchFunc.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty,
                    true);
            }
            else
            {
                var searchText = workflow.fields["search_text"].ToString();
                strSql = searchFunc.GenSearchCommonSql(searchText, "", EnmOrderTime.InQuery, true);
            }

            var pageIndex = workflow.ObjectField["page_index"]?.ToInt() + 1 ?? 0;
            var pageSize = workflow.ObjectField["page_size"]?.ToInt() ?? 0;
            if (pageSize < 5 || pageSize > 20)
            {
                pageIndex = 0;
            }
            else
            {
                pageIndex = (int)Math.Ceiling((double)(pageIndex * pageSize) / 20);
            }

            var result = O9Utils.Search(strSql, pageIndex, workflow.WorkflowFunc);
            result = searchFunc.SearchData(result);

            return result;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SimpleSearch(WorkflowRequestModel workflow)
    {
        return await Search(workflow, false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> AdvanceSearch(WorkflowRequestModel workflow)
    {
        return await Search(workflow, true);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<JToken> View(WorkflowRequestModel model)
    {
        await Task.CompletedTask;
        try
        {
            JToken response = null;
            var objectGenDataRequest = model.ObjectField;
            string strJsonResult = O9Utils.GenJsonDataRequest(objectGenDataRequest, model.WorkflowFunc);
            if (!string.IsNullOrEmpty(strJsonResult))
            {
                JObject jsResult = JObject.Parse(strJsonResult);

                response = jsResult.BuildWorkflowResponseSuccess();
            }
            else
            {
                "Not found!".BuildWorkflowResponseError();
            }

            return response;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// Rules the func using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <exception cref="Exception"></exception>
    /// <returns>The response</returns>
    public async Task<JToken> RuleFunc(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        try
        {
            var condition =
                workflow.fields.Count(e => e.Key.ToString() != "page_index" && e.Key.ToString() != "page_size") switch
                {
                    0 => null,
                    _ => workflow.fields.Where(e => e.Key.ToString() != "page_index" && e.Key.ToString() != "page_size")
                };

            var result = O9Utils.RuleFunc(workflow.WorkflowFunc, workflow.Module, condition);
            result = await _mappingService.MappingResponse(workflow.MappingResponse, result["data"] ?? result);
            if (workflow.fields.TryGetValue("page_index", out _) && workflow.fields.TryGetValue("page_size", out _))
            {
                var pagedList = result.ToPagedList<JObject>(0, int.MaxValue);
                int totalCount = pagedList.TotalCount;
                if (Singleton<PagingData>.Instance.Paging.TryGetValue(workflow.WorkflowFunc, out int total))
                {
                    totalCount = total;
                }

                result = JToken.FromObject(pagedList.ToPageListModel(totalCount));
            }

            return result.BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }


    /// <summary>
    /// Executes the rule func using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>A task containing the token</returns>
    public async Task<JToken> ExecuteRuleFunc(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        try
        {
            var result = O9Utils.ExecuteRuleFunc(workflow.TxCode, workflow.WorkflowFunc, workflow.ObjectField);
            result = await _mappingService.MappingResponse(workflow.MappingResponse, result["data"] ?? result);
            if (workflow.fields.TryGetValue("page_index", out _) && workflow.fields.TryGetValue("page_size", out _))
            {
                var pagedList = result.ToPagedList<JObject>(0, int.MaxValue);
                int totalCount = pagedList.TotalCount;
                if (Singleton<PagingData>.Instance.Paging.TryGetValue(workflow.WorkflowFunc, out int total))
                {
                    totalCount = total;
                }

                result = JToken.FromObject(pagedList.ToPageListModel(totalCount));
            }

            return result.BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NeptuneException"></exception>
    public async Task<JToken> CreateBO(WorkflowRequestModel workflow)
    {
        try
        {
            JsonTableName clsJson = new();
            JObject jsData = workflow.ObjectField;

            JObject jsRequest = jsData;

            clsJson.TXBODY.Add(new JsonData(workflow.TableName, jsRequest));
            O9Utils.ConsoleWriteLine(clsJson.ToString());

            string result =
                O9Utils.GenJsonBackOfficeRequest(workflow.user_sessions, workflow.WorkflowFunc, clsJson.TXBODY);

            JObject jsResult = O9Utils.AnalysisBOResult(result);

            return jsResult;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }


    /// <summary>
    /// Fronts the office using the specified workflow
    /// </summary>
    /// <param name="workflow">The workflow</param>
    /// <returns>A task containing the token</returns>
    public async Task<JToken> FrontOffice(WorkflowRequestModel workflow)
    {
        try
        {
            await Task.CompletedTask;

            JObject jsRequest = workflow.ObjectField;
            JObject jsFees = null;

            //string internalTxKey = "internalTransaction";
            string approverIdKey = "approverid";
            string approver = null;
            string status = "C";

            if (jsRequest.ContainsKey(approverIdKey))
            {
                int? approverId = jsRequest.Value<int?>(approverIdKey);
                approver = approverId?.ToString();
                if (approverId == -1)
                {
                    status = "P";
                }
            }

            jsRequest = O9Utils.ProcessIfcFees(workflow.WorkflowFunc, jsRequest);

            if (jsRequest.ContainsKey("ifcfees"))
            {
                if (jsRequest.SelectToken("ifcfees").HasValues)
                {
                    jsFees = ((JArray)jsRequest.SelectToken("ifcfees")).ConvertToJArrayDetails();
                }

                jsRequest.Remove("ifcfees");
            }

            string strResult = O9Utils.GenJsonFrontOfficeRequest(
                workflow.user_sessions,
                workflow.WorkflowFunc,
                jsRequest,
                functionId: "",
                isResultCaching: EnmCacheAction.NoCached,
                pstatus: status,
                ptxrefid: null,
                pvaluedt: workflow.StringWorkingDate,
                pifcfee: jsFees
            );

            JsonFrontOffice jsonFrontOffice = O9Utils.AnalysisFrontOfficeResult(strResult);
            //var convert = JsonConvert.DeserializeObject<JsonFrontOfficeResponse>(result);
            //if (convert == null || convert.R > 0)
            //{
            //    var errorMessage = convert == null ? "Null data" : convert.M.ToString();
            //    return errorMessage.BuildWorkflowResponseError();
            //}
            //var jsonFrontOffice = new JsonFrontOffice(JsonConvert.DeserializeObject<JsonFrontOfficeMapping>(convert.M.ToString()!));
            //jsonFrontOffice.RESULT.Add("transaction_number", jsonFrontOffice.TXREFID);

            JObject result = O9Utils.ConvertFOToJObject(jsonFrontOffice);
            var txBodyObject =
                JObject.Parse(
                    (workflow.IsWorkflow
                        ? result["result"]?.ToObject<string>()
                        : result["txbody"]?.ToObject<string>()) ??
                    string.Empty);

            if (result.TryGetValue("txrefid", out JToken refId))
            {
                txBodyObject.Add("transaction_number", refId);
            }

            var txBody = await _mappingService.MappingResponse(workflow.MappingResponse, txBodyObject);

            if (!result.ContainsKey("postings"))
            {
                return txBody.BuildWorkflowResponseSuccess(false);
            }

            List<TemporaryPosting> postings =
                result["postings"]?.ToObject<string>().MapToModel<List<TemporaryPosting>>();
            JObject response = AddEntryJournalsToResponse(txBodyObject, postings);

            return response.BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// Adds the entry journals to response using the specified tx body token
    /// </summary>
    /// <param name="txBodyToken">The tx body token</param>
    /// <param name="postings">The postings</param>
    /// <returns>The response</returns>
    private static JObject AddEntryJournalsToResponse(JObject txBodyToken, List<TemporaryPosting> postings)
    {
        if (txBodyToken == null)
        {
            return null;
        }

        var debits = postings.Where(s => s.action == "D").ToList();
        var credits = postings.Where(s => s.action == "C").ToList();

        JObject response = txBodyToken ?? new JObject();

        response.Add("postings_debit", debits.ToJToken());
        response.Add("postings_credit", credits.ToJToken());

        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> Delete(WorkflowRequestModel model)
    {
        await Task.CompletedTask;
        try
        {
            JObject jsRequest = new JObject();

            JToken token = model.ObjectField.SelectToken("id");
            dynamic id = null;

            if (token != null)
            {
                if (token.Type == JTokenType.Integer)
                {
                    id = token.Value<int>();
                }
                else if (token.Type == JTokenType.String)
                {
                    id = token.Value<string>();
                }
                else if (token.Type == JTokenType.Object)
                {
                    id = token.Value<object>();
                }
            }

            if (model.IdFieldName.ToLower() == "object")
            {
                jsRequest = id;
            }
            else
            {
                jsRequest.Add(model.IdFieldName, id);
            }


            JsonTableName clsJson = new();
            clsJson.TXBODY.Add(new JsonData(model.TableName, jsRequest));

            string result = O9Utils.GenJsonBackOfficeRequest(model.user_sessions, model.WorkflowFunc, clsJson.TXBODY);
            JObject jsResult = O9Utils.AnalysisBOResult(result, null, false);
            //var baseModel = jsResult.ToModel<BaseO9TransactionModel>();

            return jsResult;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<JToken> UpdateBO(WorkflowRequestModel model)
    {
        try
        {
            await Task.CompletedTask;
            JsonTableName clsJson = new JsonTableName();
            JObject jsData = model.ObjectField;
            string id = jsData.SelectToken("id")?.ToObject<string>();
            jsData.Remove("id");
            if (!jsData.ContainsKey(model.IdFieldName))
            {
                if (id.IsNumeric())
                {
                    jsData.Add(model.IdFieldName, int.Parse(id));
                }
                else
                {
                    jsData.Add(model.IdFieldName, id);
                }
            }

            JObject jsRequest = jsData;
            O9Utils.ConsoleWriteLine(jsRequest.ToString());
            object fpk = null;
            if (jsRequest.TryGetValue("FPK", out var fpkValue))
            {
                fpk = fpkValue;
                jsRequest.Remove("FPK");
            }

            clsJson.TXBODY.Add(new JsonData(model.TableName, jsRequest, fpk));

            string result = O9Utils.GenJsonBackOfficeRequest(model.user_sessions, model.WorkflowFunc, clsJson.TXBODY);
            JObject jsResult = O9Utils.AnalysisBOResult(result);
            return jsResult;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SearchList(WorkflowRequestModel workflow)
    {
        await Task.CompletedTask;
        try
        {
            var isSearchAdvance = workflow.ObjectField.TryGetValue("is_advance", out var isAdvanceToken)
                ? isAdvanceToken.ToObject<bool>()
                : false;

            if (workflow.fields.ContainsKey("is_advance"))
                workflow.fields.Remove("is_advance");

            if (workflow.ObjectField.ContainsKey("is_advance"))
                workflow.ObjectField.Remove("is_advance");

            var data = await SearchData(workflow, isSearchAdvance);

            if (data["data"] != null)
                return data["data"].BuildWorkflowResponseSuccess(true);
            else
                throw new Exception("Data is invalid");
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> SearchInfo(WorkflowRequestModel workflow)
    {
        try
        {
            var id = workflow.ObjectField.GetValue("id");
            workflow.ObjectField.Remove("id");
            workflow.fields.Remove("id");

            var data = await SearchList(workflow);
            var listData = data?["result"]?.ToObject<List<JObject>>();

            JToken response = null;
            if (id != null)
            {
                response = listData?.FirstOrDefault(item =>
                    item.GetValue(workflow.IdFieldName.ToLower())?.ToString() == id.ToString());
            }
            else
            {
                response = listData?.FirstOrDefault();
            }

            return response?.BuildWorkflowResponseSuccess() ??
                   $"[{workflow.workflowid}] - Data not found!".BuildWorkflowResponseError();
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }
}