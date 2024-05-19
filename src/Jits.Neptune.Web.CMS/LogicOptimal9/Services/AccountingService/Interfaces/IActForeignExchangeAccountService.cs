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
    public partial interface IActForeignExchangeAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActForeignExchangeAccountDefinitionSearchResponse, ActForeignExchangeAccountDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActForeignExchangeAccountDefinitionSearchResponse, ActForeignExchangeAccountDefinitionSearchResponse>> AdvancedSearch(ActForeignExchangeAccountDefinitionSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ActForeignExchangeAccountDefinitionViewResponse View(ModelViewActForeignExchangeAccountDefinition model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        ModelInsertForeignExchangeAccount Create(ModelInsertForeignExchangeAccount model, UserSessions userSessions, string tableName, string txCode);

    }
}
