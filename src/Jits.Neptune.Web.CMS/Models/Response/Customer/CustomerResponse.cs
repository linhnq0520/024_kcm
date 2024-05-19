#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null

// Jits.Neptune.Web.Framework.dll

#endregion

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.CMS.Models
{
    
    /// <summary>
    /// 
    /// </summary>
    public class CustomerProfileResponseSearch : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("id")]
        public int? customerid { get; set; }
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
        [JsonProperty("date_of_birth")]
        public DateTime dob { get; set; }

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
        [JsonProperty("contact_local_address")]
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("old_id_of_customer")]
        public string refid { get; set; }

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

    }

    
    /// <summary>
    /// 
    /// </summary>
    public class CustomerLinkageResponseSearch : BaseNeptuneModel
    {
        /// <summary>
        /// Gets or sets the value of the catid
        /// </summary>
        [JsonProperty("id")]
        public int? lkgid { get; set; }
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
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("linkage_credit_line")]
        public decimal? lkgline { get; set; } = 0;

    }
    /// <summary>
    /// 
    /// </summary>
    public class CustomerGroupResponseSearch : BaseNeptuneModel
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
        [JsonProperty("description")]
        public string descr { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("group_leader")]
        public string mmemberid { get; set; }
    }

    /// <summary>
    /// CustomerViewResponseModel
    /// </summary>
    public partial class CustomerViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// CustomerViewResponseModel
        /// </summary>
        public CustomerViewResponseModel() { }
        /// <summary>
        /// CUSTOMERID
        /// </summary>
        [JsonProperty("id")]
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
        ///// <summary>
        ///// INCOME
        ///// </summary>
        //[JsonProperty("income")]
        //public decimal? INCOME { get; set; } 
        /// <summary>
        /// DOB
        /// </summary>
        [JsonProperty("date_of_birth")]
        public DateTime? DOB { get; set; }
        /// <summary>
        /// ANNIVERSARY
        /// </summary>
        [JsonProperty("anniversary")]
        public AnniversaryModel ANNIVERSARY { get; set; } = new AnniversaryModel();

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
        [JsonProperty("issue_date_of_paper")]
        public DateTime? IDDT { get; set; }
        /// <summary>
        /// Idplace
        /// </summary>
        [JsonProperty("issue_place_of_paper")]
        public string IDPLACE { get; set; }
        /// <summary>
        /// Idexpdt
        /// </summary>
        [JsonProperty("expire_date_of_paper")]
        public DateTime? IDEXPDT { get; set; }
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
        [JsonProperty("open_date")]
        public DateTime? OPNDT { get; set; }
        /// <summary>
        /// Lastdt
        /// </summary>
        [JsonProperty("last_date")]
        public DateTime? LASTDT { get; set; }
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
        /// <summary>
        /// Aprdt
        /// </summary>
        [JsonProperty("approve_date")]
        public DateTime? APRDT { get; set; }
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
        /// <summary>
        /// Joindt
        /// </summary>
        [JsonProperty("join_date")]
        public DateTime? JOINDT { get; set; }
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
        public string UserDefine1 { get; set; }
        /// <summary>
        /// Tunused2
        /// </summary>
        [JsonProperty("user_define_2")]
        public string UserDefine2 { get; set; }
        /// <summary>
        /// Tunused3
        /// </summary>
        [JsonProperty("user_define_3")]
        public string UserDefine3 { get; set; }
        /// <summary>
        /// Tunused4
        /// </summary>
        [JsonProperty("user_define_4")]
        public string UserDefine4 { get; set; }
        /// <summary>
        /// Tunused5
        /// </summary>
        [JsonProperty("user_define_5")]
        public string UserDefine5 { get; set; }
        /// <summary>
        /// Tunused6
        /// </summary>
        [JsonProperty("user_define_6")]
        public string UserDefine6 { get; set; }
        /// <summary>
        /// Tunused7
        /// </summary>
        [JsonProperty("user_define_7")]
        public string UserDefine7 { get; set; }
        /// <summary>
        /// Tunused8
        /// </summary>
        [JsonProperty("user_define_8")]
        public string UserDefine8 { get; set; }
        /// <summary>
        /// Tunused9
        /// </summary>
        [JsonProperty("user_define_9")]
        public string UserDefine9 { get; set; }
        /// <summary>
        /// Tunused10
        /// </summary>
        [JsonProperty("user_define_10")]
        public string UserDefine10 { get; set; }
        /// <summary>
        /// Cunused1
        /// </summary>
        [JsonProperty("user_define_11")]
        public string UserDefine11 { get; set; }
        /// <summary>
        /// cunused2
        /// </summary>
        [JsonProperty("user_define_12")]
        public string UserDefine12 { get; set; }
        /// <summary>
        /// cunused 3
        /// </summary>
        [JsonProperty("user_define_13")]
        public string UserDefine13 { get; set; }
        /// <summary>
        /// cunused4
        /// </summary>
        [JsonProperty("user_define_14")]
        public string UserDefine14 { get; set; }
        /// <summary>
        /// cunused5
        /// </summary>
        [JsonProperty("user_define_15")]
        public string UserDefine15 { get; set; }
        /// <summary>
        /// cunused6
        /// </summary>
        [JsonProperty("user_define_16")]
        public string UserDefine16 { get; set; }
        /// <summary>
        /// cunused7
        /// </summary>
        [JsonProperty("user_define_17")]
        public string UserDefine17 { get; set; }
        /// <summary>
        /// cunused8
        /// </summary>
        [JsonProperty("user_define_18")]
        public string UserDefine18 { get; set; }
        /// <summary>
        /// cunused9
        /// </summary>
        [JsonProperty("user_define_19")]
        public string UserDefine19 { get; set; }
        /// <summary>
        /// cunused10
        /// </summary>
        [JsonProperty("user_define_20")]
        public string UserDefine20 { get; set; }
        /// <summary>
        /// Siddt
        /// </summary>
        [JsonProperty("secondary_issue_date_of_paper")]
        public DateTime? SIDDT { get; set; }
        /// <summary>
        /// Sidplace
        /// </summary>
        [JsonProperty("secondary_issue_place_of_paper")]
        public string SIDPLACE { get; set; }
        /// <summary>
        /// Sidexpdt
        /// </summary>
        [JsonProperty("secondary_expire_date_of_paper")]
        public DateTime? SIDEXPDT { get; set; }
        /// <summary>
        /// Epydt
        /// </summary>
        [JsonProperty("employee_date")]
        public DateTime? EPYDT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_by_code")]
        public string CreatedByCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created_by_name")]
        public string CreatedByName { get; set; }
        /// <summary>
        /// BranchCode
        /// </summary>
        [JsonProperty("managing_branch_name")]
        public string ManagingBranchName { get; set; }
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
        /// <summary>
        /// MigrationAddress
        /// </summary>
        [JsonProperty("migration_address")]
        public string MigrationAddress { get; set; }
        /// <summary>
        /// Kscore
        /// </summary>
        [JsonProperty("kscroe")]
        public string Kscore { get; set; }
        /// <summary>
        /// FirstAccessFinancialService
        /// </summary>
        [JsonProperty("first_access_financial_service")]
        public string FirstAccessFinancialService { get; set; }
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
        [JsonProperty("employee_status")]
        public string EMPLSTS { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("employee_type")]
        public string EMPLTYPE { get; set; }
        /// <summary>
        /// IncomeSourceSubSection
        /// </summary>
        [JsonProperty("credit_line_od_limit")]
        public decimal? CRLIMITOD { get; set; } = 0;
    }
    /// <summary>
    /// CustomerNameModel
    /// </summary>
    public partial class CustomerNameModel : BaseNeptuneModel
    {
        /// <summary>
        /// FamilyNameEn
        /// </summary>
        [JsonProperty("faname_en")]
        public string E { get; set; }
        /// <summary>
        /// GivenNameEn
        /// </summary>
        [JsonProperty("giname_en")]
        public string I { get; set; }
        /// <summary>
        /// FamilyNameEn
        /// </summary>
        [JsonProperty("faname_kh")]
        public string F { get; set; }
        /// <summary>
        /// GivenNameEn
        /// </summary>
        [JsonProperty("giname_kh")]
        public string G { get; set; }
        /// <summary>
        /// OtherName
        /// </summary>
        [JsonProperty("other_name")]
        public string N { get; set; }
    }

    /// <summary>
    /// AnniversaryModel
    /// </summary>
    public partial class AnniversaryModel : BaseNeptuneModel
    {
        /// <summary>
        /// Married date
        /// </summary>
        [JsonProperty("married_date")]
        public DateTime? M { get; set; }
        /// <summary>
        /// Graduation date
        /// </summary>
        [JsonProperty("graduation_date")]
        public DateTime? G { get; set; }
        /// <summary>
        /// Starting date of company
        /// </summary>
        [JsonProperty("starting_date_of_company")]
        public DateTime? B { get; set; }
    }

    /// <summary>
    /// PhoneModel
    /// </summary>
    public partial class PhoneModel : BaseNeptuneModel
    {
        /// <summary>
        /// mobile
        /// </summary>
        [JsonProperty("p_mobile")]
        public string H { get; set; }
        /// <summary>
        /// Office
        /// </summary>
        [JsonProperty("p_office")]
        public string O { get; set; }
        /// <summary>
        /// Fax
        /// </summary>
        [JsonProperty("p_fax")]
        public string C { get; set; }
        /// <summary>
        /// Home
        /// </summary>
        [JsonProperty("p_home")]
        public string F { get; set; }
        /// <summary>
        /// Unknown
        /// </summary>
        [JsonProperty("p_unknown")]
        public string T { get; set; }
    }

    /// <summary>
    /// ReferenceCodeModel 
    /// </summary>
    public partial class ReferenceCodeModel : BaseNeptuneModel
    {
        /// <summary>
        /// Bic
        /// </summary>
        [JsonProperty("bic")]
        public int? B { get; set; } = 0;
        /// <summary>
        /// Domestic bank code
        /// </summary>
        [JsonProperty("domestic_bank_code")]
        public int? C { get; set; } = 0;
        /// <summary>
        /// Internal Code
        /// </summary>
        [JsonProperty("internal_code")]
        public int? I { get; set; } = 0;
    }

    /// <summary>
    /// OtherEmailAddressModel
    /// </summary>
    public partial class OtherEmailAddressModel : BaseNeptuneModel
    {
        /// <summary>
        /// Home
        /// </summary>
        [JsonProperty("e_home")]
        public string H { get; set; }
        /// <summary>
        /// Office
        /// </summary>
        [JsonProperty("e_office")]
        public string O { get; set; }
        /// <summary>
        /// Imyahoo
        /// </summary>
        [JsonProperty("e_imyahoo")]
        public string I { get; set; }
        /// <summary>
        /// Facebook
        /// </summary>
        [JsonProperty("e_facebook")]
        public string F { get; set; }

    }
    /// <summary>
    /// RepresentativeInformationModel
    /// </summary>
    public partial class RepresentativeInformationModel : BaseNeptuneModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("r_name")]
        public string N { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("r_id")]
        public string I { get; set; }
        /// <summary>
        /// Phone
        /// </summary>
        [JsonProperty("r_phone")]
        public string P { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("r_title")]
        public string T { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("r_nation")]
        public string A { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("r_relative")]
        public string R { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("r_day_of_birth")]
        public string D { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("r_gender")]
        public string G { get; set; }
    }

    /// <summary>
    /// LegalLocalAddress
    /// </summary>
    public partial class LAddressModel : BaseNeptuneModel
    {
        /// <summary>
        /// Address in Cambodia
        /// </summary>
        [JsonProperty("address_type")]
        public string B { get; set; } = string.Empty;
        /// <summary>
        /// Province
        /// </summary>
        [JsonProperty("province")]
        public string H { get; set; } = string.Empty;
        /// <summary>
        /// Village
        /// </summary>
        [JsonProperty("village")]
        public string LW { get; set; } = string.Empty;
        /// <summary>
        /// District
        /// </summary>
        [JsonProperty("district")]
        public string LF { get; set; } = string.Empty;
        /// <summary>
        /// Commune
        /// </summary>
        [JsonProperty("commune")]
        public string LR { get; set; } = string.Empty;
        /// <summary>
        /// GroupNo
        /// </summary>
        [JsonProperty("group_no")]
        public string T { get; set; } = string.Empty;
        /// <summary>
        /// StreetNo
        /// </summary>
        [JsonProperty("street_no")]
        public string C { get; set; } = string.Empty;
        /// <summary>
        /// HouseNo
        /// </summary>
        [JsonProperty("house_no")]
        public string D { get; set; } = string.Empty;
        /// <summary>
        /// AddressDetail
        /// </summary>
        [JsonProperty("address_detail")]
        public string A { get; set; } = string.Empty;

    }

    /// <summary>
    /// LegalLocalAddress
    /// </summary>
    public partial class MAddressModel : BaseNeptuneModel
    {
        /// <summary>
        /// Address in Cambodia
        /// </summary>
        [JsonProperty("address_type")]
        public string B { get; set; } = string.Empty;
        /// <summary>
        /// Province
        /// </summary>
        [JsonProperty("province")]
        public string H { get; set; } = string.Empty;
        /// <summary>
        /// Village
        /// </summary>
        [JsonProperty("village")]
        public string MW { get; set; } = string.Empty;
        /// <summary>
        /// District
        /// </summary>
        [JsonProperty("district")]
        public string MF { get; set; } = string.Empty;
        /// <summary>
        /// Commune
        /// </summary>
        [JsonProperty("commune")]
        public string MR { get; set; } = string.Empty;
        /// <summary>
        /// GroupNo
        /// </summary>
        [JsonProperty("group_no")]
        public string T { get; set; } = string.Empty;
        /// <summary>
        /// StreetNo
        /// </summary>
        [JsonProperty("street_no")]
        public string C { get; set; } = string.Empty;
        /// <summary>
        /// HouseNo
        /// </summary>
        [JsonProperty("house_no")]
        public string D { get; set; } = string.Empty;
        /// <summary>
        /// AddressDetail
        /// </summary>
        [JsonProperty("address_detail")]
        public string A { get; set; } = string.Empty;

    }

    /// <summary>
    /// CustomerLinkageViewResponseModel
    /// </summary>
    public partial class CustomerLinkageViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Customer Group Search Model
        /// </summary>
        public CustomerLinkageViewResponseModel() { }
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public int lkgid { get; set; }
        /// <summary>
        /// LKGCD
        /// </summary>
        [JsonProperty("linkage_code")]
        public string lkgcd { get; set; }
        /// <summary>
        /// MCUSTOMERCD
        /// </summary>
        [JsonProperty("master_customer_code")]
        public string mcustomercd { get; set; }
        /// <summary>
        /// MCUSTOMERCD
        /// </summary>
        [JsonProperty("master_customer_id")]
        public int mcustomerid { get; set; }
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("master_customer_name")]
        public string mfullname { get; set; } = "";
        /// <summary>
        /// LKGDSC
        /// </summary>
        [JsonProperty("linkage_description")]
        public string lkgdsc { get; set; }
        /// <summary>
        /// LKGLINE
        /// </summary>
        [JsonProperty("linkage_credit_line")]
        public decimal lkgline { get; set; }
        /// <summary>
        /// CCRCD
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }

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
        /// 
        /// </summary>
        [JsonProperty("linkage_detail_list")]
        public List<LinkageDetailResponse> LinkageDetailList { get; set; }

    }
    /// <summary>
    /// LinkageDetailResponse class
    /// </summary>
    public partial class LinkageDetailResponse : BaseNeptuneModel
    {
        /// <summary>
        /// DCUSTOMERID
        /// </summary>
        [JsonProperty("detail_customer_id")]
        public int dcustomerid { get; set; }
        /// <summary>
        /// DCUSTOMERID
        /// </summary>
        [JsonProperty("lkgid")]
        public int lkgid { get; set; }
        /// <summary>
        /// DCUSTOMERID
        /// </summary>
        [JsonProperty("detail_customer_code")]
        public string dcustomercd { get; set; } = string.Empty;
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonProperty("detail_customer_name")]
        public string dfullname { get; set; } = string.Empty;
        /// <summary>
        /// STATUS
        /// </summary>
        [JsonProperty("linkage_status")]
        public string status { get; set; } = string.Empty;
        /// <summary>
        /// STATUS
        /// </summary>
        [JsonProperty("linkage_type")]
        public string lkgtype { get; set; } = string.Empty;


    }

    /// <summary>
    /// CustomerMediaSearchResponseModel
    /// </summary>
    public partial class CustomerMediaSearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Customer Media Search Model Response
        /// </summary>
        public CustomerMediaSearchResponseModel() { }

        /// <summary>
        /// MEDIAID
        /// </summary>
        [JsonProperty("id")]
        public int mediaid { get; set; }
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
        public DateTime? expdt { get; set; }
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
        ///
        /// </summary>
        [JsonProperty("customer_type")]
        public string reftypect { get; set; }
        /// <summary>
        /// OPNDT
        /// </summary>
        [JsonProperty("open_date")]
        public DateTime? opndt { get; set; }
        /// <summary>
        /// LASTDT
        /// </summary>
        [JsonProperty("last_update_date")]
        public DateTime? lastdt { get; set; }


    }

    /// <summary>
    /// CustomerLinkageViewResponseModel
    /// </summary>
    public partial class CustomerGroupViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("group_leader")]
        public string mmemberid { get; set; }
        /// <summary>
        /// Customer Group Search Model
        /// </summary>
        public CustomerGroupViewResponseModel() { }
        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public int grpid { get; set; }
        /// <summary>
        /// LKGCD
        /// </summary>
        [JsonProperty("group_code")]
        public string grpcd { get; set; }
        /// <summary>
        /// MCUSTOMERCD
        /// </summary>
        [JsonProperty("group_name")]
        public string grpname { get; set; }
        /// <summary>
        /// MCUSTOMERCD
        /// </summary>
        [JsonProperty("group_type")]
        public string grptype { get; set; }
        /// <summary>
        /// FULLNAME
        /// </summary>
        [JsonProperty("purpose")]
        public string purpose { get; set; }
        /// <summary>
        /// LKGDSC
        /// </summary>
        [JsonProperty("description")]
        public string descr { get; set; }
        /// <summary>
        /// LKGLINE
        /// </summary>
        [JsonProperty("group_line")]
        public decimal grpline { get; set; }
        /// <summary>
        /// LKGLINE
        /// </summary>
        [JsonProperty("group_line_od")]
        public decimal GRPLINEOD { get; set; }
        /// <summary>
        /// CCRCD
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrcd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("list_members")]
        public List<ListMembersResponse> ListMembers { get; set; }

    }
    /// <summary>
    /// LinkageDetailResponse class
    /// </summary>
    public partial class ListMembersResponse : BaseNeptuneModel
    {        /// <summary>
        /// DCUSTOMERID
        /// </summary>
        [JsonProperty("customer_code")]
        public string customercd { get; set; } = string.Empty;
        /// <summary>
        /// LKGTYPE
        /// </summary>
        [JsonProperty("fullname")]
        public string fullname { get; set; } = string.Empty;
        /// <summary>
        /// STATUS
        /// </summary>
        [JsonProperty("company")]
        public string company { get; set; } = string.Empty;

        /// <summary>
        /// STATUS
        /// </summary>
        [JsonProperty("is_group_leader")]
        public int is_group_leader { get; set; } = 0;
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("group_leader")]
        [JsonPropertyName("group_leader")]
        public string mmemberid { get; set; } = string.Empty;

    }
}