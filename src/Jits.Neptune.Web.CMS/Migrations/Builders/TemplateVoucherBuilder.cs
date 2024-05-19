using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// TemplateVoucher Builder
/// </summary>
public partial class TemplateVoucherBuilder : NeptuneEntityBuilder<TemplateVoucher>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(TemplateVoucher.Code)).AsString(200).Nullable()
            .WithColumn(nameof(TemplateVoucher.Status)).AsString(200).Nullable()
            // .WithColumn(nameof(TemplateVoucher.HtmlCode)).AsString(int.MaxValue).Nullable()
            .WithColumn(nameof(TemplateVoucher.App)).AsString(500).Nullable();
    }
}