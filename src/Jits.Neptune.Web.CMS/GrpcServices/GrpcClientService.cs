using System.Threading.Tasks;
using Jits.Neptune.Web.Framework.Services.Grpc;
using Jits.Neptune.Web.Framework.Services;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.GrpcServices;

/// <summary>
/// Call Authentication Grpc 
/// </summary>
public class GrpcClientService : IGrpcClientService
{
    private IGrpcService _grpcService;
    // private IWorkflowService _workflowService;
    private static readonly String fullClassName = "JITS.Neptune.NeptuneClient.GrpcClient";
   private static readonly String moduleName = "";


    /// <summary>
    /// Constructor
    /// </summary>
    public GrpcClientService(IGrpcService grpcService)
    {
        _grpcService = grpcService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pExecutionID"></param>
    /// <returns></returns>
    public async Task<string> GetExecutionInfo(string pExecutionID)
    {
        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "InquireWorkflowExecution", pExecutionID);
        return rs;
    }

}

