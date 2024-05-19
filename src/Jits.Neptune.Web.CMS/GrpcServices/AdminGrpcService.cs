using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Grpc;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.GrpcServices;

/// <summary>
/// Call Admin Grpc 
/// </summary>
public class AdminGrpcService : IAdminGrpcService
{
    private IGrpcService _grpcService;
    // private IWorkflowService _workflowService;
    private static readonly String fullClassName = "Jits.Neptune.Web.Admin.AdminGrpcService";
    private static readonly String moduleName = "ADM";


    /// <summary>
    /// Constructor
    /// </summary>
    public AdminGrpcService(IGrpcService grpcService)
    {
        _grpcService = grpcService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<AuthenticateResponse> Authenticate(string username, string password)
    {

        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "Authenticate", username, password);

        if (rs != null) return JsonConvert.DeserializeObject<AuthenticateResponse>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public async Task<List<RoleOfUser>> GetListRoleByUserId(string userid)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetListRoleByUserId", userid);

        if (rs != null) return JsonConvert.DeserializeObject<List<RoleOfUser>>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<GetUserAccountByIdResponse> GetUserAccountById(string userId)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserAccountById", userId);

        if (rs != null) return JsonConvert.DeserializeObject<GetUserAccountByIdResponse>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    public async Task<List<UserRight>> GetByRoleId(string roleId)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetByRoleId", roleId);

        if (rs != null) return JsonConvert.DeserializeObject<List<UserRight>>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>  
    public async Task<List<UserCommand>> GetUserCommandByApplicationCode(string applicationCode)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserCommandByApplicationCode", applicationCode);
        if (rs != null) return JsonConvert.DeserializeObject<List<UserCommand>>(rs);
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
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserCommandInfoFromParentId", applicationCode, parentId);
        if (rs != null) return JsonConvert.DeserializeObject<List<CommandIdInfoModel>>(rs);
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
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserCommandInfoFromCommandId", applicationCode, commandId);

        if (rs != null) return JsonConvert.DeserializeObject<List<CommandIdInfoModel>>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="formCode"></param>
    /// <returns></returns>
    public async Task<List<UserCommand>> GetUserCommandInfoFromFormCode(string applicationCode, string formCode)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserCommandInfoFromFormCode", applicationCode, formCode);

        if (rs != null) return JsonConvert.DeserializeObject<List<UserCommand>>(rs);
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
        // Console.WriteLine("GetUserCommandInfoFromRoleId start==" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff",
        //                                     CultureInfo.InvariantCulture));        
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserCommandInfoFromRoleId", applicationCode, roleId);
        if (rs != null) return JsonConvert.DeserializeObject<List<CommandIdInfoModel>>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<string> CreateOtherToken(string token)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "CreateOtherToken", token);
        return rs;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<string> LockScreen(string token)
    {
        System.Console.WriteLine("LockScreen======" + token);
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "LockScreen", token);

