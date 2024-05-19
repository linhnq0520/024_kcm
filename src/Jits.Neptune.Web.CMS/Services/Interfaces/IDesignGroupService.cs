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
public partial interface IDesignGroupService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;IDesignGroup&gt;.</returns>
    Task<DesignGroup> GetById(int id);
   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
    Task<List<DesignGroupModel>> GetAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="DesignGroup"></param>
    /// <returns></returns>
    Task Insert(DesignGroup DesignGroup);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;IDesignGroup&gt;.</returns>
    Task<DesignGroup> Update(DesignGroup DesignGroup);

}
