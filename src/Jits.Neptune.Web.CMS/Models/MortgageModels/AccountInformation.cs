using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MultiOtherPaperData : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>        
        [JsonProperty("paper_type")]
        public string T { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("paper_number")]
        public int? N { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("opaper")]
        public int? PAMT { get; set; }
 
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class MultiOtherAddress : BaseNeptuneModel
    {
        /// <summary>
        /// 
        /// </summary>        
       // [JsonProperty("n")]
        public string n { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("h")]
        public string h { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("p")]
        public string p { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("h")]
        public string l { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("w")]
        public string w { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("b")]
        public string b { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("a")]
        public string a { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[JsonProperty("s")]
        public string s { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("t")]
        public string t { get; set; }
        /// <summary>
        /// 
        /// </summary>
       // [JsonProperty("d")]
        public string d { get; set; }
    }

}
