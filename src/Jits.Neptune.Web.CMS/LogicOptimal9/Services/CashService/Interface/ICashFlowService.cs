using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Models.Request.Cash;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICashFlowService
    {

        /// <summary>
        /// SimpleSearch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CashFlowSearchResponseModel, CashFlowSearchResponseModel>> SimpleSearch(SimpleSearchModel model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CashFlowSearchResponseModel, CashFlowSearchResponseModel>> AdvanceSearch(CashFlowSearch model);
    }
}
