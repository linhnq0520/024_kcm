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
using System.Linq;
using System.Threading.Tasks;
using static LinqToDB.Common.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerGroupService : ICustomerGroupService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerGroupResponseSearch, CustomerGroupResponseSearch>> AdvanceSearch(AdvanceSearchCustomerGroupRequest model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;
            var modelSearch = O9Utils.SearchFunc(model, "CTM_CUSTOMER_GROUP");

            await Task.CompletedTask;
            string strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            JToken result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var responses = result.DataListToPagedList<CustomerGroupResponseSearch>(model.PageIndex, model.PageSize);
            return responses.ToPagedListModel<CustomerGroupResponseSearch, CustomerGroupResponseSearch>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<PagedListModel<CustomerGroupResponseSearch, CustomerGroupResponseSearch>> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            await Task.CompletedTask;
            var searchFunc = O9Utils.SearchFunc(model, "CTM_CUSTOMER_GROUP");
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);

            var response = result.DataListToPagedList<CustomerGroupResponseSearch>(model.PageIndex, model.PageSize);
            return response.ToPagedListModel<CustomerGroupResponseSearch, CustomerGroupResponseSearch>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerGroupViewResponseModel GetById(int id)
        {
            var value = new CustomerGroupViewResponseModel();
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, "CTM_GET_GRP");
                //JToken jsResult = JToken.Parse(strJsonResult);
                var listKey = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH." + "CTM_CUSTOMER_GROUP_CUST_GRP");
                var modelSearch = JsonConvert.DeserializeObject<SearchFunc>(listKey);
                modelSearch.SetValueOfFtag("GRPID", id);
                var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
                var result = O9Utils.Search(strSql, 0);

                result = modelSearch.SearchData(result);

                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    value = System.Text.Json.JsonSerializer.Deserialize<CustomerGroupViewResponseModel>(JsonConvert.SerializeObject(jsResult));

                    var jsResult1 = result.SelectToken("data").ToObject<JArray>();

                    var groupcode = jsResult["grpcd"].ToString();

                    var listKey_groupleader = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH." + "CTM_CUSTOMER_GROUP");
                    var modelSearch_groupleader = JsonConvert.DeserializeObject<SearchFunc>(listKey_groupleader);
                    modelSearch_groupleader.SetValueOfFtag("GRPCD", groupcode);
                    var strSql_groupleader = modelSearch_groupleader.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true); //GenSearchCommonSql("", EnmOrderTime.InQuery, string.Empty, true);
                    var result_groupleader = O9Utils.Search(strSql_groupleader, 0);

                    result_groupleader = modelSearch_groupleader.SearchData(result_groupleader);

                    var leaderCode = result_groupleader.SelectToken("data[0].mmemberid").ToObject<string>();

                    value.ListMembers = System.Text.Json.JsonSerializer.Deserialize<List<ListMembersResponse>>(JsonConvert.SerializeObject(jsResult1));

                    var leader = value.ListMembers.Where(s => s.customercd == leaderCode).FirstOrDefault();
                    if(leader != null)
                    {
                        value.ListMembers.Remove(leader);
                        leader.is_group_leader = 1;
                        leader.mmemberid = leaderCode;
                        value.ListMembers.Add(leader);
                    }
                }
                //var objList = System.Text.Json.JsonSerializer.Deserialize<CustomerGroupViewResponseModel>(JsonConvert.SerializeObject(jsResult));
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
        public JObject Update(CustomerGroupRequestUpdateModel model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {
                JsonTableName clsJson = new JsonTableName();
                JObject jsRequest = model.ToUpperPropertyName();
                jsRequest.Remove("LISTMEMBERS");
                

                JObject jsLinkageDetail = new JObject();


                var listMemberidValues = new List<string>();
                var listGrpidIdValues = new List<int>();
                var GroupLeader = "";


                foreach (var item in model.ListMembers)
                {

                    listMemberidValues.Add(item.memberid);
                    listGrpidIdValues.Add(model.grpid);
                    if (item.mmemberid != null && item.mmemberid != "")
                    {
                        GroupLeader = item.mmemberid;
                    }
                }


                jsLinkageDetail.Add("MEMBERID", JToken.FromObject(listMemberidValues));
                jsLinkageDetail.Add("GRPID", JToken.FromObject(listGrpidIdValues));

                jsRequest.Add("MMEMBERID", JToken.FromObject(GroupLeader));

                clsJson.TXBODY.Add(new JsonData(tableName, jsRequest));

                clsJson.TXBODY.Add(new JsonData("O9DATA.D_CTMGRPRL", jsLinkageDetail));

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
        public JObject Create(CustomerGroupRequestInsertModel model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {
                JsonTableName clsJson = new JsonTableName();
                JObject jsRequest = model.ToUpperPropertyName();
                jsRequest.Remove("LISTMEMBERS");
                

                JObject jsLinkageDetail = new JObject();


                var listMemberidValues = new List<string>();
                var GroupLeader = "";


                foreach (var item in model.ListMembers)
                {

                    listMemberidValues.Add(item.memberid);
                    if (item.mmemberid != null && item.mmemberid != "")
                    {
                        GroupLeader = item.mmemberid;
                    }
                     
                }


                jsLinkageDetail.Add("MEMBERID", JToken.FromObject(listMemberidValues));
                jsRequest.Add("MMEMBERID", JToken.FromObject(GroupLeader));

                clsJson.TXBODY.Add(new JsonData(tableName, jsRequest));

                clsJson.TXBODY.Add(new JsonData("O9DATA.D_CTMGRPRL", jsLinkageDetail));

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
