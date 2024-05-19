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

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// 
/// </summary>
public class CommonAccountMappingController : BaseController
{
    private readonly IActCommonAccountMappingService _actCommonAccountMappingService = EngineContext.Current.Resolve<IActCommonAccountMappingService>();

    /// <summary>
    /// 
    /// </summary>
    public CommonAccountMappingController()
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
        var result = await _actCommonAccountMappingService.SimpleSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AdvancedSearch([FromBody] ActCommonAccountMappingSearch model)
    {
        var result = await _actCommonAccountMappingService.AdvancedSearch(model);
        return Ok(result);
    }
}

