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
/// LearnApi service
/// </summary>
public partial class LearnApiService : ILearnApiService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<LearnApi> _LearnApiRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="LearnApiRepository"></param>

    public LearnApiService(ILocalizationService localizationService,
        IRepository<LearnApi> LearnApiRepository)
    {
        _localizationService = localizationService;
        _LearnApiRepository = LearnApiRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>
    public virtual async Task<LearnApi> GetById(int id)
    {
        return await _LearnApiRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;LearnApiModel&gt;.</returns>
    public virtual async Task<LearnApiModel> GetByAppAndId(string app, string learnApiId)
    {
        try
        {
            var getLearnApi = await _LearnApiRepository.Table.Where(s => s.App.Equals(app.Trim()) && s.LearnApiId.Equals(learnApiId.Trim())).FirstOrDefaultAsync();

            if (getLearnApi == null)
                return null;

            // var LearnApiModel = getLearnApi.ToModel<LearnApiModel>();
            // var LearnApiDictionary = Utils.Utils.ToDictionary(getLearnApi);

            return getLearnApi.ToModel<LearnApiModel>();
        }
    
        catch (System.Exception ex)
        {
            System.Console.WriteLine("GetByApp=Exception=getLearnApi=" + ex.StackTrace);

            // TODO
        }
        return null;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>
    public virtual async Task Insert(LearnApi LearnApi)
    {
        var findForm = await _LearnApiRepository.Table.Where(s => s.App.Equals(LearnApi.App) && s.LearnApiId.Equals(LearnApi.LearnApiId)).FirstOrDefaultAsync();
        if (findForm == null)
            await _LearnApiRepository.Insert(LearnApi);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<List<LearnApiModel>> GetByApp(string app)
    {
        return await _LearnApiRepository.Table.Where(s => s.App.Equals(app.Trim())).Select(s => s.ToModel<LearnApiModel>()).ToListAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<LearnApiModel>> GetAll()
    {
        return await _LearnApiRepository.Table.Select(s=>s.ToModel<LearnApiModel>()).ToListAsync();
    }
    ///
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;LearnApi&gt;.</returns>
    public virtual async Task Update(LearnApi LearnApi)
    {
        await _LearnApiRepository.Update(LearnApi);
    }
   /// <summary>
   /// 
   /// </summary>
   /// <param name="app"></param>
   /// <param name="LearnApi"></param>
   /// <returns></returns>
    public virtual async Task<LearnApi> DeleteByAppAndLearnApi(string app, string LearnApi)
    {
        await Task.CompletedTask;
        return null;
    }


}
