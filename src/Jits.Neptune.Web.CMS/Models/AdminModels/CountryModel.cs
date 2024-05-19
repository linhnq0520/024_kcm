using Jits.Neptune.Web.CMS.LogicOptimal9.Utils;
using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jits.Neptune.Web.Admin.Models
{
    /// <summary>
    /// MultiLingualCountryName
    /// </summary>
    public class MultiCountryName : BaseNeptuneModel
    {
        /// <summary>
        /// Country Name 1
        /// </summary>
        [JsonProperty("country_name1")]
        public string CN1 { get; set; } = null;

        /// <summary>
        /// Country Name 2
        /// </summary>
        [JsonProperty("country_name2")]
        public string CN2 { get; set; } = null;

        /// <summary>
        /// Country Name 3
        /// </summary>
        [JsonProperty("country_name3")]
        public string CN3 { get; set; } = null;
    }

    /// <summary>
    /// 
    /// </summary>
    public class MultiCountryShortName : BaseNeptuneModel
    {
        /// <summary>
        /// Short Name 1
        /// </summary>
        [JsonProperty("short_name1")]
        public string SN1 { get; set; } = null;

        /// <summary>
        /// Short Name 2
        /// </summary>
        [JsonProperty("short_name2")]
        public string SN2 { get; set; } = null;

        /// <summary>
        /// Short Name 3
        /// </summary>
        [JsonProperty("short_name3")]
        public string SN3 { get; set; } = null;
    }

    /// <summary>
    /// Country create model
    /// </summary>
    public partial class CountryCreateModel : BaseTransactionModel
    {

        /// <summary>
        /// Country create model constructor
        /// </summary>
        public CountryCreateModel()
        {
        }
        /// <summary>
        /// Iso2Alpha
        /// </summary>
        public string Iso2Alpha { get; set; }

        /// <summary>
        /// Iso3Alpha
        /// </summary>
        public string Iso3Alpha { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Multi Country name
        /// </summary>
        public MultiCountryName MultiLingualCountryName { get; set; }

        /// <summary>
        /// Country Short Name
        /// </summary>
        public string CountryShortName { get; set; }

        /// <summary>
        /// Multi Lingual Country Short Name
        /// </summary>
        public MultiCountryShortName MultiLingualCountryShortName { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Main Language
        /// </summary>
        public string MainLanguage { get; set; }

        /// <summary>
        /// StatusOfCountry
        /// </summary>
        public string StatusOfCountry { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// RegionOfCountry
        /// </summary>
        public string RegionOfCountry { get; set; }
    }


    /// <summary>
    /// Country delete model
    /// </summary>
    public partial class CountryDeleteModel : BaseTransactionModel
    {

        /// <summary>
        /// Country delete model constructor
        /// </summary>
        public CountryDeleteModel()
        {
        }

        /// <summary>
        /// country default id
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Country search model
    /// </summary>
    public partial class CountrySearchModel : SearchBaseModel
    {
        /// <summary>
        /// Country search model constructor
        /// </summary>
        public CountrySearchModel()
        {
        }

        /// <summary>
        /// Iso code
        /// </summary>
        [JsonProperty(PropertyName = "iso2_alpha")]
        public string ctrycd { get; set; }

        /// <summary>
        /// Iso code 3
        /// </summary>
        [JsonProperty(PropertyName = "iso3_alpha")]
        public string ctrycd3 { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [JsonProperty(PropertyName = "country_name")]
        public string ctryname { get; set; }
    }
    /// <summary>
    /// CountrySearchResponseModel
    /// </summary>
    public partial class CountrySearchResponseModel : BaseNeptuneModel
    {

        /// <summary>
        /// country id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Iso code
        /// </summary>
        [JsonProperty(PropertyName = "iso2_alpha")]
        public string ctrycd { get; set; }

        /// <summary>
        /// Iso code 3
        /// </summary>
        [JsonProperty(PropertyName = "iso3_alpha")]
        public string ctrycd3 { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [JsonProperty(PropertyName = "country_name")]
        public string ctryname { get; set; }
    }
    /// <summary>
    /// CountrySearchResponseModel
    /// </summary>
    public partial class CountryViewResponseModel : BaseNeptuneModel
    {   
        /// <summary>
        /// 
        /// </summary>
        public CountryViewResponseModel()
        {
            
        }
        /// <summary>
        /// country id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Iso code
        /// </summary>
        [JsonProperty(PropertyName = "iso2_alpha")]
        public string ctrycd { get; set; }

        /// <summary>
        /// Iso code 3
        /// </summary>
        [JsonProperty(PropertyName = "iso3_alpha")]
        public string ctrycd3 { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [JsonProperty(PropertyName = "country_name")]
        public string ctryname { get; set; }

        /// <summary>
        /// Multi Country name
        /// </summary>
        [JsonProperty("multi_lingual_country_name")]
        public MultiCountryName MultiCountryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mctryname { get; set; }
        /// <summary>
        /// CountryShortName
        /// </summary>
        [JsonProperty("country_short_name")]
        public string ctrsname { get; set; }

        /// <summary>
        /// Multi Lingual Country Short Name
        /// </summary>
        [JsonProperty("multi_lingual_country_short_name")]
        public MultiCountryShortName MultiCountryShortName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mctrsname { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        [JsonProperty("currency_code")]
        public string ccrid { get; set; }

        /// <summary>
        /// MainLanguage
        /// </summary>
        [JsonProperty("main_language")]
        public string lang { get; set; }

        /// <summary>
        /// StatusOfCountry
        /// </summary>
        [JsonProperty("status_of_country")]
        public string ctrysts { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        [JsonProperty("display_order")]
        public int? ord { get; set; }

        /// <summary>
        /// Region Of Country
        /// </summary>
        [JsonProperty("region_of_country")]
        public string region { get; set; }
    }

    /// <summary>
    /// Country update model
    /// </summary>
    public partial class CountryUpdateModel : BaseTransactionModel
    {

        /// <summary>
        /// Country update model constructor
        /// </summary>
        public CountryUpdateModel()
        {
        }

        /// <summary>
        /// Country id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Iso2Alpha
        /// </summary>
        public string Iso2Alpha { get; set; }

        /// <summary>
        /// Iso3Alpha
        /// </summary>
        public string Iso3Alpha { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Multi Country name
        /// </summary>
        public MultiCountryName MultiLingualCountryName { get; set; }

        /// <summary>
        /// Country Short Name
        /// </summary>
        public string CountryShortName { get; set; }

        /// <summary>
        /// Multi Lingual Country Short Name
        /// </summary>
        public MultiCountryShortName MultiLingualCountryShortName { get; set; }

        /// <summary>
        /// Currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Main Language
        /// </summary>
        public string MainLanguage { get; set; }

        /// <summary>
        /// StatusOfCountry
        /// </summary>
        public string StatusOfCountry { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// RegionOfCountry
        /// </summary>
        public string RegionOfCountry { get; set; }
    }
}