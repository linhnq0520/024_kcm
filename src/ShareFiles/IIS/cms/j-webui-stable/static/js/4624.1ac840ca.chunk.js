"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[4624],{4624:(e,a,t)=>{t.r(a),t.d(a,{default:()=>_});var s=t(7313),l=t(9676),r=t(5842),o=t(6417);const d={structable:"",structable_read:"",data_default:"",isjson:"false",parent:""};class i extends s.Component{constructor(e){super(e),this.getData=()=>{let{CCP_Default_Config_textarea:e}=this.state,a=e.format_JSON.dataFull.data.find((e=>e.selected));return{structable:e.collection_method.dataFull.value,structable_read:e.read_data.dataFull.value,data_default:e.data_default.dataFull.value,isjson:a.value,parent:this.data.parent}},this.loadDataToState=()=>({collection_method:{dataFull:{config:{default:{title:r.ZP.getLang("designForm_cTextArea_structable"),class:"col-md-12 ",required:!1,placeholder:r.ZP.getLang("designForm_cTextArea_structable"),helper:r.ZP.getLang("designForm_cTextArea_structable_helper"),code_form_component:"collection_method"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable,abs_Change:this.onChangeValue}},read_data:{dataFull:{config:{default:{title:r.ZP.getLang("designForm_cTextArea_structable_read"),class:"col-md-12 ",required:!1,placeholder:r.ZP.getLang("designForm_cTextArea_structable_read"),helper:r.ZP.getLang("designForm_cTextArea_structable_read_helper"),code_form_component:"read_data"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable_read,abs_Change:this.onChangeValue}},data_default:{dataFull:{config:{default:{helper:r.ZP.getLang("designForm_cTextArea_data_default_helper"),title:r.ZP.getLang("designForm_cTextArea_data_default"),class:"col-md-12",rows:10,code_form_component:"data_default"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.data_default,abs_Change:this.onChangeValue}},format_JSON:{dataFull:{config:{default:{search:{placeholder:r.ZP.getLang("designForm_cTextArea_is_json")},helper:r.ZP.getLang("designForm_cTextArea_is_json_helper"),data_status:"No Result",title:r.ZP.getLang("designForm_cTextArea_is_json"),class:"col-md-6",required:!1,code_form_component:"format_JSON"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Yes",value:"true",selected:"true"===this.data.isjson},{title:"No",value:"false",selected:"false"===this.data.isjson}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}}}),this.componentDidMount=()=>{this.setState({CCP_Default_Config_textarea:this.loadDataToState()})},this.onChangeValue=(e,a)=>{let{CCP_Default_Config_textarea:t}=this.state;t[a].dataFull.value=e.target.value,this.setState({CCP_Default_Config_textarea:t})},this.onChangeValueSelect=(e,a,t)=>{let{CCP_Default_Config_textarea:s}=this.state;if(t){for(const a of s[t].dataFull.data)a.selected=a.value===e;this.setState({CCP_Default_Config_textarea:s})}},this.CCP_Default_Config_textarea=(0,l.Iq)("CCP_Default_Config_textarea"),this.data=this.readConfig(this.props.configComponent.configItem.config),this.state={CCP_Default_Config_textarea:{}}}readConfig(e){var a={};void 0===e&&(e={});for(let t in d)void 0!==e[t]&&null!==e[t]?a[t]=e[t]:a[t]=d[t];return a}render(){const e=this.CCP_Default_Config_textarea;return(0,o.jsx)(e,{stateData:this.state.CCP_Default_Config_textarea})}}const _=i}}]);