using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface;
using Jits.Neptune.Web.CMS.Models.Request.Job;
using Jits.Neptune.Web.Framework.Models;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Models.Request.Cash;
using System;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models.Request.Mortgage;
using Jits.Neptune.Web.CMS.Models.Response.Mortgage;
using static LinqToDB.Common.Configuration;
using Jits.Neptune.Web.Framework.Models.Neptune;
using System.Globalization;
using Microsoft.VisualBasic;
using Microsoft.IdentityModel.Tokens;




namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService
{
    /// <summary>
    ///  Service accouting
    /// </summary>
    public class MortgageAccountInformationService : IMortgageAccountInformationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<PagedListModel<MTGAccountInformationResponse, MTGAccountInformationResponse>> AdvanceSearch(MTGAccountInformationSearch model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "MTG_ACCOUNT_INFORMATION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);
            Console.WriteLine("data test"+strSql);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<MTGAccountInformationResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<MTGAccountInformationResponse, MTGAccountInformationResponse>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<MTGAccountInformationResponse, MTGAccountInformationResponse>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var modelSearch = O9Utils.SearchFunc(model, "MTG_ACCOUNT_INFORMATION");
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<MTGAccountInformationResponse>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<MTGAccountInformationResponse, MTGAccountInformationResponse>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public MTGAccountInformationViewResponse ViewAccount(MTGAccountViewRequest model, UserSessions userSessions)
        {
            var value = new MTGAccountInformationViewResponse();
            JObject jsRequest = new JObject();
            try
            {

                string id = model.acno;
                string wffunc = model.workflowFun;
                string ftag = "PDACC";
                string isregKey = "isreg";
                string otherPaperKey = "opaper";
                jsRequest.Add(ftag, id);

                JsonFrontOffice result = O9Utils.PostFrontOffice(userSessions, wffunc, jsRequest);
                if(result.RESULT.ContainsKey(isregKey) && string.IsNullOrEmpty(result.RESULT.Value<string>(isregKey).ToString()))
                {
                    result.RESULT[isregKey] = null;
                }
                JArray otherPaper = new JArray();
                if (result.RESULT.ContainsKey(otherPaperKey))
                {
                    Object otherPapers = result.RESULT.Value<JObject>(otherPaperKey);
                    if (otherPaper != null)
                    {
                        Console.WriteLine("VIEW ACCOUNTING DATA");
                    }
                }
                JObject jsResult = JObject.Parse(result.RESULT.ToString());

                value = System.Text.Json.JsonSerializer.Deserialize<MTGAccountInformationViewResponse>(JsonConvert.SerializeObject(jsResult));
                value.open_date = (DateTime)(string.IsNullOrEmpty(value.OPNDT) ? DateTime.Now : (DateTime)O9Utils.ConvertStringToDateTime(value.OPNDT));
                value.close_date = (DateTime)(string.IsNullOrEmpty(value.CLSDT) ? DateTime.Now : (DateTime)O9Utils.ConvertStringToDateTime(value.CLSDT));
                value.last_transaction_date = (DateTime)(string.IsNullOrEmpty(value.LASTDT) ? DateTime.Now : (DateTime)O9Utils.ConvertStringToDateTime(value.LASTDT));
                value.evaluate_date = (DateTime)(string.IsNullOrEmpty(value.VALRDT) ? DateTime.Now : (DateTime)O9Utils.ConvertStringToDateTime(value.VALRDT));
                //value.receiv_date = (DateTime)(string.IsNullOrEmpty(value.REIVDT) ? DateTime.Now : (DateTime)O9Utils.ConvertStringToDateTime(value.REIVDT));
                
                //value.open_date = (DateTime)O9Utils.ConvertStringToDateTime(value.OPNDT);              
                //value.close_date = (DateTime)O9Utils.ConvertStringToDateTime(value.CLSDT);
                //value.last_transaction_date = (DateTime)O9Utils.ConvertStringToDateTime(value.LASTDT);
                //value.evaluate_date = (DateTime)O9Utils.ConvertStringToDateTime(value.VALRDT);
                return value;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }


        /// <summary>
        /// Insert Account
        /// </summary>
        public MTGAccountInsertRequest InsertAccount(MTGAccountInsertRequest model, UserSessions userSessions)
        {
            var backOffice = O9Utils.BackOffice(userSessions, "010002000003", "o9sys.v_mortgage", model);
            var result = backOffice.ToResponseModel<MTGAccountInsertRequest>();
            return result;
        }


        /// <summary>
        /// update Account 
        /// </summary>
        public MTGAccountUpdateRequest UpdateAccount(MTGAccountUpdateRequest model, UserSessions userSessions)
        {
            var backOffice = O9Utils.BackOffice(userSessions, "010002000004", "O9DATA.D_MORTGAGE", model);
            var result = backOffice.ToResponseModel<MTGAccountUpdateRequest>();
            return result;
        }
        /// <summary>
        /// update Account 
        /// </summary>
        public MTGAccountDeleteRequest DeleteAccount(MTGAccountDeleteRequest model, UserSessions userSessions)
        {
            var backOffice = O9Utils.BackOffice(userSessions, "010002000005", "O9DATA.D_MORTGAGE", model);
            var result = backOffice.ToResponseModel<MTGAccountDeleteRequest>();

            return result;
        }
    }
}
