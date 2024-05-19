using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface ICodeListService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeId"></param>
        /// <returns></returns>
        CodeListViewResponseModel GetByCodeId(string codeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IPagedList<Cdlist>> Search(CodeListModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Update(Cdlist entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlist"></param>
        /// <param name="userSessions"></param>
        void O9Update(Cdlist cdlist, UserSessions userSessions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlist"></param>
        /// <param name="userSessions"></param>
        void O9Insert(Cdlist cdlist, UserSessions userSessions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlist"></param>
        /// <param name="userSessions"></param>
        void O9Delete(Cdlist cdlist, UserSessions userSessions);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        Task<CodeListSearchResponseModel> GetByPrimaryKey(CodeListPrimaryKey key);
    }
}
