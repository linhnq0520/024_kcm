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
public partial interface IFormService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;Form&gt;.</returns>
    Task<Form> GetById(int id);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    Task<FormModel> GetByIdAndApp(string formCode, string app);
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    Task<List<FormModel>> GetByApp(string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<List<RoleCacheModel>> GetRoleCacheByApp(string app);
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    Task Insert(Form Form);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    Task Update(Form Form);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    Task Delete(string tx_code, string app);

}
