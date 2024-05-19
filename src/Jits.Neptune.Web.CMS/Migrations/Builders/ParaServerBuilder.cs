using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;
using LinqToDB.Mapping;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class ParaServerBuilder : NeptuneEntityBuilder<ParaServer>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(ParaServer.Code)).AsString(70)
        .WithColumn(nameof(ParaServer.Des)).AsString(70)
        .WithColumn(nameof(ParaServer.Data_Type)).AsString(7)
        .WithColumn(nameof(ParaServer.Isadmin)).AsBoolean()
        .WithColumn(nameof(ParaServer.Value)).AsAnsiString(int.MaxValue)
        .WithColumn(nameof(ParaServer.App)).AsString(70);
    }
}