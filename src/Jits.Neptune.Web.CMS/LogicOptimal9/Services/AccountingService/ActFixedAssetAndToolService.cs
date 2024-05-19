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
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public class ActFixedAssetAndToolService : IActFixedAssetAndToolService
    {
        private readonly IBranchProfileService _branchService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchService"></param>
        public ActFixedAssetAndToolService(IBranchProfileService branchService)
        {
            _branchService = branchService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>> AdvancedSearch(ActFixedAssetAndToolSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "FAC_FIXED_ASSET_AND_TOOL");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<ActFixedAssetAndToolSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "FAC_FIXED_ASSET_AND_TOOL");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<ActFixedAssetAndToolSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public ActFixedAssetAndToolViewResponse View(ModelViewActFixedAssetAndTool model)
        {
            var value = new ActFixedAssetAndToolViewResponse();
            try
            {
                JsonAccounting jsRequest = new JsonAccounting()
                {
                    I = model.id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataRequest(jsRequest, "FAC_GET_FIXEDASSET");
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    
                    jsResult["buydt"] = O9Utils.ConvertLongToDateTime(long.Parse(jsResult["buydt"].ToString()));
                    jsResult["dprdt"] = O9Utils.ConvertLongToDateTime(long.Parse(jsResult["dprdt"].ToString()));
                    jsResult["wrtodt"] = O9Utils.ConvertLongToDateTime(long.Parse(jsResult["wrtodt"].ToString()));
                    jsResult["wrfrdt"] = O9Utils.ConvertLongToDateTime(long.Parse(jsResult["wrfrdt"].ToString()));

                    value = System.Text.Json.JsonSerializer.Deserialize<ActFixedAssetAndToolViewResponse>(JsonConvert.SerializeObject(jsResult));
                }

                var branch = _branchService.GetById(value.branchid);
                if (branch != null)
                {
                    value.branchcd = branch.branchcd;
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
