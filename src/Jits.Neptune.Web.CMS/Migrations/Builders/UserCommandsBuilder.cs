using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// TemplateVoucher Builder
/// </summary>
public partial class UserCommandsBuilder : NeptuneEntityBuilder<UserCommands>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(UserCommands.ApplicationCode)).AsString(100).Nullable()
            .WithColumn(nameof(UserCommands.CommandId)).AsString(100).Nullable()
            .WithColumn(nameof(UserCommands.ParentId)).AsString(100).Nullable()
            .WithColumn(nameof(UserCommands.CommandName)).AsString(200).Nullable()
            .WithColumn(nameof(UserCommands.CommandNameLanguage)).AsString(500).Nullable()
            .WithColumn(nameof(UserCommands.CommandType)).AsString(1).Nullable()
            .WithColumn(nameof(UserCommands.Enabled)).AsBoolean().Nullable()
            .WithColumn(nameof(UserCommands.DisplayOrder)).AsInt16().Nullable()
            .WithColumn(nameof(UserCommands.GroupMenuIcon)).AsString(100).Nullable()
            .WithColumn(nameof(UserCommands.GroupMenuVisible)).AsString(2).Nullable()
            .WithColumn(nameof(UserCommands.GroupMenuId)).AsString(100).Nullable()
            .WithColumn(nameof(UserCommands.GroupMenuListAuthorizeForm)).AsString(500).Nullable();
    }
}