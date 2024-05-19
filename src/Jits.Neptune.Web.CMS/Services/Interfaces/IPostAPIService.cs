using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IPostAPIService
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    Task<JToken> GetDataPostAPI(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="file"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<string> PostZipFileNeptune(IFormFile file, string app);

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    Task<JToken> GetDataPostAPIUploadMasterFile(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    Task<JToken> GetDataPostAPIDownload(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>

    Task<JToken> GetDataPostAPIWithoutKeyReadData(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="appCodeRequest"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <param name="learn_api"></param>
    /// <returns></returns>
    Task<JToken> CallAPIAsync(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context,
        string learn_api
    );
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<string> GetNewNeptuneToken(
    );
    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiModel"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    Task<JToken> PostHttpsWithStatusCode(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiModel"></param>
    /// <param name="actionName"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    Task<JToken> PostHttpWithStatusCode(
        LearnApiModel learnApiModel,
        string actionName,
        JWebUIObjectContextModel context
    );

    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApi"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    Task<LearnApiModel> TxMapData(string learnApi, JObject dataMap, string appRequest);
    
    /// <summary>
    /// Txes the map data out put using the specified learn api
    /// </summary>
    /// <param name="learnApi">The learn api</param>
    /// <param name="dataMap">The data map</param>
    /// <param name="appRequest">The app request</param>
    /// <returns>A task containing the learn api model</returns>
    Task<string> TxMapDataOutPut(string learnApi, JObject dataMap, string appRequest);

    
    /// <summary>
    ///
    /// </summary>
    /// <param name="learnApiMapping"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    Task<JObject> TxMapDataBody(string learnApiMapping, JObject dataMap, string appRequest);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obMapp_"></param>
    /// <param name="appRequest"></param>
    /// <param name="uid"></param>
    /// <param name="dataMap"></param>
    /// <param name="learnApiData"></param>
    /// <param name="isO9Mapping"></param>
    /// <returns></returns>
    public JObject LoopConfigMapping(
        ref JObject obMapp_,
        string appRequest,
        string uid,
        JObject dataMap,
        string learnApiData,
        bool isO9Mapping = false
    );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obMapp_"></param>
    /// <param name="appRequest"></param>
    /// <param name="uid"></param>
    /// <param name="dataMap"></param>
    /// <param name="learnApiData"></param>
    /// <param name="isO9Mapping"></param>
    /// <returns></returns>
    JArray LoopConfigMappingArray(
        ref JArray obMapp_,
        string appRequest,
        string uid,
        JObject dataMap,
        string learnApiData,
        bool isO9Mapping = false
    );
}
