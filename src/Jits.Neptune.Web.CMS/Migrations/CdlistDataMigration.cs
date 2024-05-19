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
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Migrations
{
    /// <summary>
    /// Bo Schema Migration
    /// </summary>
    [NeptuneMigration("2020/01/01 18:32:46:0000000", "Cdlist-CMS data", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class CdlistDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public CdlistDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Localization migrations
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override async void Up()
        {
            //var CMSCdlists = Constants.cdlists;
            //System.Console.WriteLine("Migrating CMSCdlists...: " + CMSCdlists.Count);
            //_dataProvider.BulkInsertEntities(CMSCdlists).Wait();

            // ADM


            var data = await Utils.Utils.ReadData<Cdlist>("CdlistData.json");

            await _dataProvider.Truncate<Cdlist>(false);
            await _dataProvider.BulkInsertEntities(data.ToArray());

            //var jArray = JArray.Parse(File.ReadAllText("CodeListData.json"));
            //var jObject = jArray.Children<JObject>().FirstOrDefault(o => o["data"] != null);
            //if (jObject is not null)
            //{
            //    var data = jObject.Value<JArray>("data");
            //    var ADMCdlists = (from item in data
            //                      select new Cdlist
            //                      {
            //                          // Id = item.Value<int>("Id"),
            //                          Cdgrp = item.Value<string>("code_group"),
            //                          Cdname = item.Value<string>("code_name"),
            //                          Cdid = item.Value<string>("code_id"),
            //                          Caption = item.Value<string>("caption"),
            //                          Cdval = item.Value<string>("code_value"),
            //                          Cdidx = item.Value<int>("code_index"),
            //                          Ftag = item.Value<string>("ftag"),
            //                          Visible = item.Value<int>("visible"),
            //                          Mcaption = item.Value<string>("mcaption"),
            //                          App = "ncbsCbs",
            //                      }).ToList();

            //    System.Console.WriteLine("Migrating ADMCdlists...: " + ADMCdlists.Count);
            //    _dataProvider.BulkInsertEntities(ADMCdlists).Wait();
            //}

        }
    }
}