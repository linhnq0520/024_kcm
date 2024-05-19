using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class WebSocketsController : BaseController
    {
        private readonly ILogger<WebSocketsController> _logger;
        // private WebSocketHandler _websocketHandler { get; set; }
        readonly IWebSocketsService _webSocketsService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="webSocketsService"></param>
        public WebSocketsController(ILogger<WebSocketsController> logger, IWebSocketsService webSocketsService)
        {
            _logger = logger;
            _webSocketsService = webSocketsService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session_webui"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/webchannel/webuisocket/{session_webui}")]
        public async Task GetWebsocket(string session_webui)
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {

                var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                try
                {
                    await _webSocketsService.Receiving(session_webui, webSocket);

                }
                catch (System.Exception ex)
                {
                    // TODO
                    System.Console.WriteLine("GetWebSocket ERROR====" + ex.StackTrace);
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }

        }

    }




}
