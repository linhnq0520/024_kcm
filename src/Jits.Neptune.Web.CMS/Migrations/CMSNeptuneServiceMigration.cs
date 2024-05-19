using System.Collections.Generic;
using FluentMigrator;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Core.Domain.Localization;
using Jits.Neptune.Core.Domain.Neptune;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Services.Workflow;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// CMS locolization migration
    /// </summary>
    [NeptuneMigration("2020/01/01 22:31:40:1000000", "CMSServiceMigration installed", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class CMSServiceMigration : Migration
    {
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migration constructor
        /// </summary>
        /// <param name="dataProvider"></param>
        public CMSServiceMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override void Up()
        {
            const string nameSpace = "Jits.Neptune.Web.CMS.Services.Workflow";
            const string settingQueue = "CMSSettingQueueService";


            var mappings = new List<NeptuneService> {
                new NeptuneService { StepCode = "CMS_SETTING_ADD", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.Create) },
                new NeptuneService { StepCode = "CMS_SETTING_UPDATE", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.Update) },
                new NeptuneService { StepCode = "CMS_SETTING_DELETE", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.Delete) },
                new NeptuneService { StepCode = "CMS_SETTING_VIEW", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.View) },
                new NeptuneService { StepCode = "CMS_SETTING_SEARCH", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.SimpleSearch) },
                new NeptuneService { StepCode = "CMS_SETTING_ADSEARCH", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.AdvanceSearch) },
                new NeptuneService { StepCode = "CMS_LIST_AUDIT_SETTING", FullClassName =nameSpace + "." + settingQueue, MethodName = nameof(CMSSettingQueueService.GetListAuditSetting) },
                    };

            _dataProvider.BulkInsertEntities(mappings.ToArray()).Wait();

        }
        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down()
        {

        }
    }
}

