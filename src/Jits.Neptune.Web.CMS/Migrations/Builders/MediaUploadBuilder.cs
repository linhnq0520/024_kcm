using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class MediaUploadBuilder : NeptuneEntityBuilder<MediaUpload>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
        // .WithColumn(nameof(MediaUpload.MediaData)).AsString(int.MaxValue).Nullable()
        .WithColumn(nameof(MediaUpload.MediaName)).AsString(700).Nullable()
        .WithColumn(nameof(MediaUpload.MediaType)).AsString(700).Nullable()
        .WithColumn(nameof(MediaUpload.Token)).AsString(700).Nullable()
        .WithColumn(nameof(MediaUpload.UserId)).AsInt64().Nullable();
    }
}