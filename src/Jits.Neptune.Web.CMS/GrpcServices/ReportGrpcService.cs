using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Grpc;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.GrpcServices;

/// <summary>
/// Call Report Grpc 
/// </summary>
public class ReportGrpcService : IReportGrpcService
{
    private IGrpcService _grpcService;
    // private IWorkflowService _workflowService;
    private static readonly String fullClassName = "Jits.Neptune.Web.Report.ReportGrpcService";
    private static readonly String moduleName = "RPT";


    /// <summary>
    /// Constructor
    /// </summary>
    public ReportGrpcService(IGrpcService grpcService)
    {
        _grpcService = grpcService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<TemplateReportWithCodeModel>> GetAllTemplateReport()
    {

        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetAllTemplateReport");
        if (rs != null) return JsonConvert.DeserializeObject<List<TemplateReportWithCodeModel>>(rs);
        return null;
    }

}
/// <summary>
/// 
/// </summary>
public partial class TemplateReport : BaseNeptuneModel
{
    /// <summary>
    /// 
    /// </summary>
    public TemplateReport() { }
    /// <summary>
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("app")]
    public string App { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("description")]

    public string Description { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [JsonProperty("version")]

    public string Version { get; set; }

}
/// <summary>
/// 
/// </summary>
public partial class TemplateReportWithCodeModel : BaseNeptuneModel
{
    /// <summary>
    /// 
    /// </summary>
    public TemplateReportWithCodeModel()
    {
    }

    /// <summary>
    /// TemplateReport id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonProperty("app")]
    public string App { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    [JsonProperty("version")]
    public string Version { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Description { get; set; }

}