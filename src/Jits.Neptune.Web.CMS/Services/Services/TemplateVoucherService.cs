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
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Services;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft;
using Jits.Neptune.Web.Framework.Models;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// TemplateVoucher service
/// </summary>
public partial class TemplateVoucherService : ITemplateVoucherService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<TemplateVoucher> _TemplateVoucherRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="TemplateVoucherRepository"></param>

    public TemplateVoucherService(ILocalizationService localizationService,
        IRepository<TemplateVoucher> TemplateVoucherRepository)
    {
        _localizationService = localizationService;
        _TemplateVoucherRepository = TemplateVoucherRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    public virtual async Task<TemplateVoucher> GetById(int id)
    {
        return await _TemplateVoucherRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;TemplateVoucherModel&gt;.</returns>
    public virtual async Task<TemplateVoucherModel> GetByIdAndApp(string TemplateVoucherCode, string app)
    {
        System.Console.WriteLine("TemplateVoucherCode===" + TemplateVoucherCode);
        var getTemplateVoucher = await _TemplateVoucherRepository.Table.Where(s => s.App.Equals(app.Trim()) && s.Code.Equals(TemplateVoucherCode.Trim())).Select(s => new TemplateVoucherModel
        {
            App = app,
            Code = TemplateVoucherCode,
            HtmlCode = s.HtmlCode,
            Status = s.Status
        }).FirstOrDefaultAsync();

        if (getTemplateVoucher == null)
            throw new NeptuneException(await _localizationService.GetResource("CMS_TemplateVoucher_ERR_0000000"));

        return getTemplateVoucher;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    public virtual async Task<List<TemplateVoucher>> GetByApp(string app)
    {
        return await _TemplateVoucherRepository.Table.Where(s => s.App.Equals(app)).ToListAsync();
    }
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    public virtual async Task Insert(TemplateVoucher TemplateVoucher)
    {
        var findTemplateVoucher = await _TemplateVoucherRepository.Table.Where(s => s.App.Equals(TemplateVoucher.App) && s.Code.Equals(TemplateVoucher.Code)).FirstOrDefaultAsync();
        if (findTemplateVoucher == null)
            await _TemplateVoucherRepository.Insert(TemplateVoucher);

    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    public virtual async Task Update(TemplateVoucher TemplateVoucher)
    {
        await _TemplateVoucherRepository.Update(TemplateVoucher, "");
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;TemplateVoucher&gt;.</returns>
    public virtual async Task<TemplateVoucher> Delete(string tx_code, string app)
    {
        await Task.CompletedTask;
        return null;
    }


}
