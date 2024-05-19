using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.Admin.Models
{

    /// <summary>
    /// CurrencyName
    /// </summary>
    public partial class MultiCurrencyName : BaseNeptuneModel
    {
        /// <summary>
        /// Currency Name 1
        /// </summary>
        [JsonProperty("currency_name1")]
        public string CN1 { get; set; } = null;

        /// <summary>
        /// Currency Name 2
        /// </summary>
        [JsonProperty("currency_name2")]
        public string CN2 { get; set; } = null;

        /// <summary>
        /// Currency Name 3
        /// </summary>
        [JsonProperty("currency_name3")]
        public string CN3 { get; set; } = null;
    }

    /// <summary>
    /// MasterName
    /// </summary>
    public partial class MultiMasterName : BaseNeptuneModel
    {
        /// <summary>
        /// Master Name 1
        /// </summary>
        [JsonProperty("master_name1")]
        public string MN1 { get; set; } = null;

        /// <summary>
        /// Master Name 2
        /// </summary>
        [JsonProperty("master_name2")]
        public string MN2 { get; set; } = null;

        /// <summary>
        /// Master Name 3
        /// </summary>
        [JsonProperty("master_name3")]
        public string MN3 { get; set; } = null;
    }

    /// <summary>
    /// DecimalName
    /// </summary>
    public partial class MultiDecimalName : BaseNeptuneModel
    {
        /// <summary>
        /// Decimal Name 1
        /// </summary>
        [JsonProperty("decimal_name1")]
        public string DN1 { get; set; } = null;

        /// <summary>
        /// Decimal Name 2
        /// </summary>
        [JsonProperty("decimal_name2")]
        public string DN2 { get; set; } = null;

        /// <summary>
        /// Decimal Name 3
        /// </summary>
        [JsonProperty("decimal_name3")]
        public string DN3 { get; set; } = null;
    }

    /// <summary>
    /// Currency create model
    /// </summary>
    public partial class CurrencyCreateModel : BaseTransactionModel
    {

        /// <summary>
        /// Currency create model constructor
        /// </summary>
        public CurrencyCreateModel()
        {
        }
        /// <summary>
        /// CurrencyId
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// ShortCurrencyId
        /// </summary>
        public string ShortCurrencyId { get; set; }

        /// <summary>
        /// CurrencyName
        /// </summary>
        public MultiCurrencyName CurrencyName { get; set; }

        /// <summary>
        /// CurrencyNumber
        /// </summary>
        public int? CurrencyNumber { get; set; }

        /// <summary>
        /// MasterName
        /// </summary>
        public MultiMasterName MasterName { get; set; }

        /// <summary>
        /// DecimalName
        /// </summary>
        public MultiDecimalName DecimalName { get; set; }

        /// <summary>
        /// DecimalDigits
        /// </summary>
        public int DecimalDigits { get; set; }

        /// <summary>
        /// RoundingDigits
        /// </summary>
        public int RoundingDigits { get; set; }

        /// <summary>
        /// StatusOfCurrency
        /// </summary>
        public string StatusOfCurrency { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }
    }

    /// <summary>
    /// Currency delete model
    /// </summary>
    public partial class CurrencyDeleteModel : BaseTransactionModel
    {

        /// <summary>
        /// currency id
        /// </summary>
        public int Id { get; set; }
    }


    /// <summary>
    /// Currency search model
    /// </summary>
    public partial class CurrencySearchModel : SearchBaseModel
    {
        /// <summary>
        /// Currency Id
        /// </summary>
        [JsonProperty("currency_id")]
        public string cccrid { get; set; }

        /// <summary>
        /// Short Currency Id
        /// </summary>
        [JsonProperty("short_currency_id")]
        public string shrtid { get; set; }

        /// <summary>
        /// Currency Number
        /// </summary>
        [JsonProperty("currency_number")]
        public int? ccrnumber { get; set; }

        /// <summary>
        /// Currency Number From
        /// </summary>
        [JsonProperty("currency_number_from")]
        public int? CurrencyNumberFrom { get; set; }

        /// <summary>
        /// Currency Number To
        /// </summary>
        [JsonProperty("currency_number_to")]
        public int? CurrencyNumberTo { get; set; }

        /// <summary>
        /// Status Of Currency
        /// </summary>
        [JsonProperty("status_of_currency")]
        public string ccrsts { get; set; }

        /// <summary>
        /// Display Order
        /// </summary>
        [JsonProperty("display_order")]
        public int? ord { get; set; }

        /// <summary>
        /// Order From
        /// </summary>
        [JsonProperty("order_from")]
        public int? OrderFrom { get; set; }

        /// <summary>
        /// Order To
        /// </summary>
        [JsonProperty("order_to")]
        public int? OrderTo { get; set; }

        /// <summary>
        /// Order To
        /// </summary>
        [JsonProperty("oprtval_display_order")]
        public string oprtval_ord { get; set; }
        /// <summary>
        /// Order To
        /// </summary>
        [JsonProperty("oprtval_currency_number")]
        public string oprtval_ccrnumber { get; set; }
    }

    /// <summary>
    /// CurrencySearchResponseModel
    /// </summary>
    public partial class CurrencySearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Country ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Currency ID
        /// </summary>
        [JsonProperty("currency_id")]
        public string ccrid { get; set; }

        /// <summary>
        /// Short Currency ID
        /// </summary>
        [JsonProperty("short_currency_id")]
        public string shrtid { get; set; }

        /// <summary>
        /// Currency Number
        /// </summary>
        [JsonProperty("currency_number")]
        public int? ccrnumber { get; set; }

        /// <summary>
        /// Status Of Currency
        /// </summary>
        [JsonProperty("status_of_currency")]
        public string status { get; set; }

        /// <summary>
        /// Display Order
        /// </summary>
        [JsonProperty("display_order")]
        public int? ord { get; set; }
    }

    /// <summary>
    /// CurrencyViewResponseModel
    /// </summary>
    public partial class CurrencyViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Country ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Currency ID
        /// </summary>
        [JsonProperty("currency_id")]
        public string ccrid { get; set; }

        /// <summary>
        /// Short Currency ID
        /// </summary>
        [JsonProperty("short_currency_id")]
        public string shrtid { get; set; }

        /// <summary>
        /// Currency Name
        /// </summary>
        [JsonProperty("currency_name")]
        public MultiCurrencyName CurrencyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ccrname {get;set;}

        /// <summary>
        /// Currency Number
        /// </summary>
        [JsonProperty("currency_number")]
        public int? ccrnumber { get; set; }

        /// <summary>
        /// Master Name
        /// </summary>
        [JsonProperty("master_name")]
        public MultiMasterName MasterName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ccrmst {get;set;}
        /// <summary>
        /// Decimal Name
        /// </summary>
        [JsonProperty("decimal_name")]
        public MultiDecimalName DecimalName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ccrdec{get;set;}
        /// <summary>
        /// Decimal Digits
        /// </summary>
        [JsonProperty("decimal_digits")]
        public int? cdecimal { get; set; }

        /// <summary>
        /// Rounding Digits
        /// </summary>
        [JsonProperty("rounding_digits")]
        public int? crnd { get; set; }

        /// <summary>
        /// Status Of Currency
        /// </summary>
        [JsonProperty("status_of_currency")]
        public string ccrsts { get; set; }

        /// <summary>
        /// Display Order
        /// </summary>
        [JsonProperty("display_order")]
        public int? ord { get; set; }
    }

    /// <summary>
    /// Currency update model
    /// </summary>
    public partial class CurrencyUpdateModel : BaseTransactionModel
    {

        /// <summary>
        /// Currency update model constructor
        /// </summary>
        public CurrencyUpdateModel()
        {
        }

        /// <summary>
        /// currency id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ShortCurrencyId
        /// </summary>
        public string ShortCurrencyId { get; set; }

        /// <summary>
        /// CurrencyName
        /// </summary>
        public MultiCurrencyName CurrencyName { get; set; }

        /// <summary>
        /// CurrencyNumber
        /// </summary>
        public int? CurrencyNumber { get; set; }

        /// <summary>
        /// MasterName
        /// </summary>
        public MultiMasterName MasterName { get; set; }

        /// <summary>
        /// DecimalName
        /// </summary>
        public MultiDecimalName DecimalName { get; set; }

        /// <summary>
        /// DecimalDigits
        /// </summary>
        public int DecimalDigits { get; set; }

        /// <summary>
        /// RoundingDigits
        /// </summary>
        public int RoundingDigits { get; set; }

        /// <summary>
        /// StatusOfCurrency
        /// </summary>
        public string StatusOfCurrency { get; set; }

        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int? DisplayOrder { get; set; }
    }

    /// <summary>
    /// GetInfoCurrencyCode
    /// </summary>
    public class GetInfoCurrencyCode : BaseTransactionModel
    {
        /// <summary>
        /// AccountNumber
        /// </summary>
        public string AccountNumber { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ADMGetInfoCurrencyCodeModel : BaseTransactionModel
    {
        /// <summary>
        /// AccountNumber
        /// </summary>
        public string CurrencyCode { get; set; }
    }
}