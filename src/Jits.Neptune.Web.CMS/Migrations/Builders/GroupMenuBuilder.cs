using FluentMigrator.Builders.Create.Table;
using Jits.Neptune.Data.Mapping.Builders;
using Jits.Neptune.Web.CMS.Domain;

namespace Jits.Neptune.Web.CMS.Migrations.Builders;

/// <summary>
/// User Account Builder
/// </summary>
public partial class GroupMenuBuilder : NeptuneEntityBuilder<GroupMenu>
{
    /// <summary>
    /// MapEntity
    /// </summary>
    /// <param name="table">The table.</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        // table
        // .WithColumn(nameof(GroupMenu.GroupMenuLang)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuName)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuOrder)).AsInt32().Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuIcon)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuParent)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuStatus)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuFunctionCode)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuVisible)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuId)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuModuleForm)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.GroupMenuListAuthorizeForm)).AsString(700).Nullable()
        // .WithColumn(nameof(GroupMenu.App)).AsString(700).Nullable();


    }
}