using System;
using System.Collections.Generic;
using FluentMigrator;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Domain.Neptune;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2020/01/01 14:33:39:0000000", "App-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class AppDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public AppDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            var data = await Utils.Utils.ReadData<App>("AppData.json");

            await _dataProvider.Truncate<App>(false);
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