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
    public class DepartmentProfileService : IDepartmentProfileService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<DepartmentSearchResponseModel> AdvanceSearch(DepartmentSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var modelSearch = O9Utils.SearchFunc(model, "ADM_DEPARTMENT_PROFILE");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<DepartmentSearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<DepartmentSearchResponseModel> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var searchFunc = O9Utils.SearchFunc(model, "ADM_DEPARTMENT_PROFILE");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<DepartmentSearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DepartmentViewResponseModel GetById(int id)
        {
            var value = new DepartmentViewResponseModel();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, O9Constants.TXCODE.ADM_GET_DEPARTMENT);
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    //jsResult.ConvertListDateStringToLong();
                    value = System.Text.Json.JsonSerializer.Deserialize<DepartmentViewResponseModel>(JsonConvert.SerializeObject(jsResult));
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
