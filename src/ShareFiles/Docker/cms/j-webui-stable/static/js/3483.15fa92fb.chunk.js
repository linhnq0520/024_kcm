"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[3483],{3483:(t,e,a)=>{a.r(e),a.d(e,{default:()=>r});var l=a(7313),s=a(5842),i=a(9676),n=a(6417);const o={structable:"",structable_read:"",data_config:'[\n            {\n                "api_id": "api_id",\n                "mode": "face"\n            }\n        ]'};class c extends l.Component{constructor(t){super(t),this.getData=()=>{let{CCP_Default_Config_authentic:t}=this.state;return{structable:t.collection_method.dataFull.value,structable_read:t.read_data.dataFull.value,data_config:t.data_config.dataFull.value}},this.readConfig=t=>{var e={};for(let a in o)void 0!==t[a]&&null!==t[a]?e[a]=t[a]:e[a]=o[a];return e},this.loadDataToState=()=>({collection_method:{dataFull:{config:{default:{title:s.ZP.getLang("designForm_cp_structable"),class:"col-md-12 ",required:!1,placeholder:s.ZP.getLang("designForm_cp_structable"),helper:s.ZP.getLang("designForm_cp_structable"),code_form_component:"collection_method"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable,abs_Change:this.onChangeValue}},read_data:{dataFull:{config:{default:{title:s.ZP.getLang("designForm_cp_structable_read"),class:"col-md-12 ",required:!1,placeholder:s.ZP.getLang("designForm_cp_structable_read"),helper:s.ZP.getLang("designForm_cp_structable_read"),code_form_component:"read_data"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.structable_read,abs_Change:this.onChangeValue}},data_config:{dataFull:{config:{default:{helper:"Format Table",title:"Format Table",class:"col-md-12",rows:10,code_form_component:"data_config"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.data_config,abs_Change:this.onChangeValue}}}),this.onChangeValue=(t,e)=>{let{CCP_Default_Config_authentic:a}=this.state;a[e].dataFull.value=t.target.value,this.setState({CCP_Default_Config_authentic:a})},this.componentDidMount=()=>{this.setState({CCP_Default_Config_authentic:this.loadDataToState()})},this.CCP_Default_Config_authentic=(0,i.Iq)("CCP_Default_Config_authentic"),this.data=this.readConfig(this.props.configComponent.configItem.config),this.state={CCP_Default_Config_authentic:{}}}render(){const t=this.CCP_Default_Config_authentic;return(0,n.jsx)(t,{stateData:this.state.CCP_Default_Config_authentic})}}const r=c}}]);