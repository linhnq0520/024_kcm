using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class BoBuilder : NeptuneEntityBuilder<Bo>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(Bo.Input)).AsString(2000).Nullable()
            // .WithColumn(nameof(Bo.Actions)).AsString(int.MaxValue).Nullable()
            .WithColumn(nameof(Bo.Response)).AsString(2000).Nullable()
            .WithColumn(nameof(Bo.Txcode)).AsString(500).Nullable()
            .WithColumn(nameof(Bo.Txname)).AsString(500).Nullable()
            .WithColumn(nameof(Bo.Txtype)).AsString(500).Nullable()
            .WithColumn(nameof(Bo.Updatetime)).AsInt64().Nullable()
            .WithColumn(nameof(Bo.Hasrole)).AsString(500).Nullable()
            .WithColumn(nameof(Bo.Status)).AsString(500).Nullable()
            .WithColumn(nameof(Bo.DisplayOrder)).AsInt32().Nullable()
            .WithColumn(nameof(Bo.Isold)).AsBoolean().Nullable()
            .WithColumn(nameof(Bo.Version)).AsInt32().Nullable()
            .WithColumn(nameof(Bo.App)).AsString(50).Nullable();
    }
}