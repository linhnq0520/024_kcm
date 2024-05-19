using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models;

/// <summary>
/// The credit tariff catalog response class
/// </summary>
/// <seealso cref="BaseNeptuneModel"/>

public class CrediIfcCatalogResponse : BaseNeptuneModel
{
    
    /// <summary>
    /// Gets or sets the value of the ifccd
    /// </summary>
    [JsonProperty("ifc_code")] public int IFCCD { get; set; }
        
    
    /// <summary>
    /// Gets or sets the value of the ifcname
    /// </summary>
    [JsonProperty("ifc_name")] public string IFCNAME { get; set; }
     
   
    /// <summary>
    /// Gets or sets the value of the ifcval
    /// </summary>
    [JsonProperty("ifc_value")] public string IFCVAL { get; set; }
    /// <summary>
    /// Gets or sets the value of the ifctypect
    /// </summary>
    [JsonProperty("ifc_type")] public string IFCTYPECT { get; set; }

    /// <summary>
    /// Gets or sets the value of the ifctnr
    /// </summary>
    [JsonProperty("ifc_tennor")] public string IFCTNR { get; set; }

    /// <summary>
    /// Gets or sets the value of the ifctnrunct
    /// </summary>
    [JsonProperty("ifc_tennor_unit")] public string IFCTNRUNCT { get; set; }

    /// <summary>
    /// Gets or sets the value of the ifccond
    /// </summary>
    [JsonProperty("ifc_condition")] public string IFCCOND { get; set; }

    /// <summary>
    /// Gets or sets the value of the ifcstsct
    /// </summary>
    [JsonProperty("ifc_status")] public string IFCSTSCT { get; set; }
    
    /// <summary>
    /// Gets or sets the value of the trfcd
    /// </summary>
    [JsonProperty("ifc_code")] public int TRFCD { get; set; }
}


/// <summary>
/// The credi tariff catalog response class
/// </summary>
/// <seealso cref="BaseNeptuneModel"/>

public class CrediTariffCatalogResponse : BaseNeptuneModel
{
    /// <summary>
    /// Gets or sets the value of the trfname
    /// </summary>
    [JsonProperty("tariff_name")] public string TRFNAME { get; set; }
     
    
    /// <summary>
    /// Gets or sets the value of the trfcond
    /// </summary>
    [JsonProperty("tariff_condition")] public string TRFCOND { get; set; }

   
    /// <summary>
    /// Gets or sets the value of the trfsts
    /// </summary>
    [JsonProperty("tariff_status")] public string TRFSTS { get; set; }
    
   
    /// <summary>
    /// Gets or sets the value of the trfcd
    /// </summary>
    [JsonProperty("tariff_code")] public int TRFCD { get; set; }
}