using Newtonsoft.Json;
using System;

namespace Jits.Neptune.Web.CMS.Models.O9Model.ResponseToCMS
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginResponseToCMSModel
    {
        /// <summary>
        /// 
        /// </summary>
        public LoginResponse login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class LoginResponse
        {
            /// <summary>
            /// user id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// user code
            /// </summary>
            public string user_code { get; set; }
            /// <summary>
            /// user name
            /// </summary>
            public string user_name { get; set; }
            /// <summary>
            /// login name
            /// </summary>
            public string login_name { get; set; }
            /// <summary>
            /// token
            /// </summary>
            public string token { get; set; }
            /// <summary>
            /// working date
            /// </summary>
            public DateTime working_date { get; set; }
            /// <summary>
            /// branch id
            /// </summary>
            public int branch_id { get; set; }
            /// <summary>
            /// branch code
            /// </summary>
            public string branch_code { get; set; }
            /// <summary>
            /// branch name
            /// </summary>
            public string branch_name { get; set; }
            /// <summary>
            /// department code
            /// </summary>
            public string department_code { get; set; }
            /// <summary>
            /// region
            /// </summary>
            public string region { get; set; }
            /// <summary>
            /// position
            /// </summary>
            public Position position { get; set; }
            /// <summary>
            /// branch status
            /// </summary>
            public string branch_status { get; set; }
            /// <summary>
            /// bank status
            /// </summary>
            public string bank_status { get; set; }
            /// <summary>
            /// reset password
            /// </summary>
            public bool reset_password { get; set; } = false;
            /// <summary>
            /// working date
            /// </summary>
            public DateTime expire_time { get; set; }
            /// <summary>
            /// avatar
            /// </summary>
            public string avatar { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public class Position
            {
                /// <summary>
                /// cashier
                /// </summary>
                public int cashier { get; set; }
                /// <summary>
                /// officer
                /// </summary>
                public int officer { get; set; }
                /// <summary>
                /// chief_cashier
                /// </summary>
                public int chief_cashier { get; set; }
                /// <summary>
                /// operation_staff
                /// </summary>
                public int operation_staff { get; set; }
                /// <summary>
                /// dealer
                /// </summary>
                public int dealer { get; set; }
                /// <summary>
                /// inter_branch_user
                /// </summary>
                public int inter_branch_user { get; set; }
                /// <summary>
                /// branch_manager
                /// </summary>
                public int branch_manager { get; set; }
            }
        }
    }
}
