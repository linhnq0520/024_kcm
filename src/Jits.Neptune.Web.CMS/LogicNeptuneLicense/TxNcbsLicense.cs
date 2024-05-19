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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.NcbsLicense.Core;

/// <summary>
/// Tx
/// </summary>
[JwebuiClassAttribute]
public class TxNcbsLicense
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
    private readonly ICdlistService _cdlistService;
    private readonly ILearnApiService _learnApiService;
    private readonly IMediaUploadService _mediaUploadService;

    private readonly IWebSocketsService _webSocketsService;

    private readonly ILogServiceService _logServiceService;


    /// <summary>
    ///Tx
    /// </summary>

    public TxNcbsLicense(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, ICdlistService cdlistService, ILearnApiService learnApiService, IMediaUploadService mediaUploadService, IWebSocketsService webSocketsService, ILogServiceService logServiceService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _postApiService = postAPIService;
        _cdlistService = cdlistService;
        _learnApiService = learnApiService;
        _mediaUploadService = mediaUploadService;
        _webSocketsService = webSocketsService;
        _logServiceService = logServiceService;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>
    /// <returns>Task&lt;string&gt;.</returns>
    [JwebuiFunctionAttribute]
    public async Task<string> search()
    {
        var boInput = context?.Bo?.GetBoInput();

        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var searchRequest = new SearchPortalRequestModel()
        {
            key_table_paging = boInput["key_table_paging"]?.ToString(),
            search_advanced = boInput[propertyName: "search_advanced"]?.ToString()
        };
        if (searchRequest == null) return "false";
        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "Search", context);


        if (obData != null)
        {
            var searchResponse = obData.ToSearchResponsePortalModel();

            if (searchResponse == null)
            {
                BuildStatusErrorResponse();
                return "false";
            }

            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);

            if (!learnApiContent.LearnApiData.Equals(""))
            {
                if (Utils.Utils.IsValidJsonArray(searchResponse.results.ToSerialize()))
                {
                    context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(searchResponse.results.ToJArray(), learnApiContent.LearnApiData));

                    var searchResponseCMS = new SearchResponseCMSModel()
                    {
                        search_advanced = searchRequest.search_advanced,
                        total_items = searchResponse.total_items
                    };

                    if (!string.IsNullOrEmpty(searchRequest.key_table_paging)) context.Bo.AddPackFo(searchRequest.key_table_paging, searchResponseCMS.ToJObject());
                    else context.Bo.AddPackFo("table_paging", searchResponseCMS.ToJObject());

                    BuildStatusErrorResponse();

                    if (searchResponseCMS.total_items == 0) return "empty";
                    return "true";
                }
                else
                { // JOBJECT
                    context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);
                    return "true";
                }
            }
            else
            { //learn api data =""
                foreach (var (key, value) in obData.ToDictionary())
                {
                    context.Bo.AddPackFo(key, value.ToJToken()); ;
                }
                BuildStatusErrorResponse();
                return "true";
            }


        }

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> searchMulti()
    {
        var boInput = context?.Bo?.GetBoInput();

        String[] listLearnApi = new String[] { };

        if (boInput.ContainsKey("learn_api"))
            listLearnApi = boInput.GetValue("learn_api").ToString().Split(";");
        //String is_success="true";
        var searchRequest = new SearchPortalRequestModel()
        {
            key_table_paging = boInput["key_table_paging"]?.ToString(),
            search_advanced = boInput[propertyName: "search_advanced"]?.ToString()
        };
        for (int i = 0; i < listLearnApi.Length; i++)
        {
            string learnApi = listLearnApi[i];
            context.Bo.GetBoInput()["learn_api"] = learnApi;

            if (searchRequest == null) return "false";
            var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "Search", context);


            if (obData != null)
            {
                var searchResponse = obData.ToSearchResponsePortalModel();

                if (searchResponse == null)
                {
                    BuildStatusErrorResponse();
                    return "false";
                }

                var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);

                if (!learnApiContent.LearnApiData.Equals(""))
                {
                    if (Utils.Utils.IsValidJsonArray(searchResponse.results.ToSerialize()))
                    {
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, BuildTableCodeForArray(searchResponse.results.ToJArray(), learnApiContent.LearnApiData));

                        var searchResponseCMS = new SearchResponseCMSModel()
                        {
                            search_advanced = searchRequest.search_advanced,
                            total_items = searchResponse.total_items
                        };
                        if (!string.IsNullOrEmpty(searchRequest.key_table_paging.Split(";")[i].ToString())) context.Bo.AddPackFo(searchRequest.key_table_paging.Split(";")[i].ToString(), searchResponseCMS.ToJObject());
                        else context.Bo.AddPackFo("table_paging", searchResponseCMS.ToJObject());

                        BuildStatusErrorResponse();

                    }
                    else
                    { // JOBJECT
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, obData);
                    }
                }
                else
                { //learn api data =""
                    foreach (var (key, value) in obData.ToDictionary())
                    {
                        context.Bo.AddPackFo(key, value.ToJToken()); ;
                    }
                    BuildStatusErrorResponse();
                }


            }
            else return "false";
        }
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> postAPI()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "GetInfo", context);

        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            if (learnApiContent.LearnApiData.Equals("")) context.Bo.AddPackFo("data", obData.SelectToken(learnApiContent.KeyReadData));
            else
            {
                JObject obDataRs = new JObject();
                obDataRs.Add(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.KeyReadData));
                context.Bo.AddPackFo("data", obDataRs);
            }
            return "true";

        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> callAPI()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "GetInfo", context);

        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            if (learnApiContent.LearnApiData.Equals("")) return "false";
            else
            {
                JObject obDataRs = new JObject();

                if (!string.IsNullOrEmpty(learnApiContent.KeyReadData))
                {
                    obDataRs.Add(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.KeyReadData));
                    context.Bo.AddPackFo(learnApiContent.LearnApiData, obDataRs);
                    boInput[learnApiContent.LearnApiData] = obDataRs;
                }
                else
                {
                    obDataRs.Add(learnApiContent.LearnApiData, obData);
                    context.Bo.AddPackFo(learnApiContent.LearnApiData, obDataRs);

                }

            }
            BuildStatusErrorResponse();
            return "true";

        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> create()
    {
        JObject boInput = context?.Bo?.GetBoInput().DeepClone().ToJObject();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString().Split(";")[0];



        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "GetInfo", context);

        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            if (learnApiContent != null)
            {
                if (learnApiContent.LearnApiData.Equals("")) return "false";
                else
                {
                    JObject obDataRs = new JObject();

                    if (!string.IsNullOrEmpty(learnApiContent.KeyReadData))
                    {
                        obDataRs.Add(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.KeyReadData));
                        obDataRs["errorJWebUI"] = ReturnStatusPacked();
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, obDataRs);
                        boInput[learnApiContent.LearnApiData] = obDataRs;
                    }
                    else
                    {
                        obDataRs.Add(learnApiContent.LearnApiData, obData);
                        obDataRs["errorJWebUI"] = ReturnStatusPacked();
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, obDataRs);
                    }

                    //call api 2
                    try
                    {
                        string learnApi2 = boInput["learn_api"].ToString().Split(";")[1];
                        context.Bo.GetBoInput()["learn_api"] = learnApi2;
                        var obData2 = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "GetInfo", context);

                        if (obData2 != null)
                        {
                            var learnApiContent2 = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi2);
                            if (learnApiContent2 != null)
                            {
                                JObject obDataRs2 = new JObject();

                                if (!string.IsNullOrEmpty(learnApiContent2.KeyReadData))
                                {
                                    obDataRs2.Add(learnApiContent2.LearnApiData, obData2.SelectToken(learnApiContent2.KeyReadData));
                                    obDataRs2["errorJWebUI"] = ReturnStatusPacked();
                                    context.Bo.AddPackFo(learnApiContent2.LearnApiData, obDataRs2);
                                    boInput[learnApiContent2.LearnApiData] = obDataRs2;
                                }
                                else
                                {
                                    obDataRs2.Add(learnApiContent2.LearnApiData, obData2);
                                    obDataRs2["errorJWebUI"] = ReturnStatusPacked();
                                    context.Bo.AddPackFo(learnApiContent2.LearnApiData, obDataRs2);
                                }

                                if (boInput["node_clear"] != null)
                                {
                                    context.Bo.GetActionInput()["node_clear"] = boInput["node_clear"].ToString();
                                }
                                return "true";
                            }

                        }
                    }
                    catch (System.Exception)
                    {


                    }

                }
                return "true";
            }
        }
        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createAndSearch()
    {
        JObject boInput = context?.Bo?.GetBoInput().DeepClone().ToJObject();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString().Split(";")[0];



        var obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "GetInfo", context);

        if (obData != null)
        {
            var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);
            if (learnApiContent != null)
            {
                if (learnApiContent.LearnApiData.Equals("")) return "false";
                else
                {
                    JObject obDataRs = new JObject();

                    if (!string.IsNullOrEmpty(learnApiContent.KeyReadData))
                    {
                        obDataRs.Add(learnApiContent.LearnApiData, obData.SelectToken(learnApiContent.KeyReadData));
                        obDataRs["errorJWebUI"] = ReturnStatusPacked();
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, obDataRs);
                        boInput[learnApiContent.LearnApiData] = obDataRs;
                    }
                    else
                    {
                        obDataRs.Add(learnApiContent.LearnApiData, obData);
                        obDataRs["errorJWebUI"] = ReturnStatusPacked();
                        context.Bo.AddPackFo(learnApiContent.LearnApiData, obDataRs);
                    }

                    //call api 2
                    try
                    {
                        string learnApi2 = boInput["learn_api"].ToString().Split(";")[1];
                        context.Bo.GetBoInput()["learn_api"] = learnApi2;
                        var obData2 = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "GetInfo", context);
                        if (obData2 != null)
                        {
                            var learnApiContent2 = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi2);
                            if (learnApiContent2 != null)
                            {
                                JObject obDataRs2 = new JObject();
                                var searchResponse = obData2.ToSearchResponsePortalModel();

                                if (searchResponse.results != null)
                                {
                                    obDataRs2.Add(learnApiContent2.LearnApiData, BuildTableCodeForArray(searchResponse.results.ToJArray(), learnApiContent2.LearnApiData));
                                    context.Bo.AddPackFo(learnApiContent2.LearnApiData, BuildTableCodeForArray(searchResponse.results.ToJArray(), learnApiContent2.LearnApiData));

                                    //obDataRs2.Add(learnApiContent2.LearnApiData, obData2.SelectToken(learnApiContent2.KeyReadData));
                                    obDataRs2["errorJWebUI"] = ReturnStatusPacked();
                                    //context.Bo.AddPackFo(learnApiContent2.LearnApiData, obDataRs2);
                                    //boInput[learnApiContent2.LearnApiData] = obDataRs2;
                                }
                                else
                                {
                                    obDataRs2.Add(learnApiContent2.LearnApiData, obData2);
                                    obDataRs2[propertyName: "errorJWebUI"] = ReturnStatusPacked();
                                    context.Bo.AddPackFo(learnApiContent2.LearnApiData, obDataRs2);
                                }

                                if (boInput["node_clear"] != null)
                                {
                                    context.Bo.GetActionInput()["node_clear"] = boInput["node_clear"].ToString();
                                }
                                if (boInput["table_reload"] != null)
                                {
                                    context.Bo.GetActionInput()["table_reload"] = boInput["table_reload"].ToString();
                                }
                                return "true";
                            }

                        }
                    }
                    catch (System.Exception)
                    {


                    }

                }
                return "true";
            }
        }
        return "false";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> confirmAndReload()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirm", context);

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("learn_api_search"))
        {
            context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());
            context.Bo.GetBoInput()["learn_api"] = boInput["learn_api_search"].ToString();
        }

        if (boInput.ContainsKey("lang_confirm"))
            context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

        var learnApiContent = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);

        if (learnApiContent != null)
        {
            if (learnApiContent.LearnApiData.Equals("")) return "false";
            else
            {

            }
        }

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> copy()
    {
        var boInput = context.Bo.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "copy", context);

        if (obData != null)
        {
            if (boInput.ContainsKey("lang_confirm"))
                context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

            if (boInput.ContainsKey("learn_api_search"))
                context.Bo.GetActionInput().Add("learn_api_search", boInput["learn_api_search"].ToString());
            else return "noSearch";

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
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(context.InfoApp.GetApp(), "view", context);

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        var viewForm = boInput.ToObject<ViewFormBoModel>();
        if (viewForm != null)
        {
            if (viewForm.form_key != null) context.Bo.GetActionInput()["form_key"] = viewForm.form_key;
            if (viewForm.table_code != null) context.Bo.GetActionInput()["table_code"] = viewForm.table_code;

            var getLearnApi = await _learnApiService.GetByAppAndId(context.InfoApp.GetApp(), learnApi);

            if (getLearnApi != null)
            {
                getLearnApi.KeyReadData = getLearnApi.KeyReadData.Replace("data.", "");
                if (!getLearnApi.LearnApiData.Equals(""))
                {
                    JObject obItem = new JObject();
                    obItem[getLearnApi.LearnApiData] = obData[getLearnApi.KeyReadData];
                    context.Bo.AddPackFo(getLearnApi.LearnApiData, obItem);
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
    public async Task<string> confirm()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirm", context);

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("learn_api_search"))
            context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());

        if (boInput.ContainsKey("learn_api_search"))
            context.Bo.GetActionInput().Add("learn_api_search", boInput["learn_api_search"].ToString());


        if (boInput.ContainsKey("lang_confirm"))
            context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

        if (learnApi.Equals("adm_token_delete"))
        {
            if (boInput.SelectToken("adm_token_search.token") != null)
            {
                var info = Utils.Utils.CreateFoQuick("#sys:fo-goto-pageLogin", new JObject()).ToSerialize();
                await _webSocketsService.SendMessageWithToken(boInput.SelectToken("adm_token_search.token").ToString(), info);

            }
        }

        if (learnApi.Equals("adm_token_delete_all"))
        {
            var info = Utils.Utils.CreateFoQuick("#sys:fo-goto-pageLogin", new JObject()).ToSerialize();
            await _webSocketsService.SendMessageAllExceptToken(context.InfoUser.GetUserLogin().Token, info);
        }
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> confirmDeleteSession()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirm", context);

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("learn_api_search"))
            context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());

        if (boInput.ContainsKey("lang_confirm"))
            context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> confirmDeleteToken()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";
        // string token = "";

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "confirm", context);

        if (obData == null)
        {
            JObject obErr = new JObject();
            obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
            context.Bo.AddPackFo("errorJWebUI", obErr);
            return "false";
        }

        if (boInput.ContainsKey("learn_api_search"))
            context.Bo.GetActionInput().Add("learn_api", boInput["learn_api_search"].ToString());

        if (boInput.ContainsKey("lang_confirm"))
            context.Bo.GetActionInput().Add("lang_confirm", boInput["lang_confirm"].ToString());

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();


        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createFileAndDownload()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";

        var createFileAndDownloadModel = boInput.ToCreateAndDownloadFileModel();

        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        if (!string.IsNullOrEmpty(createFileAndDownloadModel.lang_confirm))
            context.Bo.GetActionInput().Add("lang_confirm", createFileAndDownloadModel.lang_confirm);

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "createFileAndDownload", context);

        if (obData == null) return "false";

        if (obData != null)
        {
            var bytes = Encoding.ASCII.GetBytes(obData.ToString());
            string fileName = "" + context.InfoApp.GetApp();
            if (!string.IsNullOrEmpty(createFileAndDownloadModel.key_api_convert))
            {
                if (boInput[createFileAndDownloadModel.key_api_convert] != null)
                {
                    fileName += " (" + boInput[createFileAndDownloadModel.key_api_convert].ToString() + ")";
                }
            }
            else if (!string.IsNullOrEmpty(createFileAndDownloadModel.table_code) && !string.IsNullOrEmpty(createFileAndDownloadModel.key_val))
            {
                if (boInput[createFileAndDownloadModel.table_code] != null)
                    if (boInput[createFileAndDownloadModel.table_code][createFileAndDownloadModel.key_val] != null)
                    {
                        fileName += " (" + boInput[createFileAndDownloadModel.table_code][createFileAndDownloadModel.key_val].ToString() + ")";
                    }
            }

            if (!string.IsNullOrEmpty(createFileAndDownloadModel.file_name)) fileName += createFileAndDownloadModel.file_name;


            await _mediaUploadService.Insert(new MediaUpload()
            {
                MediaData = Convert.ToBase64String(bytes),
                MediaName = fileName + ".json",
                MediaType = "json",
                Token = context.InfoUser.GetUserLogin().Token,
                UserId = context.InfoUser.GetUserLogin().UserId,
            });

            context.Bo.GetActionInput()["file_name"] = fileName + ".json";
            context.Bo.GetActionInput()["media_data"] = Convert.ToBase64String(bytes);


            return "true";
        }

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> createAndDownload()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string learnApi = "";


        if (boInput.ContainsKey("learn_api"))
            learnApi = boInput.GetValue("learn_api").ToString();

        var obData = await _postApiService.GetDataPostAPI(context.InfoApp.GetApp(), "createAndDownload", context);
        Console.WriteLine("=====obData======" + JsonConvert.SerializeObject(obData));

        if (obData == null) return "false";

        if (obData != null && obData.SelectToken("data") != null && obData.SelectToken("data").Type != JTokenType.Null)
        {
            var bytes = Encoding.ASCII.GetBytes(obData.SelectToken("data").ToString());
            string fileName = "" + context.InfoApp.GetApp();
            if (boInput["name_file"] != null)
            {
                fileName += "_" + boInput["name_file"].ToString();
            }

            await _mediaUploadService.Insert(new MediaUpload()
            {
                MediaData = Convert.ToBase64String(bytes),
                MediaName = fileName + ".json",
                MediaType = "json",
                Token = context.InfoUser.GetUserLogin().Token,
                UserId = context.InfoUser.GetUserLogin().UserId,
            });

            context.Bo.GetActionInput()["file_name"] = fileName + ".json";
            context.Bo.GetActionInput()["media_data"] = Convert.ToBase64String(bytes);


            return "true";
        }

        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> deleteFile()
    {
        await _mediaUploadService.DeleteWithUserIdAndFileName(context.InfoUser.GetUserLogin().UserId.ToString(), context.Bo.GetBoInput()["file_name"].ToString());
        return "true";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> readFileAndReturn()
    {
        var boInput = context.Bo.GetBoInput();
        string fileName = "";
        string keyReadData = "";
        var readFileModel = new ReadFileBoModel()
        {
            key_convert = boInput["key_convert"]?.ToString(),
            key_read_data = boInput["key_read_data"]?.ToString(),
            table_code = boInput["table_code"]?.ToString()
        };

        if (readFileModel != null)
        {
            if (readFileModel.key_read_data != null) keyReadData = readFileModel.key_read_data;

            if (!keyReadData.Equals(""))
            {
                var uploadFile = boInput.SelectToken(keyReadData);
                if (uploadFile != null)
                {
                    if (uploadFile["name"] != null)
                    {
                        fileName = uploadFile["name"].ToString();
                    }
                }
            }

            var getFile = await _mediaUploadService.GetByUserIdAndFileName(context.InfoUser.GetUserLogin().UserId.ToString(), fileName);
            if (getFile != null)
            {
                JObject obRs = new JObject();
                obRs[readFileModel.key_convert] = getFile.MediaData;
                JObject data = new JObject();
                data[readFileModel.table_code] = obRs;
                context.Bo.AddPackFo("data", data);
                return "true";
            }
        }


        return "false";
    }
    /// <summary>
    /// 
    /// </summary>
    public void BuildStatusErrorResponse()
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        context.Bo.AddPackFo("errorJWebUI", obErr);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public JObject ReturnStatusPacked()
    {
        JObject obErr = new JObject();
        obErr.Add(new JProperty("count", context.Bo.GetActionErrors().Count));
        return obErr;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
        if (string.IsNullOrEmpty(context.Bo.GetBoInput()["learn_api"].ToString()))
            context.Bo.GetBoInput()["learn_api"] = "ncbsCBS_workflow_execute_new";

        var rs = await _postApiService.GetDataPostAPI("ncbsCbs", "executeWorkflow", context);
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
    public async Task<string> truncateLogService()
    {
        _logServiceService.DeleteAll();
        await Task.CompletedTask;
        return "true";
    }

}
