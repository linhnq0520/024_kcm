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
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface ILangService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;Lang&gt;.</returns>
    Task<Lang> GetById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lang"></param>
    /// <returns></returns>
    LangModel ToModel(Lang lang);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<Lang> SearchByApp(string app);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    Task<Dictionary<string, object>> GetByApp(string app);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Lang"></param>
    /// <returns></returns>
    Task Insert(Lang Lang);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    Task Update(Lang Lang);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    Task<Lang> DeleteByAppAndLang(string app, string lang);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<string> GetLangMigrate();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="key"></param>
    /// <param name="langData"></param>
    /// <returns></returns>
    Task FindAndSaveLang(string app, string key, JObject langData);


}
