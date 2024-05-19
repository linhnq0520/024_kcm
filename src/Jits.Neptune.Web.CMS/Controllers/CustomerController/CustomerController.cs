using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Helpers;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static LinqToDB.Common.Configuration;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

namespace Jits.Neptune.Web.CMS.Controllers;
/// <summary>
/// 
/// </summary>
public class CustomerController : BaseController
{
    private readonly ICustomerProfileService _customerProfileService = EngineContext.Current.Resolve<ICustomerProfileService>();
    private readonly ICustomerGroupService _customerGroupService = EngineContext.Current.Resolve<ICustomerGroupService>();
    private readonly ICustomerLinkageService _customerLinkageService = EngineContext.Current.Resolve<ICustomerLinkageService>();
    private readonly ICustomerMediaService _customerMediaService = EngineContext.Current.Resolve<ICustomerMediaService>();
    private readonly JWebUIObjectContextModel context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();

    /// <summary>
    /// 
    /// </summary>
    public CustomerController()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost("AdvanceSearch")]
    //public async Task<IActionResult> AdvanceSearch1([FromBody] SimpleSearchCustomerProfileRequest data)
    public async Task<IActionResult> AdvanceSearch1([FromBody] dynamic data)
    {
        await Task.CompletedTask;
        var listKey = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH.CTM_CUSTOMER_LINKAGE_LIST");
        var modelSearch = JsonConvert.DeserializeObject<SearchFunc>(listKey);

        JObject js = data;

        foreach (var item in js.Properties())
        {
            modelSearch.SetValueOfFtag(item.Name, item.Value);
        }

        //var modelSearch = O9Utils.SearchFunc(data, "CTM_CUSTOMER_GROUP");


        string strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

        JToken result = O9Utils.Search(strSql);
        result = modelSearch.SearchData(result);


        //JObject resultObject = result as JObject;
        //if (resultObject != null)
        //{
        //    JArray dataArray = resultObject["data"] as JArray;
        //    if (dataArray != null)
        //    {
        //        for (int i = 0; i < dataArray.Count; i++)
        //        {
        //            JToken dobToken = dataArray[i]["dob"];
        //            long dobTimestamp = dobToken.Value<long>();
        //            DateTime dobDate = DateTimeOffset.FromUnixTimeMilliseconds(dobTimestamp).UtcDateTime;
        //            dataArray[i]["dob"] = dobDate.ToString("yyyy-MM-dd");
        //        }
        //    }
        //}

        //var responses = result.DataListToPagedList<CustomerProfileResponseSearch>(data.PageIndex, 20);
        //return Ok(responses.ToPagedListModel<CustomerProfileResponseSearch, CustomerProfileResponseSearch>());
        //var a = System.Text.Json.JsonSerializer.Deserialize<SimpleSearchCustomerProfileResponse>(JsonConvert.SerializeObject(result));
        return Ok(result);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SimpleSearch([FromBody] SimpleSearchModel model)
    {
        var result = await _customerMediaService.SimpleSearch(model);
        return Ok(result);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AdvanceSearch([FromBody] AdvanceSearchCustomerLinkageRequest model)
    {
        var result = await _customerLinkageService.AdvanceSearch(model);
        return Ok(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> ViewLinkage([FromBody] ModelWithId model)
    {
        await Task.CompletedTask;
        var result =  _customerLinkageService.GetById(model.Id);
        return Ok(result);
    }

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="model"></param>
    ///// <returns></returns>
    //[HttpPost]
    //public async Task<IActionResult> insert([FromBody] CustomerInsertRequestModel model)
    //{
    //    var userSessions = new UserSessions
    //    {
    //        Usrid = 1372,
    //        Ssesionid = "0000018e-c09c-0626-0000-018ec09c062f",
    //    };
    //    await Task.CompletedTask;
        
    //    var result = _customerProfileService.Insert(model, userSessions);
    //    return Ok(result);
    //}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult View([FromBody] ViewWithCustomerId model)
    {
        var ModelCustomerIdNew = new ViewWithCustomerIdString()
        {
            CUSTOMERID = model.CUSTOMERID.ToString(),
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

        JObject jsResultnew = JObject.Parse(resultView.ToString());
        //jsResultnew.ConvertListDateStringToLong();

        var objList = System.Text.Json.JsonSerializer.Deserialize<CustomerViewResponseModel>(JsonConvert.SerializeObject(jsResultnew));
        return Ok(objList);
    }

}