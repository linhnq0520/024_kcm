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
using Jits.Neptune.Web.Framework.Services.Localization;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// App service
/// </summary>
public partial class AppService : IAppService
{

    #region Fields

    private readonly ILocalizationService _localizationService;

    private readonly IRepository<App> _appRepository;

    private readonly IRepository<MediaUpload> _mediaUploadRepository;

    #endregion

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="AppRepository"></param>
    /// <param name="mediaUploadRepository"></param>


    public AppService(ILocalizationService localizationService,
        IRepository<App> AppRepository, IRepository<MediaUpload> mediaUploadRepository)
    {
        _localizationService = localizationService;
        _appRepository = AppRepository;
        _mediaUploadRepository = mediaUploadRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;App&gt;.</returns>
    public virtual async Task<App> GetById(int id)
    {
        return await _appRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageSearch"></param>
    /// <returns></returns>
    public virtual async Task<App> ToAppEntity(JToken pageSearch)
    {
        var id = pageSearch["id"]?.ToString();
        string mediaLogo = "";
        try
        {
            var imgModel = pageSearch["list_appliaction_img"].ToObject<UploadResponseModel>();
            var mediaData = new MediaUpload();
            if (imgModel != null)
            {
                mediaData = await _mediaUploadRepository.Table.Where(s => s.MediaName.Equals(imgModel.name) && s.UserId == int.Parse(imgModel.user_id)).FirstOrDefaultAsync();
                if (mediaData != null) mediaLogo = mediaData.MediaData;
            }
        }
        catch (System.Exception ex)
        {
            // TODO
             System.Console.WriteLine(ex.StackTrace);
            mediaLogo = pageSearch["list_appliaction_img"] != null ? pageSearch["list_appliaction_img"].ToString() : null;
        }


        if (!string.IsNullOrEmpty(id))
            return new App()
            {
                Id = int.Parse(id),
                ListApplicationId = pageSearch["list_appliaction_id"]?.ToString(),
                ListApplicationName = pageSearch["list_appliaction_name"]?.ToString(),
                ListApplicationBo = pageSearch["list_appliaction_bo"]?.ToString(),
                ListApplicationBoLogout = pageSearch["list_application_bo_logout"]?.ToString(),
                ListApplicationBoLogoutAll = pageSearch["list_application_bo_logout_all"]?.ToString(),
                ConfigTemplate = pageSearch["configTemplate"]?.ToString(),
                ListApplicationDes = pageSearch["list_appliaction_des"]?.ToString(),
                ListApplicationImg = mediaLogo,
                ListApplicationOrder = pageSearch["list_appliaction_order"]?.ToString(),
                status = pageSearch["status"]?.ToString()
            };
        else return new App()
        {
            ListApplicationId = pageSearch["list_appliaction_id"]?.ToString(),
            ListApplicationName = pageSearch["list_appliaction_name"]?.ToString(),
            ListApplicationBo = pageSearch["list_appliaction_bo"]?.ToString(),
            ListApplicationBoLogout = pageSearch["list_application_bo_logout"]?.ToString(),
            ListApplicationBoLogoutAll = pageSearch["list_application_bo_logout_all"]?.ToString(),
            ConfigTemplate = pageSearch["configTemplate"]?.ToString(),
            ListApplicationDes = pageSearch["list_appliaction_des"]?.ToString(),
            ListApplicationImg = mediaLogo,
            ListApplicationOrder = pageSearch["list_appliaction_order"]?.ToString(),
            status = pageSearch["status"]?.ToString()
        };


    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appEntity"></param>
    /// <returns></returns>
    public virtual AppModel ToModel(App appEntity)
    {
        var appModel = appEntity.ToModel<AppModel>();
        appModel.ConfigTemplate = JObject.Parse(appEntity.ConfigTemplate);
        return appModel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="appCode"></param>
    /// <returns></returns>
    public virtual async Task<AppModel> GetByAppCode(string appCode)
    {
        return await _appRepository.Table.Where(s => s.ListApplicationId == appCode).Select(
            s => new AppModel
            {
                Id = s.Id,
                ListApplicationId = s.ListApplicationId,
                ListApplicationName = s.ListApplicationName,
                ListApplicationDes = s.ListApplicationDes,
                ListApplicationBo = s.ListApplicationBo,
                ListApplicationBoLogout = s.ListApplicationBoLogout,
                ListApplicationBoLogoutAll = s.ListApplicationBoLogoutAll,
                ListApplicationImg = s.ListApplicationImg,
                ListApplicationOrder = s.ListApplicationOrder,
                ConnectOtherSystemStatus = s.ConnectOtherSystemStatus,
                ConfigTemplate = s.ConfigTemplate.HasValue() ? JObject.Parse(s.ConfigTemplate) : new JObject(),
                status = s.status
            }).FirstOrDefaultAsync();
    }
    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;App&gt;.</returns>
    public async Task<List<AppModel>> GetAll()
    {
        return await _appRepository.Table.Select(
                s => new AppModel
                {
                    Id = s.Id,
                    ListApplicationId = s.ListApplicationId,
                    ListApplicationName = s.ListApplicationName,
                    ListApplicationDes = s.ListApplicationDes,
                    ListApplicationBo = s.ListApplicationBo,
                    ListApplicationBoLogout = s.ListApplicationBoLogout,
                    ListApplicationBoLogoutAll = s.ListApplicationBoLogoutAll,
                    ListApplicationImg = s.ListApplicationImg,
                    ListApplicationOrder = s.ListApplicationOrder,
                    ConnectOtherSystemStatus = s.ConnectOtherSystemStatus,
                    ConfigTemplate = s.ConfigTemplate.HasValue() ? JObject.Parse(s.ConfigTemplate) : new JObject(),
                    status = s.status
                }
            ).ToListAsync();
    }


    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;App&gt;.</returns>
    public virtual async Task Insert(App app)
    {
        var findApp = await _appRepository.Table.Where(s => s.ListApplicationId.Equals(app.ListApplicationId)).FirstOrDefaultAsync();
        if (findApp == null)
            await _appRepository.Insert(app);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;App&gt;.</returns>
    public virtual async Task Update(App app)
    {
        await _appRepository.Update(app);
    }


}
