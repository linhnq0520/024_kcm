using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class WorkflowDefinitionBuilder : NeptuneEntityBuilder<WorkflowDefinition>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(WorkflowDefinition.WorkflowId)).AsString(50).NotNullable()
            .WithColumn(nameof(WorkflowDefinition.WorkflowFunc)).AsString(50).Nullable()
            .WithColumn(nameof(WorkflowDefinition.TableName)).AsString(50).Nullable()
            .WithColumn(nameof(WorkflowDefinition.IdFieldName)).AsString(50).Nullable()
            .WithColumn(nameof(WorkflowDefinition.FullInterfaceName)).AsString(500).Nullable()
            .WithColumn(nameof(WorkflowDefinition.MethodName)).AsString(50).Nullable()
            .WithColumn(nameof(WorkflowDefinition.Status)).AsInt16().Nullable()
            .WithColumn(nameof(WorkflowDefinition.MappingRequest)).AsString(int.MaxValue).Nullable()
            .WithColumn(nameof(WorkflowDefinition.MappingResponse)).AsString(int.MaxValue).Nullable()
            .WithColumn(nameof(WorkflowDefinition.IsCommonProcess)).AsInt16().Nullable()
            ;

    }
}