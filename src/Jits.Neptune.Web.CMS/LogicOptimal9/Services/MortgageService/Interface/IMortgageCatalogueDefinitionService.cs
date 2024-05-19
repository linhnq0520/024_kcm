using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Models.Request.Job;
using Jits.Neptune.Web.CMS.Models.Request.Mortgage;
using Jits.Neptune.Web.CMS.Models.Response.Mortgage;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface;

/// <summary>
/// The Mortgage Catalogue Definition service interface
/// </summary>
public interface IMortgageCatalogueDefinitionService
{

    /// <summary>
    /// SimpleSearch
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<PagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>> SimpleSearch(SimpleSearchModel model);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<PagedListModel<MTGCatalogueDefinitionResponse, MTGCatalogueDefinitionResponse>> AdvancedSearch(MTGCatalogueDefinitionSearch model);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="catid"></param>
    /// <returns></returns>
    MTGCatalogueDefinitionViewResponse ViewByCatId(int catid);
    /// <summary>
    /// Inserts the model
    /// </summary>
    /// <param name="model">The model</param>
    /// <param name="userSessions">The user sessions</param>
    /// <returns>The crd catalog insert request</returns>
    MTGCatalogueDefinitionInsertRequest Insert(MTGCatalogueDefinitionInsertRequest model, UserSessions userSessions);

    /// <summary>
    /// Inserts the model
    /// </summary>
    /// <param name="model">The model</param>
    /// <param name="userSessions">The user sessions</param>
    /// <returns>The crd catalog insert request</returns>
    MTGCatalogueDefinitionUpdateRequest Update(MTGCatalogueDefinitionUpdateRequest model, UserSessions userSessions);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="userSessions"></param>
    /// <returns></returns>
    MTGCatalogueDefinitionDeleteRequest DeleteByCatId(MTGCatalogueDefinitionDeleteRequest model, UserSessions userSessions);
}
