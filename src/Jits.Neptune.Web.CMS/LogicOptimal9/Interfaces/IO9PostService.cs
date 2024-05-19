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
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;

/// <summary>
/// Bo Schema Migration
/// </summary>
public partial interface IO9PostService
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    Task<JToken> GetDataPostAPI(string appCodeRequest,
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
    Task<JToken> O9CallAPIAsync(
        string appCodeRequest,
        string actionName,
        JWebUIObjectContextModel context,
        string learn_api
    );
    
}
