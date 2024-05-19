using System.Collections.Generic;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Models;

using Nito.Disposables.Internals;

namespace Jits.Neptune.Web.CMS.GrpcServices;
/// <summary>
/// 
/// </summary>
public partial interface IAdminGrpcService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<AuthenticateResponse> Authenticate(string username, string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    Task<List<RoleOfUser>> GetListRoleByUserId(string userid);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<GetUserAccountByIdResponse> GetUserAccountById(string userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<List<UserRight>> GetByRoleId(string roleId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task<List<UserCommand>> GetUserCommandByApplicationCode(string applicationCode);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    Task<List<CommandIdInfoModel>> GetUserCommandInfoFromParentId(string applicationCode, string parentId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="commandId"></param>
    /// <returns></returns>
    Task<List<CommandIdInfoModel>> GetUserCommandInfoFromCommandId(string applicationCode, string commandId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<List<CommandIdInfoModel>> GetUserCommandInfoFromRoleId(string applicationCode, string roleId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<string> CreateOtherToken(string token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<string> LockScreen(string token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task UpdateSessionApplicationCode(string token, string applicationCode);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    Task UpdateSessionMacAndApplicationCode(string token, string mac, string applicationCode);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    Task UpdateSessionInfo(string token, string info);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task UpdateSessionMac(string token, string mac);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task DeleteToken(string token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task DeleteAllUserToken(string userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="applicationCode"></param>
    /// <param name="currentToken"></param>
    /// <returns></returns>
    Task DeleteAllAppToken(string userId, string applicationCode, string currentToken);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<SearchResponseModel>> DeleteAndReturnAllUserToken(string userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="acttype"></param>
    /// <returns></returns>
    Task UpdateActtype(string token, string acttype);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<bool> VerifyPassword(string username, string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<UserSession> GetSessionByToken(string token);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationCode"></param>
    /// <param name="formCode"></param>
    /// <returns></returns>
    Task<List<UserCommand>> GetUserCommandInfoFromFormCode(string applicationCode, string formCode);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<string> GetSessionModeByUserId(int userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<UserSession>> ListSessionByUsrId(int userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <returns></returns>
    Task<GetUserAccountByIdResponse> GetUserAccountByLoginName(string loginName);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<List<UserSession>> ListSessionByMac(string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<ValidateSessionModel> CheckValidSingleSession(string loginName, string mac);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    Task<List<UserSession>> ListUserSessionByLoginNameAndNotEqualMac(string loginName, string mac);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<CodeList>> GetAllCodeList();
}