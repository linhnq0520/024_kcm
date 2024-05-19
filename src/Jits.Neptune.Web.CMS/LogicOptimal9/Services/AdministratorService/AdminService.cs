using Apache.NMS;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.O9Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Jits.Neptune.Core.Domain.Users;
using static LinqToDB.Common.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using System.Linq.Dynamic.Core.Tokenizer;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
using Jits.Neptune.Web.Framework.Services.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminService : IAdminServices
    {
        /// <summary>
        /// 
        /// </summary>
        public JWebUIObjectContextModel context { get; set; }
        private readonly IUserCommandService _userCommand;
        private readonly IJwtTokenService _jwtTokenService = EngineContext.Current.Resolve<IJwtTokenService>();
        private readonly IUserSessionsService _userSessionsService = EngineContext.Current.Resolve<IUserSessionsService>();

        /// <summary>
        /// </summary>
        /// <param name="userCommand"></param>
        public AdminService(IUserCommandService userCommand) 
        { 
            _userCommand = userCommand;
            context = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<List<RoleOfUser>> GetListRoleByUserId(string userid)
        {
            try
            {
                var listKey = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH.ADM_USRROLERL");

                SearchFunc sf = JsonConvert.DeserializeObject<SearchFunc>(listKey.ToString());

                sf.SetINCDTFtag("USRID");

                sf.SetValueOfFtag("USRID", userid);
                string strSql = sf.GenSearchCommonSql(O9Constants.O9_CONSTANT_OR, EnmOrderTime.InQuery, string.Empty, true);

                JToken result = O9Utils.Search(strSql, 0);
                result = sf.SearchData(result);

                // remove space of value of combobox
                string dataKey = "data";
                string lnktypeKey = "lnktype";
                JArray datat = result.Value<JArray>(dataKey);

                if (datat != null)
                {
                    foreach (JObject item in datat)
                    {
                        if (item.ContainsKey(lnktypeKey))
                        {
                            item[lnktypeKey] = item[lnktypeKey].ToString().Trim();
                        }
                    }
                }

                List<RoleOfUser> roleOfUsers = new List<RoleOfUser>();
                foreach (var item in result["data"])
                {
                    RoleOfUser roleOfUser = new RoleOfUser
                    {
                        Id = (int)item["roleid"],
                        RoleId = (int)item["roleid"],
                        UserId = (int)item["usrid"]
                    };
                    roleOfUsers.Add(roleOfUser);
                }
                if (result != null) return await Task.FromResult(roleOfUsers);
                return await Task.FromResult<List<RoleOfUser>>(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return await Task.FromResult<List<RoleOfUser>>(null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<GetUserAccountByIdResponse> GetUserAccountById(string userId)
        {
            try
            {
                var dataUserLogin = context?.InfoUser.GetUserLogin();
                var loginPortalResponse = await GetSessionByToken(dataUserLogin.Token);

                var listKeyUserProfile = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH.ADM_USER_PROFILE");

                SearchFunc sfUserProfile = JsonConvert.DeserializeObject<SearchFunc>(listKeyUserProfile.ToString());

                sfUserProfile.SetINCDTFtag("USRID");

                sfUserProfile.SetValueOfFtag("USRID", userId);//"1050");

                string strSqlUserProfile = sfUserProfile.GenSearchCommonSql(O9Constants.O9_CONSTANT_OR, EnmOrderTime.InQuery, string.Empty, true);

                JToken resultUserProfile = O9Utils.Search(strSqlUserProfile, 0);
                resultUserProfile = sfUserProfile.SearchData(resultUserProfile);

                GetUserAccountByIdResponse getUserAccountByIdResponse = null;
                foreach (var item in resultUserProfile["data"])
                {
                    getUserAccountByIdResponse = new GetUserAccountByIdResponse
                    {
                        Id = (int)item["usrid"],
                        BranchName = (string)item["brname"],
                        LoginName = (string)item["lgname"],
                        UserCode = (string)item["usrcd"],
                        UserName = (string)item["usrname"],
                        UserAccountStatus = (string)item["status"],
                        WorkingDate = loginPortalResponse.Txdt
                    };

                    var listKeyUserBranch = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH.ADM_USER_BRANCH");

                    SearchFunc sfUserBranch = JsonConvert.DeserializeObject<SearchFunc>(listKeyUserBranch.ToString());

                    sfUserBranch.SetINCDTFtag("USRCD");

                    sfUserBranch.SetValueOfFtag("USRCD", getUserAccountByIdResponse.UserCode);

                    string strSqlUserBranch = sfUserBranch.GenSearchCommonSql(O9Constants.O9_CONSTANT_OR, EnmOrderTime.InQuery, string.Empty, true);

                    JToken resultUserBranch = O9Utils.Search(strSqlUserBranch, 0);
                    resultUserBranch = sfUserBranch.SearchData(resultUserBranch);

                    foreach (var itemUserBranch in resultUserBranch["data"])
                    {
                        string branchID = (string)itemUserBranch["branchid"];

                        var listKeyBranchProfile = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH.ADM_BRANCH_PROFILE");

                        SearchFunc sfBranchProfile = JsonConvert.DeserializeObject<SearchFunc>(listKeyBranchProfile.ToString());

                        sfBranchProfile.SetINCDTFtag("BRANCHID");

                        sfBranchProfile.SetValueOfFtag("BRANCHID", branchID);

                        string strSqlBranchProfile = sfBranchProfile.GenSearchCommonSql(O9Constants.O9_CONSTANT_OR, EnmOrderTime.InQuery, string.Empty, true);

                        JToken resultBranchProfile = O9Utils.Search(strSqlBranchProfile, 0);
                        resultBranchProfile = sfBranchProfile.SearchData(resultBranchProfile).SelectToken("data").FirstOrDefault();

                        getUserAccountByIdResponse.BranchCode = resultBranchProfile.SelectToken("branchcd").ToString();
                        getUserAccountByIdResponse.BranchName = resultBranchProfile.SelectToken("brname").ToString();
                        getUserAccountByIdResponse.BranchStatus = resultBranchProfile.SelectToken("isonline").ToString() == "Yes"?"Y":"N";

                        //foreach (var itemBranchProfile in resultBranchProfile["data"])
                        //{
                        //    getUserAccountByIdResponse.BranchCode = (string)itemUserBranch["branchcd"];
                        //    getUserAccountByIdResponse.BranchName = (string)itemUserBranch["brname"];
                        //    getUserAccountByIdResponse.BranchStatus = (string)itemUserBranch["isonline"];
                        //}
                    }
                }
                getUserAccountByIdResponse.BankStatus = "ONLINE";

                if (getUserAccountByIdResponse != null) return getUserAccountByIdResponse;

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationCode"></param>
        /// <returns></returns>  
        public async Task<List<UserCommands>> GetUserCommandByApplicationCode(string applicationCode)
        {

            var listAllCommand = await _userCommand.GetAllUserCommands(applicationCode);

            if (listAllCommand != null) return listAllCommand;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationCode"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<CommandIdInfoModel>> GetUserCommandInfoFromParentId(string applicationCode, string parentId)
        {
            var listAllCommand = await _userCommand.GetUserCommandInfoFromParentId(applicationCode, parentId);

            if (listAllCommand != null) return listAllCommand;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationCode"></param>
        /// <param name="commandId"></param>
        /// <returns></returns>
        public async Task<List<CommandIdInfoModel>> GetUserCommandInfoFromCommandId(string applicationCode, string commandId)
        {
            var listAllCommand = await _userCommand.GetUserCommandInfoFromCommandId(applicationCode, commandId);

            if (listAllCommand != null) return listAllCommand;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationCode"></param>
        /// <param name="formCode"></param>
        /// <returns></returns>
        public async Task<List<UserCommands>> GetUserCommandInfoFromFormCode(string applicationCode, string formCode)
        {
            var listAllCommand = await _userCommand.GetUserCommandInfoFromFormCode(applicationCode, formCode);

            if (listAllCommand != null) return listAllCommand;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationCode"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<CommandIdInfoModel>> GetUserCommandInfoFromRoleId(string applicationCode, string roleId)
        {
            var listAllCommand = await _userCommand.GetUserCommandInfoFromRoleId(applicationCode, roleId);

            if (listAllCommand != null) return listAllCommand;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> CreateOtherToken(string token)
        {

            var currentTime = DateTimeOffset.Now;
            var expireTime = currentTime.AddDays(32400 / 24 / 60);
            var expiresInSeconds = expireTime.ToUnixTimeSeconds();

            var userSession = await _userSessionsService.GetByToken(token);

            var newToken = _jwtTokenService.GetNewJwtToken(new User
            {
                Id = userSession.Usrid,
                Username = _jwtTokenService.GetUsernameFromToken(token),
                UserCode = _jwtTokenService.GetUserCodeFromToken(token),
                BranchCode = _jwtTokenService.GetBranchCodeFromToken(token),
                LoginName = _jwtTokenService.GetLoginNameFromToken(token)
            }, expiresInSeconds);

            await _userSessionsService.Insert(new UserSessions()
            {
                UserCode = userSession.UserCode,
                Token = newToken,
                Exptime = expireTime.DateTime,
                Acttype = "I",
                Info = userSession.Info
            });

            if (!newToken.IsNullOrEmpty()) return await Task.FromResult(newToken);
            return await Task.FromResult<string>(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task LockScreen(string token)
        {
            await _userSessionsService.UpdateActtype(token, "L");

        }

        /// <summary>
        /// <param name="token"></param>
        /// <param name="applicationCode"></param>
        /// <returns></returns>
        /// </summary>

        public async Task UpdateSessionApplicationCode(string token, string applicationCode)
        {
            await _userSessionsService.UpdateSessionAndApplicationCode(token, applicationCode);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="mac"></param>
        /// <param name="applicationCode"></param>
        /// <returns></returns>
        public async Task UpdateSessionMacAndApplicationCode(string token, string mac, string applicationCode)
        {
            await _userSessionsService.UpdateSessionMacAndApplicationCode(token, mac, applicationCode);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="acttype"></param>
        /// <returns></returns>
        public async Task UpdateActtype(string token, string acttype)
        {
            await _userSessionsService.UpdateActtype(token, acttype);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> VerifyPassword(string username, string password)
        {
            JsonLogin loginRequest = new JsonLogin();
            loginRequest.L = username;
            loginRequest.P = O9Encrypt.MD5Encrypt(password);
            loginRequest.A = false;

            string strResult = await Task.Run(() => O9Utils.GenJsonBodyRequest(loginRequest, GlobalVariable.UMG_LOGIN, "", EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, "-1", MsgPriority.Normal));

            if (strResult != null) { return true; }
            else
            {
                JsonLogin _loginRequest = new JsonLogin();
                _loginRequest.L = username;
                _loginRequest.P = password;
                _loginRequest.A = false;

                string _strResult = await Task.Run(() => O9Utils.GenJsonBodyRequest(loginRequest, GlobalVariable.UMG_LOGIN, "", EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, "-1", MsgPriority.Normal));

                if (_strResult != null) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task UpdateSessionInfo(string token, string info)
        {
            await _userSessionsService.UpdateSessionAndInfo(token, info);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="mac"></param>
        /// <returns></returns>
        public async Task UpdateSessionMac(string token, string mac)
        {
            await _userSessionsService.UpdateSessionMac(token, mac);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task DeleteToken(string token)
        {
            await _userSessionsService.DeleteToken(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="applicationCode"></param>
        /// <param name="currentToken"></param>
        /// <returns></returns>
        public async Task DeleteAllAppToken(string userId, string applicationCode, string currentToken)
        {
            await _userSessionsService.DeleteAllAppToken(userId, applicationCode, currentToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UserSessions> GetSessionByToken(string token)
        {
            return await _userSessionsService.GetByToken(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="mac"></param>
        /// <returns></returns>
        public async Task<ValidateSessionModel> CheckValidSingleSession(string loginName, string mac)
        {
            var userSessions = await _userSessionsService.GetListUserSessionByLoginNameAndEqualMac(loginName, mac);
            if (userSessions != null)
            {
                return new ValidateSessionModel
                {
                    SessionMode = "",
                    IsValid = true
                };
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="mac"></param>
        /// <returns></returns>
        public async Task<List<UserSessions>> ListUserSessionByLoginNameAndNotEqualMac(string loginName, string mac)
        {
            return await _userSessionsService.GetListUserSessionByLoginNameAndNotEqualMac(loginName, mac);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CodeList>> GetAllCodeList()
        {

            try
            {

                var listKey = O9Client.memCached.GetValue(GlobalVariable.O9_GLOBAL_COMCODE + ".SEARCH.ADM_SYSTEM_CODE_TABLE");

                SearchFunc sf = JsonConvert.DeserializeObject<SearchFunc>(listKey.ToString());

                string strSql = sf.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

                JToken result = O9Utils.Search(strSql, 0);
                result = sf.SearchData(result);

                List<CodeList> codeList = new List<CodeList>();
                foreach (var item in result["data"])
                {
                    CodeList cdList = new CodeList
                    {
                        CodeId = (string)item["cdid"],
                        CodeName = (string)item["cdname"],
                        Caption = (string)item["caption"],
                        CodeGroup = (string)item["cdgrp"],
                        CodeIndex = (int)item["cdidx"],
                        Ftag = (string)item["ftag"]

                    };
                    codeList.Add(cdList);
                }
                if (result != null) return await Task.FromResult(codeList);
                return await Task.FromResult<List<CodeList>>(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return await Task.FromResult<List<CodeList>>(null);
            }
        }
    }
}
