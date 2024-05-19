using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using JITS.Neptune.NeptuneClient;
using JITS.Neptune.NeptuneClient.Events;
using JITS.Neptune.NeptuneClient.Events.EventData;
 
namespace Jits.Neptune.Web.CMS.Utils
{
    /// <summary>
    /// Workflow Extensions
    /// </summary>
    public static class GrpcClientExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance_id"></param>
        /// <param name="token"></param>
        /// <param name="message"></param>
        /// <param name="event_type"></param>
        public static void RaiseServiceToServiceEventByServiceInstanceID(string instance_id,string token, string message,string event_type)
        {
            var gRPCClient = new GrpcClient();

            string strFrom_service_code = "CMS"; // assign FROM service code
            string strTo_service_code = "CMS";  // assign TO service code

            string strServiceInstanceID = GrpcClient.ClientConfig.YourInstanceID;

            var data_send = new { token, message };
            string strSerializedMessage = JsonSerializer.Serialize(data_send);
            
            NeptuneEvent<ServiceToServiceEventData> data = new NeptuneEvent<ServiceToServiceEventData>();
            data.EventData.data = new ServiceToServiceEventData()
            {
                from_service_code = strFrom_service_code,
                to_service_code = strTo_service_code,
                event_type = event_type, // your custom event type
                text_data = strSerializedMessage,
            };

            gRPCClient.RaiseServiceToServiceEventByServiceInstanceID(instance_id, data);

        }
    }
}