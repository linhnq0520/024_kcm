using FluentMigrator;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Domain.Neptune;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Data.Migrations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2020/01/01 14:33:32:0000000", "LearnApi-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class LearnApiDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public LearnApiDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            var data = await Utils.Utils.ReadData<LearnApi>("LearnApiData.json");

            await _dataProvider.Truncate<LearnApi>(false);
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