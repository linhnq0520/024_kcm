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
public partial interface ILearnApiService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;LearnApi&gt;.</returns>
    Task<LearnApi> GetById(int id);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>
    Task<LearnApiModel> GetByAppAndId(string app, string learnApiId);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<LearnApiModel>> GetAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<List<LearnApiModel>> GetByApp(string app);

   /// <summary>
   /// 
   /// </summary>
   /// <param name="LearnApi"></param>
   /// <returns></returns>
    Task Insert(LearnApi LearnApi);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>
    Task Update(LearnApi LearnApi);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>
    Task<LearnApi> DeleteByAppAndLearnApi(string app, string LearnApi);

}
