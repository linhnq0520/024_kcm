#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GrpcClientExecuteModel
    {
        /// <summary>
        /// 
        /// </summary>
        public GrpcClientExecuteModel() { }
        /// <summary>
        /// </summary>
        public JITS.Neptune.NeptuneClient.GrpcClient grpcClient { get; set; } = new JITS.Neptune.NeptuneClient.GrpcClient();
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool isRegistered { get; set; } = false;


    }
}


