using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class LearnApiBuilder : NeptuneEntityBuilder<LearnApi>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {

        table.WithColumn(nameof(LearnApi.LearnApiId)).AsString(700)
        .WithColumn(nameof(LearnApi.LearnApiName)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiLink)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiData)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiNodeData)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiApp)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiMethod)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.FlowApi)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.SaveTo)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiHeader)).AsString(7000).Nullable()
        // .WithColumn(nameof(LearnApi.LearnApiMapping)).AsString(70000).Nullable()
        .WithColumn(nameof(LearnApi.NumberOfSteps)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.LearnApiGetInfo)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.KeyReadData)).AsString(700).Nullable()

        .WithColumn(nameof(LearnApi.JwebuiUsercreate)).AsString(700).Nullable()
        .WithColumn(nameof(LearnApi.App)).AsString(70)
        .WithColumn(nameof(LearnApi.LearnApiMappingArchive)).AsString(int.MaxValue)
        .WithColumn(nameof(LearnApi.LearnApiMappingResponse)).AsString(int.MaxValue);

    }
}