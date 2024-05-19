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
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IGroupMenuService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;GroupMenu&gt;.</returns>
    Task<GroupMenu> GetById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
     Task<List<GroupMenuModel>> GetAll();
   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<List<GroupMenuModel>> SearchByApp(string app);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<GroupMenuModel> GetByIdAndApp(string id,string app);
/// <summary>
/// 
/// </summary>
/// <param name="functionCode"></param>
/// <param name="app"></param>
/// <returns></returns>
    Task<GroupMenuModel> GetByFunctionCodeAndApp(string functionCode, string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="formCode"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<GroupMenuModel> GetByAuthorizeFormsAndApp(string formCode, string app);

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    Task Insert(GroupMenu GroupMenu);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    Task Update(GroupMenu GroupMenu);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupMenuModel"></param>
    /// <returns></returns>
    GroupMenu ToEntity(GroupMenuModel groupMenuModel);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupMenuEntity"></param>
    /// <returns></returns>
    GroupMenuModel ToModel(GroupMenu groupMenuEntity);
}
