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

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public class ActCommonAccountMappingService : IActCommonAccountMappingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActCommonAccountMappingSearchResponse, ActCommonAccountMappingSearchResponse>> AdvancedSearch(ActCommonAccountMappingSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "ACT_ACCOUNTING_COMMON_EXTRA");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<ActCommonAccountMappingSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActCommonAccountMappingSearchResponse, ActCommonAccountMappingSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActCommonAccountMappingSearchResponse, ActCommonAccountMappingSearchResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "ACT_ACCOUNTING_COMMON_EXTRA");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<ActCommonAccountMappingSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActCommonAccountMappingSearchResponse, ActCommonAccountMappingSearchResponse>();
        }
    }
}
