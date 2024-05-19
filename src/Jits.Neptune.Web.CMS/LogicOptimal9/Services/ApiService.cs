using JITS.Neptune.NeptuneClient.Workflow;
using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public partial class ApiService: IApiService
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
    /// <param name="workflowId"></param>
    /// <param name="responseModel"></param>
    /// <param name="keyError"></param>
    /// <returns></returns>
    public async Task<List<ErrorInfoModel>> BuildError(string workflowId,WorkflowResponseModel responseModel, string keyError = "SYSTEM_ERROR")
    {
        List<ErrorInfoModel> listError = new();
        try
        {
            if (responseModel.status != 0)
            {
                listError.Add(AddActionError(ErrorType.errorForm, ErrorMainForm.warning, responseModel.error_message, workflowId, keyError));

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
        await Task.CompletedTask;

        return listError;
    }
}

/// <summary>
/// 
/// </summary>
public static class BuildWorkflowResponse
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="needs_mapping"></param>
    /// <param name="error_message"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static JObject BuildWorkflowResponseSuccess(this object value, bool needs_mapping = true, string error_message = null)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        JToken token = value is JToken ? (JToken)value : JToken.FromObject(value);
        var rs = new WorkflowResponseModel(ExecutionStatus.SUCCESS, error_message, token, needs_mapping);
        return rs.ToJObject();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error_message"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static JObject BuildWorkflowResponseError(this string error_message, JToken result = null)
    {
        var rs = new WorkflowResponseModel(ExecutionStatus.ERROR, error_message, result);
        return rs.ToJObject();
    }
}

