using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;

/// <summary>
/// The credit account service interface
/// </summary>

public interface ICreditAccountService
{
    /// <summary>
    /// Simples the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd account search response and crd account search response</returns>
    PagedListModel<CrdAccountSearchResponse, CrdAccountSearchResponse> SimpleSearch(SimpleSearchModel model);
    /// <summary>
    /// Advances the search using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd account search response and crd account search response</returns>
    PagedListModel<CrdAccountSearchResponse, CrdAccountSearchResponse> AdvanceSearch(CrdAccountSearch model);
}