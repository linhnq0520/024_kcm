using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;

/// <summary>
/// The credit ifc service interface
/// </summary>

public interface ICreditIFCService
{
    /// <summary>
    /// Simples the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd ifc denfinition search response and crd ifc denfinition search response</returns>
    PagedListModel<CrdIfcDenfinitionSearchResponse, CrdIfcDenfinitionSearchResponse> SimpleSearch(
        SimpleSearchModel model);

    /// <summary>
    /// Advances the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd ifc denfinition search response and crd ifc denfinition search response</returns>
    PagedListModel<CrdIfcDenfinitionSearchResponse, CrdIfcDenfinitionSearchResponse> AdvanceSearch(
        CrdIfcDenfinitionSearch model);


}