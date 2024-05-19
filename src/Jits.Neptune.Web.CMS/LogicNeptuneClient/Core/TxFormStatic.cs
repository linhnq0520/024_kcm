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
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
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
public class TxFormStatic
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

    //
    private readonly IAdminServices _adminService;
    private readonly IO9PostService _o9PostService;
    //


    /// <summary>
    ///Tx
    /// </summary>
    public TxFormStatic(IFoService foService, IAppService appService, ILangService langService, IParaServerService paraServerService, IAdminServices adminService, IAdminGrpcService adminGrpcService, IAuthenticationGrpcService authenticationGrpcService, IPostAPIService postAPIService, ICdlistService cdlistService, 
        ILearnApiService learnApiService, IO9PostService o9PostService)
    {
        context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        _foService = foService;
        _appService = appService;
        _langService = langService;
        _paraServerService = paraServerService;
        _adminService = adminService;
        _adminGrpcService = adminGrpcService;
        _authenticationGrpcService = authenticationGrpcService;
        _postApiService = postAPIService;
        _cdlistService = cdlistService;
        _learnApiService = learnApiService;
        _o9PostService = o9PostService;
    }


    /// <summary>
    ///getUserProfileDefaultSys
    /// </summary>

    public async Task<string> postAPI()
    {
        JObject boInput = context?.Bo?.GetBoInput();
        string app = boInput["app"] != null ? boInput["app"].ToString() : context.InfoApp.GetApp();
        string learnApi = "";
        string tableCode = "data_api";
        JObject bodyMapping = new JObject();
        WorkflowExecuteModel executeModel = new WorkflowExecuteModel();
        Dictionary<string, object> idInput = new Dictionary<string, object>();
        int numberOfSteps = 2;
        var postApiInputModel = boInput.ToObject<FormStaticPostApiModel>();
        if (boInput.ContainsKey("learn_api")) learnApi = postApiInputModel.learn_api;
        // learnApi = boInput.GetValue("learn_api").ToString();
        if (boInput.ContainsKey("key_convert_data")) tableCode = postApiInputModel.key_convert_data;
        // tableCode = boInput.GetValue("key_convert_data").ToString();
        if (boInput.ContainsKey("api_data"))
        {
            // bodyMapping = JObject.FromObject(boInput.GetValue("api_data"));
            bodyMapping = postApiInputModel.api_data.ToJObject();
        }

        if (boInput.ContainsKey("number_of_step"))
            numberOfSteps = postApiInputModel.number_of_step;

        executeModel.workflowid = postApiInputModel.workflow_id;
        executeModel.fields = bodyMapping.ToDictionary();

        executeModel.lang = context.InfoUser.GetUserLogin().Lang;

        boInput["execution"] = JToken.FromObject(executeModel);

        JToken obData = null;
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            obData = await _o9PostService.GetDataPostAPI(
                "ncbsCbs",
                "postAPI",
                context
            );
        }
        else
        {
            obData = await _postApiService.GetDataPostAPIWithoutKeyReadData(app, "postAPI", context);
        }

        if (obData == null)
        {
            BuildStatusErrorResponse();
            return "false";
        }

        string selectTokenKey = $"execution_steps[{numberOfSteps - 1}].p2_content.response.data";
        var dataResult = obData.SelectToken(selectTokenKey);
        if (dataResult != null)
        {
            context.Bo.AddPackFo(tableCode, obData.SelectToken(selectTokenKey));
            boInput[tableCode] = obData.SelectToken(selectTokenKey);

            if (boInput.ContainsKey("learn_api"))
                context.Bo.GetActionInput().Add("learn_api", boInput["learn_api"].ToString());
            if (boInput.ContainsKey("workflow_id_search"))
                context.Bo.GetActionInput().Add("workflow_id", boInput["workflow_id_search"].ToString());
            if (boInput.ContainsKey("table_code"))
                context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());
            return "true";
        }
        else
        {
            context.Bo.AddPackFo(tableCode, obData);
            boInput[tableCode] = obData;

            if (boInput.ContainsKey("learn_api"))
                context.Bo.GetActionInput().Add("learn_api", boInput["learn_api"].ToString());
            if (boInput.ContainsKey("workflow_id_search"))
                context.Bo.GetActionInput().Add("workflow_id", boInput["workflow_id_search"].ToString());
            if (boInput.ContainsKey("table_code"))
                context.Bo.GetActionInput().Add("table_code", boInput["table_code"].ToString());
            return "true";
        }



        // return "false";
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
    public async Task<JToken> executeWorkflow()
    {
        var boInput = context.Bo.GetBoInput();
        if (string.IsNullOrEmpty(context.Bo.GetBoInput()["learn_api"].ToString()))
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
    public async Task<string> LoadRoleOperationHeader()
    {
        var boInput = context.Bo.GetBoInput();
        if (boInput["command_id"] != null && boInput["app_select"] != null)
        {
            var command_id = boInput["command_id"].ToString();
            var app = boInput["app_select"].ToString();
            if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
            {
                var getOperationData = await _adminService.GetUserCommandInfoFromParentId(app, command_id);
                var getCommandsFromCommand = await _adminService.GetUserCommandInfoFromCommandId(app, command_id);
                getCommandsFromCommand.AddRange(getOperationData);
                getCommandsFromCommand = getCommandsFromCommand.OrderBy(x => x.RoleId).ToList();
                if (getCommandsFromCommand != null)
                {
                    var operationHeader = await getCommandsFromCommand.FindAll(s => s.ParentId.Equals(command_id) && s.CommandType.Equals("C")).Select(s => new OperationHeaderModel()
                    {
                        cmdid = s.CommandId,
                        caption = s.CommandName
                    }).ToListAsync();

                    var operationBody = getCommandsFromCommand.FindAll(s => s.CommandId.Equals(command_id) || s.CommandType.Equals("C"));

                    JObject dataRs = new JObject();
                    dataRs["operation_header"] = operationHeader.DistinctBy(p => p.cmdid).ToJArray();
                    dataRs["operation_body"] = operationBody.ToJArray();
                    context.Bo.AddPackFo("data", dataRs);
                    return "true";
                }
            }
            else
            {
                var getOperationData = await _adminGrpcService.GetUserCommandInfoFromParentId(app, command_id);
                var getCommandsFromCommand = await _adminGrpcService.GetUserCommandInfoFromCommandId(app, command_id);
                getCommandsFromCommand.AddRange(getOperationData);
                getCommandsFromCommand = getCommandsFromCommand.OrderBy(x => x.RoleId).ToList();
                if (getCommandsFromCommand != null)
                {
                    var operationHeader = await getCommandsFromCommand.FindAll(s => s.ParentId.Equals(command_id) && s.CommandType.Equals("C")).Select(s => new OperationHeaderModel()
                    {
                        cmdid = s.CommandId,
                        caption = s.CommandName
                    }).ToListAsync();

                    var operationBody = getCommandsFromCommand.FindAll(s => s.CommandId.Equals(command_id) || s.CommandType.Equals("C"));

                    JObject dataRs = new JObject();
                    dataRs["operation_header"] = operationHeader.DistinctBy(p => p.cmdid).ToJArray();
                    dataRs["operation_body"] = operationBody.ToJArray();
                    context.Bo.AddPackFo("data", dataRs);
                    return "true";
                }
            }
        }
        return "false";
    }
}
