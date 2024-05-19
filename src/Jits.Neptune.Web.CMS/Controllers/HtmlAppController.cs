using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Helpers;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class HtmlAppController : BaseController
{
    #region Fields
    readonly IWebchannelService _webchannelService;
    readonly ILocalizationService _localizationService;
    readonly IPostAPIService _postAPIService;

    #endregion
    /// <summary>
    /// Ctor
    /// </summary>
    public HtmlAppController(IWebchannelService webchannelService, ILocalizationService localizationService, IPostAPIService postAPIService)
    {
        _webchannelService = webchannelService;
        _localizationService = localizationService;
        _postAPIService = postAPIService;
    }

    /// <summary>
    /// Get config-client 
    /// </summary>
    /// <returns>IActionResult.</returns>
    [Route("/app")]
    [HttpGet]
    public virtual async Task<IActionResult> GetReactApp()
    {
        var config_client = await _webchannelService.GetConfigClient();
        return new ContentResult
        {
            Content = "window.mainstart = " + config_client.ToString(),
            ContentType = "text/html"
        };
        // return Ok(config_client);
        // return Ok( "window.mainstart = " + Json(config_client) );
        // return Ok(new { window.mainstart = config_client });
    }

}