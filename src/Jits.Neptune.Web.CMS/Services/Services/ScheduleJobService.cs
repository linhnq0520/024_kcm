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
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// ScheduleJob service
/// </summary>
public partial class ScheduleJobService : IScheduleJobService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<ScheduleJob> _ScheduleJobRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="ScheduleJobRepository"></param>

    public ScheduleJobService(ILocalizationService localizationService,
        IRepository<ScheduleJob> ScheduleJobRepository)
    {
        _localizationService = localizationService;
        _ScheduleJobRepository = ScheduleJobRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    public virtual async Task<ScheduleJob> GetById(int id)
    {
        return await _ScheduleJobRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual async Task<ScheduleJob> GetByAppAndId(string app, int id)
    {
        return await _ScheduleJobRepository.Table.Where(s => s.ApplicationCode == app && s.Id == id).FirstOrDefaultAsync();
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;ScheduleJobModel&gt;.</returns>
    public virtual async Task<List<ScheduleJobModel>> GetByApp(string app)
    {
        try
        {
            var getScheduleJob = await _ScheduleJobRepository.Table.Where(s => s.ApplicationCode.Equals(app)).Select(
                s => new ScheduleJobModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    ContentRun = s.ContentRun,
                    Status = s.Status,
                    Time = s.Time,
                    Type = s.Type,
                    ApplicationCode = s.ApplicationCode
                }
            ).ToListAsync();
            if (getScheduleJob == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_ScheduleJob_ERR_0000000"));

            // var ScheduleJobModel = getScheduleJob.ToModel<ScheduleJobModel>();
            // var ScheduleJobDictionary = Utils.Utils.ToDictionary(getScheduleJob);

            return getScheduleJob;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("GetByApp=Exception=getScheduleJob=" + ex.StackTrace);

            // TODO
        }
        return null;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    public virtual async Task Insert(ScheduleJob ScheduleJob)
    {
        await _ScheduleJobRepository.Insert(ScheduleJob);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    public virtual async Task Update(ScheduleJob ScheduleJob)
    {
        await _ScheduleJobRepository.Update(ScheduleJob);
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;ScheduleJob&gt;.</returns>
    public virtual async Task<ScheduleJob> DeleteByAppAndScheduleJob(string app, string ScheduleJob)
    {
        await Task.CompletedTask;
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<ScheduleJob>> GetAll()
    {
        return await _ScheduleJobRepository.Table.ToListAsync();
    }


}
