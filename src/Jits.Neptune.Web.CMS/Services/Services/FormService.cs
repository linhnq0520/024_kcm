using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// Form service
/// </summary>
public partial class FormService : IFormService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<Form> _formRepository;
    

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="FormRepository"></param>

    public FormService(ILocalizationService localizationService,
        IRepository<Form> FormRepository)
    {
        _localizationService = localizationService;
        _formRepository = FormRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    public virtual async Task<Form> GetById(int id)
    {
        return await _formRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;FormModel&gt;.</returns>
    public virtual async Task<FormModel> GetByIdAndApp(string formCode, string app)
    {
        var getForm = await _formRepository.Table.Where(s => s.App.Equals(app.Trim()) && s.FormId.Equals(formCode.Trim())).Select(s => new FormModel
        {
            Id = s.Id,
            App = app,
            FormId = formCode,
            ReactTxt = s.ReactTxt,
            ListLayout = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(s.ListLayout),
            Info = JsonConvert.DeserializeObject<InfoForm>(s.Info)
        }).FirstOrDefaultAsync();

        // if (getForm == null)
        //     throw new NeptuneException(await _localizationService.GetResource("CMS_Form_ERR_0000000"));

        return getForm;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    public virtual async Task<List<FormModel>> GetByApp(string app)
    {
        return await _formRepository.Table.Where(s => s.App.Equals(app)).Select(s => new FormModel
        {
            Id=s.Id,
            App = app,
            FormId = s.FormId,
            ReactTxt = s.ReactTxt,
            ListLayout = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(s.ListLayout),
            Info = JsonConvert.DeserializeObject<InfoForm>(s.Info)
        }).ToListAsync();
    }
/// <summary>
/// 
/// </summary>
/// <param name="app"></param>
/// <returns></returns>
    public virtual async Task<List<RoleCacheModel>> GetRoleCacheByApp(string app)
    {
        return await _formRepository.Table.Where(s => s.App.Equals(app)).Select(s => new RoleCacheModel
        {
            FormId = s.FormId,
        }).ToListAsync();
    }
    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    public virtual async Task Insert(Form Form)
    {
        var findForm = await _formRepository.Table.Where(s => s.App.Equals(Form.App) && s.FormId.Equals(Form.FormId)).FirstOrDefaultAsync();
        if (findForm == null)
            await _formRepository.Insert(Form);

    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    public virtual async Task Update(Form form)
    {
        await _formRepository.Update(form);
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Form&gt;.</returns>
    public virtual async Task Delete(string tx_code, string app)
    {
        var form_ = await GetByIdAndApp(tx_code, app);

        await _formRepository.Delete(await GetById(form_.Id));
    }


}
