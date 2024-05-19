using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Config;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.ClearScript.JavaScript;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualStudio.Services.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(NeptuneConfigurationDefaults.AppSettingsFilePath, true, true);
builder.Services.AddMemoryCache();


if (!string.IsNullOrEmpty(builder.Environment?.EnvironmentName))
{
    var path = string.Format(NeptuneConfigurationDefaults.AppSettingsEnvironmentFilePath,
        builder.Environment.EnvironmentName);
    builder.Configuration.AddJsonFile(path, true, true);
}

builder.Configuration.AddEnvironmentVariables();
GlobalVariable.Optimal9Settings = builder.Configuration.GetSection("CommonConfig").Get<Optimal9Settings>();
if (GlobalVariable.Optimal9Settings != null)
{
    if (!string.IsNullOrEmpty(GlobalVariable.Optimal9Settings.ncbsCbsMode) &&
        GlobalVariable.Optimal9Settings.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
    {
        GlobalVariable.ncbsCbsMode = GlobalVariable.Optimal9Settings.ncbsCbsMode;
        O9Client.Init(GlobalVariable.Optimal9Settings.Memcached, GlobalVariable.Optimal9Settings);
    }
}

builder.Services.ConfigureApplicationServices(builder);


var app = builder.Build();

var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "j-webui-template"));
var requestPath = "/fwcss";

var fileProviderLogin = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "j-webui-login"));
var requestPathLogin = "/login";

var fileProviderWizRs = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wiz_rs"));
var requestPathWizRs = "/rs";

var fileProviderStable = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "j-webui-stable"));
var requestPathStable = "/app";

var provider = new FileExtensionContentTypeProvider();
// Add .scss mapping
provider.Mappings[".scss"] = "text/css";
provider.Mappings[".ttf"] = "application/x-font-ttf";
provider.Mappings[".woff2"] = "application/font-woff2";

var options = new FileServerOptions()
{
    FileProvider = fileProvider,
    RequestPath = requestPath,
    StaticFileOptions = { ServeUnknownFileTypes = true, ContentTypeProvider = provider }
};

// options.StaticFileOptions.ServeUnknownFileTypes = true;
// options.StaticFileOptions.ContentTypeProvider = provider;

var optionsLogin = new FileServerOptions()
{
    FileProvider = fileProviderLogin,
    RequestPath = requestPathLogin,
    StaticFileOptions = { ServeUnknownFileTypes = true, ContentTypeProvider = provider }
};

var optionsWizRs = new FileServerOptions()
{
    FileProvider = fileProviderWizRs,
    RequestPath = requestPathWizRs,
    StaticFileOptions = { ServeUnknownFileTypes = true, ContentTypeProvider = provider }
};

var optionsStable = new FileServerOptions()
{
    FileProvider = fileProviderStable,
    RequestPath = requestPathStable,
    StaticFileOptions = { ServeUnknownFileTypes = true, ContentTypeProvider = provider }
};

// optionsLogin.StaticFileOptions.ServeUnknownFileTypes = true;
// optionsLogin.StaticFileOptions.ContentTypeProvider = provider;

app.UseDeveloperExceptionPage();
app.UseFileServer(options);
app.UseFileServer(optionsLogin);
app.UseFileServer(optionsWizRs);
app.UseFileServer(optionsStable);

app.UseRouting();
app.UseExceptionHandler("/error");
app.Map("/error", (IHttpContextAccessor httpContextAccessor) =>
{
    var exceptions = httpContextAccessor.HttpContext?
        .Features.Get<IExceptionHandlerFeature>()?
        .Error;

    if (httpContextAccessor.HttpContext != null) httpContextAccessor.HttpContext.Response.StatusCode = 200;

    if (exceptions is NeptuneException)
    {
        var neptuneException = exceptions as NeptuneException;
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>
        {
            Utils.AddActionError(
                ErrorType.errorSystem,
                ErrorMainForm.danger,
                neptuneException.Message,
                neptuneException.ErrorCode ?? "",
                "#ERROR_SYSTEM: "
            )
        };
        var responseModel = new ActionsResponseModel<object>();
        var infoError = new FoResponseModel<object>()
        {
            txcode = "#sys:fo-sys-showError",
            input = new Dictionary<string, object> { { "infoError", listError} }
        };
        responseModel.fo.Add(infoError);
        responseModel.error.AddRange(listError);
        return responseModel;
    }
    else
    {
        List<ErrorInfoModel> listError = new List<ErrorInfoModel>
        {
            Utils.AddActionError(
                ErrorType.errorSystem,
                ErrorMainForm.danger,
                exceptions?.Message,
                "",
                "#ERROR_SYSTEM: "
            )
        };
        var responseModel = new ActionsResponseModel<object>();
        var infoError = new FoResponseModel<object>()
        {
            txcode = "#sys:fo-sys-showError",
            input = new Dictionary<string, object> { { "infoError", listError} }
        };
        responseModel.fo.Add(infoError);
        responseModel.error.AddRange(listError);
        return responseModel;
    }
});
app.UseCors();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromSeconds(10)
};
app.UseWebSockets(webSocketOptions);

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async http =>
    {
        await System.Threading.Tasks.Task.CompletedTask;
        http.Response.Redirect("/login");
    });
});
#pragma warning restore ASP0014

app.ConfigureRequestPipeline();
app.StartEngine();

app.Run();

