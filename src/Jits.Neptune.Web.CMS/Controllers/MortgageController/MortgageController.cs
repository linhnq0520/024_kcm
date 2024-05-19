using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Jits.Neptune.Web.CMS.Models.Request.Job;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface;
using Jits.Neptune.Web.CMS.Models.Request.Mortgage;
using Jits.Neptune.Web.CMS.Models.Response.Mortgage;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Domain;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Azure;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Core.Domain.Logging;
using Google.Protobuf.WellKnownTypes;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Apache.NMS.ActiveMQ.Commands;
using System.Linq;

namespace Jits.Neptune.Web.CMS.Controllers.MortgageController
{
    //[Route("api/")]
    /// <summary>
    ///
    /// </summary>
    public class MortgageController : BaseController
    {
        private readonly IMortgageAccountInformationService _contextAccountInformation = EngineContext.Current.Resolve<IMortgageAccountInformationService>();
        private readonly IMortgageCatalogueDefinitionService _contextCatalogueDefinition = EngineContext.Current.Resolve<IMortgageCatalogueDefinitionService>();

        /// <summary>
        /// 
        /// </summary>

        public MortgageController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SimpleSearchAccount([FromBody] SimpleSearchModel data)
        {


            var result = await _contextAccountInformation.SimpleSearch(data);
            return Ok(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AdvancedSearchAccount([FromBody] MTGAccountInformationSearch data)
        {


            var result = await _contextAccountInformation.AdvanceSearch(data);
            return Ok(result);



        }

        //[HttpPost]
        //public MTGAccountInformationViewResponse ViewAccount([FromBody] MTGAccountViewRequest defacno)
        //{
        //    var result = _contextAccountInformation.ViewAccount(defacno);
        //    return result;
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertAccount([FromBody] MTGAccountInsertRequest model)
        {
            var user = new UserSessions
            {
                Usrid = 1051,
                Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",

            };
            await Task.CompletedTask;
            var result = _contextAccountInformation.InsertAccount(model, user);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateAccount([FromBody] MTGAccountUpdateRequest model)
        {
            var user = new UserSessions
            {
                Usrid = 1051,
                Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",

            };
            await Task.CompletedTask;
            var result = _contextAccountInformation.UpdateAccount(model, user);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteAccount([FromBody] MTGAccountDeleteRequest model)
        {
            var user = new UserSessions
            {
                Usrid = 1051,
                Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",

            };
            await Task.CompletedTask;
            var result = _contextAccountInformation.DeleteAccount(model, user);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SimpleSearchCatalogue([FromBody] SimpleSearchModel data)
        {


            var result = await _contextCatalogueDefinition.SimpleSearch(data);
            return Ok(result);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AdvancedSearchCatalogue([FromBody] MTGCatalogueDefinitionSearch data)
        {


            var result = await _contextCatalogueDefinition.AdvancedSearch(data);
            return Ok(result);



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpPost]
        public MTGCatalogueDefinitionViewResponse ViewCatalogue([FromBody] int catid)
        {
            var result = _contextCatalogueDefinition.ViewByCatId(catid);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InsertCatalogue([FromBody] MTGCatalogueDefinitionInsertRequest data)
        {
            var user = new UserSessions
            {
                Usrid=1051,
                Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",

            };
            await Task.CompletedTask;
            var result = _contextCatalogueDefinition.Insert(data, user);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateCatalogue([FromBody] MTGCatalogueDefinitionUpdateRequest data)
        {
            var user = new UserSessions
            {
                Usrid = 1051,
                Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",

            };
            await Task.CompletedTask;
            var result = _contextCatalogueDefinition.Update(data, user);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteCatalogue([FromBody] MTGCatalogueDefinitionDeleteRequest data)
        {
            var user = new UserSessions
            {
                Usrid = 1051,
                Ssesionid = "0000018e-a8be-63d3-0000-018ea8be63dc",

            };
            await Task.CompletedTask;
            var result = _contextCatalogueDefinition.DeleteByCatId(data, user);
            return Ok(result);
        }


    }
}
