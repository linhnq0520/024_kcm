using Apache.NMS;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.O9Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Core.Domain.Users;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Core;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.IdentityModel.Tokens;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public class AuthenticateService : IAuthenticateService
{
    private readonly IJwtTokenService _jwtTokenService = EngineContext.Current.Resolve<IJwtTokenService>();
    private readonly IUserSessionsService _userSessionsService = EngineContext.Current.Resolve<IUserSessionsService>();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    public async Task<JToken> Login(WorkflowExecuteModel workflow)//O9LoginRequest model)
    {
        var model = workflow.fields.ToModel<O9LoginRequest>();
        JsonLoginResponse clsJsonLoginResponse;
        TransactionResponse authenticate = new TransactionResponse();
        JsonLogin loginRequest = new JsonLogin
        {
            L = model.Username,
            P = model.encrypt ? model.Password : O9Encrypt.MD5Encrypt(model.Password),
            A = false
        };

        string strResult = await Task.Run(() => O9Utils.GenJsonBodyRequest(loginRequest, GlobalVariable.UMG_LOGIN, "", EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, "-1", MsgPriority.Normal));

        clsJsonLoginResponse = JsonConvert.DeserializeObject<JsonLoginResponse>(strResult);

        var jsonResponse = JsonConvert.DeserializeObject<JObject>(strResult);

        var user = jsonResponse["usrac"];
        if(!user.IsNullOrEmpty())
        {
            var position = JsonConvert.DeserializeObject<Position>(JsonConvert.SerializeObject(user["position"]));

            clsJsonLoginResponse.position = position;
        }
        
        var currentTime = DateTimeOffset.Now;
        var expireTime = currentTime.AddDays(32400 / 24 / 60);
        var expiresInSeconds = expireTime.ToUnixTimeSeconds();

        var token = _jwtTokenService.GetNewJwtToken(new User
        {
            Id = clsJsonLoginResponse.id,
            Username = clsJsonLoginResponse.user_name,
            UserCode = clsJsonLoginResponse.user_code,
            BranchCode = clsJsonLoginResponse.branch_code,
            LoginName = clsJsonLoginResponse.login_name
        }, expiresInSeconds);

        clsJsonLoginResponse.token = token;
        clsJsonLoginResponse.expire_time = expireTime;

        ResponseLoginToCMS responseLoginToCMS = new ResponseLoginToCMS
        {
            login = clsJsonLoginResponse
        };

        JToken response_data = JToken.Parse(System.Text.Json.JsonSerializer.Serialize(responseLoginToCMS));

        UserSessions userSessions = new UserSessions
        {
            Usrid = clsJsonLoginResponse.id,
            UserCode = clsJsonLoginResponse.user_code,
            Ssesionid = clsJsonLoginResponse.uuid,
            UsrBranch = clsJsonLoginResponse.branch_code,
            UsrBranchid = clsJsonLoginResponse.branch_id,
            Usrname = clsJsonLoginResponse.user_name,
            Lang = clsJsonLoginResponse.lang,
            Txdt = clsJsonLoginResponse.working_date.Value,
            Exptime = clsJsonLoginResponse.expire_time.DateTime,
            Token = clsJsonLoginResponse.token,
            Acttype = "I",
            CommandList = string.Join(",", jsonResponse["menuarc"]) + "," + string.Join(",", jsonResponse["txdef"]),
            ResetPassword = responseLoginToCMS.login.reset_password
        };

        await _userSessionsService.Insert(userSessions);
        return response_data.BuildWorkflowResponseSuccess(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    /// <exception cref="NeptuneException"></exception>
    public virtual async Task<JToken> CheckLoginApprove(WorkflowExecuteModel workflow)
    {
        var model = workflow.fields.ToModel<O9LoginRequest>();
        try
        {
            JsonLogin loginRequest = new ()
            {
                L = model.Username,
                P = model.encrypt ? model.Password : O9Encrypt.MD5Encrypt(model.Password),
            };

            string strResult = await Task.Run(() => O9Utils.GenJsonBodyRequest(loginRequest, "UMG_CHECK_LOGIN", "", EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, "0", MsgPriority.Normal));

            JsonLoginResponse clsJsonLoginResponse = JsonConvert.DeserializeObject<JsonLoginResponse>(strResult);

            var jsonResponse = JsonConvert.DeserializeObject<JObject>(strResult);
            if (jsonResponse == null)
            {
                throw new Exception("An error occurred while checking the login!");
            }

            var currentTime = DateTimeOffset.Now;
            var expireTime = currentTime.AddDays(32400 / 24 / 60);
            var expiresInSeconds = expireTime.ToUnixTimeSeconds();

            var token = _jwtTokenService.GetNewJwtToken(new User
            {
                Id = clsJsonLoginResponse.id,
                Username = clsJsonLoginResponse.user_name,
                UserCode = clsJsonLoginResponse.user_code,
                BranchCode = clsJsonLoginResponse.branch_code,
                LoginName = clsJsonLoginResponse.login_name
            }, expiresInSeconds);

            clsJsonLoginResponse.token = token;
            clsJsonLoginResponse.expire_time = expireTime;

            AuthenticateApproveResponseModel response = new()
            {
                Id = clsJsonLoginResponse.id,
                StaticToken = token
            };

            return JToken.FromObject(response).BuildWorkflowResponseSuccess(false);
        }
        catch (Exception ex)
        {
            return ex.Message.BuildWorkflowResponseError();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateApproveResponseModel : BaseNeptuneModel
    {
        /// <summary>
        ///  Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StaticToken { get; set; }
    }
}
