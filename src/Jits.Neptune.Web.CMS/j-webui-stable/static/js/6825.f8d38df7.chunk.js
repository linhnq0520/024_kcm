"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[6825],{2026:(e,a,t)=>{t.r(a),t.d(a,{default:()=>i});var s=t(7313),n=t(9676),l=t(6417);class r extends s.Component{constructor(e){super(e),this.getData=()=>({}),this.loadDataToState=()=>({is_danger:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:"Danger",data_status:"No Result",title:"Danger",class:"col-md-6",required:!1,code_form_component:"is_danger"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Yes",value:"true",selected:"true"===this.data.danger},{title:"No",value:"false",selected:"false"===this.data.danger}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}},is_warning:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:"Warning",data_status:"No Result",title:"Warning",class:"col-md-6",required:!1,code_form_component:"is_warning"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"Yes",value:"true",selected:"true"===this.data.warning},{title:"No",value:"false",selected:"false"===this.data.warning}],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}}}),this.componentDidMount=()=>{},this.onChangeValueSelect=(e,a,t)=>{let{CCP_Default_Essence_config:s}=this.state;if(t){for(const a of s[t].dataFull.data)a.selected=a.value===e;this.setState({CCP_Default_Essence_config:s})}},this.CCP_Default_Essence_textInput=(0,n.Iq)("CCP_Default_Essence_chart"),this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.data=this.readConfig(this.props.configComponent.configItem.property),this.state={CCP_Default_Essence_config:{}}}readConfig(e){var a={};return void 0===e&&(e={}),null!=e.danger?a.danger=e.danger:a.danger="false",null!=e.warning?a.warning=e.warning:a.warning="false",a}render(){const e=this.CCP_Default_Essence_textInput;return(0,l.jsx)(e,{stateData:this.state.CCP_Default_Essence_config})}}const i=r}}]);