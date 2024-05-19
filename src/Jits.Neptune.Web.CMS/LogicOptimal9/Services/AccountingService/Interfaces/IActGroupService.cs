using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IActGroupService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>> SimpleSearch(SimpleSearchModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<PagedListModel<ActGroupDefinitionSearchResponse, ActGroupDefinitionSearchResponse>> AdvancedSearch(ActGroupDefinitionSearch model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ActGroupDefinitionViewResponse View(ModelViewActGroup model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        ModelInsertGroupDefinition Create(ModelInsertGroupDefinition model, UserSessions userSessions, string tableName, string txCode);
    }
}
