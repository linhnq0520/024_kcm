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
public partial interface ITemplateVoucherService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    Task<TemplateVoucher> GetById(int id);
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    Task<TemplateVoucherModel> GetByIdAndApp(string TemplateVoucherCode, string app);
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    Task<List<TemplateVoucher>> GetByApp(string app);
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    Task Insert(TemplateVoucher TemplateVoucher);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    Task Update(TemplateVoucher TemplateVoucher);
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    Task<TemplateVoucher> Delete(string tx_code, string app);

}
