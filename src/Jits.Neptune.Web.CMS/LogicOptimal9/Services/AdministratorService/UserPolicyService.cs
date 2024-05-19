using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPolicyService : IUserPolicyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<UserPolicySearchResponseModel> AdvanceSearch(UserPolicySearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var modelSearch = O9Utils.SearchFunc(model, "ADM_SYSTEM_POLICY");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<UserPolicySearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<UserPolicySearchResponseModel> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var searchFunc = O9Utils.SearchFunc(model, "ADM_SYSTEM_POLICY");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<UserPolicySearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserPolicyViewResponseModel GetById(int id)
        {
            var value = new UserPolicyViewResponseModel();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, O9Constants.TXCODE.ADM_GET_USRPOLICY);
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    value = jsResult.MapToModel<UserPolicyViewResponseModel>();
                    value.EffectiveFrom = value.effrom.HasValue ? O9Utils.ConvertLongToDateTime(value.effrom.Value) : default(DateTime?);
                    value.EffectiveTo = value.efto.HasValue ? O9Utils.ConvertLongToDateTime(value.efto.Value) : default(DateTime?);
                }

                return value;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }
    }
}
