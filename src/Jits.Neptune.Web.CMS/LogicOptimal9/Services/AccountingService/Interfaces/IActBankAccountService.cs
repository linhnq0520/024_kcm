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
    public partial interface IActBankAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActBankAccountDefinitionSearchResponse, ActBankAccountDefinitionSearchResponse>> AdvancedSearch(ActBankAccountDefinitionSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acno"></param>
        /// <returns></returns>
        ActBankAccountDefinitionViewResponse ViewByAcno(string acno);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        ModelInsertBankAccountDefinition Create(ModelInsertBankAccountDefinition model, UserSessions userSessions, string tableName, string txCode);
    }
}
