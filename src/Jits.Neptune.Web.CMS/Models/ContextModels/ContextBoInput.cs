#region Assembly Jits.Neptune.Web.Framework, Version=1.0.2.10, Culture=neutral, PublicKeyToken=null
// Jits.Neptune.Web.Framework.dll
#endregion

using Jits.Neptune.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Jits.Neptune.Web.CMS.Utils;

namespace Jits.Neptune.Web.CMS.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ContextBoInputModel {
        // public ContextBoInputModel() { }
        /// <summary>
        /// 
        /// </summary>
        // private string txcode = "";
        private JObject boInput = new JObject();
        private FoResponseModel<object> foInput = new FoResponseModel<object>();
        private JObject actionInput = new JObject();
        private List<ErrorInfoModel> actionError = new List<ErrorInfoModel>();
        private JObject actionTrace = new JObject();
        /// <summary>
        /// 
        /// </summary>
        public bool isDebug = false;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ErrorInfoModel> GetActionErrors()
        {
            return actionError;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FoResponseModel<object> GetFoInput()
        {
            return foInput;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JObject GetActionInput()
        {
            return actionInput;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JObject GetBoInput()
        {

            return boInput;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name_"></param>
        /// <param name="detail_"></param>
        public void AddPackFo<InputValueType>(string name_, InputValueType detail_)
        {
            foInput.input[name_] = detail_;
            actionInput[name_] = detail_.ToJToken();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public void AddErrorRunRule(ErrorStatusModel error)
        {
            JObject obError = new JObject();
            obError.Add(new JProperty("count", error.GetCode()));
            AddPackFo("errorJWebUI", obError);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void AddActionErrorAll(List<ErrorInfoModel> arr)
        {
            actionError.AddRange(arr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public void setActionErrorAll(List<ErrorInfoModel> arr)
        {
            actionError=arr;
        }
    }
}


