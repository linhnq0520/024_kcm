using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class DepositWorkflowService: IDepositWorkflowService
{
    /// <summary>
    /// 
    /// </summary>
    public DepositWorkflowService()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public async Task<JToken> UpdateAccount(WorkflowRequestModel workflow)
    {
        JsonTableName clsJson = new();
        try
        {
            JObject jsData = workflow.ObjectField;
            string ifcListKey = "ifclist";
            string defacnoKey = "DEFACNO";

            JArray ifcList = jsData.Value<JArray>(ifcListKey);
            jsData.Remove(ifcListKey);

            JObject jsRequest = jsData.ConvertToJArray();
            clsJson.TXBODY.Add(new JsonData(workflow.TableName, jsRequest));

            if (ifcList != null && ifcList.Count > 0)
            {
                string defacno = jsData.Value<string>(defacnoKey);
                var jsonDataIfcs = ConvertIFCs(ifcList, defacno);
                clsJson.TXBODY.Add(jsonDataIfcs);
            }
            else
            {
                var emptyIFCList = new JsonData
                {
                    DATA = new JObject
                        {
                            { "MDLCODE", new JArray() },
                            { "DEFACNO", new JArray() },
                            { "LASTDT", new JArray() },
                            { "IFCCD", new JArray() }
                        },
                    FPK = null,
                    TABLENAME = "O9DATA.D_IFCBAL"
                };
                clsJson.TXBODY.Add(emptyIFCList);
            }

            string result = O9Utils.GenJsonBackOfficeRequest(workflow.user_sessions,workflow.WorkflowFunc, clsJson.TXBODY);
            JObject jsResult = O9Utils.AnalysisBOResult(result, null, true);
            return jsResult;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.StackTrace);
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    private static JsonData ConvertIFCs(JArray IFCs, string defacno)
    {
        string mdlcodeKey = "module_code";
        string lastdtKey = "last_datetime";

        JArray mdlcodes = new();
        JArray lastdts = new();
        JArray defacnos = new();
        JArray ifcCodes = new();
        foreach (var ifc in IFCs)
        {
            mdlcodes.Add(ifc.SelectToken(mdlcodeKey));
            lastdts.Add(ifc.SelectToken(lastdtKey).ToObject<DateTime>().ToString("dd/MM/yyyy"));
            defacnos.Add(defacno);
            ifcCodes.Add(ifc.SelectToken("ifc_code"));
        }
        var ifcsData = new JsonData
        {
            DATA = new JObject
                        {
                            { "MDLCODE", mdlcodes },
                            { "DEFACNO", defacnos },
                            { "LASTDT", lastdts },
                            { "IFCCD", ifcCodes }
                        },
            FPK = null,
            TABLENAME = "O9DATA.D_IFCBAL"
        };

        return ifcsData;
    }
}
