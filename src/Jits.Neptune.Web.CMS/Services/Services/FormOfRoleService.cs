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
using Jits.Neptune.Web.CMS.Services;
using System.Text;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.GrpcServices;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// FormOfRole service
/// </summary>
public partial class FormOfRoleService : IFormOfRoleService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<FormOfRole> _FormOfRoleRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="FormOfRoleRepository"></param>

    public FormOfRoleService(ILocalizationService localizationService,
        IRepository<FormOfRole> FormOfRoleRepository)
    {
        _localizationService = localizationService;
        _FormOfRoleRepository = FormOfRoleRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;FormOfRole&gt;.</returns>
    public virtual async Task<FormOfRole> GetById(int id)
    {
        return await _FormOfRoleRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;FormOfRoleModel&gt;.</returns>
    public virtual async Task<List<FormOfRoleModel>> GetByRoleId(int roleId, string app)
    {

        try
        {
            var getFormOfRole = await _FormOfRoleRepository.Table.Where(s => s.RoleId == roleId && s.App == app).Select(s => new FormOfRoleModel
            {
                RoleId = roleId,
                App = app,
                Form = s.Form,
                AccessForm = s.AccessForm
            }).ToListAsync();
            if (getFormOfRole == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_FormOfRole_ERR_0000000"));

            return getFormOfRole;
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
    /// <param name="FormOfRole"></param>
    /// <returns></returns>
    public virtual async Task Insert(FormOfRole FormOfRole)
    {
        var findForm = await _FormOfRoleRepository.Table.Where(s => s.App.Equals(FormOfRole.App) && s.Form.Equals(FormOfRole.Form) && s.RoleId.Equals(FormOfRole.RoleId)).FirstOrDefaultAsync();
        if (findForm == null)
            await _FormOfRoleRepository.Insert(FormOfRole);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;FormOfRole&gt;.</returns>
    public virtual async Task<FormOfRole> Update(FormOfRole FormOfRole)
    {
        await Task.CompletedTask;
        return null;
    }

}
