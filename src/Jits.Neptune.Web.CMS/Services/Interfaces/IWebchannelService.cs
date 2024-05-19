using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IWebchannelService
{
    ///<Summary>
    /// GetConfigClient
    ///</Summary>
    Task<JObject> GetConfigClient();

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task<string> BuildListAuthorizeForms(string app);

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<string> BuildFormLangByFormName(string app);

    ///<Summary>
    /// GetHTMLDynamic
    ///</Summary>
    Task<string> GetHTMLDynamic(string host, string scheme);

    /// <summary>
    ///
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<string> MigrationFromFile(string path);

    /// <summary>
    ///
    /// </summary>
    /// <param name="from_app"></param>
    /// <param name="to_app"></param>
    /// <returns></returns>
    Task<string> CopyAppTo(string from_app, string to_app);

    /// <summary>
    ///
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    Task<string> MigrationCdlist(string path);

    /// <summary>
    ///
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<string> BuildFormOfRole(string app);

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task<string> FixKeyReadData();

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task BuildMenuModuleForm();

    /// <summary>
    ///
    /// </summary>
    /// <param name="bo"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    Task<ActionsResponseModel<object>> StartRequest(BoRequestModel bo, HttpContext httpContext);

    /// <summary>
    ///
    /// </summary>
    /// <param name="formDataUpload"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    Task<UploadResponseModel> UploadFile(
        FormDataUploadModel formDataUpload,
        HttpContext httpContext
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>

    Task<string> UploadFileZipNeptune(IFormFile file);
}
