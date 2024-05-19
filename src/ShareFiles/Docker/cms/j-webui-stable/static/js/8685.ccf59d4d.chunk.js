"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[8685],{8685:(t,e,o)=>{o.r(e),o.d(e,{default:()=>c});var i=o(7313),s=o(5842),l=o(1896),a=o(9676),r=o(6417);let n=(0,a.Iq)("jwebui_roleMatrix"),d=(0,a.Iq)("jwebui_role_matrix_manager");class _ extends i.Component{constructor(t){var e;super(t),this.changeKeyLanguage=t=>{let e={note:s.ZP.getLang("note"),title_:s.ZP.getLang("roleMatrix_title"),des_:s.ZP.getLang("roleMatrix_des"),function:s.ZP.getLang("roleMatrix_function"),role:s.ZP.getLang("roleMatrix_role"),power:s.ZP.getLang("roleMatrix_power"),rolesearch:s.ZP.getLang("roleMatrix_rolesearch"),permissionsearch:s.ZP.getLang("roleMatrix_permissionsearch"),access_function:s.ZP.getLang("roleMatrix_accessFunction"),data_monitoring:s.ZP.getLang("roleMatrix_dataMonitoring"),decentralized_objects:s.ZP.getLang("roleMatrix_decentralizedObjects"),constructor:s.ZP.getLang("roleMatrix_constructor"),set_up_power:s.ZP.getLang("roleMatrix_setUpPower"),form_btn_close:s.ZP.getLang("form_close_title"),form_btn_add:s.ZP.getLang("form_add_title")};if(void 0!==t)return e;let o=this.stateHidden.infoA;o.title=s.ZP.getLang("roleMatrix_title"),o.des=s.ZP.getLang("roleMatrix_des"),o.lang_form.vi=s.ZP.getLang("roleMatrix_title"),o.lang_form.en=s.ZP.getLang("roleMatrix_title"),this.stateHidden.infoA=o,this.stateHidden.languages=e,this.setState({lang_key:s.ZP.getLangKey()}),this.changeLanguageTemplate(e)},this.closeForm=()=>{s.ZP.removeForm(this.key_form)},this.getInfoA=()=>this.stateHidden.infoA,this.getKeyFormAuto=()=>this.key_form,this.callSetHidden=t=>{this.stateHidden.hidden="none"===t,this.setState({reload:!0})},this.abs_search_role=t=>{let e=this.state.stateData;e.role_search.value=t.target.value,e.listButton=this.ROLE_SYSTEM.filter((e=>{let o=e.role_system.role_system_name.toLowerCase(),i=t.target.value.toLowerCase();return o.includes(i)})).map(((t,e)=>({dataFull:{config:{default:{title:t.role_system.role_system_name,type:0===e?"primary":"",class:"col-sm-12"}},dataItem:{id:t.role_system.role_system_id}},abs_Click:this.abs_select_role}))),this.setState({stateData:e})},this.abs_search_form=t=>{let e=t.target.value,o=this.state.stateData,i=this.MENU_TEMPLATE.filter((t=>t.title.toLowerCase().includes(e.toLowerCase())));this.list_menu_id=i.map((t=>t.id)),i=this.getListMenuChild(i),i=this.getListMenuParent(i),o.form_search.value=e,o.listTreeItem.tree_data=i,this.setState({stateData:o,form_search:""})},this.abs_select_item_menu=(t,e)=>{const o=e.dataItem.menu.group_menu.group_menu_function_code,i=this.state.role_select;this.onCallForm(o,i)},this.abs_select_role=(t,e)=>{let o=this.state.stateData;for(let i of o.listButton)i.dataFull.dataItem.id===e.id?i.dataFull.config.default.type="primary":i.dataFull.config.default.type="";this.setState({stateData:o,role_select:e.id},(()=>{const t=this.state.form_select,e=this.state.role_select;this.onCallForm(t,e)}))},this.buildActionStatus=(t,e)=>{let o=[];for(const l in e){let a=e[l];for(const e in a.list_view){let l=a.list_view[e];for(const e in l.list_input){let a=l.list_input[e];if("cButton"===a.inputtype){var i,s;let e=a.default.name;o.push({name:e,status:!(null===(i=t[this.state.role_select][a.default.codeHidden])||void 0===i||null===(s=i.component)||void 0===s||!s.install)})}}}}return o},this.abs_Click_check_access_function=t=>{let e;void 0!==t&&void 0!==t.config&&void 0!==t.config.info&&void 0!==t.config.info.form_code&&(e=t.config.info.form_code);let o=t.role_id,i={};i[o]=t.form_role,void 0===i[o][e]&&(i[o][e]={}),void 0===i[o][e].form&&(i[o][e].form={}),i[o][e].form.accept=!i[o][e].form.accept;let s=t.config.list_layout;for(const l in s){let t=s[l];void 0===i[o][t.codeHidden]&&(i[o][t.codeHidden]={layout:{install:!0}});for(const e in t.list_view){let s=t.list_view[e];void 0===i[o][s.codeHidden]&&(i[o][s.codeHidden]={view:{install:!0}});for(const t in s.list_input){let e=s.list_input[t];void 0===i[o][e.default.codeHidden]&&(i[o][e.default.codeHidden]={component:{install:!0}})}}}l.Yr([{txcode:"bo-save-roleMatrix",input:{form_id:e,content:JSON.stringify(i),role_select:o,action_status:this.buildActionStatus(i,s)}}],{infoA:{key_form:this.key_form}}).then((t=>{this.onCallForm(this.state.form_select,o)}))},this.abs_Click_check_role_contructor=t=>{let e=t.form_id,o=t.role_id,i={};void 0===i[o]&&(i[o]={}),i[o]=t.form_role,i[o][t.codeHidden]={[t.type]:{install:!t.constructor}};let s=t.layout;switch(t.type){case"layout":for(const e in s){let l=s[e];if(l.codeHidden===t.codeHidden){for(const e in l.list_view){let s=l.list_view[e];i[o][s.codeHidden]={view:{install:!t.constructor}};for(const e in s.list_input){let l=s.list_input[e];i[o][l.default.codeHidden]={component:{install:!t.constructor}}}}break}}break;case"view":for(const e in s){let l=s[e];for(const e in l.list_view){let s=l.list_view[e];if(s.codeHidden===t.codeHidden){i[o][s.codeHidden]={view:{install:!t.constructor}};for(const e in s.list_input){let l=s.list_input[e];i[o][l.default.codeHidden]={component:{install:!t.constructor}}}break}}}}l.Yr([{txcode:"bo-save-roleMatrix",input:{form_id:e,content:JSON.stringify(i),role_select:o,action_status:this.buildActionStatus(i,s)}}],{infoA:{key_form:this.key_form}}).then((t=>{this.onCallForm(this.state.form_select,o)}))},this.getMenuTreeTemplate=()=>this.DATA_MENU.map((t=>({title:t.group_menu.group_menu_name||"#ERROR",parent_id:t.group_menu.group_menu_parent,is_open:!1,DOM_elm:null,id:t.group_menu.group_menu_id,dataItem:{menu:t},abs_click:this.abs_select_item_menu}))),this.getCheckboxTreeTemplate=(t,e,o)=>{var i,s,l,a;return{abs_Click_check_access_function:this.abs_Click_check_access_function,form_name:t.info.title,dataItem:{config:t,form_role:e,role_id:o},access_function:(null===e||void 0===e||null===(i=e[t.info.form_code])||void 0===i||null===(s=i.form)||void 0===s?void 0:s.accept)||!1,data_monitoring:(null===e||void 0===e||null===(l=e[t.info.form_code])||void 0===l||null===(a=l.form)||void 0===a?void 0:a.follow)||!1,list_layout:t.list_layout.map((i=>{var s,l;return{dataItem:{type:"layout",codeHidden:i.codeHidden,constructor:(null===e||void 0===e||null===(s=e[i.codeHidden])||void 0===s?void 0:s.layout.install)||!1,permission:!1,role_id:o,layout:i,form_id:t.info.form_code,form_role:e},name:i.name||"Layout: #NO_NAME",abs_Click_constructor:this.abs_Click_check_role_contructor,constructor:(null===e||void 0===e||null===(l=e[i.codeHidden])||void 0===l?void 0:l.layout.install)||!1,permission:!1,default:i.default,list_view:i.list_view.map((s=>{var l,a;return{dataItem:{type:"view",codeHidden:s.codeHidden,constructor:(null===e||void 0===e||null===(l=e[s.codeHidden])||void 0===l?void 0:l.view.install)||!1,permission:!1,role_id:o,layout:i,form_id:t.info.form_code,form_role:e},name:s.name||"View: #NO_NAME",abs_Click_constructor:this.abs_Click_check_role_contructor,constructor:(null===e||void 0===e||null===(a=e[s.codeHidden])||void 0===a?void 0:a.view.install)||!1,permission:!1,default:s.default,list_input:s.list_input.map((s=>{var l,a;return{dataItem:{type:"component",codeHidden:s.default.codeHidden,constructor:(null===e||void 0===e||null===(l=e[s.default.codeHidden])||void 0===l?void 0:l.component.install)||!1,permission:!1,role_id:o,layout:i,form_id:t.info.form_code,form_role:e},abs_Click_constructor:this.abs_Click_check_role_contructor,constructor:(null===e||void 0===e||null===(a=e[s.default.codeHidden])||void 0===a?void 0:a.component.install)||!1,permission:!1,default:s.default}}))}}))}}))}},this.findListAuthorzieForms=t=>{let e="";for(let o=0;o<this.DATA_MENU.length;o++){const i=this.DATA_MENU[o].group_menu;void 0!==i.group_menu_function_code&&i.group_menu_function_code===t&&void 0!==i.group_menu_list_authorize_form&&(e=i.group_menu_list_authorize_form)}return e},this.key_form="roleMatrix",this.DATA_MENU=s.ZP.getData("group_menu").sort((function(t,e){return t.group_menu.group_menu_order-e.group_menu.group_menu_order})),this.MENU_TEMPLATE=this.getMenuTreeTemplate(),this.ROLE_SYSTEM=s.ZP.getData("role_system");let o=this.changeKeyLanguage("start");this.stateHidden={infoA:{lang_form:{vi:s.ZP.getLang("roleMatrix_title"),en:s.ZP.getLang("roleMatrix_title")},title:"Permissions System",des:"H\u1ec7 th\u1ed1ng ph\xe2n quy\u1ec1n to\xe0n \u1ee9ng d\u1ee5ng!",openOne:"true",ofModal:!1},languages:o,role_task_tree:{},form_config:{},form_role:{},hidden:!1,role_filter:this.ROLE_SYSTEM,menu_filter:this.DATA_MENU},this.state={lang_key:s.ZP.getLangKey(),form_select:"",role_select:null===(e=this.ROLE_SYSTEM[0])||void 0===e?void 0:e.role_system.role_system_id,role_search:"",form_search:"",stateData:{form:{dataFull:{config:{default:{title:o.title_,title_sub:o.des_,icon:"folder"}},title_button:{close_button:o.form_btn_close,add_form:o.form_btn_add},mode:{form_min:!1},list_button_on_header:[],cmd:{visibility:"",isLoading:!1,isFavorite:!1},abs_Close:this.closeForm,abs_AddMenuBar:this.addMenu}},role:{title:o.role},role_search:{placeholder:o.rolesearch,value:"",abs_search:this.abs_search_role},permission:{title:o.power},form_search:{placeholder:o.permissionsearch,value:"",abs_search:this.abs_search_form},listButton:this.ROLE_SYSTEM.map(((t,e)=>({dataFull:{config:{default:{title:t.role_system.role_system_name,type:0===e?"primary":"",class:"col-sm-12"}},dataItem:{id:t.role_system.role_system_id}},abs_Click:this.abs_select_role}))),listTreeItem:{tree_data:this.MENU_TEMPLATE,config:{open_one:!0,is_has_dom:!0}}}}}changeLanguageTemplate(t){let{stateData:e}=this.state;e.form.dataFull.config.default.title=t.title_,e.form.dataFull.config.default.title_sub=t.des_,e.form.dataFull.title_button.close_button=t.form_btn_close,e.form.dataFull.title_button.add_form=t.form_btn_add,e.role.title=t.role,e.role_search.placeholder=t.rolesearch,e.permission.title=t.power,e.form_search.placeholder=t.permissionsearch,this.setState({stateData:e})}componentWillMount(){this.state.stateData.listTreeItem.tree_data[0].DOM_elm=(0,r.jsx)(d,{dataFull:{access_function:!1,data_monitoring:!1,list_layout:[]}},"no")}componentDidMount(){s.ZP.addAppAuto(this.key_form,this,this.stateHidden.infoA.ofModal),s.ZP.form_addMapping(this.key_form,this.props.mapping_key)}getListMenuParent(t){for(const e of t){let o=this.getMenuTreeTemplate().filter((t=>t.id===e.parent_id&&!1===this.list_menu_id.includes(t.id)&&(this.list_menu_id.push(t.id),!0)));null!==o&&void 0!==o&&o.length&&(t=t.concat(this.getListMenuParent(o)))}return t}getListMenuChild(t){for(const e of t){let o=this.getMenuTreeTemplate().filter((t=>t.parent_id===e.id&&!1===this.list_menu_id.includes(t.id)&&(this.list_menu_id.push(t.id),!0)));null!==o&&void 0!==o&&o.length&&(t=t.concat(this.getListMenuChild(o)))}return t}convertRoleTaskTree(t){let e=this.state.role_select,o=this.state.form_select,i={[e]:{[o]:{form:{accept:!1,follow:!1}}}};return t.list_layout.forEach((t=>{i[e][t.codeHidden]={layout:{install:!0}},t.list_view.forEach((t=>{i[e][t.codeHidden]={view:{install:!0}},t.list_input.forEach((t=>{i[e][t.default.codeHidden]={component:{install:!0}}}))}))})),i}onCallForm(t,e){if(!t||!e)return;let o=this.findListAuthorzieForms(t);(0,l.Yr)([{txcode:"#sys:bo-load-formId",input:{form_id:t}},{txcode:"#sys:bo-load-list-authorize-forms",input:{list_authorize_forms:o}}],{infoA:{key_form:this.key_form}}).then((o=>{var i=s.ZP.foGetData("form_design_detail",o);void 0===i&&(i={info:{form_code:t},list_layout:[]});var l=s.ZP.foGetData("loadRoleTask",o)||{};void 0===l[e]&&(l[e]={[t]:{form:{accept:!1,follow:!1}}});let a=s.ZP.foGetData("list_authorize_forms",o)||[],n=this.state.stateData,_=n.listTreeItem.tree_data,c=[];for(let s of _)if(s.dataItem.menu.group_menu.group_menu_function_code===t){let o=this.getCheckboxTreeTemplate(i,l[e],e);if(a.length>0){for(let o=0;o<a.length;o++){let i=a[o],s=i.form_role_task,l=i.form_design_detail;void 0===l&&(l={info:{form_code:t,form_name:l.info.title},list_layout:[]}),void 0===s[e]&&(s[e]={[t]:{form:{accept:!1,follow:!1}}});let r=this.getCheckboxTreeTemplate(l,s[e],e);c.push(r)}o.list_authorize_forms=c}this.stateHidden.role_task_tree=o,s.DOM_elm=(0,r.jsx)(d,{dataFull:o},t)}n.listTreeItem.tree_data=_,this.stateHidden.form_config=i,this.stateHidden.form_role=l,this.setState({form_select:t,stateData:n})}),(t=>{}))}render(){return(0,r.jsx)("div",{style:{display:this.stateHidden.hidden?"none":""},children:(0,r.jsx)(n,{stateData:this.state.stateData})})}}const c=_}}]);