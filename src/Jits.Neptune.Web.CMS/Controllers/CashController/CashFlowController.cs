using System;
using System.Threading.Tasks;
using global::Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using global::Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using global::Jits.Neptune.Web.CMS.Models.Request.Cash;
using global::Jits.Neptune.Web.CMS.Models;
using global::Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Services.DepositService.Interface;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService.Interface;
using static LinqToDB.Common.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.Framework.Services.Logging;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/")]
public class CashFlowController : BaseController
{
    private readonly ICashFlowService _contextCatalog = EngineContext.Current.Resolve<ICashFlowService>();

    private readonly IUserSessionsService _userSession = EngineContext.Current.Resolve<IUserSessionsService>();
    /// <summary>
    /// 
    /// </summary>
    public CashFlowController()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost("GetCashDetail")]
    public async Task<IActionResult> CashFlowListDetails([FromBody] CashFlowSearch data)
    {
        await Task.CompletedTask;
        try
        {
            var modelSearch = O9Utils.SearchFunc(data, "CSH_CASH_FLOW");
            var strSql =
                modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, 0);
            var a = System.Text.Json.JsonSerializer.Deserialize<CashFlowSearchResponseModel>(JsonConvert.SerializeObject(result));
            return Ok(a);
        }
        catch (Exception)
        {
            return Ok();
        }
    }
}
