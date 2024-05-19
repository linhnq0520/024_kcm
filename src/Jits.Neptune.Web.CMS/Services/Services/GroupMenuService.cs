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
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// GroupMenu service
/// </summary>
public partial class GroupMenuService : IGroupMenuService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<GroupMenu> _GroupMenuRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="GroupMenuRepository"></param>

    public GroupMenuService(ILocalizationService localizationService,
        IRepository<GroupMenu> GroupMenuRepository)
    {
        _localizationService = localizationService;
        _GroupMenuRepository = GroupMenuRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    public virtual async Task<GroupMenu> GetById(int id)
    {
        return await _GroupMenuRepository.GetById(id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<GroupMenuModel> GetByIdAndApp(string id, string app)
    {
        return await _GroupMenuRepository.Table.Where(s => s.GroupMenuId.Equals(id) && s.App.Equals(app)).Select(s => ToModel(s)).FirstOrDefaultAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="functionCode"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<GroupMenuModel> GetByFunctionCodeAndApp(string functionCode, string app)
    {
        return await _GroupMenuRepository.Table.Where(s => s.GroupMenuFunctionCode.Equals(functionCode.Trim()) && s.App.Equals(app)).Select(s => ToModel(s)).FirstOrDefaultAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="formCode"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<GroupMenuModel> GetByAuthorizeFormsAndApp(string formCode, string app)
    {
        return await _GroupMenuRepository.Table.Where(s => ((s.GroupMenuListAuthorizeForm.Contains(";" + formCode + ";")
        || s.GroupMenuListAuthorizeForm.StartsWith(formCode + ";")
        || s.GroupMenuListAuthorizeForm.EndsWith(";" + formCode)) && s.App.Equals(app))).Select(s => ToModel(s)).FirstOrDefaultAsync();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupMenuModel"></param>
    /// <returns></returns>
    public virtual GroupMenu ToEntity(GroupMenuModel groupMenuModel)
    {
        var groupMenuEntity = new GroupMenu();
        groupMenuEntity = groupMenuModel.ToEntity(groupMenuEntity);
        groupMenuEntity.GroupMenuLang = JsonConvert.SerializeObject(groupMenuModel.GroupMenuLang);

        return groupMenuEntity;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupMenuEntity"></param>
    /// <returns></returns>
    public virtual GroupMenuModel ToModel(GroupMenu groupMenuEntity)
    {
        var groupMenuModel = groupMenuEntity.ToModel<GroupMenuModel>();
        groupMenuModel.GroupMenuLang = JsonConvert.DeserializeObject<Dictionary<string, string>>(groupMenuEntity.GroupMenuLang);

        return groupMenuModel;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    public virtual async Task<List<GroupMenuModel>> SearchByApp(string app)
    {
        return await _GroupMenuRepository.Table.Where(s => s.App.Equals(app)).Select(s => ToModel(s)).ToListAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<GroupMenuModel>> GetAll()
    {
        return await _GroupMenuRepository.Table.Select(s => ToModel(s)).ToListAsync();
    }
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    public virtual async Task Insert(GroupMenu GroupMenu)
    {
        var getGroupMenu = await _GroupMenuRepository.Table.Where(s => s.App.Equals(GroupMenu.App) && s.GroupMenuId.Equals(GroupMenu.GroupMenuId)).FirstOrDefaultAsync();
        if (getGroupMenu == null)
            await _GroupMenuRepository.Insert(GroupMenu);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;GroupMenu&gt;.</returns>
    public virtual async Task Update(GroupMenu GroupMenu)
    {
        await _GroupMenuRepository.Update(GroupMenu);
    }

}
