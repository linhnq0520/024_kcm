using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;

/// <summary>
/// The credit ifc service class
/// </summary>
public class CreditIFCService : ICreditIFCService
{
    /// <summary>
    /// Simples the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd ifc denfinition search response and crd ifc denfinition search response</returns>
    public PagedListModel<CrdIfcDenfinitionSearchResponse, CrdIfcDenfinitionSearchResponse> SimpleSearch(
        SimpleSearchModel model)
    {
        model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

        var searchFunc = O9Utils.SearchFunc(model, "IFC_IFC_ITEM_DEFINITION");
        var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
        var result = O9Utils.Search(strSql, model.PageIndex);

        result = searchFunc.SearchData(result);
        var response = result.DataListToPagedList<CrdIfcDenfinitionSearchResponse>(model.PageIndex, model.PageSize);
        return response.ToPagedListModel<CrdIfcDenfinitionSearchResponse, CrdIfcDenfinitionSearchResponse>();
    }


    /// <summary>
    /// Advances the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd ifc denfinition search response and crd ifc denfinition search response</returns>
    public PagedListModel<CrdIfcDenfinitionSearchResponse, CrdIfcDenfinitionSearchResponse> AdvanceSearch(
        CrdIfcDenfinitionSearch model)
    {
        model.page_size = model.page_size == 0 ? int.MaxValue : model.page_size;

        var searchFunc = O9Utils.SearchFunc(model, "IFC_IFC_ITEM_DEFINITION");
        var strSql =
            searchFunc.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);
        var result = O9Utils.Search(strSql, model.page_index);

        result = searchFunc.SearchData(result);
        var response = result.DataListToPagedList<CrdIfcDenfinitionSearchResponse>(model.page_index, model.page_size);
        return response.ToPagedListModel<CrdIfcDenfinitionSearchResponse, CrdIfcDenfinitionSearchResponse>();
    }
    
}