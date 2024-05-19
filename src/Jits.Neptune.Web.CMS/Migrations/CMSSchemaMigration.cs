using System.Data;
using FluentMigrator;
using Jits.Neptune.Data.Extensions;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations;

/// <summary>
/// CMS Schema Migration
/// </summary>
[NeptuneMigration("2020/01/01 12:44:01:0000000", "CMS data base schema", MigrationProcessType.Installation)]
public class CMSSchemaMigration : AutoReversingMigration
{
    /// <summary>
    /// Update to database
    /// </summary>
    public override void Up()
    {
        Create.TableFor<Fo>();
        Create.TableFor<Bo>();
        Create.TableFor<Cdlist>();
        Create.TableFor<App>();
        Create.TableFor<LearnApi>();
        Create.TableFor<Form>();
        Create.TableFor<ParaServer>();
        Create.TableFor<AppOfRole>();
        Create.TableFor<MediaUpload>();
        Create.TableFor<DesignGroup>();
        Create.TableFor<DesignItem>();
        Create.TableFor<DesignTemplateForm>();
        Create.TableFor<FormShortcut>();
        Create.TableFor<Lang>();
        Create.TableFor<LogService>();
        Create.TableFor<OrganizationParameter>();
        Create.TableFor<RoleCache>();
        Create.TableFor<ScheduleJob>();
        Create.TableFor<ShortcutConfig>();
        Create.TableFor<TemplateVoucher>();
        Create.TableFor<UserSessions>();


        Create.UniqueConstraint("UC_Bo").OnTable(nameof(Bo)).Columns(nameof(Bo.Txcode), nameof(Bo.App));
        Create.UniqueConstraint("UC_Fo").OnTable(nameof(Fo)).Columns(nameof(Fo.Txcode), nameof(Fo.App));
        Create.UniqueConstraint("UC_App").OnTable(nameof(App)).Columns(nameof(App.ListApplicationId));
        Create.UniqueConstraint("UC_LearnApi").OnTable(nameof(LearnApi)).Columns(nameof(LearnApi.LearnApiId), nameof(LearnApi.App));
        Create.UniqueConstraint("UC_ParaServer").OnTable(nameof(ParaServer)).Columns(nameof(ParaServer.Code), nameof(ParaServer.App));

    }
}