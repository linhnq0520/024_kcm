using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// DesignGroup Builder
/// </summary>
public partial class DesignTemplateFormBuilder : NeptuneEntityBuilder<DesignTemplateForm>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
        .WithColumn(nameof(DesignTemplateForm.TemplateId)).AsString(200).Nullable()
            .WithColumn(nameof(DesignTemplateForm.Template)).AsString(50000).Nullable()
            .WithColumn(nameof(DesignTemplateForm.Info)).AsString(50000).Nullable()
            .WithColumn(nameof(DesignTemplateForm.ListLayout)).AsString(50000).Nullable()
            .WithColumn(nameof(DesignTemplateForm.ReactTxt)).AsString(50000).Nullable();
    }
}