using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class AppOfRoleBuilder : NeptuneEntityBuilder<AppOfRole>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(AppOfRole.RoleId)).AsInt32()
        .WithColumn(nameof(AppOfRole.App)).AsString(200);



    }
}