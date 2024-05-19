using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jits.Neptune.Web.Framework.Controllers;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Configuration;

namespace Jits.Neptune.Web.CMS.Controllers
{
    /// <summary>
    /// User role controller
    /// </summary>
    public partial class BackupRestoreDatabaseController : BaseController
    {
        #region Fields
        private readonly INeptuneDataProvider _dataProvider;
        private readonly CMSSetting _setting;
        #endregion

        /// <summary>
        /// Migration
        /// </summary>
        public BackupRestoreDatabaseController(INeptuneDataProvider dataProvider, CMSSetting setting)
        {
            _dataProvider = dataProvider;
            _setting = setting;
        }

        /// <summary>
        /// Backup for MSSQL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> BackupDatabase(string FileName)
        {
            string defaultPath = $"{_setting.BackupDirectory}{FileName}.bak";
            await _dataProvider.BackupDatabase(defaultPath);
            return Ok();
        }

        /// <summary>
        /// Restore for MSSQL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> RestoreDatabase(string FileName)
        {
            string defaultPath = $"{_setting.BackupDirectory}{FileName}.bak";
            await _dataProvider.RestoreDatabase(defaultPath);
            return Ok();
        }
    }
}