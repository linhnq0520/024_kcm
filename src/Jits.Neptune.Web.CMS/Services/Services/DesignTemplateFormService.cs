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
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// DesignTemplateForm service
/// </summary>
public partial class DesignTemplateFormService : IDesignTemplateFormService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<DesignTemplateForm> _DesignTemplateFormRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="DesignTemplateFormRepository"></param>

    public DesignTemplateFormService(ILocalizationService localizationService,
        IRepository<DesignTemplateForm> DesignTemplateFormRepository)
    {
        _localizationService = localizationService;
        _DesignTemplateFormRepository = DesignTemplateFormRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;DesignTemplateForm&gt;.</returns>
    public virtual async Task<DesignTemplateForm> GetById(int id)
    {
        return await _DesignTemplateFormRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;DesignTemplateFormModel&gt;.</returns>
    public virtual async Task<List<DesignTemplateFormModel>> GetAll()
    {

        try
        {
            List<DesignTemplateFormModel> result = new List<DesignTemplateFormModel>();
            var getDesignTemplateForm = await _DesignTemplateFormRepository.Table.ToListAsync();
            if (getDesignTemplateForm == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_DesignTemplateForm_ERR_0000000"));
            foreach (var itemDesignTemplateForm in getDesignTemplateForm)
            {
                var itemAdd = new DesignTemplateFormModel()
                {
                    ListLayout = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(itemDesignTemplateForm.ListLayout),
                    Info = JsonConvert.DeserializeObject<InfoForm>(itemDesignTemplateForm.Info),
                    Template = JsonConvert.DeserializeObject<Dictionary<string, object>>(itemDesignTemplateForm.Template),
                    TemplateId = itemDesignTemplateForm.TemplateId,
                    ReactTxt = itemDesignTemplateForm.ReactTxt
                };

                result.Add(itemAdd);

            }

            return result;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetAll==Exception====" + ex.StackTrace);

        }
        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="DesignTemplateForm"></param>
    /// <returns></returns>
    public virtual async Task Insert(DesignTemplateForm DesignTemplateForm)
    {
        var findForm = await _DesignTemplateFormRepository.Table.Where(s => s.TemplateId.Equals(DesignTemplateForm.TemplateId)).FirstOrDefaultAsync();
        if (findForm == null)
            await _DesignTemplateFormRepository.Insert(DesignTemplateForm);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="DesignTemplateForm"></param>
    /// <returns></returns>
    public virtual async Task<DesignTemplateForm> Update(DesignTemplateForm DesignTemplateForm)
    {
        await Task.CompletedTask;
        return null;
    }

}
