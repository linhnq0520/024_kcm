using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface ICustomerMediaService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CustomerMediaSearchResponseModel, CustomerMediaSearchResponseModel>> AdvanceSearch(CustomerMediaSearchModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CustomerMediaSearchResponseModel, CustomerMediaSearchResponseModel>> SimpleSearch(SimpleSearchModel model);
    }
}
