using Apache.NMS;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class O9ClientService : IO9ClientService
{
    private readonly O9Client _client;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    public O9ClientService(O9Client client)
    {
        _client = client;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objJsonBody"></param>
    /// <param name="functionId"></param>
    /// <param name="sessionid"></param>
    /// <param name="isResultCaching"></param>
    /// <param name="sendtype"></param>
    /// <param name="usrId"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public async Task<string> GenJsonBodyRequestAsync(object objJsonBody,
        string functionId, string sessionid = "",
        EnmCacheAction isResultCaching = EnmCacheAction.NoCached,
        EnmSendTypeOption sendtype = EnmSendTypeOption.Synchronize,
        string usrId = "-1",
        MsgPriority priority = MsgPriority.Normal)
    {
        try
        {
            if (string.IsNullOrEmpty(functionId)) return string.Empty;
            string strRequest = string.Empty;
            string strResult = string.Empty;
            O9Client o9Client = new O9Client();
            if (objJsonBody != null) strRequest = JsonConvert.SerializeObject(objJsonBody);
            strResult = await _client.SendStringAsync(strRequest, functionId, usrId, sessionid, EnmCacheAction.NoCached,
                                                        EnmSendTypeOption.Synchronize, MsgPriority.Normal);
            o9Client = null;
            return strResult;
        }
        catch (Exception ex)
        {
            Console.WriteLine("error_GenJsonBodyRequest == " + ex.Message);
            return string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="ptxcode"></param>
    /// <param name="ptxbody"></param>
    /// <param name="functionId"></param>
    /// <param name="isResultCaching"></param>
    /// <param name="pstatus"></param>
    /// <param name="ptxrefid"></param>
    /// <param name="pvaluedt"></param>
    /// <param name="pifcfee"></param>
    /// <param name="pusrws"></param>
    /// <param name="papuser"></param>
    /// <param name="papusrip"></param>
    /// <param name="papusrws"></param>
    /// <param name="papdt"></param>
    /// <param name="pisreverse"></param>
    /// <param name="phbranchid"></param>
    /// <param name="prbranchid"></param>
    /// <param name="papreason"></param>
    /// <param name="pposting"></param>
    /// <param name="pprn"></param>
    /// <param name="pid"></param>
    /// <param name="isMapping"></param>
    /// <returns></returns>
    public async Task<string> GenJsonFrontOfficeRequestAsync(UserSessions user, string ptxcode, JObject ptxbody,
        string functionId = "", EnmCacheAction isResultCaching = EnmCacheAction.NoCached,
        string pstatus = "C", string ptxrefid = null, string pvaluedt = null, JObject pifcfee = null,
        string pusrws = null, object papuser = null, string papusrip = null, string papusrws = null,
        string papdt = null, string pisreverse = "N", int? phbranchid = null, int? prbranchid = null,
        string papreason = null, JsonPosting pposting = null, string pprn = null,
        string pid = null, bool isMapping = true)
    {
        try
        {
            JsonFrontOffice clsJsonFrontOffice = new JsonFrontOffice();
            if (string.IsNullOrEmpty(functionId)) functionId = GlobalVariable.UTIL_CALL_PROC;
            if (string.IsNullOrEmpty(pprn)) pprn = "";

            clsJsonFrontOffice.TXCODE = ptxcode;
            clsJsonFrontOffice.TXDT = user.Txdt.ToString("dd/MM/yyyy");
            clsJsonFrontOffice.BRANCHID = user.UsrBranchid;
            clsJsonFrontOffice.USRID = user.Usrid;
            clsJsonFrontOffice.LANG = user.Lang;
            clsJsonFrontOffice.STATUS = pstatus;
            clsJsonFrontOffice.TXREFID = ptxrefid;
            clsJsonFrontOffice.VALUEDT = user.Txdt.ToString("dd/MM/yyyy");
            clsJsonFrontOffice.USRWS = pusrws;
            clsJsonFrontOffice.APUSER = papuser;
            clsJsonFrontOffice.APUSRIP = papusrip;
            clsJsonFrontOffice.APUSRWS = papusrws;
            clsJsonFrontOffice.APDT = papdt;
            clsJsonFrontOffice.ISREVERSE = pisreverse;
            clsJsonFrontOffice.HBRANCHID = phbranchid;
            clsJsonFrontOffice.RBRANCHID = prbranchid;
            clsJsonFrontOffice.TXBODY = ptxbody;
            clsJsonFrontOffice.APREASON = papreason;
            clsJsonFrontOffice.IFCFEE = pifcfee;
            clsJsonFrontOffice.PRN = pprn;
            if (string.IsNullOrEmpty(pid)) pid = Guid.NewGuid().ToString();
            clsJsonFrontOffice.ID = pid;

            if (isMapping)
            {
                var frontOfficeMapping = new JsonFrontOfficeMapping(clsJsonFrontOffice);
                return await GenJsonBodyRequestAsync(frontOfficeMapping, functionId, user.Ssesionid,
                    EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, user.Usrid.ToString());
            }

            return await GenJsonBodyRequestAsync(clsJsonFrontOffice, functionId, user.Ssesionid, EnmCacheAction.NoCached,
                EnmSendTypeOption.Synchronize, user.Usrid.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return string.Empty;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userSessions"></param>
    /// <param name="pTXCODE"></param>
    /// <param name="pTXBODY"></param>
    /// <param name="functionId"></param>
    /// <param name="isCaching"></param>
    /// <param name="pSTATUS"></param>
    /// <param name="pTXREFID"></param>
    /// <param name="pVALUEDT"></param>
    /// <param name="pUSRWS"></param>
    /// <param name="pAPUSER"></param>
    /// <param name="pAPUSRIP"></param>
    /// <param name="pAPUSRWS"></param>
    /// <param name="pAPDT"></param>
    /// <param name="pISREVERSE"></param>
    /// <param name="pHBRANCHID"></param>
    /// <param name="pRBRANCHID"></param>
    /// <param name="pAPREASON"></param>
    /// <param name="pPRN"></param>
    /// <returns></returns>
    public async Task<string> GenJsonBackOfficeRequestAsync(UserSessions userSessions, string pTXCODE, List<JsonData> pTXBODY,
        string functionId = "", EnmCacheAction isCaching = EnmCacheAction.NoCached,
        string pSTATUS = "C", string pTXREFID = null,
        string pVALUEDT = null, string pUSRWS = "",
        object pAPUSER = null, string pAPUSRIP = "",
        string pAPUSRWS = "", string pAPDT = "",
        string pISREVERSE = "N", int pHBRANCHID = 0,
        int pRBRANCHID = 0, string pAPREASON = null,
        string pPRN = "")
    {
        try
        {
            JsonBackOffice clsJsonBackOffice = new JsonBackOffice();
            if (string.IsNullOrEmpty(functionId))
                functionId = GlobalVariable.UTIL_CALL_PROC;

            clsJsonBackOffice.TXCODE = pTXCODE; // Field 1
            clsJsonBackOffice.TXDT = userSessions.Txdt.ToShortDateString(); // Field 2
            clsJsonBackOffice.BRANCHID = userSessions.UsrBranchid; // Field 5
            clsJsonBackOffice.USRID = userSessions.Usrid; // Field 7
            clsJsonBackOffice.LANG = GlobalVariable.O9_GLOBAL_LANG.ToLower(); // Field 8
            clsJsonBackOffice.STATUS = pSTATUS; // Field 14
            clsJsonBackOffice.TXREFID = pTXREFID; // Field 3
            clsJsonBackOffice.VALUEDT = pVALUEDT; // Field 4
            clsJsonBackOffice.USRWS =
                string.IsNullOrEmpty(pUSRWS) ? GlobalVariable.O9_GLOBAL_COMPUTER_NAME : pUSRWS; // Field 6
            clsJsonBackOffice.APUSER = pAPUSER; // Field 9
            clsJsonBackOffice.APUSRIP = pAPUSRIP; // Field 10
            clsJsonBackOffice.APUSRWS = pAPUSRWS; // Field 11
            clsJsonBackOffice.APDT = pAPDT; // Field 12
            clsJsonBackOffice.ISREVERSE = pISREVERSE; // Field 14
            clsJsonBackOffice.HBRANCHID = pHBRANCHID; // Field 15
            clsJsonBackOffice.RBRANCHID = pRBRANCHID; // Field 16
            clsJsonBackOffice.TXBODY = pTXBODY; // Field 17
            clsJsonBackOffice.APREASON = pAPREASON; // Field 18
            clsJsonBackOffice.PRN = pPRN; // Field 19
            clsJsonBackOffice.ID = Guid.NewGuid().ToString(); // Field 20


            // Sent to hosting
            return await GenJsonBodyRequestAsync(new JsonBackOfficeMapping(clsJsonBackOffice), functionId,
                userSessions.Ssesionid,
                EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, userSessions.Usrid.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return string.Empty;
        }
    }

    private static string TransRuleKey(string txcode)
    {
        return O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + "." +
                                           GlobalVariable.O9_GLOBAL_MEMCACHED_KEY.RuleFunc + "." + txcode.ToUpper());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="txcode"></param>
    /// <param name="rule_name"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<JToken> ExecuteRuleFuncAsync(string txcode, string rule_name, dynamic data)
    {
        // get query info first 
        string _rules = TransRuleKey(txcode);
        List<JsonRuleFunc> clsJsonRuleFuncList = O9Utils.JSONDeserializeObject<List<JsonRuleFunc>>(_rules);
        if (clsJsonRuleFuncList != null)
        {
            foreach (var rf in clsJsonRuleFuncList)
            {
                if (rf.FUNC.Equals(rule_name.ToUpper()))
                {
                    if (rf.RULE.Equals("GET_INFO"))
                    {
                        var result = await GetInfoExecuteAsync(rf.QUERY, rf.RELF, data);
                        return JToken.FromObject(result);
                    }

                    //if (rf.RULE.Equals("GET_SIG"))
                    //{
                    //    var result = await GetSignatureExecute(data);
                    //    return result.ToString(); // Chuyển kết quả thành chuỗi
                    //}
                    if (rf.RULE.Equals("LKP_DATA"))
                    {
                        var result = await LookupDataExecuteAsync(rf.QUERY, rf.RELF, data);
                        return result;
                    }
                }
            }
        }

        return null;
    }

    private async Task<JObject> GetInfoExecuteAsync(string query, string fields, dynamic data)
    {
        if (!String.IsNullOrEmpty(query)) query = O9Utils.GenQuery(query, data);
        O9Utils.ConsoleWriteLine(query);
        JObject jsRequest = new JObject();
        bool isArray = false;
        string proc = "UTIL_GET_INFO";
        try
        {
            jsRequest.Add("Q", query);
            jsRequest.Add("R", fields);
            jsRequest.Add("I", isArray);

            string strResult = await GenJsonBodyRequestAsync(jsRequest, proc);

            if (!String.IsNullOrEmpty(strResult))
            {
                JsonFrontOffice fo = O9Utils.AnalysisFrontOfficeResult(strResult);
                return fo.RESULT.ConvertListDateStringToLong();
            }

            return new JObject();
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="fields"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private async Task<JToken> LookupDataExecuteAsync(string query, string fields, dynamic data)
    {
        if (!String.IsNullOrEmpty(query)) query = O9Utils.GenQuery(query, data);
        O9Utils.ConsoleWriteLine(query);

        try
        {
            SearchFunc sf = new SearchFunc();
            sf = await GenAdvanceSearchAsync("LKP_DATA", "SYS");
            JObject js = data;
            int page = 0;
            string term = string.Empty;
            string strSql = query;
            if (js != null)
            {
                if (js.HasValues)
                {
                    page = js.GetValues<int>("page");
                    js.Remove("page");
                    if (js.ContainsKey("term"))
                    {
                        term = js.GetValues<string>("term");
                        js.Remove("term");
                    }

                    if (!string.IsNullOrEmpty(term))
                    {
                        string[] columns = O9Utils.GetAttributeFieldNames(query);
                        strSql = O9Utils.MergeQuery(query, columns, term);
                    }
                }
            }

            JToken result = await SearchAsync(strSql, page);
            if (result.SelectToken("data") == null || !result.SelectToken("data").HasValues)
            {
                result["data"] = new JArray();
            }

            JToken dataSearch = result.SelectToken("data");
            //dataSearch = RenameFields(dataSearch);

            return result;
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchFunc"></param>
    /// <param name="module"></param>
    /// <returns></returns>
    public async Task<SearchFunc> GenAdvanceSearchAsync(string searchFunc, string module)
    {
        try
        {
            JsonSearch clsJsonSearch = new JsonSearch()
            {
                F = searchFunc,
                M = module,
                C = O9Constants.O9_CONSTANT_COMCODE
            };
            string strResult = await GenJsonBodyRequestAsync(clsJsonSearch, "UTIL_GEN_SEARCH_ADVANCED");
            if (String.IsNullOrEmpty(strResult)) return null;
            JObject js = JObject.Parse(strResult);
            SearchFunc sf = new SearchFunc(); //O9Utils.JSONDeserializeObject<SearchFunc>(js.ToUpperKey().ToString());  
            sf.STORV = js.Value<string>("storv");
            sf.DTNAME = js.Value<string>("dtname");
            List<JsonSearchFtag> lstftag = new List<JsonSearchFtag>();
            foreach (var item in js.GetValue("lstsft").Children())
            {
                JsonSearchFtag sftag = new JsonSearchFtag()
                {
                    FTAG = item.Value<string>("ftag"),
                    FTYPE = item.Value<string>("ftype"),
                    INPTYPE = item.Value<string>("inptype"),
                    CAPTION = item.Value<JObject>("caption"),
                    INCDT = item.Value<bool>("incdt"),
                    INSELECT = item.Value<bool>("inselect"),
                    VISIBLE = item.Value<bool>("visible"),
                    ORD = item.Value<int>("ord")
                };
                lstftag.Add(sftag);
            }

            sf.LSTSFT = lstftag;
            return sf;
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<JToken> SearchAsync(string sql, int page = 0)
    {
        string proc = "UTIL_SEARCH_DATA";
        string hsql = "";

        try
        {
            JObject jsCondition = new JObject
            {
                { "S", sql },
                { "H", hsql },
                { "L", "en" },
                { "P", page }
            };

            string strResult = await GenJsonBodyRequestAsync(jsCondition, proc);
            if (!string.IsNullOrEmpty(strResult))
            {
                JToken data = JToken.Parse(strResult).SelectToken("0");

                JsonSerializerSettings js = new JsonSerializerSettings() { DateFormatString = "dd/MM/yyyy" };
                object o = JsonConvert.DeserializeObject<object>(strResult, new JsonConverterCore());

                JObject result = new()
                {
                    { "data", data }
                };

                if (page == 1)
                {
                    JToken pg = JToken.Parse(strResult).SelectToken("T");

                    JObject jPaging = O9Utils.CreatePaging(pg, page);
                    result.Add("paging", jPaging);
                }

                return result;
            }

            return null;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.StackTrace);
            throw new Exception("Search");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clsJsonData"></param>
    /// <param name="functionId"></param>
    /// <returns></returns>
    public async Task<string> GenJsonDataRequestAsync(object clsJsonData, string functionId)
    {
        try
        {
            if (clsJsonData == null) return "";

            string strResult = await GenJsonBodyRequestAsync(clsJsonData, functionId);

            if (!string.IsNullOrEmpty(strResult) && strResult.EndsWith(","))
            {
                strResult = strResult.TrimEnd(',');
            }

            return strResult;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchFunc"></param>
    /// <param name="currentModules"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<JToken> RuleFuncAsync(string searchFunc, string currentModules,
        IEnumerable<KeyValuePair<string, object>> condition = null)
    {
        var clsJsonSearch = new JsonSearch
        {
            F = searchFunc.ToUpper(),
            M = currentModules.ToUpper(),
            C = "O9"
        };

        var strResult = await GenJsonBodyRequestAsync(clsJsonSearch, "UTIL_GEN_SEARCH_ADVANCED", "");
        if (!string.IsNullOrEmpty(strResult))
        {
            var m_searchFunc = JsonConvert.DeserializeObject<SearchFunc>(strResult);
            m_searchFunc.ToJObject();
            var sqlQuery = "";
            if (condition == null)
            {
                sqlQuery = m_searchFunc.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery,
                    string.Empty, true);
            }
            else
            {
                sqlQuery = m_searchFunc.GenSearchCommonSql(condition, O9Constants.O9_CONSTANT_AND);
            }
            var result = await SearchAsync(sqlQuery, 0);
            result = m_searchFunc.SearchData(result);
            return result;
        }
        throw new Exception("Error RuleFunc Null Data");
    }
}
