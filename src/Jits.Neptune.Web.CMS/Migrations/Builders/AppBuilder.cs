using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class AppBuilder : NeptuneEntityBuilder<App>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(App.ListApplicationId)).AsString(20).NotNullable()
            .WithColumn(nameof(App.ListApplicationName)).AsString(70).NotNullable()
            .WithColumn(nameof(App.ListApplicationDes)).AsString(50).NotNullable()
            .WithColumn(nameof(App.ListApplicationImg)).AsString(int.MaxValue).NotNullable()
            .WithColumn(nameof(App.ListApplicationBo)).AsString(50).NotNullable()
            .WithColumn(nameof(App.ListApplicationBoLogout)).AsString(50).Nullable()
            .WithColumn(nameof(App.ListApplicationBoLogoutAll)).AsString(50).Nullable()
            .WithColumn(nameof(App.ConnectOtherSystemStatus)).AsString(50).Nullable()
            .WithColumn(nameof(App.ListApplicationOrder)).AsString(50).NotNullable()
            .WithColumn(nameof(App.ConfigTemplate)).AsString(2000).NotNullable()
            .WithColumn(nameof(App.status)).AsString(20).Nullable();


    }
}