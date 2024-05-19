using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Data;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeListService : ICodeListService
    {
        private readonly IRepository<Cdlist> _cdlistRepository;
        private readonly ILocalizationService _localizationService;
        private readonly StringComparison ICIC = StringComparison.InvariantCultureIgnoreCase;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlistRepository"></param>
        /// <param name="localizationService"></param>
        public CodeListService(IRepository<Cdlist> cdlistRepository, ILocalizationService localizationService)
        {
            _cdlistRepository = cdlistRepository;
            _localizationService = localizationService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public CodeListViewResponseModel GetByCodeId(string codeId)
        {
            var value = new CodeListViewResponseModel();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = codeId,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, "ADM_GET_CDLIST");
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    
                    value = jsResult.MapToModel<CodeListViewResponseModel>();
                    value.MultiCaption = JObject.Parse(value.mcaption).MapToModel<MultiCaption>();
                }

                return value;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<Cdlist>> Search(CodeListModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;
            var query = _cdlistRepository.Table;
            if (model.Cdid.HasValue()) query = query.Where(c => c.Cdid.Contains(model.Cdid, ICIC));
            if (model.Cdname.HasValue()) query = query.Where(c => c.Cdname.Contains(model.Cdname, ICIC));
            if (model.Caption.HasValue()) query = query.Where(c => c.Caption.Contains(model.Caption, ICIC));
            if (model.Cdgrp.HasValue()) query = query.Where(c => c.Cdgrp.Contains(model.Cdgrp, ICIC));
            if (model.Ftag.HasValue()) query = query.Where(c => c.Ftag.Contains(model.Ftag, ICIC));
            if (model.Cdidx != null) query = query.Where(c => c.Cdidx == model.Cdidx);
            if (model.CodeIndexFrom.HasValue) query = query.Where(c => c.Cdidx >= model.CodeIndexFrom);
            if (model.CodeIndexTo.HasValue) query = query.Where(c => c.Cdidx <= model.CodeIndexTo);
            if (model.Visible != null) query = query.Where(c => c.Visible == model.Visible);

            query = query.OrderBy(c => c.Cdid);

            var pagedCodeList = await query.ToPagedList(model.PageIndex, model.PageSize);
            return pagedCodeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(Cdlist entity)
        {
            await _cdlistRepository.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlist"></param>
        /// <param name="userSessions"></param>
        public void O9Update(Cdlist cdlist, UserSessions userSessions)
        {
            var updateModel = cdlist.ToModel<CdlistUpdateModel>();

            updateModel.Mcaption = JsonConvert.DeserializeObject<MultiCaption>(JsonConvert.SerializeObject(System.Text.Json.JsonSerializer.Deserialize<MCaption>(cdlist.Mcaption)));
            var rs = O9Utils.BackOffice(userSessions, O9Constants.TXCODE.ADM_UPDATE_CDLIST, O9Constants.TableName.CodeList, updateModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlist"></param>
        /// <param name="userSessions"></param>
        public void O9Insert(Cdlist cdlist, UserSessions userSessions)
        {
            var createModel = cdlist.ToModel<CdlistCreateModel>();

            createModel.Mcaption = JsonConvert.DeserializeObject<MultiCaption>(JsonConvert.SerializeObject(System.Text.Json.JsonSerializer.Deserialize<MCaption>(cdlist.Mcaption)));
            var rs = O9Utils.BackOffice(userSessions, O9Constants.TXCODE.ADM_INSERT_CDLIST, O9Constants.TableName.CodeList, createModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlist"></param>
        /// <param name="userSessions"></param>
        public void O9Delete(Cdlist cdlist, UserSessions userSessions)
        {
            var searchModel = cdlist.ToModel<CodeListSearchModel>();
            var value = O9Utils.AdvanceSearchCommon<CodeListSearchModel, CodeListSearchResponseModel>
                                       (searchModel, "ADM_SYSTEM_CODE_TABLE").FirstOrDefault();
            if (value == null) return;
            var deleteModel = new ModelWithRownum()
            {
                rownum_cdid_cdname_cdgrp = value.rownum_cdid_cdname_cdgrp
            };

            var rs = O9Utils.BackOffice(userSessions, O9Constants.TXCODE.ADM_DELETE_CDLIST, O9Constants.TableName.CodeList, deleteModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public async Task<CodeListSearchResponseModel> GetByPrimaryKey(CodeListPrimaryKey key)
        {
            try
            {
                var codeList = await _cdlistRepository.Table
                    .Where(s => s.Cdid == key.cdid && s.Cdgrp == key.cdgrp && s.Cdname == key.cdname)
                    .Select(s => new CodeListSearchResponseModel()
                    {
                        cdid = s.Cdid,
                        caption = s.Caption,
                        cdgrp = s.Cdgrp,
                        cdidx = s.Cdidx,
                        cdname = s.Cdname,
                        ftag = s.Ftag,
                        visible = s.Visible
                    }).FirstOrDefaultAsync() ?? throw new NeptuneException(await _localizationService.GetResource("CMS_Cdlist_ERR_0000000"));
                return codeList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetByPrimaryKey_Exception === " + ex.StackTrace);
            }
            return null;
        }
    }
}
