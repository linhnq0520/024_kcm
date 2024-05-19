using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService.Interface;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;




namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService
{
    /// <summary>
    ///  Service tatalog
    /// </summary>
    public class CashFlowService : ICashFlowService
    {
/// <inheritdoc/>

        public async Task<PagedListModel<CashFlowSearchResponseModel, CashFlowSearchResponseModel>> AdvanceSearch(Models.Request.Cash.CashFlowSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "CSH_CASH_FLOW");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<CashFlowSearchResponseModel>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CashFlowSearchResponseModel, CashFlowSearchResponseModel>();
        }
/// <inheritdoc/>


        public async Task<PagedListModel<CashFlowSearchResponseModel, CashFlowSearchResponseModel>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "CSH_CASH_FLOW");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<CashFlowSearchResponseModel>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CashFlowSearchResponseModel, CashFlowSearchResponseModel>();
        }
    }
}
