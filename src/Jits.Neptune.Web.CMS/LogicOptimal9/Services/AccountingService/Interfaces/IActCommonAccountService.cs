using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IActCommonAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActCommonAccountDefinitionSearchResponse, ActCommonAccountDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActCommonAccountDefinitionSearchResponse, ActCommonAccountDefinitionSearchResponse>> AdvancedSearch(ActCommonAccountDefinitionSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ActCommonAccountDefinitionViewResponse View(ModelViewActCommonAccountDefinition model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        ModelInsertCommonAccount Create(ModelInsertCommonAccount model, UserSessions userSessions, string tableName, string txCode);

    }
}
