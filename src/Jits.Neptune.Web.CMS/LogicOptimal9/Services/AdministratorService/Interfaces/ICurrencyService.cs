using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface ICurrencyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IPagedList<CurrencySearchResponseModel> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IPagedList<CurrencySearchResponseModel> AdvanceSearch(CurrencySearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CurrencyViewResponseModel GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        CurrencyViewResponseModel GetByCurrencyId(string currencyId);
    }
}
