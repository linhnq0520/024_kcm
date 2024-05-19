using Jits.Neptune.Core;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Controllers;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LinqToDB.Common.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerLinkageService : ICustomerLinkageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerLinkageResponseSearch, CustomerLinkageResponseSearch>> AdvanceSearch(AdvanceSearchCustomerLinkageRequest model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;
            var modelSearch = O9Utils.SearchFunc(model, "CTM_CUSTOMER_LINKAGE");

            await Task.CompletedTask;
            string strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            JToken result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var responses = result.DataListToPagedList<CustomerLinkageResponseSearch>(model.PageIndex, model.PageSize);
            return responses.ToPagedListModel<CustomerLinkageResponseSearch, CustomerLinkageResponseSearch>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerLinkageResponseSearch, CustomerLinkageResponseSearch>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "CTM_CUSTOMER_LINKAGE");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);

            var response = result.DataListToPagedList<CustomerLinkageResponseSearch>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CustomerLinkageResponseSearch, CustomerLinkageResponseSearch>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerLinkageViewResponseModel GetById(int id)
        {
            var value = new CustomerLinkageViewResponseModel();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, "CTM_GET_CTMLKG");
                var listKey = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH." + "CTM_CUSTOMER_LINKAGE_LIST");
                var modelSearch = JsonConvert.DeserializeObject<SearchFunc>(listKey);
                modelSearch.SetValueOfFtag("LKGID", id);
                var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
                var result = O9Utils.Search(strSql, 0);

                result = modelSearch.SearchData(result);

                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    value = System.Text.Json.JsonSerializer.Deserialize<CustomerLinkageViewResponseModel>(JsonConvert.SerializeObject(jsResult));

                    var jsResult1 = result.SelectToken("data").ToObject<JArray>();

                    value.LinkageDetailList  = System.Text.Json.JsonSerializer.Deserialize<List<LinkageDetailResponse>>(JsonConvert.SerializeObject(jsResult1));
                }

                return value;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public JObject Create(CustomerLinkageRequestInsertModel model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {
                JsonTableName clsJson = new JsonTableName();
                JObject jsRequest = model.ToUpperPropertyName();
                jsRequest.Remove("LINKAGEDETAILLIST");
                clsJson.TXBODY.Add(new JsonData(tableName, jsRequest));

                JObject jsLinkageDetail = new JObject();

                
                var linkageStatusValues = new List<string>();
                var linkageTypeValues = new List<string>();
                var detailCustomerIdValues = new List<int>();

                
                foreach (var item in model.LinkageDetailList)
                {
                    
                    linkageStatusValues.Add(item.LinkageStatus);
                    linkageTypeValues.Add(item.LinkageType);
                    detailCustomerIdValues.Add(item.DetailCustomerId);
                }

                
                jsLinkageDetail.Add("STATUS", JToken.FromObject(linkageStatusValues));
                jsLinkageDetail.Add("LKGTYPE", JToken.FromObject(linkageTypeValues));
                jsLinkageDetail.Add("DCUSTOMERID", JToken.FromObject(detailCustomerIdValues));


                
                clsJson.TXBODY.Add(new JsonData("O9DATA.D_CTMLKGRL", jsLinkageDetail));

                string result = O9Utils.GenJsonBackOfficeRequest(userSessions, txCode, clsJson.TXBODY);

                JObject jsResult = O9Utils.AnalysisBackOfficeResult(result);
                jsRequest = jsResult.ConvertToJObject();
                return jsRequest;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userSessions"></param>
        /// <param name="tableName"></param>
        /// <param name="txCode"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public JObject Update(CustomerLinkageRequestUpdateModel model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {
                JsonTableName clsJson = new JsonTableName();
                JObject jsRequest = model.ToUpperPropertyName();
                jsRequest.Remove("LINKAGEDETAILLIST");
                clsJson.TXBODY.Add(new JsonData(tableName, jsRequest));

                JObject jsLinkageDetail = new JObject();


                var linkageStatusValues = new List<string>();
                var linkageTypeValues = new List<string>();
                var detailCustomerIdValues = new List<int>();
                var linkageidValues = new List<int>();


                foreach (var item in model.LinkageDetailList)
                {

                    linkageStatusValues.Add(item.LinkageStatus);
                    linkageTypeValues.Add(item.LinkageType);
                    detailCustomerIdValues.Add(item.DetailCustomerId);
                    linkageidValues.Add(item.lkgid);
                }


                jsLinkageDetail.Add("STATUS", JToken.FromObject(linkageStatusValues));
                jsLinkageDetail.Add("LKGTYPE", JToken.FromObject(linkageTypeValues));
                jsLinkageDetail.Add("DCUSTOMERID", JToken.FromObject(detailCustomerIdValues));
                jsLinkageDetail.Add("LKGID", JToken.FromObject(linkageidValues));

                clsJson.TXBODY.Add(new JsonData("O9DATA.D_CTMLKGRL", jsLinkageDetail));

                string result = O9Utils.GenJsonBackOfficeRequest(userSessions, txCode, clsJson.TXBODY);

                JObject jsResult = O9Utils.AnalysisBackOfficeResult(result);
                jsRequest = jsResult.ConvertToJObject();
                return jsRequest;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }
    }
}
