using System.Collections.Generic;
using System.Linq;
using Jits.Neptune.Core.Domain.Configuration;
using Jits.Neptune.Web.Admin.Models;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper;
using Jits.Neptune.Web.Framework.Models;
using JITS.Neptune.NeptuneClient.Events.EventData;
using JITS.Neptune.NeptuneClient.Workflow;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Infrastructure.Mapper
{
    /// <summary>
    /// Framework mapper configuration
    /// </summary>
    public partial class CMSMapperConfiguration : BaseMapperConfiguration
    {
        /// <summary>
        /// Framework mapper configuration constructor
        /// </summary>
        public CMSMapperConfiguration()
        {
            CreateMap<Bo, BoModel>()
                .ForMember(des => des.Input, src => src.Ignore())
                .ForMember(des => des.Actions, src => src.Ignore())
                .ForMember(des => des.Response, src => src.Ignore());
            CreateMap<Fo, FoModel>()
                .ForMember(des => des.Input, src => src.Ignore())
                .ForMember(des => des.Actions, src => src.Ignore())
                .ForMember(des => des.Request, src => src.Ignore());
            CreateMap<Fo, FoCreateModel>()
                .ForMember(des => des.Input, src => src.Ignore())
                .ForMember(des => des.Actions, src => src.Ignore())
                .ForMember(des => des.Request, src => src.Ignore());

            CreateMap<App, AppModel>().ForMember(des => des.ConfigTemplate, src => src.Ignore());
            // CreateModelMap<Lang, LangModel>();
            CreateMap<Lang, LangModel>()
                .ForMember(des => des.LangData, src => src.Ignore());
            CreateModelMap<ParaServer, ParaServerModel>();
            CreateModelMap<AppOfRole, AppOfRoleModel>();

            CreateModelMap<FormOfRole, FormOfRoleModel>();
            CreateMap<Cdlist, CdlistModel>().ForMember(des => des.Mcaption, src => src.Ignore());
            CreateMap<Cdlist, CdlistResponseModel>()
                .ForMember(des => des.Mcaption, src => src.Ignore());

            CreateMap<LearnApi, LearnApiModel>();
            CreateMap<ShortcutConfig, ShortcutConfig>();
            CreateMap<FormShortcut, FormShortcut>();
            CreateMap<DesignGroup, DesignGroupModel>()
                .ForMember(des => des.Title, src => src.Ignore());
            CreateMap<DesignItem, DesignItemModel>()
                .ForMember(des => des.Title, src => src.Ignore())
                .ForMember(des => des.Template, src => src.Ignore());
            CreateMap<DesignTemplateForm, DesignTemplateFormModel>()
                .ForMember(des => des.TemplateId, src => src.Ignore())
                .ForMember(des => des.Template, src => src.Ignore());
            CreateModelMap<GroupMenu, GroupMenuModel>();
            CreateMap<GroupMenu, GroupMenuModel>()
                .ForMember(des => des.GroupMenuLang, src => src.Ignore());
            CreateMap<WorkflowExecutionInquiry, WorkflowExecutionDataEvent>();
            CreateModelMap<OrganizationParameter, OrganizationParameterModel>();
            CreateModelMap<LogService, LogServiceModel>();
            CreateModelMap<LogService, LogServiceSearchModel>();

            CreateModelMap<Setting, SettingSearchResponse>();
            CreateModelMap<ScheduleJob, ScheduleJobModel>();
            CreateModelMap<Cdlist, CodeListUpdateByPrimaryKey>();
            CreateModelMap<Cdlist, CodeListPrimaryKey>();
            CreateMap<Cdlist, CdlistUpdateModel>()
                .ForMember(des => des.Mcaption, src => src.Ignore());
            CreateMap<Cdlist, CdlistCreateModel>()
                .ForMember(des => des.Mcaption, src => src.Ignore());
            CreateModelMap<Cdlist, Admin.Models.CodeListSearchModel>();

            CreateMap<Dictionary<string, object>, UserAccountCreateModel>()
                .ForAllMembers(opts =>
                {
                    opts.MapFrom((src, dest, destMember, context) =>
                    {
                        var propertyName = opts.DestinationMember.Name;
                        var jsonProperty = opts.DestinationMember.GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault() as JsonPropertyAttribute;
                        if (jsonProperty != null)
                        {
                            propertyName = jsonProperty.PropertyName;
                        }

                        if (src.TryGetValue(propertyName, out object value))
                        {
                            return value;
                        }

                        return null;
                    });
                });
            CreateModelMap<UserAccountCreateModel, UserAccountCreateRequestModel>();    
        }
    }
}
