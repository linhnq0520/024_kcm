"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[3457],{3457:(e,a,t)=>{t.r(a),t.d(a,{default:()=>u});var l=t(7313),s=t(9676),d=t(5842),i=t(6417);const o={action:"",structable:"",structable_read:"",data_default:"{}",callform:"",hidden:"",is_open:"true",has_default:"true",value_default:"",address_default:"",notReload:!1};class r extends l.Component{constructor(e){super(e),this.getData=()=>{let{CCP_Default_Config_:e}=this.state;const a=e.is_open_form_begin.dataFull.data.find((e=>e.selected)),t=e.is_data_default.dataFull.data.find((e=>e.selected)),l=e.noReload.dataFull.data.find((e=>e.selected));return{action:this.data.action,structable:e.collection_method.dataFull.value,structable_read:e.read_data.dataFull.value,data_default:e.data_default.dataFull.value,callform:e.data_form.dataFull.value,hidden:this.data.hidden,is_open:a.value,has_default:t.value,notReload:l.value}},this.loadDataToState=()=>({collection_method:{dataFull:{config:{default:{title:d.ZP.getLang("designForm_cp_structable"),class:"col-md-12 ",required:!1,placeholder:d.ZP.getLang("designForm_cp_structable"),helper:d.ZP.getLang("designForm_cp_structable_helper"),code_form_component:"collection_method"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable,abs_Change:this.onChangeValue}},read_data:{dataFull:{config:{default:{title:d.ZP.getLang("designForm_cp_structable"),class:"col-md-12 ",required:!1,placeholder:d.ZP.getLang("designForm_cp_structable"),helper:d.ZP.getLang("designForm_cp_structable_helper"),code_form_component:"read_data"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable_read,abs_Change:this.onChangeValue}},data_default:{dataFull:{config:{default:{title:d.ZP.getLang("designForm_cTextArea_data_default"),class:"col-md-6 ",required:!1,placeholder:d.ZP.getLang("designForm_cTextArea_data_default"),helper:d.ZP.getLang("designForm_cTextArea_data_default"),code_form_component:"data_default"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.data_default,abs_Change:this.onChangeValue}},data_form:{dataFull:{config:{default:{title:d.ZP.getLang("designForm_jMulti_data_form"),class:"col-md-6 ",required:!1,placeholder:d.ZP.getLang("designForm_jMulti_data_form"),helper:d.ZP.getLang("designForm_jMulti_data_form"),code_form_component:"data_form"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.callform,abs_Change:this.onChangeValue}},is_open_form_begin:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:d.ZP.getLang("designForm_jMulti_is_open_form_begin"),data_status:"No Result",title:d.ZP.getLang("designForm_jMulti_is_open_form_begin"),class:"col-md-6",required:!1,code_form_component:"is_open_form_begin"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Yes",value:"true",selected:"true"===this.data.is_open},{title:"No",value:"false",selected:"false"===this.data.is_open}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}},noReload:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:"Not Reload",data_status:"No Result",title:"Not Reload",class:"col-md-6",required:!1,code_form_component:"noReload"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Yes",value:!0,selected:!0===this.data.notReload},{title:"No",value:!1,selected:!1===this.data.notReload}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}},is_data_default:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:d.ZP.getLang("designForm_jMulti_is_data_default"),data_status:"No Result",title:d.ZP.getLang("designForm_jMulti_is_data_default"),class:"col-md-6",required:!1,code_form_component:"is_data_default"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Yes",value:"true",selected:"true"===this.data.has_default},{title:"No",value:"false",selected:"false"===this.data.has_default}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}},value_default:{dataFull:{config:{default:{title:d.ZP.getLang("designForm_jMulti_value_default"),class:"col-md-6 ",required:!1,placeholder:d.ZP.getLang("designForm_jMulti_value_default"),helper:d.ZP.getLang("designForm_jMulti_value_default"),code_form_component:"value_default"},cmd:{isHelper:!0,disable:!1,visible:"true"===this.data.has_default,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.value_default,abs_Change:this.onChangeValue}},address_default:{dataFull:{config:{default:{title:d.ZP.getLang("designForm_jMulti_address_default"),class:"col-md-6 ",required:!1,placeholder:d.ZP.getLang("designForm_jMulti_address_default"),helper:d.ZP.getLang("designForm_jMulti_address_default"),code_form_component:"address_default"},cmd:{isHelper:!0,disable:!1,visible:"true"===this.data.has_default,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.address_default,abs_Change:this.onChangeValue}}}),this.componentDidMount=()=>{this.setState({CCP_Default_Config_:this.loadDataToState()})},this.onChangeValue=(e,a)=>{let{CCP_Default_Config_:t}=this.state;t[a].dataFull.value=e.target.value,this.setState({CCP_Default_Config_:t})},this.onChangeValueSelect=(e,a,t)=>{let{CCP_Default_Config_:l}=this.state;if(t){"is_data_default"===t&&(l.value_default.dataFull.config.cmd.visible="true"===e,l.address_default.dataFull.config.cmd.visible="true"===e);for(const a of l[t].dataFull.data)a.selected=a.value===e;this.setState({CCP_Default_Config_:l})}},this.CCP_Default_Config_button_multiValue=(0,s.Iq)("CCP_Default_Config_multiValue"),this.data=this.readConfig(this.props.configComponent.configItem.config),this.state={CCP_Default_Config_:{}}}readConfig(e){var a={};void 0===e&&(e={});for(let t in o)void 0!==e[t]&&null!==e[t]?a[t]=e[t]:a[t]=o[t];return a}render(){const e=this.CCP_Default_Config_button_multiValue;return(0,i.jsx)(e,{stateData:this.state.CCP_Default_Config_})}}const u=r}}]);