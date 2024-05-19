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
using Jits.Neptune.Web.CMS.Services;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// OrganizationParameter service
/// </summary>
public partial class OrganizationParameterService : IOrganizationParameterService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<OrganizationParameter> _OrganizationParameterRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="OrganizationParameterRepository"></param>

    public OrganizationParameterService(ILocalizationService localizationService,
        IRepository<OrganizationParameter> OrganizationParameterRepository)
    {
        _localizationService = localizationService;
        _OrganizationParameterRepository = OrganizationParameterRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;OrganizationParameter&gt;.</returns>
    public virtual async Task<OrganizationParameter> GetById(int id)
    {
        return await _OrganizationParameterRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="org"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public virtual async Task<OrganizationParameterModel> GetByOrgAndCode(string org, string code)
    {
        return await _OrganizationParameterRepository.Table.Where(s => s.OrganizationCode.Equals(org) && s.ParamaterCode.Equals(code)).Select(s => s.ToModel<OrganizationParameterModel>()).FirstOrDefaultAsync();
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;OrganizationParameterModel&gt;.</returns>
    public virtual async Task<List<OrganizationParameterModel>> GetByOrg(string org)
    {
        try
        {
            var getOrganizationParameter = await _OrganizationParameterRepository.Table.Where(s => s.OrganizationCode == org).Select(
                s => s.ToModel<OrganizationParameterModel>()
            ).ToListAsync();
            if (getOrganizationParameter == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_OrganizationParameter_ERR_0000000"));

            // var OrganizationParameterModel = getOrganizationParameter.ToModel<OrganizationParameterModel>();
            // var OrganizationParameterDictionary = Utils.Utils.ToDictionary(getOrganizationParameter);

            return getOrganizationParameter;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("GetByApp=Exception=getOrganizationParameter=" + ex.StackTrace);

            // TODO
        }
        return null;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;OrganizationParameter&gt;.</returns>

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;OrganizationParameter&gt;.</returns>
    public virtual async Task Insert(OrganizationParameter OrganizationParameter)
    {
        await Task.CompletedTask;
        return;
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;OrganizationParameter&gt;.</returns>
    public virtual async Task<OrganizationParameter> Update(OrganizationParameter OrganizationParameter)
    {
        await Task.CompletedTask;
        return null;
    }



}
