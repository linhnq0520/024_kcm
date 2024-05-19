using System.Collections.Generic;
using System.Linq;
using FluentMigrator;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Domain.Localization;
using Jits.Neptune.Core.Domain.Neptune;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [NeptuneMigration("2024/05/01 10:24:38:0000000", "Add LocalizationData", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class LocalizationDataMigration : Migration
    {
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migration constructor
        /// </summary>
        /// <param name="dataProvider"></param>
        public LocalizationDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override void Up()
        {
            var resources = new List<LocaleStringResource> {
                new() { Language = "en", ResourceName = "CMS.String.OverLimit", ResourceValue = "Officer Approval Require" },
                new() { Language = "en", ResourceName = "CMS.String.ApprovalRequired", ResourceValue = "Approval Require" },
                new() { Language = "en", ResourceName = "CMS.String.CantCallGrpcAdmin", ResourceValue = "Can't connect to service Admin. Please check your server!" },
                new() { Language = "en", ResourceName = "CMS.String.CantConnectDb", ResourceValue = "Can't connect to database. Please check your database!" },
                new() { Language = "en", ResourceName = "UserAccount.InvalidUserId", ResourceValue = "Invalid UserID!" },
            };
            foreach(var item in resources) {
                if(!_dataProvider.GetTable<LocaleStringResource>().Where(x=>x.ResourceName == item.ResourceName).Any()){
                    _dataProvider.InsertEntity(item).Wait();
                }
            }
           //_dataProvider.BulkInsertEntities(resources.ToArray()).Wait();

        }
        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down()
        {

        }
    }
}