        return rs;
    }
    /// <summary>
    /// <param name="token"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    /// </summary>

    public async Task UpdateSessionApplicationCode(string token, string applicationCode)
    {
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "UpdateSessionApplicationCode", token, applicationCode);

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
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "UpdateSessionMacAndApplicationCode", token, mac, applicationCode);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="acttype"></param>
    /// <returns></returns>
    public async Task UpdateActtype(string token, string acttype)
    {
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "UpdateActtype", token, acttype);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<bool> VerifyPassword(string username, string password)
    {
        var rs = await _grpcService.Call<bool>(moduleName, fullClassName, "VerifyPassword", username, password);
        return rs;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    public async Task UpdateSessionInfo(string token, string info)
    {
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "UpdateSessionInfo", token, info);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public async Task UpdateSessionMac(string token, string mac)
    {
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "UpdateSessionMac", token, mac);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task DeleteAllUserToken(string userId)
    {
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "DeleteAllUserToken", userId);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task DeleteToken(string token)
    {
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "DeleteToken", token);
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
        var rs = await _grpcService.Call<Task>(moduleName, fullClassName, "DeleteAllAppToken", userId, applicationCode, currentToken);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<SearchResponseModel>> DeleteAndReturnAllUserToken(string userId)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "DeleteAndReturnAllUserToken", userId);
        return JsonConvert.DeserializeObject<List<SearchResponseModel>>(rs);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<UserSession> GetSessionByToken(string token)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetSessionByToken", token);
        if (rs != null) return JsonConvert.DeserializeObject<UserSession>(rs);
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> GetSessionModeByUserId(int userId)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetSessionModeByUserId", userId.ToString());
        return rs;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<UserSession>> ListSessionByUsrId(int userId)
    {
        var rs = await _grpcService.Call<List<UserSession>>(moduleName, fullClassName, "ListSessionByUsrId", userId.ToString());
        return rs;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <returns></returns>
    public async Task<GetUserAccountByIdResponse> GetUserAccountByLoginName(string loginName)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetUserAccountResponseByLoginName", loginName);

        if (rs != null) return JsonConvert.DeserializeObject<GetUserAccountByIdResponse>(rs);
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mac"></param>
    /// <returns></returns>
    public async Task<List<UserSession>> ListSessionByMac(string mac)
    {
        var rs = await _grpcService.Call<List<UserSession>>(moduleName, fullClassName, "ListSessionByMac", mac);
        return rs;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public async Task<ValidateSessionModel> CheckValidSingleSession(string loginName, string mac)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "CheckValidSingleSession", loginName, mac);
        return JsonConvert.DeserializeObject<ValidateSessionModel>(rs);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public async Task<List<UserSession>> ListUserSessionByLoginNameAndNotEqualMac(string loginName, string mac)
    {
        var rs = await _grpcService.Call<List<UserSession>>(moduleName, fullClassName, "ListUserSessionByLoginNameAndNotEqualMac", loginName, mac);
        return rs;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<CodeList>> GetAllCodeList()
    {
        var rs = await _grpcService.Call<List<CodeList>>(moduleName, fullClassName, "GetAllCodeList");
        return rs;
    }
}
/// <summary>
/// 
/// </summary>
public partial class UserSession : BaseEntity
{
    /// <summary>
    /// UserSession
    /// </summary>
    public UserSession()
    {
        Ssntime = System.DateTime.Now;
        Exptime = System.DateTime.Now;
        Uuid = string.Empty;
        Wsip = string.Empty;
        Mac = string.Empty;
        Wsname = string.Empty;
        Token = string.Empty;
        Acttype = "I";
    }
    /// <summary>
    /// Usrid
    /// </summary>
    public string UserCode { get; set; }

    /// <summary>
    /// Ssntime
    /// </summary>
    public DateTime Ssntime { get; set; }

    /// <summary>
    /// Uuid
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    /// Exptime
    /// </summary>
    public DateTime Exptime { get; set; }

    /// <summary>
    /// Wsip
    /// </summary>
    public string Wsip { get; set; }

    /// <summary>
    /// Mac
    /// </summary>
    public string Mac { get; set; }

    /// <summary>
    /// Wsname
    /// </summary>
    public string Wsname { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Acttype
    /// </summary>
    public string Acttype { get; set; }

    /// <summary>
    /// Application code
    /// </summary>
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Meta Info
    /// </summary>
    public string Info { get; set; }
}
/// <summary>
/// 
/// </summary>
/// 
public partial class UserSessionSearchResponseModel : BaseNeptuneModel
{
    /// <summary>
    /// UserSessionResponseModel
    /// </summary>
    public UserSessionSearchResponseModel()
    {
    }

    #region UserSession

    /// <summary>
    /// Usrid
    /// </summary>
    public int Usrid { get; set; }

    /// <summary>
    /// Ssntime
    /// </summary>
    public DateTime Ssntime { get; set; }

    /// <summary>
    /// Uuid
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    /// Exptime
    /// </summary>
    public DateTime Exptime { get; set; }

    /// <summary>
    /// Wsip
    /// </summary>
    public string Wsip { get; set; }

    /// <summary>
    /// Mac
    /// </summary>
    public string Mac { get; set; }

    /// <summary>
    /// Wsname
    /// </summary>
    public string Wsname { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Acttype
    /// </summary>
    public string Acttype { get; set; }

    /// <summary>
    /// Application code
    /// </summary>
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Meta Info
    /// </summary>
    public string Info { get; set; }

    #endregion

    /// <summary>
    /// User code
    /// </summary>
    public string UserCode { get; set; }

    /// <summary>
    /// User name
    /// </summary>
    /// <value></value>
    public string UserName { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class CommandIdInfoModel : BaseNeptuneModel
{
    /// <summary>
    /// 
    /// </summary>
    public CommandIdInfoModel() { }
    /// <summary>
    /// role id
    /// </summary>
    public int RoleId { get; set; }
    /// <summary>
    /// rolename
    /// </summary>
    public string RoleName { get; set; }

    /// <summary>
    /// Parent command Id
    /// </summary>
    public string ParentId { get; set; }

    /// <summary>
    /// /// Command Id
    /// </summary>
    public string CommandId { get; set; }

    /// <summary>
    /// Command Name
    /// </summary>
    public string CommandName { get; set; }

    /// <summary>
    /// Command Id Detail
    /// </summary>
    public string CommandIdDetail { get; set; }

    /// <summary>
    /// Invoke
    /// </summary>
    public int Invoke { get; set; }

    /// <summary>
    /// Approve
    /// </summary>
    public int Approve { get; set; }

    /// <summary>
    /// ApplicationCode
    /// </summary>
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Command Type
    /// </summary>
    /// <value></value>
    public string CommandType { get; set; }

    /// <summary>
    /// GroupMenuIcon
    /// </summary>
    public string GroupMenuIcon { get; set; }

    /// <summary>
    /// GroupMenuVisible
    /// </summary>
    public string GroupMenuVisible { get; set; }

    /// <summary>
    /// GroupMenuId
    /// </summary>
    public string GroupMenuId { get; set; }

    /// <summary>
    /// GroupMenuListAuthorizeForm
    /// </summary>
    public string GroupMenuListAuthorizeForm { get; set; }

}
/// <summary>
/// 
/// </summary>
public class UserCommand : BaseNeptuneModel
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("application_code")]
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Command Id
    /// </summary>
    [JsonProperty("command_id")]
    public string CommandId { get; set; }

#nullable enable
    /// <summary>
    /// Parent command Id
    /// </summary>
    [JsonProperty("parent_id")]
    public string? ParentId { get; set; }

    /// <summary>
    /// Command Name
    /// </summary>
    [JsonProperty("command_name")]
    public string? CommandName { get; set; }

    /// <summary>
    /// Command Name Multi language
    /// </summary>
    [JsonProperty("command_name_language")]
    public string? CommandNameLanguage { get; set; }
#nullable disable

    /// <summary>
    /// Command Type
    /// </summary>
    [JsonProperty("command_type")]
    public string CommandType { get; set; }

    /// <summary>
    /// Is Enabled
    /// </summary>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Order
    /// </summary>
    [JsonProperty("display_order")]
    public int DisplayOrder { get; set; }

    /// <summary>
    /// GroupMenuIcon
    /// </summary>
    [JsonProperty("group_menu_icon")]
    public string GroupMenuIcon { get; set; }

    /// <summary>
    /// GroupMenuVisible
    /// </summary>
    [JsonProperty("group_menu_visible")]
    public string GroupMenuVisible { get; set; }

    /// <summary>
    /// GroupMenuId
    /// </summary>
    [JsonProperty("group_menu_id")]
    public string GroupMenuId { get; set; }

    /// <summary>
    /// GroupMenuListAuthorizeForm
    /// </summary>
    [JsonProperty("group_menu_list_authorize_form")]
    public string GroupMenuListAuthorizeForm { get; set; }
}
/// <summary>
/// 
/// </summary>
public class AuthenticateResponse : BaseNeptuneModel
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="token"></param>
    public AuthenticateResponse(string token)
    {
        Token = token;
    }

    /// <summary>
    /// Id
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// UserCode
    /// </summary>
    /// <value></value>
    public string UserCode { get; set; }
    /// <summary>
    /// UserName
    /// </summary>
    /// <value></value>
    public string UserName { get; set; }

    /// <summary>
    /// LoginName
    /// </summary>
    /// <value></value>
    public string LoginName { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    /// <value></value>
    [JsonProperty(Required = Required.Always)]
    public string Token { get; set; }

    /// <summary>
    /// WorkingDate
    /// </summary>
    /// <value></value>
    public DateTime WorkingDate { get; set; }

    /// <summary>
    /// BranchId
    /// </summary>
    /// <value></value>
    public int BranchId { get; set; }

    /// <summary>
    /// BranchCode
    /// </summary>
    /// <value></value>
    public string BranchCode { get; set; }

    /// <summary>
    /// BranchName
    /// </summary>
    /// <value></value>
    public string BranchName { get; set; }

    /// <summary>
    /// DepartmentId
    /// </summary>
    /// <value></value>
    public int DepartmentId { get; set; }

    /// <summary>
    /// DepartmentCode
    /// </summary>
    /// <value></value>
    public string DepartmentCode { get; set; }

    /// <summary>
    /// Pst
    /// </summary>
    /// <value></value>
    [JsonIgnore]
    public string Pst { get; set; }

    /// <summary>
    /// Region
    /// </summary>
    /// <value></value>
    public string Region { get; set; }

    /// <summary>
    /// BranchStatus
    /// </summary>
    /// <value></value>
    public string BranchStatus { get; set; }

    /// <summary>
    /// BankStatus
    /// </summary>
    /// <value></value>
    public string BankStatus { get; set; }

    /// <summary>
    /// ResetPassword
    /// </summary>
    /// <value></value>
    public bool ResetPassword { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DateTimeOffset ExpireTime { get; set; }
}
/// <summary>
/// 
/// </summary>
public partial class RoleOfUser : BaseNeptuneModel
{
    /// <summary>
    /// Role of user domain constructor
    /// </summary>
    public RoleOfUser() { }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public int Id { get; set; }
    /// <summary>
    /// roleid
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// usrid
    /// </summary>
    public int UserId { get; set; }

}
/// <summary>
/// 
/// </summary>
public class GetUserAccountByIdResponse : BaseNeptuneModel
{

    /// <summary>
    /// GetUserAccountByIdResponse constructor
    /// </summary>
    public GetUserAccountByIdResponse()
    {

    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Position
    /// </summary>
    public string Position { get; set; }

    /// <summary>
    /// BranchCode
    /// </summary>
    public string BranchCode { get; set; }
    /// <summary>
    /// BranchName
    /// </summary>
    public string BranchName { get; set; }
    /// <summary>
    /// Position
    /// </summary>
    public string LoginName { get; set; }

    /// <summary>
    /// UserCode
    /// </summary>
    public string UserCode { get; set; }

    /// <summary>
    /// UserName
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// ResetPassword
    /// </summary>
    /// <value></value>
    public bool ResetPassword { get; set; }
    /// <summary>
    /// BranchStatus
    /// </summary>
    /// <value></value>
    public string BranchStatus { get; set; }
    /// <summary>
    /// BankStatus
    /// </summary>
    /// <value></value>
    public string BankStatus { get; set; } // add for cms
    /// <summary>
    /// Region
    /// </summary>
    /// <value></value>
    public string Region { get; set; } // add for cms
    /// <summary>
    /// WorkingDate
    /// </summary>
    /// <value></value>
    public DateTime WorkingDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public decimal TimeZone { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string UserAccountStatus { get; set; }

    /// <summary>
    /// Is Cash Account
    /// </summary>
    public bool IsCashier
    {
        get
        {
            try
            {
                MultiPosition positionAccount = System.Text.Json.JsonSerializer.Deserialize<MultiPosition>(this.Position);
                return (positionAccount.Cashier == 1);
            }
            catch
            {
                return false;
            }

        }
    }

    /// <summary>
    /// Is Cash Account
    /// </summary>
    public bool IsChiefCashier
    {
        get
        {
            try
            {
                MultiPosition positionAccount = System.Text.Json.JsonSerializer.Deserialize<MultiPosition>(this.Position);
                return (positionAccount.ChiefCashier == 1);
            }
            catch
            {
                return false;
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Avatar { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class CodeList : BaseNeptuneModel
{
    /// <summary>
    /// Code list constructor
    /// </summary>

    public CodeList() { }
    /// <summary>
    /// Code Id
    /// </summary>
    [JsonProperty("code_id")]
    public string CodeId { get; set; }

    /// <summary>
    /// Code Name
    /// </summary>
    [JsonProperty("code_name")]
    public string CodeName { get; set; }

    /// <summary>
    /// caption
    /// </summary>
    [JsonProperty("caption")]
    public string Caption { get; set; }

    /// <summary>
    /// mcaption
    /// </summary>
    [JsonProperty("mcaption")]
    public string Mcaption { get; set; }

    /// <summary>
    /// Code Group
    /// </summary>
    [JsonProperty("code_group")]
    public string CodeGroup { get; set; }

    /// <summary>
    /// Code Index
    /// </summary>
    [JsonProperty("code_index")]
    public int CodeIndex { get; set; }

    /// <summary>
    /// Code Value
    /// </summary>
    [JsonProperty("code_value")]
    public string CodeValue { get; set; }

    /// <summary>
    /// Ftag
    /// </summary>
    [JsonProperty("ftag")]
    public string Ftag { get; set; }

    /// <summary>
    /// Visible
    /// </summary>
    [JsonProperty("visible")]
    public int Visible { get; set; }

    /// <summary>
    /// Last update date
    /// </summary>
    [JsonProperty("updated_on_utc")]
    public DateTime? UpdatedOnUtc { get; set; }

    /// <summary>
    /// Last update date
    /// </summary>
    [JsonProperty("created_on_utc")]
    public DateTime? CreatedOnUtc { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class UserRight : BaseNeptuneModel
{
    /// <summary>
    /// User right domain constructor
    /// </summary>
    public UserRight() { }

    /// <summary>
    /// roleid
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// cmdid
    /// </summary>
    public string CommandId { get; set; }

    /// <summary>
    /// cmdiddt
    /// </summary>
    public string CommandIdDetail { get; set; }

    /// <summary>
    /// invoke
    /// </summary>
    public int Invoke { get; set; }

    /// <summary>
    /// approve
    /// </summary>
    public int Approve { get; set; }
}

/// <summary>
/// 
/// </summary>
public partial class SearchResponseModel
{
    /// <summary>
    /// UserSessionResponseModel
    /// </summary>
    public SearchResponseModel()
    {

    }

    #region UserSession

    /// <summary>
    /// Usrid
    /// </summary>
    public int Usrid { get; set; }

    /// <summary>
    /// Ssntime
    /// </summary>
    public DateTime Ssntime { get; set; }

    /// <summary>
    /// Uuid
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    /// Exptime
    /// </summary>
    public DateTime Exptime { get; set; }

    /// <summary>
    /// Wsip
    /// </summary>
    public string Wsip { get; set; }

    /// <summary>
    /// Mac
    /// </summary>
    public string Mac { get; set; }

    /// <summary>
    /// Wsname
    /// </summary>
    public string Wsname { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Acttype
    /// </summary>
    public string Acttype { get; set; }

    /// <summary>
    /// Application code
    /// </summary>
    public string ApplicationCode { get; set; }

    /// <summary>
    /// Meta Info
    /// </summary>
    public string Info { get; set; }

    #endregion

    /// <summary>
    /// User code
    /// </summary>
    public string UserCode { get; set; }

    /// <summary>
    /// User name
    /// </summary>
    /// <value></value>
    public string UserName { get; set; }


}
/// <summary>
/// 
/// </summary>
public partial class MultiPosition : BaseNeptuneModel
{
    /// <summary>
    /// Cashier
    /// </summary>
    [JsonProperty("cashier")]
    public int? Cashier { get; set; } = 0;

    /// <summary>
    /// Officer
    /// </summary>
    [JsonProperty("officer")]
    public int? Officer { get; set; } = 0;

    /// <summary>
    /// ChiefCashier
    /// </summary>
    [JsonProperty("chief_cashier")]
    public int? ChiefCashier { get; set; } = 0;

    /// <summary>
    /// OperationStaff
    /// </summary>
    [JsonProperty("operation_staff")]
    public int? OperationStaff { get; set; } = 0;

    /// <summary>
    /// Dealer
    /// </summary>
    [JsonProperty("dealer")]
    public int? Dealer { get; set; } = 0;

    /// <summary>
    /// InterBranchUser
    /// </summary>
    [JsonProperty("inter_branch_user")]
    public int? InterBranchUser { get; set; } = 0;

    /// <summary>
    /// BranchManager
    /// </summary>
    [JsonProperty("branch_manager")]
    public int? BranchManager { get; set; } = 0;
}
