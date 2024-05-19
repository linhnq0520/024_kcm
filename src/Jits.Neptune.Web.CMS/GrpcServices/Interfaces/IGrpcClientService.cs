using System.Collections.Generic;
using System.Threading.Tasks;


namespace Jits.Neptune.Web.CMS.GrpcServices;
/// <summary>
/// 
/// </summary>
public partial interface IGrpcClientService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pExecutionID"></param>
    /// <returns></returns>
    Task<string> GetExecutionInfo(string pExecutionID);

}