using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Grpc;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.GrpcServices;

/// <summary>
/// Call Authentication Grpc 
/// </summary>
public class AuthenticationGrpcService : IAuthenticationGrpcService
{
    private IGrpcService _grpcService;
    // private IWorkflowService _workflowService;
    private static readonly String fullClassName = "JITS.Neptune.Lib.GrpcLib.AuthenticationGrpc";
    private static readonly String moduleName = "";


    /// <summary>
    /// Constructor
    /// </summary>
    public AuthenticationGrpcService(IGrpcService grpcService)
    {
        _grpcService = grpcService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pUserCode"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<string> GetAuthenticationToken(string pUserCode, string password)
    {
        System.Console.WriteLine("==pUserCode==" + pUserCode);
        System.Console.WriteLine("==password==" + password);

        var rs = await _grpcService.Call<string>(moduleName, fullClassName, "GetAuthenticationToken", pUserCode, password);


        System.Console.WriteLine("==result==" + rs);
        return rs;
    }

}
