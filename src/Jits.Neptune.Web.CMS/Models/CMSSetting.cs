using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Core.Configuration;
using Jits.Neptune.Core.Infrastructure;
using Jits.Neptune.Web.Framework.Services.Security;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Configuration
{
    /// <summary>
    /// Settings for Web Api
    /// </summary>
    public class CMSSetting : ISettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Isdev { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Isprod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Slowspeednetwork { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Hostport { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TemplateHostDev { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string SeverRsaPrivateKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ClientRsaPublicKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DataRsaPrivateKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DataRsaPublicKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ResponseEncryption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PasswordEncryption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int PostRsaType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string App { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Dictionary<string, AppGatewaySetting> AppGatewaySetting
        {
            get => JsonConvert.DeserializeObject<Dictionary<string, AppGatewaySetting>>(App);
            set => App = JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PasswordEncryptonType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Domains { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Dictionary<string, object> DomainsDictionary
        {
            get => JsonConvert.DeserializeObject<Dictionary<string, object>>(Domains);
            set => Domains = JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DomainsSocket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string EncryptionKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string DeveloperMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TokenLifetimeDays { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string SecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string UserPortal { get; set; } = "neptune";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PasswordPoral
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// /// </summary>
        /// <value></value>
        public int TimeoutApi { get; set; } = 60000;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AdminStaticToken { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PortalToken { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string ListLangConfig { get; set; } = "[{\"key\":\"vi\",\"view\":\"VietNam\",\"img\":\"../rs/global/img/vietnam.png\"},{\"key\":\"en\",\"view\":\"English\",\"img\":\"../rs/global/img/uk.png\",\"selected\":true}]";

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AUTO_EXTEND_SESSION { get; set; } = "Yes";
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long AUTO_EXTEND_SESSION_SECOND_INTERVAL { get; set; } = 1800000;

        /// <summary>
        /// BackupDirectory
        /// </summary>
        /// <value></value>
        public string BackupDirectory { get; set; }
        /// <summary>
        /// ImportApiIp
        /// </summary>
        /// <value></value>
        public string ImportApiUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReportApiUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AppVersion { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class AppGatewaySetting
    {
        /// <summary>
        /// 
        /// </summary>
        public AppGatewaySetting() { }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string IP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PortLogin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PortData { get; set; }

    }
}
