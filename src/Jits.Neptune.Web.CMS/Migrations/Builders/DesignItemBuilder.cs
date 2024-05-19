using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// DesignGroup Builder
/// </summary>
public partial class DesignItemBuilder : NeptuneEntityBuilder<DesignItem>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(DesignItem.GroupId)).AsString(200).Nullable()
            .WithColumn(nameof(DesignItem.isActive)).AsBoolean().Nullable()
            .WithColumn(nameof(DesignItem.Title)).AsString(2000).Nullable()
            .WithColumn(nameof(DesignItem.DisplayOrder)).AsString(500).Nullable()
            .WithColumn(nameof(DesignItem.AttId)).AsString(200).Nullable()
            .WithColumn(nameof(DesignItem.Img)).AsString(200).Nullable()
            .WithColumn(nameof(DesignItem.KeyNew)).AsString(2000).Nullable()
            // .WithColumn(nameof(DesignItem.Template)).AsString(50000).Nullable()
            .WithColumn(nameof(DesignItem.Type)).AsString(500).Nullable();
    }
}