using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Jits.Neptune.Core;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class UserSessions : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Usrid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UsrBranch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UsrBranchid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Usrname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Txdt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ssesionid { get; set; }
        /// <summary>
        /// Usrid
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// Ssntime
        /// </summary>
        public DateTime Ssntime { get; set; }

        /// <summary>
        /// Exptime
        /// </summary>
        public DateTime Exptime { get; set; }

        /// <summary>
        /// Wsip
        /// </summary>
        public string Wsip { get; set; }

        /// <summary>
        /// Mac
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// Wsname
        /// </summary>
        public string Wsname { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Acttype
        /// </summary>
        public string Acttype { get; set; }

        /// <summary>
        /// Application code
        /// </summary>
        public string ApplicationCode { get; set; }

        /// <summary>
        /// Meta Info
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// CommandList
        /// </summary>
        public string CommandList { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// ResetPassword
        /// </summary>
        public bool ResetPassword { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserSessions()
        {
            Ssntime = System.DateTime.Now;
            Exptime = System.DateTime.Now;
            Ssesionid = string.Empty;
            Wsip = string.Empty;
            Mac = string.Empty;
            Wsname = string.Empty;
            Token = string.Empty;
            Acttype = "I";
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public UserSessions(int usrid, int usrBranchid, string usrBranch, string usrname, string sessionid, string lang, DateTime timelogin)
        //{
        //    Usrid = usrid;
        //    UsrBranch = usrBranch;
        //    UsrBranchid = usrBranchid;
        //    Usrname = usrname;
        //    Ssesionid = sessionid;
        //    Lang = lang;
        //    Txdt = timelogin;
        //}
    }
}