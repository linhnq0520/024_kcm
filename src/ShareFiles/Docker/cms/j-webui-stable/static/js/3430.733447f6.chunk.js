"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[3430],{3430:(t,e,a)=>{a.r(e),a.d(e,{default:()=>_});var s=a(7313),l=a(5842),n=a(9676),i=a(6417);class o extends s.Component{constructor(t){super(t),this.getData=()=>{let t={};return this.lang_system.forEach((e=>{const a=this.state.CCP_Default_Lang_config.list_lang_inputs.find((t=>t.dataFull.config.default.code_form_component===e.key));try{t[e.key]=JSON.parse(a.dataFull.value)}catch(s){t[e.key]={}}})),t},this.loadDataToState=()=>({title:l.ZP.getLang("designForm_cp_lang_title"),helper:l.ZP.getLang("designForm_cp_lang_title_helper"),list_lang_inputs:this.lang_system.map((t=>({dataFull:{config:{default:{title:t.view,class:"col-md-6 ",required:!1,placeholder:t.view,helper_description:"",code_form_component:t.key,rows:10},cmd:{isHelper:!1,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:"string"===typeof this.data[t.key]?this.data[t.key]:"",abs_Change:this.onChangeValue,abs_Blur:this.onBlurValueJsonObject}})))}),this.componentDidMount=()=>{this.setState({CCP_Default_Lang_config:this.loadDataToState()})},this.onChangeValue=(t,e)=>{let{CCP_Default_Lang_config:a}=this.state;a.list_lang_inputs.find((t=>t.dataFull.config.default.code_form_component===e)).dataFull.value=t.target.value,this.setState({CCP_Default_Lang_config:a})},this.onBlurValueJsonObject=(t,e)=>{let{CCP_Default_Lang_config:a}=this.state;try{let s=JSON.parse(t.target.value);a[e].dataFull.value=JSON.stringify(s,null,4),a[e].dataFull.config.cmd.error.message="",this.error_cpn[e]=!0,this.setState({CCP_Default_Lang_config:a})}catch(s){this.error_cpn[e]=!1,a[e].dataFull.config.cmd.error.message=l.ZP.getLang("designform_not_json_format"),alert(s)}this.setState({CCP_Default_Lang_config:a})},this.CCP_Default_Lang_tableDefault=(0,n.Iq)("CCP_Default_Lang_tableDefault"),this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.lang_system=l.ZP.getConfigUserDefault("list_lang_config"),this.data=this.readConfig(this.props.configComponent.configItem.lang),this.state={CCP_Default_Lang_config:{}}}readConfig(t){var e={};return void 0===t&&(t={}),this.lang_system.forEach((a=>{null!==t[a.key]&&void 0!==t[a.key]&&""!==t[a.key]?e[a.key]=JSON.stringify(t[a.key]):e[a.key]="{}"})),e}render(){const t=this.CCP_Default_Lang_tableDefault;return(0,i.jsx)(t,{stateData:this.state.CCP_Default_Lang_config})}}const _=o}}]);