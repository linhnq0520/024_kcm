using Apache.NMS;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Common.O9Constants;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;
using static LinqToDB.Common.Configuration;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccountService : IUserAccountService
    {
        private readonly IBranchProfileService _branchService;
        private readonly IDepartmentProfileService _departmentService;
        private readonly IUserPolicyService _policyService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchService"></param>
        /// <param name="departmentService"></param>
        /// <param name="policyService"></param>
        public UserAccountService(IBranchProfileService branchService, IDepartmentProfileService departmentService,
            IUserPolicyService policyService)
        {
            _branchService = branchService;
            _departmentService = departmentService;
            _policyService = policyService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<UserAccountSearchResponseModel> AdvanceSearch(UserAccountSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var modelSearch = O9Utils.SearchFunc(model, O9Constants.SFUNC.O9SYS_V_USRAC);
            var strSql = modelSearch.GenSearchCommonSql(O9Constants.O9_CONSTANT_AND, EnmOrderTime.InQuery, string.Empty, true);

            var result = O9Utils.Search(strSql, model.PageIndex);
            result = modelSearch.SearchData(result);

            var response = result.DataListToPagedList<UserAccountSearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IPagedList<UserAccountSearchResponseModel> SimpleSearch(SimpleSearchModel model)
        {
            model.PageSize = model.PageSize == 0 ? int.MaxValue : model.PageSize;

            var searchFunc = O9Utils.SearchFunc(model, O9Constants.SFUNC.O9SYS_V_USRAC);
            var strSql = searchFunc.GenSearchCommonSql(model.SearchText, "", EnmOrderTime.InQuery, true);
            var result = O9Utils.Search(strSql, model.PageIndex);

            result = searchFunc.SearchData(result);
            var response = result.DataListToPagedList<UserAccountSearchResponseModel>(model.PageIndex, model.PageSize);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JObject GetById(int id)
        {
            JObject jsResult = null;
            try
            {
                JsonGetDataById jsRequest = new JsonGetDataById()
                {
                    I = id,
                    M = false
                };

                string strJsonResult = O9Utils.GenJsonDataByIdRequest(jsRequest, TXCODE.ADM_GET_USER);
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    jsResult = JObject.Parse(strJsonResult);
                }

                return jsResult;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public UserAccountSearchResponseModel GetByLoginName(string loginName)
        {
            try
            {
                UserAccountSearchModel modelSearch = new()
                {
                    lgname = loginName,
                };

                var list = AdvanceSearch(modelSearch);
                var user = list.FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw new NeptuneException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        public async Task<JToken> Update(WorkflowRequestModel workflow)
        {
            await Task.CompletedTask;
            JsonTableName clsJson = new();
            try
            {
                JObject jsData = workflow.ObjectField;
                string id = jsData.Value<string>("id");
                jsData.Remove("id");
                if (!jsData.ContainsKey(workflow.IdFieldName.ToLower()))
                {
                    if (id.IsNumeric())
                    {
                        jsData.Add(workflow.IdFieldName.ToLower(), int.Parse(id));
                    }
                    else
                    {
                        jsData.Add(workflow.IdFieldName.ToLower(), id);
                    }
                }

                string isResetPasswordKey = "isResetPassword";
                bool isResetPassword = jsData.Value<bool>(isResetPasswordKey);
                jsData.Remove(isResetPasswordKey);

                JObject jsRequest = jsData.ConvertToJArray();
                clsJson.TXBODY.Add(new JsonData(workflow.TableName, jsRequest));

                string passwd = string.Empty;
                if (isResetPassword)
                {
                    int policyId = jsData.Value<int>("POLICYID");
                    string loginName = jsData.Value<string>("LGNAME");
                    UserPolicyViewResponseModel userPolicy = _policyService.GetById(policyId);
                    if (userPolicy.upwddflt.Equals("Y"))
                    {
                        passwd = userPolicy.pwddflt;
                    }
                    else
                    {
                        passwd = O9Utils.GenPassword();
                    }

                    string encryptedPwd = O9Encrypt.MD5Encrypt(passwd);

                    JObject jsPass = new()
                    {
                        { "pwdstr".ToUpper(), GenPassword(loginName, encryptedPwd) }
                    };

                    clsJson.TXBODY.Add(new JsonData("O9SYS.S_USRPWD", jsPass));

                    JObject jsPassHis = new()
                    {
                        { "pwdreset".ToUpper(), passwd }
                    };
                    clsJson.TXBODY.Add(new JsonData("O9SYS.S_USRPWD_HIS", jsPassHis));
                }

                string result = O9Utils.GenJsonBackOfficeRequest(workflow.user_sessions, workflow.WorkflowFunc, clsJson.TXBODY);

                JObject jsResult = O9Utils.AnalysisBackOfficeResult(result);
                JObject response = jsResult.ConvertToJObject();
                response.Add("pwdstr", passwd);
                return response;
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
        public JObject Create(UserAccountCreateModel model, UserSessions userSessions, string tableName, string txCode)
        {
            try
            {
                JsonTableName clsJson = new JsonTableName();

                JObject jsRequest = model.ToUpperPropertyNameWithDate("dd/MM/yyy");
                clsJson.TXBODY.Add(new JsonData(tableName, jsRequest));

                string passwd = string.Empty;

                //Set default password or generate password
                UserPolicyViewResponseModel usrPolicy = _policyService.GetById(model.policyid.Value);
                if (usrPolicy.upwddflt.Equals("Y"))
                {
                    passwd = usrPolicy.pwddflt;
                }
                else
                {
                    passwd = O9Utils.GenPassword();
                }

                string encryptedPwd = O9Encrypt.MD5Encrypt(passwd);

                JObject jsPass = new()
                {
                    { "pwdstr".ToUpper(), GenPassword(model.lgname, encryptedPwd) }
                };

                clsJson.TXBODY.Add(new JsonData("O9SYS.S_USRPWD", jsPass));

                JObject jsPassHis = new()
                {
                    { "pwdreset".ToUpper(), passwd }
                };
                clsJson.TXBODY.Add(new JsonData("O9SYS.S_USRPWD_HIS", jsPassHis));

                string result = O9Utils.GenJsonBackOfficeRequest(userSessions, txCode, clsJson.TXBODY);

                JObject jsResult = O9Utils.AnalysisBackOfficeResult(result);
                jsRequest = jsResult.ConvertToJObject();
                jsRequest.Add("pwdstr", passwd);
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
        /// <param name="lgName"></param>
        /// <param name="encryptedPass"></param>
        /// <returns></returns>
        private string GenPassword(string lgName, string encryptedPass)
        {
            JObject js = new()
            {
                { "I", encryptedPass },
                { "L", lgName }
            };

            string strResult = O9Utils.GenJsonBodyRequest(js, "UMG_GEN_PASSWORD");
            return strResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        public async Task<JToken> ResetPassword(WorkflowRequestModel workflow)
        {
            JsonTableName clsJson = new();
            try
            {
                JObject dataModel = workflow.ObjectField;
                int id = workflow.ObjectField.SelectToken("id").ToObject<int>();
                int policyId = dataModel.Value<int>("policy_id");
                string loginName = dataModel.Value<string>("login_name");

                string passwd = string.Empty;
                UserPolicyViewResponseModel userPolicy = _policyService.GetById(policyId);
                if (userPolicy.upwddflt.Equals("Y"))
                {
                    passwd = userPolicy.pwddflt;
                }
                else
                {
                    passwd = O9Utils.GenPassword();
                }

                string encryptedPwd = O9Encrypt.MD5Encrypt(passwd);

                JObject jsPass = new()
                {
                    { "pwdstr".ToUpper(), GenPassword(loginName, encryptedPwd) }
                };

                clsJson.TXBODY.Add(new JsonData("O9SYS.S_USRPWD", jsPass));

                JObject jsPassHis = new()
                {
                    { "pwdreset".ToUpper(), passwd }
                };
                clsJson.TXBODY.Add(new JsonData("O9SYS.S_USRPWD_HIS", jsPassHis));


                string result = O9Utils.GenJsonBackOfficeRequest(workflow.user_sessions, workflow.WorkflowFunc, clsJson.TXBODY);

                JObject jsResult = O9Utils.AnalysisBackOfficeResult(result);
                JObject response = jsResult.ConvertToJObject();
                response.Add("pwdstr", passwd);
                return response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.StackTrace);
                throw new NeptuneException(ex.Message);
            }
        }

        /// <summary>
        /// UMG_CHANGE_PASSWORD
        /// </summary>
        /// <param name="workflow"></param>
        /// <returns></returns>
        /// <exception cref="NeptuneException"></exception>
        public async Task<JToken> ChangePassword(WorkflowRequestModel workflow)
        {
            await Task.CompletedTask;
            JObject jsData = workflow.ObjectField;
            JObject jsRequest = new();
            JObject response = new();
            try
            {
                var user = GetById(workflow.user_sessions.Usrid);

                string oldPwd = jsData.Value<string>("old_password");
                string newPwd = jsData.Value<string>("new_password");
                string lgName = user.Value<string>("lgname");//jsData.Value<string>("confirm_password");
                //string procName = "UMG_CHANGE_PASSWORD";

                jsRequest.Add("O", O9Encrypt.MD5Encrypt(oldPwd)); 

                jsRequest.Add("N", O9Encrypt.MD5Encrypt(newPwd));

                jsRequest.Add("NO", newPwd);
                jsRequest.Add("LG", lgName);
                string strJsonResult = O9Utils.GenJsonBodyRequest(jsRequest, workflow.WorkflowFunc, "", EnmCacheAction.NoCached, EnmSendTypeOption.Synchronize, workflow.user_sessions.Usrid.ToString(), MsgPriority.Normal);
                if (!string.IsNullOrEmpty(strJsonResult))
                {
                    JObject jsResult = JObject.Parse(strJsonResult);
                    string errDesc = string.Empty;
                    if (!string.IsNullOrEmpty(jsResult.ToLowerKey().Value<string>("e")))
                    {
                        return jsResult.ToLowerKey().Value<string>("e").BuildWorkflowResponseError();
                    }

                    if (jsResult.ToLowerKey().Value<bool>("t"))
                    {
                        response.Add("update", "Y");
                    }
                }
                return response.BuildWorkflowResponseSuccess(false);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
