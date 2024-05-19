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
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2024/04/23 15:47:00:0000000", "WorkflowDefinition data 4", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class WorkflowDefinitionMigration4 : AutoReversingMigration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataProvider"></param>
        public WorkflowDefinitionMigration4(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            string directoryPath = "./Migrations/SeedData/MTGWorkflowDefinition.csv";
            var data = await Utils.Utils.ReadDataCSV<WorkflowDefinition>(directoryPath);

            foreach (var item in data)
            {
                var old = _dataProvider.GetTable<WorkflowDefinition>().Where(x => x.WorkflowId == item.WorkflowId).FirstOrDefault();

                if (old != null)
                {
                    _dataProvider.DeleteEntity(old).Wait();
                    //_dataProvider.InsertEntity(item).Wait();
                }
                _dataProvider.InsertEntity(item).Wait();
            }
        }
    }
}