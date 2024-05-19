using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Models.Neptune;
using Jits.Neptune.Web.Framework.Services;
using Newtonsoft.Json.Linq;
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;

namespace Jits.Neptune.Web.CMS.Infrastructure;

/// <summary>
/// Represents the registering services on application startup
/// </summary>
public class WorkflowStartup
{
    /// <summary>
    /// The workflow repo
    /// </summary>
    private readonly IRepository<WorkflowDefinition> _workflowRepo;
    /// <summary>
    /// The service provider
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the WorkflowStartup class.
    /// </summary>
    /// <param name="workflowRepo">The workflow repository.</param>
    /// <param name="serviceProvider">The service provider.</param>
    public WorkflowStartup(IRepository<WorkflowDefinition> workflowRepo, IServiceProvider serviceProvider)
    {
        _workflowRepo = workflowRepo;
        _serviceProvider = serviceProvider;

        if (Singleton<ConfigureWorkflow>.Instance == null)
            Singleton<ConfigureWorkflow>.Instance = new ConfigureWorkflow();

    }

    /// <summary>
    /// Represents the configuration for workflows.
    /// </summary>
    public class ConfigureWorkflow
    {
        /// <summary>
        /// Gets or sets the dictionary of workflow functions.
        /// </summary>
        //public Dictionary<string, Func<WorkflowExecuteModel, Task<JToken>>> Workflows { get; } = new Dictionary<string, Func<WorkflowExecuteModel, Task<JToken>>>();
        public Dictionary<string, WorkflowInfo> Workflows { get; } = new Dictionary<string, WorkflowInfo>();
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Func<WorkflowExecuteModel, Task<JToken>> InvokeWorkflow { get; set; } = null;
        
        /// <summary>
        /// 
        /// </summary>
        public int IsCommonProcess { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public string MappingRequest { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public string MappingResponse { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public BoInfo BoInfo { get; set; } = null;
    }

    /// <summary>
    /// 
    /// </summary>
    public class BoInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorkflowFunc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IdFieldName { get; set; }

    }

    /// <summary>
    /// Creates workflow instances.
    /// </summary>
    public void InitializeWorkflowInstances()
    {
        if (_workflowRepo == null) return;
        
        var workflows = _workflowRepo.Table.Where(s => s.Status == Constants.WorkflowStatus.Active);
        foreach (var item in workflows)
        {
            try
            {
                CreateWorkflowInstance(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to resolve Workflow {item.WorkflowId} with message: " + ex.Message);
            }
        }
    }

    /// <summary>
    /// Tries to get the workflow instance.
    /// </summary>
    /// <param name="workflowId">The ID of the workflow to retrieve.</param>
    /// <returns>A function that represents the workflow instance.</returns>
    public WorkflowInfo TryGetWorkflow(string workflowId)
    {
        if (_workflowRepo == null || Singleton<ConfigureWorkflow>.Instance == null)
            return null;

        var workflow = _workflowRepo.Table.FirstOrDefault(s => s.Status == Constants.WorkflowStatus.Active && s.WorkflowId == workflowId);
        if (workflow == null)
            return null;

        WorkflowInfo workflowInfo = CreateWorkflowInstance(workflow);
        
        return workflowInfo;
    }

    private WorkflowInfo CreateWorkflowInstance(WorkflowDefinition workflowDefinition)
    {
        var interfaceType = Type.GetType(workflowDefinition.FullInterfaceName);
        if (interfaceType == null)
            return null;

        var handler = _serviceProvider.GetService(interfaceType);
        if (handler == null)
            return null;

        var methodInfo = handler.GetType().GetMethod(workflowDefinition.MethodName);
        if (methodInfo == null || !interfaceType.IsAssignableFrom(handler.GetType()))
            return null;

        var instance = new WorkflowInfo()
        {
            MappingRequest = workflowDefinition.MappingRequest,
            MappingResponse = workflowDefinition.MappingResponse,
            BoInfo = new BoInfo()
            {
                TableName = workflowDefinition.TableName,
                IdFieldName = workflowDefinition.IdFieldName,
                WorkflowFunc = workflowDefinition.WorkflowFunc
            },
            IsCommonProcess = workflowDefinition.IsCommonProcess,
            InvokeWorkflow = async (model) => await (Task<JToken>)methodInfo.Invoke(handler, new object[] { model })
        };
        Singleton<ConfigureWorkflow>.Instance.Workflows.Add(workflowDefinition.WorkflowId, instance);

        return instance;
    }

}
