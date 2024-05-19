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
    public class CountryService : ICountryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<CountrySearchResponseModel> AdvanceSearch(CountrySearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var modelSearch = O9Utils.SearchFunc(model, "ADM_COUNTRY");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<CountrySearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<CountrySearchResponseModel> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var searchFunc = O9Utils.SearchFunc(model, "ADM_COUNTRY");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<CountrySearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iso3Alpha"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public CountryViewResponseModel GetByIso3Alpha(string iso3Alpha)
        {
            var value = new CountryViewResponseModel();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = iso3Alpha,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, O9Constants.TXCODE.ADM_GET_COUNTRY);
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    //jsResult.ConvertListDateStringToLong();
                    //value = System.Text.Json.JsonSerializer.Deserialize<CountryViewResponseModel>(JsonConvert.SerializeObject(jsResult));
                    value = jsResult.MapToModel<CountryViewResponseModel>();
                    value.MultiCountryName = JObject.Parse(value.mctryname).MapToModel<MultiCountryName>();
                    value.MultiCountryShortName = JObject.Parse(value.mctrsname).MapToModel<MultiCountryShortName>();
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
