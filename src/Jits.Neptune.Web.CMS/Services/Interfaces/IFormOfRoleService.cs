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
public partial interface IFormOfRoleService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;IFormOfRole&gt;.</returns>
    Task<FormOfRole> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<List<FormOfRoleModel>> GetByRoleId(int roleId, string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="FormOfRole"></param>
    /// <returns></returns>
    Task Insert(FormOfRole FormOfRole);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;IFormOfRole&gt;.</returns>
    Task<FormOfRole> Update(FormOfRole FormOfRole);

}
