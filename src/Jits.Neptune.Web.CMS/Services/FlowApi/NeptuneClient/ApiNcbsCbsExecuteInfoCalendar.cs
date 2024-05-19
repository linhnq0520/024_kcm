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
public partial class ApiNcbsCbsExecuteInfoCalendar : ICoreAPIService
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
    /// <param name="title"></param>
    /// <param name="start"></param>
    /// <param name="color"></param>
    /// <returns></returns>
    private JObject createItemCalender(string title, string start, string color)
    {

        JObject ob_new_calendar = new JObject();
        try
        {
            var itemCalendar = new ItemCalendarModel()
            {
                title = title,
                color = color,
                start = DateTime.Parse(start).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)
            }.ToJObject();
            ob_new_calendar["calender"] = itemCalendar;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("createItemCalender exception===" + ex.StackTrace);
        }
        return ob_new_calendar;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<JToken> BuildResponse(JToken packApi)
    {
        var arr_new = new JArray();
        foreach (var item_ in packApi.ToJArray())
        {
            var sqn_date = item_["sqn_date"].ToString();
            if (item_["sqn_date"] != null && item_.SelectToken("is_holiday") != null)
            {
                if (item_.SelectToken("is_holiday").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calenderHoliday", sqn_date, "#ff0000"));
                }
            }

            if (item_["sqn_date"] != null && item_.SelectToken("is_current_date") != null)
            {
                if (item_.SelectToken("is_current_date").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarNow", sqn_date, "#ffa500"));
                }
            }

            if (item_["sqn_date"] != null && item_.SelectToken("is_begin_of_half_year") != null)
            {
                if (item_.SelectToken("is_begin_of_half_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarBoh", sqn_date, "#00ffff"));
                }
            }

            if (item_["sqn_date"] != null && item_.SelectToken("is_begin_of_month") != null)
            {
                if (item_.SelectToken("is_begin_of_month").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarBom", sqn_date, "#e0ffff"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_begin_of_quater") != null)
            {
                if (item_.SelectToken("is_begin_of_quater").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarBoq", sqn_date, "#ffa07a"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_begin_of_week") != null)
            {
                if (item_.SelectToken("is_begin_of_week").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarBow", sqn_date, "#f08080"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_begin_of_year") != null)
            {
                if (item_.SelectToken("is_begin_of_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarBoy", sqn_date, "#ffe4c4"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_end_of_half_year") != null)
            {
                if (item_.SelectToken("is_end_of_half_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarSeoh", sqn_date, "#808000"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_end_of_month") != null)
            {
                if (item_.SelectToken("is_end_of_month").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarSeom", sqn_date, "#90ee90"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_end_of_quater") != null)
            {
                if (item_.SelectToken("is_end_of_quater").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarSeoq", sqn_date, "#ffff00"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_end_of_week") != null)
            {
                if (item_.SelectToken("is_end_of_week").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarSeow", sqn_date, "#add8e6"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_end_of_year") != null)
            {
                if (item_.SelectToken("is_end_of_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarSeoy", sqn_date, "#ffc0cb"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_begin_of_half_year") != null)
            {
                if (item_.SelectToken("is_fiscal_begin_of_half_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFboh", sqn_date, "#ffe4b5"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_begin_of_month") != null)
            {
                if (item_.SelectToken("is_fiscal_begin_of_month").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFbom", sqn_date, "#faf0e6"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_begin_of_quater") != null)
            {
                if (item_.SelectToken("is_fiscal_begin_of_quater").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFboq", sqn_date, "#778899"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_begin_of_week") != null)
            {
                if (item_.SelectToken("is_fiscal_begin_of_week").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFbow", sqn_date, "#00ff00"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_begin_of_year") != null)
            {
                if (item_.SelectToken("is_fiscal_begin_of_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFboy", sqn_date, "#da70d6"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_end_of_half_year") != null)
            {
                if (item_.SelectToken("is_fiscal_end_of_half_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFeoh", sqn_date, "#ffc0cb"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_end_of_month") != null)
            {
                if (item_.SelectToken("is_fiscal_end_of_month").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFeom", sqn_date, "#ff00ff"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_end_of_quater") != null)
            {
                if (item_.SelectToken("is_fiscal_end_of_quater").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFeoq", sqn_date, "#ffd700"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_end_of_week") != null)
            {
                if (item_.SelectToken("is_fiscal_end_of_week").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFeow", sqn_date, "#b22222"));
                }
            }
            if (item_["sqn_date"] != null && item_.SelectToken("is_fiscal_end_of_year") != null)
            {
                if (item_.SelectToken("is_fiscal_end_of_year").getAsInt() != 0)
                {
                    arr_new.Add(createItemCalender("calendarFeoy", sqn_date, "#e6e6fa"));
                }
            }
        }
        await Task.CompletedTask;
        return arr_new;
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
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine(ex.StackTrace);
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
        await Task.CompletedTask;
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>();
        if (!packApi.execution.is_success.Equals("Y")) return true;
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
        await Task.CompletedTask;
        var result = packApi;

        return result.ToJToken();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="packApi"></param>
    /// <returns></returns>
    public async Task<string> BuildRequest(string packApi)
    {
        await Task.CompletedTask;
        var workflowExecute = JObject.Parse(packApi).ToObject<WorkflowExecuteModel>();
        return workflowExecute.ToSerialize();
    }
}
