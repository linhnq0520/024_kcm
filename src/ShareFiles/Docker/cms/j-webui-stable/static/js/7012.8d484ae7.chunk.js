"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[7012],{7012:(e,a,t)=>{t.r(a),t.d(a,{default:()=>d});var l=t(7313),s=t(9676),i=t(5842),r=t(6417);class o extends l.Component{constructor(e){super(e),this.getData=()=>{let{CCP_Default_Validate_config:e}=this.state;return{is_compare:e.is_compare.dataFull.value,request:e.is_required.dataFull.value,min:e.min_words.dataFull.value,max:e.max_words.dataFull.value,regex_format:e.structure_regex.dataFull.value,validate_html:this.data.validate_html}},this.loadDataToState=()=>({is_compare:{dataFull:{dataItem:{componentCode:"is_compare"},value:this.data.is_compare,title:i.ZP.getLang("desiignform_cp_is_compare"),class:"col-md-6",config:{cmd:{visible:!1,disable:!1,error:{message:"",type:""}}},abs_Click:this.onClickValue}},is_required:{dataFull:{dataItem:{componentCode:"is_required"},value:this.data.request,title:"Is Required",class:"col-md-6",config:{cmd:{visible:!1,disable:!1,error:{message:"",type:""}}},abs_Click:this.onClickValue}},min_words:{dataFull:{config:{default:{title:"Min words",class:"col-md-6 ",required:!1,placeholder:"Min words",helper:"Min words",code_form_component:"min_words"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.min,abs_Change:this.onChangeValue}},max_words:{dataFull:{config:{default:{title:"Max words",class:"col-md-6 ",required:!1,placeholder:"Max words",helper:"Max words",code_form_component:"max_words"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.max,abs_Change:this.onChangeValue}},structure_regex:{dataFull:{config:{default:{title:"Structure regex",class:"col-md-6 ",required:!1,placeholder:"Structure regex",helper:"Structure regex",code_form_component:"structure_regex"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.regex_format,abs_Change:this.onChangeValue}}}),this.componentDidMount=()=>{this.setState({CCP_Default_Validate_config:this.loadDataToState()})},this.onChangeValue=(e,a)=>{let{CCP_Default_Validate_config:t}=this.state;t[a].dataFull.value=e.target.value,this.setState({CCP_Default_Validate_config:t})},this.onClickValue=e=>{let{CCP_Default_Validate_config:a}=this.state,t=e.componentCode;a[t].dataFull.value=!a[t].dataFull.value,this.setState({CCP_Default_Validate_config:a})},this.CCP_Default_Validate_textInput=(0,s.Iq)("CCP_Default_Validate_select"),this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.data=this.readConfig(this.props.configComponent.configItem.validate),this.state={CCP_Default_Validate_config:{}}}readConfig(e){var a={};return void 0===e&&(e={}),null!=e.request?a.request=e.request:a.request=!1,null!=e.is_compare?a.is_compare=e.is_compare:a.is_compare=!1,null!=e.min?a.min=e.min:a.min="",null!=e.max?a.max=e.max:a.max="",null!=e.regex_format?a.regex_format=e.regex_format:a.regex_format="",void 0!==e.validate_html?a.validate_html=e.validate_html:a.validate_html="true",a}render(){const e=this.CCP_Default_Validate_textInput;return(0,r.jsx)(e,{stateData:this.state.CCP_Default_Validate_config})}}const d=o}}]);