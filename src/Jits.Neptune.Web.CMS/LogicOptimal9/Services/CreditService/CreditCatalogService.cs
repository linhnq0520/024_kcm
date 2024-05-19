using System;
using System.Collections.Generic;
using System.Globalization;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services.CreditService;

/// <summary>
/// The credit service class
/// </summary>
public class CreditCatalogService : ICreditCatalogService
{
    private readonly JWebUIObjectContextModel context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();

    /// <summary>
    /// 
    /// </summary>
    public CreditCatalogService()
    {
    }

    /// <summary>
    /// Advances the search catalog using the specified data
    /// </summary>
    /// <param name="data">The data</param>
    /// <exception cref="Exception"></exception>
    /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>
    public PagedListModel<CrdCatalogueDefinitionResponse, CrdCatalogueDefinitionResponse> AdvanceSearch(
        CrdCatalogueDefinitionSearch data)
    {
        try
        {
            data.page_size = data.page_size == 0 ? int.MaxValue : data.page_size;
            var modelSearch = O9Utils.SearchFunc(data, "CRD_CATALOGUE_DEFINITION");
            var strSql =
                modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, data.page_index);
            result = modelSearch.SearchData(result);
            var responses = result.DataListToPagedList<CrdCatalogueDefinitionResponse>(data.page_index, data.page_size);
            return responses.ToPagedListModel<CrdCatalogueDefinitionResponse, CrdCatalogueDefinitionResponse>();
            ;
        }
        catch
        {
            throw new Exception();
        }
    }


    /// <summary>
    /// Simples the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>
    public PagedListModel<CrdCatalogueDefinitionResponse, CrdCatalogueDefinitionResponse> SimpleSearch(
        SimpleSearchModel model)
    {
        model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

        var searchFunc = O9Utils.SearchFunc(model, "CRD_CATALOGUE_DEFINITION");
        var strSql =
            searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery,
                true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
        var result = O9Utils.Search(strSql, model.PageIndex);

        result = searchFunc.SearchData(result);
        var response = result.DataListToPagedList<CrdCatalogueDefinitionResponse>(model.PageIndex, model.PageSize);
        return response.ToPagedListModel<CrdCatalogueDefinitionResponse, CrdCatalogueDefinitionResponse>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="userSessions"></param>
    /// <returns></returns>
    public CrdCatalogInsertRequest Insert(CrdCatalogInsertRequest model, UserSessions userSessions)
    {
        var backOffice = O9Utils.BackOffice(userSessions, "006001000002", "O9DATA.D_CRDCAT", model);
        var result = backOffice.ToResponseModel<CrdCatalogInsertRequest>();
        return result;
    }

    
}