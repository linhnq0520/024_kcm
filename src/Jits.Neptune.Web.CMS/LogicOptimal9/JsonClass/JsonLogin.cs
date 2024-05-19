using LinqToDB.Mapping;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace Jits.Neptune.Web.CMS.LogicOptimal9.JsonClass;

/// <summary>
/// 
/// </summary>
public class JsonLogin
{
    /// <summary>
    /// 
    /// </summary>
    public string L { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string P { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool A { get; set; }
}

/// <summary>
/// 
/// </summary>
public class ResponseLoginToCMS
{
    /// <summary>
    /// 
    /// </summary>
    public JsonLoginResponse login { get; set; }
}
/// <summary>
/// 
/// </summary>
public class JsonLoginResponse
{
    /// <summary>
    /// user id
    /// </summary>
    [JsonProperty("usrid")]
    public int id { get; set; }
    /// <summary>
    /// user code
    /// </summary>
    [JsonProperty("usrcd")]
    public string user_code { get; set; }
    /// <summary>
    /// user name
    /// </summary>
    [JsonProperty("usrname")]
    public string user_name { get; set; }
    /// <summary>
    /// login name
    /// </summary>
    [JsonProperty("lgname")]
    public string login_name { get; set; }
    /// <summary>
    /// token
    /// </summary>
    [JsonProperty("token")]
    public string token { get; set; }
    /// <summary>
    /// working date
    /// </summary>
    [JsonProperty("busdate")]
    public DateTime? working_date { get; set; }
    /// <summary>
    /// branch id
    /// </summary>
    [JsonProperty("branchid")]
    public int branch_id { get; set; }
    /// <summary>
    /// branch code
    /// </summary>
    [JsonProperty("branchcd")]
    public string branch_code { get; set; }
    /// <summary>
    /// branch name
    /// </summary>
    [JsonProperty("brname")]
    public string branch_name { get; set; }
    /// <summary>
    /// department code
    /// </summary>
    [JsonProperty("deprtcd")]
    public string department_code { get; set; }
    /// <summary>
    /// region
    /// </summary>
    [JsonProperty("region")]
    public string region { get; set; }
    /// <summary>
    /// position
    /// </summary>
    [JsonProperty("usrac.position")]
    public Position position { get; set; }
    /// <summary>
    /// branch status
    /// </summary>
    [JsonProperty("isonline")]
    public string branch_status { get; set; }
    /// <summary>
    /// bank status
    /// </summary>
    [JsonProperty("bankactive")]
    public string bank_status { get; set; }
    /// <summary>
    /// reset password
    /// </summary>
    [JsonProperty("reset_password")]
    public bool reset_password {
        get
        {
            return !string.IsNullOrEmpty(PwdReset);
        }
        set
        {
            this.reset_password = value;
        }

    }
   /// <summary>
   /// 
   /// </summary>
    [JsonProperty("usrac.expdt")]
    public DateTimeOffset expire_time { get; set; }
    /// <summary>
    /// avatar
    /// </summary>
    [JsonProperty("avatar")]
    public string avatar { get; set; }
    /// <summary>
    /// uuid
    /// </summary>
    public string uuid { get; set; }
    /// <summary>
    /// lang
    /// </summary>
    public string lang { get; set; }
    /// <summary>
    /// PwdReset
    /// </summary>
    [JsonProperty("pwdreset")]
    public string PwdReset { get; set; }
}

/// <summary>
/// Postion
/// </summary>
public class Position
{
    /// <summary>
    /// cashier
    /// </summary>
    [JsonProperty("C")]
    public int cashier { get; set; }
    /// <summary>
    /// officer
    /// </summary>
    [JsonProperty("O")]
    public int officer { get; set; }
    /// <summary>
    /// chief_cashier
    /// </summary>
    [JsonProperty("I")]
    public int chief_cashier { get; set; }
    /// <summary>
    /// operation_staff
    /// </summary>
    [JsonProperty("S")]
    public int operation_staff { get; set; }
    /// <summary>
    /// dealer
    /// </summary>
    [JsonProperty("D")]
    public int dealer { get; set; }
    /// <summary>
    /// inter_branch_user
    /// </summary>
    [JsonProperty("inter_branch_user")]
    public int inter_branch_user { get; set; }
    /// <summary>
    /// branch_manager
    /// </summary>
    [JsonProperty("branch_manager")]
    public int branch_manager { get; set; }
}


