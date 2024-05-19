using System;
using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.Admin.Models
{

    /// <summary>
    /// User policy create model
    /// </summary>
    public partial class UserPolicyCreateModel : BaseTransactionModel
    {

        /// <summary>
        /// user policy create model constructor
        /// </summary>
        public UserPolicyCreateModel()
        {
            EnforcePasswordHistory = 3;
            MinimumPasswordLength = 0;
            PasswordComplexityRequirements = "Y";
            PasswordHaveSpecialSymbol = "Y";
            PasswordHaveUpperCase = "Y";
            PasswordHaveLowerCase = "Y";
            PasswordHaveNumber = "Y";
            MaximumPasswordAge = 180;
            LockoutTthrs = 3;
            SessionMode = "M";
        }

        /// <summary>
        /// Descr
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        /// EffectiveFrom
        /// </summary>
        public DateTime EffectiveFrom { get; set; }

        /// <summary>
        /// EffectiveTo
        /// </summary>
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// EnforcePasswordHistory
        /// </summary>
        public int? EnforcePasswordHistory { get; set; }

        /// <summary>
        /// MaximumPasswordAge
        /// </summary>
        public int? MaximumPasswordAge { get; set; }

        /// <summary>
        /// MinimumPasswordLength
        /// </summary>
        public int? MinimumPasswordLength { get; set; }

        /// <summary>
        /// PasswordComplexityRequirements
        /// </summary>
        public string PasswordComplexityRequirements { get; set; }

        /// <summary>
        /// PasswordHaveSpecialSymbol
        /// </summary>
        public string PasswordHaveSpecialSymbol { get; set; }

        /// <summary>
        /// PasswordHaveUpperCase
        /// </summary>
        public string PasswordHaveUpperCase { get; set; }

        /// <summary>
        /// PasswordHaveLowerCase
        /// </summary>
        public string PasswordHaveLowerCase { get; set; }

        /// <summary>
        /// PasswordHaveNumber
        /// </summary>
        public string PasswordHaveNumber { get; set; }

        /// <summary>
        /// CanLoginFrom
        /// </summary>
        public string CanLoginFrom { get; set; }

        /// <summary>
        /// CanLoginTo
        /// </summary>
        public string CanLoginTo { get; set; }

        /// <summary>
        /// LockoutTthrs
        /// </summary>
        public int? LockoutTthrs { get; set; }
        /// <summary>
        /// SessionMode
        /// </summary>
        /// <value></value>
        public string SessionMode { get; set; }
    }

    /// <summary>
    /// User policy delete model
    /// </summary>
    public partial class UserPolicyDeleteModel : BaseTransactionModel
    {
        /// <summary>
        /// User policy delete model constructor
        /// </summary>
        public UserPolicyDeleteModel()
        {
        }

        /// <summary>
        /// user policy id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// User policy search model
    /// </summary>
    public partial class UserPolicySearchModel : SearchBaseModel
    {

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public int? policyid { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("descr")]
        public string descr { get; set; }

        /// <summary>
        /// Effective From
        /// </summary>
        [JsonProperty("effective_from")]
        public DateTime? EffectiveFrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string effrom { get; set; }

        /// <summary>
        /// Effective To
        /// </summary>
        [JsonProperty("effective_to")]
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string efto { get; set; }
    }

    /// <summary>
    /// UserPolicySearchResponseModel
    /// </summary>
    public partial class UserPolicySearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public int policyid { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("descr")]
        public string descr { get; set; }

        /// <summary>
        /// Effective From
        /// </summary>
        [JsonProperty("effective_from")]
        public DateTime? effrom { get; set; }

        /// <summary>
        /// Effective To
        /// </summary>
        [JsonProperty("effective_to")]
        public DateTime? efto { get; set; }

    }
    /// <summary>
    /// UserPolicyViewResponseModel
    /// </summary>
    public partial class UserPolicyViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public int policyid { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("descr")]
        public string descr { get; set; }

        /// <summary>
        /// Effective From
        /// </summary>
        [JsonProperty("effective_from")]
        public DateTime? EffectiveFrom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? effrom{ get; set; }

        /// <summary>
        /// Effective To
        /// </summary>
        [JsonProperty("effective_to")]
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? efto{ get; set; }

        /// <summary>
        /// Enforce Password History
        /// </summary>
        [JsonProperty("enforce_password_history")]
        public int? pwdhis { get; set; }

        /// <summary>
        /// Maximum Password Age
        /// </summary>
        [JsonProperty("maximum_password_age")]
        public int? pwdagemax { get; set; }

        /// <summary>
        /// Minimum Password Length
        /// </summary>
        [JsonProperty("minimum_password_length")]
        public int? minpwdlen { get; set; }

        /// <summary>
        /// Password Complexity Requirements
        /// </summary>
        [JsonProperty("password_complexity_requirements")]
        public string pwdcplx { get; set; }

        /// <summary>
        /// Password Have Special Symbol
        /// </summary>
        [JsonProperty("password_have_special_symbol")]
        public string pwdcplxlc { get; set; }

        /// <summary>
        /// Password Have Upper Case
        /// </summary>
        [JsonProperty("password_have_upper_case")]
        public string pwdcplxuc { get; set; }

        /// <summary>
        /// Password Have Lower Case
        /// </summary>
        [JsonProperty("password_have_lower_case")]
        public string pwdcplxsc { get; set; }

        /// <summary>
        /// Password Have Number
        /// </summary>
        [JsonProperty("password_have_number")]
        public string pwdcplxnc { get; set; }

        /// <summary>
        /// Can Login From
        /// </summary>
        [JsonProperty("can_login_from")]
        public string lginfr { get; set; }

        /// <summary>
        /// Can Login To
        /// </summary>
        [JsonProperty("can_login_to")]
        public string lginto { get; set; }

        /// <summary>
        /// Lockout Threshold
        /// </summary>
        [JsonProperty("lockout_threshold")]
        public int? lkoutthrs { get; set; }

        /// <summary>
        /// Session Mode
        /// </summary>
        [JsonProperty("session_mode")]
        public string SessionMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string upwddflt { get;set; }
        /// <summary>
        /// 
        /// </summary>
        public string pwddflt { get;set; }
        /// <summary>
        /// 
        /// </summary>
        public int pwddfltexpire { get;set; }
    }

    /// <summary>
    /// user policy update model
    /// </summary>
    public partial class UserPolicyUpdateModel : BaseTransactionModel
    {
        /// <summary>
        /// user policy update model constructor
        /// </summary>
        public UserPolicyUpdateModel()
        {
            EnforcePasswordHistory = 3;
            MaximumPasswordAge = 180;
            MinimumPasswordLength = 6;
            PasswordComplexityRequirements = "Y";
            PasswordHaveSpecialSymbol = "Y";
            PasswordHaveUpperCase = "Y";
            PasswordHaveLowerCase = "Y";
            PasswordHaveNumber = "Y";
            SessionMode = "M";
        }

        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descr
        /// </summary>
        public string Descr { get; set; }

        /// <summary>
        /// EffectiveFrom
        /// </summary>
        public DateTime EffectiveFrom { get; set; }

        /// <summary>
        /// EffectiveTo
        /// </summary>
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// EnforcePasswordHistory
        /// </summary>
        public int? EnforcePasswordHistory { get; set; }

        /// <summary>
        /// MaximumPasswordAge
        /// </summary>
        public int? MaximumPasswordAge { get; set; }

        /// <summary>
        /// MinimumPasswordLength
        /// </summary>
        public int? MinimumPasswordLength { get; set; }

        /// <summary>
        /// PasswordComplexityRequirements
        /// </summary>
        public string PasswordComplexityRequirements { get; set; }

        /// <summary>
        /// PasswordHaveSpecialSymbol
        /// </summary>
        public string PasswordHaveSpecialSymbol { get; set; }

        /// <summary>
        /// PasswordHaveUpperCase
        /// </summary>
        public string PasswordHaveUpperCase { get; set; }

        /// <summary>
        /// PasswordHaveLowerCase
        /// </summary>
        public string PasswordHaveLowerCase { get; set; }

        /// <summary>
        /// PasswordHaveNumber
        /// </summary>
        public string PasswordHaveNumber { get; set; }

        /// <summary>
        /// CanLoginFrom
        /// </summary>
        public string CanLoginFrom { get; set; }

        /// <summary>
        /// CanLoginTo
        /// </summary>
        public string CanLoginTo { get; set; }

        /// <summary>
        /// LockoutTthrs
        /// </summary>
        public int? LockoutTthrs { get; set; }
        /// <summary>
        /// SessionMode
        /// </summary>
        /// <value></value>
        public string SessionMode { get; set; }
    }
}