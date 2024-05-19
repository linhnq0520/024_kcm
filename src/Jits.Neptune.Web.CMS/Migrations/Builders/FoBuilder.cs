using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class FoBuilder : NeptuneEntityBuilder<Fo>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(Fo.Input)).AsString(200).Nullable()
            // .WithColumn(nameof(Fo.Actions)).AsString(20000).Nullable()
            .WithColumn(nameof(Fo.Request)).AsString(500).Nullable()
            .WithColumn(nameof(Fo.Txcode)).AsString(50).Nullable()
            .WithColumn(nameof(Fo.Txname)).AsString(100).Nullable()
            .WithColumn(nameof(Fo.Txtype)).AsString(50).Nullable()
            .WithColumn(nameof(Fo.Updatetime)).AsInt64().Nullable()
            .WithColumn(nameof(Fo.Status)).AsString(50).Nullable()
            .WithColumn(nameof(Fo.DisplayOrder)).AsInt32().Nullable()
            .WithColumn(nameof(Fo.Isold)).AsBoolean().Nullable()
            .WithColumn(nameof(Fo.Version)).AsInt32().Nullable()
            .WithColumn(nameof(Fo.App)).AsString(50).Nullable();


    }
}