using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// FormShortcut Builder
/// </summary>
public partial class FormShortcutBuilder : NeptuneEntityBuilder<FormShortcut>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(FormShortcut.FormName))
            .AsString(200)
            .Nullable()
            .WithColumn(nameof(FormShortcut.FormId))
            .AsString(200)
            .WithColumn(nameof(FormShortcut.GroupCode))
            .AsString(200)
            .Nullable()
            .WithColumn(nameof(FormShortcut.App))
            .AsString(500)
            .Nullable();
    }
}
