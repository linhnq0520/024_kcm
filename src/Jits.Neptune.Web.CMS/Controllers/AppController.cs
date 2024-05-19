using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class AppController : BaseController
{

    /// <summary>
    /// Ctor
    /// </summary>
    public AppController()
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="listFields"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> ExportToFiles(List<AppExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<App, AppExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        try
        {
            foreach (var file in files)
            {
                // var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
                string path = "DeployData/App/";

                Utils.Utils.CreateDirectoryIfNotExist(path);

                string fullPath = Path.Combine(path, file.FileName);
                bool flag = Utils.Utils.FileWriter(fullPath, file.FileContent);

            }
        }
        catch (System.Exception ex)
        {
            // TODO
            // Console.WriteLine(ex.StackTrace);
            return Ok(ex.StackTrace);
        }

        return Ok($"Converted {files.Count} files");
    }
    /// <summary>
    /// Export data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> Export(List<AppExportDataModel> listFields)
    {

        var file = await Utils.Utils.ExportData<App, AppExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        if (file.FileContent is not null)
        {
            var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
            return File(fileContents: fileContent, contentType: file.ContentType, fileDownloadName: file.FileName);
        }
        return Ok("Data not found");
    }

    /// <summary>
    /// Upload data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> UploadData(IFormFile file)
    {
        string utfString;
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            utfString = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
        }

        JArray jArray = JArray.Parse(utfString);

        await Utils.Utils.UploadData<App, AppExportDataModel>(utfString);

        return Ok();
    }

}