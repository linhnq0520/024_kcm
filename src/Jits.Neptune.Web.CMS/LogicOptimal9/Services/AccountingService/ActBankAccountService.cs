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
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public class ActBankAccountService : IActBankAccountService
    {

        private readonly IBranchProfileService _branchService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchService"></param>
        public ActBankAccountService(IBranchProfileService branchService)
        {
            _branchService = branchService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>> AdvancedSearch(ActBankAccountDefinitionSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "ACT_BANK_ACCOUNT_DEFINITION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<ActBankAccountDefinitionSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "ACT_BANK_ACCOUNT_DEFINITION");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<ActBankAccountDefinitionSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acno"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public ActBankAccountDefinitionViewResponse ViewByAcno(string acno)
        {
            var value = new ActBankAccountDefinitionViewResponse();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = acno,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, "ACT_GET_ACCHRT");
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);

                    value = System.Text.Json.JsonSerializer.Deserialize<ActBankAccountDefinitionViewResponse>(JsonConvert.SerializeObject(jsResult));
                 
                    if(jsResult["mname"].ToString() != "")
                    {
                        var mphone = JObject.Parse(jsResult["mname"].ToString());
                        value.multivaluename = System.Text.Json.JsonSerializer.Deserialize<MultiValueName>(JsonConvert.SerializeObject(mphone));
                    }

                    var branch = _branchService.GetById(value.branchid);
                    if (branch != null)
                    {
                        value.branchcode = branch.branchcd;
                    }

                    value.jobopt = value.jobopt.Trim();
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
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public ModelInsertBankAccountDefinition Create(ModelInsertBankAccountDefinition model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {

                var rs = O9Utils.BackOffice(userSessions, "012002000002",
                    "O9DATA.D_ACCHRT", model.ToUpperPropertyName());

                return model;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }
    }
}
