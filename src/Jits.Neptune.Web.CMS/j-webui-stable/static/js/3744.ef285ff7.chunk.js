"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[3744],{3744:(e,t,a)=>{a.r(t),a.d(t,{default:()=>_});var r=a(7313),o=a(9676),l=a(5842),s=a(6417);const i={query_data:"",file_report:"",file_report_name:"",config_data:JSON.stringify({key_parent:[{key_1:"key_parent.key_1",key_2:"key_parent.key_2"}]},null,4)};class n extends r.Component{constructor(e){super(e),this.validateData=()=>{for(const[,e]of Object.entries(this.error_cpn))if(!1===e)return!1;return!0},this.getData=()=>{let{CCP_Default_Config_report:e}=this.state;const t=e.file_report.dataFull.data.find((e=>e.selected));if(this.validateData())return{query_data:e.query_data.dataFull.value,file_report:t.value,config_data:e.config_data.dataFull.value}},this.loadDataToState=()=>({query_data:{dataFull:{config:{default:{title:"Query Data",class:"col-md-12 ",required:!1,placeholder:"Query Data",helper:"Query data",code_form_component:"query_data"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.query_data,abs_Change:this.onChangeValue}},config_data:{dataFull:{config:{default:{helper:"Config column data",title:"Config column data",class:"col-md-12",rows:10,code_form_component:"config_data"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.config_data,abs_Change:this.onChangeValue,abs_Blur:this.onBlurValueJsonObject}},file_report:{dataFull:{config:{default:{search:{placeholder:l.ZP.getLang("designForm_jReport_fileReport")},helper:l.ZP.getLang("designForm_jReport_fileReport_helper"),data_status:"No Result",title:l.ZP.getLang("designForm_jReport_fileReport"),class:"col-md-6",required:!1,code_form_component:"file_report"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:this.getListReport(),search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}}}),this.onChangeValueSelect=(e,t,a)=>{let{CCP_Default_Config_report:r}=this.state;if(a){for(const t of r[a].dataFull.data)t.selected=t.value===e;this.setState({CCP_Default_Config_report:r})}},this.handleImageChange=e=>{e.preventDefault();let t=new FileReader,a=e.target.files[0];t.onloadend=()=>{let{CCP_Default_Config_report:e}=this.state;e.file_report.dataFull.value=t.result,e.file_report.dataFull.file_name=a.name,e.file_report.dataFull.config.default.att_content=a.name,this.setState({CCP_Default_Config_report:e})};void 0!==a&&null!==a&&a.size/1024/1024<100&&t.readAsDataURL(a)},this.componentDidMount=()=>{this.setState({CCP_Default_Config_report:this.loadDataToState()})},this.onChangeValue=(e,t)=>{let{CCP_Default_Config_report:a}=this.state;a[t].dataFull.value=e.target.value,this.setState({CCP_Default_Config_report:a})},this.onClickSeeMore=e=>{},this.onBlurValueJson=(e,t)=>{let{CCP_Default_Config_report:a}=this.state;try{let r=JSON.parse(e.target.value);Array.isArray(r)?(a[t].dataFull.value=JSON.stringify(JSON.parse(e.target.value),null,4),a[t].dataFull.config.cmd.error.message="",this.error_cpn[t]=!0):(this.error_cpn[t]=!1,a[t].dataFull.config.cmd.error.message=l.ZP.getLang("designform_not_json_format")),this.setState({CCP_Default_Config_report:a})}catch(r){this.error_cpn[t]=!1,a[t].dataFull.config.cmd.error.message=l.ZP.getLang("designform_not_json_format"),alert(r)}this.setState({CCP_Default_Config_report:a})},this.onBlurValueJsonObject=(e,t)=>{let{CCP_Default_Config_report:a}=this.state;try{let r=JSON.parse(e.target.value);a[t].dataFull.value=JSON.stringify(r,null,4),a[t].dataFull.config.cmd.error.message="",this.error_cpn[t]=!0,this.setState({CCP_Default_Config_report:a})}catch(r){this.error_cpn[t]=!1,a[t].dataFull.config.cmd.error.message=l.ZP.getLang("designform_not_json_format"),alert(r)}this.setState({CCP_Default_Config_report:a})},this.CCP_Default_Config_report=(0,o.Iq)("CCP_Default_Config_report"),this.data=this.readConfig(this.props.configComponent.configItem.config),console.log("this.props",this.props),this.error_cpn={},this.state={CCP_Default_Config_report:{}}}readConfig(e){var t={};void 0===e&&(e={});for(let a in i)"config_data"===a&&null!=e[a]&&(e[a]=JSON.stringify(JSON.parse(e[a]),null,4)),void 0!==e[a]&&null!==e[a]?t[a]=e[a]:t[a]=i[a];return t}getListReport(){return this.props.data.allListReport.map(((e,t)=>({title:e.code,value:e.code,selected:this.data.file_report===e.code})))}render(){const e=this.CCP_Default_Config_report;return(0,s.jsx)(e,{stateData:this.state.CCP_Default_Config_report})}}const _=n}}]);