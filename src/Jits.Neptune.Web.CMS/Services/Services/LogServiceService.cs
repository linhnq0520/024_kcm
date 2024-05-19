using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Domain;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Jits.Neptune.Web.Framework.Services.Localization;
using JITS.Neptune.NeptuneClient;
using JITS.NeptuneClient.Scheme.Workflow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// LogService service
/// </summary>
public partial class LogServiceService : ILogServiceService
{


    private readonly ILocalizationService _localizationService;

    private readonly IRepository<LogService> _LogServiceRepository;

    #region Ctor   
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="localizationService"></param>
    /// <param name="LogServiceRepository"></param>

    public LogServiceService(ILocalizationService localizationService,
        IRepository<LogService> LogServiceRepository)
    {
        _localizationService = localizationService;
        _LogServiceRepository = LogServiceRepository;
    }

    #endregion
    /// <summary>
    /// Gets GetById
    /// </summary>
    /// <returns>Task&lt;LogService&gt;.</returns>
    public virtual async Task<LogService> GetById(int id)
    {
        return await _LogServiceRepository.GetById(id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logService"></param>
    /// <returns></returns>
    public virtual LogServiceModel ToLogServiceModel(LogService logService)
    {
        var model_ = logService.ToModel<LogServiceModel>();
        model_.LogUtc = logService.LogUtc;
        model_.Date = Utils.Utils.ConvertFromUnixTimestamp(logService.LogUtc).ToShortDateString();
        model_.Time = Utils.Utils.ConvertFromUnixTimestamp(logService.LogUtc).ToString("hh:mm:ss.fffffff");
        return model_;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="centralizedLog"></param>
    /// <returns></returns>
    public virtual async Task WriteCentralizedLog(JITS.Neptune.NeptuneClient.Log.CentralizedLog centralizedLog)
    {

        await _LogServiceRepository.Insert(new LogService()
        {
            LogUtc = centralizedLog.log_utc,
            ExecutionId = centralizedLog.execution_id,
            ServiceId = centralizedLog.service_id,
            StepCode = centralizedLog.step_code,
            StepExecutionId = centralizedLog.step_execution_id,
            Subject = centralizedLog.subject,
            LogText = centralizedLog.log_text,
            JsonDetails = centralizedLog.json_details,
            LogType = centralizedLog.log_type,
        });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<List<LogServiceModel>> GetAll()
    {
        return await _LogServiceRepository.Table.OrderByDescending(d => d.LogUtc).Select(s => ToLogServiceModel(s)).ToListAsync();
    }


    /// <summary>
    /// Gets SearchByApp
    /// </summary>
    /// <returns>Task&lt;LogService&gt;.</returns>
    public virtual async Task WriteLog(string subject, string logText, string details, string logType)
    {
        await Task.CompletedTask;
        var workflow = new JITS.NeptuneClient.Scheme.Workflow.WorkflowScheme();
        // JITS.NeptuneClient.Scheme.Workflow.WorkflowScheme.CentralizedLogType logType_;
        // Enum.TryParse(logType, true, out logType_);
        // var theCentralizedLog = workflow.CreateCentralizedLog(subject, logText, details, logType_);
        var theCentralizedLog = workflow.CreateCentralizedLog(subject, logText);

        await WriteCentralizedLog(theCentralizedLog);
    }

    /// <summary>
    ///Insert
    /// </summary>
    /// <returns>Task&lt;LogService&gt;.</returns>
    public virtual async Task Insert(LogService logService)
    {
        await _LogServiceRepository.Insert(logService);
    }
    /// <summary>
    ///Update
    /// </summary>
    /// <returns>Task&lt;LogService&gt;.</returns>
    public virtual async Task<LogService> Update(LogService LogService)
    {
        await Task.CompletedTask;
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual void DeleteAll()
    {
        _LogServiceRepository.Truncate();
    }

}
