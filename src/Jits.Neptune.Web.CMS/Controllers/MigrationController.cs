using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.Framework.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jits.Neptune.Web.CMS.Controllers;

/// <summary>
/// User Account controller
/// </summary>
public partial class MigrationController : BaseController
{
    /// <summary>
    /// Ctor
    /// </summary>
    public MigrationController() { }

    /// <summary>
    /// ReMigration
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public virtual async Task<IActionResult> ReMigration(
        IFormFileCollection files,
        bool Truncate = false
    )
    {
        foreach (var file in files)
        {
            string utfString = string.Empty;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                utfString = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
            }
            await Utils.Utils.MigrateData<App>(utfString, Truncate);
            await Utils.Utils.MigrateData<Bo>(utfString, Truncate);
            await Utils.Utils.MigrateData<Cdlist>(utfString, Truncate);
            await Utils.Utils.MigrateData<DesignGroup>(utfString, Truncate);
            await Utils.Utils.MigrateData<DesignItem>(utfString, Truncate);
            await Utils.Utils.MigrateData<Fo>(utfString, Truncate);
            await Utils.Utils.MigrateData<Form>(utfString, Truncate);
            await Utils.Utils.MigrateData<Lang>(utfString, Truncate);
            await Utils.Utils.MigrateData<LearnApi>(utfString, Truncate);
            await Utils.Utils.MigrateData<ParaServer>(utfString, Truncate);
            await Utils.Utils.MigrateData<TemplateVoucher>(utfString, Truncate);
            await Utils.Utils.MigrateData<ShortcutConfig>(utfString, Truncate);
            await Utils.Utils.MigrateData<FormShortcut>(utfString, Truncate);
            await Utils.Utils.MigrateData<AppOfRole>(utfString, Truncate);
        }
        return Ok();
    }
}
