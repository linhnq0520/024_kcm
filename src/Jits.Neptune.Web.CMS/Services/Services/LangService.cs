using System;
using System.Collections.Generic;
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
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// Lang service
/// </summary>
public partial class LangService : ILangService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<Lang> _LangRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="LangRepository"></param>

    public LangService(ILocalizationService localizationService,
        IRepository<Lang> LangRepository)
    {
        _localizationService = localizationService;
        _LangRepository = LangRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    public virtual async Task<Lang> GetById(int id)
    {
        return await _LangRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lang"></param>
    /// <returns></returns>
    public virtual LangModel ToModel(Lang lang)
    {
        LangModel langModel = lang.ToModel<LangModel>();
        langModel.LangData = JsonConvert.DeserializeObject<Dictionary<string, object>>(lang.LangData);
        return langModel;
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;LangModel&gt;.</returns>
    public virtual async Task<Dictionary<string, object>> GetByApp(string app)
    {
        try
        {
            var getLang = await _LangRepository.Table.Where(s => s.App == app).FirstOrDefaultAsync();

            if (getLang == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Lang_ERR_0000000"));

            var langModel = ToModel(getLang);



            // langDictionary.Remove("en_dictionary");
            // langDictionary.Remove("vi_dictionary");
            // langDictionary.Remove("app");

            return langModel.LangData;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("GetByApp=Exception==" + ex.StackTrace);

            // TODO
        }
        return null;
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;LangModel&gt;.</returns>
    public virtual async Task<Lang> SearchByApp(string app)
    {
        try
        {
            var getLang = await _LangRepository.Table.Where(s => s.App.Equals(app)).FirstOrDefaultAsync();

            if (getLang == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Lang_ERR_0000000"));



            return getLang;
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("SearchByApp=Exception==" + ex.StackTrace);

            // TODO
        }
        return null;
    }

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    public virtual async Task Insert(Lang lang)
    {
        await _LangRepository.Insert(lang);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    public virtual async Task Update(Lang lang)
    {
        await _LangRepository.Update(lang);
    }
    /// <summary>
    ///Delete.
    /// </summary>
    /// <returns>Task&lt;Lang&gt;.</returns>
    public virtual async Task<Lang> DeleteByAppAndLang(string app, string lang)
    {
        await Task.CompletedTask;
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetLangMigrate()
    {
        var Langs = await _LangRepository.Table.ToListAsync();
        var getString = "";
        foreach (Lang Lang in Langs)
        {
            foreach (var propertyInfo in Lang.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType.ToString() == "System.String")
                {
                    var realStr = propertyInfo.GetValue(Lang)?.ToString();
                    if (realStr != null)
                    {
                        var tempStr = "";
                        foreach (var c in realStr)
                        {
                            if (c == '"')
                            {
                                tempStr = tempStr + @"\" + "\"";
                            }
                            else
                            {
                                tempStr = tempStr + c;
                            }
                        }
                        propertyInfo.SetValue(Lang, tempStr);
                    }
                    else
                    {
                        propertyInfo.SetValue(Lang, "null");
                    }
                }
            }
            var currentStr = $"new Lang {{LangData=\"{Lang.LangData}\", App=\"{Lang.App}\",\n";
            var newStr = currentStr.Replace("\"null\"", "null");
            getString += newStr;
        }
        return getString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <param name="key"></param>
    /// <param name="langData"></param>
    /// <returns></returns>
    public virtual async Task FindAndSaveLang(string app, string key, JObject langData)
    {
        try
        {
            var getLang = await _LangRepository.Table.Where(s => s.App.Equals(app)).FirstOrDefaultAsync();

            if (getLang == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Lang_ERR_0000000"));


            var getLangData = ToModel(getLang).LangData;
            if (getLangData != null)
                if (getLangData.ContainsKey(key))
                {
                    getLangData[key] = langData;
                    getLang.LangData = getLangData.ToSerialize();
                    await _LangRepository.Update(getLang);
                }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("FindAndSaveLang=Exception==" + ex.StackTrace);

            // TODO
        }
        return;
    }

}
