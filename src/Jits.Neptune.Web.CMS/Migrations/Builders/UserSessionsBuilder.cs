using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// TemplateVoucher Builder
/// </summary>
public partial class UserSessionsBuilder : NeptuneEntityBuilder<UserSessions>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(UserSessions.Token)).AsString(1500).Nullable()
            .WithColumn(nameof(UserSessions.UserCode)).AsString(50).Nullable()
            .WithColumn(nameof(UserSessions.UsrBranch)).AsString(50).Nullable()
            .WithColumn(nameof(UserSessions.Usrname)).AsString(100).Nullable()
            .WithColumn(nameof(UserSessions.Lang)).AsString(50).Nullable()
            .WithColumn(nameof(UserSessions.Ssesionid)).AsString(100).Nullable()
            .WithColumn(nameof(UserSessions.Wsip)).AsString(100).Nullable()
            .WithColumn(nameof(UserSessions.Mac)).AsString(100).Nullable()
            .WithColumn(nameof(UserSessions.Wsname)).AsString(500).Nullable()
            .WithColumn(nameof(UserSessions.Acttype)).AsString(5).Nullable()
            .WithColumn(nameof(UserSessions.ApplicationCode)).AsString(100).Nullable()
            .WithColumn(nameof(UserSessions.Info)).AsString(1500).Nullable()
            .WithColumn(nameof(UserSessions.CommandList)).AsString(1500).Nullable()
            .WithColumn(nameof(UserSessions.ResetPassword)).AsBoolean().Nullable();
    }
}