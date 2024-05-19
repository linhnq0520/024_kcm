using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class CdlistController : BaseController
{

    /// <summary>
    /// Ctor
    /// </summary>
    public CdlistController()
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
    public virtual async Task<IActionResult> ExportToFiles(List<CdlistExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<Cdlist, CdlistExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
        try
        {
            foreach (var file in files)
            {
                // var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
                string path = "DeployData/Cdlist/";

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
    public virtual async Task<IActionResult> Export(List<CdlistExportDataModel> listFields)
    {
        var file = await Utils.Utils.ExportData<Cdlist, CdlistExportDataModel>(HttpContext.Request.Host.ToString(), listFields);
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

        await Utils.Utils.UploadData<Cdlist, CdlistExportDataModel>(utfString);

        return Ok();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="files"></param>
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

            await Utils.Utils.UploadData<Cdlist, CdlistExportDataModel>(utfString);
        }
        return Ok();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> SyncCdlistFromAdmin()
    {
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var getAllCodeLists = await EngineContext.Current.Resolve<AdminService>().GetAllCodeList();

            var CodeLists = Constants.cdlists;

            foreach (var item in getAllCodeLists)
            {
                CodeLists.Add(new Cdlist
                {
                    // Id = item.Value<int>("Id"),
                    Cdgrp = item.CodeGroup,
                    Cdname = item.CodeName,
                    Cdid = item.CodeId,
                    Caption = item.Caption,
                    Cdval = item.CodeValue,
                    Cdidx = item.CodeIndex,
                    Ftag = item.Ftag,
                    Visible = item.Visible,
                    Mcaption = item.Mcaption,
                    App = "ncbsCbs",
                });
            }

            await EngineContext.Current.Resolve<INeptuneDataProvider>().Truncate<Cdlist>(true);
            await EngineContext.Current.Resolve<INeptuneDataProvider>().BulkInsertEntities(CodeLists.ToArray());

            await Task.CompletedTask;
            return Ok("Sync Done");
        }
        else
        {
            var getAllCodeLists = await EngineContext.Current.Resolve<IAdminGrpcService>().GetAllCodeList();

            var CodeLists = Constants.cdlists;

            foreach (var item in getAllCodeLists)
            {
                CodeLists.Add(new Cdlist
                {
                    // Id = item.Value<int>("Id"),
                    Cdgrp = item.CodeGroup,
                    Cdname = item.CodeName,
                    Cdid = item.CodeId,
                    Caption = item.Caption,
                    Cdval = item.CodeValue,
                    Cdidx = item.CodeIndex,
                    Ftag = item.Ftag,
                    Visible = item.Visible,
                    Mcaption = item.Mcaption,
                    App = "ncbsCbs",
                });
            }

            await EngineContext.Current.Resolve<INeptuneDataProvider>().Truncate<Cdlist>(true);
            await EngineContext.Current.Resolve<INeptuneDataProvider>().BulkInsertEntities(CodeLists.ToArray());

            await Task.CompletedTask;
            return Ok("Sync Done");
        }

    }

}