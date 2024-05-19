using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Interfaces;

/// <summary>
/// The credit catalog service interface
/// </summary>

public interface ICreditCatalogService
{

    /// <summary>
    /// Advances the search using the specified data
    /// </summary>
    /// <param name="data">The data</param>
    /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>
    PagedListModel<CrdCatalogueDefinitionResponse, CrdCatalogueDefinitionResponse> AdvanceSearch(CrdCatalogueDefinitionSearch data);

   
    /// <summary>
    /// Simples the searh using the specified model
    /// </summary>
    /// <param name="model">The model</param>
    /// <returns>A paged list model of crd catalogue definition response and crd catalogue definition response</returns>
    PagedListModel<CrdCatalogueDefinitionResponse, CrdCatalogueDefinitionResponse> SimpleSearch(
        SimpleSearchModel model);
    
  
    /// <summary>
    /// Inserts the model
    /// </summary>
    /// <param name="model">The model</param>
    /// <param name="userSessions">The user sessions</param>
    /// <returns>The crd catalog insert request</returns>
    CrdCatalogInsertRequest Insert(CrdCatalogInsertRequest model,UserSessions userSessions);

}