using System.Collections.Generic;
using System.Threading.Tasks;


namespace Jits.Neptune.Web.CMS.GrpcServices;
/// <summary>
/// 
/// </summary>
public partial interface IAuthenticationGrpcService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pUserCode"></param>
    /// <param name="pPassword"></param>
    /// <returns></returns>
    Task<string> GetAuthenticationToken(string pUserCode, string pPassword);

}