using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class ScheduleJobBuilder : NeptuneEntityBuilder<ScheduleJob>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(ScheduleJob.Name)).AsString(700)
        .WithColumn(nameof(ScheduleJob.Status)).AsString(70)
        .WithColumn(nameof(ScheduleJob.Type)).AsString(70)
        .WithColumn(nameof(ScheduleJob.Time)).AsInt64()
        .WithColumn(nameof(ScheduleJob.ContentRun)).AsString(2000)
        .WithColumn(nameof(ScheduleJob.ApplicationCode)).AsString(70);

    }
}