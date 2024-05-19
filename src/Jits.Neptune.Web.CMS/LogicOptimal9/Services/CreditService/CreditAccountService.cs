using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Services.CreditService;

/// <summary>
/// The credit account service class
/// </summary>

public class CreditAccountService : ICreditAccountService
{
    /// <summary>
    /// Simples the search account using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd account search response and crd account search response</returns>
    public  PagedListModel<CrdAccountSearchResponse, CrdAccountSearchResponse> SimpleSearch(SimpleSearchModel model)
    {
        model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

        var searchFunc = O9Utils.SearchFunc(model, "CRD_ACCOUNT_INFORMATION");
        var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true); 
        var result = O9Utils.Search(strSql, model.PageIndex);

        result = searchFunc.SearchData(result);
        var response = result.DataListToPagedList<CrdAccountSearchResponse>(model.PageIndex, model.PageSize);
        return response.ToPagedListModel<CrdAccountSearchResponse, CrdAccountSearchResponse>();
    }
    
     
    /// <summary>
    /// Advances the search account using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd account search response and crd account search response</returns>
    public  PagedListModel<CrdAccountSearchResponse, CrdAccountSearchResponse> AdvanceSearch(CrdAccountSearch model)
    {
        model.page_size = model.page_size == 0 ? int.MaxValue : model.page_size;

        var searchFunc = O9Utils.SearchFunc(model, "CRD_ACCOUNT_INFORMATION");
        var strSql = searchFunc.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);
        var result = O9Utils.Search(strSql, model.page_index);

        result = searchFunc.SearchData(result);
        var response = result.DataListToPagedList<CrdAccountSearchResponse>(model.page_index, model.page_size);
        return response.ToPagedListModel<CrdAccountSearchResponse, CrdAccountSearchResponse>();
    }

}