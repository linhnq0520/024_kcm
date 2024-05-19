using Jits.Neptune.Web.CMS.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static Jits.Neptune.Web.CMS.Infrastructure.WorkflowStartup;
using System.Threading.Tasks;
using Jits.Neptune.Web.CMS.Services;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.CMS.Utils;
using System;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;
/// <summary>
/// 
/// </summary>
public class MappingService: IMappingService
{
    private readonly IPostAPIService _postAPIService;
    /// <summary>
    /// 
    /// </summary>
    public JWebUIObjectContextModel context { get; set; } = EngineContext.Current.Resolve<JWebUIObjectContextModel>();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="postAPIService"></param>
    public MappingService(IPostAPIService postAPIService)
    {
        _postAPIService = postAPIService;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflowInfo"></param>
    /// <param name="dataRequest"></param>
    /// <returns></returns>
    public async Task<LearnApiModel> MappingRequest(WorkflowInfo workflowInfo, JObject dataRequest)
    {
        if (string.IsNullOrEmpty(workflowInfo.MappingRequest))
        {
            throw new Exception("Missing mapping request value!");
        }
        var learnApiModel = new LearnApiModel()
        {
            LearnApiMapping = workflowInfo.MappingRequest,
            LearnApiData = ""
        };
        learnApiModel = await O9MapData(learnApiModel, dataRequest.ConvertToJObject(), "ncbsCbs");
        return learnApiModel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mappingResponse"></param>
    /// <param name="data"></param>
    /// <param name="learnApiData"></param>
    /// <returns></returns>
    public async Task<JToken> MappingResponse(string mappingResponse, JToken data, string learnApiData ="")
    {
        JToken result = null;
        if (data is JArray jArray)
        {
            JArray resultArray = new JArray();

            foreach (JToken item in jArray)
            {
                var learnApiModel = new LearnApiModel()
                {
                    LearnApiMapping = mappingResponse,
                    LearnApiData = learnApiData
                };
                var mapObj = await O9MapData(learnApiModel, item.ToObject<JObject>().ConvertToJObject(), "ncbsCbs");

                //resultArray.Add(JToken.FromObject(learnApiModel.LearnApiMapping));
                if(mapObj == null)
                {
                    throw new Exception("An error occurred while mapping data response!");
                }
                resultArray.Add(JObject.Parse(mapObj.LearnApiMapping));
            }

            result = resultArray;
        }
        else if (data is JObject)
        {
            var dataObject = data.ToObject<JObject>();
            var learnApiModel = new LearnApiModel()
            {
                LearnApiMapping = mappingResponse,
                LearnApiData = ""
            };
            learnApiModel = await O9MapData(learnApiModel, dataObject.ConvertToJObject(), "ncbsCbs");

            var resultObject = JObject.Parse(learnApiModel.LearnApiMapping);
            
            result = resultObject;
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="learnApiContent"></param>
    /// <param name="dataMap"></param>
    /// <param name="appRequest"></param>
    /// <returns></returns>
    public async Task<LearnApiModel> O9MapData(LearnApiModel learnApiContent, JObject dataMap, string appRequest)
    {
        await Task.CompletedTask;
        if (learnApiContent != null)
        {
            var uid = context.InfoUser.GetUserLogin().Token;

            try
            {
                if (learnApiContent.LearnApiMapping != null)
                {
                    string strLearnApiMapping = learnApiContent.LearnApiMapping.Trim();

                    string learnApiData = "";
                    if (!string.IsNullOrEmpty(learnApiContent.LearnApiData))
                        learnApiData = learnApiContent.LearnApiData;

                    // strLearnApiMapping = strLearnApiMapping.Replace("pdatap", learnApiData);
                    LearnApiModel obPackApi = learnApiContent;

                    if (CMS.Utils.Utils.IsValidJsonObject(learnApiContent.LearnApiMapping.Trim()))
                    {
                        JObject obMapp_ = JsonConvert
                            .DeserializeObject(learnApiContent.LearnApiMapping.Trim())
                            .ToJObject();

                        if (obMapp_ == null)
                            obMapp_ = new JObject();

                        _postAPIService.LoopConfigMapping(ref obMapp_, appRequest, uid, dataMap, learnApiData, true);
                        //body
                        obPackApi.LearnApiMapping = JsonConvert.SerializeObject(obMapp_);
                    }
                    else if (CMS.Utils.Utils.IsValidJsonArray(learnApiContent.LearnApiMapping.Trim()))
                    {
                        JArray obMapp_ = JArray.FromObject(
                            JsonConvert.DeserializeObject(learnApiContent.LearnApiMapping.Trim())
                        );

                        if (obMapp_ == null)
                            obMapp_ = new JArray();

                        _postAPIService.LoopConfigMappingArray(ref obMapp_, appRequest, uid, dataMap, learnApiData, true);
                        //body
                        obPackApi.LearnApiMapping = JsonConvert.SerializeObject(obMapp_);
                    }

                    //header
                    if (!string.IsNullOrEmpty(learnApiContent.LearnApiHeader))
                    {
                        JObject headerApi = JsonConvert.DeserializeObject<JObject>(
                            learnApiContent.LearnApiHeader
                        );
                        _postAPIService.LoopConfigMapping(ref headerApi, appRequest, uid, dataMap, learnApiData);

                        obPackApi.LearnApiHeader = JsonConvert.SerializeObject(headerApi);
                    }
                    else
                        obPackApi.LearnApiHeader = null;

                    return obPackApi;
                }
            }
            catch (System.Exception ex)
            {
                if ((bool)context.InfoUser.GetUserLogin().isDebug)
                {
                    JObject errorApi = new JObject();
                    errorApi.Add(new JProperty("data", learnApiContent.LearnApiMapping));
                    errorApi.Add(new JProperty("mess", "Cant not parse learn_api_mapping"));
                    errorApi.Add(new JProperty("function", "BasicAction.txMapData"));
                    context.Bo.AddPackFo("error_api", errorApi);
                }

                // TODO
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        return null;
    }
}
