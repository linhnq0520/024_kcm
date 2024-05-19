#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null

// Jits.Neptune.Web.Framework.dll

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleSearchCustomerProfileRequest : BaseNeptuneModel
    {

        /// <summary>
        /// Gets or sets the value of the customer_code
        /// </summary>
        [JsonProperty("customer_code")]
        public string customercd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("fullname")]
        public string fullname { get; set; }

        /// <summary>
        /// Gets or sets the value of the catalog status
        /// </summary>
        [JsonProperty("paper_number")]
        public string repid { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("day_of_birth")]
        public DateTime? day_of_birth { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        //[JsonProperty("day_of_birth")]
        public string dob { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("gender")]
        public string gender { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit type
        /// </summary>credit_type
        [JsonProperty("customer_status")]
        public string ctmsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("nation")]
        public string nation { get; set; }

        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("address")]
        public string adress { get; set; }

        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("classification")]
        public string classify { get; set; }

        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("approve_status")]
        public string aprsts { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("oprtval_dob")]
        public string oprtval_dob { get; set; }

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
    /// 
    /// </summary>
    public class AdvanceSearchCustomerLinkageRequest : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the customer_code
        /// </summary>
        [JsonProperty("linkage_code")]
        public string lkgcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("master_customer_code")]
        public string mcustomercd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catalog status
        /// </summary>
        [JsonProperty("master_customer_name")]
        public string mfullname { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_description")]
        public string lkgdsc { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("oprtval_lkgline")]
        public string oprtval_lkgline { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("linkage_credit_line_to")]
        public decimal? lkgline { get; set; }

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
    /// 
    /// </summary>
    public class AdvanceSearchCustomerGroupRequest : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the customer_code
        /// </summary>
        [JsonProperty("group_code")]
        public string grpcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("group_name")]
        public string grpname { get; set; }

        /// <summary>
        /// Gets or sets the value of the catalog status
        /// </summary>
        [JsonProperty("group_type")]
        public string grptype { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("purpose")]
        public string purpose { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("desc")]
        public string descr { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("group_leader")]
        public string GroupLeader { get; set; }

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
    /// 
    /// </summary>
    public class ViewWithCustomerId : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("id")]
        public int CUSTOMERID { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ViewWithCustomerIdString : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("CUSTOMERID")]
        public string CUSTOMERID { get; set; }
    }
    /// <summary>
    /// CustomerMediaSearchModel
    /// </summary>
    public partial class CustomerMediaSearchModel : BaseTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerMediaSearchModel() { }

        /// <summary>
        /// CUSTOMERID -> customercode
        /// </summary>
        [JsonProperty("customer_code")]
        public string customercd { get; set; }
        /// <summary>
        /// MDNAME
        /// </summary>
        [JsonProperty("media_name")]
        public string mdname { get; set; }
        /// <summary>
        /// MDTYPE
        /// </summary>
        [JsonProperty("media_type")]
        public string mdtype { get; set; }
        /// <summary>
        /// EXPDT
        /// </summary>
        [JsonProperty("expire_date")]
        public DateTime? expire_date { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        public string expdt { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("oprtval_expdt")]
        public string oprtval_expdt { get; set; }
        /// <summary>
        /// OTHER
        /// </summary>
        [JsonProperty("other")]
        public string other { get; set; }
        /// <summary>
        /// MEDIASTS
        /// </summary>
        [JsonProperty("status")]
        public string caption { get; set; }
        /// <summary>
        /// OPNDT
        /// </summary>
        [JsonProperty("open_date")]
        public DateTime? open_date { get; set; }
        /// <summary>
        /// OPNDT
        /// </summary>
        public string opndt { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("oprtval_opndt")]
        public string oprtval_opndt { get; set; }
        /// <summary>
        /// LASTDT
        /// </summary>
        [JsonProperty("last_update_date")]
        public DateTime? last_update_date { get; set; }
        /// <summary>
        /// OPNDT
        /// </summary>
        public string lastdt { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("oprtval_lastdt")]
        public string oprtval_lastdt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;
    }

    /// <summary>
    /// CustomerViewResponseModel
    /// </summary>
    public partial class CustomerInsertRequestModel : BaseNeptuneModel
    {
        /// <summary>
        /// CustomerViewResponseModel
        /// </summary>
        public CustomerInsertRequestModel() { }
        ///// <summary>
        ///// CUSTOMERID
        ///// </summary>
        //[JsonProperty("id")]
        //public int? CUSTOMERID { get; set; }
        ///// <summary>
        ///// CUSTOMERCD
        ///// </summary>
        //[JsonProperty("customer_code")]
        //public string CUSTOMERCD { get; set; }
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("fullname")]
        public string FULLNAME { get; set; }
        /// <summary>
        /// CPRIVATE
        /// </summary>
        [JsonProperty("customer_private")]
        public string CPRIVATE { get; set; }
        /// <summary>
        /// mname
        /// </summary>
        [JsonProperty("customer_name")]
        public CustomerNameModel MNAME { get; set; } = new CustomerNameModel();
        /// <summary>
        /// SHORTNAME
        /// </summary>
        [JsonProperty("shortname")]
        public string SHORTNAME { get; set; }
        /// <summary>
        /// TITLE
        /// </summary>
        [JsonProperty("title")]
        public string TITLE { get; set; }
        /// <summary>
        /// FANAME
        /// </summary>
        [JsonProperty("reference_name")]
        public string FANAME { get; set; }
        /// <summary>
        /// SHORTID
        /// </summary>
        [JsonProperty("customer_short_id")]
        public string SHORTID { get; set; }
        /// <summary>
        /// COMPANY
        /// </summary>
        [JsonProperty("company")]
        public string COMPANY { get; set; }
        ///// <summary>
        ///// INCOME
        ///// </summary>
        //[JsonProperty("income")]
        //public decimal? INCOME { get; set; } 
        ///// <summary>
        ///// DOB
        ///// </summary>
        //[JsonProperty("date_of_birth")]
        ////[DataFormat("dd/MM/yyyy")]
        //public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// DOB
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DOB { get; set; }
        /// <summary>
        /// ANNIVERSARY
        /// </summary>
        [JsonProperty("anniversary")]
        public AnniversaryModelRequest ANNIVERSARY { get; set; } = new AnniversaryModelRequest();

        /// <summary>
        /// Mphone
        /// </summary>
        [JsonProperty("primary_phone")]
        public PhoneModel MPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// REFCODE
        /// </summary>
        [JsonProperty("reference_code")]
        public ReferenceCodeModel REFCODE { get; set; } = new ReferenceCodeModel();
        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email_address")]
        public string EMAIL { get; set; }
        /// <summary>
        /// mEmail
        /// </summary>
        [JsonProperty("other_email_address")]
        public OtherEmailAddressModel MEMAIL { get; set; } = new OtherEmailAddressModel();
        /// <summary>
        /// webaddr
        /// </summary>
        [JsonProperty("web_address")]
        public string WEBADDR { get; set; }
        /// <summary>
        /// repinfo
        /// </summary>
        [JsonProperty("representative_information")]
        public RepresentativeInformationModel REPINFO { get; set; } = new RepresentativeInformationModel();
        /// <summary>
        /// Repid
        /// </summary>
        [JsonProperty("paper_number")]
        public string REPID { get; set; }
        /// <summary>
        /// Repidtype
        /// </summary>
        [JsonProperty("paper_type")]
        public string REPIDTYPE { get; set; }
        ///// <summary>
        ///// Iddt
        ///// </summary>
        //[JsonProperty("issue_date_of_paper")]
        //public DateTime? IssueDateOfPaper { get; set; }
        /// <summary>
        /// Iddt
        /// </summary>
        /// 
        [JsonProperty("issue_date_of_paper")]
        public string IDDT { get; set; }
        /// <summary>
        /// Idplace
        /// </summary>
        [JsonProperty("issue_place_of_paper")]
        public string IDPLACE { get; set; }
        ///// <summary>
        ///// Idexpdt
        ///// </summary>
        //[JsonProperty("expire_date_of_paper")]
        //public DateTime? ExpireDateOfPaper { get; set; }
        /// <summary>
        /// Idexpdt
        /// </summary>
        /// 
        [JsonProperty("expire_date_of_paper")]
        public string IDEXPDT { get; set; }
        /// <summary>
        /// Nation
        /// </summary>
        [JsonProperty("nation")]
        public string NATION { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string COUNTRY { get; set; }
        /// <summary>
        /// Religion
        /// </summary>
        [JsonProperty("religion")]
        public string RELIGION { get; set; }
        /// <summary>
        /// Mainlang
        /// </summary>
        [JsonProperty("mainlang")]
        public string MAINLANG { get; set; }
        /// <summary>
        /// Sublang
        /// </summary>
        [JsonProperty("sublang")]
        public string SUBLANG { get; set; }
        /// <summary>
        /// Classify
        /// </summary>
        [JsonProperty("classify")]
        public string CLASSIFY { get; set; }
        /// <summary>
        /// Sector
        /// </summary>
        [JsonProperty("sector")]
        public string SECTOR { get; set; }
        /// <summary>
        /// Subsector
        /// </summary>
        [JsonProperty("subsector")]
        public string SUBSECTOR { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("gender")]
        public string GENDER { get; set; }
        /// <summary>
        /// Ctype
        /// </summary>
        [JsonProperty("customer_type")]
        public string CTYPE { get; set; }
        /// <summary>
        /// Profession
        /// </summary>
        [JsonProperty("profession")]
        public string PROFESSION { get; set; }
        /// <summary>
        /// Mstatus
        /// </summary>
        [JsonProperty("marital_status")]
        public string MSTATUS { get; set; }
        /// <summary>
        /// Children
        /// </summary>
        [JsonProperty("number_of_children")]
        public int? CHILDREN { get; set; } = 0;
        /// <summary>
        /// hobbies
        /// </summary>
        [JsonProperty("hobbies")]
        public string HOBBIES { get; set; }
        /// <summary>
        /// Resident
        /// </summary>
        [JsonProperty("resident")]
        public string RESIDENT { get; set; }
        /// <summary>
        /// Categories
        /// </summary>
        [JsonProperty("categories")]
        public string CATEGORIES { get; set; }
        ///// <summary>
        ///// Opndt
        ///// </summary>
        //[JsonProperty("open_date")]
        //public DateTime? OpenDate { get; set; }
        /// <summary>
        /// Opndt
        /// </summary>
        /// 
        [JsonProperty("open_date")]
        public string OPNDT { get; set; }
        ///// <summary>
        ///// Lastdt
        ///// </summary>
        //[JsonProperty("last_date")]
        //public DateTime? LastDate { get; set; }
        /// <summary>
        /// Lastdt
        /// </summary>
        /// 
        [JsonProperty("last_date")]
        public string LASTDT { get; set; }
        /// <summary>
        /// Branchid
        /// </summary>
        [JsonProperty("branchid")]
        public int? BRANCHID { get; set; } = 0;
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_code")]
        //public string BranchCode { get; set; }
        ///// <summary>
        ///// Aprdt
        ///// </summary>
        //[JsonProperty("approve_date")]
        //public DateTime? ApproveDate { get; set; }
        /// <summary>
        /// Aprdt
        /// </summary>
        /// 
        [JsonProperty("approve_date")]
        public string APRDT { get; set; }
        /// <summary>
        /// Ctmline
        /// </summary>
        [JsonProperty("customer_credit_line")]
        public decimal? CTMLINE { get; set; } = 0;
        /// <summary>
        /// Usectmline
        /// </summary>
        [JsonProperty("customer_credit_line_used")]
        public decimal? USECTMLINE { get; set; } = 0;
        /// <summary>
        /// Ctmline2
        /// </summary>
        [JsonProperty("customer_credit_line2")]
        public decimal? CTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Usectmline2
        /// </summary>
        [JsonProperty("customer_credit_line_used2")]
        public decimal? USECTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Ctmline3
        /// </summary>
        [JsonProperty("customer_credit_line3")]
        public decimal? CTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Usectmline3
        /// </summary>
        [JsonProperty("customer_credit_line_used3")]
        public decimal? USECTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Ctmline4
        /// </summary>
        [JsonProperty("customer_credit_line4")]
        public decimal? CTMLINE4 { get; set; } = 0;
        /// <summary>
        /// Usectmline4
        /// </summary>
        [JsonProperty("customer_credit_line_used4")]
        public decimal? USECTMLINE4 { get; set; } = 0;

        //[JsonProperty("effect_exchange_rate_time")] //Efttime
        //public string EffectExchangeRateTime { get; set; }
        /// <summary>
        /// Usrid
        /// </summary>
        [JsonProperty("staff_code")]
        public int? USRID { get; set; } = 0;
        /// <summary>
        /// Apuser
        /// </summary>
        [JsonProperty("approve_user_code")]
        public int? APUSER { get; set; } = 0;
        /// <summary>
        /// Rmkfld
        /// </summary>
        [JsonProperty("remark")]
        public string RMKFLD { get; set; }
        /// <summary>
        /// Refid
        /// </summary>
        [JsonProperty("old_id_of_customer")]
        public string REFID { get; set; }

        /// <summary>
        /// Descr
        /// </summary>
        [JsonProperty("description")]
        public string DESCR { get; set; }
        /// <summary>
        /// Ranking
        /// </summary>
        [JsonProperty("ranking")]
        public string RANKING { get; set; }
        /// <summary>
        /// Point
        /// </summary>
        [JsonProperty("point")]
        public string POINT { get; set; }
        /// <summary>
        /// Ctmsts
        /// </summary>
        [JsonProperty("customer_status")]
        public string CTMSTS { get; set; }
        /// <summary>
        /// Crmid
        /// </summary>
        [JsonProperty("customer_realation_staff_code")]
        public int? CRMID { get; set; } = 0;

        /// <summary>
        /// Rsklvl
        /// </summary>
        [JsonProperty("kyc_level")]
        public string RSKLVL { get; set; }
        /// <summary>
        /// Ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string CCRCD { get; set; }
        /// <summary>
        /// Ctmsize
        /// </summary>
        [JsonProperty("customer_size")]
        public string CTMSIZE { get; set; }

        /// <summary>
        /// cbranchid
        /// </summary>
        [JsonProperty("current_branch")]
        public int? CBRANCHID { get; set; } = 0;
        /// <summary>
        /// Srepidtype
        /// </summary>
        [JsonProperty("secondary_paper_type")]
        public string SREPIDTYPE { get; set; }
        /// <summary>
        /// Srepid
        /// </summary>
        [JsonProperty("secondary_paper_number")]
        public string SREPID { get; set; }
        /// <summary>
        /// sphone
        /// </summary>
        [JsonProperty("secondary_phone")]
        public PhoneModel SPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// lenofsev
        /// </summary>
        [JsonProperty("length_of_service")]
        public decimal? LENOFSEV { get; set; } = 0;
        /// <summary>
        /// Busname
        /// </summary>
        [JsonProperty("bussiness_name")]
        public string BUSNAME { get; set; }
        /// <summary>
        /// Busseg
        /// </summary>
        [JsonProperty("bussiness_segment")]
        public string BUSSEG { get; set; }
        /// <summary>
        /// Monincome
        /// </summary>
        [JsonProperty("monthly_income")]
        public decimal? MONINCOME { get; set; } = 0;
        /// <summary>
        /// Profit
        /// </summary>
        [JsonProperty("profit")]
        public int? PROFIT { get; set; } = 0;
        /// <summary>
        /// Ctmchar
        /// </summary>
        [JsonProperty("customer_characteristic")]
        public string CTMCHAR { get; set; }
        /// <summary>
        /// Deptservice
        /// </summary>
        [JsonProperty("dept_service_capacity")]
        public string DEPTSERVICE { get; set; }
        /// <summary>
        /// Security
        /// </summary>
        [JsonProperty("security_document")]
        public string SECURITY { get; set; }
        ///// <summary>
        ///// Joindt
        ///// </summary>
        //[JsonProperty("join_date")]
        //public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Joindt
        /// </summary>
        /// 
        [JsonProperty("join_date")]
        public string JOINDT { get; set; }
        /// <summary>
        /// Nbcclassify
        /// </summary>
        [JsonProperty("nbc_classify")]
        public string NBCCLASSIFY { get; set; }
        /// <summary>
        /// Spilvl
        /// </summary>
        [JsonProperty("spi_level")]
        public string SPILVL { get; set; }
        /// <summary>
        /// Busaddr
        /// </summary>
        [JsonProperty("bussiness_address")]
        public string BUSADDR { get; set; }
        /// <summary>
        /// Laddr
        /// </summary>
        [JsonProperty("primary_address")]
        public LAddressModel LADDR { get; set; } = new LAddressModel();
        /// <summary>
        /// Maddr
        /// </summary>
        [JsonProperty("secondary_address")]
        public MAddressModel MADDR { get; set; } = new MAddressModel();
        /// <summary>
        /// Tunused1
        /// </summary>
        [JsonProperty("user_define_1")]
        public string TUNUSED1 { get; set; }
        /// <summary>
        /// Tunused2
        /// </summary>
        [JsonProperty("user_define_2")]
        public string TUNUSED2 { get; set; }
        /// <summary>
        /// Tunused3
        /// </summary>
        [JsonProperty("user_define_3")]
        public string TUNUSED3 { get; set; }
        /// <summary>
        /// Tunused4
        /// </summary>
        [JsonProperty("user_define_4")]
        public string TUNUSED4 { get; set; }
        /// <summary>
        /// Tunused5
        /// </summary>
        [JsonProperty("user_define_5")]
        public string TUNUSED5 { get; set; }
        /// <summary>
        /// Tunused6
        /// </summary>
        [JsonProperty("user_define_6")]
        public string TUNUSED6 { get; set; }
        /// <summary>
        /// Tunused7
        /// </summary>
        [JsonProperty("user_define_7")]
        public string TUNUSED7 { get; set; }
        /// <summary>
        /// Tunused8
        /// </summary>
        [JsonProperty("user_define_8")]
        public string TUNUSED8 { get; set; }
        /// <summary>
        /// Tunused9
        /// </summary>
        [JsonProperty("user_define_9")]
        public string TUNUSED9 { get; set; }
        /// <summary>
        /// Tunused10
        /// </summary>
        [JsonProperty("user_define_10")]
        public string TUNUSED10 { get; set; }
        /// <summary>
        /// Cunused1
        /// </summary>
        [JsonProperty("user_define_11")]
        public string CUNUSED1 { get; set; }
        ///// <summary>
        ///// cunused2
        ///// </summary>
        //[JsonProperty("user_define_12")]
        //public string UserDefine12 { get; set; }
        ///// <summary>
        ///// cunused 3
        ///// </summary>
        //[JsonProperty("user_define_13")]
        //public string UserDefine13 { get; set; }
        ///// <summary>
        ///// cunused4
        ///// </summary>
        //[JsonProperty("user_define_14")]
        //public string UserDefine14 { get; set; }
        ///// <summary>
        ///// cunused5
        ///// </summary>
        //[JsonProperty("user_define_15")]
        //public string UserDefine15 { get; set; }
        ///// <summary>
        ///// cunused6
        ///// </summary>
        //[JsonProperty("user_define_16")]
        //public string UserDefine16 { get; set; }
        ///// <summary>
        ///// cunused7
        ///// </summary>
        //[JsonProperty("user_define_17")]
        //public string UserDefine17 { get; set; }
        ///// <summary>
        ///// cunused8
        ///// </summary>
        //[JsonProperty("user_define_18")]
        //public string UserDefine18 { get; set; }
        ///// <summary>
        ///// cunused9
        ///// </summary>
        //[JsonProperty("user_define_19")]
        //public string UserDefine19 { get; set; }
        ///// <summary>
        ///// cunused10
        ///// </summary>
        //[JsonProperty("user_define_20")]
        //public string UserDefine20 { get; set; }
        ///// <summary>
        ///// Siddt
        ///// </summary>
        //[JsonProperty("secondary_issue_date_of_paper")]
        //public DateTime? SecondaryIssueDateOfPaper { get; set; }
        /// <summary>
        /// Siddt
        /// </summary>
        /// 
        [JsonProperty("secondary_issue_date_of_paper")]
        public string SIDDT { get; set; }
        /// <summary>
        /// Sidplace
        /// </summary>
        [JsonProperty("secondary_issue_place_of_paper")]
        public string SIDPLACE { get; set; }
        ///// <summary>
        ///// Sidexpdt
        ///// </summary>
        //[JsonProperty("secondary_expire_date_of_paper")]
        //public DateTime? SecondaryExpireDateOfPaper { get; set; }
        /// <summary>
        /// Sidexpdt
        /// </summary>
        /// 
        [JsonProperty("secondary_expire_date_of_paper")]
        public string SIDEXPDT { get; set; }
        ///// <summary>
        ///// Epydt
        ///// </summary>
        //[JsonProperty("employee_date")]
        //public DateTime? EmployeeDate { get; set; }
        /// <summary>
        /// Epydt
        /// </summary>
        /// 
        [JsonProperty("employee_date")]
        public string EPYDT { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_code")]
        //public string CreatedByCode { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_name")]
        //public string CreatedByName { get; set; }
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_name")]
        //public string ManagingBranchName { get; set; }
        ///// <summary>
        ///// monitoring
        ///// </summary>
        //[JsonProperty("monitorings")]
        //public List<MonitoringModel> Monitorings { get; set; } = new();
        /// <summary>
        /// Education
        /// </summary>
        [JsonProperty("education")]
        public string EDUINF { get; set; }
        ///// <summary>
        ///// MigrationAddress
        ///// </summary>
        //[JsonProperty("migration_address")]
        //public string MigrationAddress { get; set; }
        ///// <summary>
        ///// Kscore
        ///// </summary>
        //[JsonProperty("kscroe")]
        //public string Kscore { get; set; }
        ///// <summary>
        ///// FirstAccessFinancialService
        ///// </summary>
        //[JsonProperty("first_access_financial_service")]
        //public string FirstAccessFinancialService { get; set; }
        /// <summary>
        /// Industry
        /// </summary>
        [JsonProperty("industry")]
        public string INDUSTRY { get; set; }
        /// <summary>
        /// SubIndustry
        /// </summary>
        [JsonProperty("sub_industry")]
        public string SUBINDUSTRY { get; set; }
        /// <summary>
        /// IncomeSourceSection
        /// </summary>
        [JsonProperty("income_source_section")]
        public string MSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("income_source_sub_section")]
        public string SSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("credit_line_od_limit")]
        public decimal? CRLIMITOD { get; set; } = 0;

        
    }
    /// <summary>
    /// AnniversaryModel
    /// </summary>
    public partial class AnniversaryModelRequest : BaseNeptuneModel
    {
        /// <summary>
        /// Married date
        /// </summary>
        [JsonProperty("married_date")]
        public DateTime? MarriedDate { get; set; }
        /// <summary>
        /// Married date
        /// </summary>
        public string M { get; set; }
        /// <summary>
        /// Graduation date
        /// </summary>
        [JsonProperty("graduation_date")]
        public DateTime? GraduationDate { get; set; }
        /// <summary>
        /// Graduation date
        /// </summary>
        public string G { get; set; }
        /// <summary>
        /// Starting date of company
        /// </summary>
        [JsonProperty("starting_date_of_company")]
        public DateTime? StartingDateOfCompany { get; set; }
        /// <summary>
        /// Starting date of company
        /// </summary>
        public string B { get; set; }
    }
    /// <summary>
    /// CustomerViewResponseModel
    /// </summary>
    public partial class CustomerUpdateRequestModel : BaseNeptuneModel
    {
        /// <summary>
        /// CustomerViewResponseModel
        /// </summary>
        public CustomerUpdateRequestModel() { }
        /// <summary>
        /// CUSTOMERID
        /// </summary>
        [JsonProperty("id")]
        public int? CUSTOMERID { get; set; }
        ///// <summary>
        ///// CUSTOMERCD
        ///// </summary>
        //[JsonProperty("customer_code")]
        //public string CUSTOMERCD { get; set; }
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("fullname")]
        public string FULLNAME { get; set; }
        /// <summary>
        /// CPRIVATE
        /// </summary>
        [JsonProperty("customer_private")]
        public string CPRIVATE { get; set; }
        /// <summary>
        /// mname
        /// </summary>
        [JsonProperty("customer_name")]
        public CustomerNameModel MNAME { get; set; } = new CustomerNameModel();
        /// <summary>
        /// SHORTNAME
        /// </summary>
        [JsonProperty("shortname")]
        public string SHORTNAME { get; set; }
        /// <summary>
        /// TITLE
        /// </summary>
        [JsonProperty("title")]
        public string TITLE { get; set; }
        /// <summary>
        /// FANAME
        /// </summary>
        [JsonProperty("reference_name")]
        public string FANAME { get; set; }
        /// <summary>
        /// SHORTID
        /// </summary>
        [JsonProperty("customer_short_id")]
        public string SHORTID { get; set; }
        /// <summary>
        /// COMPANY
        /// </summary>
        [JsonProperty("company")]
        public string COMPANY { get; set; }
        ///// <summary>
        ///// INCOME
        ///// </summary>
        //[JsonProperty("income")]
        //public decimal? INCOME { get; set; } 
        ///// <summary>
        ///// DOB
        ///// </summary>
        //[JsonProperty("date_of_birth")]
        ////[DataFormat("dd/MM/yyyy")]
        //public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// DOB
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DOB { get; set; }
        /// <summary>
        /// ANNIVERSARY
        /// </summary>
        [JsonProperty("anniversary")]
        public AnniversaryModelRequest ANNIVERSARY { get; set; } = new AnniversaryModelRequest();

        /// <summary>
        /// Mphone
        /// </summary>
        [JsonProperty("primary_phone")]
        public PhoneModel MPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// REFCODE
        /// </summary>
        [JsonProperty("reference_code")]
        public ReferenceCodeModel REFCODE { get; set; } = new ReferenceCodeModel();
        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email_address")]
        public string EMAIL { get; set; }
        /// <summary>
        /// mEmail
        /// </summary>
        [JsonProperty("other_email_address")]
        public OtherEmailAddressModel MEMAIL { get; set; } = new OtherEmailAddressModel();
        /// <summary>
        /// webaddr
        /// </summary>
        [JsonProperty("web_address")]
        public string WEBADDR { get; set; }
        /// <summary>
        /// repinfo
        /// </summary>
        [JsonProperty("representative_information")]
        public RepresentativeInformationModel REPINFO { get; set; } = new RepresentativeInformationModel();
        /// <summary>
        /// Repid
        /// </summary>
        [JsonProperty("paper_number")]
        public string REPID { get; set; }
        /// <summary>
        /// Repidtype
        /// </summary>
        [JsonProperty("paper_type")]
        public string REPIDTYPE { get; set; }
        ///// <summary>
        ///// Iddt
        ///// </summary>
        //[JsonProperty("issue_date_of_paper")]
        //public DateTime? IssueDateOfPaper { get; set; }
        /// <summary>
        /// Iddt
        /// </summary>
        /// 
        [JsonProperty("issue_date_of_paper")]
        public string IDDT { get; set; } = null;
        /// <summary>
        /// Idplace
        /// </summary>
        [JsonProperty("issue_place_of_paper")]
        public string IDPLACE { get; set; }
        ///// <summary>
        ///// Idexpdt
        ///// </summary>
        //[JsonProperty("expire_date_of_paper")]
        //public DateTime? ExpireDateOfPaper { get; set; }
        /// <summary>
        /// Idexpdt
        /// </summary>
        /// 
        [JsonProperty("expire_date_of_paper")]
        public string IDEXPDT { get; set; } = null;
        /// <summary>
        /// Nation
        /// </summary>
        [JsonProperty("nation")]
        public string NATION { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string COUNTRY { get; set; }
        /// <summary>
        /// Religion
        /// </summary>
        [JsonProperty("religion")]
        public string RELIGION { get; set; }
        /// <summary>
        /// Mainlang
        /// </summary>
        [JsonProperty("mainlang")]
        public string MAINLANG { get; set; }
        /// <summary>
        /// Sublang
        /// </summary>
        [JsonProperty("sublang")]
        public string SUBLANG { get; set; }
        /// <summary>
        /// Classify
        /// </summary>
        [JsonProperty("classify")]
        public string CLASSIFY { get; set; }
        /// <summary>
        /// Sector
        /// </summary>
        [JsonProperty("sector")]
        public string SECTOR { get; set; }
        /// <summary>
        /// Subsector
        /// </summary>
        [JsonProperty("subsector")]
        public string SUBSECTOR { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("gender")]
        public string GENDER { get; set; }
        /// <summary>
        /// Ctype
        /// </summary>
        [JsonProperty("customer_type")]
        public string CTYPE { get; set; }
        /// <summary>
        /// Profession
        /// </summary>
        [JsonProperty("profession")]
        public string PROFESSION { get; set; }
        /// <summary>
        /// Mstatus
        /// </summary>
        [JsonProperty("marital_status")]
        public string MSTATUS { get; set; }
        /// <summary>
        /// Children
        /// </summary>
        [JsonProperty("number_of_children")]
        public float CHILDREN { get; set; } = 0;
        /// <summary>
        /// hobbies
        /// </summary>
        [JsonProperty("hobbies")]
        public string HOBBIES { get; set; }
        /// <summary>
        /// Resident
        /// </summary>
        [JsonProperty("resident")]
        public string RESIDENT { get; set; }
        /// <summary>
        /// Categories
        /// </summary>
        [JsonProperty("categories")]
        public string CATEGORIES { get; set; }
        ///// <summary>
        ///// Opndt
        ///// </summary>
        //[JsonProperty("open_date")]
        //public DateTime? OpenDate { get; set; }
        /// <summary>
        /// Opndt
        /// </summary>
        /// 
        [JsonProperty("open_date")]
        public string OPNDT { get; set; } = null;
        ///// <summary>
        ///// Lastdt
        ///// </summary>
        //[JsonProperty("last_date")]
        //public DateTime? LastDate { get; set; }
        /// <summary>
        /// Lastdt
        /// </summary>
        /// 
        [JsonProperty("last_date")]
        public string LASTDT { get; set; } = null;
        /// <summary>
        /// Branchid
        /// </summary>
        [JsonProperty("branchid")]
        public int? BRANCHID { get; set; } = 0;
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_code")]
        //public string BranchCode { get; set; }
        ///// <summary>
        ///// Aprdt
        ///// </summary>
        //[JsonProperty("approve_date")]
        //public DateTime? ApproveDate { get; set; }
        /// <summary>
        /// Aprdt
        /// </summary>
        /// 
        [JsonProperty("approve_date")]
        public string APRDT { get; set; } = null;
        /// <summary>
        /// Ctmline
        /// </summary>
        [JsonProperty("customer_credit_line")]
        public decimal? CTMLINE { get; set; } = 0;
        /// <summary>
        /// Usectmline
        /// </summary>
        [JsonProperty("customer_credit_line_used")]
        public decimal? USECTMLINE { get; set; } = 0;
        /// <summary>
        /// Ctmline2
        /// </summary>
        [JsonProperty("customer_credit_line2")]
        public decimal? CTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Usectmline2
        /// </summary>
        [JsonProperty("customer_credit_line_used2")]
        public decimal? USECTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Ctmline3
        /// </summary>
        [JsonProperty("customer_credit_line3")]
        public decimal? CTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Usectmline3
        /// </summary>
        [JsonProperty("customer_credit_line_used3")]
        public decimal? USECTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Ctmline4
        /// </summary>
        [JsonProperty("customer_credit_line4")]
        public decimal? CTMLINE4 { get; set; } = 0;
        /// <summary>
        /// Usectmline4
        /// </summary>
        [JsonProperty("customer_credit_line_used4")]
        public decimal? USECTMLINE4 { get; set; } = 0;

        //[JsonProperty("effect_exchange_rate_time")] //Efttime
        //public string EffectExchangeRateTime { get; set; }
        /// <summary>
        /// Usrid
        /// </summary>
        [JsonProperty("staff_code")]
        public int? USRID { get; set; } = 0;
        /// <summary>
        /// Apuser
        /// </summary>
        [JsonProperty("approve_user_code")]
        public int? APUSER { get; set; } = 0;
        /// <summary>
        /// Rmkfld
        /// </summary>
        [JsonProperty("remark")]
        public string RMKFLD { get; set; }
        /// <summary>
        /// Refid
        /// </summary>
        [JsonProperty("old_id_of_customer")]
        public string REFID { get; set; }

        /// <summary>
        /// Descr
        /// </summary>
        [JsonProperty("description")]
        public string DESCR { get; set; }
        /// <summary>
        /// Ranking
        /// </summary>
        [JsonProperty("ranking")]
        public string RANKING { get; set; }
        /// <summary>
        /// Point
        /// </summary>
        [JsonProperty("point")]
        public string POINT { get; set; }
        /// <summary>
        /// Ctmsts
        /// </summary>
        [JsonProperty("customer_status")]
        public string CTMSTS { get; set; }
        /// <summary>
        /// Crmid
        /// </summary>
        [JsonProperty("customer_realation_staff_code")]
        public int? CRMID { get; set; } = 0;

        /// <summary>
        /// Rsklvl
        /// </summary>
        [JsonProperty("kyc_level")]
        public string RSKLVL { get; set; }
        /// <summary>
        /// Ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string CCRCD { get; set; }
        /// <summary>
        /// Ctmsize
        /// </summary>
        [JsonProperty("customer_size")]
        public string CTMSIZE { get; set; }

        /// <summary>
        /// cbranchid
        /// </summary>
        [JsonProperty("current_branch")]
        public int? CBRANCHID { get; set; } = 0;
        /// <summary>
        /// Srepidtype
        /// </summary>
        [JsonProperty("secondary_paper_type")]
        public string SREPIDTYPE { get; set; }
        /// <summary>
        /// Srepid
        /// </summary>
        [JsonProperty("secondary_paper_number")]
        public string SREPID { get; set; }
        /// <summary>
        /// sphone
        /// </summary>
        [JsonProperty("secondary_phone")]
        public PhoneModel SPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// lenofsev
        /// </summary>
        [JsonProperty("length_of_service")]
        public decimal? LENOFSEV { get; set; } = 0;
        /// <summary>
        /// Busname
        /// </summary>
        [JsonProperty("bussiness_name")]
        public string BUSNAME { get; set; }
        /// <summary>
        /// Busseg
        /// </summary>
        [JsonProperty("bussiness_segment")]
        public string BUSSEG { get; set; }
        /// <summary>
        /// Monincome
        /// </summary>
        [JsonProperty("monthly_income")]
        public decimal? MONINCOME { get; set; } = 0;
        /// <summary>
        /// Profit
        /// </summary>
        [JsonProperty("profit")]
        public decimal? PROFIT { get; set; } = 0;
        /// <summary>
        /// Ctmchar
        /// </summary>
        [JsonProperty("customer_characteristic")]
        public string CTMCHAR { get; set; }
        /// <summary>
        /// Deptservice
        /// </summary>
        [JsonProperty("dept_service_capacity")]
        public string DEPTSERVICE { get; set; }
        /// <summary>
        /// Security
        /// </summary>
        [JsonProperty("security_document")]
        public string SECURITY { get; set; }
        ///// <summary>
        ///// Joindt
        ///// </summary>
        //[JsonProperty("join_date")]
        //public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Joindt
        /// </summary>
        /// 
        [JsonProperty("join_date")]
        public string JOINDT { get; set; } = null;
        /// <summary>
        /// Nbcclassify
        /// </summary>
        [JsonProperty("nbc_classify")]
        public string NBCCLASSIFY { get; set; }
        /// <summary>
        /// Spilvl
        /// </summary>
        [JsonProperty("spi_level")]
        public string SPILVL { get; set; }
        /// <summary>
        /// Busaddr
        /// </summary>
        [JsonProperty("bussiness_address")]
        public string BUSADDR { get; set; }
        /// <summary>
        /// Laddr
        /// </summary>
        [JsonProperty("primary_address")]
        public LAddressModel LADDR { get; set; } = new LAddressModel();
        /// <summary>
        /// Maddr
        /// </summary>
        [JsonProperty("secondary_address")]
        public MAddressModel MADDR { get; set; } = new MAddressModel();
        /// <summary>
        /// Tunused1
        /// </summary>
        [JsonProperty("user_define_1")]
        public string TUNUSED1 { get; set; }
        /// <summary>
        /// Tunused2
        /// </summary>
        [JsonProperty("user_define_2")]
        public string TUNUSED2 { get; set; }
        /// <summary>
        /// Tunused3
        /// </summary>
        [JsonProperty("user_define_3")]
        public string TUNUSED3 { get; set; }
        /// <summary>
        /// Tunused4
        /// </summary>
        [JsonProperty("user_define_4")]
        public string TUNUSED4 { get; set; }
        /// <summary>
        /// Tunused5
        /// </summary>
        [JsonProperty("user_define_5")]
        public string TUNUSED5 { get; set; }
        /// <summary>
        /// Tunused6
        /// </summary>
        [JsonProperty("user_define_6")]
        public string TUNUSED6 { get; set; }
        /// <summary>
        /// Tunused7
        /// </summary>
        [JsonProperty("user_define_7")]
        public string TUNUSED7 { get; set; }
        /// <summary>
        /// Tunused8
        /// </summary>
        [JsonProperty("user_define_8")]
        public string TUNUSED8 { get; set; }
        /// <summary>
        /// Tunused9
        /// </summary>
        [JsonProperty("user_define_9")]
        public string TUNUSED9 { get; set; }
        /// <summary>
        /// Tunused10
        /// </summary>
        [JsonProperty("user_define_10")]
        public string TUNUSED10 { get; set; }
        /// <summary>
        /// Cunused1
        /// </summary>
        [JsonProperty("user_define_11")]
        public string CUNUSED1 { get; set; }
        ///// <summary>
        ///// cunused2
        ///// </summary>
        //[JsonProperty("user_define_12")]
        //public string UserDefine12 { get; set; }
        ///// <summary>
        ///// cunused 3
        ///// </summary>
        //[JsonProperty("user_define_13")]
        //public string UserDefine13 { get; set; }
        ///// <summary>
        ///// cunused4
        ///// </summary>
        //[JsonProperty("user_define_14")]
        //public string UserDefine14 { get; set; }
        ///// <summary>
        ///// cunused5
        ///// </summary>
        //[JsonProperty("user_define_15")]
        //public string UserDefine15 { get; set; }
        ///// <summary>
        ///// cunused6
        ///// </summary>
        //[JsonProperty("user_define_16")]
        //public string UserDefine16 { get; set; }
        ///// <summary>
        ///// cunused7
        ///// </summary>
        //[JsonProperty("user_define_17")]
        //public string UserDefine17 { get; set; }
        ///// <summary>
        ///// cunused8
        ///// </summary>
        //[JsonProperty("user_define_18")]
        //public string UserDefine18 { get; set; }
        ///// <summary>
        ///// cunused9
        ///// </summary>
        //[JsonProperty("user_define_19")]
        //public string UserDefine19 { get; set; }
        ///// <summary>
        ///// cunused10
        ///// </summary>
        //[JsonProperty("user_define_20")]
        //public string UserDefine20 { get; set; }
        ///// <summary>
        ///// Siddt
        ///// </summary>
        //[JsonProperty("secondary_issue_date_of_paper")]
        //public DateTime? SecondaryIssueDateOfPaper { get; set; }
        /// <summary>
        /// Siddt
        /// </summary>
        /// 
        [JsonProperty("secondary_issue_date_of_paper")]
        public string SIDDT { get; set; } = null;
        /// <summary>
        /// Sidplace
        /// </summary>
        [JsonProperty("secondary_issue_place_of_paper")]
        public string SIDPLACE { get; set; }
        ///// <summary>
        ///// Sidexpdt
        ///// </summary>
        //[JsonProperty("secondary_expire_date_of_paper")]
        //public DateTime? SecondaryExpireDateOfPaper { get; set; }
        /// <summary>
        /// Sidexpdt
        /// </summary>
        /// 
        [JsonProperty("secondary_expire_date_of_paper")]
        public string SIDEXPDT { get; set; } = null;
        ///// <summary>
        ///// Epydt
        ///// </summary>
        //[JsonProperty("employee_date")]
        //public DateTime? EmployeeDate { get; set; }
        /// <summary>
        /// Epydt
        /// </summary>
        /// 
        [JsonProperty("employee_date")]
        public string EPYDT { get; set; } = null;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_code")]
        //public string CreatedByCode { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_name")]
        //public string CreatedByName { get; set; }
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_name")]
        //public string ManagingBranchName { get; set; }
        ///// <summary>
        ///// monitoring
        ///// </summary>
        //[JsonProperty("monitorings")]
        //public List<MonitoringModel> Monitorings { get; set; } = new();
        /// <summary>
        /// Education
        /// </summary>
        [JsonProperty("education")]
        public string EDUINF { get; set; }
        ///// <summary>
        ///// MigrationAddress
        ///// </summary>
        //[JsonProperty("migration_address")]
        //public string MigrationAddress { get; set; }
        ///// <summary>
        ///// Kscore
        ///// </summary>
        //[JsonProperty("kscroe")]
        //public string Kscore { get; set; }
        ///// <summary>
        ///// FirstAccessFinancialService
        ///// </summary>
        //[JsonProperty("first_access_financial_service")]
        //public string FirstAccessFinancialService { get; set; }
        /// <summary>
        /// Industry
        /// </summary>
        [JsonProperty("industry")]
        public string INDUSTRY { get; set; }
        /// <summary>
        /// SubIndustry
        /// </summary>
        [JsonProperty("sub_industry")]
        public string SUBINDUSTRY { get; set; }
        /// <summary>
        /// IncomeSourceSection
        /// </summary>
        [JsonProperty("income_source_section")]
        public string MSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("income_source_sub_section")]
        public string SSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("credit_line_od_limit")]
        public decimal? CRLIMITOD { get; set; } = 0;


    }
    /// <summary>
    /// CustomerViewResponseModel
    /// </summary>
    public partial class CustomerUpdateResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// CustomerViewResponseModel
        /// </summary>
        public CustomerUpdateResponseModel() { }
        /// <summary>
        /// CUSTOMERID
        /// </summary>
        public int CUSTOMERID { get; set; }
        ///// <summary>
        ///// CUSTOMERCD
        ///// </summary>
        //[JsonProperty("customer_code")]
        //public string CUSTOMERCD { get; set; }
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("fullname")]
        public string FULLNAME { get; set; }
        /// <summary>
        /// CPRIVATE
        /// </summary>
        [JsonProperty("customer_private")]
        public string CPRIVATE { get; set; }
        /// <summary>
        /// mname
        /// </summary>
        [JsonProperty("customer_name")]
        public CustomerNameModel MNAME { get; set; } = new CustomerNameModel();
        /// <summary>
        /// SHORTNAME
        /// </summary>
        [JsonProperty("shortname")]
        public string SHORTNAME { get; set; }
        /// <summary>
        /// TITLE
        /// </summary>
        [JsonProperty("title")]
        public string TITLE { get; set; }
        /// <summary>
        /// FANAME
        /// </summary>
        [JsonProperty("reference_name")]
        public string FANAME { get; set; }
        /// <summary>
        /// SHORTID
        /// </summary>
        [JsonProperty("customer_short_id")]
        public string SHORTID { get; set; }
        /// <summary>
        /// COMPANY
        /// </summary>
        [JsonProperty("company")]
        public string COMPANY { get; set; }
        ///// <summary>
        ///// INCOME
        ///// </summary>
        //[JsonProperty("income")]
        //public decimal? INCOME { get; set; } 
        ///// <summary>
        ///// DOB
        ///// </summary>
        //[JsonProperty("date_of_birth")]
        ////[DataFormat("dd/MM/yyyy")]
        //public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// DOB
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DOB { get; set; }
        /// <summary>
        /// ANNIVERSARY
        /// </summary>
        [JsonProperty("anniversary")]
        public AnniversaryModelRequest ANNIVERSARY { get; set; } = new AnniversaryModelRequest();

        /// <summary>
        /// Mphone
        /// </summary>
        [JsonProperty("primary_phone")]
        public PhoneModel MPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// REFCODE
        /// </summary>
        [JsonProperty("reference_code")]
        public ReferenceCodeModel REFCODE { get; set; } = new ReferenceCodeModel();
        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email_address")]
        public string EMAIL { get; set; }
        /// <summary>
        /// mEmail
        /// </summary>
        [JsonProperty("other_email_address")]
        public OtherEmailAddressModel MEMAIL { get; set; } = new OtherEmailAddressModel();
        /// <summary>
        /// webaddr
        /// </summary>
        [JsonProperty("web_address")]
        public string WEBADDR { get; set; }
        /// <summary>
        /// repinfo
        /// </summary>
        [JsonProperty("representative_information")]
        public RepresentativeInformationModel REPINFO { get; set; } = new RepresentativeInformationModel();
        /// <summary>
        /// Repid
        /// </summary>
        [JsonProperty("paper_number")]
        public string REPID { get; set; }
        /// <summary>
        /// Repidtype
        /// </summary>
        [JsonProperty("paper_type")]
        public string REPIDTYPE { get; set; }
        ///// <summary>
        ///// Iddt
        ///// </summary>
        //[JsonProperty("issue_date_of_paper")]
        //public DateTime? IssueDateOfPaper { get; set; }
        /// <summary>
        /// Iddt
        /// </summary>
        /// 
        [JsonProperty("issue_date_of_paper")]
        public string IDDT { get; set; } = null;
        /// <summary>
        /// Idplace
        /// </summary>
        [JsonProperty("issue_place_of_paper")]
        public string IDPLACE { get; set; }
        ///// <summary>
        ///// Idexpdt
        ///// </summary>
        //[JsonProperty("expire_date_of_paper")]
        //public DateTime? ExpireDateOfPaper { get; set; }
        /// <summary>
        /// Idexpdt
        /// </summary>
        /// 
        [JsonProperty("expire_date_of_paper")]
        public string IDEXPDT { get; set; } = null;
        /// <summary>
        /// Nation
        /// </summary>
        [JsonProperty("nation")]
        public string NATION { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string COUNTRY { get; set; }
        /// <summary>
        /// Religion
        /// </summary>
        [JsonProperty("religion")]
        public string RELIGION { get; set; }
        /// <summary>
        /// Mainlang
        /// </summary>
        [JsonProperty("mainlang")]
        public string MAINLANG { get; set; }
        /// <summary>
        /// Sublang
        /// </summary>
        [JsonProperty("sublang")]
        public string SUBLANG { get; set; }
        /// <summary>
        /// Classify
        /// </summary>
        [JsonProperty("classify")]
        public string CLASSIFY { get; set; }
        /// <summary>
        /// Sector
        /// </summary>
        [JsonProperty("sector")]
        public string SECTOR { get; set; }
        /// <summary>
        /// Subsector
        /// </summary>
        [JsonProperty("subsector")]
        public string SUBSECTOR { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("gender")]
        public string GENDER { get; set; }
        /// <summary>
        /// Ctype
        /// </summary>
        [JsonProperty("customer_type")]
        public string CTYPE { get; set; }
        /// <summary>
        /// Profession
        /// </summary>
        [JsonProperty("profession")]
        public string PROFESSION { get; set; }
        /// <summary>
        /// Mstatus
        /// </summary>
        [JsonProperty("marital_status")]
        public string MSTATUS { get; set; }
        /// <summary>
        /// Children
        /// </summary>
        [JsonProperty("number_of_children")]
        public float CHILDREN { get; set; } = 0;
        /// <summary>
        /// hobbies
        /// </summary>
        [JsonProperty("hobbies")]
        public string HOBBIES { get; set; }
        /// <summary>
        /// Resident
        /// </summary>
        [JsonProperty("resident")]
        public string RESIDENT { get; set; }
        /// <summary>
        /// Categories
        /// </summary>
        [JsonProperty("categories")]
        public string CATEGORIES { get; set; }
        ///// <summary>
        ///// Opndt
        ///// </summary>
        //[JsonProperty("open_date")]
        //public DateTime? OpenDate { get; set; }
        /// <summary>
        /// Opndt
        /// </summary>
        /// 
        [JsonProperty("open_date")]
        public string OPNDT { get; set; } = null;
        ///// <summary>
        ///// Lastdt
        ///// </summary>
        //[JsonProperty("last_date")]
        //public DateTime? LastDate { get; set; }
        /// <summary>
        /// Lastdt
        /// </summary>
        /// 
        [JsonProperty("last_date")]
        public string LASTDT { get; set; } = null;
        /// <summary>
        /// Branchid
        /// </summary>
        [JsonProperty("branchid")]
        public int? BRANCHID { get; set; } = 0;
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_code")]
        //public string BranchCode { get; set; }
        ///// <summary>
        ///// Aprdt
        ///// </summary>
        //[JsonProperty("approve_date")]
        //public DateTime? ApproveDate { get; set; }
        /// <summary>
        /// Aprdt
        /// </summary>
        /// 
        [JsonProperty("approve_date")]
        public string APRDT { get; set; } = null;
        /// <summary>
        /// Ctmline
        /// </summary>
        [JsonProperty("customer_credit_line")]
        public decimal? CTMLINE { get; set; } = 0;
        /// <summary>
        /// Usectmline
        /// </summary>
        [JsonProperty("customer_credit_line_used")]
        public decimal? USECTMLINE { get; set; } = 0;
        /// <summary>
        /// Ctmline2
        /// </summary>
        [JsonProperty("customer_credit_line2")]
        public decimal? CTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Usectmline2
        /// </summary>
        [JsonProperty("customer_credit_line_used2")]
        public decimal? USECTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Ctmline3
        /// </summary>
        [JsonProperty("customer_credit_line3")]
        public decimal? CTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Usectmline3
        /// </summary>
        [JsonProperty("customer_credit_line_used3")]
        public decimal? USECTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Ctmline4
        /// </summary>
        [JsonProperty("customer_credit_line4")]
        public decimal? CTMLINE4 { get; set; } = 0;
        /// <summary>
        /// Usectmline4
        /// </summary>
        [JsonProperty("customer_credit_line_used4")]
        public decimal? USECTMLINE4 { get; set; } = 0;

        //[JsonProperty("effect_exchange_rate_time")] //Efttime
        //public string EffectExchangeRateTime { get; set; }
        /// <summary>
        /// Usrid
        /// </summary>
        [JsonProperty("staff_code")]
        public int? USRID { get; set; } = 0;
        /// <summary>
        /// Apuser
        /// </summary>
        [JsonProperty("approve_user_code")]
        public int? APUSER { get; set; } = 0;
        /// <summary>
        /// Rmkfld
        /// </summary>
        [JsonProperty("remark")]
        public string RMKFLD { get; set; }
        /// <summary>
        /// Refid
        /// </summary>
        [JsonProperty("old_id_of_customer")]
        public string REFID { get; set; }

        /// <summary>
        /// Descr
        /// </summary>
        [JsonProperty("description")]
        public string DESCR { get; set; }
        /// <summary>
        /// Ranking
        /// </summary>
        [JsonProperty("ranking")]
        public string RANKING { get; set; }
        /// <summary>
        /// Point
        /// </summary>
        [JsonProperty("point")]
        public string POINT { get; set; }
        /// <summary>
        /// Ctmsts
        /// </summary>
        [JsonProperty("customer_status")]
        public string CTMSTS { get; set; }
        /// <summary>
        /// Crmid
        /// </summary>
        [JsonProperty("customer_realation_staff_code")]
        public int? CRMID { get; set; } = 0;

        /// <summary>
        /// Rsklvl
        /// </summary>
        [JsonProperty("kyc_level")]
        public string RSKLVL { get; set; }
        /// <summary>
        /// Ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string CCRCD { get; set; }
        /// <summary>
        /// Ctmsize
        /// </summary>
        [JsonProperty("customer_size")]
        public string CTMSIZE { get; set; }

        /// <summary>
        /// cbranchid
        /// </summary>
        [JsonProperty("current_branch")]
        public int? CBRANCHID { get; set; } = 0;
        /// <summary>
        /// Srepidtype
        /// </summary>
        [JsonProperty("secondary_paper_type")]
        public string SREPIDTYPE { get; set; }
        /// <summary>
        /// Srepid
        /// </summary>
        [JsonProperty("secondary_paper_number")]
        public string SREPID { get; set; }
        /// <summary>
        /// sphone
        /// </summary>
        [JsonProperty("secondary_phone")]
        public PhoneModel SPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// lenofsev
        /// </summary>
        [JsonProperty("length_of_service")]
        public decimal? LENOFSEV { get; set; } = 0;
        /// <summary>
        /// Busname
        /// </summary>
        [JsonProperty("bussiness_name")]
        public string BUSNAME { get; set; }
        /// <summary>
        /// Busseg
        /// </summary>
        [JsonProperty("bussiness_segment")]
        public string BUSSEG { get; set; }
        /// <summary>
        /// Monincome
        /// </summary>
        [JsonProperty("monthly_income")]
        public decimal? MONINCOME { get; set; } = 0;
        /// <summary>
        /// Profit
        /// </summary>
        [JsonProperty("profit")]
        public decimal? PROFIT { get; set; } = 0;
        /// <summary>
        /// Ctmchar
        /// </summary>
        [JsonProperty("customer_characteristic")]
        public string CTMCHAR { get; set; }
        /// <summary>
        /// Deptservice
        /// </summary>
        [JsonProperty("dept_service_capacity")]
        public string DEPTSERVICE { get; set; }
        /// <summary>
        /// Security
        /// </summary>
        [JsonProperty("security_document")]
        public string SECURITY { get; set; }
        ///// <summary>
        ///// Joindt
        ///// </summary>
        //[JsonProperty("join_date")]
        //public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Joindt
        /// </summary>
        /// 
        [JsonProperty("join_date")]
        public string JOINDT { get; set; } = null;
        /// <summary>
        /// Nbcclassify
        /// </summary>
        [JsonProperty("nbc_classify")]
        public string NBCCLASSIFY { get; set; }
        /// <summary>
        /// Spilvl
        /// </summary>
        [JsonProperty("spi_level")]
        public string SPILVL { get; set; }
        /// <summary>
        /// Busaddr
        /// </summary>
        [JsonProperty("bussiness_address")]
        public string BUSADDR { get; set; }
        /// <summary>
        /// Laddr
        /// </summary>
        [JsonProperty("primary_address")]
        public LAddressModel LADDR { get; set; } = new LAddressModel();
        /// <summary>
        /// Maddr
        /// </summary>
        [JsonProperty("secondary_address")]
        public MAddressModel MADDR { get; set; } = new MAddressModel();
        /// <summary>
        /// Tunused1
        /// </summary>
        [JsonProperty("user_define_1")]
        public string TUNUSED1 { get; set; }
        /// <summary>
        /// Tunused2
        /// </summary>
        [JsonProperty("user_define_2")]
        public string TUNUSED2 { get; set; }
        /// <summary>
        /// Tunused3
        /// </summary>
        [JsonProperty("user_define_3")]
        public string TUNUSED3 { get; set; }
        /// <summary>
        /// Tunused4
        /// </summary>
        [JsonProperty("user_define_4")]
        public string TUNUSED4 { get; set; }
        /// <summary>
        /// Tunused5
        /// </summary>
        [JsonProperty("user_define_5")]
        public string TUNUSED5 { get; set; }
        /// <summary>
        /// Tunused6
        /// </summary>
        [JsonProperty("user_define_6")]
        public string TUNUSED6 { get; set; }
        /// <summary>
        /// Tunused7
        /// </summary>
        [JsonProperty("user_define_7")]
        public string TUNUSED7 { get; set; }
        /// <summary>
        /// Tunused8
        /// </summary>
        [JsonProperty("user_define_8")]
        public string TUNUSED8 { get; set; }
        /// <summary>
        /// Tunused9
        /// </summary>
        [JsonProperty("user_define_9")]
        public string TUNUSED9 { get; set; }
        /// <summary>
        /// Tunused10
        /// </summary>
        [JsonProperty("user_define_10")]
        public string TUNUSED10 { get; set; }
        /// <summary>
        /// Cunused1
        /// </summary>
        [JsonProperty("user_define_11")]
        public string CUNUSED1 { get; set; }
        ///// <summary>
        ///// cunused2
        ///// </summary>
        //[JsonProperty("user_define_12")]
        //public string UserDefine12 { get; set; }
        ///// <summary>
        ///// cunused 3
        ///// </summary>
        //[JsonProperty("user_define_13")]
        //public string UserDefine13 { get; set; }
        ///// <summary>
        ///// cunused4
        ///// </summary>
        //[JsonProperty("user_define_14")]
        //public string UserDefine14 { get; set; }
        ///// <summary>
        ///// cunused5
        ///// </summary>
        //[JsonProperty("user_define_15")]
        //public string UserDefine15 { get; set; }
        ///// <summary>
        ///// cunused6
        ///// </summary>
        //[JsonProperty("user_define_16")]
        //public string UserDefine16 { get; set; }
        ///// <summary>
        ///// cunused7
        ///// </summary>
        //[JsonProperty("user_define_17")]
        //public string UserDefine17 { get; set; }
        ///// <summary>
        ///// cunused8
        ///// </summary>
        //[JsonProperty("user_define_18")]
        //public string UserDefine18 { get; set; }
        ///// <summary>
        ///// cunused9
        ///// </summary>
        //[JsonProperty("user_define_19")]
        //public string UserDefine19 { get; set; }
        ///// <summary>
        ///// cunused10
        ///// </summary>
        //[JsonProperty("user_define_20")]
        //public string UserDefine20 { get; set; }
        ///// <summary>
        ///// Siddt
        ///// </summary>
        //[JsonProperty("secondary_issue_date_of_paper")]
        //public DateTime? SecondaryIssueDateOfPaper { get; set; }
        /// <summary>
        /// Siddt
        /// </summary>
        /// 
        [JsonProperty("secondary_issue_date_of_paper")]
        public string SIDDT { get; set; } = null;
        /// <summary>
        /// Sidplace
        /// </summary>
        [JsonProperty("secondary_issue_place_of_paper")]
        public string SIDPLACE { get; set; }
        ///// <summary>
        ///// Sidexpdt
        ///// </summary>
        //[JsonProperty("secondary_expire_date_of_paper")]
        //public DateTime? SecondaryExpireDateOfPaper { get; set; }
        /// <summary>
        /// Sidexpdt
        /// </summary>
        /// 
        [JsonProperty("secondary_expire_date_of_paper")]
        public string SIDEXPDT { get; set; } = null;
        ///// <summary>
        ///// Epydt
        ///// </summary>
        //[JsonProperty("employee_date")]
        //public DateTime? EmployeeDate { get; set; }
        /// <summary>
        /// Epydt
        /// </summary>
        /// 
        [JsonProperty("employee_date")]
        public string EPYDT { get; set; } = null;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_code")]
        //public string CreatedByCode { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_name")]
        //public string CreatedByName { get; set; }
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_name")]
        //public string ManagingBranchName { get; set; }
        ///// <summary>
        ///// monitoring
        ///// </summary>
        //[JsonProperty("monitorings")]
        //public List<MonitoringModel> Monitorings { get; set; } = new();
        /// <summary>
        /// Education
        /// </summary>
        [JsonProperty("education")]
        public string EDUINF { get; set; }
        ///// <summary>
        ///// MigrationAddress
        ///// </summary>
        //[JsonProperty("migration_address")]
        //public string MigrationAddress { get; set; }
        ///// <summary>
        ///// Kscore
        ///// </summary>
        //[JsonProperty("kscroe")]
        //public string Kscore { get; set; }
        ///// <summary>
        ///// FirstAccessFinancialService
        ///// </summary>
        //[JsonProperty("first_access_financial_service")]
        //public string FirstAccessFinancialService { get; set; }
        /// <summary>
        /// Industry
        /// </summary>
        [JsonProperty("industry")]
        public string INDUSTRY { get; set; }
        /// <summary>
        /// SubIndustry
        /// </summary>
        [JsonProperty("sub_industry")]
        public string SUBINDUSTRY { get; set; }
        /// <summary>
        /// IncomeSourceSection
        /// </summary>
        [JsonProperty("income_source_section")]
        public string MSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("income_source_sub_section")]
        public string SSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("credit_line_od_limit")]
        public decimal? CRLIMITOD { get; set; } = 0;


    }

    /// <summary>
    /// CustomerViewResponseModel
    /// </summary>
    public partial class CustomerInsertResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// CustomerViewResponseModel
        /// </summary>
        public CustomerInsertResponseModel() { }
        /// <summary>
        /// CUSTOMERID
        /// </summary>
        //[JsonProperty("id")]
        public int? CUSTOMERID { get; set; }
        /// <summary>
        /// CUSTOMERCD
        /// </summary>
        [JsonProperty("customer_code")]
        public string CUSTOMERCD { get; set; }
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("fullname")]
        public string FULLNAME { get; set; }
        /// <summary>
        /// CPRIVATE
        /// </summary>
        [JsonProperty("customer_private")]
        public string CPRIVATE { get; set; }
        /// <summary>
        /// mname
        /// </summary>
        [JsonProperty("customer_name")]
        public CustomerNameModel MNAME { get; set; } = new CustomerNameModel();
        /// <summary>
        /// SHORTNAME
        /// </summary>
        [JsonProperty("shortname")]
        public string SHORTNAME { get; set; }
        /// <summary>
        /// TITLE
        /// </summary>
        [JsonProperty("title")]
        public string TITLE { get; set; }
        /// <summary>
        /// FANAME
        /// </summary>
        [JsonProperty("reference_name")]
        public string FANAME { get; set; }
        /// <summary>
        /// SHORTID
        /// </summary>
        [JsonProperty("customer_short_id")]
        public string SHORTID { get; set; }
        /// <summary>
        /// COMPANY
        /// </summary>
        [JsonProperty("company")]
        public string COMPANY { get; set; }
        /// <summary>
        /// DOB
        /// </summary>
        [JsonProperty("date_of_birth")]
        public string DOB { get; set; }
        /// <summary>
        /// ANNIVERSARY
        /// </summary>
        [JsonProperty("anniversary")]
        public AnniversaryModelRequest ANNIVERSARY { get; set; } = new AnniversaryModelRequest();

        /// <summary>
        /// Mphone
        /// </summary>
        [JsonProperty("primary_phone")]
        public PhoneModel MPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// REFCODE
        /// </summary>
        [JsonProperty("reference_code")]
        public ReferenceCodeModel REFCODE { get; set; } = new ReferenceCodeModel();
        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("email_address")]
        public string EMAIL { get; set; }
        /// <summary>
        /// mEmail
        /// </summary>
        [JsonProperty("other_email_address")]
        public OtherEmailAddressModel MEMAIL { get; set; } = new OtherEmailAddressModel();
        /// <summary>
        /// webaddr
        /// </summary>
        [JsonProperty("web_address")]
        public string WEBADDR { get; set; }
        /// <summary>
        /// repinfo
        /// </summary>
        [JsonProperty("representative_information")]
        public RepresentativeInformationModel REPINFO { get; set; } = new RepresentativeInformationModel();
        /// <summary>
        /// Repid
        /// </summary>
        [JsonProperty("paper_number")]
        public string REPID { get; set; }
        /// <summary>
        /// Repidtype
        /// </summary>
        [JsonProperty("paper_type")]
        public string REPIDTYPE { get; set; }
        /// <summary>
        /// Iddt
        /// </summary>
        /// 
        [JsonProperty("issue_date_of_paper")]
        public string IDDT { get; set; }
        /// <summary>
        /// Idplace
        /// </summary>
        [JsonProperty("issue_place_of_paper")]
        public string IDPLACE { get; set; }
        /// <summary>
        /// Idexpdt
        /// </summary>
        /// 
        [JsonProperty("expire_date_of_paper")]
        public string IDEXPDT { get; set; }
        /// <summary>
        /// Nation
        /// </summary>
        [JsonProperty("nation")]
        public string NATION { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string COUNTRY { get; set; }
        /// <summary>
        /// Religion
        /// </summary>
        [JsonProperty("religion")]
        public string RELIGION { get; set; }
        /// <summary>
        /// Mainlang
        /// </summary>
        [JsonProperty("mainlang")]
        public string MAINLANG { get; set; }
        /// <summary>
        /// Sublang
        /// </summary>
        [JsonProperty("sublang")]
        public string SUBLANG { get; set; }
        /// <summary>
        /// Classify
        /// </summary>
        [JsonProperty("classify")]
        public string CLASSIFY { get; set; }
        /// <summary>
        /// Sector
        /// </summary>
        [JsonProperty("sector")]
        public string SECTOR { get; set; }
        /// <summary>
        /// Subsector
        /// </summary>
        [JsonProperty("subsector")]
        public string SUBSECTOR { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("gender")]
        public string GENDER { get; set; }
        /// <summary>
        /// Ctype
        /// </summary>
        [JsonProperty("customer_type")]
        public string CTYPE { get; set; }
        /// <summary>
        /// Profession
        /// </summary>
        [JsonProperty("profession")]
        public string PROFESSION { get; set; }
        /// <summary>
        /// Mstatus
        /// </summary>
        [JsonProperty("marital_status")]
        public string MSTATUS { get; set; }
        /// <summary>
        /// Children
        /// </summary>
        [JsonProperty("number_of_children")]
        public int? CHILDREN { get; set; } = 0;
        /// <summary>
        /// hobbies
        /// </summary>
        [JsonProperty("hobbies")]
        public string HOBBIES { get; set; }
        /// <summary>
        /// Resident
        /// </summary>
        [JsonProperty("resident")]
        public string RESIDENT { get; set; }
        /// <summary>
        /// Categories
        /// </summary>
        [JsonProperty("categories")]
        public string CATEGORIES { get; set; }
        /// <summary>
        /// Opndt
        /// </summary>
        /// 
        [JsonProperty("open_date")]
        public string OPNDT { get; set; }
        /// <summary>
        /// Lastdt
        /// </summary>
        /// 
        [JsonProperty("last_date")]
        public string LASTDT { get; set; }
        /// <summary>
        /// Branchid
        /// </summary>
        [JsonProperty("branchid")]
        public int? BRANCHID { get; set; } = 0;
        /// <summary>
        /// Aprdt
        /// </summary>
        /// 
        [JsonProperty("approve_date")]
        public string APRDT { get; set; }
        /// <summary>
        /// Ctmline
        /// </summary>
        [JsonProperty("customer_credit_line")]
        public decimal? CTMLINE { get; set; } = 0;
        /// <summary>
        /// Usectmline
        /// </summary>
        [JsonProperty("customer_credit_line_used")]
        public decimal? USECTMLINE { get; set; } = 0;
        /// <summary>
        /// Ctmline2
        /// </summary>
        [JsonProperty("customer_credit_line2")]
        public decimal? CTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Usectmline2
        /// </summary>
        [JsonProperty("customer_credit_line_used2")]
        public decimal? USECTMLINE2 { get; set; } = 0;
        /// <summary>
        /// Ctmline3
        /// </summary>
        [JsonProperty("customer_credit_line3")]
        public decimal? CTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Usectmline3
        /// </summary>
        [JsonProperty("customer_credit_line_used3")]
        public decimal? USECTMLINE3 { get; set; } = 0;
        /// <summary>
        /// Ctmline4
        /// </summary>
        [JsonProperty("customer_credit_line4")]
        public decimal? CTMLINE4 { get; set; } = 0;
        /// <summary>
        /// Usectmline4
        /// </summary>
        [JsonProperty("customer_credit_line_used4")]
        public decimal? USECTMLINE4 { get; set; } = 0;
        /// <summary>
        /// Usrid
        /// </summary>
        [JsonProperty("staff_code")]
        public int? USRID { get; set; } = 0;
        /// <summary>
        /// Apuser
        /// </summary>
        [JsonProperty("approve_user_code")]
        public int? APUSER { get; set; } = 0;
        /// <summary>
        /// Rmkfld
        /// </summary>
        [JsonProperty("remark")]
        public string RMKFLD { get; set; }
        /// <summary>
        /// Refid
        /// </summary>
        [JsonProperty("old_id_of_customer")]
        public string REFID { get; set; }

        /// <summary>
        /// Descr
        /// </summary>
        [JsonProperty("description")]
        public string DESCR { get; set; }
        /// <summary>
        /// Ranking
        /// </summary>
        [JsonProperty("ranking")]
        public string RANKING { get; set; }
        /// <summary>
        /// Point
        /// </summary>
        [JsonProperty("point")]
        public string POINT { get; set; }
        /// <summary>
        /// Ctmsts
        /// </summary>
        [JsonProperty("customer_status")]
        public string CTMSTS { get; set; }
        /// <summary>
        /// Crmid
        /// </summary>
        [JsonProperty("customer_realation_staff_code")]
        public int? CRMID { get; set; } = 0;

        /// <summary>
        /// Rsklvl
        /// </summary>
        [JsonProperty("kyc_level")]
        public string RSKLVL { get; set; }
        /// <summary>
        /// Ccrcd
        /// </summary>
        [JsonProperty("currency_code")]
        public string CCRCD { get; set; }
        /// <summary>
        /// Ctmsize
        /// </summary>
        [JsonProperty("customer_size")]
        public string CTMSIZE { get; set; }

        /// <summary>
        /// cbranchid
        /// </summary>
        [JsonProperty("current_branch")]
        public int? CBRANCHID { get; set; } = 0;
        /// <summary>
        /// Srepidtype
        /// </summary>
        [JsonProperty("secondary_paper_type")]
        public string SREPIDTYPE { get; set; }
        /// <summary>
        /// Srepid
        /// </summary>
        [JsonProperty("secondary_paper_number")]
        public string SREPID { get; set; }
        /// <summary>
        /// sphone
        /// </summary>
        [JsonProperty("secondary_phone")]
        public PhoneModel SPHONE { get; set; } = new PhoneModel();
        /// <summary>
        /// lenofsev
        /// </summary>
        [JsonProperty("length_of_service")]
        public decimal? LENOFSEV { get; set; } = 0;
        /// <summary>
        /// Busname
        /// </summary>
        [JsonProperty("bussiness_name")]
        public string BUSNAME { get; set; }
        /// <summary>
        /// Busseg
        /// </summary>
        [JsonProperty("bussiness_segment")]
        public string BUSSEG { get; set; }
        /// <summary>
        /// Monincome
        /// </summary>
        [JsonProperty("monthly_income")]
        public decimal? MONINCOME { get; set; } = 0;
        /// <summary>
        /// Profit
        /// </summary>
        [JsonProperty("profit")]
        public int? PROFIT { get; set; } = 0;
        /// <summary>
        /// Ctmchar
        /// </summary>
        [JsonProperty("customer_characteristic")]
        public string CTMCHAR { get; set; }
        /// <summary>
        /// Deptservice
        /// </summary>
        [JsonProperty("dept_service_capacity")]
        public string DEPTSERVICE { get; set; }
        /// <summary>
        /// Security
        /// </summary>
        [JsonProperty("security_document")]
        public string SECURITY { get; set; }
        /// <summary>
        /// Joindt
        /// </summary>
        /// 
        [JsonProperty("join_date")]
        public string JOINDT { get; set; }
        /// <summary>
        /// Nbcclassify
        /// </summary>
        [JsonProperty("nbc_classify")]
        public string NBCCLASSIFY { get; set; }
        /// <summary>
        /// Spilvl
        /// </summary>
        [JsonProperty("spi_level")]
        public string SPILVL { get; set; }
        /// <summary>
        /// Busaddr
        /// </summary>
        [JsonProperty("bussiness_address")]
        public string BUSADDR { get; set; }
        /// <summary>
        /// Laddr
        /// </summary>
        [JsonProperty("primary_address")]
        public LAddressModel LADDR { get; set; } = new LAddressModel();
        /// <summary>
        /// Maddr
        /// </summary>
        [JsonProperty("secondary_address")]
        public MAddressModel MADDR { get; set; } = new MAddressModel();
        /// <summary>
        /// Tunused1
        /// </summary>
        [JsonProperty("user_define_1")]
        public string TUNUSED1 { get; set; }
        /// <summary>
        /// Tunused2
        /// </summary>
        [JsonProperty("user_define_2")]
        public string TUNUSED2 { get; set; }
        /// <summary>
        /// Tunused3
        /// </summary>
        [JsonProperty("user_define_3")]
        public string TUNUSED3 { get; set; }
        /// <summary>
        /// Tunused4
        /// </summary>
        [JsonProperty("user_define_4")]
        public string TUNUSED4 { get; set; }
        /// <summary>
        /// Tunused5
        /// </summary>
        [JsonProperty("user_define_5")]
        public string TUNUSED5 { get; set; }
        /// <summary>
        /// Tunused6
        /// </summary>
        [JsonProperty("user_define_6")]
        public string TUNUSED6 { get; set; }
        /// <summary>
        /// Tunused7
        /// </summary>
        [JsonProperty("user_define_7")]
        public string TUNUSED7 { get; set; }
        /// <summary>
        /// Tunused8
        /// </summary>
        [JsonProperty("user_define_8")]
        public string TUNUSED8 { get; set; }
        /// <summary>
        /// Tunused9
        /// </summary>
        [JsonProperty("user_define_9")]
        public string TUNUSED9 { get; set; }
        /// <summary>
        /// Tunused10
        /// </summary>
        [JsonProperty("user_define_10")]
        public string TUNUSED10 { get; set; }
        /// <summary>
        /// Cunused1
        /// </summary>
        [JsonProperty("user_define_11")]
        public string CUNUSED1 { get; set; }
        ///// <summary>
        ///// cunused2
        ///// </summary>
        //[JsonProperty("user_define_12")]
        //public string UserDefine12 { get; set; }
        ///// <summary>
        ///// cunused 3
        ///// </summary>
        //[JsonProperty("user_define_13")]
        //public string UserDefine13 { get; set; }
        ///// <summary>
        ///// cunused4
        ///// </summary>
        //[JsonProperty("user_define_14")]
        //public string UserDefine14 { get; set; }
        ///// <summary>
        ///// cunused5
        ///// </summary>
        //[JsonProperty("user_define_15")]
        //public string UserDefine15 { get; set; }
        ///// <summary>
        ///// cunused6
        ///// </summary>
        //[JsonProperty("user_define_16")]
        //public string UserDefine16 { get; set; }
        ///// <summary>
        ///// cunused7
        ///// </summary>
        //[JsonProperty("user_define_17")]
        //public string UserDefine17 { get; set; }
        ///// <summary>
        ///// cunused8
        ///// </summary>
        //[JsonProperty("user_define_18")]
        //public string UserDefine18 { get; set; }
        ///// <summary>
        ///// cunused9
        ///// </summary>
        //[JsonProperty("user_define_19")]
        //public string UserDefine19 { get; set; }
        ///// <summary>
        ///// cunused10
        ///// </summary>
        //[JsonProperty("user_define_20")]
        //public string UserDefine20 { get; set; }
        ///// <summary>
        ///// Siddt
        ///// </summary>
        //[JsonProperty("secondary_issue_date_of_paper")]
        //public DateTime? SecondaryIssueDateOfPaper { get; set; }
        /// <summary>
        /// Siddt
        /// </summary>
        /// 
        [JsonProperty("secondary_issue_date_of_paper")]
        public string SIDDT { get; set; }
        /// <summary>
        /// Sidplace
        /// </summary>
        [JsonProperty("secondary_issue_place_of_paper")]
        public string SIDPLACE { get; set; }
        ///// <summary>
        ///// Sidexpdt
        ///// </summary>
        //[JsonProperty("secondary_expire_date_of_paper")]
        //public DateTime? SecondaryExpireDateOfPaper { get; set; }
        /// <summary>
        /// Sidexpdt
        /// </summary>
        /// 
        [JsonProperty("secondary_expire_date_of_paper")]
        public string SIDEXPDT { get; set; }
        ///// <summary>
        ///// Epydt
        ///// </summary>
        //[JsonProperty("employee_date")]
        //public DateTime? EmployeeDate { get; set; }
        /// <summary>
        /// Epydt
        /// </summary>
        /// 
        [JsonProperty("employee_date")]
        public string EPYDT { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("employee_status")]
        public string EMPLSTS { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("employee_type")]
        public string EMPLTYPE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_code")]
        //public string CreatedByCode { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty("created_by_name")]
        //public string CreatedByName { get; set; }
        ///// <summary>
        ///// BranchCode
        ///// </summary>
        //[JsonProperty("managing_branch_name")]
        //public string ManagingBranchName { get; set; }
        ///// <summary>
        ///// monitoring
        ///// </summary>
        //[JsonProperty("monitorings")]
        //public List<MonitoringModel> Monitorings { get; set; } = new();
        /// <summary>
        /// Education
        /// </summary>
        [JsonProperty("education")]
        public string EDUINF { get; set; }
        ///// <summary>
        ///// MigrationAddress
        ///// </summary>
        //[JsonProperty("migration_address")]
        //public string MigrationAddress { get; set; }
        ///// <summary>
        ///// Kscore
        ///// </summary>
        //[JsonProperty("kscroe")]
        //public string Kscore { get; set; }
        ///// <summary>
        ///// FirstAccessFinancialService
        ///// </summary>
        //[JsonProperty("first_access_financial_service")]
        //public string FirstAccessFinancialService { get; set; }
        /// <summary>
        /// Industry
        /// </summary>
        [JsonProperty("industry")]
        public string INDUSTRY { get; set; }
        /// <summary>
        /// SubIndustry
        /// </summary>
        [JsonProperty("sub_industry")]
        public string SUBINDUSTRY { get; set; }
        /// <summary>
        /// IncomeSourceSection
        /// </summary>
        [JsonProperty("income_source_section")]
        public string MSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("income_source_sub_section")]
        public string SSRCINCOME { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("credit_line_od_limit")]
        public decimal? CRLIMITOD { get; set; } = 0;


    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerLinkageRequestInsertModel : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("master_customer_id")]
        public int mcustomerid { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_description")]
        public string lkgdsc { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_eftime")]
        public string efttime { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_rttype")]
        public string rttype { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("linkage_credit_line")]
        public decimal? lkgline { get; set; }
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("linkage_od_credit_line")]
        public decimal? lkglineod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<LinkageDetail> LinkageDetailList { get; set; } = new List<LinkageDetail>();

    }
    /// <summary>
    /// 
    /// </summary>
    public partial class LinkageDetail : BaseNeptuneModel
    {
        /// <summary>
        /// DCUSTOMERID
        /// </summary>
        [JsonPropertyName("detail_customer_id")]
        public int DetailCustomerId { get; set; }
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonPropertyName("linkage_type")]
        public string LinkageType { get; set; } = string.Empty;
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonPropertyName("linkage_status")]
        public string LinkageStatus { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerLinkageRequestUpdateModel : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("master_customer_id")]
        public int mcustomerid { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("id")]
        public int lkgid { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_description")]
        public string lkgdsc { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_eftime")]
        public string efttime { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("linkage_rttype")]
        public string rttype { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("linkage_credit_line")]
        public decimal? lkgline { get; set; }
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("linkage_od_credit_line")]
        public decimal? lkglineod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<LinkageDetailUpdate> LinkageDetailList { get; set; } = new List<LinkageDetailUpdate>();

    }
    /// <summary>
    /// 
    /// </summary>
    public partial class LinkageDetailUpdate : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("lkgid")]
        public int lkgid { get; set; }
        /// <summary>
        /// DCUSTOMERID
        /// </summary>
        [JsonPropertyName("detail_customer_id")]
        public int DetailCustomerId { get; set; }
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonPropertyName("linkage_type")]
        public string LinkageType { get; set; } = string.Empty;
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonPropertyName("linkage_status")]
        public string LinkageStatus { get; set; } = string.Empty;

    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerGroupRequestUpdateModel : BaseNeptuneModel
    {
        ///// <summary>
        ///// Gets or sets the value of the catalog_name
        ///// </summary>
        //[JsonProperty("group_leader")]
        //public string mmemberid { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("id")]
        public int grpid { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("description")]
        public string descr { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("eftime")]
        public string efttime { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("rttype")]
        public string rttype { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("purpose")]
        public string purpose { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("group_name")]
        public string grpname { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("group_line")]
        public decimal? grpline { get; set; }
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("group_line_od")]
        public decimal? grplineod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("list_members")]
        public List<GroupDetailUpdate> ListMembers { get; set; } = new List<GroupDetailUpdate>();

    }
    /// <summary>
    /// 
    /// </summary>
    public partial class GroupDetailUpdate : BaseNeptuneModel
    {
        
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonPropertyName("customer_code")]
        [JsonProperty("customer_code")]
        public string memberid { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonPropertyName("id")]
        public int grpid { get; set; }
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("group_leader")]
        [JsonPropertyName("group_leader")]
        public string mmemberid { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerGroupRequestInsertModel : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("group_type")]
        public string grptype { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("description")]
        public string descr { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("eftime")]
        public string efttime { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("rttype")]
        public string rttype { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("purpose")]
        public string purpose { get; set; }
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("group_name")]
        public string grpname { get; set; }

        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("group_line")]
        public decimal? grpline { get; set; }
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("group_line_od")]
        public decimal? grplineod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [JsonProperty("list_members")]
        public List<GroupDetailInsert> ListMembers { get; set; } = new List<GroupDetailInsert>();

    }
    /// <summary>
    /// 
    /// </summary>
    public partial class GroupDetailInsert : BaseNeptuneModel
    {

        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonPropertyName("customer_code")]
        [JsonProperty("customer_code")]
        public string memberid { get; set; }
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("group_leader")]
        [JsonPropertyName("group_leader")]
        public string mmemberid { get; set; }

    }
}