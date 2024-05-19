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
/// DesignGroup service
/// </summary>
public partial class DesignGroupService : IDesignGroupService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<DesignGroup> _DesignGroupRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="DesignGroupRepository"></param>

    public DesignGroupService(ILocalizationService localizationService,
        IRepository<DesignGroup> DesignGroupRepository)
    {
        _localizationService = localizationService;
        _DesignGroupRepository = DesignGroupRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;DesignGroup&gt;.</returns>
    public virtual async Task<DesignGroup> GetById(int id)
    {
        return await _DesignGroupRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;DesignGroupModel&gt;.</returns>
    public virtual async Task<List<DesignGroupModel>> GetAll()
    {
        List<DesignGroupModel> result = new List<DesignGroupModel>();

        try
        {
            var getDesignGroup = await _DesignGroupRepository.Table.ToListAsync();
            if (getDesignGroup == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_DesignGroup_ERR_0000000"));

            foreach (var itemDesignItem in getDesignGroup)
            {
                var itemAdd = itemDesignItem.ToModel<DesignGroupModel>();
                itemAdd.Title = JsonConvert.DeserializeObject<Dictionary<string, object>>(itemDesignItem.Title);
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
/// <param name="DesignGroup"></param>
/// <returns></returns>
    public virtual async Task Insert(DesignGroup DesignGroup)
    {
        var findForm = await _DesignGroupRepository.Table.Where(s => s.GroupId.Equals(DesignGroup.GroupId)).FirstOrDefaultAsync();
        if (findForm == null)
            await _DesignGroupRepository.Insert(DesignGroup);
    }
 /// <summary>
 /// 
 /// </summary>
 /// <param name="DesignGroup"></param>
 /// <returns></returns>
    public virtual Task<DesignGroup> Update(DesignGroup DesignGroup)
    {
        return null;
    }

}
