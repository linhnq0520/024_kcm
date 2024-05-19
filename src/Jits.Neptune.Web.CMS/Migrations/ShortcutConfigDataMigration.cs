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
    [NeptuneMigration(
        "2023/07/12 17:48:22:0000000",
        "ShortcutConfig-CMS data",
        UpdateMigrationType.Data,
        MigrationProcessType.Update
    )]
    public class ShortcutConfigDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public ShortcutConfigDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override void Up()
        {
            var ShortcutConfigs = new List<ShortcutConfig>
            {
                //
                new ShortcutConfig
                {
                    Name = "Jump to Search Global",
                    ShortcutId = "jump_search_global",
                    Keystrokes = "ctrlKey+Slash",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Open Debug",
                    ShortcutId = "open_debug",
                    Keystrokes = "ctrlKey+Period",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Open Shortcut",
                    ShortcutId = "open_shortcut",
                    Keystrokes = "shiftKey+Slash",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Open Transaction Journal",
                    ShortcutId = "open_journal",
                    Keystrokes = "F8",
                    UserId = "",
                    FormCode = "BO_013001",
                    App = "ncbsCbs"
                },
                new ShortcutConfig
                {
                    Name = "Open FX Transaction",
                    ShortcutId = "fx_transaction",
                    Keystrokes = "F2",
                    UserId = "",
                    FormCode = "BO_013003",
                    App = "ncbsCbs"
                },
                new ShortcutConfig
                {
                    Name = "Open Internal Transaction",
                    ShortcutId = "act_man",
                    Keystrokes = "ctrlKey+F3",
                    UserId = "",
                    FormCode = "BO_012003",
                    App = "ncbsCbs"
                },
                new ShortcutConfig
                {
                    Name = "Open Cash Flow",
                    ShortcutId = "cash_flow",
                    Keystrokes = "ctrlKey+F7",
                    UserId = "",
                    FormCode = "BO_011001",
                    App = "ncbsCbs"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 1",
                    ShortcutId = "switch_tab1",
                    Keystrokes = "shiftKey+Digit1",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 2",
                    ShortcutId = "switch_tab2",
                    Keystrokes = "shiftKey+Digit2",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 3",
                    ShortcutId = "switch_tab3",
                    Keystrokes = "shiftKey+Digit3",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 4",
                    ShortcutId = "switch_tab4",
                    Keystrokes = "shiftKey+Digit4",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 5",
                    ShortcutId = "switch_tab5",
                    Keystrokes = "shiftKey+Digit5",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 6",
                    ShortcutId = "switch_tab6",
                    Keystrokes = "shiftKey+Digit6",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 7",
                    ShortcutId = "switch_tab7",
                    Keystrokes = "shiftKey+Digit7",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 8",
                    ShortcutId = "switch_tab8",
                    Keystrokes = "shiftKey+Digit8",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                },
                new ShortcutConfig
                {
                    Name = "Switch to tab 9",
                    ShortcutId = "switch_tab9",
                    Keystrokes = "shiftKey+Digit9",
                    UserId = "",
                    FormCode = "",
                    App = "sys"
                }
            };

            _dataProvider.BulkInsertEntities(ShortcutConfigs.ToArray()).Wait();
        }

        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down() { }
    }
}
