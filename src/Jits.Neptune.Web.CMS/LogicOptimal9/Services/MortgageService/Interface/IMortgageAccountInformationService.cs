using Jits.Neptune.Web.CMS.Models.Request.Cash;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Models.Request.Job;
using Jits.Neptune.Web.CMS.Models.Response.Mortgage;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface
{/// <summary>
/// The Mortgage Account Information service interface
/// </summary>
    public interface IMortgageAccountInformationService
    {
        /// <summary>
        /// SimpleSearch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<MTGAccountInformationResponse, MTGAccountInformationResponse>> SimpleSearch(SimpleSearchModel model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<MTGAccountInformationResponse, MTGAccountInformationResponse>> AdvanceSearch(MTGAccountInformationSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <returns></returns>
        MTGAccountInformationViewResponse ViewAccount(MTGAccountViewRequest model, UserSessions userSessions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <returns></returns>
        MTGAccountInsertRequest InsertAccount(MTGAccountInsertRequest model, UserSessions userSessions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <returns></returns>
        MTGAccountUpdateRequest UpdateAccount(MTGAccountUpdateRequest model, UserSessions userSessions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <returns></returns>
        MTGAccountDeleteRequest DeleteAccount(MTGAccountDeleteRequest model, UserSessions userSessions);


    }
}
