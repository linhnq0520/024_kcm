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
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IBoService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;Bo&gt;.</returns>
    Task<Bo> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<BoModel>> GetAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="foModel"></param>
    /// <returns></returns>
    Bo ToEntity(BoModel foModel);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="foEntity"></param>
    /// <returns></returns>
    BoModel ToModel(Bo foEntity);

    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    
    Task<BoModel> GetByTxcodeAndApp(string tx_code, string app);

    /// <summary>
    /// GetByApp
    /// </summary>
    /// <returns></returns>
    Task<List<BoModel>> GetByApp(string app);
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    
    Task<IPagedList<BoModel>> SearchByApp(string app);
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    Task Insert(Bo bo);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    Task Update(Bo bo);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    Task<Bo> Delete(string tx_code, string app);

}
