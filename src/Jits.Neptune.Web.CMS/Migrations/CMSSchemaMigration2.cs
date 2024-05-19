using System.Collections.Generic;
using System.Data;
using System.Linq;
using FluentMigrator;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Data.Extensions;
using Jits.Neptune.Data.Migrations;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Infrastructure;
using LinqToDB;
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;

namespace Jits.Neptune.Web.CMS.Migrations;

/// <summary>
/// CMS Schema Migration
/// </summary>
[NeptuneMigration("2024/05/17 10:39:01:0000000", "CMS data base schema 2", MigrationProcessType.Installation)]
public class CMSSchemaMigration2 : AutoReversingMigration
{
    private readonly INeptuneDataProvider _dataProvider;
    private readonly WorkflowStartup _workflowStartup;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataProvider"></param>
    /// <param name="workflowStartup"></param>
    public CMSSchemaMigration2(INeptuneDataProvider dataProvider, WorkflowStartup workflowStartup)
    {
        _dataProvider = dataProvider;
        _workflowStartup = workflowStartup;
    }
    /// <summary>
    /// Update to database
    /// </summary>
    public override void Up()
    {
        if (!Schema.Table(nameof(WorkflowDefinition)).Exists())
        {
            Create.TableFor<WorkflowDefinition>();
            Create.UniqueConstraint("UC_WF_DEF").OnTable(nameof(WorkflowDefinition))
                .Columns(nameof(WorkflowDefinition.WorkflowId), nameof(WorkflowDefinition.Status));

        }

        if(Singleton<ConfigureWorkflow>.Instance == null || !Singleton<ConfigureWorkflow>.Instance.Workflows.Any())
        {
            _workflowStartup.InitializeWorkflowInstances();
        }
        if (Schema.Table(nameof(WorkflowDefinition)).Exists())
        {
            if (Schema.Table(nameof(WorkflowDefinition)).Column(nameof(WorkflowDefinition.FullInterfaceName)).Exists())
            {
                Alter.Table(nameof(WorkflowDefinition))
                    .AlterColumn(nameof(WorkflowDefinition.FullInterfaceName)).AsString(500).Nullable();
            }
            if (Schema.Table(nameof(WorkflowDefinition)).Column(nameof(WorkflowDefinition.MethodName)).Exists())
            {
                Alter.Table(nameof(WorkflowDefinition))
                    .AlterColumn(nameof(WorkflowDefinition.MethodName)).AsString(50).Nullable();
            }
        }

        if (Schema.Table(nameof(LearnApi)).Exists())
        {
            if (!Schema.Table(nameof(LearnApi)).Column(nameof(LearnApi.LearnApiMappingArchive)).Exists())
            {
                Alter.Table(nameof(LearnApi))
                    .AddColumn(nameof(LearnApi.LearnApiMappingArchive)).AsString(int.MaxValue).Nullable();
            }
            if (!Schema.Table(nameof(LearnApi)).Column(nameof(LearnApi.LearnApiMappingResponse)).Exists())
            {
                Alter.Table(nameof(LearnApi))
                    .AddColumn(nameof(LearnApi.LearnApiMappingResponse)).AsString(int.MaxValue).Nullable();
            }
        }
    }
}