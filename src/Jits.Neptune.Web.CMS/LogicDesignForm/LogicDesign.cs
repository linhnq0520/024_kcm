using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Design.Form;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class LogicDesign
{
    /// <summary>
    ///context
    /// </summary>
    [JwebuiContextAttribute]
    public JWebUIObjectContextModel context { get; set; }
    private readonly IAppService _appService;
    private readonly IFoService _foService;
    private readonly ILangService _langService;
    private readonly IParaServerService _paraServerService;
    private readonly IReportGrpcService _reportGrpcService;
    private readonly IDesignItemService _designItemService;
    private readonly IDesignTemplateFormService _designTemplateFormService;
    private readonly IDesignGroupService _designGroupService;
    private readonly IFormService _formService;
    private readonly ILearnApiService _learnApiService;
    private readonly ICdlistService _cdlistService;
    private readonly IMemoryCache _cache;

    /// <summary>
    ///Tx
    /// </summary>

    public LogicDesign(ILearnApiService learnApiService, IDesignTemplateFormService designTemplateFormService, IFoService foService, IReportGrpcService reportGrpcService, IAppService appService, ILangService langService, IParaServerService paraServerService, IDesignItemService designItemService, IDesignGroupService designGroupService, IFormService formService, ICdlistService cdlistService, IMemoryCache cache)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();

        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _designItemService = designItemService;
        _designTemplateFormService = designTemplateFormService;
        _designGroupService = designGroupService;
        _formService = formService;
        _cdlistService = cdlistService;
        _reportGrpcService = reportGrpcService;
        _learnApiService = learnApiService;
        _cache = cache;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> getAll()
    {
        List<ListAppInDesignForm> listApp = new List<ListAppInDesignForm>();
        List<ListFormInDesignForm> listForm = new List<ListFormInDesignForm>();
        List<ListDesignGroupInDesignForm> listDesignGroup = new List<ListDesignGroupInDesignForm>();
        List<ListDesignItemInDesignForm> listDesignItem = new List<ListDesignItemInDesignForm>();
        List<ListDesignTemplateFormInDesignForm> listDesignTemplateForm = new List<ListDesignTemplateFormInDesignForm>();

        var getAllApp = await GetOrCreateAsync("allApps", () => _appService.GetAll());
        if (getAllApp != null)
        {
            foreach (var itemApp in getAllApp)
            {
                listApp.Add(new ListAppInDesignForm() { App = itemApp.ListApplicationId });

                var getAllForm = await GetOrCreateAsync($"forms_{itemApp.ListApplicationId}", () => _formService.GetByApp(itemApp.ListApplicationId));
                if (getAllForm != null)
                {
                    foreach (var item in getAllForm)
                    {
                        var infoForm_ = item.Info;
                        infoForm_.App = item.App;
                        listForm.Add(new ListFormInDesignForm() { DESIGNFORM_CODE_DATABASE = new InfoFormInDesignForm() { Info = infoForm_ } });
                    }
                }
            }
        }

        var getAllDesignGroup = await GetOrCreateAsync("allDesignGroups", () => _designGroupService.GetAll());
        if (getAllDesignGroup != null)
        {
            foreach (var itemDesignGroup in getAllDesignGroup)
            {
                listDesignGroup.Add(new ListDesignGroupInDesignForm() { DESIGNFORM_CODE_TOOL_GROUPS = itemDesignGroup });
            }
        }

        var getAllDesignItem = await GetOrCreateAsync("allDesignItems", () => _designItemService.GetAll());
        if (getAllDesignItem != null)
        {
            foreach (var itemDesignItem in getAllDesignItem)
            {
                listDesignItem.Add(new ListDesignItemInDesignForm() { DESIGNFORM_CODE_TOOL_ITEMS = itemDesignItem });
            }
        }

        var getAllDesignTemplateForm = await GetOrCreateAsync("allDesignTemplateForms", () => _designTemplateFormService.GetAll());
        if (getAllDesignTemplateForm != null)
        {
            foreach (var itemDesignTemplateForm in getAllDesignTemplateForm)
            {
                listDesignTemplateForm.Add(new ListDesignTemplateFormInDesignForm() { DESIGNFORM_CODE_FORM_TEMPLATE = itemDesignTemplateForm });
            }
        }

        context.Bo.AddPackFo("list_form", listForm);
        context.Bo.AddPackFo("list_app", listApp);
        context.Bo.AddPackFo("list_design_tool_group", listDesignGroup);
        context.Bo.AddPackFo("list_design_tool_item", listDesignItem);
        context.Bo.AddPackFo("list_form_template", listDesignTemplateForm);

        return "true";
    }

    private async Task<T> GetOrCreateAsync<T>(string cacheKey, Func<Task<T>> factory)
    {
        if (!_cache.TryGetValue(cacheKey, out T cacheEntry))
        {
            cacheEntry = await factory();
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60), // Cache trong 60 phút
                SlidingExpiration = TimeSpan.FromMinutes(10) // Làm mới cache nếu được truy cập
            };

            _cache.Set(cacheKey, cacheEntry, cacheEntryOptions);
        }

        return cacheEntry;
    }


    // public async Task<string> getAll()
    // {

    //     List<ListAppInDesignForm> listApp = new List<ListAppInDesignForm>();
    //     List<ListFormInDesignForm> listForm = new List<ListFormInDesignForm>();
    //     List<ListDesignGroupInDesignForm> listDesignGroup = new List<ListDesignGroupInDesignForm>();
    //     List<ListDesignItemInDesignForm> listDesignItem = new List<ListDesignItemInDesignForm>();

    //     List<ListDesignTemplateFormInDesignForm> listDesignTemplateForm = new List<ListDesignTemplateFormInDesignForm>();

    //     var getAllApp = await _appService.GetAll();
    //     if (getAllApp != null)
    //     {
    //         foreach (var itemApp in getAllApp)
    //         {

    //             listApp.Add(new ListAppInDesignForm() { App = itemApp.ListApplicationId });
    //             //get form in app
    //             var getAllForm = await _formService.GetByApp(itemApp.ListApplicationId);
    //             if (getAllForm != null)
    //             {
    //                 foreach (var item in getAllForm)
    //                 {
    //                     var infoForm_ = item.Info;
    //                     infoForm_.App = item.App;
    //                     listForm.Add(new ListFormInDesignForm() { DESIGNFORM_CODE_DATABASE = new InfoFormInDesignForm() { Info = infoForm_ } });
    //                 }
    //             }
    //         }
    //     }

    //     var getAllDesignGroup = await _designGroupService.GetAll();
    //     if (getAllDesignGroup != null)
    //     {
    //         foreach (var itemDesignGroup in getAllDesignGroup)
    //         {

    //             listDesignGroup.Add(new ListDesignGroupInDesignForm() { DESIGNFORM_CODE_TOOL_GROUPS = itemDesignGroup });

    //         }
    //     }
    //     var getAllDesignItem = await _designItemService.GetAll();
    //     if (getAllDesignItem != null)
    //     {
    //         foreach (var itemDesignItem in getAllDesignItem)
    //         {

    //             listDesignItem.Add(new ListDesignItemInDesignForm() { DESIGNFORM_CODE_TOOL_ITEMS = itemDesignItem });
    //         }
    //     }

    //     var getAllDesignTemplateForm = await _designTemplateFormService.GetAll();
    //     if (getAllDesignTemplateForm != null)
    //     {
    //         foreach (var itemDesignTemplateForm in getAllDesignTemplateForm)
    //         {

    //             listDesignTemplateForm.Add(new ListDesignTemplateFormInDesignForm() { DESIGNFORM_CODE_FORM_TEMPLATE = itemDesignTemplateForm });
    //         }

    //     }

    //     context.Bo.AddPackFo<List<ListFormInDesignForm>>("list_form", listForm);
    //     context.Bo.AddPackFo<List<ListAppInDesignForm>>("list_app", listApp);
    //     context.Bo.AddPackFo<List<ListDesignGroupInDesignForm>>("list_design_tool_group", listDesignGroup);
    //     context.Bo.AddPackFo<List<ListDesignItemInDesignForm>>("list_design_tool_item", listDesignItem);
    //     context.Bo.AddPackFo<List<ListDesignTemplateFormInDesignForm>>("list_form_template", listDesignTemplateForm);
    //     //context.Bo.AddPackFo("list_form_template", getAllDesignTemplateForm);
    //     return "true";

    // }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> getAllReport()
    {
        await Task.CompletedTask;
        //var getAllReport = await _reportGrpcService.GetAllTemplateReport();
        //System.Console.WriteLine("getAllReport==" + getAllReport.Count);
        //context.Bo.AddPackFo("list_report", getAllReport);
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> save()
    {
        var boInput = context.Bo.GetBoInput();
        string appCode = "";
        string formId = "";
        if (boInput.ContainsKey("dataItem"))
        {
            var dataItem = boInput["dataItem"];
            if (dataItem["key_form"] != null && dataItem["newForm_Data"] != null && dataItem["app_code"] != null)
            {
                appCode = dataItem["app_code"].ToString();
                formId = dataItem["key_form"].ToString();
                var newFormData = dataItem["newForm_Data"].ToJObject();
                if (newFormData["designForm"] != null)
                {
                    var formSave = newFormData["designForm"].ToJObject();

                    if (formSave != null)
                    {
                        var formSave_ = new Jits.Neptune.Web.CMS.Domain.Form()
                        {
                            Info = JsonConvert.SerializeObject(formSave["info"]),
                            ListLayout = JsonConvert.SerializeObject(formSave["list_layout"]),
                            FormId = formId,
                            App = appCode
                        };
                        var findForm = await _formService.GetByIdAndApp(formId, appCode);
                        if (findForm != null)
                        {
                            formSave_.Id = findForm.Id;
                            await _formService.Update(formSave_);
                        }
                        else await _formService.Insert(formSave_);
                        JObject resultFinal = new JObject();
                        resultFinal["error_code"] = "NOT_ERROR";
                        resultFinal["status"] = true;
                        context.Bo.AddPackFo("result", resultFinal);
                        return "true";
                    }
                }
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> addFeeConfig()
    {
        var boInput = context.Bo.GetBoInput();
        string appCode = "";

        if (boInput.ContainsKey("list_form") && boInput.ContainsKey("list_learn_api"))
        {
            if (boInput["list_form"] != null && boInput["list_learn_api"] != null)
            {
                var list_form = boInput["list_form"].ToJArray();
                var list_learn_api = boInput["list_learn_api"].ToJArray();
                appCode = boInput["app_code"].ToString();
                var learn_api_accept_id = boInput["learn_api_accept_id"].ToString();
                var mapping_fee = boInput["mapping_fee"].ToJObject();
                for (var i = 0; i < list_form.Count; i++)
                {
                    var formSave = list_form[i].ToJObject();

                    if (formSave != null)
                    {
                        string formId = formSave["form_id"].ToString();
                        var formSave_ = new Jits.Neptune.Web.CMS.Domain.Form()
                        {
                            Info = JsonConvert.SerializeObject(formSave["info"]),
                            ListLayout = JsonConvert.SerializeObject(formSave["list_layout"]),
                            FormId = formId,
                            App = appCode
                        };
                        var findForm = await _formService.GetByIdAndApp(formId, appCode);
                        if (findForm != null)
                        {
                            formSave_.Id = findForm.Id;
                            await _formService.Update(formSave_);
                        }
                        else await _formService.Insert(formSave_);
                        // JObject resultFinal = new JObject();
                        // resultFinal["error_code"] = "NOT_ERROR";
                        // resultFinal["status"] = true;
                        // context.Bo.AddPackFo("result", resultFinal);
                        // return "true";
                    }
                }
                for (var i = 0; i < list_learn_api.Count; i++)
                {
                    var learn_api = list_learn_api[i].ToJObject();

                    if (learn_api != null)
                    {
                        string learnApiId = learn_api["LearnApiId"].ToString();
                        var learnApiSave_ = new Jits.Neptune.Web.CMS.Domain.LearnApi()
                        {

                            LearnApiId = learn_api["LearnApiId"].ToString(),
                            LearnApiName = learn_api["LearnApiName"].ToString(),
                            LearnApiLink = learn_api["LearnApiLink"].ToString(),
                            LearnApiData = learn_api["LearnApiData"].ToString(),
                            LearnApiNodeData = learn_api["LearnApiNodeData"].ToString(),
                            LearnApiApp = learn_api["LearnApiApp"].ToString(),
                            LearnApiMethod = learn_api["LearnApiMethod"].ToString(),
                            FlowApi = learn_api["FlowApi"].ToString(),
                            SaveTo = learn_api["SaveTo"].ToString(),
                            LearnApiHeader = learn_api["LearnApiHeader"].ToString(),
                            LearnApiMapping = learn_api["LearnApiMapping"].ToString(),
                            NumberOfSteps = learn_api["NumberOfSteps"].ToString(),
                            LearnApiGetInfo = learn_api["LearnApiGetInfo"].ToString(),
                            KeyReadData = learn_api["KeyReadData"].ToString(),
                            JwebuiUsercreate = null,
                            App = appCode
                        };
                        var findLearnApi = await _learnApiService.GetByAppAndId(appCode, learnApiId);
                        if (findLearnApi != null)
                        {
                            learnApiSave_.Id = findLearnApi.Id;
                            await _learnApiService.Update(learnApiSave_);
                        }
                        else await _learnApiService.Insert(learnApiSave_);
                        // JObject resultFinal = new JObject();
                        // resultFinal["error_code"] = "NOT_ERROR";
                        // resultFinal["status"] = true;
                        // context.Bo.AddPackFo("result", resultFinal);
                        // return "true";
                    }
                }
                var findLearnApiAccept = await _learnApiService.GetByAppAndId(appCode, learn_api_accept_id);
                if (findLearnApiAccept != null)
                {
                    //var new_data = new object();
                    var mappingLearnApi = JObject.Parse(findLearnApiAccept.LearnApiMapping);
                    var fields = mappingLearnApi.GetValue("fields");
                    fields = JObject.FromObject(Utils.Utils.MergeDictionary(fields.ToDictionary(), mapping_fee.ToDictionary()));
                    mappingLearnApi["fields"] = fields;
                    var learnApiAccept_ = new Jits.Neptune.Web.CMS.Domain.LearnApi()
                    {
                        Id = findLearnApiAccept.Id,
                        LearnApiId = findLearnApiAccept.LearnApiId,
                        LearnApiName = findLearnApiAccept.LearnApiName,
                        LearnApiLink = findLearnApiAccept.LearnApiLink,
                        LearnApiData = findLearnApiAccept.LearnApiData,
                        LearnApiNodeData = findLearnApiAccept.LearnApiNodeData,
                        LearnApiApp = findLearnApiAccept.LearnApiApp,
                        LearnApiMethod = findLearnApiAccept.LearnApiMethod,
                        FlowApi = findLearnApiAccept.FlowApi,
                        SaveTo = findLearnApiAccept.SaveTo,
                        LearnApiHeader = findLearnApiAccept.LearnApiHeader,
                        LearnApiMapping = mappingLearnApi.ToSerialize(),
                        NumberOfSteps = findLearnApiAccept.NumberOfSteps,
                        LearnApiGetInfo = findLearnApiAccept.LearnApiGetInfo,
                        KeyReadData = findLearnApiAccept.KeyReadData,
                        JwebuiUsercreate = null,
                        App = appCode
                    };
                    await _learnApiService.Update(learnApiAccept_);
                }
                JObject resultFinal = new JObject();
                resultFinal["error_code"] = "NOT_ERROR";
                resultFinal["status"] = true;
                context.Bo.AddPackFo("result", resultFinal);
                return "true";
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> saveDuplicate()
    {

        var boInput = context.Bo.GetBoInput();
        FormModel formSave = new FormModel();
        if (boInput.ContainsKey("dataItem"))
        {
            var dataItem = boInput["dataItem"];
            var saveDupModel = dataItem.ToObject<SaveDuplicateFormModel>();

            if (saveDupModel != null && dataItem["newForm_data"] != null)
            {
                var newFormData = dataItem["newForm_data"].ToJObject();
                var oldForm = await _formService.GetByIdAndApp(saveDupModel.old_key_form, saveDupModel.old_app);
                if (newFormData["designForm"] != null && oldForm != null)
                {
                    formSave = newFormData["designForm"].ToObject<FormModel>();
                    formSave.ListLayout = oldForm.ListLayout;
                    formSave.App = saveDupModel.app_code;
                    formSave.FormId = saveDupModel.new_key_form;
                    if (formSave != null)
                    {
                        var formSave_ = new Jits.Neptune.Web.CMS.Domain.Form()
                        {
                            App = saveDupModel.app_code,
                            FormId = saveDupModel.new_key_form,
                            Info = JsonConvert.SerializeObject(formSave.Info),
                            ListLayout = JsonConvert.SerializeObject(formSave.ListLayout)
                        };
                        await _formService.Insert(formSave_);

                        JObject resultFinal = new JObject();
                        resultFinal["error_code"] = "NOT_ERROR";
                        resultFinal["status"] = true;
                        context.Bo.AddPackFo("result", resultFinal);
                        return "true";
                    }
                }
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> loadDataForm()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput.ContainsKey("dataItem"))
        {
            var dataItem = boInput["dataItem"];
            if (dataItem["key_form"] != null && dataItem["app_code"] != null)
            {
                var formModel_ = await _formService.GetByIdAndApp(dataItem["key_form"].ToString(), dataItem["app_code"].ToString());
                if (formModel_ != null)
                {
                    var itemForm = formModel_;
                    itemForm.Info.App = dataItem["app_code"].ToString();
                    var itemReturn = new ListLoadDataForm()
                    {
                        DataForm = new DataFormModel()
                        {
                            formModel = itemForm
                        },
                        Status = true,
                        error_code = "NOT_ERROR"
                    };

                    context.Bo.AddPackFo<ListLoadDataForm>("result", itemReturn);
                    return "true";
                }
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> loadcdlist()
    {

        var boInput = context.Bo.GetBoInput();
        if (boInput.ContainsKey("dataItem"))
        {
            var dataItem = boInput["dataItem"];
            if (dataItem["app"] != null)
            {
                var getCdlist = await _cdlistService.GetByApp(dataItem["app"].ToString());
                if (getCdlist != null)
                {
                    var listCdlistRs = new List<CdlistDesignFormResponse>();
                    foreach (var itemCdlist in getCdlist)
                    {
                        listCdlistRs.Add(new CdlistDesignFormResponse()
                        {
                            cdlists = itemCdlist
                        });
                    }
                    var resultFinal = new ListCdlistDesignForm()
                    {
                        cdlistsResponse = listCdlistRs,
                        Status = true
                    };
                    context.Bo.AddPackFo<ListCdlistDesignForm>("result", resultFinal);
                    return "true";
                }
            }
        }
        return "false";
    }

}
