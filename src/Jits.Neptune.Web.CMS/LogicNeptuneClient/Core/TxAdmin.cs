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
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.NcbsCbs.Core;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxAdmin
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
    private readonly IAdminGrpcService _adminGrpcService;
    private readonly IPostAPIService _postApiService;
    private readonly IAuthenticationGrpcService _authenticationGrpcService;
    private readonly IO9PostService _o9PostService;
    private readonly IFormService _formService;

    /// <summary>
    ///Tx
    /// </summary>

    public TxAdmin(IFormService formService,IFoService foService, IAppService appService, 
    ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, 
    IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService,
    IO9PostService o9PostService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _postApiService = postAPIService;
        _formService = formService;
        _o9PostService = o9PostService;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> search()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string tableCode = "";
        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new"))
        {
            JObject idInput = new JObject();
            JObject execution = new JObject();
            int pageSize = 5;
            int pageIndex = 0;
            string searchText = "";
            // JObject tableSearch = new JObject();

            if (boInput.ContainsKey("table_search"))
            {
                var tableSearch = JObject.FromObject(boInput["table_search"]);
                if (tableSearch.ContainsKey("paging"))
                {
                    var paging = JObject.FromObject(tableSearch["paging"]);
                    if (paging.ContainsKey("recordItem") && paging.ContainsKey("pagingIndex"))
                    {
                        pageSize = Int32.Parse(paging["recordItem"].ToString());
                        pageIndex = Int32.Parse(paging["pagingIndex"].ToString()) - 1;
                    }
                }
            }

            if (boInput.ContainsKey(tableCode))
            {
                if (JObject.FromObject(boInput[tableCode]).ContainsKey("search_text"))
                    searchText = JObject.FromObject(boInput[tableCode])["search_text"].ToString();
            }

            idInput.Add(new JProperty("page_size", pageSize));
            idInput.Add(new JProperty("page_index", pageIndex));
            idInput.Add(new JProperty("search_text", searchText));

            execution.Add(new JProperty("fields", idInput));
            execution.Add(new JProperty("workflowid", boInput["workflow_id"].ToString()));
            execution.Add(new JProperty("lang",context.InfoUser.GetUserLogin().Lang));
            context.Bo.GetBoInput()["execution"] = execution;

            var obData = await executeWorkflow();
            var obDataModel = new PageSearchModel()
            {
                Items = obData.SelectToken("items").ToList<object>(),
                TotalCount = Int32.Parse(obData.SelectToken("total_count").ToString()),
                TotalPages = Int32.Parse(obData.SelectToken("total_pages").ToString())
            };

            if (obDataModel == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
            context.Bo.AddPackFo(tableCode, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), tableCode));

            JObject obPaging = new JObject();
            obPaging.Add(new JProperty("total_items", obDataModel.TotalCount));
            obPaging.Add(new JProperty("search_advanced", "false"));

            context.Bo.AddPackFo("table_paging", obPaging);

            JObject obErr_ = new JObject();
            obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr_);

            if (obDataModel.TotalCount == 0) return "empty";

            return "true";


        }
        return "false";
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> searchAdvanced()
    {

        var infoUserLogin = context.InfoUser.GetUserLogin();
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string tableCode = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("table_code"))
            tableCode = boInput.GetValue("table_code").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        if (learnApi.Equals("ncbsCBS_workflow_execute_new") || learnApi.Equals("ncbsCBS_workflow_get_execution_info_new"))
        {
            Dictionary<string, object> idInput = new Dictionary<string, object>();
            WorkflowExecuteModel execution = new WorkflowExecuteModel();
            int pageSize = 5;
            int pageIndex = 0;


            if (boInput.ContainsKey("table_search"))
            {
                var tableSearch = JObject.FromObject(boInput["table_search"]);
                if (tableSearch.ContainsKey("paging"))
                {
                    var paging = JObject.FromObject(tableSearch["paging"]);
                    if (paging.ContainsKey("recordItem") && paging.ContainsKey("pagingIndex"))
                    {
                        pageSize = Int32.Parse(paging["recordItem"].ToString());
                        pageIndex = Int32.Parse(paging["pagingIndex"].ToString()) - 1;
                    }
                }
            }

            if (boInput.ContainsKey(tableCode))
            {

                var tableCodeSearch = JObject.FromObject(boInput).SelectToken(tableCode).ToObject<JObject>();

                if (tableCodeSearch.ContainsKey("learn_api_mapping"))
                {

                    var learnApiMapping = tableCodeSearch["learn_api_mapping"].ToString();

                    if (boInput.ContainsKey("table_code_replace"))
                    {
                        learnApiMapping = learnApiMapping.Replace(boInput["table_code_replace"].ToString(), tableCode);
                    }


                    idInput = (await _postApiService.TxMapDataBody(learnApiMapping, boInput, context.InfoApp.GetApp())).ToDictionary();

                }
                else
                {
                    foreach (var (key, value) in tableCodeSearch.ToDictionary())
                    {
                        idInput[key] = value;
                    }
                }
            }
            idInput.Add("page_index", pageIndex);
            idInput.Add("page_size", pageSize);

            execution.fields = idInput;
            execution.workflowid = boInput["workflow_id"].ToString();
            execution.lang = context.InfoUser.GetUserLogin().Lang;
            execution.reference_id=System.Guid.NewGuid().ToString();
            context.Bo.GetBoInput()["execution"] = JToken.FromObject(execution);

            var obData = await executeWorkflow();
            var obDataModel = new PageSearchModel()
            {
                Items = obData.SelectToken("items").ToList<object>(),
                TotalCount = Int32.Parse(obData.SelectToken("total_count").ToString()),
                TotalPages = Int32.Parse(obData.SelectToken("total_pages").ToString()),
                HasPreviousPage = (bool)obData.SelectToken("has_previous_page"),
                HasNextPage = (bool)obData.SelectToken("has_next_page"),

            };

            if (boInput.ContainsKey("api_map_code"))
                tableCode = boInput["api_map_code"].ToString();
            if (obDataModel == null)
            {
                JObject obErr = new JObject();
                obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
                context.Bo.AddPackFo("errorJWebUI", obErr);
                return "false";
            }
            context.Bo.AddPackFo(tableCode, BuildTableCodeForArray(JArray.FromObject(obDataModel.Items), tableCode));

            JObject obPaging = new JObject();
            obPaging.Add(new JProperty("total_items", obDataModel.TotalCount));
            obPaging.Add(new JProperty("search_advanced", "true"));

            context.Bo.AddPackFo("table_paging", obPaging);

            JObject obErr_ = new JObject();
            obErr_.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr_);

            if (obDataModel.TotalCount == 0) return "empty";
            return "true";


        }
        return "false";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> view()
    {
        var boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        string formSearchKey = "";
        WorkflowExecuteModel execution = new WorkflowExecuteModel();
        Dictionary<string, object> idInput = new Dictionary<string, object>();

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("form_search_key"))
            formSearchKey = boInput.GetValue("form_search_key").ToString();

        context.Bo.GetBoInput()["learn_api"] = learnApi;

        if (boInput.ContainsKey(formSearchKey))
        {
            if (boInput.ContainsKey("view_id"))
            {
                var tableCodeSearch = boInput[formSearchKey];
                foreach (var (key, value) in tableCodeSearch.ToDictionary())
                {
                    if (key.Equals(boInput["view_id"])) idInput[key] = value;
                }
            }
        }

        execution.fields = idInput;
        execution.workflowid = boInput["workflow_id"].ToString();
        execution.lang = context.InfoUser.GetUserLogin().Lang;
        execution.reference_id= System.Guid.NewGuid().ToString();
        context.Bo.GetBoInput()["execution"] = JToken.FromObject(execution);

        var obData = await executeWorkflow();

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("form_key"))
            context.Bo.GetActionInput().Add("form_key", boInput["form_key"].ToString());

        if (boInput.ContainsKey("table_code"))
            context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());


        JObject obItem = new JObject();
        obItem.Add(boInput["table_code"].ToString(), obData);

        context.Bo.AddPackFo(boInput["table_code"].ToString(), obItem);

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
        context.Bo.GetBoInput()["learn_api"] = "ncbsCBS_workflow_execute_new";

        JToken rs = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            rs = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "search",
                context
            );
        }
        else
        {
            rs = await _postApiService.GetDataPostAPI("ncbsCbs", "executeWorkflow", context);
        }
        return rs;
    }

    private JArray BuildTableCodeForArray(JArray arr, string tableCode)
    {
        JArray arrRes = new JArray();
        foreach (var itemArr in arr)
        {
            JObject obj = new JObject();
            obj.Add(new JProperty(tableCode, itemArr));
            arrRes.Add(obj);
        }
        return arrRes;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> getFormFo()
    {
        var getAllForm = await _formService.GetByApp("ncbsCbs");
        var listFormFo=new List<FormFOModel>();
                if (getAllForm != null)
                {
                    foreach (var form_ in getAllForm)
                    {
                        var infoForm_ = form_.Info;
                        var listLayout = form_.ListLayout.ToJArray();
                        if(infoForm_.Form_Code.IndexOf("FO_")==0 && infoForm_.Form_Code.Split("_").Length==3 && infoForm_.Form_Code[infoForm_.Form_Code.Length - 1] != char.ToLower(infoForm_.Form_Code[infoForm_.Form_Code.Length - 1]))
                        {
                            bool has_fee=false;
                            string fee_status="Form hasn't Fee";
                            for (int i_l = 0; i_l < listLayout.Count; i_l++)
                            {
                                var listView=listLayout[i_l]["list_view"].ToJArray();
                                for (int i_v = 0; i_v < listView.Count; i_v++)
                                {
                                    var listInput=listView[i_v]["list_input"].ToJArray();
                                    for (int i_i = 0; i_i < listInput.Count; i_i++)
                                    {
                                        var component=listInput[i_i];
                                        if(component["inputtype"].ToString() == "jSameMain" && component["default"]["code"].ToString() == "form_fee"){
                                            has_fee=true;
                                            fee_status="Active";
                                            break;
                                        }
                                    }
                                }
                            }
                            if(has_fee)
                            {
                                var listRuleStrong=infoForm_.Rulestrong.ToJArray();
                                for (int i = 0; i < listRuleStrong.Count; i++)
                                {
                                    if(listRuleStrong[i]["code"].ToString()=="visibility")
                                    {
                                        var config=listRuleStrong[i]["config"];
                                        if(config.SelectToken("component_result").ToString().IndexOf("form_fee")>-1 && config.SelectToken("component_action").ToString()==""){
                                            if(config.SelectToken("visible").ToString()=="false") fee_status="Inactive";
                                            else fee_status="Active";
                                            break;
                                        }
                                    }
                                }
                            }

                            listFormFo.Add(new FormFOModel(){
                                Info=infoForm_,
                                HasFee=has_fee,
                                ReactTxt=form_.ReactTxt,
                                FormId=form_.FormId,
                                FormTitle=infoForm_.Title,
                                App="ncbsCbs",
                                FeeStatus=fee_status
                            });
                        }
                    }
                    context.Bo.AddPackFo("list_form_fo",BuildTableCodeForArray(listFormFo.ToJArray(),"list_form_fo") );
                     return "true";
                }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> setStatusFee()
    {
        var boInput = context?.Bo?.GetBoInput();
        var form_config=boInput["list_form_fo"];
        var findForm = await _formService.GetByIdAndApp(form_config["form_id"].ToString(),"ncbsCbs");
        if (findForm != null)
        {
            var newInfoForm=findForm.Info;
            var has_rule=false;
            var newListRuleStrong=newInfoForm.Rulestrong.ToJArray();
            for (int i = 0; i < newListRuleStrong.Count; i++)
            {
                if(newListRuleStrong[i]["code"].ToString()=="visibility")
                {
                    var newConfig=newListRuleStrong[i]["config"];
                    if(newConfig.SelectToken("component_result").ToString().IndexOf("form_fee")>-1&& newConfig.SelectToken("component_action").ToString()==""){
                        has_rule=true;
                        newListRuleStrong[i]["config"]["visible"]=boInput["status"].ToString()=="Active"?"true":"false";
                        
                        break;

                    }

                }
            }
            if(!has_rule){
                var config_rule=new JObject();
                config_rule["component_action"]="";
                config_rule["component_result"]="form_fee;form_fee()";
                config_rule["view_result"]="";
                config_rule["condition"]="";
                config_rule["visible"]=boInput["status"].ToString()=="Active"?"true":"false";
                config_rule["ena_dis"]="not_use"; 
                 config_rule["component_event"]="all"; 
                  config_rule["list_config"]=new JArray(); 
                var newRule=new RuleStrong(){
                    Code="visibility",
                    InUse=true,
                    IsStart=true,
                    IsStatus="-1",
                    Order=1,
                    IsDidStart=false,
                    Config=config_rule.ToDictionary()
                };
               
               newListRuleStrong.Add(newRule.ToJObject());
            }
            newInfoForm.Rulestrong=newListRuleStrong;
            await _formService.Update(new Jits.Neptune.Web.CMS.Domain.Form(){
                Id=findForm.Id,
                App="ncbsCbs",
                FormId=form_config["form_id"].ToString(),
                ReactTxt=findForm.ReactTxt,
                Info=JsonConvert.SerializeObject(newInfoForm),
                ListLayout=JsonConvert.SerializeObject(findForm.ListLayout)
            });
        }
                        // else await _formService.Insert(formSave_);
        var getAllForm = await _formService.GetByApp("ncbsCbs");
        var listFormFo=new List<FormFOModel>();
                if (getAllForm != null)
                {
                    foreach (var form_ in getAllForm)
                    {
                        var infoForm_ = form_.Info;
                        var listLayout = form_.ListLayout.ToJArray();
                        if(infoForm_.Form_Code.IndexOf("FO_")==0 && infoForm_.Form_Code.Split("_").Length==3 && infoForm_.Form_Code[infoForm_.Form_Code.Length - 1] != char.ToLower(infoForm_.Form_Code[infoForm_.Form_Code.Length - 1]))
                        {
                            bool has_fee=false;
                            string fee_status="Form hasn't Fee";
                            for (int i_l = 0; i_l < listLayout.Count; i_l++)
                            {
                                var listView=listLayout[i_l]["list_view"].ToJArray();
                                for (int i_v = 0; i_v < listView.Count; i_v++)
                                {
                                    var listInput=listView[i_v]["list_input"].ToJArray();
                                    for (int i_i = 0; i_i < listInput.Count; i_i++)
                                    {
                                        var component=listInput[i_i];
                                        if(component["inputtype"].ToString() == "jSameMain" && component["default"]["code"].ToString() == "form_fee"){
                                            has_fee=true;
                                            fee_status="Active";
                                            break;
                                        }
                                    }
                                }
                            }
                            if(has_fee)
                            {
                                var listRuleStrong=infoForm_.Rulestrong.ToJArray();
                                for (int i = 0; i < listRuleStrong.Count; i++)
                                {
                                    if(listRuleStrong[i]["code"].ToString()=="visibility")
                                    {
                                        var config=listRuleStrong[i]["config"];
                                        if(config.SelectToken("component_result").ToString().IndexOf("form_fee")>-1&& config.SelectToken("component_action").ToString()==""){
                                            if(config.SelectToken("visible").ToString()=="false") fee_status="Inactive";
                                            else fee_status="Active";
                                            break;
                                        }

                                    }
                                }
                            }

                            listFormFo.Add(new FormFOModel(){
                                Info=infoForm_,
                                HasFee=has_fee,
                                ReactTxt=form_.ReactTxt,
                                FormId=form_.FormId,
                                FormTitle=infoForm_.Title,
                                App="ncbsCbs",
                                FeeStatus=fee_status
                            });
                        }
                    }
                    context.Bo.AddPackFo("list_form_fo",BuildTableCodeForArray(listFormFo.ToJArray(),"list_form_fo") );
                     return "true";
                }
        return "false";
    }

}
