using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IWebSocketsService
{
    // Task DeleteAllOtherSession(string session_webui);
    // Task DeleteSession(string session_webui);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <param name="socket"></param>
    /// <returns></returns>
    Task Receiving(string session_webui, WebSocket socket);
    // Task ServerSendToClient(string token_webui, string info);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendMessageWithToken(string token, string message);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendMessageAsyncInternal(string token, string message);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    Task SendMessageAllExceptToken(string token, string message);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    string FindInstanceIdByToken(string token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ssid"></param>
    /// <returns></returns>
    string FindSessionBySSID(string ssid);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sSid"></param>
    /// <param name="token"></param>
    /// <param name="userid"></param>
    /// <returns></returns>
    Task AddSSIDToRedis(string sSid, int userid, string token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    Task AddContextUserLogin(string session_webui, string context);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <returns></returns>
    Task<string> GetContextUserLogin(string session_webui);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T GetObject<T>(string key);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    void GetObject<T>(string key, T value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool Remove(string key);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="substring"></param>
    void DeleteKeysWithSubstring(string substring);
}
