using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jits.Neptune.Web.CMS.GrpcServices;
/// <summary>
/// 
/// </summary>
public partial interface IReportGrpcService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<TemplateReportWithCodeModel>> GetAllTemplateReport();
}