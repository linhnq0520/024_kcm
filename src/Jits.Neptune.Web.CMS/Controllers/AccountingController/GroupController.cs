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
public class GroupController : BaseController
{
    private readonly IActGroupService _actGroupService = EngineContext.Current.Resolve<IActGroupService>();

    /// <summary>
    /// 
    /// </summary>
    public GroupController()
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
        var result = await _actGroupService.SimpleSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AdvancedSearch([FromBody] ActGroupDefinitionSearch model)
    {
        var result = await _actGroupService.AdvancedSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] ModelInsertGroupDefinition model)
    {
        var userSessions = new UserSessions
        {
            Usrid = 1051,
            Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",
        };
        await Task.CompletedTask;

        var result = _actGroupService.Create(model, userSessions, "O9SYS.S_ACGRPDEF", "012005001002");
        return Ok(result);
    }
}

