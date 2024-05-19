using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Controllers;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Utils;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Common.O9Constants;
using static LinqToDB.Common.Configuration;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core;
using Jits.Neptune.Data;
using System.Linq;
using Jits.Neptune.Web.Framework.Models.Extensions;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using Jits.Neptune.Web.Framework.Models.Neptune;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerProfileService : ICustomerProfileService
    {
        private readonly ICodeListService _codeListService;
        private IRepository<Cdlist> _cdlistRepository;
        //private readonly StringComparison ICIC = StringComparison.InvariantCultureIgnoreCase;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdlistRepository"></param>
        /// <param name="codeListService"></param>
        public CustomerProfileService(IRepository<Cdlist> cdlistRepository, ICodeListService codeListService)
        {
            _cdlistRepository = cdlistRepository;
            _codeListService = codeListService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>> AdvanceSearch(SimpleSearchCustomerProfileRequest model)
        {
            var modelSearch = O9Utils.SearchFunc(model, "CTM_CUSTOMER_PROFILE");

            await Task.CompletedTask;
            string strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            JToken result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var responses = result.DataListToPagedList<CustomerProfileResponseSearch>(model.PageIndex, model.PageSize);
            return responses.ToPagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "CTM_CUSTOMER_PROFILE");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, 0);

            result = searchFunc.SearchData(result);

            var response = result.DataListToPagedList<CustomerProfileResponseSearch>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerViewResponseModel> View(int id)
        {
            await Task.CompletedTask;
            var ModelCustomerIdNew = new ViewWithCustomerIdString()
            {
                CUSTOMERID = id.ToString(),
            };
            JObject jsonObject = JObject.FromObject(ModelCustomerIdNew);

            var user = new UserSessions();

            var result = O9Utils.GenJsonFunctionRequest(user, "003001", jsonObject, "O9SYS.CUSTOMER_INQUIRY");
            JToken jsResult = JToken.Parse(result);
            var resultView = jsResult.SelectToken("m.v");

            resultView["SIDDT"] = O9Utils.ConvertStringToDateTime(resultView["SIDDT"].ToString());
            resultView["IDDT"] = O9Utils.ConvertStringToDateTime(resultView["IDDT"].ToString());
            resultView["IDEXPDT"] = O9Utils.ConvertStringToDateTime(resultView["IDEXPDT"].ToString());
            resultView["OPNDT"] = O9Utils.ConvertStringToDateTime(resultView["OPNDT"].ToString());
            resultView["LASTDT"] = O9Utils.ConvertStringToDateTime(resultView["LASTDT"].ToString());
            resultView["APRDT"] = O9Utils.ConvertStringToDateTime(resultView["APRDT"].ToString());
            resultView["JOINDT"] = O9Utils.ConvertStringToDateTime(resultView["JOINDT"].ToString());
            resultView["SIDEXPDT"] = O9Utils.ConvertStringToDateTime(resultView["SIDEXPDT"].ToString());
            resultView["EPYDT"] = O9Utils.ConvertStringToDateTime(resultView["EPYDT"].ToString());
            resultView["DOB"] = O9Utils.ConvertStringToDateTime(resultView["DOB"].ToString());
            resultView["ANNIVERSARY"]["B"] = O9Utils.ConvertStringToDateTime(resultView["ANNIVERSARY"]["B"].ToString());
            resultView["ANNIVERSARY"]["M"] = O9Utils.ConvertStringToDateTime(resultView["ANNIVERSARY"]["M"].ToString());
            resultView["ANNIVERSARY"]["G"] = O9Utils.ConvertStringToDateTime(resultView["ANNIVERSARY"]["G"].ToString());


            var objList = System.Text.Json.JsonSerializer.Deserialize<CustomerViewResponseModel>(JsonConvert.SerializeObject(resultView));
            return objList;
        }
        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CustomerUpdateResponseModel Update(CustomerUpdateRequestModel model, UserSessions userSessions, string tableName, string txCode)
        {

            model.ANNIVERSARY.M = model.ANNIVERSARY.MarriedDate?.ToString("dd/MM/yyyy");
            model.ANNIVERSARY.G = model.ANNIVERSARY.GraduationDate?.ToString("dd/MM/yyyy");
            model.ANNIVERSARY.B = model.ANNIVERSARY.StartingDateOfCompany?.ToString("dd/MM/yyyy");

            JObject jsRequest = model.ToUpperPropertyName();
            var backOffice = O9Utils.BackOffice(userSessions, txCode, tableName, jsRequest);
            var result = backOffice.ToResponseModel<CustomerUpdateResponseModel>();
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        public int Insert(CustomerInsertRequestModel model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {
                model.ANNIVERSARY.M = model.ANNIVERSARY.MarriedDate?.ToString("dd/MM/yyyy");
                model.ANNIVERSARY.G = model.ANNIVERSARY.GraduationDate?.ToString("dd/MM/yyyy");
                model.ANNIVERSARY.B = model.ANNIVERSARY.StartingDateOfCompany?.ToString("dd/MM/yyyy");
                model.SUBSECTOR = "1";
                model.SECTOR = "1";
                JObject jsRequest = model.ToUpperPropertyName();

                //var rs = O9Utils.BackOffice(userSessions, "003001000002", "O9DATA.D_CUSTOMER", model);
                //var backOffice = O9Utils.BackOffice(userSessions, txCode, tableName, jsRequest);
                JsonTableName clsJson = new();

                clsJson.TXBODY.Add(new JsonData(tableName, jsRequest));
                string stringResult =
                O9Utils.GenJsonBackOfficeRequest(userSessions, txCode, clsJson.TXBODY);

                JObject jsResult = O9Utils.AnalysisBOResult(stringResult);
                return jsResult.SelectToken("result.customerid").ToInt();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception(ex.Message);
            }

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<Cdlist>> LookupDataCommune(CodeListModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;
            var query = await (from cd in _cdlistRepository.Table
                        where cd.Cdname == model.Cdname &&
                              (cd.Cdid.Substring(0, 2) == (model.Cdid.Substring(0, 2))) &&
                              cd.Cdgrp == model.Cdgrp
                               orderby cd.Cdidx
                               select new Cdlist
                            {
                                Cdid =  cd.Cdid,
                                Caption = cd.Caption,
                                Cdname = cd.Cdname,
                                Id = cd.Id
                            }).ToListAsync();

            var pagedCodeList = await query.AsQueryable().ToPagedList<Cdlist>(model.PageIndex, model.PageSize);
            return pagedCodeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CodeListSearchResponseModel GetInforCdname(CodeListPrimaryKey model)
        {
            var resutl = _codeListService.GetByPrimaryKey(model).GetAwaiter().GetResult();
            return resutl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<Cdlist>> LookupDataforPrimarykey(CodeListModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;
            var query = await (from cd in _cdlistRepository.Table
                               where cd.Cdname == model.Cdname &&
                                     cd.Visible == 1 &&
                                     cd.Cdgrp == model.Cdgrp
                                    orderby cd.Cdidx
                               select new Cdlist
                               {
                                   Cdid = cd.Cdid,
                                   Caption = cd.Caption,
                                   Cdname = cd.Cdname,
                                   Id = cd.Id
                               }).ToListAsync();

            var pagedCodeList = await query.AsQueryable().ToPagedList<Cdlist>(model.PageIndex, model.PageSize);
            return pagedCodeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<IPagedList<Cdlist>> LookupDataSUBINDUSTRYOrSSRCINCOME(CodeListModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;
            var query = await (from cd in _cdlistRepository.Table
                               where cd.Cdname == model.Cdname &&
                                     (cd.Cdid.Substring(0, 2) == model.Cdid) &&
                                     cd.Cdgrp == model.Cdgrp &&
                                     cd.Visible == 1
                               orderby cd.Cdidx
                               select new Cdlist
                               {
                                   Cdid = cd.Cdid,
                                   Caption = cd.Caption,
                                   Cdname = cd.Cdname,
                                   Id = cd.Id
                               }).ToListAsync();

            var pagedCodeList = await query.AsQueryable().ToPagedList<Cdlist>(model.PageIndex, model.PageSize);
            return pagedCodeList;
        }
    }
}
