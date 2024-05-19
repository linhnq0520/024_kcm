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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IDesignTemplateFormService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;IDesignTemplateForm&gt;.</returns>
    Task<DesignTemplateForm> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<List<DesignTemplateFormModel>> GetAll();
    ///Insert
    /// <summary>
    /// </summary>
    /// <returns>Task&lt;IDesignTemplateForm&gt;.</returns>
    Task Insert(DesignTemplateForm DesignTemplateForm);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;IDesignTemplateForm&gt;.</returns>
    Task<DesignTemplateForm> Update(DesignTemplateForm DesignTemplateForm);

}
