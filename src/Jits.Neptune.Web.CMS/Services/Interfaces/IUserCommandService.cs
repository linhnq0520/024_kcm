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
public partial interface IUserCommandService

{


    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task<List<GrpcServices.CommandIdInfoModel>> GetAllUserCommandModel(string applicationCode);

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task<List<UserCommands>> GetAllUserCommands(string applicationCode);


    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    Task<List<GrpcServices.CommandIdInfoModel>> GetUserCommandInfoFromParentId(string applicationCode, string parentId);

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="commandId"></param>
    /// <returns></returns>
    Task<List<GrpcServices.CommandIdInfoModel>> GetUserCommandInfoFromCommandId(string applicationCode, string commandId);

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="formCode"></param>
    /// <returns></returns>
    Task<List<UserCommands>> GetUserCommandInfoFromFormCode(string applicationCode, string formCode);

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<List<GrpcServices.CommandIdInfoModel>> GetUserCommandInfoFromRoleId(string applicationCode, string roleId);
}
