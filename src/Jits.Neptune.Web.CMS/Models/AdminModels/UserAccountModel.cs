using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.Admin.Models
{
    /// <summary>
    /// MultiPosition
    /// </summary>
    public partial class MultiPosition : BaseNeptuneModel
    {
        /// <summary>
        /// Cashier
        /// </summary>
        [JsonProperty("cashier")]
        public int? C { get; set; } = 0;

        /// <summary>
        /// Officer
        /// </summary>
        [JsonProperty("officer")]
        public int? O { get; set; } = 0;

        /// <summary>
        /// ChiefCashier
        /// </summary>
        [JsonProperty("chief_cashier")]
        public int? I { get; set; } = 0;

        /// <summary>
        /// OperationStaff
        /// </summary>
        [JsonProperty("operation_staff")]
        public int? S { get; set; } = 0;

        /// <summary>
        /// Dealer
        /// </summary>
        [JsonProperty("dealer")]
        public int? D { get; set; } = 0;
    }

    /// <summary>
    /// User account create model
    /// </summary>
    public partial class UserAccountCreateModel : BaseNeptuneModel
    {

        /// <summary>
        /// Mã người dùng
        /// </summary>
        [JsonProperty("user_code")]
        public string usrcd { get; set; }

        /// <summary>
        /// Mã người dùng cũ
        /// </summary>
        [JsonProperty("old_user_code")]
        public string urefid { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        [JsonProperty("user_name")]
        public string usrname { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [JsonProperty("login_name")]
        public string lgname { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_id")]
        public int? deprtid { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        [JsonProperty("position")]
        public MultiPosition position { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [JsonProperty("remark")]
        public string remark { get; set; }

        /// <summary>
        /// Trạng thái tài khoản người dùng
        /// </summary>
        [JsonProperty("user_account_status")]
        public string status { get; set; }

        /// <summary>
        /// Đặt lại mật khẩu
        /// </summary>
        [JsonProperty("reset_password")]
        public string pwdstr { get; set; }

        /// <summary>
        /// Ngôn ngữ chính
        /// </summary>
        [JsonProperty("main_language")]
        public string lang { get; set; }

        /// <summary>
        /// Số điện thoại người dùng
        /// </summary>
        [JsonProperty("user_phone")]
        public string phone { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        [JsonProperty("phone_number")]
        public MultiPhoneNumber mphone { get; set; }

        /// <summary>
        /// Múi giờ
        /// </summary>
        [JsonProperty("time_zone")]
        public decimal? timezn { get; set; }

        /// <summary>
        /// Ký tự phân cách hàng nghìn
        /// </summary>
        [JsonProperty("thousand_separate_character")]
        public string numfmtt { get; set; }

        /// <summary>
        /// Ký tự phân cách thập phân
        /// </summary>
        [JsonProperty("decimal_separate_character")]
        public string numfmtd { get; set; }

        /// <summary>
        /// Định dạng ngày
        /// </summary>
        [JsonProperty("date_format")]
        public string datefmt { get; set; }

        /// <summary>
        /// Định dạng ngày dài
        /// </summary>
        [JsonProperty("long_date_format")]
        public string ldatefmt { get; set; }

        /// <summary>
        /// Định dạng thời gian
        /// </summary>
        [JsonProperty("time_format")]
        public string timefmt { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        [JsonProperty("expire_date")]
        //[DataFormat("dd/MM/yyyy")]
        public DateTime? expdt { get; set; }

        /// <summary>
        /// Id của chính sách
        /// </summary>
        [JsonProperty("policy_id")]
        public int? policyid { get; set; }

        /// <summary>
        /// Người dùng có thể thay đổi mật khẩu hay không
        /// </summary>
        [JsonProperty("user_can_change_password")]
        public string pwdchg { get; set; }

        /// <summary>
        /// Mật khẩu không bao giờ hết hạn
        /// </summary>
        [JsonProperty("password_never_expire")]
        public string pwdexp { get; set; }

        /// <summary>
        /// Đổi mật khẩu khi đăng nhập
        /// </summary>
        [JsonProperty("change_password_when_login")]
        public string pwdchgr { get; set; }

        /// <summary>
        /// Yêu cầu về độ phức tạp của mật khẩu
        /// </summary>
        [JsonProperty("password_complexity_requirements")]
        public string pwdcplx { get; set; }

        /// <summary>
        /// Thời gian khóa tài khoản (phút)
        /// </summary>
        [JsonProperty("lockout_dur")]
        public int? lkoutdur { get; set; }

        /// <summary>
        /// Số lần thử sai trước khi khóa tài khoản
        /// </summary>
        [JsonProperty("lockout_tthrs")]
        public int? lkoutthrs { get; set; }

        /// <summary>
        /// Đặt lại khóa tài khoản sau (phút)
        /// </summary>
        [JsonProperty("reset_lockout")]
        public int? resetlkout { get; set; }
    }

    /// <summary>
    /// User account create model
    /// </summary>
    public partial class UserAccountCreateRequestModel : BaseNeptuneModel
    {

        /// <summary>
        /// Mã người dùng
        /// </summary>
        [JsonProperty("user_code")]
        public string usrcd { get; set; }

        /// <summary>
        /// Mã người dùng cũ
        /// </summary>
        [JsonProperty("old_user_code")]
        public string urefid { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        [JsonProperty("user_name")]
        public string usrname { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [JsonProperty("login_name")]
        public string lgname { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_id")]
        public int? deprtid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("position")]
        public JObject MultiPosition { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [JsonProperty("remark")]
        public string remark { get; set; }

        /// <summary>
        /// Trạng thái tài khoản người dùng
        /// </summary>
        [JsonProperty("user_account_status")]
        public string status { get; set; }

        /// <summary>
        /// Đặt lại mật khẩu
        /// </summary>
        [JsonProperty("reset_password")]
        public string pwdstr { get; set; }

        /// <summary>
        /// Ngôn ngữ chính
        /// </summary>
        [JsonProperty("main_language")]
        public string lang { get; set; }

        /// <summary>
        /// Số điện thoại người dùng
        /// </summary>
        [JsonProperty("user_phone")]
        public string phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("phone_number")]
        public JObject MultiPhone { get; set; }

        /// <summary>
        /// Múi giờ
        /// </summary>
        [JsonProperty("time_zone")]
        public decimal? timezn { get; set; }

        /// <summary>
        /// Ký tự phân cách hàng nghìn
        /// </summary>
        [JsonProperty("thousand_separate_character")]
        public string numfmtt { get; set; }

        /// <summary>
        /// Ký tự phân cách thập phân
        /// </summary>
        [JsonProperty("decimal_separate_character")]
        public string numfmtd { get; set; }

        /// <summary>
        /// Định dạng ngày
        /// </summary>
        [JsonProperty("date_format")]
        public string datefmt { get; set; }

        /// <summary>
        /// Định dạng ngày dài
        /// </summary>
        [JsonProperty("long_date_format")]
        public string ldatefmt { get; set; }

        /// <summary>
        /// Định dạng thời gian
        /// </summary>
        [JsonProperty("time_format")]
        public string timefmt { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        [JsonProperty("expire_date")]
        //[DataFormat("dd/MM/yyyy")]
        public DateTime? expdt { get; set; }

        /// <summary>
        /// Id của chính sách
        /// </summary>
        [JsonProperty("policy_id")]
        public int? policyid { get; set; }

        /// <summary>
        /// Người dùng có thể thay đổi mật khẩu hay không
        /// </summary>
        [JsonProperty("user_can_change_password")]
        public string pwdchg { get; set; }

        /// <summary>
        /// Mật khẩu không bao giờ hết hạn
        /// </summary>
        [JsonProperty("password_never_expire")]
        public string pwdexp { get; set; }

        /// <summary>
        /// Đổi mật khẩu khi đăng nhập
        /// </summary>
        [JsonProperty("change_password_when_login")]
        public string pwdchgr { get; set; }

        /// <summary>
        /// Yêu cầu về độ phức tạp của mật khẩu
        /// </summary>
        [JsonProperty("password_complexity_requirements")]
        public string pwdcplx { get; set; }

        /// <summary>
        /// Thời gian khóa tài khoản (phút)
        /// </summary>
        [JsonProperty("lockout_dur")]
        public int? lkoutdur { get; set; }

        /// <summary>
        /// Số lần thử sai trước khi khóa tài khoản
        /// </summary>
        [JsonProperty("lockout_tthrs")]
        public int? lkoutthrs { get; set; }

        /// <summary>
        /// Đặt lại khóa tài khoản sau (phút)
        /// </summary>
        [JsonProperty("reset_lockout")]
        public int? resetlkout { get; set; }
    }

    /// <summary>
    /// User account delete model
    /// </summary>
    public partial class UserAccountDeleteModel : BaseTransactionModel
    {
        /// <summary>
        /// user account dafault id
        /// </summary>
        public int Id { get; set; }
    }


    /// <summary>
    /// User account search model
    /// </summary>
    public partial class UserAccountSearchModel : SearchBaseModel
    {
        /// <summary>
        /// UserCode
        /// </summary>
        [JsonProperty("user_code")]
        public string usrcd { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [JsonProperty("user_name")]
        public string usrname { get; set; }

        /// <summary>
        /// LoginName
        /// </summary>
        [JsonProperty("login_name")]
        public string lgname { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }

        /// <summary>
        /// DepartmentName
        /// </summary>
        [JsonProperty("department_name")]
        public string deprname { get; set; }

        /// <summary>
        /// DepartmentCode
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// UserAccountStatus
        /// </summary>
        [JsonProperty("user_account_status")]
        public string status { get; set; }

        /// <summary>
        /// IsOnline
        /// </summary>
        [JsonProperty("is_online")]
        public string isonline { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        ///// <summary>
        ///// PageIndex
        ///// </summary>
        //public int PageIndex { get; set; } = 0;

        ///// <summary>
        ///// PageSize
        ///// </summary>
        //public int PageSize { get; set; } = int.MaxValue;
    }

    /// <summary>
    /// UserAccountSearchResponseModel
    /// </summary>
    public partial class UserAccountSearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int usrid { get; set; }

        /// <summary>
        /// UserCode
        /// </summary>
        [JsonProperty("user_code")]
        public string usrcd { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [JsonProperty("user_name")]
        public string usrname { get; set; }

        /// <summary>
        /// LoginName
        /// </summary>
        [JsonProperty("login_name")]
        public string lgname { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }

        /// <summary>
        /// DepartmentName
        /// </summary>
        [JsonProperty("department_name")]
        public string deprname { get; set; }

        /// <summary>
        /// DepartmentCode
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// UserAccountStatus
        /// </summary>
        [JsonProperty("user_account_status")]
        public string status { get; set; }

        /// <summary>
        /// IsOnline
        /// </summary>
        [JsonProperty("is_online")]
        public string isonline { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// UserAccountSearchResponseModel
    /// </summary>
    public partial class GetListUserAtBranch : BaseNeptuneModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public string UserAccountStatus { get; set; }
    }

    /// <summary>
    /// User account view response
    /// </summary>
    public partial class UserAccountViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int usrid { get; set; }

        /// <summary>
        /// Mã người dùng
        /// </summary>
        [JsonProperty("user_code")]
        public string usrcd { get; set; }

        /// <summary>
        /// Mã người dùng cũ
        /// </summary>
        [JsonProperty("old_user_code")]
        public string urefid { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        [JsonProperty("user_name")]
        public string usrname { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [JsonProperty("login_name")]
        public string lgname { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_id")]
        public int? deprtid { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        [JsonProperty("position")]
        public MultiPosition position { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [JsonProperty("remark")]
        public string remark { get; set; }

        /// <summary>
        /// Trạng thái tài khoản người dùng
        /// </summary>
        [JsonProperty("user_account_status")]
        public string status { get; set; }

        /// <summary>
        /// Đặt lại mật khẩu
        /// </summary>
        [JsonProperty("reset_password")]
        public string pwdstr { get; set; }

        /// <summary>
        /// Ngôn ngữ chính
        /// </summary>
        [JsonProperty("main_language")]
        public string lang { get; set; }

        /// <summary>
        /// Số điện thoại người dùng
        /// </summary>
        [JsonProperty("user_phone")]
        public string phone { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        [JsonProperty("phone_number")]
        public MultiPhoneNumber mphone { get; set; }

        /// <summary>
        /// Múi giờ
        /// </summary>
        [JsonProperty("time_zone")]
        public decimal? timezn { get; set; }

        /// <summary>
        /// Ký tự phân cách hàng nghìn
        /// </summary>
        [JsonProperty("thousand_separate_character")]
        public string numfmtt { get; set; }

        /// <summary>
        /// Ký tự phân cách thập phân
        /// </summary>
        [JsonProperty("decimal_separate_character")]
        public string numfmtd { get; set; }

        /// <summary>
        /// Định dạng ngày
        /// </summary>
        [JsonProperty("date_format")]
        public string datefmt { get; set; }

        /// <summary>
        /// Định dạng ngày dài
        /// </summary>
        [JsonProperty("long_date_format")]
        public string ldatefmt { get; set; }

        /// <summary>
        /// Định dạng thời gian
        /// </summary>
        [JsonProperty("time_format")]
        public string timefmt { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        [JsonProperty("expire_date")]
        public DateTime? expdt { get; set; }

        /// <summary>
        /// Id của chính sách
        /// </summary>
        [JsonProperty("policy_id")]
        public int? policyid { get; set; }

        /// <summary>
        /// Người dùng có thể thay đổi mật khẩu hay không
        /// </summary>
        [JsonProperty("user_can_change_password")]
        public string pwdchg { get; set; }

        /// <summary>
        /// Mật khẩu không bao giờ hết hạn
        /// </summary>
        [JsonProperty("password_never_expire")]
        public string pwdexp { get; set; }

        /// <summary>
        /// Đổi mật khẩu khi đăng nhập
        /// </summary>
        [JsonProperty("change_password_when_login")]
        public string pwdchgr { get; set; }

        /// <summary>
        /// Yêu cầu về độ phức tạp của mật khẩu
        /// </summary>
        [JsonProperty("password_complexity_requirements")]
        public string pwdcplx { get; set; }

        /// <summary>
        /// Thời gian khóa tài khoản (phút)
        /// </summary>
        [JsonProperty("lockout_dur")]
        public int? lkoutdur { get; set; }

        /// <summary>
        /// Số lần thử sai trước khi khóa tài khoản
        /// </summary>
        [JsonProperty("lockout_tthrs")]
        public int? lkoutthrs { get; set; }

        /// <summary>
        /// Đặt lại khóa tài khoản sau (phút)
        /// </summary>
        [JsonProperty("reset_lockout")]
        public int? resetlkout { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }

    /// <summary>
    /// User account update model
    /// </summary>
    public partial class UserAccountUpdateModel : BaseTransactionModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int usrid { get; set; }

        /// <summary>
        /// Mã người dùng
        /// </summary>
        [JsonProperty("user_code")]
        public string usrcd { get; set; }

        /// <summary>
        /// Mã người dùng cũ
        /// </summary>
        [JsonProperty("old_user_code")]
        public string urefid { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        [JsonProperty("user_name")]
        public string usrname { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [JsonProperty("login_name")]
        public string lgname { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_id")]
        public int branchid { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonProperty("department_id")]
        public int? deprtid { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        [JsonProperty("position")]
        public MultiPosition position { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [JsonProperty("remark")]
        public string remark { get; set; }

        /// <summary>
        /// Trạng thái tài khoản người dùng
        /// </summary>
        [JsonProperty("user_account_status")]
        public string status { get; set; }

        /// <summary>
        /// Đặt lại mật khẩu
        /// </summary>
        [JsonProperty("reset_password")]
        public string pwdstr { get; set; }

        /// <summary>
        /// Ngôn ngữ chính
        /// </summary>
        [JsonProperty("main_language")]
        public string lang { get; set; }

        /// <summary>
        /// Số điện thoại người dùng
        /// </summary>
        [JsonProperty("user_phone")]
        public string phone { get; set; }

        /// <summary>
        /// PhoneNumber
        /// </summary>
        [JsonProperty("phone_number")]
        public MultiPhoneNumber mphone { get; set; }

        /// <summary>
        /// Múi giờ
        /// </summary>
        [JsonProperty("time_zone")]
        public decimal? timezn { get; set; }

        /// <summary>
        /// Ký tự phân cách hàng nghìn
        /// </summary>
        [JsonProperty("thousand_separate_character")]
        public string numfmtt { get; set; }

        /// <summary>
        /// Ký tự phân cách thập phân
        /// </summary>
        [JsonProperty("decimal_separate_character")]
        public string numfmtd { get; set; }

        /// <summary>
        /// Định dạng ngày
        /// </summary>
        [JsonProperty("date_format")]
        public string datefmt { get; set; }

        /// <summary>
        /// Định dạng ngày dài
        /// </summary>
        [JsonProperty("long_date_format")]
        public string ldatefmt { get; set; }

        /// <summary>
        /// Định dạng thời gian
        /// </summary>
        [JsonProperty("time_format")]
        public string timefmt { get; set; }

        /// <summary>
        /// Ngày hết hạn
        /// </summary>
        [JsonProperty("expire_date")]
        public DateTime? expdt { get; set; }

        /// <summary>
        /// Id của chính sách
        /// </summary>
        [JsonProperty("policy_id")]
        public int? policyid { get; set; }

        /// <summary>
        /// Người dùng có thể thay đổi mật khẩu hay không
        /// </summary>
        [JsonProperty("user_can_change_password")]
        public string pwdchg { get; set; }

        /// <summary>
        /// Mật khẩu không bao giờ hết hạn
        /// </summary>
        [JsonProperty("password_never_expire")]
        public string pwdexp { get; set; }

        /// <summary>
        /// Đổi mật khẩu khi đăng nhập
        /// </summary>
        [JsonProperty("change_password_when_login")]
        public string pwdchgr { get; set; }

        /// <summary>
        /// Yêu cầu về độ phức tạp của mật khẩu
        /// </summary>
        [JsonProperty("password_complexity_requirements")]
        public string pwdcplx { get; set; }

        /// <summary>
        /// Thời gian khóa tài khoản (phút)
        /// </summary>
        [JsonProperty("lockout_dur")]
        public int? lkoutdur { get; set; }

        /// <summary>
        /// Số lần thử sai trước khi khóa tài khoản
        /// </summary>
        [JsonProperty("lockout_tthrs")]
        public int? lkoutthrs { get; set; }

        /// <summary>
        /// Đặt lại khóa tài khoản sau (phút)
        /// </summary>
        [JsonProperty("reset_lockout")]
        public int? resetlkout { get; set; }
    }

    /// <summary>
    /// UserAccountExtendedViewResponseModel
    /// </summary>
    public partial class UserAccountExtendedViewResponseModel : UserAccountViewResponseModel
    {
    }

    /// <summary>
    /// UserAccountExtendedViewResponseModel
    /// </summary>
    public partial class UpdateUserNameAndAvatarModel : BaseTransactionModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Avatar
        /// </summary>
        public string Avatar { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UserAccountSyncADModel : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserAccountSearchResponseModel> ListUsersAddNew { get; set; } = new List<UserAccountSearchResponseModel>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserAccountSearchResponseModel> ListUsersClose { get; set; } = new List<UserAccountSearchResponseModel>();


    }
}