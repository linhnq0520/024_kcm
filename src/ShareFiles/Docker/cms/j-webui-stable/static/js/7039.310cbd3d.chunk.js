"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[7039],{7039:(t,e,a)=>{a.r(e),a.d(e,{default:()=>_});var n=a(7313),s=a(5842),l=a(9676),i=a(6417);class o extends n.Component{constructor(t){super(t),this.getData=()=>{let t={};return this.lang_system.forEach((e=>{const a=this.state.CCP_Default_Lang_config.list_lang_inputs.find((t=>t.dataFull.config.default.code_form_component===e.key));t[e.key]=a.dataFull.value})),t},this.loadDataToState=()=>({title:"Component name (languages)",helper:"Component name (languages)",list_lang_inputs:this.lang_system.map((t=>({dataFull:{config:{default:{title:t.view,class:"col-md-6 ",required:!1,placeholder:t.view,helper_description:"abc",code_form_component:t.key},cmd:{isHelper:!1,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data[t.key],abs_Change:this.onChangeValue}})))}),this.componentDidMount=()=>{this.setState({CCP_Default_Lang_config:this.loadDataToState()})},this.onChangeValue=(t,e)=>{let{CCP_Default_Lang_config:a}=this.state;a.list_lang_inputs.find((t=>t.dataFull.config.default.code_form_component===e)).dataFull.value=t.target.value,this.setState({CCP_Default_Lang_config:a})},this.CCP_Default_Lang_checkBox=(0,l.Iq)("CCP_Default_Lang_checkbox"),this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.lang_system=s.ZP.getConfigUserDefault("list_lang_config"),this.data=this.readConfig(this.props.configComponent.configItem.lang),this.state={CCP_Default_Lang_config:{}}}readConfig(t){var e={};return void 0===t&&(t={}),this.lang_system.forEach((a=>{null!=t[a.key]?e[a.key]=t[a.key]:e[a.key]=""})),e}render(){const t=this.CCP_Default_Lang_checkBox;return(0,i.jsx)(t,{stateData:this.state.CCP_Default_Lang_config})}}const _=o}}]);