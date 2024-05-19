using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// Cdlist service
/// </summary>
public partial class CdlistService : ICdlistService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<Cdlist> _CdlistRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="CdlistRepository"></param>

    public CdlistService(ILocalizationService localizationService,
        IRepository<Cdlist> CdlistRepository)
    {
        _localizationService = localizationService;
        _CdlistRepository = CdlistRepository;
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_mcaption"></param>
    /// <returns></returns>
    public virtual string convertToMCaptionEntity(string _mcaption)
    {
        var objMaption = JObject.Parse(_mcaption);
        return (new MultiCaptionEntity
        {
            English = objMaption["en"] != null ? objMaption["en"].ToString() : "",
            Vietnamese = objMaption["vi"] != null ? objMaption["vi"].ToString() : "",
            Laothian = objMaption["lo"] != null ? objMaption["lo"].ToString() : "",
            Khmer = objMaption["km"] != null ? objMaption["km"].ToString() : "",
            Myanmar = objMaption["mn"] != null ? objMaption["mn"].ToString() : "",
        }).ToSerialize();
    }

    private MultiCaption convertToMCaptionModel(string _mcaption)
    {

        try
        {
            // var objMaption = JObject.Parse(_mcaption);

            // return objMaption.ToModel<MultiCaption>();
            var multiCaption = System.Text.Json.JsonSerializer.Deserialize<MultiCaption>(_mcaption);
            return multiCaption;

        }
        catch(Exception ex)
        {
            // TODO
            Console.WriteLine(ex.StackTrace);
            return new MultiCaption();
        }
    }


    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;Cdlist&gt;.</returns>
    public virtual async Task<Cdlist> GetById(int id)
    {
        return await _CdlistRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;CdlistModel&gt;.</returns>
    public virtual async Task<CdlistModel> GetByCd(string cdgrp, string cdname, string cdid)
    {

        try
        {
            var getCdlist = await _CdlistRepository.Table.Where(s => s.Cdid == cdid && s.Cdgrp == cdgrp && s.Cdname == cdname).Select(s => new CdlistModel()
            {
                Id = s.Id,
                Cdid = s.Cdid,
                App = s.App,
                Caption = s.Caption,
                Cdgrp = s.Cdgrp,
                Cdidx = s.Cdidx,
                Cdname = s.Cdname,
                Ftag = s.Ftag,
                Cdval = s.Cdval,
                Mcaption = !string.IsNullOrEmpty(s.Mcaption) ? convertToMCaptionModel(s.Mcaption) : new MultiCaption(),
                Visible = s.Visible
            }).FirstOrDefaultAsync();

            if (getCdlist == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Cdlist_ERR_0000000"));

            return getCdlist;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByCd==Exception====" + ex.StackTrace);

        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdgrp"></param>
    /// <param name="cdname"></param>
    /// <param name="cdid"></param>
    /// <returns></returns>
    public virtual async Task<Cdlist> GetByCodeGroup(string cdgrp, string cdname, string cdid)
    {

        try
        {
            var getCdlist = await _CdlistRepository.Table.Where(s => s.Cdid == cdid && s.Cdgrp == cdgrp && s.Cdname == cdname).FirstOrDefaultAsync();
            if (getCdlist == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Cdlist_ERR_0000000"));

            return getCdlist;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByCodeGroup==Exception====" + ex.StackTrace);

        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdgrp"></param>
    /// <param name="cdname"></param>
    /// <returns></returns>
    public virtual async Task<List<CdlistModel>> GetByCdgrpAndCdname(string cdgrp, string cdname)
    {
        try
        {
            var app = EngineContext.Current.Resolve<JWebUIObjectContextModel>().InfoApp.GetApp();
            var getCdlist = await _CdlistRepository.Table.Where(s => s.Cdgrp == cdgrp && s.Cdname == cdname
            && s.App == app).Select(s => new CdlistModel()
            {
                Id = s.Id,
                Cdid = s.Cdid,
                App = s.App,
                Caption = s.Caption,
                Cdgrp = s.Cdgrp,
                Cdidx = s.Cdidx,
                Cdname = s.Cdname,
                Ftag = s.Ftag,
                Cdval = s.Cdval,
                Mcaption = new MultiCaption(), //!string.IsNullOrEmpty(s.Mcaption) ? convertToMCaptionModel(s.Mcaption) : new MultiCaption(),
                Visible = s.Visible
            }).ToListAsync();
            if (getCdlist == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Cdlist_ERR_0000000"));

            return getCdlist;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByCdgrpAndCdname==Exception====" + ex.StackTrace);

        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<CdlistResponseModel>> GetAll()
    {
        try
        {
            var getCdlist = await _CdlistRepository.Table.Select(s => new CdlistResponseModel()
            {
                Id = s.Id,
                Cdid = s.Cdid,
                App = s.App,
                Caption = s.Caption,
                Cdgrp = s.Cdgrp,
                Cdidx = s.Cdidx,
                Cdname = s.Cdname,
                Ftag = s.Ftag,
                Cdval = s.Cdval,
                Mcaption = new MultiCaption(), //!string.IsNullOrEmpty(s.Mcaption) ? convertToMCaptionModel(s.Mcaption) : new MultiCaption(),
                Visible = s.Visible
            }).ToListAsync();
            if (getCdlist == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Cdlist_ERR_0000000"));

            return getCdlist;
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
    /// <param name="app"></param>
    /// <returns></returns>
    public virtual async Task<List<CdlistResponseModel>> GetByApp(string app)
    {
        try
        {
            var getCdlist = await _CdlistRepository.Table.Where(s => s.App.Equals(app))
            .Select(s => new CdlistResponseModel()
            {
                Id = s.Id,
                Cdid = s.Cdid,
                App = s.App,
                Caption = s.Caption,
                Cdgrp = s.Cdgrp,
                Cdidx = s.Cdidx,
                Cdname = s.Cdname,
                Ftag = s.Ftag,
                Cdval = s.Cdval,
                Mcaption = new MultiCaption(), //!string.IsNullOrEmpty(s.Mcaption) ? convertToMCaptionModel(s.Mcaption) : new MultiCaption(),
                Visible = s.Visible
            }).ToListAsync();
            if (getCdlist == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_Cdlist_ERR_0000000"));

            return getCdlist;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByApp==Exception====" + ex.StackTrace);

        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdlist"></param>
    /// <returns></returns>
    public virtual async Task Insert(Cdlist cdlist)
    {
        var getCdlist = await _CdlistRepository.Table.Where(s => s.Cdid == cdlist.Cdid && s.Cdgrp == cdlist.Cdgrp && s.Cdname == cdlist.Cdname).FirstOrDefaultAsync();
        if (getCdlist == null) await _CdlistRepository.Insert(cdlist);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;Cdlist&gt;.</returns>
    public virtual async Task Update(Cdlist cdlist)
    {
        var getCdlist = await _CdlistRepository.Table.Where(s => s.Cdid == cdlist.Cdid && s.Cdgrp == cdlist.Cdgrp && s.Cdname == cdlist.Cdname).FirstOrDefaultAsync();
        if (getCdlist != null)
        {
            // System.Console.WriteLine("getCdlist==" + JsonConvert.SerializeObject(getCdlist));

            var cdlist_ = cdlist;
            cdlist_.Id = getCdlist.Id;
            await _CdlistRepository.Update(cdlist_);

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cdlist"></param>
    /// <returns></returns>
    public virtual async Task Delete(Cdlist cdlist)
    {
        await _CdlistRepository.Delete(cdlist);
    }

}
