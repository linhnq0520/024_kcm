using System;
using System.Linq;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Caching;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Configuration;
using Jits.Neptune.Web.Framework.Services.Localization;

namespace Jits.Neptune.Web.CMS.Services
{

    /// <summary>
    /// SettingService
    /// </summary>
    public partial class CMSSettingService : ICMSSettingService
    {
        #region Fields
        StringComparison ICIC = StringComparison.InvariantCultureIgnoreCase;

        private readonly IRepository<Setting> _settingRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;


        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingRepository"></param>
        /// <param name="staticCacheManager"></param>
        /// <param name="settingService"></param>
        /// <param name="localizationService"></param>
        public CMSSettingService(
            IRepository<Setting> settingRepository,
            IStaticCacheManager staticCacheManager,
            ISettingService settingService,
            ILocalizationService localizationService)
        {
            _settingRepository = settingRepository;
            _localizationService = localizationService;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
        }

        #endregion


        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<Setting> GetById(int id)
        {
            return await _settingRepository.GetById(id);
        }

        /// <summary>
        /// GetByPrimaryKey
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual async Task<Setting> GetByPrimaryKey(string name)
        {
            var query = await _settingRepository.Table.Where(s => s.Name == name).FirstOrDefaultAsync();
            return query;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<Setting> View(int id)
        {
            var getSetting = await _settingRepository.GetById(id);
            if (getSetting == null)
            {
                throw new NeptuneException("CMS.Setting.Value.NotFound");
            }
            return getSetting;
        }


        /// <summary>
        /// Simple Search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<Setting>> Search(SimpleSearchModel model)
        {
            var viewTable = _settingRepository.Table.Where(s =>
                    s.Name.Contains(model.SearchText, ICIC)
                 || s.Value.Contains(model.SearchText, ICIC)
                 || s.OrganizationId.ToString().Equals(model.SearchText)
                );

            var result = await viewTable.ToPagedList(model.PageIndex, model.PageSize);
            return result;
        }

        /// <summary>
        /// Advance Search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<Setting>> Search(SettingSearchModel model)
        {
            var query = _settingRepository.Table;
            if (model.Name.HasValue())
            {
                query = query.Where(s => s.Name.Contains(model.Name, ICIC));
            }
            if (model.Value.HasValue())
            {
                query = query.Where(s => s.Value.Contains(model.Value, ICIC));
            }
            if (model.OrganizationId.HasValue())
            {
                query = query.Where(s => s.OrganizationId.ToString() == model.OrganizationId);
            }
            return await query.ToPagedList(model.PageIndex, model.PageSize);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<Setting> Create(SettingCreateModel model)
        {
            var getSetting = await GetByPrimaryKey(model.Name);
            if (getSetting != null) throw new NeptuneException("CMS.Setting.Value.Exist");

            var newModel = new Setting()
            {
                Name = model.Name,
                Value = model.Value,
                OrganizationId = model.OrganizationId
            };
            await Insert(newModel, model.ReferenceId);
            getSetting = await GetByPrimaryKey(newModel.Name);
            await _staticCacheManager.RemoveByPrefix(NeptuneEntityCacheDefaults<Setting>.Prefix);
            var allSettingKey = Framework.Services.Configuration.NeptuneConfigurationDefaults.SettingsAllAsDictionaryCacheKey;
            await _staticCacheManager.RemoveByPrefix(allSettingKey.Key);
            await _settingService.ClearCache();
            return getSetting;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="value"></param>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        public virtual async Task Insert(Setting value, string referenceId = "")
        {
            await _settingRepository.Insert(value, referenceId);
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        public virtual async Task<SettingUpdateModel> Update(SettingUpdateModel model, string referenceId = "")
        {
            var getSetting = await GetById(model.Id);
            if (getSetting == null) throw new NeptuneException("CMS.Setting.Value.NotFound");

            // convert
            getSetting.Name = model.Name;
            getSetting.Value = model.Value;
            getSetting.OrganizationId = model.OrganizationId;

            await _settingRepository.Update(getSetting, referenceId);
            await _staticCacheManager.RemoveByPrefix(NeptuneEntityCacheDefaults<Setting>.Prefix);
            var allSettingKey = Framework.Services.Configuration.NeptuneConfigurationDefaults.SettingsAllAsDictionaryCacheKey;
            await _staticCacheManager.RemoveByPrefix(allSettingKey.Key);
            await _settingService.ClearCache();
            return model;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        public virtual async Task<Setting> Delete(int id, string referenceId = "")
        {
            var getSetting = await GetById(id);
            if (getSetting == null) throw new NeptuneException("CMS.Setting.Value.NotFound");

            await _settingRepository.Delete(getSetting, referenceId);
            await _staticCacheManager.RemoveByPrefix(NeptuneEntityCacheDefaults<Setting>.Prefix);
            var allSettingKey = Framework.Services.Configuration.NeptuneConfigurationDefaults.SettingsAllAsDictionaryCacheKey;
            await _staticCacheManager.RemoveByPrefix(allSettingKey.Key);
            await _settingService.ClearCache();
            return getSetting;
        }

    }
}