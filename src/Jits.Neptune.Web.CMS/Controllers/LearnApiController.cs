using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class LearnApiController : BaseController
{

    /// <summary>
    /// Ctor
    /// </summary>
    readonly IRepository<LearnApi> _form = EngineContext.Current.Resolve<IRepository<LearnApi>>();
    readonly INeptuneDataProvider _dataprovider = EngineContext.Current.Resolve<INeptuneDataProvider>();
    /// <summary>
    /// 
    /// </summary>
    public LearnApiController()
    { }
    /// <summary>
    ///
    /// </summary>
    /// <param name="zipFile"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> UploadZip(IFormFile zipFile)
    {
        using (var memoryStream = new MemoryStream())
        {
            // Copy the uploaded ZIP file to a memory stream
            zipFile.CopyTo(memoryStream);
            memoryStream.Position = 0;

            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Read))
            {

                foreach (ZipArchiveEntry entry in zipArchive.Entries)
                {
                    // Ensure the entry is a file, not a directory
                    if (!string.IsNullOrEmpty(entry.Name))
                    {
                        using (var entryStream = entry.Open())
                        {
                            using (var contentStream = new MemoryStream())
                            {
                                entryStream.CopyTo(contentStream);
                                var fileBytes = contentStream.ToArray();
                                string utfString = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                                System.Console.WriteLine(utfString);
                                JArray jArray = JArray.Parse(utfString);

                                await Utils.Utils.UploadData<LearnApi, LearnApiExportDataModel>(utfString);
                            }

                        }
                    }
                }
                return Ok($"Converted");
            }
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
    public virtual async Task<IActionResult> DownloadZip(List<LearnApiExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<LearnApi, LearnApiExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        try
        {
            var zipName = $"LearnApi-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";
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
    public virtual async Task<IActionResult> ExportToFiles(List<LearnApiExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<LearnApi, LearnApiExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        try
        {
            foreach (var file in files)
            {
                // var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
                string path = "DeployData/LearnApi/";

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
    public virtual async Task<IActionResult> ExportDataWithContains(List<LearnApiExportDataModel> listFields)
    {
        var file = await Utils.Utils.ExportDataWithContains<LearnApi, LearnApiExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        if (file.FileContent is not null)
        {
            var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
            return File(fileContents: fileContent, contentType: file.ContentType, fileDownloadName: file.FileName);
        }
        return Ok("Data not found");
    }

    /// <summary>
    /// Export data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> Export(List<LearnApiExportDataModel> listFields)
    {
        var file = await Utils.Utils.ExportData<LearnApi, LearnApiExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
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

        await Utils.Utils.UploadData<LearnApi, LearnApiExportDataModel>(utfString);

        return Ok();
    }

    /// <summary>
    /// Upload data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> UploadMultiFiles(IFormFileCollection files)
    {
        foreach (var file in files)
        {
            string utfString;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                utfString = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
            }

            JArray jArray = JArray.Parse(utfString);

            await Utils.Utils.UploadData<LearnApi, LearnApiExportDataModel>(utfString);
        }
        return Ok();
    }
    /// <summary>
    /// Export data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> HotFix27042023()
    {
        var allLearnAPI = await EngineContext.Current.Resolve<IRepository<LearnApi>>().Table.ToListAsync();
        if (allLearnAPI.Count > 0)
        {
            for (var i = 0; i < allLearnAPI.Count; i++)
            {
                var new_mapping = JObject.Parse(allLearnAPI[i].LearnApiMapping);
                new_mapping["reference_id"] = "MapS.dataS(guid)";
                allLearnAPI[i].LearnApiMapping = JsonConvert.SerializeObject(new_mapping);

                await EngineContext.Current.Resolve<IRepository<LearnApi>>().Update(allLearnAPI[i]);
            }

        }
        return Ok("Data not found");
    }

    /// <summary>
    /// Export data
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> UpdateLearnApiByName(string path)
    {
        try
        {
            string[] listLearnApi = path.Split(";");
            foreach (string learnApi in listLearnApi)
            {
                var data = await Utils.Utils.ReadData<LearnApi>("DeployData/LearnApi/" + learnApi + ".json");
                foreach (var item in data)
                {
                    var oldForm = _form.Table.Where(s => s.LearnApiId == item.LearnApiId && s.App == item.App).FirstOrDefault();
                    if (oldForm != null)
                    {
                        item.Id = oldForm.Id;
                        await _form.Update(item);
                    }
                    else
                    {
                        await _form.Insert(item);
                    }
                }

            }
            return Ok("Updated");
        }
        catch (System.Exception ex)
        {
            // TODO
            // Console.WriteLine(ex.StackTrace);
            return Ok(ex.StackTrace);
        }
    }

    /// <summary>
    /// Update all Laern api from folder
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> UpdateAllFormFromFolder(string folderPath = "DeployData/LearnApi", int pageSize = 100)
    {
        try
        {
            string[] files = Directory.GetFiles(folderPath);
            System.Console.WriteLine("Total LearnApi read from folder: " + files.Length);
            var formMigration = new List<LearnApi>();
            foreach (string filePath in files)
            {
                var data = await Utils.Utils.ReadData<LearnApi>(filePath);
                formMigration.AddRange(data);
            }
            var listOldForm = (from a in formMigration
                               join b in _form.Table on new { a.LearnApiId, a.App } equals new { b.LearnApiId, b.App }
                               select b).ToList();

            var forms = from d in formMigration
                        group d by new { d.LearnApiId, d.App } into groupForms
                        select new
                        {
                            LearnApiId = groupForms.Key,
                            Count = groupForms.Count(),
                        };

            forms = forms.Where(s => s.Count > 1).ToList();
            if (forms.Any())
            {
                string error = $"There is duplicate learn api for :";
                foreach (var item in forms)
                {
                    error += item.LearnApiId + "; ";
                }
                return Ok(error);
            }
            System.Console.WriteLine("Total LearnApi delete: " + listOldForm.Count);
            await _dataprovider.BulkDeleteEntities(listOldForm);
            System.Console.WriteLine("Total LearnApi Update: " + formMigration.Count);
            await _dataprovider.BulkInsertEntities(formMigration);
            return Ok($"Updated {formMigration.Count} Files");
        }
        catch (System.Exception ex)
        {
            // TODO
            // Console.WriteLine(ex.StackTrace);
            return Ok(ex.StackTrace);
        }
    }

}