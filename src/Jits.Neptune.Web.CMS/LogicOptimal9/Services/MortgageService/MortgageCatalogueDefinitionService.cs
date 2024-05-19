using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models.Request.Job;
using Jits.Neptune.Web.CMS.Models.Request.Mortgage;
using Jits.Neptune.Web.CMS.Models.Response.Mortgage;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Protobuf.WellKnownTypes;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.CMS.Models;
using System.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService
{
    /// <summary>
    /// The credit service class
    /// </summary>
    public class MortgageCatalogueDefinitionService : IMortgageCatalogueDefinitionService
    {

        /// <summary>
        /// Advances the search catalog using the specified data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>

        public async Task<PagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>> AdvancedSearch(MTGCatalogueDefinitionSearch model)
        {

            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "MTG_CATALOGUE_DEFINITION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<MTGCatalogueDefinitionResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>();

        }

        /// <summary>
        /// Advances the search catalog using the specified data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>
        public async Task<PagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "MTG_CATALOGUE_DEFINITION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<MTGCatalogueDefinitionResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>();
        }

        /// <summary>
        /// View Catalogue Definition View Response by CATID
        /// </summary>
        /// <param name="catid"></param>
        /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>
        public MTGCatalogueDefinitionViewResponse ViewByCatId(int catid)
        {
            var value = new MTGCatalogueDefinitionViewResponse();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = catid,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, "MTG_GET_MTGCAT");
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    value = System.Text.Json.JsonSerializer.Deserialize<MTGCatalogueDefinitionViewResponse>(JsonConvert.SerializeObject(jsResult));
                }

                return value;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }

        /// <summary>
        /// Insert Catalogue 
        /// </summary>
        public MTGCatalogueDefinitionInsertRequest Insert(MTGCatalogueDefinitionInsertRequest model, UserSessions userSessions)
        {
            var backOffice = O9Utils.BackOffice(userSessions,"010001000002", "O9DATA.D_MTGCAT", model.ToUpperPropertyName());
            var result = backOffice.ToResponseModel<MTGCatalogueDefinitionInsertRequest>();
            return result;
        }


        /// <summary>
        /// update catalogue 
        /// </summary>
        public MTGCatalogueDefinitionUpdateRequest Update(MTGCatalogueDefinitionUpdateRequest model, UserSessions userSessions)
        {
            var backOffice = O9Utils.BackOffice(userSessions, "010001000004", "O9DATA.D_MTGCAT", model.ToUpperPropertyName());
            var result = backOffice.ToResponseModel<MTGCatalogueDefinitionUpdateRequest>();
            return result;
        }
        /// <summary>
        /// update catalogue 
        /// </summary>
        public MTGCatalogueDefinitionDeleteRequest DeleteByCatId(MTGCatalogueDefinitionDeleteRequest model, UserSessions userSessions)
        {
            var backOffice = O9Utils.BackOffice(userSessions, "010001000005", "O9DATA.D_MTGCAT", model.ToUpperPropertyName());
            var result = backOffice.ToResponseModel<MTGCatalogueDefinitionDeleteRequest>();

            return result;
        }

    }

}
