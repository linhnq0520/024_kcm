using System;
using System.Reflection;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.Attributes;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial class HtmlAppService : IHtmlAppService
{

    #region Fields

    private readonly ILocalizationService _localizationService;
    private readonly INeptuneFileProvider _fileProvider;
    private readonly IBoService _boService;
    private readonly IFoService _foService;

    private readonly CMSSetting _cmsSeting;


    JWebUIObjectContextModel context = new JWebUIObjectContextModel();
    #endregion

    #region Ctor   
   /// <summary>
   /// 
   /// </summary>
   /// <param name="localizationService"></param>
   /// <param name="fileProvider"></param>
   /// <param name="boService"></param>
   /// <param name="foService"></param>
   /// <param name="cMSSetting"></param>
    public HtmlAppService(ILocalizationService localizationService,
       INeptuneFileProvider fileProvider, IBoService boService, IFoService foService, CMSSetting cMSSetting)
    {
        _localizationService = localizationService;
        _fileProvider = fileProvider;
        _boService = boService;
        _foService = foService;

        _cmsSeting = cMSSetting;


    }

    #endregion


}
