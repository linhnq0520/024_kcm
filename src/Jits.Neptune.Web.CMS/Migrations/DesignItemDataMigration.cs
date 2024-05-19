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
    [NeptuneMigration("2021/01/02 17:55:39:0000000", "DesignItem-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class DesignItemDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public DesignItemDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            var data = await Utils.Utils.ReadData<DesignItem>("DesignItemData.json");

            await _dataProvider.Truncate<DesignItem>(false);
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