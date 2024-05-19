using Apache.NMS;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public interface IO9ClientService
{
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
    Task<string> GenJsonBodyRequestAsync(object objJsonBody,
        string functionId, string sessionid = "",
        EnmCacheAction isResultCaching = EnmCacheAction.NoCached,
        EnmSendTypeOption sendtype = EnmSendTypeOption.Synchronize,
        string usrId = "-1",
        MsgPriority priority = MsgPriority.Normal);

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
    Task<string> GenJsonBackOfficeRequestAsync(UserSessions userSessions, string pTXCODE, List<JsonData> pTXBODY,
        string functionId = "", EnmCacheAction isCaching = EnmCacheAction.NoCached,
        string pSTATUS = "C", string pTXREFID = null,
        string pVALUEDT = null, string pUSRWS = "",
        object pAPUSER = null, string pAPUSRIP = "",
        string pAPUSRWS = "", string pAPDT = "",
        string pISREVERSE = "N", int pHBRANCHID = 0,
        int pRBRANCHID = 0, string pAPREASON = null,
        string pPRN = "");

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
    Task<string> GenJsonFrontOfficeRequestAsync(UserSessions user, string ptxcode, JObject ptxbody,
        string functionId = "", EnmCacheAction isResultCaching = EnmCacheAction.NoCached,
        string pstatus = "C", string ptxrefid = null, string pvaluedt = null, JObject pifcfee = null,
        string pusrws = null, object papuser = null, string papusrip = null, string papusrws = null,
        string papdt = null, string pisreverse = "N", int? phbranchid = null, int? prbranchid = null,
        string papreason = null, JsonPosting pposting = null, string pprn = null,
        string pid = null, bool isMapping = true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="txcode"></param>
    /// <param name="rule_name"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<JToken> ExecuteRuleFuncAsync(string txcode, string rule_name, dynamic data);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clsJsonData"></param>
    /// <param name="functionId"></param>
    /// <returns></returns>
    Task<string> GenJsonDataRequestAsync(object clsJsonData, string functionId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    Task<JToken> SearchAsync(string sql, int page = 0);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchFunc"></param>
    /// <param name="currentModules"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    Task<JToken> RuleFuncAsync(string searchFunc, string currentModules,
        IEnumerable<KeyValuePair<string, object>> condition = null);

}
