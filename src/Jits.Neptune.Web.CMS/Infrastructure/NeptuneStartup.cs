using System.Collections.Generic;
using System.Linq;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.GrpcServices;
using Jits.Neptune.Web.CMS.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService;
using Jits.Neptune.Web.CMS.Services.CreditService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;
using Jits.Neptune.Web.CMS.Services.DepositService.Interface;
using Jits.Neptune.Web.CMS.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Jits.Neptune.Web.Framework.Services.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService.Interface;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;

namespace Jits.Neptune.Web.CMS.Infrastructure;

/// <summary>
/// Represents the registering services on application startup
/// </summary>
public class NeptuneStartup : INeptuneStartup
{
    /// <summary>
    /// Add and configure any of the middleware
    /// </summary>
    /// <param name="services">Collection of service descriptors</param>
    /// <param name="configuration">Configuration of the application</param>


    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        if (!GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints =
                    {
                        Singleton<AppSettings>.Instance.Get<NeptuneConfiguration>().RedisEndpoint
                    },

                    //EndPoints = { "192.168.1.170:6379" }
                }
            );
            services.AddSingleton<IConnectionMultiplexer>(redis);

            Singleton<List<RedisKey>>.Instance = redis
                .GetServer(Singleton<AppSettings>.Instance.Get<NeptuneConfiguration>().RedisEndpoint)
                .Keys(pattern: "*")
                .ToList<RedisKey>();

            var dbRedis = redis.GetDatabase();
            // System.Console.WriteLine("_redisKeys===" + _redisKeys.ToString());
            foreach (var item in Singleton<List<RedisKey>>.Instance.Select(key => (string)key))
            {
                if (item.Contains(Constants.CMSInstanceIDString))
                {
                    dbRedis.KeyDelete(item);
                }
            }
        }
        else
        {
            Singleton<List<RedisKey>>.Instance = new List<RedisKey> { };
            services.AddSingleton<IConnectionMultiplexer, ConnectionMultiplexer>();
        }

        //services
        services.AddScoped<IWebchannelService, WebchannelService>();
        services.AddScoped<IBoService, BoService>();
        services.AddScoped<IFoService, FoService>();
        services.AddScoped<IAppService, AppService>();
        services.AddScoped<ILangService, LangService>();
        services.AddScoped<IParaServerService, ParaServerService>();
        services.AddScoped<IPostAPIService, PostAPIService>();
        services.AddScoped<IAppOfRoleService, AppOfRoleService>();
        services.AddScoped<IFormOfRoleService, FormOfRoleService>();
        services.AddScoped<IFormService, FormService>();
        services.AddScoped<ILearnApiService, LearnApiService>();
        services.AddScoped<IMediaUploadService, MediaUploadService>();

        services.AddScoped<IWebSocketsService, WebSocketsService>();
        services.AddScoped<IGroupMenuService, GroupMenuService>();
        services.AddScoped<ICdlistService, CdlistService>();
        services.AddScoped<IDesignGroupService, DesignGroupService>();
        services.AddScoped<IDesignItemService, DesignItemService>();
        services.AddScoped<IDesignTemplateFormService, DesignTemplateFormService>();

        services.AddScoped<ITemplateVoucherService, TemplateVoucherService>();
        services.AddScoped<IShortcutConfigService, ShortcutConfigService>();
        services.AddScoped<IFormShortcutService, FormShortcutService>();
        services.AddScoped<IOrganizationParameterService, OrganizationParameterService>();
        services.AddScoped<ILogServiceService, LogServiceService>();
        services.AddScoped<ICMSSettingService, CMSSettingService>();
        services.AddScoped<IScheduleJobService, ScheduleJobService>();
        services.AddScoped<IO9PostService, O9PostService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();

        //Logic service
        //grpc
        services.AddScoped<IAdminGrpcService, AdminGrpcService>();
        services.AddScoped<IAuthenticationGrpcService, AuthenticationGrpcService>();
        services.AddScoped<IGrpcClientService, GrpcClientService>();
        services.AddScoped<IReportGrpcService, ReportGrpcService>();
        services.AddScoped<IUserSessionsService, UserSessionsService>();
        services.AddScoped<IUserCommandService, UserCommandService>();


        services.AddScoped<JWebUIObjectContextModel>();

        services.AddSingleton<ListExecuteModel>();
        services.AddSingleton<GrpcClientExecuteModel>();
        services.AddSingleton<ConnectionManager>();
        Singleton<ConnectionManager>.Instance = new ConnectionManager();

        // REMOVE CMSInstanceIDString REDIS KEYS WHEN RESTART

        //
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAnyCorsPolicy",
                policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
            );

        });

        var appVersion = configuration["AppVersion"];

        // if (appVersion.HasValue())
        // {
        //     var oldVersion = EngineContext.Current.Resolve<INeptuneDataProvider>().GetTable<Setting>().Where(s => s.Name == "CMSSetting.AppVersion");
        //     if (oldVersion != null)
        //         EngineContext.Current.Resolve<INeptuneDataProvider>().DeleteEntity(oldVersion);

        //     var newVersion = new Setting { Name = "CMSSetting.AppVersion", Value = appVersion };
        //     EngineContext.Current.Resolve<INeptuneDataProvider>().InsertEntity(newVersion);
        // }

        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            services.ConfigureServicesO9(configuration);

            services.AddSingleton<WorkflowStartup>();
        }

    }

    /// <summary>
    /// Configure the using of added middleware
    /// </summary>
    /// <param name="application">Builder for configuring an application's request pipeline</param>
    public void Configure(IApplicationBuilder application)
    {
        application.UseCors("AllowAnyCorsPolicy");
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var serviceProvider = application.ApplicationServices;
            var workflowStartup = serviceProvider.GetService<WorkflowStartup>();
            workflowStartup.InitializeWorkflowInstances();
        }
    }


    /// <summary>
    /// Gets order of this dependency registrar implementation
    /// </summary>
    public int Order => 2000;
}
