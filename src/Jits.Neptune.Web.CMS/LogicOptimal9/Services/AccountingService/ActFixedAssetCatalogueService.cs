using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Controllers;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LinqToDB.Common.Configuration;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Newtonsoft.Json.Linq;
using System;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetCatalogueService : IActFixedAssetCatalogueService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>> AdvancedSearch(ActFixedAssetCatalogueDefinitionSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "FAC_FIXED_ASSET_CATALOGUE_DEFINITION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<ActFixedAssetCatalogueDefinitionSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "FAC_FIXED_ASSET_CATALOGUE_DEFINITION");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<ActFixedAssetCatalogueDefinitionSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public ActFixedAssetCatalogueDefinitionViewResponse View(ModelWithId model)
        {
            var value = new ActFixedAssetCatalogueDefinitionViewResponse();
            try
            {
                JsonAccounting jsRequest = new JsonAccounting()
                {
                    I = model.Id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataRequest(jsRequest, "FAC_GET_FACCAT");
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);

                    value = System.Text.Json.JsonSerializer.Deserialize<ActFixedAssetCatalogueDefinitionViewResponse>(JsonConvert.SerializeObject(jsResult));
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
