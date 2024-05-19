using Jits.Neptune.Web.Framework.Models;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.O9Models
{
    /// <summary>
    /// 
    /// </summary>
    public class O9LoginRequest: BaseNeptuneModel
    {
        /// <summary>
        /// Username to login O9Core
        /// </summary>
        /// <example>ac01</example>
        [JsonPropertyName("username")]
        public string Username { get; set; }
        /// <summary>
        /// Password of user to login
        /// </summary>
        /// <example>123456</example>
        [JsonPropertyName("password")]
        public string Password { get; set; }
        /// <summary>
        /// Password is encrypt or not. If you send plain password => set this to "false" 
        /// </summary>
        /// <example>false</example>
        public bool encrypt { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public O9LoginRequest()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}