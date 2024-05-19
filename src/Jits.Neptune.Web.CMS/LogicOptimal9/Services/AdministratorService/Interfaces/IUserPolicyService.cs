using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IUserPolicyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IPagedList<UserPolicySearchResponseModel> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IPagedList<UserPolicySearchResponseModel> AdvanceSearch(UserPolicySearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserPolicyViewResponseModel GetById(int id);
    }
}
