using System.Collections.Generic;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.Admin.Models
{
    /// <summary>
    /// MultiPhoneNumber
    /// </summary>
    public partial class MultiPhoneNumber : BaseNeptuneModel
    {
        /// <summary>
        /// Home
        /// </summary>
        [JsonProperty("home")]
        public string H { get; set; } = null;

        /// <summary>
        /// Office
        /// </summary>
        [JsonProperty("office")]
        public string O { get; set; } = null;

        /// <summary>
        /// Cell
        /// </summary>
        [JsonProperty("cell")]
        public string C { get; set; } = null;

        /// <summary>
        /// Facsimile
        /// </summary>
        [JsonProperty("facsimile")]
        public string F { get; set; } = null;

        /// <summary>
        /// Telex
        /// </summary>
        [JsonProperty("telex")]
        public string T { get; set; } = null;
    }

    /// <summary>
    /// MultiReferenceCode
    /// </summary>
    public partial class MultiReferenceCode : BaseNeptuneModel
    {
        /// <summary>
        /// Bic
        /// </summary>
        public string Bic { get; set; } = null;

        /// <summary>
        /// DomesticBankCode
        /// </summary>
        public string DomesticBankCode { get; set; } = null;

        /// <summary>
        /// InternalCode
        /// </summary>
        public string InternalCode { get; set; } = null;
    }

    /// <summary>
    /// Branch create model
    /// </summary>
    public partial class BranchCreateModel : BaseTransactionModel
    {

        /// <summary>
        /// branch create model constructor
        /// </summary>
        public BranchCreateModel()
        {
        }

        /// <summary>
        /// OldBranchId
        /// </summary>
        public string OldBranchId { get; set; }

        /// <summary>
        /// BranchCode (required by shwe)
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// IsGenerateBranchCode (required by shwe)
        /// </summary>
        public bool? IsGenerateBranchCode { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// BranchAddress
        /// </summary>
        public string BranchAddress { get; set; }

        /// <summary>
        /// BranchPhone
        /// </summary>
        public string BranchPhone { get; set; }

        /// <summary>
        /// Phone Number (Home, Office, Cell, Facsimile, Telex)
        /// </summary>
        public MultiPhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// tax code
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// bcycid
        /// </summary>
        public string BaseCurrencyCode { get; set; }

        /// <summary>
        /// lcycid
        /// </summary>
        public string LocalCurrencyCode { get; set; }

        /// <summary>
        /// Reference code (Bic, domestic bank code, internal code)
        /// </summary>
        public new MultiReferenceCode ReferenceCode { get; set; }

        /// <summary>
        /// country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Main anguage
        /// </summary>
        public string MainLanguage { get; set; }

        /// <summary>
        /// TimeZoneOfBranch
        /// </summary>
        public decimal TimeZoneOfBranch { get; set; }

        /// <summary>
        /// ThousandSeparateCharacter
        /// </summary>
        public string ThousandSeparateCharacter { get; set; }

        /// <summary>
        /// DecimalSeparateCharacter
        /// </summary>
        public string DecimalSeparateCharacter { get; set; }

        /// <summary>
        /// DateFormatForShort
        /// </summary>
        public string DateFormatForShort { get; set; }

        /// <summary>
        /// LongDateFormat
        /// </summary>
        public string LongDateFormat { get; set; }

        /// <summary>
        /// TimeFormat
        /// </summary>
        public string TimeFormat { get; set; }

        /// <summary>
        /// IsOnline
        /// </summary>
        public string IsOnline { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// BranchType
        /// </summary>
        public string BranchType { get; set; }
    }

    /// <summary>
    /// Branch delete model
    /// </summary>
    public partial class BranchDeleteModel : BaseTransactionModel
    {
        /// <summary>
        /// Branch delete model constructor
        /// </summary>
        public BranchDeleteModel()
        {
        }

        /// <summary>
        /// branch id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Branch search model
    /// </summary>
    public partial class BranchSearchModel : SearchBaseModel
    {
        /// <summary>
        /// Branch search model constructor
        /// </summary>
        public BranchSearchModel()
        {
            PageIndex = 0;
            PageSize = int.MaxValue;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int branchid { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcd { get; set; }

        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// Địa chỉ chi nhánh
        /// </summary>
        [JsonProperty("branch_address")]
        public string address { get; set; }

        /// <summary>
        /// Mã tiền tệ cơ bản
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string bcycid { get; set; }

        /// <summary>
        /// Trạng thái trực tuyến
        /// </summary>
        [JsonProperty("is_online")]
        public string isonline { get; set; }
    }

    /// <summary>
    /// Branch search response model
    /// </summary>
    public partial class BranchSearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int branchid { get; set; }

        /// <summary>
        /// Branch Code
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcd { get; set; }

        /// <summary>
        /// Branch Name
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// Branch Address
        /// </summary>
        [JsonProperty("branch_address")]
        public string address { get; set; }

        /// <summary>
        /// Base Currency Code
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string bcycid { get; set; }

        /// <summary>
        /// Is Online
        /// </summary>
        [JsonProperty("is_online")]
        public string isonline { get; set; }

        /// <summary>
        /// Branch Type
        /// </summary>
        [JsonProperty("branch_type")]
        public string BranchType { get; set; }
    }

    /// <summary>
    /// Branch search response model
    /// </summary>
    public partial class BranchRefreshResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        public string BranchPhone { get; set; }

        /// <summary>
        /// BranchAddress
        /// </summary>
        public string BranchAddress { get; set; }

        /// <summary>
        /// IsOnline
        /// </summary>
        public string IsOnline { get; set; }
    }

    /// <summary>
    /// Branch view response
    /// </summary>
    public partial class BranchViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int branchid { get; set; }

        /// <summary>
        /// Mã chi nhánh cũ
        /// </summary>
        [JsonProperty("old_branch_id")]
        public string refid { get; set; }

        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// Mã chi nhánh
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcd { get; set; }

        /// <summary>
        /// Địa chỉ chi nhánh
        /// </summary>
        [JsonProperty("branch_address")]
        public string address { get; set; }

        /// <summary>
        /// Số điện thoại chi nhánh
        /// </summary>
        [JsonProperty("branch_phone")]
        public string phone { get; set; }

        ///// <summary>
        ///// Số điện thoại
        ///// </summary>
        //[JsonProperty("phone_number")]
        //public MultiPhoneNumber mphone { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        [JsonProperty("tax_code")]
        public string taxcode { get; set; }

        /// <summary>
        /// Mã tiền tệ cơ bản
        /// </summary>
        [JsonProperty("base_currency_code")]
        public string bcycid { get; set; }

        /// <summary>
        /// Mã tiền tệ địa phương
        /// </summary>
        [JsonProperty("local_currency_code")]
        public string lcycid { get; set; }

        /// <summary>
        /// Mã số tham chiếu
        /// </summary>
        [JsonProperty("reference_code")]
        public MultiReferenceCode refcode { get; set; }

        /// <summary>
        /// Quốc gia
        /// </summary>
        [JsonProperty("country")]
        public string country { get; set; }

        /// <summary>
        /// Ngôn ngữ chính
        /// </summary>
        [JsonProperty("main_language")]
        public string lang { get; set; }

        /// <summary>
        /// Múi giờ của chi nhánh
        /// </summary>
        [JsonProperty("time_zone_of_branch")]
        public decimal timezn { get; set; }

        /// <summary>
        /// Ký tự ngăn cách hàng nghìn
        /// </summary>
        [JsonProperty("thousand_separate_character")]
        public string numfmtt { get; set; }

        /// <summary>
        /// Ký tự ngăn cách thập phân
        /// </summary>
        [JsonProperty("decimal_separate_character")]
        public string numfmtd { get; set; }

        /// <summary>
        /// Định dạng ngày tháng ngắn
        /// </summary>
        [JsonProperty("date_format_for_short")]
        public string datefmt { get; set; }

        /// <summary>
        /// Định dạng ngày tháng dài
        /// </summary>
        [JsonProperty("long_date_format")]
        public string ldatefmt { get; set; }

        /// <summary>
        /// Định dạng thời gian
        /// </summary>
        [JsonProperty("time_format")]
        public string timefmt { get; set; }

        /// <summary>
        /// Trạng thái trực tuyến
        /// </summary>
        [JsonProperty("is_online")]
        public string isonline {get; set; }

        /// <summary>
        /// Vùng
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Loại chi nhánh
        /// </summary>
        [JsonProperty("branch_type")]
        public string BranchType { get; set; }
    }

    /// <summary>
    /// branch update model
    /// </summary>
    public partial class BranchUpdateModel : BaseTransactionModel
    {
        /// <summary>
        /// Branch id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// OldBranchId
        /// </summary>
        public string OldBranchId { get; set; }

        /// <summary>
        /// BranchName
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// BranchAddress
        /// </summary>
        public string BranchAddress { get; set; }

        /// <summary>
        /// BranchPhone
        /// </summary>
        public string BranchPhone { get; set; }

        /// <summary>
        /// Phone Number (Home, Office, Cell, Facsimile, Telex)
        /// </summary>
        public MultiPhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// tax code
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// bcycid
        /// </summary>
        public string BaseCurrencyCode { get; set; }

        /// <summary>
        /// lcycid
        /// </summary>
        public string LocalCurrencyCode { get; set; }

        /// <summary>
        /// Reference code (Bic, domestic bank code, internal code)
        /// </summary>
        public new MultiReferenceCode ReferenceCode { get; set; }

        /// <summary>
        /// country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Main anguage
        /// </summary>
        public string MainLanguage { get; set; }

        /// <summary>
        /// TimeZoneOfBranch
        /// </summary>
        public decimal TimeZoneOfBranch { get; set; }

        /// <summary>
        /// ThousandSeparateCharacter
        /// </summary>
        public string ThousandSeparateCharacter { get; set; }

        /// <summary>
        /// DecimalSeparateCharacter
        /// </summary>
        public string DecimalSeparateCharacter { get; set; }

        /// <summary>
        /// DateFormatForShort
        /// </summary>
        public string DateFormatForShort { get; set; }

        /// <summary>
        /// LongDateFormat
        /// </summary>
        public string LongDateFormat { get; set; }

        /// <summary>
        /// TimeFormat
        /// </summary>
        public string TimeFormat { get; set; }

        /// <summary>
        /// IsOnline
        /// </summary>
        public string IsOnline { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// BranchType
        /// </summary>
        public string BranchType { get; set; }
    }
    /// <summary>
    /// GetListUserBranch
    /// </summary>
    public partial class GetListUserBranch : BaseTransactionModel
    {

        /// <summary>
        /// BranchCode
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; } = 0;

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;
    }

    /// <summary>
    /// Use for Open / Close Branch 
    /// </summary>
    public partial class BranchIdModel : BaseTransactionModel
    {
        /// <summary>
        /// Branch Id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// GetInfoBranchId
    /// </summary>
    public class GetInfoBranchId : BaseTransactionModel
    {
        /// <summary>
        /// AccountNumber
        /// </summary>
        public string AccountNumber { get; set; }
    }

    /// <summary>
    /// Get Region Model
    /// </summary>
    public partial class GetRegionModel : BaseTransactionModel
    {

        /// <summary>
        /// Branch code
        /// </summary>
        public string BranchCode { get; set; } = string.Empty;

        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class DepositCheckPendingTransactionModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel deposit_account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel overdraft_modify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel overdraft { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel deposit_account_modify { get; set; }

    }

    /// <summary>
    /// Model for checking pending transactions in Credit.
    /// </summary>
    public partial class CreditCheckPendingTransactionModel : BaseNeptuneModel
    {
        /// <summary>
        /// Indicates if there are pending transactions in Credit accounts.
        /// </summary>
        public CheckPendingTransactionModel credit_account { get; set; }

        /// <summary>
        /// Indicates if there are pending transactions in Credit account modifications.
        /// </summary>
        public CheckPendingTransactionModel credit_approve_account { get; set; }

        /// <summary>
        /// Indicates if there are pending transactions in Credit product limits.
        /// </summary>
        public CheckPendingTransactionModel product_limit { get; set; }

        /// <summary>
        /// Indicates if there are pending transactions in Credit sub-product limits.
        /// </summary>
        public CheckPendingTransactionModel sub_product_limit { get; set; }
    }

    /// <summary>
    /// Model for checking pending transactions in Customer.
    /// </summary>
    public partial class CustomerCheckPendingTransactionModel : BaseNeptuneModel
    {
        /// <summary>
        /// I
        /// </summary>
        public CheckPendingTransactionModel single_customer { get; set; }

        /// <summary>
        /// </summary>
        public CheckPendingTransactionModel customer_approve { get; set; }

        /// <summary>
        /// </summary>
        public CheckPendingTransactionModel linkage_approve { get; set; }

        /// <summary>
        /// </summary>
        public CheckPendingTransactionModel group_approve { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel customer_media { get; set; }
    }

    /// <summary>
    /// Model for checking pending transactions in Mortgage.
    /// </summary>
    public partial class MortgageCheckPendingTransactionModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel mortgage_account { get; set; }
    }

    /// <summary>
    /// Model for checking pending transactions in Foreign Exchange.
    /// </summary>
    public partial class FxCheckPendingTransactionModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CheckPendingTransactionModel foreign_exchange { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CheckPendingTransactionModel : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public bool is_valid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int line_count { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CloseBranchModel : BaseTransactionModel
    {

        /// <summary>
        /// Branch code
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Region
        /// </summary>
        public string BranchCode { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DepositCheckPendingTransactionModel Deposit { get; set; } = new DepositCheckPendingTransactionModel();
        /// <summary>
        /// 
        /// </summary>
        public CreditCheckPendingTransactionModel Credit { get; set; } = new CreditCheckPendingTransactionModel();
        /// <summary>
        /// 
        /// </summary>
        public CustomerCheckPendingTransactionModel Customer { get; set; } = new CustomerCheckPendingTransactionModel();
        /// <summary>
        /// 
        /// </summary>
        public MortgageCheckPendingTransactionModel Mortgage { get; set; } = new MortgageCheckPendingTransactionModel();
        /// <summary>
        /// 
        /// </summary>
        public FxCheckPendingTransactionModel Fx { get; set; } = new FxCheckPendingTransactionModel();
        /// <summary>
        /// 
        /// </summary>
        public List<string> Import { get; set; } = new List<string>();

    }
}