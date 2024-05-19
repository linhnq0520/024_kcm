using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.ActiveMQ.Threads;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Models.Request.Deposit;
using Jits.Neptune.Web.CMS.Models.Response.Deposit;
using Jits.Neptune.Web.CMS.Services.DepositService.Interface;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.Controllers.DepositController.cs
{
    /// <summary>
    /// 
    /// </summary>
    public class DepositController : BaseController
    {

        private readonly IDepositCatalogService _contextCatalog = EngineContext.Current.Resolve<IDepositCatalogService>();
        /// <summary>
        /// 
        /// </summary>

        public DepositController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Deposit Search")]
        public async Task<IActionResult> Search([FromBody] CatalogueDefinitionSearch data)
        {
            await System.Threading.Tasks.Task.CompletedTask;
            try
            {
                var modelSearch = O9Utils.SearchFunc(data, "DPT_CATALOGUE_DEFINITION");
                var strSql =
                    modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);
                var result = O9Utils.Search(strSql, 0);
                result = modelSearch.SearchData(result);
                var a = result.DataListToPagedList<CatalogueDefinitionSearchResponse>(0, 20);
                // var a = System.Text.Json.JsonSerializer.Deserialize<CrdCatalogueDefinitionSearchResponse>(
                //     JsonConvert.SerializeObject(result));
                return Ok(a);
            }
            catch
            {
                return Ok();
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SimpleSearch")]
        public async Task<IActionResult> SimpleSearch([FromBody] SimpleSearchModel data)
        {


            var result = await _contextCatalog.SimpleSearch(data);
            return Ok(result);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("AdvancedSearch")]
        public async Task<IActionResult> AdvancedSearch([FromBody] CatalogueDefinitionSearch data)
        {


            var result = await _contextCatalog.AdvanceSearch(data);
            return Ok(result);



        }

    }
        
}
