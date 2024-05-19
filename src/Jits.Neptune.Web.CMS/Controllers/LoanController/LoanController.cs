using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using LinqToDB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ClearScript.Util.Web;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// The loan controller class
/// </summary>
/// <seealso cref="BaseController"/>
[Route("api/")]
public class LoanController : BaseController
{
    /// <summary>
    /// The memory cache
    /// </summary>
    private readonly IMemoryCache _memoryCache;
    /// <summary>
    /// The credit service
    /// </summary>
    private readonly ICreditCatalogService _creditService;

    /// <summary>
    /// 
    /// </summary>
    
    public LoanController(ICreditCatalogService creditService, IMemoryCache memoryCache)
    {
        _creditService = creditService;
        _memoryCache = memoryCache;
    }

    /// <summary>
    /// Tests the throw
    /// </summary>
    /// <returns>The action result</returns>
    [HttpPost("TestThrow")]
    public IActionResult TestThrow()
    {
        throw new NeptuneException($"Workflow not found in Database!");
    }
 
    
    /// <summary>
    /// Simples the rule func
    /// </summary>
    /// <returns>The action result</returns>
    [HttpPost("SimpleRuleFunc")]
     public IActionResult SimpleRuleFunc()
    {

        var obj = new JObject();
        obj.Add("CCTMCD", "00011000419");
        obj.Add("CCTMT","C");

        var a = O9Utils.ExecuteRuleFunc("DPT_OPN", "GET_INFO_CACNM", obj);
         return Ok("");
     }
    
}