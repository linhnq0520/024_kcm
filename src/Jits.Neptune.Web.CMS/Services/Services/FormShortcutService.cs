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
/// FormShortcut service
/// </summary>
public partial class FormShortcutService : IFormShortcutService
{
    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<FormShortcut> _formShortcutRepository;

    #endregion

    #region Ctor
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="formShortcutRepository"></param>

    public FormShortcutService(
        ILocalizationService localizationService,
        IRepository<FormShortcut> formShortcutRepository
    )
    {
        _localizationService = localizationService;
        _formShortcutRepository = formShortcutRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    public virtual async Task<FormShortcut> GetById(int id)
    {
        return await _formShortcutRepository.GetById(id);
    }

    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;FormShortcutModel&gt;.</returns>
    public virtual async Task<FormShortcutModel> GetByIdAndApp(string formCode, string app)
    {
        System.Console.WriteLine("formCode===" + formCode);
        var getFormShortcut = await _formShortcutRepository.Table
            .Where(s => s.App.Equals(app.Trim()) && s.FormId.Equals(formCode.Trim()))
            .Select(
                s =>
                    new FormShortcutModel
                    {
                        App = app,
                        FormId = formCode,
                        FormName = s.FormName,
                        GroupCode = s.GroupCode
                    }
            )
            .FirstOrDefaultAsync();

        if (getFormShortcut == null)
            throw new NeptuneException(
                await _localizationService.GetResource("CMS_formShortcut_ERR_0000000")
            );

        return getFormShortcut;
    }

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    public virtual async Task<List<FormShortcutModel>> GetByApp(string app)
    {
        return await _formShortcutRepository.Table
            .Where(s => s.App.Equals(app))
            .Select(
                s =>
                    new FormShortcutModel()
                    {
                        FormId = s.FormId,
                        FormName = s.FormName,
                        App = s.App,
                        GroupCode = s.GroupCode
                    }
            )
            .ToListAsync();
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<FormShortcut>> GetAll()
    {
        return await _formShortcutRepository.Table.ToListAsync();
    }

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    public virtual async Task Insert(FormShortcut FormShortcut)
    {
        var findFormShortcut = await _formShortcutRepository.Table.FirstOrDefaultAsync();
        if (findFormShortcut == null)
            await _formShortcutRepository.Insert(FormShortcut);
    }

    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    public virtual async Task Update(FormShortcut FormShortcut)
    {
        await _formShortcutRepository.Update(FormShortcut, "");
    }

    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    public virtual async Task<FormShortcut> Delete(string tx_code, string app)
    {
        await Task.CompletedTask;
        return null;
    }
}
