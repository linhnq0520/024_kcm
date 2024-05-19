using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// User Account service
/// </summary>
public partial interface IMediaUploadService

{  /// <summary>
   /// Gets the by identifier.
   /// </summary>
   /// <param name="id">The identifier.</param>
   /// <returns>Task&lt;IMediaUpload&gt;.</returns>
    Task<MediaUpload> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<List<MediaUpload>> GetByUserToken(string token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userToken"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    Task<MediaUpload> GetByUserTokenFileName(string userToken,string fileName);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    Task<MediaUpload> GetByUserIdAndFileName(string userId, string fileName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="MediaUpload"></param>
    /// <returns></returns>
    Task Insert(MediaUpload MediaUpload);
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;IMediaUpload&gt;.</returns>
    Task Update(MediaUpload MediaUpload);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="MediaUpload"></param>
    /// <returns></returns>
    Task Delete(MediaUpload MediaUpload);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    Task DeleteWithUserIdAndFileName(string userId,string fileName);

}
