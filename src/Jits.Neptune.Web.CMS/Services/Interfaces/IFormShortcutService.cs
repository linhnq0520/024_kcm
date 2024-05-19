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
public partial interface IFormShortcutService
{
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    Task<FormShortcut> GetById(int id);

    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    Task<FormShortcutModel> GetByIdAndApp(string FormShortcutCode, string app);

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    Task<List<FormShortcutModel>> GetByApp(string app);

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task<List<FormShortcut>> GetAll();

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    Task Insert(FormShortcut FormShortcut);

    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    Task Update(FormShortcut FormShortcut);

    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;FormShortcut&gt;.</returns>
    Task<FormShortcut> Delete(string tx_code, string app);
}
