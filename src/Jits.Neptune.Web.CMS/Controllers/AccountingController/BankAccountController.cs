using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Models;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ClearScript.Util.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
///
/// </summary>
public class BankAccountController : BaseController
{
    private readonly IActBankAccountService _actBankAccountService = EngineContext.Current.Resolve<IActBankAccountService>();
    /// <summary>
    /// 
    /// </summary>
    public BankAccountController()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SimpleSearch([FromBody] SimpleSearchModel model)
    {
        var result = await _actBankAccountService.SimpleSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AdvancedSearch([FromBody] ActBankAccountDefinitionSearch model)
    {
        var result = await _actBankAccountService.AdvancedSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="acno"></param>
    /// <returns></returns>
    [HttpPost]
    public ActBankAccountDefinitionViewResponse View([FromBody] string acno)
    {
        var result = _actBankAccountService.ViewByAcno(acno);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] ModelInsertBankAccountDefinition model)
    {
        var userSessions = new UserSessions
        {
            Usrid = 1051,
            Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",
        };
        await Task.CompletedTask;

        var result = _actBankAccountService.Create(model, userSessions, "O9DATA.D_ACCHRT", "012002000002");
        return Ok(result);
    }
}

