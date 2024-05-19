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
    [NeptuneMigration("2020/01/01 14:33:18:0000000", "Form-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class FormDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public FormDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
         public override async void Up()
        {
            var data = await Utils.Utils.ReadData<Form>("FormData.json");

            await _dataProvider.Truncate<Form>(false);
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