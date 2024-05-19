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
    public class CrdCatalogueDefinitionSearch : SearchBaseModel
    {
      
        /// <summary>
        /// Gets or sets the value of the catalog code
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }
     
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("catalog_name")] public string catname { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the catalog status
        /// </summary>
        [JsonProperty("catalog_status")] public string catsts { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("currency_code")] public string ccrcd { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("credit_facility")] public string crdfacility { get; set; }
       
        /// <summary>
        /// Gets or sets the value of the credit type
        /// </summary>credit_type
        [JsonProperty("credit_type")] public string crdtype { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("tenor_type")] public string tntype { get; set; }
        /// <summary>
        /// Gets or sets the value of the page index
        /// </summary>
        public int page_index { get; set; }
        /// <summary>
        /// Gets or sets the value of the page size
        /// </summary>
        public int page_size { get; set; }
    }
    
    /// <summary>
    /// The crd account search class
    /// </summary>
    /// <seealso cref="BaseNeptuneModel"/>
    public class CrdAccountSearch : BaseNeptuneModel
    {
      
        /// <summary>
        /// Gets or sets the value of the catalog code
        /// </summary>
        [JsonProperty("account_number")] public string acno { get; set; }
     
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("account_name")] public string acname { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the catalog status
        /// </summary>
        [JsonProperty("currency_code")] public string ccrcd { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("customer_code")] public string customercd { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("catalog_code")] public string catcd { get; set; }
       
        /// <summary>
        /// Gets or sets the value of the credit type
        /// </summary>credit_type
        [JsonProperty("credit_type")] public string crdtype { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("tenor_type")] public string tntype { get; set; }
        
        
        /// <summary>
        /// Gets or sets the value of the crdsts
        /// </summary>
        [JsonProperty("credit_status")] public string crdsts { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the refid
        /// </summary>
        [JsonProperty("reference_number")] public string refid { get; set; }
        
        
        /// <summary>
        /// Gets or sets the value of the page index
        /// </summary>
        public int page_index { get; set; }
        /// <summary>
        /// Gets or sets the value of the page size
        /// </summary>
        public int page_size { get; set; }
    }
    
     /// <summary>
     /// 
     /// </summary>
     public class CrdIfcDenfinitionSearch : BaseNeptuneModel
    {
      
        /// <summary>
        /// Gets or sets the value of the catalog code
        /// </summary>
        [JsonProperty("account_number")] public string ifccd { get; set; }
     
        /// <summary>
        /// Gets or sets the value of the catalog_name
        /// </summary>
        [JsonProperty("account_name")] public string ifccond { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the catalog status
        /// </summary>
        [JsonProperty("currency_code")] public string ifcname { get; set; }
      
        /// <summary>
        /// Gets or sets the value of the currency code
        /// </summary>
        [JsonProperty("customer_code")] public string ifcsts { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the credit facility
        /// </summary>
        [JsonProperty("catalog_code")] public string ifctnr { get; set; }
       
        /// <summary>
        /// Gets or sets the value of the credit type
        /// </summary>credit_type
        [JsonProperty("credit_type")] public string ifctnrun { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the tenor type
        /// </summary>tenor_type
        [JsonProperty("tenor_type")] public string ifctypect { get; set; }
        
        
        /// <summary>
        /// Gets or sets the value of the crdsts
        /// </summary>
        [JsonProperty("credit_status")] public string ifcval { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the refid
        /// </summary>
        [JsonProperty("reference_number")] public string valtypect { get; set; }
        
        
        /// <summary>
        /// Gets or sets the value of the page index
        /// </summary>
        public int page_index { get; set; }
        /// <summary>
        /// Gets or sets the value of the page size
        /// </summary>
        public int page_size { get; set; }
    }
    
}