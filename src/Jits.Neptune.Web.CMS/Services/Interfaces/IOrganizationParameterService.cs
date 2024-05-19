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
public partial interface IOrganizationParameterService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;OrganizationParameter&gt;.</returns>
    Task<OrganizationParameter> GetById(int id);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;OrganizationParameter&gt;.</returns>
    Task<List<OrganizationParameterModel>> GetByOrg(string org);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="org"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<OrganizationParameterModel> GetByOrgAndCode(string org,string code);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orgPara"></param>
    /// <returns></returns>
    Task Insert(OrganizationParameter orgPara);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;OrganizationParameter&gt;.</returns>
    Task<OrganizationParameter> Update(OrganizationParameter orgPara);
}
