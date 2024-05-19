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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IShortcutConfigService
{
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    Task<ShortcutConfig> GetById(int id);

    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    Task<ShortcutConfigModel> GetBy_Id_UserId_App(string shortcut_id, int user_id, string app);

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    Task<List<ShortcutConfig>> GetByApp(string app);

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task<List<ShortcutConfig>> GetAll();

    /// <summary>
    ///
    /// </summary>
    /// <param name="user_id"></param>
    ///  <param name="app"></param>
    /// <returns></returns>
    Task<List<ShortcutConfigModel>> GetByUserIdAndApp(int user_id, string app);

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    Task Insert(ShortcutConfig ShortcutConfig);

    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    Task Update(ShortcutConfig ShortcutConfig);

    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    Task<ShortcutConfig> Delete(string tx_code, string app);
}
