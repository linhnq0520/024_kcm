using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Services;
using JITS.Neptune.NeptuneClient.Workflow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.FlowApi;

/// <summary>
/// ICoreAPIService service
/// </summary>
public partial class ApiNcbsCbsMediaFo : ICoreAPIService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="typeError"></param>
    /// <param name="info"></param>
    /// <param name="code"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    protected ErrorInfoModel AddActionError(string type, string typeError, string info, string code, string key)
    {
        return new ErrorInfoModel()
        {
            type = type,
            type_error = typeError,
            key = key,
            info = info,
            code = code
        }; ;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JObject> BuildHeader(JObject packApi)
    {
        await Task.CompletedTask;
        return packApi;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(JToken packApi)
    {
        var workflow = packApi.ToWorkflowExecutionInquiry();
        var steps = workflow.execution_steps;
        for (int i = 0; i < steps.Count; i++)
        {
            var step = steps[i];
            var content = JsonConvert.DeserializeObject<WorkflowStep>(step.p2_content.ToString());
            //var data_res = JObject.Parse(content.response.data.ToString());

            //.WriteLine("=====data======"+ JsonConvert.SerializeObject(data_res));
            try
            {
                var data = content.response.data.ToJToken().ToPageSearchMediaModel();
                List<object> listMedia = new List<object>();

                if (data.items != null)
                {
                    foreach (var item in data.items)
                    {
                        var media = item.ToJToken().ToMediaModel();
                        var new_media = new MediaClientModel()
                        {
                            FN = media.MediaName,
                            MCS = media.MediaData,
                            FT = media.MediaType,
                            CC = media.CustomerCode,
                            RT = media.ReferenceType,
                            ED = media.ExpireDate,
                            OT = media.Other,
                            Infor1 = media.Infor1,
                            Infor2 = media.Infor2
                        };
                        listMedia.Add(new_media.ToJObject());
                    }

                }
                data.MEDIA = listMedia;
                JObject obPaging = new JObject();
                obPaging.Add(new JProperty(name: "total", data.total_count));
                data.PAGING = obPaging;
                content.response.data = data;

                workflow.execution_steps[i].p2_content = content;
            }
            catch (System.Exception)
            {
                // TODO
            }

        }
        await Task.CompletedTask;
        return JToken.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(workflow));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseApiModel"></param>
    /// <returns></returns>
    public async Task<List<ErrorInfoModel>> BuildError(WorkflowExecutionInquiry responseApiModel)
    {
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        try
        {
            if (responseApiModel.execution_steps != null)
            {
                foreach (var itemStep in responseApiModel.execution_steps)
                {
                    var dataProcess = itemStep.p2_content.ToExecutionStepProcess();

                    if (dataProcess != null && dataProcess.response != null)
                    {
                        if (dataProcess.response.status != 0)
                        {
                            // var errorMeg = itemStep.step_code + " : " + dataProcess.response.data.GetErrorMessage();
                            // listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, errorMeg, "", ""));
                            string[] list_error = dataProcess.response.error_message.Split("\n");
                            for (var i = 0; i < list_error.Length; i++)
                            {
                                listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, list_error[i], itemStep.step_code, dataProcess.response.error_code));
                            }

                        }
                    }
                }
            }
        }
        catch (System.Exception)
        {
            // TODO
            if (responseApiModel.execution.is_timeout.Equals("Y")) listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, "Timeout execute workflow with execution_id : " + responseApiModel.execution.execution_id, "", ""));
        }
        await Task.CompletedTask;
        return listError;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<bool> CheckHasError(WorkflowExecutionInquiry packApi)
    {
        //Console.WriteLine("======packApi" +JsonConvert.SerializeObject(packApi));
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        if (!packApi.execution.is_success.Equals("Y")) return true;
        await Task.CompletedTask;
        return false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<bool> CheckHasError(ExecuteResponseModel packApi)
    {
        await Task.CompletedTask;
        return false;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseApiModel"></param>
    /// <returns></returns>
    public async Task<List<ErrorInfoModel>> BuildError(ExecuteResponseModel responseApiModel)
    {
        await Task.CompletedTask;
        return new List<ErrorInfoModel>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(ExecuteResponseModel packApi)
    {
        var result = packApi;
        await Task.CompletedTask;
        return result.ToJToken();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<string> BuildRequest(string packApi)
    {
        var workflowExecute = JObject.Parse(packApi).ToObject<WorkflowExecuteModel>();
        await Task.CompletedTask;
        return workflowExecute.ToSerialize();
    }
}
