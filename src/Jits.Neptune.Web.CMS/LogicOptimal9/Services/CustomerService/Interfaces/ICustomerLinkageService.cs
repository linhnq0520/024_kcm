using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface ICustomerLinkageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CustomerLinkageResponseSearch, CustomerLinkageResponseSearch>> AdvanceSearch(AdvanceSearchCustomerLinkageRequest model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CustomerLinkageResponseSearch, CustomerLinkageResponseSearch>> SimpleSearch(SimpleSearchModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerLinkageViewResponseModel GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        JObject Create(CustomerLinkageRequestInsertModel model, UserSessions userSessions, string tableName, string txCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        JObject Update(CustomerLinkageRequestUpdateModel model, UserSessions userSessions, string tableName, string txCode);
    }
}
