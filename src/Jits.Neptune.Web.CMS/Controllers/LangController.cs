using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
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
public partial class LangController : BaseController
{

    /// <summary>
    /// Ctor
    /// </summary>
    public LangController()
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
    public virtual async Task<IActionResult> DownloadZip(List<LangExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<Lang, LangExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        try
        {
            var zipName = $"Lang-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";
            using (MemoryStream ms = new MemoryStream())
            {
                //required: using System.IO.Compression;  
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    //QUery the Products table and get all image content  
                    files.ToList().ForEach(file =>
                    {
                        var entry = zip.CreateEntry(file.FileName);
                        using (var fileStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(file.FileContent)))
                        using (var entryStream = entry.Open())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    });
                }
                return File(ms.ToArray(), "application/zip", zipName);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            // Console.WriteLine(ex.StackTrace);
            return Ok(ex.StackTrace);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listFields"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> ExportToFiles(List<LangExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<Lang, LangExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        try
        {
            foreach (var file in files)
            {
                // var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
                string path = "DeployData/Lang/";

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
    public virtual async Task<IActionResult> Export(List<LangExportDataModel> listFields)
    {
        var file = await Utils.Utils.ExportData<Lang, LangExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
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

        await Utils.Utils.UploadData<Lang, LangExportDataModel>(utfString);

        return Ok();
    }

}