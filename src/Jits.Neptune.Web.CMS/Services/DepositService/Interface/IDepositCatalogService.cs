using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.Models.Request.Deposit;
using Jits.Neptune.Web.CMS.Models.Response.Deposit;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.Services.DepositService.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDepositCatalogService
    {


        /// <summary>
        /// SimpleSearch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CatalogSearchResponseModel, CatalogSearchResponseModel>> SimpleSearch(SimpleSearchModel model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CatalogSearchResponseModel, CatalogSearchResponseModel>> AdvanceSearch(CatalogueDefinitionSearch model);

    }
}
