using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// DesignGroup Builder
/// </summary>
public partial class DesignGroupBuilder : NeptuneEntityBuilder<DesignGroup>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    // <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(DesignGroup.GroupId)).AsString(200).Nullable()
            .WithColumn(nameof(DesignGroup.isActive)).AsBoolean().Nullable()
            .WithColumn(nameof(DesignGroup.Title)).AsString(2000).Nullable()
            .WithColumn(nameof(DesignGroup.DisplayOrder)).AsString(500).Nullable();
    }
}