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
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// Fo service
/// </summary>
public partial class FoService : IFoService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<Fo> _FoRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="FoRepository"></param>

    public FoService(ILocalizationService localizationService,
        IRepository<Fo> FoRepository)
    {
        _localizationService = localizationService;
        _FoRepository = FoRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    public virtual async Task<Fo> GetById(int id)
    {
        return await _FoRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;FoModel&gt;.</returns>
    public virtual async Task<FoModel> GetByTxcodeAndApp(string tx_code, string app)
    {
        var getFo = await _FoRepository.Table.Where(s => s.Txcode.Equals(tx_code) && s.App.Equals(app)).FirstOrDefaultAsync();
        if (getFo == null) return null;

        var foModel = getFo.ToModel<FoModel>();
        foModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(getFo.Input);
        foModel.Actions = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(getFo.Actions);
        foModel.Request = JsonConvert.DeserializeObject<Dictionary<string, object>>(getFo.Request);

        return foModel;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<List<FoModel>> GetByApp(string app)
    {
        List<FoModel> result = new List<FoModel>();
        var getAll = await _FoRepository.Table.Where(s => s.App.Equals(app)).ToListAsync();
        foreach (var item in getAll)
        {
            var itemModel = item.ToModel<FoModel>();
            itemModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Input);
            itemModel.Actions = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(item.Actions);
            itemModel.Request = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Request);
            result.Add(itemModel);
        }
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="foModel"></param>
    /// <returns></returns>
    public virtual Fo ToEntity(FoModel foModel)
    {
        var foEntity = new Fo();
        foEntity = foModel.ToEntity(foEntity);
        foEntity.Input = JsonConvert.SerializeObject(foModel.Input);
        foEntity.Actions = JsonConvert.SerializeObject(foModel.Actions);
        foEntity.Request = JsonConvert.SerializeObject(foModel.Request);

        return foEntity;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="foEntity"></param>
    /// <returns></returns>
    public virtual FoModel ToModel(Fo foEntity)
    {
        var foModel = foEntity.ToModel<FoModel>();
        foModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(foEntity.Input);
        foModel.Actions = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(foEntity.Actions);
        foModel.Request = JsonConvert.DeserializeObject<Dictionary<string, object>>(foEntity.Request);

        return foModel;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<FoModel>> GetAll()
    {
        List<FoModel> result = new List<FoModel>();
        var getAll = await _FoRepository.Table.ToListAsync();
        foreach (var item in getAll)
        {
            var itemModel = item.ToModel<FoModel>();
            itemModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Input);
            itemModel.Actions = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(item.Actions);
            itemModel.Request = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Request);
            result.Add(itemModel);
        }
        return result;
    }

    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    public virtual async Task<List<FoModel>> SearchByApp(string app)
    {
        await Task.CompletedTask;
        return null;
    }
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    public virtual async Task Insert(Fo fo)
    {
        var findForm = await _FoRepository.Table.Where(s => s.App.Equals(fo.App) && s.Txcode.Equals(fo.Txcode)).FirstOrDefaultAsync();
        if (findForm == null)
            await _FoRepository.Insert(fo);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    public virtual async Task Update(Fo fo)
    {
        await _FoRepository.Update(fo);
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Fo&gt;.</returns>
    public virtual async Task<Fo> Delete(string tx_code, string app)
    {
        await Task.CompletedTask;
        return null;
    }


}
