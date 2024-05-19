using System;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.Controllers;


/// <summary>
/// 
/// </summary>
public class UserAccountController : BaseController
{
    private readonly IUserAccountService _userAccountService = EngineContext.Current.Resolve<IUserAccountService>();
    /// <summary>
    /// 
    /// </summary>
    public UserAccountController()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult SimpleSearch([FromBody] SimpleSearchModel model)
    {
        var result = _userAccountService.SimpleSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult ResetTimer()
    {
        if (Singleton<ExecutionTimer>.Instance == null)
        {
            Singleton<ExecutionTimer>.Instance = new ExecutionTimer();
        }
        Singleton<ExecutionTimer>.Instance.ExecutionTime = 0;
        return Ok(Singleton<ExecutionTimer>.Instance);
    }

}