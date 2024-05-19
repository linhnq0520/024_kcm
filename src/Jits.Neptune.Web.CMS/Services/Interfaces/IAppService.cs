using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IAppService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;Bo&gt;.</returns>
    Task<App> GetById(int id);
/// <summary>
/// 
/// </summary>
/// <param name="appEntity"></param>
/// <returns></returns>
    AppModel ToModel(App appEntity);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageSearch"></param>
    /// <returns></returns>
    Task<App> ToAppEntity(JToken pageSearch);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    Task<List<AppModel>> GetAll();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="appCode"></param>
    /// <returns></returns>
    Task<AppModel> GetByAppCode(string appCode);

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    Task Insert(App app);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    Task Update(App app);

}
