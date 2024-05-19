using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Jits.Neptune.Core;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Extensions;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Data;
using Jits.Neptune.Web.CMS.Attributes;
using Jits.Neptune.Web.CMS.Configuration;
using Jits.Neptune.Web.CMS.LogicOptimal9.Common;
using Jits.Neptune.Web.CMS.LogicOptimal9.Services;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.CMS.Utils;
using Jits.Neptune.Web.Framework.Infrastructure.Mapper.Extensions;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace Jits.Neptune.Web.CMS.Services;

/// <summary>
/// 
/// </summary>
public partial class WebSocketsService : IWebSocketsService
{
    private readonly string CMSInstanceIDString = Constants.CMSInstanceIDString;
    private readonly string CMSSSIDString = Constants.CMSSSIDString;
    private readonly string CMSContextUserString = Constants.CMSContextUserString;


    private readonly IConnectionMultiplexer _redis;
    private readonly List<RedisKey> _redisKeys = Singleton<List<RedisKey>>.Instance;
    private readonly IDatabase _database;

    /// <summary>
    /// 
    /// </summary>
    /// 
    public WebSocketsService()
    {
        
     
            _redis = Singleton<IConnectionMultiplexer>.Instance;
            ;
            if (Singleton<ConnectionManager>.Instance == null)
            {
                Singleton<ConnectionManager>.Instance = new ConnectionManager();
                _redisKeys = Singleton<List<RedisKey>>.Instance;
            }

        if (_redis == null)
        {
            if (Singleton<ConnectionManager>.Instance == null)
            {
                Singleton<ConnectionManager>.Instance = new ConnectionManager();
            }
        }
        else
        {
            _database = _redis.GetDatabase();
        }

    }

