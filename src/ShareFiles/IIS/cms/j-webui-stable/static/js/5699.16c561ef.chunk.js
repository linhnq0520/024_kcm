"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[5699],{5699:(e,a,t)=>{t.r(a),t.d(a,{default:()=>r});var l=t(7313),d=t(9676),o=t(5842),i=t(6417);const s={component_title:"",structable:"",structable_read:"",data_default:"",data_view_format:"",data_view:"",data_value:"",data_type:"json",data_query:"",data_json:JSON.stringify([{title:"",code:"",icon:"",config:{}}],null,4),data_more:JSON.stringify([{title:"",code:"",icon:"",config:{}}],null,4)};class n extends l.Component{constructor(e){super(e),this.getData=()=>{let{CCP_Default_Config_radiobox:e}=this.state;return{data_type:e.data_type.dataFull.data.find((e=>e.selected)).value,structable:e.collection_method.dataFull.value,structable_read:e.read_data.dataFull.value,data_default:e.data_default.dataFull.value,component_title:e.component_title.dataFull.value,data_view:e.data_view.dataFull.value,data_query:e.data_query.dataFull.value,data_json:e.data_json.dataFull.value,data_more:e.data_more.dataFull.value,data_view_format:e.data_view_format.dataFull.value,data_value:this.data.data_value}},this.readConfig=e=>{var a={};for(let t in s)void 0!==e[t]&&null!==e[t]?a[t]=e[t]:a[t]=s[t];return a},this.loadDataToState=()=>({collection_method:{dataFull:{config:{default:{title:o.ZP.getLang("designForm_cp_structable"),class:"col-md-12 ",required:!1,placeholder:o.ZP.getLang("designForm_cp_structable"),helper:o.ZP.getLang("designForm_cp_structable"),code_form_component:"collection_method"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable,abs_Change:this.onChangeValue}},read_data:{dataFull:{config:{default:{title:o.ZP.getLang("designForm_cTextInput_structable_read"),class:"col-md-12 ",required:!1,placeholder:o.ZP.getLang("designForm_cTextInput_structable_read"),helper:o.ZP.getLang("designForm_cTextInput_structable_read"),code_form_component:"read_data"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable_read,abs_Change:this.onChangeValue}},data_default:{dataFull:{config:{default:{title:o.ZP.getLang("designForm_cTextInput_data_default"),class:"col-md-6 ",required:!1,placeholder:o.ZP.getLang("designForm_cTextInput_data_default"),helper:o.ZP.getLang("designForm_cTextInput_data_default"),code_form_component:"data_default"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.data_default,abs_Change:this.onChangeValue}},component_title:{dataFull:{config:{default:{title:"Component Title",class:"col-md-6 ",required:!1,placeholder:o.ZP.getLang("designForm_cTextInput_data_default"),helper:o.ZP.getLang("designForm_cTextInput_data_default"),code_form_component:"component_title"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.component_title,abs_Change:this.onChangeValue}},SD_multiValue:{dataFull:{config:{default:{title:"DATA"},cmd:{visible:!0}}}},data_type:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:o.ZP.getLang("designForm_cTextInput_is_upcase"),data_status:"No Result",title:"Data type",class:"col-md-6",required:!1,code_form_component:"data_type"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Database",value:"database",selected:"database"===this.data.data_type},{title:"JSON",value:"json",selected:"json"===this.data.data_type}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}},data_view:{dataFull:{config:{default:{title:"Data view",class:"col-md-6 ",required:!1,placeholder:o.ZP.getLang("designForm_cTextInput_data_default"),helper:o.ZP.getLang("designForm_cTextInput_data_default"),code_form_component:"data_view"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.data_view,abs_Change:this.onChangeValue}},data_query:{dataFull:{config:{default:{title:"Data query",class:"col-md-6 ",required:!1,placeholder:o.ZP.getLang("designForm_cTextInput_data_default"),helper:o.ZP.getLang("designForm_cTextInput_data_default"),code_form_component:"data_query"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.data_query,abs_Change:this.onChangeValue}},interface_multiValue:{dataFull:{config:{default:{title:"FORMAT"},cmd:{visible:!0}}}},data_view_format:{dataFull:{config:{default:{title:"Data view format",class:"col-md-6 ",required:!1,placeholder:o.ZP.getLang("designForm_cTextInput_data_default"),helper:o.ZP.getLang("designForm_cTextInput_data_default"),code_form_component:"data_view_format"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.data_view_format,abs_Change:this.onChangeValue}},data_json:{dataFull:{config:{default:{helper:"JSON data",title:"JSON data",class:"col-md-12",rows:10,code_form_component:"data_json"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.data_json,abs_Change:this.onChangeValue}},data_more:{dataFull:{config:{default:{helper:"JSON data more",title:"JSON data more",class:"col-md-12",rows:10,code_form_component:"data_more"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.data_more,abs_Change:this.onChangeValue}}}),this.componentDidMount=()=>{this.setState({CCP_Default_Config_radiobox:this.loadDataToState()})},this.onChangeValue=(e,a)=>{let{CCP_Default_Config_radiobox:t}=this.state;t[a].dataFull.value=e.target.value,this.setState({CCP_Default_Config_radiobox:t})},this.onChangeValue_ActionContent=(e,a)=>{let{CCP_Default_Config_radiobox:t}=this.state;t.action.action_textarea.dataFull.value=e.target.value,this.setState({CCP_Default_Config_radiobox:t})},this.onChangeValueSelect=(e,a,t)=>{let{CCP_Default_Config_radiobox:l}=this.state;if(t){if("action_event"===t){let e=[],t=[];e=l.action.action_callForm.dataFull.data.filter((e=>e.selected)),t=l.action.action_callForm.dataFull.data.filter(((e,t)=>t===a)),e.length>0&&(e[0].selected=!1),t.length>0&&(t[0].selected=!0),l.action.action_textarea={dataFull:{config:{default:{helper:t[0].title,title:t[0].title,class:"col-md-12",rows:10,code_form_component:"true"===t[0].value?"txFoAction":"txFo"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:"true"===t[0].value?this.data.txFoActions:this.data.txFo,abs_Change:this.onChangeValue_ActionContent}}}else for(const a of l[t].dataFull.data)a.selected=a.value===e;this.setState({CCP_Default_Config_radiobox:l})}},this.CCP_Default_Config_radiobox=(0,d.Iq)("CCP_Default_Config_radioBox"),this.data=this.readConfig(this.props.configComponent.configItem.config),this.state={CCP_Default_Config_radiobox:{}}}render(){const e=this.CCP_Default_Config_radiobox;return(0,i.jsx)(e,{stateData:this.state.CCP_Default_Config_radiobox})}}const r=n}}]);