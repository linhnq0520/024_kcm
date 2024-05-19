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
/// DesignItem service
/// </summary>
public partial class DesignItemService : IDesignItemService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<DesignItem> _DesignItemRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="DesignItemRepository"></param>

    public DesignItemService(ILocalizationService localizationService,
        IRepository<DesignItem> DesignItemRepository)
    {
        _localizationService = localizationService;
        _DesignItemRepository = DesignItemRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;DesignItem&gt;.</returns>
    public virtual async Task<DesignItem> GetById(int id)
    {
        return await _DesignItemRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;DesignItemModel&gt;.</returns>
    public virtual async Task<List<DesignItemModel>> GetAll()
    {

        try
        {
             List < DesignItemModel > result = new List<DesignItemModel>();
            var getDesignItem = await _DesignItemRepository.Table.ToListAsync();
            if (getDesignItem == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_DesignItem_ERR_0000000"));
            foreach (var itemDesignItem in getDesignItem)
            {
                var itemAdd = itemDesignItem.ToModel<DesignItemModel>();
                itemAdd.Title = JsonConvert.DeserializeObject<Dictionary<string,object>>(itemDesignItem.Title);
                itemAdd.Template=JsonConvert.DeserializeObject<Dictionary<string, object>>(itemDesignItem.Template);
                result.Add(itemAdd);

            }
            
            return result;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetAll==Exception====" + ex.StackTrace);

        }
        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="designItem"></param>
    /// <returns></returns>
    public virtual async Task Insert(DesignItem designItem)
    {
        var findForm = await _DesignItemRepository.Table.Where(s => s.AttId.Equals(designItem.AttId)).FirstOrDefaultAsync();
        if (findForm == null)
            await _DesignItemRepository.Insert(designItem);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="DesignItem"></param>
    /// <returns></returns>
    public virtual async Task<DesignItem> Update(DesignItem DesignItem)
    {
        await Task.CompletedTask;
        return null;
    }

}
