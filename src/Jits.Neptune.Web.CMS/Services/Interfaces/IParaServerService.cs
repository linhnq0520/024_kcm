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
public partial interface IParaServerService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;ParaServer&gt;.</returns>
    Task<ParaServer> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<ParaServer>> GetAll();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    Task<ParaServer> GetByAppAndCode(string app, string code);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    Task<List<ParaServerModel>> GetByApp(string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ParaServer"></param>
    /// <returns></returns>
    Task Insert(ParaServer ParaServer);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    Task Update(ParaServer ParaServer);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    Task<ParaServer> DeleteByAppAndParaServer(string app, string ParaServer);

}
