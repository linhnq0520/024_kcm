using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// ParaServer service
/// </summary>
public partial class UserSessionsService : IUserSessionsService
{
    private readonly ILocalizationService _localizationService;

    private readonly IRepository<UserSessions> _userSessionsRepository;
    private readonly IJwtTokenService _jwtTokenService = EngineContext.Current.Resolve<IJwtTokenService>();
    private readonly IMemoryCache _memoryCache;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="userSessionsRepository"></param>
    /// <param name="memoryCache"></param>
    public UserSessionsService(ILocalizationService localizationService,
        IRepository<UserSessions> userSessionsRepository, IMemoryCache memoryCache)
    {
        _localizationService = localizationService;
        _userSessionsRepository = userSessionsRepository;
        _memoryCache = memoryCache;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userSession"></param>
    /// <returns></returns>
    public virtual async Task Insert(UserSessions userSession)
    {
        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));
        await _userSessionsRepository.Insert(userSession);
    }
    /// <summary>
     /// Gets a user session by session string
     /// </summary>
     /// <param name="token"></param>
     /// <param name="activeOnly"></param>
     /// <returns></returns>
    public virtual async Task<UserSessions> GetByToken(string token, bool activeOnly = true)
    {
        var cache = _memoryCache.Get<UserSessions>(token);
        if (cache != null)
        {
            return cache;
        }
        var query = _userSessionsRepository.Table.Where(s => s.Token == token);
        if (activeOnly) query = query.Where(s => s.Acttype == "I" || s.Acttype == "S"); // Active and StaticToken
        query = from s in query select s;
        var session = await query.FirstOrDefaultAsync();
        if(session != null)
            _memoryCache.Set(session.Token,session,session.Exptime);

        return session;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public virtual async Task UpdateSessionMac(string token, string mac)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        userSession.Mac = mac;

        await _userSessionsRepository.Update(userSession);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    public virtual async Task UpdateInfo(string token, string info)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        userSession.Info = info;

        await _userSessionsRepository.Update(userSession);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mac"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    public virtual async Task UpdateSessionMacAndApplicationCode(string token, string mac, string applicationCode)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        userSession.Mac = mac;
        userSession.ApplicationCode = applicationCode;

        await _userSessionsRepository.Update(userSession);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="applicationCode"></param>
    /// <returns></returns>
    public virtual async Task UpdateSessionAndApplicationCode(string token, string applicationCode)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        userSession.ApplicationCode = applicationCode;

        await _userSessionsRepository.Update(userSession);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="acttype"></param>
    /// <returns></returns>
    public virtual async Task UpdateActtype(string token, string acttype)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        userSession.Acttype = acttype;

        await _userSessionsRepository.Update(userSession);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="info"></param>
    /// <returns></returns>
    public virtual async Task UpdateSessionAndInfo(string token, string info)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        userSession.Info = info;

        await _userSessionsRepository.Update(userSession);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task DeleteToken(string token)
    {
        var userSession = await GetByToken(token);

        if (userSession == null)
            throw new ArgumentNullException(nameof(userSession));

        await _userSessionsRepository.Delete(userSession);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="applicationCode"></param>
    /// <param name="currentToken"></param>
    /// <returns></returns>
    public virtual async Task DeleteAllAppToken(string userId, string applicationCode, string currentToken)
    {
        Dictionary<string, string> searchInput = new Dictionary<string, string>();
        searchInput.Add("Usrid", userId);
        searchInput.Add("ApplicationCode", applicationCode);
        searchInput.Add("Token", currentToken);

        await _userSessionsRepository.FilterAndDelete(searchInput);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task DeleteAllById(string userId)
    {
        Dictionary<string, string> searchInput = new()
        {
            { "Usrid", userId }
        };

        await _userSessionsRepository.FilterAndDelete(searchInput);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public virtual async Task<UserSessions> GetListUserSessionByLoginNameAndEqualMac(string loginName, string mac)
    {
        return await _userSessionsRepository.Table.Where(s => s.Mac == mac && _jwtTokenService.GetLoginNameFromToken(s.Token) == loginName).FirstOrDefaultAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public virtual async Task<List<UserSessions>> GetListUserSessionByLoginNameAndNotEqualMac(string loginName, string mac)
    {
        return await _userSessionsRepository.Table.Where(s => s.Mac != mac && _jwtTokenService.GetLoginNameFromToken(s.Token) == loginName).ToListAsync<UserSessions>();
    }
}
