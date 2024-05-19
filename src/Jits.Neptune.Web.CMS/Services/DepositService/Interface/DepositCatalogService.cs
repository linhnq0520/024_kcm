using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models.Request.Deposit;
using Jits.Neptune.Web.CMS.Models.Response.Deposit;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;



namespace Jits.Neptune.Web.CMS.Services.DepositService.Interface
{
    /// <summary>
    ///  Service tatalog
    /// </summary>
    public class DepositCatalogService : IDepositCatalogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<PagedListModel<CatalogSearchResponseModel, CatalogSearchResponseModel>> AdvanceSearch(CatalogueDefinitionSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "DPT_CATALOGUE_DEFINITION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<CatalogSearchResponseModel>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CatalogSearchResponseModel, CatalogSearchResponseModel>();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CatalogSearchResponseModel, CatalogSearchResponseModel>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "DPT_CATALOGUE_DEFINITION");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<CatalogSearchResponseModel>(model.PageIndex, model.PageSize);
            //var response = System.Text.Json.JsonSerializer.Deserialize<List<UserAccountSearchResponseModel>>(JsonConvert.SerializeObject(result["data"]));
            return response.ToPagedListModel<CatalogSearchResponseModel, CatalogSearchResponseModel>();
        }
    }
}
