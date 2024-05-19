using System;
using System.Linq;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Web.Framework.Helpers;
using Jits.Neptune.Web.Framework.Services.Localization;
using LinqToDB.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class ToolController : BaseController
{
    readonly IWebchannelService _webchannelService;
    readonly ILangService _langService;


    #region Fields

    #endregion
    /// <summary>
    /// Ctor
    /// </summary>
    public ToolController(IWebchannelService webchannelService, ILangService langService)
    {
        _webchannelService = webchannelService;
        _langService = langService;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<IActionResult> BuildListAuthorizeForms(string app)
    {
        var getLangMigrate = await _webchannelService.BuildListAuthorizeForms(app);
        return Ok(getLangMigrate);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<IActionResult> BuildFormLangByFormName(string app)
    {
        var getLangMigrate = await _webchannelService.BuildFormLangByFormName(app);
        return Ok(getLangMigrate);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<IActionResult> GetMigration()
    {
        var getLangMigrate = await _langService.GetLangMigrate();
        return Ok(getLangMigrate);
    }
    /// <summary>
    /// Search 
    /// </summary>
    /// <param name="js">GenDomain</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public virtual IActionResult GenDomain([FromBody] JObject js)
    {
        string result = "";

        foreach (var item in js.Properties())
        {
            result += "[JsonPropertyName(\"" + item.Name + "\")]  \n public string " + item.Name.ToTitleCase().Replace("_", "") + " { get; set; } ";
        }
        return Ok(result);
    }

    /// <summary>
    /// Search 
    /// </summary>
    /// <param name="js">GenBuilder.</param>
    /// <returns>IActionResult.</returns>
    [HttpPost]
    public virtual IActionResult GenBuilder([FromBody] JObject js)
    {
        string result = "table";

        foreach (var item in js.Properties())
        {
            switch (item.Value.GetType().Name.ToLower())
            {
                case "string":
                    result += ".WithColumn(nameof(TableName." + item.Name.ToTitleCase().Replace("_", "") + ")).AsString(700) \n";
                    break;
                case "boolean":
                    result += ".WithColumn(nameof(TableName." + item.Name.ToTitleCase().Replace("_", "") + ")).AsBoolean() \n";
                    break;
                case "int32":
                    result += ".WithColumn(nameof(TableName." + item.Name.ToTitleCase().Replace("_", "") + ")).AsInt32() \n";
                    break;
                case "int64":
                    result += ".WithColumn(nameof(TableName." + item.Name.ToTitleCase().Replace("_", "") + ")).AsInt64() \n";
                    break;
                default:
                    result += ".WithColumn(nameof(TableName." + item.Name.ToTitleCase().Replace("_", "") + ")).AsString(700) \n";
                    break;
            }

        }
        return Ok(result);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<IActionResult> BuildFormOfRole(string app)
    {
        var result = await _webchannelService.BuildFormOfRole(app);
        return Ok(result);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<IActionResult> FixKeyReadData()
    {
        var result = await _webchannelService.FixKeyReadData();
        return Ok(result);
    }

    /// <summary>
    /// Get query to migrate data
    /// </summary>
    /// <param name="CMSDomainName"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual IActionResult GetMigrationQuery(string CMSDomainName)
    {
        /* Replace: 
            \"replacethis 	=> 	"
            ('new 	=> 	new
            ,'),	=> 	,
            ');	=> 	
            Find and Delete 'Insert Statement'
        */

        Type t = Type.GetType("Jits.Neptune.Web.CMS.Domain." + CMSDomainName + ", Jits.Neptune.Web.CMS");

        System.Reflection.PropertyInfo[] p = t.GetProperties(
           System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static |
           System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        string output = "SELECT CONCAT('new " + t.Name + " {',";
        string outputBody = "";
        for (int i = 0; i < p.Length && p[i].Name != "Id"; i++)
        {
            if (p[i].PropertyType.In(new[] { typeof(String) }))
                outputBody += "'{0}=',IF(t.{0} is NULL,'null',CONCAT('\"replacethis',t.{0},'\"replacethis')),',',";
            else if (p[i].PropertyType.In(new[] { typeof(Decimal), typeof(Decimal?) }))
                outputBody += "'{0}=',IF(t.{0} is NULL,'null',t.{0}),',',";
            else if (p[i].PropertyType.In(new[] { typeof(Int32), typeof(Int32?) }))
                outputBody += "'{0}=',IF(t.{0} is NULL,'null',t.{0}),',',";
            else if (p[i].PropertyType.In(new[] { typeof(DateTime), typeof(DateTime?) }))
                outputBody += "'{0}=',IF(t.{0} is NULL,'null',CONCAT('DateTime.Parse(\"replacethis',t.{0},'\"replacethis)')),',',";
            else if (p[i].PropertyType.In(new[] { typeof(Boolean), typeof(Boolean?) }))
                outputBody += "'{0}=',IF(t.{0} is NULL,'null',IF(t.{0} = 1, 'true', 'false')),',',";
            else
                System.Console.WriteLine("Missing type of: " + p[i].PropertyType);

            outputBody = String.Format(outputBody, p[i].Name);
        }
        output += outputBody;
        output = output.Substring(0, output.Length - 5);
        output += ",'},'";
        output += ") FROM `o9cms`.`" + t.Name + "` t";
        return Ok(output);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> ReplaceBankAccountNumberByAccountNumber()
    {
        try
        {
            string[] listWf = { "ACT_ACCHRT_GET_INFO_ACNO", "ACT_ACCHRT_GET_INFO_BACNO", "ACT_ACCHRT_INS", "ACT_ACCHRT_LOOKUP", "ACT_ACCHRT_SER_ADVANCE" };
            var getApi = await EngineContext.Current.Resolve<IRepository<LearnApi>>().Table.Where(s => s.LearnApiMapping.Contains("bank_account_number")).ToListAsync();

            if (getApi.Count > 0)
            {
                for (var i = 0; i < getApi.Count; i++)
                {
                    getApi[i].LearnApiMapping = getApi[i].LearnApiMapping.Replace("bank_account_number", "account_number");

                    await EngineContext.Current.Resolve<IRepository<LearnApi>>().Update(getApi[i]);
                }

            }

            var getForm = await EngineContext.Current.Resolve<IRepository<Form>>().Table.Where(s => s.Info.Contains("bank_account_number") || s.ListLayout.Contains("bank_account_number")).ToListAsync();

            if (getForm.Count > 0)
            {
                for (var i = 0; i < getForm.Count; i++)
                {
                    getForm[i].Info = getForm[i].Info.Replace("bank_account_number", "account_number");
                    getForm[i].ListLayout = getForm[i].ListLayout.Replace("bank_account_number", "account_number");

                    await EngineContext.Current.Resolve<IRepository<Form>>().Update(getForm[i]);
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
}