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
using Jits.Neptune.Web.CMS.Domain;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Jits.Neptune.Web.CMS.Models.FrontOfficeModels;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public class ActGroupService : IActGroupService
    {

        private readonly IBaseWorkflowService _baseWorkflow;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseWorkflow"></param>
        public ActGroupService(IBaseWorkflowService baseWorkflow)
        {
            _baseWorkflow = baseWorkflow;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>> AdvancedSearch(ActGroupDefinitionSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "ACT_ACCOUNTING_GROUP_DEFINITION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<ActGroupDefinitionSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "ACT_ACCOUNTING_GROUP_DEFINITION");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<ActGroupDefinitionSearchResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public ActGroupDefinitionViewResponse View(ModelViewActGroup model)
        {
            var value = new ActGroupDefinitionViewResponse();
            try
            {
                JsonAccounting jsRequest = new JsonAccounting()
                {
                    GRPID = model.grpid,
                    ACGRPDEF = model.acgrpdef,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataRequest(jsRequest, "ACT_GET_ACGRPDEF");
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);

                    value = System.Text.Json.JsonSerializer.Deserialize<ActGroupDefinitionViewResponse>(JsonConvert.SerializeObject(jsResult));
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
        public ModelInsertGroupDefinition Create(ModelInsertGroupDefinition model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {

                var rs = O9Utils.BackOffice(userSessions, txCode,
                    tableName, model.ToUpperPropertyName());

                return model;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }
    }
}
