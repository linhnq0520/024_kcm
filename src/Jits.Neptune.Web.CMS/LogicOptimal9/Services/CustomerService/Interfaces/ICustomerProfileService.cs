using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface ICustomerProfileService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>> AdvanceSearch(SimpleSearchCustomerProfileRequest model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>> SimpleSearch(SimpleSearchModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CustomerViewResponseModel> View(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        int Insert(CustomerInsertRequestModel model, UserSessions userSessions, string tableName, string txCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        CustomerUpdateResponseModel Update(CustomerUpdateRequestModel model, UserSessions userSessions, string tableName, string txCode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IPagedList<Cdlist>> LookupDataCommune(CodeListModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CodeListSearchResponseModel GetInforCdname(CodeListPrimaryKey model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IPagedList<Cdlist>> LookupDataforPrimarykey(CodeListModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IPagedList<Cdlist>> LookupDataSUBINDUSTRYOrSSRCINCOME(CodeListModel model);
    }
}
