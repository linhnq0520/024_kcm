using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// Bo service
/// </summary>
public partial class BoService : IBoService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<Bo> _boRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="boRepository"></param>

    public BoService(ILocalizationService localizationService,
        IRepository<Bo> boRepository)
    {
        _localizationService = localizationService;
        _boRepository = boRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    public virtual async Task<Bo> GetById(int id)
    {
        return await _boRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<BoModel>> GetAll()
    {
        try
        {
            List<BoModel> result = new List<BoModel>();
            var getAll = await _boRepository.Table.ToListAsync();
            foreach (var item in getAll)
            {
                var itemModel = item.ToModel<BoModel>();
                itemModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Input);
                itemModel.Actions = JsonConvert.DeserializeObject<List<BoAction>>(item.Actions);
                itemModel.Response = JsonConvert.DeserializeObject<ActionsResponseModel<object>>(item.Response);
                result.Add(itemModel);
            }
            return result;
        }
        catch (System.Exception ex)
        {
            // TODO
            Console.WriteLine("GetAll" + ex.StackTrace);
        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="boModel"></param>
    /// <returns></returns>
    public virtual Bo ToEntity(BoModel boModel)
    {
        var boEntity = new Bo();
        boEntity = boModel.ToEntity(boEntity);
        boEntity.Input = JsonConvert.SerializeObject(boModel.Input);
        boEntity.Actions = JsonConvert.SerializeObject(boModel.Actions);
        boEntity.Response = JsonConvert.SerializeObject(boModel.Response);

        return boEntity;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="boEntity"></param>
    /// <returns></returns>
    public virtual BoModel ToModel(Bo boEntity)
    {
        var boModel = boEntity.ToModel<BoModel>();
        boModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(boEntity.Input);
        boModel.Actions = JsonConvert.DeserializeObject<List<BoAction>>(boEntity.Actions);
        boModel.Response = JsonConvert.DeserializeObject<ActionsResponseModel<object>>(boEntity.Response);

        return boModel;
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;BoModel&gt;.</returns>
    public virtual async Task<BoModel> GetByTxcodeAndApp(string tx_code, string app)
    {
        var getBo = await _boRepository.Table.Where(s => s.Txcode.Equals(tx_code) && s.App.Equals(app)).FirstOrDefaultAsync();
        if (getBo == null)
        {
            return null;
        }

        var boModel = getBo.ToModel<BoModel>();
        boModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(getBo.Input);
        boModel.Actions = JsonConvert.DeserializeObject<List<BoAction>>(getBo.Actions);
        boModel.Response = JsonConvert.DeserializeObject<ActionsResponseModel<object>>(getBo.Response);

        return boModel;
    }
    /// <summary>
    /// Gets GetByApp
    /// </summary>
    /// <returns>Task&lt;BoModel&gt;.</returns>
    public virtual async Task<List<BoModel>> GetByApp(string app)
    {
        try
        {
            List<BoModel> result = new List<BoModel>();
            var getByApp = await _boRepository.Table.Where(s => s.App.Equals(app)).ToListAsync();
            foreach (var item in getByApp)
            {
                var itemModel = item.ToModel<BoModel>();
                itemModel.Input = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Input);
                itemModel.Actions = JsonConvert.DeserializeObject<List<BoAction>>(item.Actions);
                itemModel.Response = JsonConvert.DeserializeObject<ActionsResponseModel<object>>(item.Response);
                result.Add(itemModel);
            }
            return result;
        }
        catch (System.Exception ex)
        {
            // TODO
            Console.WriteLine("GetByApp" + ex.StackTrace);
        }
        return null;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    public virtual async Task<IPagedList<BoModel>> SearchByApp(string app)
    {
        await Task.CompletedTask;
        return null;
    }
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    public virtual async Task Insert(Bo bo)
    {
        var findForm = await _boRepository.Table.Where(s => s.App.Equals(bo.App) && s.Txcode.Equals(bo.Txcode)).FirstOrDefaultAsync();
        if (findForm == null)
            await _boRepository.Insert(bo);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    public virtual async Task Update(Bo bo)
    {
        await _boRepository.Update(bo);
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Bo&gt;.</returns>
    public virtual async Task<Bo> Delete(string tx_code, string app)
    {
        await Task.CompletedTask;
        return null;
    }


}
