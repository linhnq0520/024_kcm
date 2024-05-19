using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// AppOfRole service
/// </summary>
public partial class AppOfRoleService : IAppOfRoleService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<AppOfRole> _AppOfRoleRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="AppOfRoleRepository"></param>
    public AppOfRoleService(ILocalizationService localizationService,
        IRepository<AppOfRole> AppOfRoleRepository)
    {
        _localizationService = localizationService;
        _AppOfRoleRepository = AppOfRoleRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;AppOfRole&gt;.</returns>
    public virtual async Task<AppOfRole> GetById(int id)
    {
        return await _AppOfRoleRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;AppOfRoleModel&gt;.</returns>
    public virtual async Task<AppOfRoleModel> GetByRoleId(int roleId)
    {
        try
        {
            var getAppOfRole = await _AppOfRoleRepository.Table.Where(s => s.RoleId == roleId).FirstOrDefaultAsync();
            if (getAppOfRole == null) return null;

            return getAppOfRole.ToModel<AppOfRoleModel>();
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByRoleId==Exception====" + ex.StackTrace);

        }
        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appOfRole"></param>
    /// <returns></returns>
    public virtual async Task Insert(AppOfRole appOfRole)
    {
        await _AppOfRoleRepository.Insert(appOfRole);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;AppOfRole&gt;.</returns>
    public virtual async Task Update(AppOfRole appOfRole)
    {
        await _AppOfRoleRepository.Update(appOfRole);
    }


}
