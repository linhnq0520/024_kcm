using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// ParaServer service
/// </summary>
public partial class UserCommandService : IUserCommandService
{
    private readonly ILocalizationService _localizationService;

    private readonly IRepository<UserCommands> _userCommand;

    private readonly IFormService _formService;

    private readonly IAppOfRoleService _appOfRoleService;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="userCommand"></param>
    /// <param name="formService"></param>
    /// <param name="appOfRoleService"></param>
    public UserCommandService(ILocalizationService localizationService,
        IRepository<UserCommands> userCommand,
        IFormService formService,
        IAppOfRoleService appOfRoleService)
    {
        _localizationService = localizationService;
        _userCommand = userCommand;
        _formService = formService;
        _appOfRoleService = appOfRoleService;
    }

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    public virtual async Task<List<GrpcServices.CommandIdInfoModel>> GetAllUserCommandModel(string applicationCode)
    {

        var result = await (from userCommand in _userCommand.Table
                                .Where(s => s.ApplicationCode == applicationCode && s.Enabled)
                            select new GrpcServices.CommandIdInfoModel()
                            {
                                ParentId = userCommand.ParentId,
                                CommandId = userCommand.CommandId,
                                CommandName = userCommand.CommandName,
                                ApplicationCode = userCommand.ApplicationCode,
                                CommandType = userCommand.CommandType,
                                GroupMenuIcon = userCommand.GroupMenuIcon,
                                GroupMenuVisible = userCommand.GroupMenuVisible,
                                GroupMenuId = userCommand.GroupMenuId,
                                GroupMenuListAuthorizeForm = userCommand.GroupMenuListAuthorizeForm,
                            }).ToListAsync();

        return result;
    }

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    public virtual async Task<List<UserCommands>> GetAllUserCommands(string applicationCode)
    {

        var result = await _userCommand.Table.Where(s => s.ApplicationCode == applicationCode && s.Enabled.Equals(true)).ToListAsync();

        return result;
    }


    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    public virtual async Task<List<GrpcServices.CommandIdInfoModel>> GetUserCommandInfoFromParentId(string applicationCode, string parentId)
    {

        var result = await (from userCommand in _userCommand.Table
                                .Where(s => s.ApplicationCode == applicationCode && s.ParentId == parentId)
                            select new GrpcServices.CommandIdInfoModel()
                            {
                                ParentId = userCommand.ParentId,
                                CommandId = userCommand.CommandId,
                                CommandName = userCommand.CommandName,
                                ApplicationCode = userCommand.ApplicationCode,
                                CommandType = userCommand.CommandType,
                                GroupMenuIcon = userCommand.GroupMenuIcon,
                                GroupMenuVisible = userCommand.GroupMenuVisible,
                                GroupMenuId = userCommand.GroupMenuId,
                                GroupMenuListAuthorizeForm = userCommand.GroupMenuListAuthorizeForm,
                            }).ToListAsync();

        return result;
    }

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="commandId"></param>
    /// <returns></returns>
    public virtual async Task<List<GrpcServices.CommandIdInfoModel>> GetUserCommandInfoFromCommandId(string applicationCode, string commandId)
    {

        var result = await (from userCommand in _userCommand.Table
                                .Where(s => s.ApplicationCode == applicationCode && s.CommandId == commandId)
                            select new GrpcServices.CommandIdInfoModel()
                            {
                                ParentId = userCommand.ParentId,
                                CommandId = userCommand.CommandId,
                                CommandName = userCommand.CommandName,
                                ApplicationCode = userCommand.ApplicationCode,
                                CommandType = userCommand.CommandType,
                                GroupMenuIcon = userCommand.GroupMenuIcon,
                                GroupMenuVisible = userCommand.GroupMenuVisible,
                                GroupMenuId = userCommand.GroupMenuId,
                                GroupMenuListAuthorizeForm = userCommand.GroupMenuListAuthorizeForm,
                            }).ToListAsync();

        return result;
    }

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="formCode"></param>
    /// <returns></returns>
    public virtual async Task<List<UserCommands>> GetUserCommandInfoFromFormCode(string applicationCode, string formCode)
    {

        var formConfig = await _formService.GetByIdAndApp(formCode, applicationCode);
        if (formConfig == null)
            return null;
        var result = await _userCommand.Table.Where(s => s.ApplicationCode == applicationCode && s.GroupMenuId == formCode )
            .ToListAsync();

        return result;
    }

    /// <summary>
    /// Get info from ApplicationCode and RoleId
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public virtual async Task<List<GrpcServices.CommandIdInfoModel>> GetUserCommandInfoFromRoleId(string applicationCode, string roleId)
    {
        var appOfRole = await _appOfRoleService.GetByRoleId(int.Parse(roleId));

        var result = await (from userCommand in _userCommand.Table
                                .Where(s => s.ApplicationCode == applicationCode && appOfRole.App.Contains(applicationCode))
                            select new GrpcServices.CommandIdInfoModel()
                            {
                                ParentId = userCommand.ParentId,
                                CommandId = userCommand.CommandId,
                                CommandName = userCommand.CommandName,
                                ApplicationCode = userCommand.ApplicationCode,
                                CommandType = userCommand.CommandType,
                                GroupMenuIcon = userCommand.GroupMenuIcon,
                                GroupMenuVisible = userCommand.GroupMenuVisible,
                                GroupMenuId = userCommand.GroupMenuId,
                                GroupMenuListAuthorizeForm = userCommand.GroupMenuListAuthorizeForm,
                            }).ToListAsync();
        return result;
    }
}
