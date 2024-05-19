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
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Services;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// ShortcutConfig service
/// </summary>
public partial class ShortcutConfigService : IShortcutConfigService
{
    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<ShortcutConfig> _shortcutConfigRepository;

    #endregion

    #region Ctor
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="ShortcutConfigRepository"></param>

    public ShortcutConfigService(
        ILocalizationService localizationService,
        IRepository<ShortcutConfig> ShortcutConfigRepository
    )
    {
        _localizationService = localizationService;
        _shortcutConfigRepository = ShortcutConfigRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    public virtual async Task<ShortcutConfig> GetById(int id)
    {
        return await _shortcutConfigRepository.GetById(id);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="shortcut_id"></param>
    /// <param name="user_id"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<ShortcutConfigModel> GetBy_Id_UserId_App(
        string shortcut_id,
        int user_id,
        string app
    )
    {
        var getShortcutConfig = await _shortcutConfigRepository.Table
            .Where(
                s =>
                    s.App.Equals(app)
                    && s.UserId.Equals(user_id.ToString())
                    && s.ShortcutId.Equals(shortcut_id)
            )
            .Select(
                s =>
                    new ShortcutConfigModel
                    {
                        Id = s.Id,
                        App = s.App,
                        FormCode = s.FormCode,
                        Name = s.Name,
                        UserId = s.UserId,
                        ShortcutId = s.ShortcutId,
                        Keystrokes = s.Keystrokes
                    }
            )
            .FirstOrDefaultAsync();

        return getShortcutConfig;
    }

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    public virtual async Task<List<ShortcutConfig>> GetByApp(string app)
    {
        return await _shortcutConfigRepository.Table.Where(s => s.App.Equals(app)).ToListAsync();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="user_id"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<List<ShortcutConfigModel>> GetByUserIdAndApp(int user_id, string app)
    {
        return await _shortcutConfigRepository.Table
            .Where(
                s =>
                    s.App.Equals("sys")
                    || (s.App.Equals(app) && s.UserId.Equals(user_id.ToString()))
                    || (s.App.Equals(app) && (s.UserId.Equals("") || s.UserId == null))
            )
            .Select(
                s =>
                    new ShortcutConfigModel
                    {
                        App = s.App,
                        FormCode = s.FormCode,
                        Name = s.Name,
                        UserId = s.UserId,
                        ShortcutId = s.ShortcutId,
                        Keystrokes = s.Keystrokes
                    }
            )
            .ToListAsync();
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<ShortcutConfig>> GetAll()
    {
        return await _shortcutConfigRepository.Table.ToListAsync();
    }

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    public virtual async Task Insert(ShortcutConfig ShortcutConfig)
    {
        var findShortcutConfig = await _shortcutConfigRepository.Table
            .Where(
                s =>
                    s.App.Equals(ShortcutConfig.App)
                    && s.ShortcutId.Equals(ShortcutConfig.ShortcutId)
            )
            .FirstOrDefaultAsync();
        if (findShortcutConfig == null)
            await _shortcutConfigRepository.Insert(ShortcutConfig);
    }

    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    public virtual async Task Update(ShortcutConfig ShortcutConfig)
    {
        await _shortcutConfigRepository.Update(ShortcutConfig);
    }

    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;ShortcutConfig&gt;.</returns>
    public virtual async Task<ShortcutConfig> Delete(string tx_code, string app)
    {
        await Task.CompletedTask;
        return null;
    }
}
