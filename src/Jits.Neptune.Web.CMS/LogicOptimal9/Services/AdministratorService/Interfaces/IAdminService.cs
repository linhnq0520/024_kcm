using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.O9Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;

/// <summary>
/// Bo Schema Migration
/// </summary>
public partial interface IAdminServices
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    Task<List<RoleOfUser>> GetListRoleByUserId(string userid);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<GetUserAccountByIdResponse> GetUserAccountById(string userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>  
    Task<List<UserCommands>> GetUserCommandByApplicationCode(string applicationCode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    Task<List<CommandIdInfoModel>> GetUserCommandInfoFromParentId(string applicationCode, string parentId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="commandId"></param>
    /// <returns></returns>
    Task<List<CommandIdInfoModel>> GetUserCommandInfoFromCommandId(string applicationCode, string commandId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="formCode"></param>
    /// <returns></returns>
    Task<List<UserCommands>> GetUserCommandInfoFromFormCode(string applicationCode, string formCode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<List<CommandIdInfoModel>> GetUserCommandInfoFromRoleId(string applicationCode, string roleId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<string> CreateOtherToken(string token);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task LockScreen(string token);

    /// <summary>
    /// <param name="token"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    /// </summary>

    Task UpdateSessionApplicationCode(string token, string applicationCode);

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
    /// <param name="acttype"></param>
    /// <returns></returns>
    Task UpdateActtype(string token, string acttype);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<bool> VerifyPassword(string username, string password);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    Task UpdateSessionInfo(string token, string info);


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
    /// <param name="token"></param>
    /// <returns></returns>
    Task<UserSessions> GetSessionByToken(string token);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<ValidateSessionModel> CheckValidSingleSession(string loginName, string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<List<UserSessions>> ListUserSessionByLoginNameAndNotEqualMac(string loginName, string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<CodeList>> GetAllCodeList();
}
