using Newtonsoft.Json.Linq;
using System;
using System.Data;
using Jits.Neptune.Core;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.Utils;
using System.Linq;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Utils;

/// <summary>
/// Utils
/// </summary>
public static class JTokenExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsObject"></param>
    /// <returns></returns>
    public static JObject ConvertToJArray(this JObject jsObject)
    {
        JObject jsReturn = new JObject();
        foreach (var js in jsObject.Properties())
        {
            JArray jsArray = new JArray
            {
                js.Value
            };
            jsReturn.Add(js.Name.ToUpper(), jsArray);
        }
        return jsReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static JObject ConvertToJArray(this BaseNeptuneModel model)
    {
        JObject jsReturn = new JObject();
        foreach (var property in model.GetType().GetProperties())
        {
            var value = property.GetValue(model);

            if (value != null)
            {
                JArray jsArray = new JArray();
                jsArray.Add(JToken.FromObject(value));

                jsReturn.Add(property.Name.ToUpper(), jsArray);
            }
        }
        return jsReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static JObject ConvertToJArray(this BaseEntity entity)
    {
        JObject jsReturn = new JObject();
        foreach (var property in entity.GetType().GetProperties())
        {
            var value = property.GetValue(entity);

            if (value != null)
            {
                JArray jsArray = new JArray();
                jsArray.Add(JToken.FromObject(value));

                jsReturn.Add(property.Name.ToUpper(), jsArray);
            }
        }
        return jsReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static JObject ToUpperPropertyName(this BaseNeptuneModel model)
    {
        JObject jsReturn = new JObject();
        foreach (var property in model.GetType().GetProperties())
        {
            var value = property.GetValue(model);
            var upperCaseName = property.Name.ToUpper();
            if (value != null)
            {
                if (IsDateType(property.PropertyType))
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(value.ToString()));
                }
                else if(property.PropertyType.IsSubclassOf(typeof(BaseNeptuneModel)))
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(JObject.Parse(System.Text.Json.JsonSerializer.Serialize(value))));
                }
                else
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(value));
                }
                
            }
        }
        return jsReturn;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static JObject ToUpperPropertyName(this JObject model)
    {
        JObject jsReturn = new();
        foreach (var property in model.Properties())
        {
            var value = property.Value;
            var upperCaseName = property.Name.ToUpper();

            if (value != null)
            {
                if (value.Type == JTokenType.Object)
                {
                    jsReturn.Add(upperCaseName, ((JObject)value).ToUpperPropertyName());
                }
                else if (value.Type == JTokenType.Array)
                {
                    var array = new JArray();
                    foreach (var item in (JArray)value)
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            array.Add(((JObject)item).ToUpperPropertyName());
                        }
                        else
                        {
                            array.Add(item);
                        }
                    }
                    jsReturn.Add(upperCaseName, array);
                }
                else
                {
                    jsReturn.Add(upperCaseName, value);
                }
            }
        }
        return jsReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="formatDate"></param>
    /// <returns></returns>
    public static JObject ToUpperPropertyNameWithDate(this BaseNeptuneModel model, string formatDate = null)
    {
        JObject jsReturn = new JObject();
        foreach (var property in model.GetType().GetProperties())
        {
            var value = property.GetValue(model);
            var upperCaseName = property.Name.ToUpper();
            if (value != null)
            {
                if (value is DateTime dateTime)
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(dateTime.ToString(formatDate)));
                }
                else if (value is DateOnly dateOnly)
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(dateOnly.ToString(formatDate)));
                }
                else if (property.PropertyType.IsSubclassOf(typeof(BaseNeptuneModel)))
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(JObject.Parse(System.Text.Json.JsonSerializer.Serialize(value))));
                }
                else
                {
                    jsReturn.Add(upperCaseName, JToken.FromObject(value));
                }
            }
        }
        return jsReturn;
    }


    private static bool IsDateType(System.Type type)
    {
        return type == typeof(DateTime) ||
               type == typeof(DateTime?) ||
               type == typeof(DateOnly) ||
               type == typeof(DateOnly?) ||
               type == typeof(TimeOnly) ||
               type == typeof(TimeOnly?);
    }
}

