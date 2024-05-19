using System;
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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface ICdlistService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;ICdlist&gt;.</returns>
    Task<Cdlist> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdgrp"></param>
    /// <param name="cdname"></param>
    /// <param name="cdid"></param>
    /// <returns></returns>
    Task<CdlistModel> GetByCd(string cdgrp, string cdname, string cdid);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdgrp"></param>
    /// <param name="cdname"></param>
    /// <param name="cdid"></param>
    /// <returns></returns>
    Task<Cdlist> GetByCodeGroup(string cdgrp, string cdname, string cdid);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdgrp"></param>
    /// <param name="cdname"></param>
    /// <returns></returns>
    Task<List<CdlistModel>> GetByCdgrpAndCdname(string cdgrp, string cdname);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<CdlistResponseModel>> GetAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    Task<List<CdlistResponseModel>> GetByApp(string app);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Cdlist"></param>
    /// <returns></returns>
    Task Insert(Cdlist Cdlist);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;ICdlist&gt;.</returns>
    Task Update(Cdlist Cdlist);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Cdlist"></param>
    /// <returns></returns>
    Task Delete(Cdlist Cdlist);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_mcaption"></param>
    /// <returns></returns>
    string convertToMCaptionEntity(string _mcaption);



}
