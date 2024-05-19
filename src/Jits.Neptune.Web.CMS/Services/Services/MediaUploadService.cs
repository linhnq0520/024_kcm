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
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services;
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// MediaUpload service
/// </summary>
public partial class MediaUploadService : IMediaUploadService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<MediaUpload> _mediaUploadRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="MediaUploadRepository"></param>

    public MediaUploadService(ILocalizationService localizationService,
        IRepository<MediaUpload> MediaUploadRepository)
    {
        _localizationService = localizationService;
        _mediaUploadRepository = MediaUploadRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;MediaUpload&gt;.</returns>
    public virtual async Task<MediaUpload> GetById(int id)
    {
        return await _mediaUploadRepository.GetById(id);
    }
    /// <summary>
    /// Gets GetByTxcodeAndApp
    /// </summary>
    /// <returns>Task&lt;MediaUploadModel&gt;.</returns>
    public virtual async Task<List<MediaUpload>> GetByUserToken(string token)
    {

        try
        {
            var getMediaUpload = await _mediaUploadRepository.Table.Where(s => s.Token == token).ToListAsync();
            if (getMediaUpload == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_MediaUpload_ERR_0000000"));

            return getMediaUpload;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByRoleId==Exception====" + ex.StackTrace);

        }
        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="mediaName"></param>
    /// <returns></returns>
    public virtual async Task<MediaUpload> GetByUserTokenFileName(string token, string mediaName)
    {
        try
        {
            var getMediaUpload = await _mediaUploadRepository.Table.Where(s => s.Token == token && s.MediaName == mediaName).FirstOrDefaultAsync();
            if (getMediaUpload == null)
                throw new NeptuneException(await _localizationService.GetResource("CMS_MediaUpload_ERR_0000000"));

            return getMediaUpload;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByFileName==Exception====" + ex.StackTrace);

        }
        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public virtual async Task<MediaUpload> GetByUserIdAndFileName(string userId, string fileName)
    {

        try
        {
            var getMediaUpload = await _mediaUploadRepository.Table.Where(s => s.UserId == Int32.Parse(userId) && s.MediaName == fileName).FirstOrDefaultAsync();
            if (getMediaUpload == null) return null;

            return getMediaUpload;
        }
        catch (System.Exception ex)
        {
            // TODO
            System.Console.WriteLine("GetByUserIdAndFileName==Exception====" + ex.StackTrace);

        }
        return null;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediaUpload"></param>
    /// <returns></returns>
    public virtual async Task Insert(MediaUpload mediaUpload)
    {
        var findForm = await _mediaUploadRepository.Table.Where(s => s.UserId.Equals(mediaUpload.UserId) && s.MediaName.Equals(mediaUpload.MediaName)).FirstOrDefaultAsync();
        if (findForm == null)
            await _mediaUploadRepository.Insert(mediaUpload);
        else
        {
            mediaUpload.Id = findForm.Id;
            await _mediaUploadRepository.Update(mediaUpload);
        }
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;MediaUpload&gt;.</returns>
    public virtual async Task Update(MediaUpload MediaUpload)
    {
        await Task.CompletedTask;
        return;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="MediaUpload"></param>
    /// <returns></returns>
    public virtual async Task Delete(MediaUpload MediaUpload)
    {
        await Task.CompletedTask;
        return;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public virtual async Task DeleteWithUserIdAndFileName(string userId, string fileName)
    {
        var getMedia = await GetByUserIdAndFileName(userId, fileName);
        if (getMedia != null) await _mediaUploadRepository.Delete(getMedia);
    }

}
