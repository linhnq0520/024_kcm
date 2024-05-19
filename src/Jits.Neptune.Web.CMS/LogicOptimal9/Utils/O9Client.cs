using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.Util;
using System;
using System.Net;
using System.IO;
using Jits.Neptune.Web.CMS.LogicOptimal9.Config;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Core.Configuration;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;
using System.Threading.Tasks;
using Autofac.Core;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.Utils;

/// <summary>
/// 
/// </summary>
public class O9Client
{
    /// <summary>
    /// 
    /// </summary>
    public static PooledActiveMQ activeMQ;
    /// <summary>
    /// 
    /// </summary>
    public static O9MemCached memCached;
    /// <summary>
    /// 
    /// </summary>
    public static CoreConfig coreConfig;
    /// <summary>
    /// 
    /// </summary>
    public static Optimal9Settings appSettings;
    /// <summary>
    /// 
    /// </summary>
    public static string ipmemCached;
    /// <summary>
    /// 
    /// </summary>
    public static string O9_GLOBAL_SEPARATE_ADDRESS { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public static string OP_MCKEY_FMAP { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public static string Comcode { get; set; }
    private static string m_userName;
    private static string m_passWord;
    /// <summary>
    /// 
    /// </summary>
    public static string m_urlRequest;
    private static string m_requestQueueName;
    private static string m_requestQueueNameASynchronize;
    private static string m_replyQueueName;
    private static string m_replyNotificationQueueName;
    private static string m_functionRequestID;
    private static string m_functionReplyID;
    private static string m_functionAsynchronizeRequestID;
    private static string m_functionAsynchronizeReplyID;
    private static int m_messageClienTimeOut;
    private static int m_sizeSessionID;
    /// <summary>
    /// 
    /// </summary>
    public static bool isInit { get; private set; } = false;
    private ActiveMQConnection m_connection;
    private Session m_messageSession;
    private MessageProducer m_messageProducer;
    private ActiveMQDestination m_destination;
    private ActiveMQDestination m_destinationAsynchronize;
    private ActiveMQTextMessage m_message;
    private ActiveMQDestination m_destinationReply;
    private MessageConsumer m_messageConsumerReply;

    /// <summary>
    /// 
    /// </summary>
    public static void Init(string ipmemcached, Optimal9Settings app)
    {
        if (coreConfig == null)
        {
            appSettings = app;
            coreConfig = app.Configure;
            ipmemCached = ipmemcached;
            memCached = new O9MemCached(ipmemcached);
        }
        try
        {
            InitParam();
            if (string.IsNullOrEmpty(m_urlRequest)) return;
            activeMQ = new PooledActiveMQ(m_userName, m_passWord, m_urlRequest, 5, app.PoolConnection);
            activeMQ.Init();
            GlobalVariable.TIME_UPDATE_TXDT = coreConfig.WKDTimes;
            //GlobalVariable.O9_PERIOD_LOGIN = app.PeriodLogin;
            GlobalVariable.O9_GLOBAL_COREAPILB = app.LbName;
            if (!string.IsNullOrEmpty(m_urlRequest)) isInit = true;
        }
        catch (Exception)
        {
            isInit = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static void InitParam()
    {
        O9_GLOBAL_SEPARATE_ADDRESS = memCached.GetValue("OP_SERVER_MESSAGE_SEPARATE_ADDRESS");
        OP_MCKEY_FMAP = memCached.GetValue("OP_MCKEY_FMAP");
        m_userName = memCached.GetValue("OP_CLIENT_MESSAGE_USERNAME");
        m_passWord = memCached.GetValue("OP_CLIENT_MESSAGE_PASSWORD");
        m_userName = O9Encrypt.Decrypt(m_userName);
        m_passWord = O9Encrypt.Decrypt(m_passWord);
        m_urlRequest = memCached.GetValue("OP_CLIENT_MESSAGE_BROKER_URL");
        m_requestQueueName = memCached.GetValue("OP_CLIENT_MESSAGE_QUEUE_NAME");
        m_requestQueueNameASynchronize = memCached.GetValue("OP_CLIENT_MESSAGE_ASYNCHRONIZE_QUEUE_NAME");
        m_replyQueueName = memCached.GetValue("OP_CLIENT_MESSAGE_REPLY_NAME");
        m_replyQueueName = m_replyQueueName + O9_GLOBAL_SEPARATE_ADDRESS;
        m_replyNotificationQueueName = memCached.GetValue("OP_CLIENT_MESSAGE_NOTIFICATION_REPLY_NAME");
        m_functionRequestID = memCached.GetValue("OP_CLIENT_FUNCTION_REQUEST_ID");
        m_functionReplyID = memCached.GetValue("OP_CLIENT_FUNCTION_REPLY_ID");
        m_functionAsynchronizeRequestID = memCached.GetValue("OP_CLIENT_FUNCTION_ASYNCHRONIZE_REQUEST_ID");
        m_functionAsynchronizeReplyID = memCached.GetValue("OP_CLIENT_FUNCTION_ASYNCHRONIZE_REPLY_ID");
        int.TryParse(memCached.GetValue("OP_CLIENT_MESSAGE_CLIENT_TIMEOUT"), out m_messageClienTimeOut);
        int.TryParse(memCached.GetValue("OP_SIZE_OF_SESSIONID"), out m_sizeSessionID);

        if (!GetMemcachedKey()) throw new Exception("Error at GetMemcachedKey");

        if (!GetHeadOfficeParam())
                throw new Exception("Get Head Office Param");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Boolean GetMemcachedKey()
    {
        try
        {
            if (GlobalVariable.O9_GLOBAL_MEMCACHED_KEY == null)
            {
                GlobalVariable.O9_GLOBAL_MEMCACHED_KEY = new MemcachedKey();
                SetValueToParam(GlobalVariable.O9_GLOBAL_MEMCACHED_KEY, "OP_MCKEY_", null, false);
            }
            if (GlobalVariable.O9_GLOBAL_MEMCACHED_KEY != null) return true;
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="comCode"></param>
    /// <returns></returns>
    public static Boolean GetHeadOfficeParam(string comCode = "")
    {
        try
        {
            comCode = (String.IsNullOrEmpty(comCode) ? O9Constants.O9_CONSTANT_COM_DEFAULT : comCode) + "_";
            GlobalVariable.O9_GLOBAL_HEADOFFICE_PARAM = SetValueToParam<HeadOfficeParam>(comCode + GlobalVariable.O9_GLOBAL_MEMCACHED_KEY.Param);

            if (GlobalVariable.O9_GLOBAL_HEADOFFICE_PARAM != null)
            {
                // do get mask configuration 
                return true;
            }
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T SetValueToParam<T>(string key)
    {
        try
        {
            string value = O9Client.memCached.GetValue(key);
            if (!String.IsNullOrEmpty(value)) return O9Utils.JSONDeserializeObject<T>(value);
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
    /// <param name="obj"></param>
    /// <param name="key"></param>
    /// <param name="resManager"></param>
    /// <param name="valueIsJson"></param>
    /// <returns></returns>
    public static Boolean SetValueToParam(Object obj, string key, ResourceManager resManager = null, Boolean valueIsJson = true)
    {
        try
        {
            CultureInfo cltInfo = new CultureInfo("en");

            foreach (PropertyInfo pri in obj.GetType().GetProperties())
            {
                string value = "";
                string keyOfMemcached = key + pri.Name.ToUpper();

                if (resManager != null) keyOfMemcached = resManager.GetResourceSet(cltInfo, true, true).GetString(keyOfMemcached);
                if (!String.IsNullOrEmpty(keyOfMemcached)) value = O9Client.memCached.GetValue(keyOfMemcached);
                if (!String.IsNullOrEmpty(value))
                {
                    if (valueIsJson)
                    {
                        JObject jsObj = JObject.Parse(value);

                        if (jsObj != null && jsObj.Count > 0)
                        {
                            JValue jsValue = (JValue)jsObj.SelectToken(O9Constants.O9_KEY_DEFAULT);
                            if (jsValue != null) value = jsValue.Value.ToString();
                        }
                    }
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (pri.PropertyType == typeof(string))
                        {
                            pri.SetValue(obj, value.ToString(), null);
                        }
                        else if (pri.PropertyType == typeof(int) || pri.PropertyType == typeof(Int16) || pri.PropertyType == typeof(Int32) || pri.PropertyType == typeof(Int64))
                        {
                            pri.SetValue(obj, int.Parse(value.ToString()), null);
                        }
                    }
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            O9Utils.ConsoleWriteLine(ex);
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="functionID"></param>
    /// <param name="userId"></param>
    /// <param name="sessionID"></param>
    /// <param name="enmCacheAction"></param>
    /// <param name="sendType"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public async Task<string> SendStringAsync(string text, string functionID, string userId, string sessionID,
        EnmCacheAction enmCacheAction, EnmSendTypeOption sendType, MsgPriority priority)
    {
        string strReturn = string.Empty;
        try
        {
            m_connection = activeMQ.GetConnection();
            if (m_connection != null)
            {
                if (!m_connection.IsStart()) m_connection.Start();
                m_messageSession = (Session)await m_connection.connection.CreateSessionAsync();
                m_destination = (ActiveMQDestination)SessionUtil.GetDestination(m_messageSession, m_requestQueueName);
                m_destinationAsynchronize = (ActiveMQDestination)SessionUtil.GetDestination(m_messageSession, m_requestQueueNameASynchronize);
                m_destinationReply = (ActiveMQDestination)SessionUtil.GetDestination(m_messageSession,
                    coreConfig.GetReplyString(m_replyQueueName, O9_GLOBAL_SEPARATE_ADDRESS, m_connection.Queue));
                m_messageConsumerReply = (MessageConsumer)await m_messageSession.CreateConsumerAsync(m_destinationReply);
                m_messageProducer = (MessageProducer)await m_messageSession.CreateProducerAsync();
                m_message = (ActiveMQTextMessage)await m_messageSession.CreateTextMessageAsync();

                if (sendType == EnmSendTypeOption.Synchronize)
                    m_message.NMSCorrelationID = m_functionRequestID + "-" + Guid.NewGuid().ToString() + O9Encrypt.GenerateRandomString();
                else if (sendType == EnmSendTypeOption.AsSynchronize)
                    m_message.NMSCorrelationID = m_functionAsynchronizeRequestID + "-" + Guid.NewGuid().ToString();

                string strSession = sessionID.PadRight(m_sizeSessionID);
                string strIsCaching = "N";
                m_message.Content = O9Compression.SetCompressText(strIsCaching + strSession + text);

                m_message.UserID = userId;
                m_message.NMSPriority = priority;
                m_message.NMSType = functionID;
                m_message.ReplyTo = m_destinationReply;
                m_messageProducer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                if (sendType == EnmSendTypeOption.Synchronize)
                    await m_messageProducer.SendAsync(m_destination, m_message);
                else if (sendType == EnmSendTypeOption.AsSynchronize)
                    await m_messageProducer.SendAsync(m_destinationAsynchronize, m_message);

                IMessage receivedMsg = null;
                bool flag = false;

                while (!flag)
                {
                    receivedMsg = await m_messageConsumerReply.ReceiveAsync(TimeSpan.FromSeconds(m_messageClienTimeOut));
                    if (receivedMsg == null)
                        break;
                    else if (receivedMsg.NMSCorrelationID.Equals(m_message.NMSCorrelationID))
                        flag = true;
                }

                if (receivedMsg != null)
                {
                    m_message = (ActiveMQTextMessage)receivedMsg;
                    strReturn = O9Compression.GetTextFromCompressBytes(m_message.Content);
                }
                else
                {
                    strReturn = "COREERRORSYSTEM Timeout when sending message to O9Hosting";
                }
            }
            else
            {
                strReturn = "TIMEOUTAQ";
            }
        }
        catch (Exception ex)
        {
            strReturn = "COREERRORSYSTEM " + ex.Message + " " + ex.StackTrace;
        }
        finally
        {
            if (m_messageProducer != null) await m_messageProducer.CloseAsync();
            if (m_messageConsumerReply != null) await m_messageConsumerReply.CloseAsync();
            if (m_destination != null) m_destination.Dispose();
            if (m_destinationAsynchronize != null) m_destinationAsynchronize.Dispose();
            if (m_destinationReply != null) m_destinationReply.Dispose();
            if (m_messageSession != null) await m_messageSession.CloseAsync();
            if (m_connection != null) activeMQ.ReleaseConnection(m_connection);
        }
        return strReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    public string SendString(string text, string functionID, string userId, string sessionID, EnmCacheAction enmCacheAction, EnmSendTypeOption sendType, MsgPriority priority)
    {
        string strReturn = string.Empty;
        try
        {
            m_connection = activeMQ.GetConnection();
            if (m_connection != null)
            {
                if (!m_connection.IsStart()) m_connection.Start();
                m_messageSession = (Session)m_connection.connection.CreateSession();
                m_destination = (ActiveMQDestination)SessionUtil.GetDestination(m_messageSession, m_requestQueueName);
                m_destinationAsynchronize = (ActiveMQDestination)SessionUtil.GetDestination(m_messageSession, m_requestQueueNameASynchronize);
                m_destinationReply = (ActiveMQDestination)SessionUtil.GetDestination(m_messageSession, coreConfig.GetReplyString(m_replyQueueName, O9_GLOBAL_SEPARATE_ADDRESS, m_connection.Queue));
                m_messageConsumerReply = (MessageConsumer)m_messageSession.CreateConsumer(m_destinationReply);
                m_messageProducer = (MessageProducer)m_messageSession.CreateProducer();
                m_message = (ActiveMQTextMessage)m_messageSession.CreateTextMessage();

                if (sendType == EnmSendTypeOption.Synchronize)
                    m_message.NMSCorrelationID = m_functionRequestID + "-" + Guid.NewGuid().ToString() + O9Encrypt.GenerateRandomString();
                else if (sendType == EnmSendTypeOption.AsSynchronize)
                    m_message.NMSCorrelationID = m_functionAsynchronizeRequestID + "-" + Guid.NewGuid().ToString();

                string strSession = "";
                string strIsCaching = "N";

                strSession = sessionID.PadRight(m_sizeSessionID);
                m_message.Content = O9Compression.SetCompressText(strIsCaching + strSession + text);

                m_message.UserID = userId;
                m_message.NMSPriority = priority;
                m_message.NMSType = functionID;
                m_message.ReplyTo = m_destinationReply;
                m_messageProducer.DeliveryMode = MsgDeliveryMode.NonPersistent;


                if (sendType == EnmSendTypeOption.Synchronize)
                    m_messageProducer.Send(m_destination, m_message);
                else if (sendType == EnmSendTypeOption.AsSynchronize)
                    m_messageProducer.Send(m_destinationAsynchronize, m_message);

                IMessage receivedMsg = null;
                bool flag = false;

                while (flag == false)
                {
                    receivedMsg = m_messageConsumerReply.Receive(TimeSpan.FromSeconds(m_messageClienTimeOut));
                    if (receivedMsg == null)
                        break;
                    else if (receivedMsg != null && receivedMsg.NMSCorrelationID.Equals(m_message.NMSCorrelationID))
                    {
                        flag = true;
                    }
                }

                if (receivedMsg != null)
                {
                    m_message = (ActiveMQTextMessage)receivedMsg;
                    strReturn = O9Compression.GetTextFromCompressBytes(m_message.Content);
                }
                else
                {
                    strReturn = "CORE_ERROR_SYSTEM Timeout when sending message to O9Hosting";
                }

            }
            else
            {
                strReturn = "TIMEOUTAQ";
            }
        }
        catch (Exception ex)
        {
            strReturn = "COREERRORSYSTEM " + ex.Message + " " + ex.StackTrace;
        }
        finally
        {
            if (m_messageProducer != null) m_messageProducer.Close();
            if (m_messageConsumerReply != null) m_messageConsumerReply.Close();
            if (m_destination != null) m_destination.Dispose();
            if (m_destinationAsynchronize != null) m_destinationAsynchronize.Dispose();
            if (m_destinationReply != null) m_destinationReply.Dispose();
            if (m_messageSession != null) m_messageSession.Close();
            if (m_connection != null) activeMQ.ReleaseConnection(m_connection);
        }
        return strReturn;
    }
}

