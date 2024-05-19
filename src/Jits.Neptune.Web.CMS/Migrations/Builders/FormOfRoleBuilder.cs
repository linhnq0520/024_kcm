using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class FormOfRoleBuilder : NeptuneEntityBuilder<FormOfRole>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        // table.WithColumn(nameof(FormOfRole.RoleId)).AsInt32().Nullable()
        // .WithColumn(nameof(FormOfRole.Form)).AsString(500).Nullable()
        // .WithColumn(nameof(FormOfRole.AccessForm)).AsBoolean().Nullable()
        // .WithColumn(nameof(FormOfRole.App)).AsString(500).Nullable();



    }
}