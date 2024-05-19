using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IUserSessionsService

{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userSession"></param>
    /// <returns></returns>
    Task Insert(UserSessions userSession);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task UpdateSessionMac(string token, string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="activeOnly"></param>
    /// <returns></returns>
    Task<UserSessions> GetByToken(string token, bool activeOnly = true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    Task UpdateInfo(string token, string info);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task UpdateSessionMacAndApplicationCode(string token, string mac, string applicationCode);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task UpdateSessionAndApplicationCode(string token, string applicationCode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="acttype"></param>
    /// <returns></returns>
    Task UpdateActtype(string token, string acttype);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    Task UpdateSessionAndInfo(string token, string info);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task DeleteToken(string token);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="applicationCode"></param>
    /// <param name="currentToken"></param>
    /// <returns></returns>
    Task DeleteAllAppToken(string userId, string applicationCode, string currentToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<UserSessions> GetListUserSessionByLoginNameAndEqualMac(string loginName, string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<List<UserSessions>> GetListUserSessionByLoginNameAndNotEqualMac(string loginName, string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task DeleteAllById(string userId);
}
