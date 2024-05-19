using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Extensions;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class FormController : BaseController
{
    /// <summary>
    /// Ctor
    /// </summary>
    readonly IRepository<Form> _form = EngineContext.Current.Resolve<IRepository<Form>>();
    readonly INeptuneDataProvider _dataprovider = EngineContext.Current.Resolve<INeptuneDataProvider>();


    /// <summary>
    ///
    /// </summary>
    public FormController() { }

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

                                await Utils.Utils.UploadData<Form, FormExportDataModel>(utfString);
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
    public virtual async Task<IActionResult> DownloadZip(List<FormExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<Form, FormExportDataModel>(
            HttpContext.Request.Host.ToString(),
            listFields
        );
        try
        {
            var zipName = $"Form-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";
            using (MemoryStream ms = new MemoryStream())
            {
                //required: using System.IO.Compression;
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    //QUery the Products table and get all image content
                    files
                        .ToList()
                        .ForEach(file =>
                        {
                            var entry = zip.CreateEntry(file.FileName);
                            using (
                                var fileStream = new MemoryStream(
                                    System.Text.Encoding.UTF8.GetBytes(file.FileContent)
                                )
                            )
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
    public virtual async Task<IActionResult> DownloadZipStartWith(List<FormExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFilesStartWith<Form, FormExportDataModel>(
            HttpContext.Request.Host.ToString(),
            listFields
        );
        try
        {
            var zipName = $"Form-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";
            using (MemoryStream ms = new MemoryStream())
            {
                //required: using System.IO.Compression;
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    //QUery the Products table and get all image content
                    files
                        .ToList()
                        .ForEach(file =>
                        {
                            var entry = zip.CreateEntry(file.FileName);
                            using (
                                var fileStream = new MemoryStream(
                                    System.Text.Encoding.UTF8.GetBytes(file.FileContent)
                                )
                            )
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
    public virtual async Task<IActionResult> ExportToFiles(List<FormExportDataModel> listFields)
    {
        var files = await Utils.Utils.ExportListFiles<Form, FormExportDataModel>(
            HttpContext.Request.Host.ToString(),
            listFields
        );
        try
        {
            foreach (var file in files)
            {
                // var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
                string path = "DeployData/Form/";

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
    public virtual async Task<IActionResult> ExportDataWithContains(
        List<FormExportDataModel> listFields
    )
    {
        var file = await Utils.Utils.ExportDataWithContains<Form, FormExportDataModel>(
            HttpContext.Request.Host.ToString(),
            listFields
        );
        if (file.FileContent is not null)
        {
            var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
            return File(
                fileContents: fileContent,
                contentType: file.ContentType,
                fileDownloadName: file.FileName
            );
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
    public virtual async Task<IActionResult> Export(List<FormExportDataModel> listFields)
    {
        var file = await Utils.Utils.ExportData<Form, FormExportDataModel>(
            HttpContext.Request.Host.ToString(),
            listFields
        );
        if (file.FileContent is not null)
        {
            var fileContent = System.Text.Encoding.UTF8.GetBytes(file.FileContent);
            return File(
                fileContents: fileContent,
                contentType: file.ContentType,
                fileDownloadName: file.FileName
            );
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
        System.Console.WriteLine("===>" + file.ToSerialize());
        string utfString;
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            utfString = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
        }

        JArray jArray = JArray.Parse(utfString);

        await Utils.Utils.UploadData<Form, FormExportDataModel>(utfString);

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

            await Utils.Utils.UploadData<Form, FormExportDataModel>(utfString);
        }

        return Ok();
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<IActionResult> FixTransactionNumber()
    {
        try
        {
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(
                    s =>
                        s.FormId.StartsWith("FO_")
                        || s.FormId == "BO_013003"
                        || s.FormId == "BO_012003"
                )
                .ToListAsync();

            foreach (var form in allFOForm)
            {
                System.Console.WriteLine(form.FormId);
                var form_ = form;
                form_.Info = form_.Info.Replace("reference_id", "transaction_number");
                form_.ListLayout = form_.ListLayout.Replace("reference_id", "transaction_number");
                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

        return Ok();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="list_form"></param>
    /// <param name="mask_format"></param>
    /// <param name="para_key"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> ChangeMaskFormatToParaServerKey(
        string list_form,
        string mask_format,
        string para_key
    )
    {
        if (list_form == "*")
        {
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.ToListAsync();

            foreach (var form in allFOForm)
            {
                var form_ = form;
                // form_.Info = form_.Info.Replace("reference_id", "transaction_number");
                form_.ListLayout = form_.ListLayout.Replace(
                    "\"" + mask_format + "\"",
                    "\"$" + para_key + "$\""
                );
                form_.ListLayout = form_.ListLayout.Replace(
                    "\\\"" + mask_format + "\\\"",
                    "\\\"$" + para_key + "$\\\""
                );
                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
            }
            return Ok();
        }
        try
        {
            list_form += ";";
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(s => list_form.IndexOf(s.FormId + ";") != -1)
                .ToListAsync();

            foreach (var form in allFOForm)
            {
                System.Console.WriteLine(form.FormId);
                var form_ = form;
                // form_.Info = form_.Info.Replace("reference_id", "transaction_number");
                form_.ListLayout = form_.ListLayout.Replace(
                    "\"" + mask_format + "\"",
                    "\"$" + para_key + "$\""
                );
                form_.ListLayout = form_.ListLayout.Replace(
                    "\\\"" + mask_format + "\\\"",
                    "\\\"$" + para_key + "$\\\""
                );
                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

        return Ok();
    }

    /// <summary>
    ///
    /// </summary>

    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public virtual async Task<IActionResult> ChangeSavingToSavings()
    {
        try
        {
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.ToListAsync();

            foreach (var form in allFOForm)
            {
                System.Console.WriteLine(form.FormId);
                var form_ = form;
                // form_.Info = form_.Info.Replace("reference_id", "transaction_number");
                form_.ListLayout = form_.ListLayout.Replace("Saving", "Savings");
                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
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
    public virtual async Task<IActionResult> HotFixCrdMask()
    {
        try
        {
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(s => s.FormId.StartsWith("FO_CRD"))
                .ToListAsync();
            foreach (var form in allFOForm)
            {
                System.Console.WriteLine(form.FormId);
                var form_ = form;
                // form_.Info = form_.Info.Replace("reference_id", "transaction_number");
                form_.ListLayout = form_.ListLayout.Replace(
                    "$MASK_DEPOSIT_ACNO_FO$",
                    "9999-__-__-999999-9"
                );
                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
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
    public virtual async Task<IActionResult> HotFixDateFormat()
    {
        try
        {
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.ToListAsync();
            foreach (var form in allFOForm)
            {
                //System.Console.WriteLine(form.FormId);
                var form_ = form;
                // form_.Info = form_.Info.Replace("reference_id", "transaction_number");
                form_.ListLayout = form_.ListLayout
                    .Replace("\"mask_mode_time\":\"utc\"", "\"mask_mode_time\":\"time_zone_c\"")
                    .Replace("\"mask_mode_time\": \"utc\"", "\"mask_mode_time\": \"time_zone_c\"")
                    .Replace(
                        "\\\"mask_mode_time\\\": \\\"utc\\\"",
                        "\\\"mask_mode_time\\\": \\\"time_zone_c\\\""
                    )
                    .Replace(
                        "\\\"mask_mode_time\\\":\\\"utc\\\"",
                        "\\\"mask_mode_time\\\":\\\"time_zone_c\\\""
                    );
                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

        return Ok();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="transaction_code"></param>
    /// <param name="new_transaction_code"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> CopyFormFO(
        string transaction_code,
        string new_transaction_code
    )
    {
        try
        {
            var findFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(s => s.FormId.StartsWith($"FO_{transaction_code}"))
                .ToListAsync();
            foreach (var form in findFOForm)
            {
                System.Console.WriteLine(form.FormId);
                var form_ = form;

                form_.Id = 0;

                form_.FormId = form_.FormId.Replace(transaction_code, new_transaction_code);

                form_.Info = form_.Info.Replace(transaction_code, new_transaction_code);
                form_.Info = form_.Info.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                form_.ListLayout = form_.ListLayout.Replace(transaction_code, new_transaction_code);
                form_.ListLayout = form_.ListLayout.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                await EngineContext.Current.Resolve<IRepository<Form>>().Insert(form_);
            }

            var findFOApi = await EngineContext.Current
                .Resolve<IRepository<LearnApi>>()
                .Table.Where(
                    s =>
                        s.LearnApiId.StartsWith($"FO_{transaction_code}")
                        || s.LearnApiId.Contains(transaction_code)
                )
                .ToListAsync();
            foreach (var api in findFOApi)
            {
                System.Console.WriteLine(api.LearnApiId);
                var api_ = api;

                api_.Id = 0;

                api_.LearnApiId = api_.LearnApiId.Replace(transaction_code, new_transaction_code);
                api_.LearnApiId = api_.LearnApiId.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                api_.LearnApiName = api_.LearnApiName.Replace(
                    transaction_code,
                    new_transaction_code
                );
                api_.LearnApiName = api_.LearnApiName.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                api_.LearnApiMapping = api_.LearnApiMapping.Replace(
                    transaction_code,
                    new_transaction_code
                );
                api_.LearnApiMapping = api_.LearnApiMapping.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                api_.LearnApiData = api_.LearnApiData.Replace(
                    transaction_code,
                    new_transaction_code
                );
                api_.LearnApiData = api_.LearnApiData.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                api_.LearnApiNodeData = api_.LearnApiNodeData.Replace(
                    transaction_code,
                    new_transaction_code
                );
                api_.LearnApiNodeData = api_.LearnApiNodeData.Replace(
                    transaction_code.ToLower(),
                    new_transaction_code.ToLower()
                );

                await EngineContext.Current.Resolve<IRepository<LearnApi>>().Insert(api_);
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

        return Ok();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="list_form"></param>
    /// <param name="mapS"></param>
    /// <param name="para_key"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> AddKeyToAcceptLearnApi(
        string list_form,
        string para_key,
        string mapS
    )
    {
        var result = "";
        try
        {
            foreach (var str in list_form.Split(";").Where(s => !string.IsNullOrEmpty(s)).ToList())
            {
                var str_ = $"fo_{str.ToLower()}";
                var learn_api_id = $"{str_}_{str_}_btn_accept_post_api_{str_}";
                var findFOApi = await EngineContext.Current
                    .Resolve<IRepository<LearnApi>>()
                    .Table.Where(s => s.LearnApiId.Contains(learn_api_id))
                    .FirstOrDefaultAsync();
                System.Console.WriteLine("findFOApi==" + findFOApi.LearnApiId);

                if (findFOApi != null)
                {
                    result += learn_api_id + ";";
                    var findFOApi_ = findFOApi;
                    var jMapping = JObject.Parse(findFOApi_.LearnApiMapping);
                    jMapping["fields"][para_key] = $"MapS.{mapS}(FO_{str}.{para_key})";
                    findFOApi_.LearnApiMapping = jMapping.ToSerialize();
                    await EngineContext.Current.Resolve<IRepository<LearnApi>>().Update(findFOApi_);
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

        return Ok(result);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="list_form"></param>

    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> BuildIFCFeeIssue213(string list_form)
    {
        var result = "";
        try
        {
            foreach (var form in list_form.Split(";").Where(s => !string.IsNullOrEmpty(s)).ToList())
            {
                var formFeeCode = $"{form}_O9_FEE";
                var getFormFee = await EngineContext.Current
                    .Resolve<IRepository<Form>>()
                    .Table.Where(s => s.FormId == formFeeCode)
                    .FirstOrDefaultAsync();
                if (getFormFee != null)
                {
                    getFormFee.ListLayout = getFormFee.ListLayout.Replace(
                        "IFC_LOOKUP_IFCTYPE_CO",
                        $"{form}ifccd"
                    );
                    getFormFee.Info = getFormFee.Info.Replace(
                        "IFC_LOOKUP_IFCTYPE_CO",
                        $"{form}ifccd"
                    );

                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(getFormFee);
                }

                var formLookupCode = $"{form}ifccd";
                var getFormLookup = await EngineContext.Current
                    .Resolve<IRepository<Form>>()
                    .Table.Where(s => s.FormId == formLookupCode)
                    .FirstOrDefaultAsync();
                if (getFormLookup != null)
                {
                    getFormLookup.Info = getFormLookup.Info.Replace(
                        "IFC_LOOKUP_IFCTYPE_CO",
                        $"{form}ifccd"
                    );
                    getFormLookup.Info = getFormLookup.Info.Replace(
                        "JSON.parse('@{table_name}').total_paging===0",
                        ""
                    );
                    getFormLookup.ListLayout = getFormLookup.ListLayout.Replace(
                        "IFC_LOOKUP_IFCTYPE_CO",
                        $"{form}ifccd"
                    );
                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(getFormLookup);
                }

                var learnApiLookup = $"{form}_api_rulefunc_tran_fee_lkp_data_ifccd";

                var getApiLookup = await EngineContext.Current
                    .Resolve<IRepository<LearnApi>>()
                    .Table.Where(s => s.LearnApiId == learnApiLookup)
                    .FirstOrDefaultAsync();
                if (getApiLookup != null)
                {
                    getApiLookup.LearnApiData = getApiLookup.LearnApiData.Replace(
                        "IFC_LOOKUP_IFCTYPE_CO",
                        $"{form}ifccd"
                    );
                    var jMapping = JObject.Parse(getApiLookup.LearnApiMapping);
                    jMapping["workflowid"] = "IFC_LOOKUP_BY_CURRENCY_AND_TRANSCODE";
                    jMapping["fields"]["currency_code"] = $"MapS.dataS({form}.currency_code)";
                    jMapping["fields"]["tran_code"] = form.Replace("FO_", "");
                    getApiLookup.LearnApiMapping = jMapping.ToSerialize();
                    await EngineContext.Current
                        .Resolve<IRepository<LearnApi>>()
                        .Update(getApiLookup);
                }

                var learnApiGetInfo = $"{form}_api_rulefunc_tran_fee_get_info_ifccd";

                var getApiGetInfo = await EngineContext.Current
                    .Resolve<IRepository<LearnApi>>()
                    .Table.Where(s => s.LearnApiId == learnApiGetInfo)
                    .FirstOrDefaultAsync();
                if (getApiGetInfo != null)
                {
                    getApiGetInfo.LearnApiData = getApiGetInfo.LearnApiData.Replace(
                        "IFC_LOOKUP_IFCTYPE_CO",
                        $"{form}ifccd"
                    );
                    var jMapping = JObject.Parse(getApiGetInfo.LearnApiMapping);
                    jMapping["workflowid"] = "IFC_GET_INFO_IFCCD_BY_CURRENCY_AND_TRANSCODE";
                    jMapping["fields"]["currency_code"] = $"MapS.dataS({form}.currency_code)";
                    jMapping["fields"]["tran_code"] = form.Replace("FO_", "");
                    getApiGetInfo.LearnApiMapping = jMapping.ToSerialize();
                    await EngineContext.Current
                        .Resolve<IRepository<LearnApi>>()
                        .Update(getApiGetInfo);
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }
        return Ok(result);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> FXNeptuneVer2()
    {
        try
        {
            var getFormFx = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(s => s.ListLayout.Contains("branch_id_fx"))
                .ToListAsync();
            if (getFormFx.Count > 0)
            {
                for (var i = 0; i < getFormFx.Count; i++)
                {
                    getFormFx[i].ListLayout = getFormFx[i].ListLayout.Replace(
                        "branch_id_fx",
                        "branch_code_fx"
                    );
                    getFormFx[i].Info = getFormFx[i].Info.Replace("branch_id_fx", "branch_code_fx");

                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(getFormFx[i]);
                }
            }

            var getApiFx = await EngineContext.Current
                .Resolve<IRepository<LearnApi>>()
                .Table.Where(s => s.LearnApiMapping.Contains("branch_id_fx"))
                .ToListAsync();
            if (getApiFx.Count > 0)
            {
                for (var i = 0; i < getApiFx.Count; i++)
                {
                    getApiFx[i].LearnApiMapping = getApiFx[i].LearnApiMapping.Replace(
                        "branch_id",
                        "branch_code"
                    );

                    await EngineContext.Current
                        .Resolve<IRepository<LearnApi>>()
                        .Update(getApiFx[i]);
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
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
    public virtual async Task<IActionResult> FixBranchIdToBranchCode()
    {
        try
        {
            var getApiFx = await EngineContext.Current
                .Resolve<IRepository<LearnApi>>()
                .Table.Where(s => s.LearnApiMapping.Contains("branch_id"))
                .ToListAsync();
            if (getApiFx.Count > 0)
            {
                for (var i = 0; i < getApiFx.Count; i++)
                {
                    getApiFx[i].LearnApiMapping = getApiFx[i].LearnApiMapping.Replace(
                        "branch_id",
                        "branch_code"
                    );

                    await EngineContext.Current
                        .Resolve<IRepository<LearnApi>>()
                        .Update(getApiFx[i]);
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
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
    public virtual async Task<IActionResult> BuildAutoFeeAllFo()
    {
        try
        {
            var getFormDPTHasFee = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(
                    s =>
                        s.ListLayout.Contains("form_fee")
                        && s.App == "ncbsCbs"
                        && s.FormId.StartsWith("FO_DPT")
                )
                .ToListAsync();
            if (getFormDPTHasFee.Count > 0)
            {
                foreach (var item in getFormDPTHasFee)
                {
                    item.Info = item.Info.Replace(
                        "O9_AUTOFEE_POST_GET_IFC_INFO",
                        "O9_AUTOFEE_DPT_POST_GET_IFC_INFO"
                    );

                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(item);

                    // var formFeeDPT = await _form.Table.Where(s => s.FormId == $"{item.FormId}_O9_FEE").FirstOrDefaultAsync();
                    // if (formFeeDPT != null)
                    // {
                    //     System.Console.WriteLine(formFeeDPT.FormId);
                    //     var _layout = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(formFeeDPT.ListLayout);
                    //     var _view`Btn = _layout[1];
                    //     if (_viewBtn["list_input"] != null)
                    //     {
                    //         var _inputBtn = _viewBtn["list_input"].ToJArray();
                    //         var _tableFee = _inputBtn[2].ToJObject();
                    //         _inputBtn[2] = new
                    //         {

                    //         }
                    //     }
                    // }
                }
            }
            //CRD
            var getFormCRDHasFee = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(
                    s =>
                        s.ListLayout.Contains("form_fee")
                        && s.App == "ncbsCbs"
                        && s.FormId.StartsWith("FO_CRD")
                )
                .ToListAsync();
            if (getFormCRDHasFee.Count > 0)
            {
                foreach (var item in getFormCRDHasFee)
                {
                    item.Info = item.Info.Replace(
                        "O9_AUTOFEE_POST_GET_IFC_INFO",
                        "O9_AUTOFEE_CRD_POST_GET_IFC_INFO"
                    );

                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(item);
                }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
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
    public virtual async Task<IActionResult> AddRuleFuncDisableButtonAcceptWhenGetInfoError()
    {
        try
        {
            var allFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(
                    s => s.FormId.StartsWith("FO_")
                )
                .ToListAsync();
            foreach (var form in allFOForm)
            {
                var form_ = form;
                if (form_.FormId.Split("_").Length == 3 && form_.FormId[form_.FormId.Length - 1] != char.ToLower(form_.FormId[form_.FormId.Length - 1]))
                {

                    // System.Console.WriteLine("formInfo",form_.Info);
                    if (form_.ListLayout.IndexOf("check_box_caution") != -1)
                    {
                        if (form_.Info.IndexOf("{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":0,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"check_box_caution\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"false\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},{\"code\":\"setValue\",\"inUse\":false,\"isStart\":false,\"isStatus\":11,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"check_box_caution\",\"component_event\":\"enter_tab\",\"isGetOOP\":\"default\",\"getOOPFormat\":\"{    \\\"check_box_caution\\\": \\\"false\\\"}\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\"},\"isDidStart\":false,\"isOpenFromOther\":false},{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":11,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"check_box_caution\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"true\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},") == -1)
                            form_.Info = form_.Info.Replace("\"ruleStrong\":[", "\"ruleStrong\":[{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":0,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"check_box_caution\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"false\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},{\"code\":\"setValue\",\"inUse\":false,\"isStart\":false,\"isStatus\":11,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"check_box_caution\",\"component_event\":\"enter_tab\",\"isGetOOP\":\"default\",\"getOOPFormat\":\"{    \\\"check_box_caution\\\": \\\"false\\\"}\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\"},\"isDidStart\":false,\"isOpenFromOther\":false},{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":11,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"check_box_caution\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"true\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},");
                    }
                    else
                    {
                        if (form_.Info.IndexOf("{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":0,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"btn_accept\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"false\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":11,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"btn_accept\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"true\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},") == -1)
                            form_.Info = form_.Info.Replace("\"ruleStrong\":[", "\"ruleStrong\":[{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":0,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"btn_accept\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"false\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},{\"code\":\"visibility\",\"inUse\":false,\"isStart\":false,\"isStatus\":11,\"order\":1,\"config\":{\"component_action\":\"\",\"component_result\":\"btn_accept\",\"view_result\":\"\",\"condition\":\"'@{transaction_number}' === \\\"\\\"\",\"visible\":\"not_use\",\"ena_dis\":\"true\",\"component_event\":\"enter_tab\",\"list_config\":[]},\"isDidStart\":false,\"isOpenFromOther\":false},");
                    }
                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
                }

            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

        return Ok();
    }

    /// <summary>
    /// Update all Form from folder
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> UpdateAllFormFromFolder(string folderPath = "DeployData/Form")
    {
        try
        {
            string[] files = Directory.GetFiles(folderPath);
            System.Console.WriteLine("Total Form read from folder: " + files.Length);
            var formMigration = new List<Form>();
            foreach (string filePath in files)
            {
                var data = await Utils.Utils.ReadData<Form>(filePath);
                formMigration.AddRange(data);
            }
            var listOldForm = (from a in formMigration
                               join b in _form.Table on new { a.FormId, a.App } equals new { b.FormId, b.App }
                               select b).ToList();
            var forms = from d in formMigration
                        group d by new { d.FormId, d.App } into groupForms
                        select new
                        {
                            LearnApiId = groupForms.Key,
                            Count = groupForms.Count(),
                        };

            forms = forms.Where(s => s.Count > 1).ToList();
            if (forms.Any())
            {
                string error = $"There is duplicate Form for :";
                foreach (var item in forms)
                {
                    error += item.LearnApiId + "; ";
                }
                return Ok(error);
            }
            System.Console.WriteLine("Total Form delete: " + listOldForm.Count);
            await _dataprovider.BulkDeleteEntities(listOldForm);
            System.Console.WriteLine("Total Form Update: " + formMigration.Count);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="listForm"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> CommandIdAcceptButtonFO(string listForm)
    {
        var listFormsApply = new List<Form>();

        if (listForm != "*")
        {
            foreach (var str in listForm.Split(";").Where(s => !string.IsNullOrEmpty(s)).ToList())
            {
                listFormsApply.Add(await EngineContext.Current.Resolve<IRepository<Form>>().Table.Where(
                s => s.FormId == str && s.App == "ncbsCbs").FirstOrDefaultAsync());
            }
        }
        else listFormsApply = await EngineContext.Current.Resolve<IRepository<Form>>().Table.Where(
                    s => s.FormId.StartsWith("FO_") && s.App == "ncbsCbs").ToListAsync();

        foreach (var form in listFormsApply)
        {
            var listLayout = JArray.Parse(form.ListLayout);
            foreach (var layout in listLayout)
            {
                var listView = JArray.Parse(layout["list_view"].ToString());

                foreach (var view in listView)
                {
                    var listInput = JArray.Parse(view["list_input"].ToString());
                    foreach (var component in listInput)
                    {
                        if (component["default"]["code"].ToString() == "btn_accept" || component["default"]["code"].ToString() == "btn_clear")
                        {
                            component["default"]["codeHidden"] = form.FormId.Replace("FO_", "");
                            System.Console.WriteLine(component["default"].ToSerialize());
                        }
                    }
                    view["list_input"] = listInput;
                }
                layout["list_view"] = listView;
            }
            form.ListLayout = listLayout.ToSerialize();

            await form.Update();
        }
        return Ok($"Done for {listFormsApply.Count} forms.");
    }
     /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> AddIFCName()
    {
       try
        {
            var findFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(s => s.FormId.EndsWith("_O9_FEE"))
                .ToListAsync();
            foreach (var form in findFOForm)
            {
                System.Console.WriteLine(form.FormId);
                var form_ = form;
               
                if(!form_.ListLayout.Contains("{\\\"code\\\":\\\"fee_data.ifc_name\\\",\\\"title\\\":\\\"IFC Name\\\",\\\"inputtype\\\":\\\"ColumnString\\\",\\\"config\\\":{}}")&&!form_.ListLayout.Contains("{\\n        \\\"code\\\": \\\"fee_data.ifc_name\\\",\\n        \\\"title\\\": \\\"IFC Name\\\",\\n        \\\"inputtype\\\": \\\"ColumnString\\\",\\n        \\\"config\\\": {}\\n    }"))
                {
                      form_.ListLayout=form_.ListLayout.Replace("{\\\"code\\\":\\\"fee_data.ifc_code\\\",\\\"title\\\":\\\"IFC code\\\",\\\"inputtype\\\":\\\"ColumnString\\\",\\\"config\\\":{}}",
                      "{\\\"code\\\":\\\"fee_data.ifc_code\\\",\\\"title\\\":\\\"IFC code\\\",\\\"inputtype\\\":\\\"ColumnString\\\",\\\"config\\\":{}},{\\\"code\\\":\\\"fee_data.ifc_name\\\",\\\"title\\\":\\\"IFC Name\\\",\\\"inputtype\\\":\\\"ColumnString\\\",\\\"config\\\":{}}");
                     form_.ListLayout=form_.ListLayout.Replace("{\\n        \\\"code\\\": \\\"fee_data.ifc_code\\\",\\n        \\\"title\\\": \\\"IFC code\\\",\\n        \\\"inputtype\\\": \\\"ColumnString\\\",\\n        \\\"config\\\": {}\\n    }","{\\\"code\\\":\\\"fee_data.ifc_code\\\",\\\"title\\\":\\\"IFC code\\\",\\\"inputtype\\\":\\\"ColumnString\\\",\\\"config\\\":{}},{\\\"code\\\":\\\"fee_data.ifc_name\\\",\\\"title\\\":\\\"IFC Name\\\",\\\"inputtype\\\":\\\"ColumnString\\\",\\\"config\\\":{}}");
                   

                await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
                }
                 //await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
                
            }

            var findFOApi = await EngineContext.Current
                .Resolve<IRepository<LearnApi>>()
                .Table.Where(
                    s =>
                         s.LearnApiId.Contains("btn_accept_post_api")||s.LearnApiId.StartsWith("O9_F2_")
                )
                .ToListAsync();
            foreach (var api in findFOApi)
            {
                System.Console.WriteLine(api.LearnApiId);
                var api_ = api;

               if(!api_.LearnApiMapping.Contains("\\\"ifc_name\\\":\\\"MapS.dataS(fee_data.ifc_name)\\\""))
               {
                 api_.LearnApiMapping = api_.LearnApiMapping.Replace(
                    "\\\"share_fee\\\":\\\"MapS.dataN(fee_data.share_fee)\\\"",
                    "\\\"share_fee\\\":\\\"MapS.dataN(fee_data.share_fee)\\\",\\\"ifc_name\\\":\\\"MapS.dataS(fee_data.ifc_name)\\\""
                );
                await EngineContext.Current.Resolve<IRepository<LearnApi>>().Update(api_);
               }
            }
        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
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
    public virtual async Task<IActionResult> HotFixFormChildOpenMany()
    {  
        string [] list_form_exception= {
            "approve_form_noLater",
            "BO_012003",
            "BO_005005",
            "BO_013001",
            "BO_013003",
            "BO_015001005",
            "BO_015001006",
            "BO_015001007",
            "BO_015003010",
            "BO_015003011",
            "BO_015003014",
            "BO_015004001",
            "BO_015005001",
            "BO_016002",
            "BO_021001",
            "build_tool_form"
        };
        try
        {
            var findFOForm = await EngineContext.Current
                .Resolve<IRepository<Form>>()
                .Table.Where(s => !s.FormId.EndsWith("_search")&&!s.FormId.EndsWith("_Search")&&!s.FormId.EndsWith("_Add")&&!s.FormId.EndsWith("_add")&&!s.FormId.EndsWith("_Import")&&!s.FormId.EndsWith("_setting_service")&&!s.FormId.StartsWith("JWEBUI_")&&s.App=="ncbsCbs"
                && !s.Info.Contains("\"openOne\":\"false\"")
                 && !s.Info.Contains("\"openOne\": \"false\"")
                && !s.Info.Contains("\"openOne\":\"\""))
                .ToListAsync();
            foreach (var form in findFOForm)
            {
                if(!list_form_exception.Any(name=>name==form.FormId))
                {
                    System.Console.WriteLine(form.FormId);
                    var form_ = form;
               
                    form_.Info=form_.Info.Replace("\"openOne\":\"true\"","\"openOne\":\"false\"").Replace("\"openOne\": \"true\"","\"openOne\": \"false\"");
                        
                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
                }
                 //await EngineContext.Current.Resolve<IRepository<Form>>().Update(form_);
                
            }
             return Ok(findFOForm.Count.ToString());

        }
        catch (System.Exception ex)
        {
            // TODO
            return Ok(ex.ToString());
        }

       
    }
}
