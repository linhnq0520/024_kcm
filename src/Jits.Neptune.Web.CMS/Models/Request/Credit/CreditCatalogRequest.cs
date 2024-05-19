using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models;

/// <summary>
/// The credit catalog insert request class
/// </summary>

public class CrdCatalogInsertRequest:BaseNeptuneModel
{   
    
    /// <summary>
    /// Gets or sets the value of the catcd
    /// </summary>
    [JsonProperty("USRID")]
    public int USRID { get; set; }
    
    /// <summary>
    /// Gets or sets the value of the catcd
    /// </summary>
    [JsonProperty("catalog_code")]
    public string CATCD { get; set; }

    /// <summary>
    /// Gets or sets the value of the catname
    /// </summary>
    [JsonProperty("catalog_name")]
    public string CATNAME { get; set; }

    /// <summary>
    /// Gets or sets the value of the ccrcd
    /// </summary>
    [JsonProperty("currency_code")]
    public string CCRCD { get; set; }

    /// <summary>
    /// Gets or sets the value of the sccrcd
    /// </summary>
    [JsonProperty("secure_currency_code")]
    public string SCCRCD { get; set; }

    /// <summary>
    /// Gets or sets the value of the crdtype
    /// </summary>
    [JsonProperty("credit_type")]
    public string CRDTYPE { get; set; }

    /// <summary>
    /// Gets or sets the value of the tntype
    /// </summary>
    [JsonProperty("tenor_type")]
    public string TNTYPE { get; set; }

    // /// <summary>
    // /// Gets or sets the value of the is syndicated
    // /// </summary>
    // [JsonProperty("is_syndicated")]
    // public string IsSyndicated { get; set; }

    /// <summary>
    /// Gets or sets the value of the intmode
    /// </summary>
    [JsonProperty("interest_computation_mode")]
    public string INTMODE { get; set; }

    /// <summary>
    /// Gets or sets the value of the sectype
    /// </summary>
    [JsonProperty("secure_type")]
    public string SECTYPE { get; set; }

    /// <summary>
    /// Gets or sets the value of the secrate
    /// </summary>
    [JsonProperty("secure_rate")]
    public double? SECRATE { get; set; }

    /// <summary>
    /// Gets or sets the value of the prtn
    /// </summary>
    [JsonProperty("principal_tenor")]
    public double PRTN { get; set; }

    /// <summary>
    /// Gets or sets the value of the prtnun
    /// </summary>
    [JsonProperty("principal_tenor_unit")]
    public string PRTNUN { get; set; }

    /// <summary>
    /// Gets or sets the value of the inttn
    /// </summary>
    [JsonProperty("interest_tenor")]
    public double INTTN { get; set; }

    /// <summary>
    /// Gets or sets the value of the inttnun
    /// </summary>
    [JsonProperty("interest_tenor_unit")]
    public string INTTNUN { get; set; }

    /// <summary>
    /// Gets or sets the value of the fntn
    /// </summary>
    [JsonProperty("fine_tenor")]
    public double FNTN { get; set; }

    /// <summary>
    /// Gets or sets the value of the fntnun
    /// </summary>
    [JsonProperty("fine_tenor_unit")]
    public string FNTNUN { get; set; }

    /// <summary>
    /// Gets or sets the value of the crdprp
    /// </summary>
    [JsonProperty("credit_purpose")]
    public string CRDPRP { get; set; }

    /// <summary>
    /// Gets or sets the value of the crdcls
    /// </summary>
    [JsonProperty("credit_classification")]
    public string CRDCLS { get; set; }

    /// <summary>
    /// Gets or sets the value of the crdfacility
    /// </summary>
    [JsonProperty("credit_facility")]
    public string CRDFACILITY { get; set; }

    /// <summary>
    /// Gets or sets the value of the dcrate
    /// </summary>
    [JsonProperty("discount_rate")]
    public double DCRATE { get; set; }
    
    /// <summary>
    /// Gets or sets the value of the rdcrate
    /// </summary>
    [JsonProperty("re_discount_rate")]
    public int RDCRATE { get; set; }

    /// <summary>
    /// Gets or sets the value of the dbmode
    /// </summary>
    [JsonProperty("disbursement_mode")]
    public string DBMODE { get; set; }

    /// <summary>
    /// Gets or sets the value of the prgrpr
    /// </summary>
    [JsonProperty("principal_grace_period")]
    public double PRGRPR { get; set; }

    /// <summary>
    /// Gets or sets the value of the intgrpr
    /// </summary>
    [JsonProperty("interest_grace_period")]
    public double INTGRPR { get; set; }

