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
public partial interface IScheduleJobService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    Task<ScheduleJob> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<ScheduleJob>> GetAll();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ScheduleJob> GetByAppAndId(string app, int id);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    Task<List<ScheduleJobModel>> GetByApp(string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ScheduleJob"></param>
    /// <returns></returns>
    Task Insert(ScheduleJob ScheduleJob);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    Task Update(ScheduleJob ScheduleJob);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    Task<ScheduleJob> DeleteByAppAndScheduleJob(string app, string ScheduleJob);

}
