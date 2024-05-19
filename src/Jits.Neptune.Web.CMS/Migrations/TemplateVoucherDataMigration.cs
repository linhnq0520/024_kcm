using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentMigrator;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Domain.Neptune;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2020/01/03 21:28:22:0000000", "TemplateVoucher-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class TemplateVoucherDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public TemplateVoucherDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            var data = await Utils.Utils.ReadData<TemplateVoucher>("TemplateVoucherData.json");

            await _dataProvider.Truncate<TemplateVoucher>(false);
            await _dataProvider.BulkInsertEntities(data.ToArray());
        }

        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down()
        {

        }

    }
}