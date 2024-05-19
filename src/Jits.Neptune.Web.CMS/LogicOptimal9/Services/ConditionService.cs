using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using static Jits.Neptune.Web.CMS.LogicOptimal9.Services.O9PostService;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Services;

/// <summary>
/// 
/// </summary>
public static class ConditionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workflow"></param>
    /// <returns></returns>
    public static bool CheckCondition(this WorkflowRequestModel workflow)
    {
        if (workflow.ObjectField != null && workflow.ObjectField.ContainsKey("condition"))
        {
            JObject condition;
            if (workflow.ObjectField["condition"] is JObject)
            {
                condition = (JObject)workflow.ObjectField["condition"];
            }
            else
            {
                condition = JObject.Parse(workflow.ObjectField["condition"].ToString());
            }

            return EvaluateExpression((JObject)condition["expression"], JObject.FromObject(workflow.ObjectField));
        }
        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsonString"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool CheckCondition(string jsonString, JObject data)
    {
        JObject condition = JObject.Parse(jsonString);
        return EvaluateExpression((JObject)condition["expression"], data);
    }

    private static bool EvaluateExpression(JObject expression, JObject data)
    {
        string func = expression["func"].ToString();
        JArray paras = (JArray)expression["paras"];

        switch (func)
        {
            case "&&":
                return paras.All(para => EvaluateExpression((JObject)para, data));
            case "||":
                return paras.Any(para => EvaluateExpression((JObject)para, data));
            case "IsStringEqual":
                return IsStringEqual(paras[0].ToString(), paras[1].ToString(), data);
            case "IsNotNull":
                return IsNotNull(paras[0].ToString(), data);
            case "IsNotNullNotEmpty":
                return IsNotNullNotEmpty(paras[0].ToString(), data);
            default:
                throw new Exception($"Unsupported function: {func}");
        }
    }


    private static bool IsStringEqual(string path, string value, JObject data)
    {
        JToken token = data.SelectToken(path);
        return token != null && token.Type == JTokenType.String && token.ToString() == value;
    }

    private static bool IsNotNull(string path, JObject data)
    {
        JToken token = data.SelectToken(path);
        return token != null && token.Type != JTokenType.Null;
    }

    private static bool IsNotNullNotEmpty(string path, JObject data)
    {
        JToken token = data.SelectToken(path);
        return token != null && token.Type != JTokenType.Null && !string.IsNullOrEmpty(token.ToString());
    }
}
