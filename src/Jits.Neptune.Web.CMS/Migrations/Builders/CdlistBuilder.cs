using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class CdlistBuilder : NeptuneEntityBuilder<Cdlist>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(Cdlist.Cdgrp)).AsString(7)
        .WithColumn(nameof(Cdlist.Cdname)).AsString(70)
        .WithColumn(nameof(Cdlist.Cdid)).AsString(70).Nullable()
        .WithColumn(nameof(Cdlist.Caption)).AsString(700).Nullable()
        .WithColumn(nameof(Cdlist.Cdval)).AsString(700).Nullable()
        .WithColumn(nameof(Cdlist.Cdidx)).AsInt32()
        .WithColumn(nameof(Cdlist.Ftag)).AsString(70).Nullable()
        .WithColumn(nameof(Cdlist.Visible)).AsInt16()
        .WithColumn(nameof(Cdlist.Mcaption)).AsString(700).Nullable()
        .WithColumn(nameof(Cdlist.App)).AsString(70).Nullable();


    }
}