using System.Collections.Generic;
using System.Linq;
using FluentMigrator;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;
namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2024/05/09 09:56:33:0000000", "Para server-CMS data1", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class ParaServerDataMigration1 : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public ParaServerDataMigration1(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override void Up()
        {
            var data = new List<ParaServer>(){
                new(){Code ="MASK_DPT_CATALOG", Des="MASK_DPT_CATALOG", Data_Type = "s", Isadmin=true, Value="_____", App ="ncbsCbs"},
            };

            foreach (var item in data)
            {
                var old = _dataProvider.GetTable<ParaServer>().Where(x => x.Code == item.Code).FirstOrDefault();

                if (old == null)
                {
                    //_dataProvider.DeleteEntity(old).Wait();
                    _dataProvider.InsertEntity(item).Wait();
                }
                //_dataProvider.InsertEntity(item).Wait();
            }
        }

        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down()
        {

        }

    }
}