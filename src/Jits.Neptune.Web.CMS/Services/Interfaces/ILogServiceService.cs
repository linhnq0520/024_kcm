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
public partial interface ILogServiceService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;LogService&gt;.</returns>
    Task<LogService> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logService"></param>
    /// <returns></returns>
    LogServiceModel ToLogServiceModel(LogService logService);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="centralizedLog"></param>
    /// <returns></returns>
    Task WriteCentralizedLog(JITS.Neptune.NeptuneClient.Log.CentralizedLog centralizedLog);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;LogService&gt;.</returns>
    Task<List<LogServiceModel>> GetAll();

   /// <summary>
   /// 
   /// </summary>
   /// <param name="subject"></param>
   /// <param name="logText"></param>
   /// <param name="details"></param>
   /// <param name="logType"></param>
   /// <returns></returns>
    Task WriteLog(string subject, string logText, string details = "{}", string logType = "Other");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logService"></param>
    /// <returns></returns>
    Task Insert(LogService logService);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;LogService&gt;.</returns>
    Task<LogService> Update(LogService orgPara);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    void DeleteAll();

}
