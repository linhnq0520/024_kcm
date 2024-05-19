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
        "2023/07/12 18:19:22:0000000",
        "FormShortcut-CMS data",
        UpdateMigrationType.Data,
        MigrationProcessType.Update
    )]
    public class FormShortcutDataMigration : Migration
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly INeptuneDataProvider _dataProvider;

        /// <summary>
        /// Localization migrations
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public FormShortcutDataMigration(INeptuneDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Up migration
        /// </summary>
        public override void Up()
        {
            var FormShortcuts = new List<FormShortcut>
            {
                //

                new FormShortcut
                {
                    FormId = "BO_012005006_Search",
                    FormName = "ACT-Clearing Account Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012005006_Add",
                    FormName = "ACT-Clearing Account Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012005005_Search",
                    FormName = "ACT-Common Account Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012005005_Add",
                    FormName = "ACT-Common Account Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012005007_Search",
                    FormName = "ACT-Foreign Exchange Account Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012005007_Add",
                    FormName = "ACT-Foreign Exchange Account Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012004001_Search",
                    FormName = "FAC-Fixed Asset And Tool-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_FAC_OPN",
                    FormName = "FAC-Open New Fixed Asset",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012004005_Search",
                    FormName = "FAC-Fixed Asset Catalogue Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012004005_Add",
                    FormName = "FAC-Fixed Asset Catalogue Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012006_Search",
                    FormName = "ACT-Account Map Table-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012006_Add",
                    FormName = "ACT-Account Map Table-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012002_Search",
                    FormName = "ACT-Bank Account Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012002_Add",
                    FormName = "ACT-Bank Account Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_012003",
                    FormName = "ACT-Internal Transaction",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003010",
                    FormName = "ADM-Bank Open/Close",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003001_Search",
                    FormName = "ADM-Branch Profile-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003001_Add",
                    FormName = "ADM-Branch Profile-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003002_Search",
                    FormName = "ADM-Department Profile-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003002_Add",
                    FormName = "ADM-Department Profile-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003011",
                    FormName = "ADM-Foreign Exchange Rate",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003006_Search",
                    FormName = "ADM-System Policy-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003006_Add",
                    FormName = "ADM-System Policy-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003004_Search",
                    FormName = "ADM-User Profile-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015003004_Add",
                    FormName = "ADM-User Profile-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015005001",
                    FormName = "ADM-Branch Open/Close",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015002004_Search",
                    FormName = "PMT-Correspondent Bank-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015002004_Add",
                    FormName = "PMT-Correspondent Bank-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015002001_Search",
                    FormName = "ADM-Country-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015002001_Add",
                    FormName = "ADM-Country-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015002002_Search",
                    FormName = "ADM-Currency-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015004001",
                    FormName = "ADM-Working Schedule And Holidays",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015001005_Search",
                    FormName = "ADM-Import Data Files - Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015001005_Add",
                    FormName = "ADM-Import Data Files - Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015001007_Search",
                    FormName = "ADM-Import Master Data Files - Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_015001001_Search",
                    FormName = "ADM-System Code Table",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_010002_Search",
                    FormName = "MTG-Account Information-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_MTG_OPN",
                    FormName = "4400: Open new collateral account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_010001_Search",
                    FormName = "MTG-Catalogue Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_010001_Add",
                    FormName = "MTG-Catalogue Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006010_Search",
                    FormName = "CRD-IFC Item Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006010_Add",
                    FormName = "CRD-IFC Item Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006002_Search",
                    FormName = "CRD-Account Information-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_OPN",
                    FormName = "5500: Open new credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006008_Search",
                    FormName = "CRD-Approve Account Modification-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006001_Search",
                    FormName = "CRD-Catalogue Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006001_Add",
                    FormName = "CRD-Catalogue Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006006_Search",
                    FormName = "CRD-Product Limit-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_PLO",
                    FormName = "CRD-Open product limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "BO_006007_Search",
                    FormName = "CRD-Sub Product Limit-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_SPLO",
                    FormName = "CRD-Open sub-product limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003007_Search",
                    FormName = "CTM-Approve Profile Modification-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003008_Search",
                    FormName = "CTM-Approve Customer relation management Modify-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003009_Search",
                    FormName = "CTM-Approve Customer Linkage Modify-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003002_Search",
                    FormName = "CTM-Customer relation management-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003003_Search",
                    FormName = "CTM-Customer Linkage-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003005",
                    FormName = "CTM-Customer media files",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003001_Search",
                    FormName = "CTM-Customer Profile-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_003001_Add",
                    FormName = "CTM-Customer Profile-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005009_Search",
                    FormName = "DPT-IFC Item Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005009_Add",
                    FormName = "DPT-IFC Item Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005002_Search",
                    FormName = "DPT-Account Information-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_OPN",
                    FormName = "1100: Open new deposit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005007_Search",
                    FormName = "DPT-Approve Account Modification-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005012_Search",
                    FormName = "DPT-Approve Overdraft Contract Modification-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005001_Search",
                    FormName = "DPT-Catalogue Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005001_Add",
                    FormName = "DPT-Catalogue Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005011_Search",
                    FormName = "DPT-OD Catalogue Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005011_Add",
                    FormName = "DPT-OD Catalogue Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_005004_Search",
                    FormName = "DPT-Stock Inventory-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_SRG",
                    FormName = "11830: Stock registration",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_013004",
                    FormName = "CSH_CFX: Cash foreign exchange at counter",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_016002",
                    FormName = "JOB-Job Process",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007022_Search",
                    FormName = "PMT-IFC Auto Fee-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007022_Add",
                    FormName = "PMT-IFC Auto Fee-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007023_Search",
                    FormName = "PMT-IFC Item Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007023_Add",
                    FormName = "PMT-IFC Item Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007009_Search",
                    FormName = "DPT-Account Linkage-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_OPAL",
                    FormName = "DPT-Account Linkage-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007001_Search",
                    FormName = "PMT-Catalogue Definition-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007001_Add",
                    FormName = "PMT-Catalogue Definition-Add",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007020_Search",
                    FormName = "PMT-Payment Queue for Inward-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "BO_007006_Search",
                    FormName = "PMT-Payment Queue for Outward-Search",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_ODO",
                    FormName = "1101: Create overdraft contract",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CDP",
                    FormName = "1110: Cash deposit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CDT",
                    FormName = "1111: Deposit by cheque",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_MDP",
                    FormName = "1112: Miscellaneous deposit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CWR",
                    FormName = "1120: Cash withdrawal",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CWC",
                    FormName = "1121: Cash withdrawal by cheque",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_MWR",
                    FormName = "1122: Miscellaneous withdrawal",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CWM",
                    FormName = "1125: Misellaneous debit by cheque",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_TRF",
                    FormName = "1130: Transfer from deposit account to deposit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CCD",
                    FormName = "1151: Outward cheque sent for clearing",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_HIS",
                    FormName = "1160: Transaction history inquiry",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_SLS",
                    FormName = "DPT-1162: Cheque Leaves Status Inquiry",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CIQ",
                    FormName = "1167: Cheque inquiry",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_IFC",
                    FormName = "DPT-1169: Adjust Deposit Interest",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CIS",
                    FormName = "11801: Cheque book issued",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_SBI",
                    FormName = "11802: Deposit savings book issue",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CER",
                    FormName = "11803: Fixed deposit receipt issued",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_FBI",
                    FormName = "11804: Fixed deposit book issue",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CCI",
                    FormName = "11806: Gift cheque issued",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CCW",
                    FormName = "11807: Gift Cheque withdrawal",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_RCC",
                    FormName = "11808: Gift cheque return",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_EMK",
                    FormName = "1180:Hold balance",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_POI",
                    FormName = "11816: Payment order issued",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_POW",
                    FormName = "11817: Payment order withdrawal",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_RPO",
                    FormName = "11818: Payment order return",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                
                 new FormShortcut
                {
                    FormId = "FO_DPT_SAB",
                    FormName = "DPT-11831: Stock Assigned To Branch",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_SAT",
                    FormName = "11832: Stock assign to Staff",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CRT",
                    FormName = "11833: Stock returned",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CCR",
                    FormName = "DPT-11834: Stock Confirm Received",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_SRA",
                    FormName = "DPT-11835: Reject Assigned Stock",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CTS",
                    FormName = "11837: Change status of stock",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_BLK",
                    FormName = "11840: Block account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CAS",
                    FormName = "11841: Change account status",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_RLS",
                    FormName = "11843: Release block account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_FOC",
                    FormName = "1184: Fee collection by cash for DD",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CEI",
                    FormName = "11850:Issued hold balance for cheque",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_ERL",
                    FormName = "11851:Release hold balance",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_REC",
                    FormName = "11852:Release hold balance for cheque",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_FEE",
                    FormName = "1185: Fee collection by transfer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_DLS",
                    FormName = "1190: Close deposit account by deposit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_MLS",
                    FormName = "1191: Close deposit account by miscellaneous",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_CLS",
                    FormName = "1193: Close deposit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_DOD",
                    FormName = "1194: Close OD Facility by Transfer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_COD",
                    FormName = "1195: Close OD Facility by Cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_APR",
                    FormName = "Approve deposit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_ODA",
                    FormName = "Approve overdraft contract",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_DPT_CAS_OD",
                    FormName = "Change Overdraft Contract Status",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_NPL_OD",
                    FormName = "OD-NPL Processing",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_DPT_EXT_TENOR_OD",
                    FormName = "Overdraft extend tenor",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_ADJ_LIMIT_OD",
                    FormName = "Overdraft limit adjustment",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_DPT_REJ",
                    FormName = "Reject deposit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_DPT_REJ_OD",
                    FormName = "Reject overdraft contract",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_MIPM",
                    FormName = "5511: Miscelaneous interest and principal collection",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_CIPM",
                    FormName = "5512:Principal and interest collection by cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_IPCT",
                    FormName = "5513: Principal and interest collection by transfer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_CDR",
                    FormName = "5520: Cash disbursement",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_MDR",
                    FormName = "5521: Miscellaneous disbursement",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_TDR",
                    FormName = "5523: Disbursement by transfer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_APR",
                    FormName = "5550: Approve credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_HIS",
                    FormName = "5560: History Inquiry",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_IFC",
                    FormName = "5562: CRD-Adjust Credit Interest",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_CLA",
                    FormName = "5563: Credit limit adjustment",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_RFC",
                    FormName = "55711: Fee refund by cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_FOC",
                    FormName = "5571: Fee collection by cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_RFD",
                    FormName = "55721: Fee refund by transfer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_FCD",
                    FormName = "5572: Fee collection by deposit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_FRG",
                    FormName = "55731: Miscellaneous fee refund",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_FCG",
                    FormName = "5573: Miscellaneous fee collection",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_BLK",
                    FormName = "55840: Block credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_CAS",
                    FormName = "55841: Change Account Status",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_REJ",
                    FormName = "55842: Reject credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_CLS",
                    FormName = "5590: Close account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_EXT",
                    FormName = "5598: Extend credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_PLAD",
                    FormName = "CRD-Adjust Product Limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_SPAD",
                    FormName = "CRD-Adjust Sub Product Limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_PLA",
                    FormName = "Approve product limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_SPLA",
                    FormName = "CRD-Approve Sub Product Limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_PLC",
                    FormName = "CRD-Close Product Limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CRD_SPLC",
                    FormName = "CRD-Close Sub Product Limit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CRD_NPL",
                    FormName = "CRD-NPL Processing",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_PMT_OIT",
                    FormName = "6600: Outward internal bank",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_PMT_OITT",
                    FormName = "6602: Outward international bank",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_PMT_IIT",
                    FormName = "6610: Inward internal bank",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_PMT_IITT",
                    FormName = "6612: Inward international bank",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_PMT_KITT",
                    FormName = "6630: Create inward (domestic/swift) message",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_RLS",
                    FormName = "4410: Release asset from credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_MTG_SCR",
                    FormName = "4420: Secure asset for credit account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_RTN",
                    FormName = "4431: Return collateral asset to customer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_APR",
                    FormName = "4450: Approve collateral account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_MTG_INR",
                    FormName = "4451: Increasing asset value",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_DCR",
                    FormName = "4452: Decreasing asset value",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_HDT",
                    FormName = "4460: History Inquiry Detail",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_MTG_BRL",
                    FormName = "4481: Release block account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_BLK",
                    FormName = "4484: Block account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_CLS",
                    FormName = "4490: Close account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_MTG_RLS_OD",
                    FormName = "Release asset from overdraft contract",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_MTG_SCR_OD",
                    FormName = "Secure asset for overdraft contract",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_ACT_FEE",
                    FormName = "1186: Fee collection by cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_ACT_GFEE",
                    FormName = "ACT-1187: Miscellaneous Fee Collection",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_FAC_CLS",
                    FormName = "FAC-Close Fixedasset Account",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_FAC_PBG",
                    FormName = "FAC-Purchase Fixed Asset By Accounting",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_FAC_PBC",
                    FormName = "FAC-Purchase Fixed Asset By Cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_FAC_PBD",
                    FormName = "FAC-Purchase Fixed Asset By Deposit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_FAC_SBG",
                    FormName = "FAC-Selling Fixed Asset By Accounting",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_FAC_SBC",
                    FormName = "FAC-Selling Fixed Asset By Cash",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_FAC_SBD",
                    FormName = "FAC-Selling Fixed Asset By Deposit",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_FAC_TFB",
                    FormName = "FAC-Transfer Fixed Asset To Another Branch",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CSH_DNM",
                    FormName = "Cash denomination",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CSH_BMOV",
                    FormName = "CSH-Internal Branch Cash Movement",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CSH_MOV",
                    FormName = "CSH-Internal Cash Movement",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                new FormShortcut
                {
                    FormId = "FO_CTM_APR",
                    FormName = "Approve customer",
                    App = "ncbsCbs",
                    GroupCode = ""
                },
                 new FormShortcut
                {
                    FormId = "FO_CTM_CAS",
                    FormName = "Change customer status",
                    App = "ncbsCbs",
                    GroupCode = ""
                }
            };

            _dataProvider.BulkInsertEntities(FormShortcuts.ToArray()).Wait();
        }

        /// <summary>
        /// Down migration
        /// </summary>
        public override void Down() { }
    }
}
