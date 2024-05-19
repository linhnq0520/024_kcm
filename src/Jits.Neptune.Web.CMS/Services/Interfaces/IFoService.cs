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
public partial interface IFoService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;Fo&gt;.</returns>
    Task<Fo> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<FoModel>> GetAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="foModel"></param>
    /// <returns></returns>
    Fo ToEntity(FoModel foModel);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="foEntity"></param>
    /// <returns></returns>
    FoModel ToModel(Fo foEntity);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    Task<FoModel> GetByTxcodeAndApp(string tx_code, string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<List<FoModel>> GetByApp(string app);

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    Task<List<FoModel>> SearchByApp(string app);
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    Task Insert(Fo Fo);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    Task Update(Fo Fo);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    Task<Fo> Delete(string tx_code, string app);

}
