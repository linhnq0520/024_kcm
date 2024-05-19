using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class FormBuilder : NeptuneEntityBuilder<Form>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
        // .WithColumn(nameof(Form.Info)).AsString(40000).Nullable()
        // .WithColumn(nameof(Form.ListLayout)).AsString(400000).Nullable()
        .WithColumn(nameof(Form.ReactTxt)).AsString(70).Nullable()
        .WithColumn(nameof(Form.App)).AsString(70).Nullable()
        .WithColumn(nameof(Form.FormId)).AsString(100).Nullable();


    }
}