/// <summary>
/// 
/// </summary>
public static class JsonExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jObject"></param>
    /// <returns></returns>
    public static T MapToModel<T>(this JObject jObject)
    {
        try
        {
            string strObject = JsonConvert.SerializeObject(jObject);
            return System.Text.Json.JsonSerializer.Deserialize<T>(strObject);
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }

        return default(T);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jObject"></param>
    /// <returns></returns>
    public static T MapToModel<T>(this JToken jObject)
    {
        try
        {
            string strObject = JsonConvert.SerializeObject(jObject);
            return System.Text.Json.JsonSerializer.Deserialize<T>(strObject);
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }

        return default(T);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="jObject"></param>
    /// <returns></returns>
    public static T JsonConvertToModel<T>(this JObject jObject)
    {
        try
        {
            string strObject = JsonConvert.SerializeObject(jObject);
            return JsonConvert.DeserializeObject<T>(strObject);
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }

        return default(T);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsObject"></param>
    /// <returns></returns>
    public static JObject ConvertToJObject(this JObject jsObject)
    {
        try
        {
            JObject jsReturn = new JObject();
            if (jsObject == null)
            {
                return jsReturn;
            }
            foreach (var js in jsObject.Properties())
            {
                switch (js.Value.Type)
                {
                    case JTokenType.Array:
                        JArray ja = (JArray)js.Value;
                        foreach (var vl in ja.Children())
                        {
                            jsReturn.Add(js.Name.ToLower(), vl);
                            break;
                        }
                        break;
                    case JTokenType.Object:
                        jsReturn.Add(js.Name.ToLower(), ((JObject)js.Value).ConvertToJObject());
                        break;
                    case JTokenType.Null:
                        jsReturn.Add(js.Name.ToLower(), JValue.CreateNull());
                        break;
                    default:
                        jsReturn.Add(js.Name.ToLower(), js.Value);
                        break;
                }
            }
            return jsReturn;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsObject"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static JObject UpperKey(this JObject jsObject)
    {
        try
        {
            JObject jsReturn = new();
            if (jsObject == null)
            {
                return jsReturn;
            }
            foreach (var js in jsObject.Properties())
            {
                switch (js.Value.Type)
                {
                    case JTokenType.Array:
                        JArray ja = (JArray)js.Value;
                        foreach (var vl in ja.Children())
                        {
                            jsReturn.Add(js.Name.ToUpper(), vl);
                            break;
                        }
                        break;
                    case JTokenType.Object:
                        jsReturn.Add(js.Name.ToUpper(), ((JObject)js.Value).UpperKey());
                        break;
                    case JTokenType.Null:
                        jsReturn.Add(js.Name.ToUpper(), JValue.CreateNull());
                        break;
                    default:
                        jsReturn.Add(js.Name.ToUpper(), js.Value);
                        break;
                }
            }
            return jsReturn;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsArray"></param>
    /// <returns></returns>
    public static JObject ConvertToJArrayDetails(this JArray jsArray)
    {
        JObject jsReturn = new();

        foreach (var jsItem in jsArray)
        {
            foreach (var js in ((JObject)jsItem).Properties())
            {
                string key = js.Name.ToUpper();
                JArray jsSub = jsReturn.ContainsKey(key) ? (JArray)jsReturn.SelectToken(key) : new JArray();
                jsSub.Add(js.Value);
                jsReturn.Remove(key);
                jsReturn.Add(key, jsSub);
            }
        }

        return jsReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jsObject"></param>
    /// <returns></returns>
    public static JArray ConvertToJObjectArrayDetails(this JObject jsObject)
    {
        JArray jsReturn = new JArray();

        try
        {
            if (jsObject != null)
            {
                foreach (var jsItem in jsObject.Properties())
                {
                    string key = jsItem.Name.ToLower();
                    for (int i = 0; i < jsItem.Values().Count(); i++)
                    {
                        JObject jsSub;
                        if (jsReturn.Count <= i) jsSub = new JObject();
                        else
                            jsSub = (JObject)jsReturn[i];

                        if (jsSub == null) jsSub = new JObject();
                        jsSub.Add(key, jsItem.Value[i]);

                        if (jsReturn.Count <= i)
                            jsReturn.Add(jsSub);
                        else
                            jsReturn[i] = jsSub;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }

        return jsReturn;
    }
}


