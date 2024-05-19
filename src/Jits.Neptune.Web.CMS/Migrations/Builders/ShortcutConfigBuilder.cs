using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// ShortcutConfig Builder
/// </summary>
public partial class ShortcutConfigBuilder : NeptuneEntityBuilder<ShortcutConfig>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(ShortcutConfig.Name))
            .AsString(200)
            .Nullable()
            .WithColumn(nameof(ShortcutConfig.ShortcutId))
            .AsString(200)
            .WithColumn(nameof(ShortcutConfig.Keystrokes))
            .AsString(200)
            .WithColumn(nameof(ShortcutConfig.UserId))
            .AsString(200)
            .Nullable()
            .WithColumn(nameof(ShortcutConfig.FormCode))
            .AsString(200)
            .Nullable()
            .WithColumn(nameof(ShortcutConfig.App))
            .AsString(500)
            .Nullable();
    }
}
