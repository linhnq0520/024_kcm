"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[4810,3684],{3684:(e,t,a)=>{a.r(t),a.d(t,{listActions:()=>o,listDisabled:()=>l,listRequest:()=>s,listRuleFormStatus:()=>n});let n=[{name:"Kh\xf4ng d\xf9ng",val:-1},{name:"noError",val:0},{name:"successLoadData",val:1},{name:"errorLoadData",val:11},{name:"successSave",val:2},{name:"errorSave",val:21},{name:"errorDuplicateData",val:22},{name:"successUpdate",val:3},{name:"errorUpdate",val:31},{name:"successDelete",val:4},{name:"errorDelete",val:41},{name:"errorNotExistDelete",val:42},{name:"successView",val:5},{name:"errorView",val:51},{name:"successClear",val:6},{name:"errorClear",val:61}],o=[{name:"Enter/Tab",val:"enter_tab"},{name:"Change",val:"on_change"},{name:"Click",val:"on_click"},{name:"Checked",val:"checked"},{name:"Reload",val:"reload"},{name:"Enter",val:"enter"},{name:"Update",val:"update"},{name:"Activated",val:"activated"},{name:"All",val:"all"}],l=[{name:"enabled",val:"false"},{name:"disabled",val:"true"},{name:"Not Use",val:"not_use"}],s=[{name:"Yes",val:!0},{name:"No",val:!1}]},4810:(e,t,a)=>{a.r(t),a.d(t,{default:()=>c});var n=a(7313),o=a(5842),l=a(9676),s=a(3684),r=a(6417);class i extends n.Component{constructor(e){super(e),this.getData=()=>{let{form:e}=this.state;const t=e.rule_managerComponent.event.dataFull.data.find((e=>e.selected)),a=e.rule_managerComponent.action.dataFull.data.find((e=>e.selected));this.props.func_save_rule_and_close({component_action:e.rule_managerComponent.code_active.dataFull.value,component_event:a.value,is_use_block:t.value,component_manager:e.rule_managerComponent.action_content.dataFull.value})},this.convert_action_template=()=>{let e={},t=[];for(let a=0;a<s.listActions.length;a++)t.push({title:s.listActions[a].name,value:s.listActions[a].val,selected:s.listActions[a].val===this.data.component_event});return t.find((e=>e.selected))||(t[0].selected=!0),e={dataFull:{config:{default:{search:{placeholder:o.ZP.getLang("designForm_rule_action")},helper:o.ZP.getLang("designForm_rule_action_helper"),data_status:"No Result",title:o.ZP.getLang("designForm_rule_action"),class:"col-md-6",required:!1,code_form_component:"action"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:t,search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}},e},this.convert_code_get_data_template=()=>{let e={};return e={dataFull:{config:{default:{title:o.ZP.getLang("designForm_rule_component_result"),class:"col-md-12 ",required:!1,placeholder:o.ZP.getLang("designForm_rule_component_result"),helper:o.ZP.getLang("designForm_rule_component_result_helper"),rows:7,code_form_component:"code_get_data"},cmd:{isHelper:!0,disable:!1,visible:!1,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},data:[],value:"",abs_Change:this.onChangeValue}},e},this.convert_active_template=()=>({dataFull:{config:{default:{title:o.ZP.getLang("designForm_rule_component_action"),class:"col-md-6 ",required:!1,placeholder:o.ZP.getLang("designForm_rule_component_action"),helper:o.ZP.getLang("designForm_rule_component_action_helper"),code_form_component:"code_active"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}}},mode:{isSearch:!1},value:this.data.component_action,abs_Change:this.onChangeValue}}),this.convert_event_template=()=>{let e=[{title:"Only hide",value:"false",selected:"false"===this.data.is_use_block},{title:"Hide and disable",value:"true",selected:"true"===this.data.is_use_block}];return{dataFull:{config:{default:{search:{placeholder:o.ZP.getLang("designForm_rule_is_use_block")},helper:o.ZP.getLang("designForm_rule_is_use_block_helper"),data_status:"No Result",title:o.ZP.getLang("designForm_rule_is_use_block"),class:"col-md-6",required:!1,code_form_component:"event"},cmd:{isHelper:!0,disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:e,search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.onChangeValueSelect}}},this.convert_option_active_template=()=>({dataFull:{config:{default:{title:"Class",class:"col-md-12 ",required:!1,placeholder:"Class",helper:"abc"},cmd:{isHelper:!0,disable:!1,visible:!1,isFocus:!1,error:{message:"",type:""}}},value:"",abs_Change:this.testInput}}),this.convert_action_content_template=()=>({dataFull:{config:{default:{helper:o.ZP.getLang("designForm_rule_action_content_helper"),title:o.ZP.getLang("designForm_rule_action_content"),class:"col-md-12",rows:10,code_form_component:"action_content"},cmd:{isHelper:!0,disable:!1,visible:!0,error:{message:"",type:""}}},data:[],value:this.data.component_manager,abs_Change:this.onChangeValue}}),this.loadDataToState=()=>{let e={};return e.title=o.ZP.getLang("designForm_rule_managerComponent_title"),e.status_form=this.props.modal_edit_rule_func.ruleStrong_default.isStatus,e.order=this.props.modal_edit_rule_func.ruleStrong_default.order,e.code_active=this.convert_active_template(),e.code_get_data=this.convert_code_get_data_template(),e.option_active=this.convert_option_active_template(),e.begin=this.props.modal_edit_rule_func.ruleStrong_default.isStart,e.status=this.props.modal_edit_rule_func.ruleStrong_default.inUse,e.event=this.convert_event_template(),e.action=this.convert_action_template(),e.action_content=this.convert_action_content_template(),e.isDidStart=this.props.modal_edit_rule_func.ruleStrong_default.isDidStart,e.isOpenFromOther=this.props.modal_edit_rule_func.ruleStrong_default.isOpenFromOther,e.button_save={dataFull:{config:{default:{title:o.ZP.getLang("designForm_rule_save"),type:"primary",icon:""},cmd:{disable:!1,isLoading:!1,isFocus:!1}},abs_Click:this.getData}},e},this.componentDidMount=()=>{let{modal:e}=this.state,{form:t}=this.state;e={title:o.ZP.getLang("designForm_rule_modal_title"),helper:o.ZP.getLang("designForm_rule_modal_title_helper"),abs_Close:this.func_close_modal,visibility:!0},t.rule_managerComponent=this.loadDataToState(),t.list_component={title:o.ZP.getLang("designForm_rule_listcp"),helper:o.ZP.getLang("designForm_rule_listcp_helper"),table_config:[{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}}],table_header:{dataFull:{Header:{data:[{title:"Layout",config:{width:"",isFrozen:!1}},{title:"View",config:{isFrozen:!1}},{title:"Name",config:{isFrozen:!1}},{title:"Code",config:{isFrozen:!1}}],config:{mode:{hasSearch:!1,isFrozenHeader:!0}}},config:{mode:{noHeader:!1}}}},table_data:this.props.modal_edit_rule_func.list_components},this.setState({modal:e,form:t})},this.func_close_modal=()=>{this.props.func_cancel_modal_edit_rule_func()},this.onChangeValue=(e,t)=>{let{form:a}=this.state;a.rule_managerComponent[t].dataFull.value=e.target.value,this.setState({form:a})},this.onChangeValueSelect=(e,t,a)=>{let{form:n}=this.state;if(a){for(const t of n.rule_managerComponent[a].dataFull.data)t.selected=t.value===e;this.setState({form:n})}},this.Modal_ManagerComponent_Rule=(0,l.Iq)("designFormModal_ruleFunction_managerComponent"),this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.data=this.readConfig(this.props.modal_edit_rule_func.ruleStrong_detail),this.state={modal:{},form:{}}}readConfig(e){var t={};return void 0===e&&(e={}),null!=e.component_event&&""!==e.component_event?t.component_event=e.component_event:t.component_event="enter_tab",null!=e.component_action?t.component_action=e.component_action:t.component_action="",null!=e.component_manager?t.component_manager=e.component_manager:t.component_manager='{\n    "component_code_1": "@{component_code_key} === 1X",\n    "component_code_2": "@{component_code_key} === 2X",\n    "component_code_3": "@{component_code_key} === 3X"\n}',null!=e.is_use_block?t.is_use_block=e.is_use_block:t.is_use_block="true",t}render(){const e=this.Modal_ManagerComponent_Rule;return(0,r.jsx)(e,{stateData:this.state})}}const c=i}}]);