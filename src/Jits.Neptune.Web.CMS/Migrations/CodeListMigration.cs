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
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models.Neptune;
using LinqToDB;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2024/04/30 22:05:00:0000000", "Add CodeListMigration data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class CodeListMigration : AutoReversingMigration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataProvider"></param>
        public CodeListMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            string directoryPath = "./Migrations/SeedData/c_cdlist.csv";
            var cdlist = await Utils.Utils.ReadDataCSV<Cdlist>(directoryPath);

            _dataProvider.Truncate<Cdlist>().Wait();
            _dataProvider.BulkInsertEntities(cdlist).Wait(); 
        }
    }
}