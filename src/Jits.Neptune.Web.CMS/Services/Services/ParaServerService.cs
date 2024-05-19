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
/// ParaServer service
/// </summary>
public partial class ParaServerService : IParaServerService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<ParaServer> _ParaServerRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="ParaServerRepository"></param>

    public ParaServerService(ILocalizationService localizationService,
        IRepository<ParaServer> ParaServerRepository)
    {
        _localizationService = localizationService;
        _ParaServerRepository = ParaServerRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    public virtual async Task<ParaServer> GetById(int id)
    {
        return await _ParaServerRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public virtual async Task<ParaServer> GetByAppAndCode(string app, string code)
    {
        return await _ParaServerRepository.Table.Where(s => s.App == app && s.Code == code).FirstOrDefaultAsync();
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;ParaServerModel&gt;.</returns>
    public virtual async Task<List<ParaServerModel>> GetByApp(string app)
    {
        try
        {
            var getParaServer = await _ParaServerRepository.Table.Where(s => s.App.Equals(app)).Select(
                s => new ParaServerModel
                {
                    Code = s.Code,
                    Des = s.Des,
                    Value = s.Value,
                    DataType = s.Data_Type,
                    IsAdmin = s.Isadmin,
                    App = s.App
                }
            ).ToListAsync();
            if (getParaServer == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_ParaServer_ERR_0000000"));

            // var ParaServerModel = getParaServer.ToModel<ParaServerModel>();
            // var ParaServerDictionary = Utils.Utils.ToDictionary(getParaServer);

            return getParaServer;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("GetByApp=Exception=getParaServer=" + ex.StackTrace);

            // TODO
        }
        return null;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    public virtual async Task Insert(ParaServer ParaServer)
    {
        await _ParaServerRepository.Insert(ParaServer);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    public virtual async Task Update(ParaServer ParaServer)
    {
        await _ParaServerRepository.Update(ParaServer);
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;ParaServer&gt;.</returns>
    public virtual async Task<ParaServer> DeleteByAppAndParaServer(string app, string ParaServer)
    {
        await Task.CompletedTask;
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<ParaServer>> GetAll()
    {
        return await _ParaServerRepository.Table.ToListAsync();
    }


}
