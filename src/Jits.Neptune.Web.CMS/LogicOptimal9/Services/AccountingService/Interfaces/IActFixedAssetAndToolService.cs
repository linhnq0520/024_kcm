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
    public partial interface IActFixedAssetAndToolService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActFixedAssetAndToolSearchResponse, ActFixedAssetAndToolSearchResponse>> AdvancedSearch(ActFixedAssetAndToolSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ActFixedAssetAndToolViewResponse View(ModelViewActFixedAssetAndTool model);

    }
}
