using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Controllers;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using static LinqToDB.Common.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerMediaService : ICustomerMediaService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerMediaSearchResponseModel, CustomerMediaSearchResponseModel>> AdvanceSearch(CustomerMediaSearchModel model)
        {
            model.opndt = model.open_date?.ToString("dd/MM/yyyy");
            model.expdt = model.expire_date?.ToString("dd/MM/yyyy");
            model.lastdt = model.last_update_date?.ToString("dd/MM/yyyy");
            var modelSearch = O9Utils.SearchFunc(model, "CTM_CUSTOMER_MEDIA_FILES");

            await Task.CompletedTask;
            string strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            JToken result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var responses = result.DataListToPagedList<CustomerMediaSearchResponseModel>(model.PageIndex, model.PageSize);
            return responses.ToPagedListModel<CustomerMediaSearchResponseModel, CustomerMediaSearchResponseModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerMediaSearchResponseModel, CustomerMediaSearchResponseModel>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "CTM_CUSTOMER_MEDIA_FILES");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, 0);

            result = searchFunc.SearchData(result);

            var response = result.DataListToPagedList<CustomerMediaSearchResponseModel>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CustomerMediaSearchResponseModel, CustomerMediaSearchResponseModel>();
        }
        
    }
}