    /// <summary>
    /// Gets or sets the value of the fngrpr
    /// </summary>
    [JsonProperty("fine_grace_period")]
    public double FNGRPR { get; set; }

    /// <summary>
    /// Gets or sets the value of the isprv
    /// </summary>
    [JsonProperty("is_provision")]
    public string ISPRV { get; set; }

    /// <summary>
    /// Gets or sets the value of the prvtn
    /// </summary>
    [JsonProperty("provision_tenor")]
    public double PRVTN { get; set; }

    /// <summary>
    /// Gets or sets the value of the prvtnun
    /// </summary>
    [JsonProperty("provision_tenor_unit")]
    public string PRVTNUN { get; set; }

    /// <summary>
    /// Gets or sets the value of the rllovr
    /// </summary>
    [JsonProperty("rollover_option")]
    public string RLLOVR { get; set; }

    /// <summary>
    /// Gets or sets the value of the restruct
    /// </summary>
    [JsonProperty("restruct")]
    public string RESTRUCT { get; set; }

    /// <summary>
    /// Gets or sets the value of the hdinttnr
    /// </summary>
    [JsonProperty("holiday_interest_tenor")]
    public double HDINTTNR { get; set; }

    /// <summary>
    /// Gets or sets the value of the hdprntnr
    /// </summary>
    [JsonProperty("holiday_principal_due_on")]
    public double HDPRNTNR { get; set; }

    /// <summary>
    /// Gets or sets the value of the hdfntnr
    /// </summary>
    [JsonProperty("holiday_fine_tenor")]
    public double HDFNTNR { get; set; }

    /// <summary>
    /// Gets or sets the value of the pdecrnd
    /// </summary>
    [JsonProperty("principal_decimal_rounding")]
    public double PDECRND { get; set; }

    /// <summary>
    /// Gets or sets the value of the idecrnd
    /// </summary>
    [JsonProperty("interest_decimal_rounding")]
    public double IDECRND { get; set; }

    /// <summary>
    /// Gets or sets the value of the catsts
    /// </summary>
    [JsonProperty("catalog_status")]
    public string CATSTS { get; set; }

    /// <summary>
    /// Gets or sets the value of the ostype
    /// </summary>
    [JsonProperty("owner_security_type")]
    public string OSTYPE { get; set; }

    /// <summary>
    /// Gets or sets the value of the gstype
    /// </summary>
    [JsonProperty("guarantor_security_type")]
    public string GSTYPE { get; set; }

    /// <summary>
    /// Gets or sets the value of the pprepaid
    /// </summary>
    [JsonProperty("principal_repayment_in_advance")]
    public string PPREPAID { get; set; }

    /// <summary>
    /// Gets or sets the value of the iprepaid
    /// </summary>
    [JsonProperty("interest_repayment_in_advance")]
    public string IPREPAID { get; set; }

    /// <summary>
    /// Gets or sets the value of the prvrate
    /// </summary>
    [JsonProperty("general_provision")]
    public double PRVRATE { get; set; }

    /// <summary>
    /// Gets or sets the value of the prdtype
    /// </summary>
    [JsonProperty("product_type")]
    public string PRDTYPE { get; set; }

    /// <summary>
    /// Gets or sets the value of the pngrpr
    /// </summary>
    [JsonProperty("penalty_grace_period")]
    public double PNGRPR { get; set; }

    /// <summary>
    /// Gets or sets the value of the grpid
    /// </summary>
    // [JsonProperty("catalogue_gl")]
    public int GRPID { get; set; }

    // /// <summary>
    // /// Gets or sets the value of the extension info
    // /// </summary>
    // [JsonProperty("extension_info")]
    // public string ExtensionInfo { get; set; }

    /// <summary>
    /// Gets or sets the value of the trfcd
    /// </summary>
    // [JsonProperty("ifc_list")]
    public int TRFCD { get; set; }

    /// <summary>
    /// Gets or sets the value of the gschbase
    /// </summary>
    [JsonProperty("generate_schedule_base")]
    public string GSCHBASE { get; set; }

    /// <summary>
    /// Gets or sets the value of the graffi
    /// </summary>
    [JsonProperty("monthly_fee_grace_period")]
    public double GRAFFI { get; set; }

    /// <summary>
    /// Gets or sets the value of the epaidoff
    /// </summary>
    [JsonProperty("early_paid_off")]
    public double EPAIDOFF { get; set; }
}


/// <summary>
/// The cattalog definition tariff request class
/// </summary>

public class CattalogDefinitionTariffRequest
{
    /// <summary>
    /// Gets or sets the value of the tariff code
    /// </summary>
    [JsonProperty("tariff_code")]
    public int TariffCode { get; set; }
}