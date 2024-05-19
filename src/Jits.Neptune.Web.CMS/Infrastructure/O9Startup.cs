using Jits.Neptune.Web.CMS.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AccountingService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService.Interface;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CashService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Workflow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService.Interface;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.MortgageService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.Admin;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CreditService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.CustomerService;
using Jits.Neptune.Web.CMS.Services.CreditService;
using Jits.Neptune.Web.CMS.Services.DepositService.Interface;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService.Interfaces;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services.AdministratorService;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;

namespace Jits.Neptune.Web.CMS.Infrastructure;

/// <summary>
/// Represents the registering services on application startup
/// </summary>
public static class O9Startup
{
    /// <summary>
    /// Add and configure any of the middleware
    /// </summary>
    /// <param name="services">Collection of service descriptors</param>
    /// <param name="configuration">Configuration of the application</param>
    public static void ConfigureServicesO9(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddSingleton<Singleton<ConfigureWorkflow>>();
        if (GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            services.AddScoped<IO9ClientService, O9ClientService>();
            services.AddScoped<IBaseWorkflowService, BaseWorkflowService>();
            services.AddScoped<IMappingService, MappingService>();
            services.AddScoped<IApiService, ApiService>();
            // AdminService
            #region Admin
            services.AddScoped<IAdminServices, AdminService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IBranchProfileService, BranchProfileService>();
            services.AddScoped<IDepartmentProfileService, DepartmentProfileService>();
            services.AddScoped<IUserPolicyService, UserPolicyService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICodeListService, CodeListService>();
            services.AddScoped<IWorkflowDefinitionService, WorkflowDefinitionService>();

            services.AddScoped<IUserAccountWorkflowService, UserAccountWorkflowService>();
            services.AddScoped<IBranchProfileWorkflowService, BranchProfileWorkflowService>();
            services.AddScoped<IDepartmentProfileWorkflowService, DepartmentProfileWorkflowService>();
            services.AddScoped<IUserPolicyWorkflowService, UserPolicyWorkflowService>();
            services.AddScoped<ICountryWorkflowService, CountryWorkflowService>();
            services.AddScoped<ICurrencyWorkflowService, CurrencyWorkflowService>();
            services.AddScoped<ICodeListWorkflowService, CodeListWorkflowService>();
            services.AddScoped<IBankWorkflowService, BankWorkflowService>();
            services.AddScoped<IExchangeRateWorkflowService, ExchangeRateWorkflowService>();
            services.AddScoped<ITransactionJournalWorkflowService, TransactionJournalWorkflowService>();
            #endregion

            // AccountingService
            #region Accounting
            services.AddScoped<IActBankAccountService, ActBankAccountService>();
            services.AddScoped<IActAccountMapTableService, ActAccountMapTableService>();
            services.AddScoped<IActAccountLinkageService, ActAccountLinkageService>();
            services.AddScoped<IActGroupService, ActGroupService>();
            services.AddScoped<IActModuleAccountListService, ActModuleAccountListService>();
            services.AddScoped<IActAccountOfGroupService, ActAccountOfGroupService>();
            services.AddScoped<IActAccountOfGroupMappingService, ActAccountOfGroupMappingService>();
            services.AddScoped<IActCommonAccountService, ActCommonAccountService>();
            services.AddScoped<IActClearAccountService, ActClearAccountService>();
            services.AddScoped<IActForeignExchangeAccountService, ActForeignExchangeAccountService>();
            services.AddScoped<IActFixedAssetAndToolService, ActFixedAssetAndToolService>();
            services.AddScoped<IActFixedAssetCatalogueService, ActFixedAssetCatalogueService>();
            services.AddScoped<IActCommonAccountMappingService, ActCommonAccountMappingService>();

            services.AddScoped<IActClearAccountWorkflowService, ActClearAccountWorkflowService>();
            services.AddScoped<IActBankAccountWorkflowService, ActBankAccountWorkflowService>();
            services.AddScoped<IActAccountMapTableWorkflowService, ActAccountMapTableWorkflowService>();
            services.AddScoped<IActGroupWorkflowService, ActGroupWorkflowService>();
            services.AddScoped<IActModuleAccountListWorkflowService, ActModuleAccountListWorkflowService>();
            services.AddScoped<IActAccountOfGroupWorkflowService, ActAccountOfGroupWorkflowService>();
            services.AddScoped<IActCommonAccountWorkflowService, ActCommonAccountWorkflowService>();
            services.AddScoped<IActForeignExchangeAccountWorkflowService, ActForeignExchangeAccountWorkflowService>();
            services.AddScoped<IActFixedAssetAndToolWorkflowService, ActFixedAssetAndToolWorkflowService>();
            services.AddScoped<IActFixedAssetCatalogueWorkflowService, ActFixedAssetCatalogueWorkflowService>();

            #endregion

            // CustomerService
            #region Customer
            services.AddScoped<ICustomerProfileService, CustomerProfileService>();
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();
            services.AddScoped<ICustomerLinkageService, CustomerLinkageService>();
            services.AddScoped<ICustomerMediaService, CustomerMediaService>();

            services.AddScoped<ICustomerWorkflowService, CustomerWorkflowService>();
            services.AddScoped<ICustomerLinkageWorkflowService, CustomerLinkageWorkflowService>();
            services.AddScoped<ICustomerGroupWorkflowService, CustomerGroupWorkflowService>();
            services.AddScoped<ICustomerMediaWorkflowService, CustomerMediaWorkflowService>();
            #endregion

            // CreditService
            #region Credit
            services.AddScoped<ICreditCatalogService, CreditCatalogService>();
            services.AddScoped<ICreditAccountService, CreditAccountService>();
            services.AddScoped<ICreditIFCService, CreditIFCService>();

            services.AddScoped<ICreditCatalogWorkflowService, CreditCatalogWorkflowService>();
            services.AddScoped<ICreditIfcWorkflowService, CreditIfcWorkflowService>();
            services.AddScoped<ICreditAccountWorkflowService, CreditAccountWorkflowService>();
            services.AddScoped<CreditFoWorklowSerivce, CreditFoWorklowSerivce>();

            #endregion

            //MortgageService
            #region Mortgage
            services.AddScoped<IMortgageAccountInformationService, MortgageAccountInformationService>();
            services.AddScoped<IMortgageCatalogueDefinitionService, MortgageCatalogueDefinitionService>();

            services.AddScoped<IMortgageCatalogueDefinitionWorkflowService, MortgageCatalogueDefinitionWorkflowService>();
            services.AddScoped<IMortgageAccountInformationWorkflowService, MortgageAccountInformationWorkflowService>();
            #endregion

            // DepositService
            #region Deposit
            services.AddScoped<IDepositCatalogService, DepositCatalogService>();
            services.AddScoped<IDepositRuleFuncService, DepositRuleFuncService>();

            services.AddScoped<IDepositWorkflowService, DepositWorkflowService>();
            #endregion

            // CashService
            #region Cash
            services.AddScoped<ICashFlowService, CashFlowService>();

            #endregion

            // FxService
            #region FX

            #endregion
        }

    }
}
