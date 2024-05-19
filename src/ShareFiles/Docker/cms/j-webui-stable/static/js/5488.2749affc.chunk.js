"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[5488],{5488:(e,t,a)=>{a.r(t),a.d(t,{default:()=>c});var l=a(7313),o=a(9676),r=a(5842),i=a(6417);const s={query_data:"",chartType:"ColumnChart",chart_width:"",chart_height:"600",columns:JSON.stringify([{columnName:"Kh\xf4ng c\u1ea7n t\xean",tableColumnGroup:"table1.recname"},{columnName:"T\u1ed5ng c\u1ee7a tableColumn 1",tableColumn:"table1.recvalue"},{columnName:"T\u1ed5ng c\u1ee7a tableColumn 2",tableColumn:"table1.recvalue"}],null,4),options:JSON.stringify({title:"Population of Largest U.S. Cities",chartArea:{width:"30%"},hAxis:{title:"Total Population",minValue:0},vAxis:{title:"City"}},null,4)};class n extends l.Component{constructor(e){super(e),this.validateData=()=>{for(const[,e]of Object.entries(this.error_cpn))if(!1===e)return!1;return!0},this.getData=()=>{let{CCP_Default_Config_chart:e}=this.state;if(this.validateData())return{query_data:e.query_data.dataFull.value,chartType:e.chart_type.dataFull.value,chart_width:e.width.dataFull.value,chart_height:e.height.dataFull.value,columns:e.config_column.dataFull.value,options:e.config_optional.dataFull.value}},this.loadDataToState=()=>({query_data:{dataFull:{config:{default:{title:"Query Data",class:"col-md-12 ",required:!1,placeholder:"Query Data",helper:"Query data",code_form_component:"query_data"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.query_data,abs_Change:this.onChangeValue}},chart_type:{dataFull:{config:{default:{title:"Chart Type",class:"col-md-12 ",required:!1,placeholder:"Chart Type",helper:"Chart Type",code_form_component:"chart_type"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.chartType,abs_Change:this.onChangeValue}},height:{dataFull:{config:{default:{title:"Height",class:"col-md-6 ",required:!1,placeholder:"Height",helper:"Height",code_form_component:"height"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.chart_height,abs_Change:this.onChangeValue}},width:{dataFull:{config:{default:{title:"Width",class:"col-md-6 ",required:!1,placeholder:"Width",helper:"Width",code_form_component:"width"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.chart_width,abs_Change:this.onChangeValue}},config_column:{dataFull:{config:{default:{helper:"Config column data",title:"Config column data",class:"col-md-12",rows:10,code_form_component:"config_column"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.columns,abs_Change:this.onChangeValue,abs_Blur:this.onBlurValueJson}},config_optional:{dataFull:{config:{default:{helper:"Config Optional",title:"Config Optional",class:"col-md-12",rows:10,code_form_component:"config_optional"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.options,abs_Change:this.onChangeValue,abs_Blur:this.onBlurValueJsonObject}},see_more:{title:"See more here",abs_Click:this.onClickSeeMore,dataItem:{data:"https://react-google-charts.com/"}}}),this.componentDidMount=()=>{this.setState({CCP_Default_Config_chart:this.loadDataToState()})},this.onChangeValue=(e,t)=>{let{CCP_Default_Config_chart:a}=this.state;a[t].dataFull.value=e.target.value,this.setState({CCP_Default_Config_chart:a})},this.onClickSeeMore=e=>{},this.onBlurValueJson=(e,t)=>{let{CCP_Default_Config_chart:a}=this.state;try{let l=JSON.parse(e.target.value);Array.isArray(l)?(a[t].dataFull.value=JSON.stringify(JSON.parse(e.target.value),null,4),a[t].dataFull.config.cmd.error.message="",this.error_cpn[t]=!0):(this.error_cpn[t]=!1,a[t].dataFull.config.cmd.error.message=r.ZP.getLang("designform_not_json_format")),this.setState({CCP_Default_Config_chart:a})}catch(l){this.error_cpn[t]=!1,a[t].dataFull.config.cmd.error.message=r.ZP.getLang("designform_not_json_format"),alert(l)}this.setState({CCP_Default_Config_chart:a})},this.onBlurValueJsonObject=(e,t)=>{let{CCP_Default_Config_chart:a}=this.state;try{let l=JSON.parse(e.target.value);a[t].dataFull.value=JSON.stringify(l,null,4),a[t].dataFull.config.cmd.error.message="",this.error_cpn[t]=!0,this.setState({CCP_Default_Config_chart:a})}catch(l){this.error_cpn[t]=!1,a[t].dataFull.config.cmd.error.message=r.ZP.getLang("designform_not_json_format"),alert(l)}this.setState({CCP_Default_Config_chart:a})},this.CCP_Default_Config_chart=(0,o.Iq)("CCP_Default_Config_chart"),this.data=this.readConfig(this.props.configComponent.configItem.config),this.error_cpn={},this.state={CCP_Default_Config_chart:{}}}readConfig(e){var t={};void 0===e&&(e={});for(let a in s)"columns"!==a&&"options"!==a||null==e[a]||(e[a]=JSON.stringify(JSON.parse(e[a]),null,4)),void 0!==e[a]&&null!==e[a]?t[a]=e[a]:t[a]=s[a];return t}render(){const e=this.CCP_Default_Config_chart;return(0,i.jsx)(e,{stateData:this.state.CCP_Default_Config_chart})}}const c=n}}]);