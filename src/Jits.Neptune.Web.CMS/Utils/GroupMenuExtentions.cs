using System;
using System.Collections.Generic;
using System.Linq;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// String extens
    /// </summary>
    public static class GroupMenuExtentions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns></returns>
        public static GroupMenuModel ToGroupMenuModel(this UserCommand userCommand)
        {
            var commandNameLanguage = new Dictionary<string, string>();
            try
            {
                if (!string.IsNullOrEmpty(userCommand.CommandNameLanguage))
                    commandNameLanguage = JsonConvert.DeserializeObject<Dictionary<string, string>>(userCommand.CommandNameLanguage);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
                System.Console.WriteLine("userCommand??????????" + userCommand.ToSerialize());
                commandNameLanguage = new Dictionary<string, string>();
            }

            return new GroupMenuModel()
            {
                App = userCommand.ApplicationCode,
                GroupMenuFunctionCode = userCommand.GroupMenuId,
                GroupMenuIcon = userCommand.GroupMenuIcon,
                GroupMenuId = userCommand.CommandId,
                GroupMenuLang = commandNameLanguage,
                GroupMenuListAuthorizeForm = userCommand.GroupMenuListAuthorizeForm,
                GroupMenuModuleForm = userCommand.CommandId,
                GroupMenuName = userCommand.CommandName,
                GroupMenuOrder = userCommand.DisplayOrder,
                GroupMenuParent = userCommand.ParentId,
                GroupMenuStatus = userCommand.Enabled ? "A" : "I",
                GroupMenuVisible = userCommand.GroupMenuVisible
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns></returns>
        public static GroupMenuModel ToGroupMenuModel(this UserCommands userCommand)
        {
            var commandNameLanguage = new Dictionary<string, string>();
            try
            {
                if (!string.IsNullOrEmpty(userCommand.CommandNameLanguage))
                    commandNameLanguage = JsonConvert.DeserializeObject<Dictionary<string, string>>(userCommand.CommandNameLanguage);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
                System.Console.WriteLine("userCommand??????????" + userCommand.ToSerialize());
                commandNameLanguage = new Dictionary<string, string>();
            }

            return new GroupMenuModel()
            {
                App = userCommand.ApplicationCode,
                GroupMenuFunctionCode = userCommand.GroupMenuId,
                GroupMenuIcon = userCommand.GroupMenuIcon,
                GroupMenuId = userCommand.CommandId,
                GroupMenuLang = commandNameLanguage,
                GroupMenuListAuthorizeForm = userCommand.GroupMenuListAuthorizeForm,
                GroupMenuModuleForm = userCommand.CommandId,
                GroupMenuName = userCommand.CommandName,
                GroupMenuOrder = userCommand.DisplayOrder,
                GroupMenuParent = userCommand.ParentId,
                GroupMenuStatus = userCommand.Enabled ? "A" : "I",
                GroupMenuVisible = userCommand.GroupMenuVisible
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSearch"></param>
        /// <returns></returns>

        public static GroupMenu ToGroupMenuEntity(this JToken pageSearch)
        {
            var id = pageSearch["id"]?.ToString();
            System.Console.WriteLine("id" + id);
            if (!string.IsNullOrEmpty(id))
                return new GroupMenu()
                {
                    Id = int.Parse(id),
                    GroupMenuLang = pageSearch["group_menu_lang"]?.ToString(),
                    GroupMenuName = pageSearch["group_menu_name"]?.ToString(),
                    App = pageSearch["app"]?.ToString(),
                    GroupMenuOrder = int.Parse(pageSearch["group_menu_order"]?.ToString()),
                    GroupMenuIcon = pageSearch["group_menu_icon"]?.ToString(),
                    GroupMenuParent = pageSearch["group_menu_parent"]?.ToString(),
                    GroupMenuStatus = pageSearch["group_menu_status"]?.ToString(),
                    GroupMenuFunctionCode = pageSearch["group_menu_function_code"]?.ToString(),
                    GroupMenuVisible = pageSearch["group_menu_visible"]?.ToString(),
                    GroupMenuId = pageSearch["group_menu_id"]?.ToString(),
                    GroupMenuModuleForm = pageSearch["group_menu_module_form"]?.ToString(),
                    GroupMenuListAuthorizeForm = pageSearch["group_menu_list_authorize_form"]?.ToString(),
                };
            else return new GroupMenu()
            {
                GroupMenuLang = pageSearch["group_menu_lang"]?.ToString(),
                GroupMenuName = pageSearch["group_menu_name"]?.ToString(),
                App = pageSearch["app"]?.ToString(),
                GroupMenuOrder = int.Parse(pageSearch["group_menu_order"]?.ToString()),
                GroupMenuIcon = pageSearch["group_menu_icon"]?.ToString(),
                GroupMenuParent = pageSearch["group_menu_parent"]?.ToString(),
                GroupMenuStatus = pageSearch["group_menu_status"]?.ToString(),
                GroupMenuFunctionCode = pageSearch["group_menu_function_code"]?.ToString(),
                GroupMenuVisible = pageSearch["group_menu_visible"]?.ToString(),
                GroupMenuId = pageSearch["group_menu_id"]?.ToString(),
                GroupMenuModuleForm = pageSearch["group_menu_module_form"]?.ToString(),
                GroupMenuListAuthorizeForm = pageSearch["group_menu_list_authorize_form"]?.ToString(),
            };
        }

    }
}

