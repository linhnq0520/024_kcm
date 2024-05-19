using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IActFixedAssetCatalogueService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActFixedAssetCatalogueDefinitionSearchResponse, ActFixedAssetCatalogueDefinitionSearchResponse>> AdvancedSearch(ActFixedAssetCatalogueDefinitionSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ActFixedAssetCatalogueDefinitionViewResponse View(ModelWithId model);

    }
}
