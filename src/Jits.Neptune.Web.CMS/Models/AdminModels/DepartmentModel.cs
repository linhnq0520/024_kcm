using Jits.Neptune.Web.CMS.Models;
using Jits.Neptune.Web.Framework.Models;
using Newtonsoft.Json;

namespace Jits.Neptune.Web.Admin.Models
{

    /// <summary>
    /// Department create model
    /// </summary>
    public partial class DepartmentCreateModel : BaseTransactionModel
    {
        /// <summary>
        /// Department create model constructor
        /// </summary>
        public DepartmentCreateModel()
        {
        }

        /// <summary>
        /// Branch id
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// Department name
        /// </summary>
        public string DepartmentName { get; set; }
    }


    /// <summary>
    /// Department delete model
    /// </summary>
    public partial class DepartmentDeleteModel : BaseTransactionModel
    {

        /// <summary>
        /// Department delete model constructor
        /// </summary>
        public DepartmentDeleteModel()
        {
        }

        /// <summary>
        /// Default department id
        /// </summary>
        public int Id { get; set; }
    }


    /// <summary>
    /// Department search model
    /// </summary>
    public partial class DepartmentSearchModel : SearchBaseModel
    {
        /// <summary>
        /// Department Code
        /// </summary>
        [JsonProperty("department_code")]
        public string deprtcd { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        [JsonProperty("department_name")]
        public string deprname { get; set; }

        /// <summary>
        /// Branch Name
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// Branch Code
        /// </summary>
        [JsonProperty("branch_code")]
        public string branchcd { get; set; }
    }

    /// <summary>
    /// DepartmentSearchResponseModel
    /// </summary>
    public partial class DepartmentSearchResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Country Id
        /// </summary>
        [JsonProperty("id")]
        public int deprtid { get; set; }

        /// <summary>
        /// Department Code
        /// </summary>
        [JsonProperty("department_code")]
        public string deprtcd { get; set; }

        /// <summary>
        /// Branch Name
        /// </summary>
        [JsonProperty("branch_name")]
        public string brname { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        [JsonProperty("department_name")]
        public string deprname { get; set; }
    }


    /// <summary>
    /// departmetn view response
    /// </summary>
    public partial class DepartmentViewResponseModel : BaseNeptuneModel
    {
        /// <summary>
        /// Department ID
        /// </summary>
        [JsonProperty("id")]
        public int deprtid { get; set; }

        /// <summary>
        /// Department Code
        /// </summary>
        [JsonProperty("department_code")]
        public string deprtcd { get; set; }

        /// <summary>
        /// Branch Name
        /// </summary>
        [JsonProperty("branch_name")]
        public string BranchName { get; set; }

        /// <summary>
        /// Branch Code
        /// </summary>
        [JsonProperty("branch_code")]
        public string BranchCode { get; set; }
        /// <summary>
        /// Branch Code
        /// </summary>
        public int branchid { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        [JsonProperty("department_name")]
        public string deprname { get; set; }
    }

    /// <summary>
    /// Department update model
    /// </summary>
    public partial class DepartmentUpdateModel : BaseTransactionModel
    {

        /// <summary>
        /// Department update model constructor
        /// </summary>
        public DepartmentUpdateModel()
        {
        }

        /// <summary>
        /// department id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Branch id
        /// </summary>
        public string BranchCode { get; set; }

        /// <summary>
        /// Department name
        /// </summary>
        public string DepartmentName { get; set; }
    }

    /// <summary>
    /// GetListUserBranch
    /// </summary>
    public partial class GetListUserDepartment : BaseTransactionModel
    {

        /// <summary>
        /// branch search model constructor
        /// </summary>
        public GetListUserDepartment()
        {
            PageIndex = 0;
            PageSize = int.MaxValue;
        }

        /// <summary>
        /// BranchCode
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// PageIndex
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; }
    }
}