    /// <summary>
    /// * Add InstanceID from Neptune Server into redis and ConnectionManager 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <param name="webSocket"></param>
    /// <returns></returns>
    public virtual async Task AddWebsocket(string session_webui, WebSocket webSocket)
    {
        var newWebSocketId = JITS.Neptune.NeptuneClient.GrpcClient.ClientConfig.YourInstanceID;

        if (!GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            _database.StringSet(CMSInstanceIDString + session_webui, newWebSocketId);
        }
        Singleton<ConnectionManager>.Instance.AddSocket(session_webui, webSocket);
        await Task.CompletedTask;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual async Task AddContextUserLogin(string session_webui, string context)
    {
        if (!GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            _database.StringSet(CMSContextUserString + session_webui, context);
        }

        await Task.CompletedTask;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <returns></returns>
    public virtual async Task<string> GetContextUserLogin(string session_webui)
    {
        await Task.CompletedTask;

        return _database.StringGet(CMSContextUserString + session_webui);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sSid"></param>
    /// <param name="userid"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public virtual async Task AddSSIDToRedis(string sSid, int userid, string token)
    {
        var findToken = FindSessionBySSID(sSid);
        if (string.IsNullOrEmpty(findToken))
        {
            var listToken = new List<string>();
            listToken.Add(token);
            _database.StringSet(CMSSSIDString + sSid, (new
            {
                UsrId = userid,
                ListToken = listToken
            }).ToSerialize());
        }
        else
        {
            var listTokenSSIDModel = JObject.Parse(findToken).ToObject<SSIDModel>();
            if (listTokenSSIDModel != null)
            {
                var listToken = listTokenSSIDModel.ListToken;
                listToken.Add(token);
                _database.StringSet(CMSSSIDString + sSid, (new
                {
                    UsrId = userid,
                    ListToken = listToken
                }).ToSerialize());
            }
        }

        await Task.CompletedTask;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="socket"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendMessageAsync(WebSocket socket, string message)
    {
        System.Console.WriteLine("message==" + message);

        if (socket == null)
        {
            System.Console.WriteLine("socket is null==");
            return;
        }

        if (socket.State != WebSocketState.Open)
            return;

        await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(message),
                offset: 0,
                count: message.Length),
            messageType: WebSocketMessageType.Text,
            endOfMessage: true,
            cancellationToken: CancellationToken.None);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendMessageWithToken(string token, string message)
    {
        await Task.CompletedTask;
        if (!GlobalVariable.ncbsCbsMode.Equals(GlobalVariable.Optimal9))
        {
            var instance_id = FindInstanceIdByToken(token);
            if (!string.IsNullOrEmpty(instance_id))
            {
                Utils.GrpcClientExtension.RaiseServiceToServiceEventByServiceInstanceID(instance_id, token, message,
                    "SendWebsocketByInstanceID");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendMessageAllExceptToken(string token, string message)
    {
        foreach (var pair in Singleton<ConnectionManager>.Instance.GetAll())
        {
            if (!pair.Key.Equals(token))
                if (pair.Value.State == WebSocketState.Open)
                    await SendMessageAsync(pair.Value, message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public string FindInstanceIdByToken(string token)
    {
        string instance_id = "";
        if (_database.KeyExists(CMSInstanceIDString + token))
        {
            return _database.StringGet(CMSInstanceIDString + token);
        }

        return instance_id;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ssid"></param>
    /// <returns></returns>
    public string FindSessionBySSID(string ssid)
    {
        string instance_id = "";
        if (_database.KeyExists(CMSSSIDString + ssid))
        {
            return _database.StringGet(CMSSSIDString + ssid);
        }

        return instance_id;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendMessageAsyncInternal(string token, string message)
    {
        System.Console.WriteLine("token===" + token);
        await SendMessageAsync(Singleton<ConnectionManager>.Instance.GetSocketById(token), message);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendMessageToAllAsync(string message)
    {
        foreach (var pair in Singleton<ConnectionManager>.Instance.GetAll())
        {
            if (pair.Value.State == WebSocketState.Open)
                await SendMessageAsync(pair.Value, message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="session_webui"></param>
    /// <param name="webSocket"></param>
    /// <returns></returns>
    public virtual async Task Receiving(string session_webui, WebSocket webSocket)
    {
        await AddWebsocket(session_webui, webSocket);
        await Receive(webSocket, async (result, buffer) =>
        {
            if (result.MessageType == WebSocketMessageType.Text)
            {
                try
                {
                    string foJson = "";
                    JObject rsTemp = new JObject();
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    protectPostKey pP_start = new protectPostKey();

                    switch (message)
                    {
                        case "#protectPostStart":
                            rsTemp.Add(new JProperty("key_protect", pP_start.getProtectCurrent()));
                            foJson = JsonConvert.SerializeObject(CreateFoQuick("#sys:fo-protect-start", rsTemp));
                            break;
                        case "#protectPost":
                            foJson = JsonConvert.SerializeObject(CreateFoQuick("#sys:fo-protect-key", rsTemp));

                            break;
                        default:
                            break;
                    }

                    await webSocket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(foJson),
                            offset: 0,
                            count: foJson.Length),
                        messageType: WebSocketMessageType.Text,
                        endOfMessage: true,
                        cancellationToken: CancellationToken.None);
                    return;
                }
                catch (System.Exception ex)
                {
                    // TODO
                    System.Console.WriteLine("ReceiveAsyncException====" + ex.StackTrace);
                }

                return;
            }
        });
    }


    private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
        var buffer = new byte[1024 * 4];

        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                cancellationToken: CancellationToken.None);

            handleMessage(result, buffer);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="txcode"></param>
    /// <param name="foInput"></param>
    /// <returns></returns>
    public JObject CreateFoQuick(string txcode, JObject foInput)
    {
        JObject rs_ = new JObject();
        JArray listAction = new JArray();
        JObject foOne = new JObject();
        foOne.Add(new JProperty("txcode", txcode));
        foInput.Add(new JProperty("input", foInput));
        listAction.Add(foOne);
        rs_.Add(new JProperty("fo", listAction));
        return rs_;
    }

    /// <summary>
    /// 
    /// </summary>
    public class protectPostKey
    {
        // thời gian tồn tại của key là 30s và sẽ tự xóa khi có key mới
        // mỗi user id dùng tối đa 2
        // key hiện hành cũng là key chính để các protectPost của websocket lấy về dùng
        private String key_protect_current = Guid.NewGuid().ToString();

        /// <summary>
        /// 
        /// </summary>
        public int bitwiseOfProtectCurrent = 0;

        // key cũ là key mà websocket lấy về nhưng có 1 thời điểm gói tin có thể chưa
        // cập nhập nhập kịp
        // nên có thể dùng key này tạm
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String key_protect_old = Guid.NewGuid().ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long timer_creeate = TimeUtils.CurrentTimeMillis();

        // thời gian cập nhập key protect
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long timer_update_key = TimeUtils.CurrentTimeMillis();

        // thời gian key cũ hết hiệu lực
        /// <summary>
        /// 
        /// </summary>
        public long timer_key_old_expired = 2 * 60 * 1000;

        // khởi tạo key mới và chép key đang dùng key_protect_old để tránh việc 1 tại 1
        // thời điểm key chưa kịp cập nhập
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String resetKey()
        {
            String key_new = Guid.NewGuid().ToString();

            // chép lại key hiện tại
            key_protect_old = key_protect_current;

            // nhận key mới
            key_protect_current = key_new;

            buildBitWise();

            return key_new;
        }

        // kiểm tra key có tồn tại và hợp lệ không?
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key_"></param>
        /// <returns></returns>
        public bool checkKey(String key_)
        {
            if (key_.Equals(key_protect_current))
                return true;

            if (key_.Equals(key_protect_old) &&
                TimeUtils.CurrentTimeMillis() < timer_update_key + timer_key_old_expired)
                return true;
            return false;
        }

        // hàm lấy mã của protected hiện tại đã được chuyển đổi sẵn
        // vì mã này dùng đi dùng lại nhiều lần và dùng tại wizAlgorithmResponse
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getBitwise()
        {
            return bitwiseOfProtectCurrent;
        }

        // hàm này chỉ lấy 1 lần tại webUiSocket nên sẽ mã ở đây cho getBitwise dùng
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getProtectCurrent()
        {
            buildBitWise();

            return key_protect_current;
        }

        private void buildBitWise()
        {
            // bắt đầu chuyển protect_current thành số
            char[] byte_from_string = key_protect_current.ToCharArray();
            if (byte_from_string.Length > 0)
            {
                int build_bitwise = byte_from_string[0];
                for (int i_data = 1; i_data < byte_from_string.Length; i_data++)
                    build_bitwise ^= byte_from_string[i_data];

                bitwiseOfProtectCurrent = build_bitwise;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetObject<T>(string key)
    {
        var value = _database.StringGet(key);
        if (value.HasValue)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        return default(T);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    public void GetObject<T>(string key, T value)
    {
        var jsonValue = JsonConvert.SerializeObject(value);
        _database.StringSet(key, jsonValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Remove(string key)
    {
        return _database.KeyDelete(key);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="substring"></param>
    public void DeleteKeysWithSubstring(string substring)
    {
        foreach (var item in _redisKeys.Select(key => (string)key))
        {
            if (item.Contains(substring))
                _database.KeyDelete(item);
        }
    }
}