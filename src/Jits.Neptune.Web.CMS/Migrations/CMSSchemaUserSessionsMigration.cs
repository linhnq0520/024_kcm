using System.Data;
using FluentMigrator;
using Jits.Neptune.Data.Extensions;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations;

/// <summary>
/// CMS Schema Migration
/// </summary>
[NeptuneMigration("2024/03/25 12:44:01:0000000", "CMS data base schema", MigrationProcessType.Installation)]
public class CMSSchemaUserSessionsMigration : AutoReversingMigration
{
    /// <summary>
    /// Update to database
    /// </summary>
    public override void Up()
    {
        Create.TableFor<UserSessions>();
    }
}