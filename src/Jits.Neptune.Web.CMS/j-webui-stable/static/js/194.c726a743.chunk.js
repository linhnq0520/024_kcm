"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[194],{194:(e,t,a)=>{a.r(t),a.d(t,{default:()=>r});var i=a(7313),s=a(1896),o=a(5842),l=a(6633),_=a(9676),m=a(7679),n=a(6417);class d extends i.Component{constructor(e){super(e),this.onChangeValueSelect=(e,t,a)=>{let{modal_rename_state:i}=this.state;if(a){for(const t of i.form[a].dataFull.data)t.selected=t.value===e;this.setState({modal_rename_state:i})}},this.createListApp=e=>{let t=[];for(let a=0;a<this.allListApp.length;a++)t.push({title:this.allListApp[a].app,value:this.allListApp[a].app,selected:e===this.allListApp[a].app});return t},this.createListTemplate=()=>{let e=[],t=this.allListFormTemplate.reduce(((e,t)=>(void 0!==t.template&&void 0!==t.template.group_code&&(e[t.template.group_code]=[...e[t.template.group_code]||[],t]),e)),{});for(const[a,i]of Object.entries(t)){let t=[];for(let e=0;e<i.length;e++)t.push({img:i[e].template.img,title:i[e].info.title,dataItem:{template:i[e].template,key_form:i[e].info.form_code,title:i[e].info.title}});e.push({title:a,data:t})}return e},this.componentDidUpdate=(e,t)=>{if(this.props.allListForms!==e.allListForms){this.allListForms=this.props.data.allListForms.map((e=>e[this.DESIGNFORM_CODE_DATABASE])),this.allDesignToolItems=this.props.data.allDesignToolItems.map((e=>e[this.DESIGNFORM_CODE_TOOL_ITEMS])),this.allDesignToolGroups=this.props.data.allDesignToolGroups.map((e=>e[this.DESIGNFORM_CODE_TOOL_GROUPS])),this.allListFormTemplate=this.props.data.allListFormTemplate.map((e=>e[this.DESIGNFORM_CODE_FORM_TEMPLATE])),this.allListApp=this.props.data.allListApp;let e=[],t=this.createListTemplate();for(let i=0;i<this.allListFormTemplate.length;i++){const t=this.allListFormTemplate[i];e.push({title:t.info.title,img:t.template.img,dataItem:{template:t.template,key_form:t.info.form_code,title:t.info.title}})}e.sort((function(e,t){return e.dataItem.template.isBlank?-1:t.dataItem.template.isBlank?1:0}));let a=this.state.design_form_begin;a.list_forms=this.convert_listForm_dataTemplate(this.allListForms),a.list_templates.data=t,a.list_forms_begin.data=e,this.setState({design_form_begin:a},(()=>{this.props.func_DF_Begin_setNoLoading()}))}},this.func_ListForm_Close=e=>{let{design_form_begin:t,design_form_design:a}=this.state;t.list_forms=this.convert_listForm_dataTemplate(this.allListForms),t.search.value="",a.cmd.visibility=!1,this.setState({design_form_begin:t,design_form_design:a},(()=>{}))},this.func_Template_Open=async e=>{let t=this.allListFormTemplate.find(((t,a)=>t.info.form_code===e.key_form));this.func_ListForm_Rename({title:t.info.title,isCreate:!0,newForm:t})},this.func_ListForm_Open=e=>{let t=this.state.design_form_design,a=this.allListForms.find(((t,a)=>t.info.form_code===e.key_form&&t.info.app===e.app));(0,s.Yr)([{txcode:"bo-designForm-loadDataForm",input:{dataItem:{key_form:a.info.form_code,app_code:a.info.app}}}],{}).then((async e=>{let a=o.ZP.foGetData("result",e),i={};if("NOT_ERROR"===a.error_code){let e=a.data_form[this.DESIGNFORM_CODE_DATABASE];void 0===this.data_cdlist[e.info.app]?(i=await this.bo_load_cdlist(e.info.app),this.data_cdlist[e.info.app]=i):i=this.data_cdlist[e.info.app],t.form_detail=e,t.data_cdlist=i,t.cmd.visibility=!0,this.setState({design_form_design:t},(()=>{this.showToast("Open Form",!0)}))}else this.showToast("Open Form",!1)}))},this.list_forms_render_data=(e,t,a)=>{let i=[];e=e.sort(((e,t)=>(0,l.ec)(e.info.last_update,"DD/MM/YYYY hh:mm:ss A")>(0,l.ec)(t.info.last_update,"DD/MM/YYYY hh:mm:ss A")?-1:(0,l.ec)(e.info.last_update,"DD/MM/YYYY hh:mm:ss A")<(0,l.ec)(t.info.last_update,"DD/MM/YYYY hh:mm:ss A")?1:0));for(let s=t;s<a;s++){let t=e[s];i.push({app:t.info.app,title:t.info.title,link:t.info.link?t.info.link:`/${t.info.app}/form`,code:t.info.form_code,last_update:t.info.last_update?t.info.last_update:"",icon:t.info.icon?t.info.icon:"account_balance_wallet",dataItem:{key_form:t.info.form_code,title:t.info.title,app:t.info.app},img:t.info.img?t.info.img:"../rs/global/img/image_form_default.png",list_buttons:this.listForm_createButtonList({key_form:t.info.form_code,title:t.info.title,app:t.info.app}),abs_OpenForm:this.func_ListForm_Open})}return i},this.listForm_createButtonList=e=>[{title:o.ZP.getLang("designForm_btn_open"),icon_item:"folder_open",dataItem:e,abs_Click:this.func_ListForm_Open},{title:o.ZP.getLang("designForm_btn_duplicate"),icon_item:"copy",dataItem:e,abs_Click:this.func_ListForm_Duplicate},{title:o.ZP.getLang("designForm_btn_rename"),icon_item:"title",dataItem:e,abs_Click:this.func_ListForm_Rename},{title:o.ZP.getLang("designForm_btn_delete"),icon_item:"delete",dataItem:e,abs_Click:this.func_ListForm_Delete}],this.func_ListForm_Delete=e=>{let t=this.state.modal_delete_state;t.modal.visibility=!0,this.modal_delete_dataItem=e,this.setState({modal_delete_state:t})},this.func_ListForm_Duplicate=e=>{if(this.allListForms){let t=-1,a=o.ZP.cloneJson(this.allListForms.find(((a,i)=>(t=i,a.info.form_code===e.key_form&&a.info.app===e.app))));if(a){const i=a.info.form_code;a.info.form_code=o.ZP.autoID(),a.info.title="Copy - "+e.title,this.func_ListForm_Rename({app:a.info.app,form_code:a.info.form_code,title:a.info.title,isCopy:!0,newDuplicateForm:a,index_item:t,old_key_form:i})}}},this.showToast=(e,t)=>{var a={};if(!0===t)a={class_:"success",icon:"fa fa-check",title:e+" successfully",time:(new Date).getTime()+"",description:e+" Successfully",data:{},action:{}};else a={class_:"error",icon:"fa fa-check",title:e,time:(new Date).getTime()+"",description:e,data:{},action:{}};o.ZP.pushNotify("notifyToast",a,{}),o.ZP.callAllScreenListen()},this.func_ListForm_Rename=e=>{let t=this.state.modal_rename_state;t.form.input_confirm.cmd.error.message="",t.modal.visibility=!0,t.form.input_confirm.value=e.title,this.modal_rename_dataItem.dataItem=o.ZP.cloneJson(e),e.isCreate?(t.form.form_code.cmd.visible=!0,t.form.form_code.value=e.newForm.info.form_code,t.form.app_code.dataFull.config.cmd.visible=!0,t.form.app_code.dataFull.data=this.createListApp(e.newForm.info.app),t.modal.title=o.ZP.getLang("designform_modal_title_create"),t.form.title=o.ZP.getLang("designform_form_title_create"),this.modal_rename_dataItem.isCreate=!0,this.modal_rename_dataItem.isCopy=!1):e.isCopy?(t.form.form_code.cmd.visible=!0,t.form.form_code.value=e.form_code,t.form.app_code.dataFull.config.cmd.visible=!0,t.form.app_code.dataFull.data=this.createListApp(e.app),t.modal.title=o.ZP.getLang("designform_modal_title_duplicate"),t.form.title=o.ZP.getLang("designform_form_title_duplicate"),this.modal_rename_dataItem.isCreate=!1,this.modal_rename_dataItem.isCopy=!0):(this.modal_rename_dataItem.old_app=e.app,t.form.form_code.cmd.visible=!1,t.form.app_code.dataFull.config.cmd.visible=!1,this.modal_rename_dataItem.isCopy=!1,this.modal_rename_dataItem.isCreate=!1,t.modal.title=o.ZP.getLang("designform_modal_title_rename"),t.form.title=o.ZP.getLang("designform_form_title_rename")),this.setState({modal_rename_state:t})},this.func_Template_ShowMore=()=>{},this.func_ClickChooseTemplate=()=>{},this.func_DF_begin_search=e=>{let t=this.state.design_form_begin;t.search.value=e.target.value,this.df_begin_search_settimeout.isTyping=!0,this.setState({design_form_begin:t},(()=>{setTimeout((()=>{let{design_form_begin:e}=this.state,a=this.allListForms.filter((e=>e.info.title.toLowerCase().includes(t.search.value.toLowerCase().trim())||e.info.form_code.toLowerCase().includes(t.search.value.toLowerCase().trim())));a&&(e.list_forms=this.convert_listForm_dataTemplate(a),this.setState({design_form_begin:e}))}),300)}))},this.func_df_CloseRenameModal=()=>{let e=this.state.modal_rename_state;e.modal.visibility=!1,this.setState({modal_rename_state:e})},this.func_df_CloseDeleteModal=()=>{let e=this.state.modal_delete_state;e.modal.visibility=!1,this.setState({modal_delete_state:e})},this.func_df_confirmDelete=()=>{let{design_form_begin:e}=this.state;(0,s.Yr)([{txcode:"bo-designForm-delete",input:{dataItem:{key_form:this.modal_delete_dataItem.key_form,app_code:this.modal_delete_dataItem.app}}}],{}).then((t=>{if("NOT_ERROR"===o.ZP.foGetData("result",t).error_code){const t=this.allListForms.findIndex((e=>e.info.form_code===this.modal_delete_dataItem.key_form&&e.info.app===this.modal_delete_dataItem.app));-1!==t&&this.allListForms.splice(t,1),e.search.value="",e.list_forms=this.convert_listForm_dataTemplate(this.allListForms),this.setState({design_form_begin:e},(()=>{this.func_df_CloseDeleteModal(),this.showToast(o.ZP.getLang("designForm_btn_delete"),!0)}))}else this.func_df_CloseDeleteModal(),this.showToast(o.ZP.getLang("designForm_btn_delete"),!1)}))},this.func_designForm_Rename_Change_form_code=e=>{let t=this.state.modal_rename_state;t.form.form_code.value=e.target.value,this.setState({modal_rename_state:t})},this.func_designForm_Rename_Change=e=>{let t=this.state.modal_rename_state;t.form.input_confirm.value=e.target.value,this.setState({modal_rename_state:t})},this.bo_load_cdlist=async e=>{let t={};return t=await(0,s.Yr)([{txcode:"bo-designForm-loadcdlist",input:{dataItem:{app:e}}}],{}),t=o.ZP.foGetData("result",t),t.data_cdlist},this.bo_save_form=async e=>{let t={},a={};return a[this.DESIGNFORM_CODE_DATABASE]=o.ZP.cloneJson(e),void 0!==a[this.DESIGNFORM_CODE_DATABASE].template&&a[this.DESIGNFORM_CODE_DATABASE].template.isTemplate,delete a[this.DESIGNFORM_CODE_DATABASE].template,t=await(0,s.Yr)([{txcode:"bo-designForm-save",input:{dataItem:{key_form:a[this.DESIGNFORM_CODE_DATABASE].info.form_code,newForm_Data:a,app_code:a[this.DESIGNFORM_CODE_DATABASE].info.app}}}],{}),t},this.bo_add_fee=async(e,t,a,i,o)=>{let l={};return l=await(0,s.Yr)([{txcode:"bo-designForm-addFee",input:{list_form:e,list_learn_api:t,learn_api_accept_id:a,mapping_fee:i,app_code:o}}],{}),l},this.bo_saveRename_form=async e=>{let t={},a={};return a[this.DESIGNFORM_CODE_DATABASE]=o.ZP.cloneJson(e),void 0!==a[this.DESIGNFORM_CODE_DATABASE].template&&a[this.DESIGNFORM_CODE_DATABASE].template.isTemplate,delete a[this.DESIGNFORM_CODE_DATABASE].template,t=await(0,s.Yr)([{txcode:"bo-designForm-saveRename",input:{dataItem:{key_form:a[this.DESIGNFORM_CODE_DATABASE].info.form_code,new_name:a[this.DESIGNFORM_CODE_DATABASE].info.title,app_code:a[this.DESIGNFORM_CODE_DATABASE].info.app}}}],{}),t},this.bo_saveDuplicate_form=async(e,t,a)=>{let i={},l={};return l[this.DESIGNFORM_CODE_DATABASE]=o.ZP.cloneJson(e),void 0!==l[this.DESIGNFORM_CODE_DATABASE].template&&l[this.DESIGNFORM_CODE_DATABASE].template.isTemplate,delete l[this.DESIGNFORM_CODE_DATABASE].template,i=await(0,s.Yr)([{txcode:"bo-designForm-saveDuplicate",input:{dataItem:{old_app:a,new_key_form:l[this.DESIGNFORM_CODE_DATABASE].info.form_code,old_key_form:t,newForm_data:l,app_code:l[this.DESIGNFORM_CODE_DATABASE].info.app}}}],{}),i},this.func_designForm_Rename_Save=async()=>{const{modal_rename_state:e}=this.state,t=e.form.input_confirm.value;let a="",i="";if(this.modal_rename_dataItem.isCopy||this.modal_rename_dataItem.isCreate){var s;a=e.form.form_code.value,i=(null===(s=e.form.app_code.dataFull.data.find((e=>e.selected)))||void 0===s?void 0:s.value)||"";if(this.allListForms.find((e=>e.info.form_code===a&&e.info.app===i)))e.form.form_code.cmd.error.message=" This form code is taken. Try another. ",this.setState({modal_rename_state:e});else if(this.modal_rename_dataItem.isCreate){let e=this.state.design_form_design,s=o.ZP.cloneJson(this.modal_rename_dataItem.dataItem.newForm);s.info.title=t,s.info.last_update=this.formatDate(),s.info.form_code=a,s.info.app=i,s.list_layout=JSON.parse(JSON.stringify(s.list_layout).replaceAll("@{form_code_posting}",a.replace("_posting","")).replaceAll("@{form_code}",a).replaceAll("@{workflow_id}",a.replace("FO_","")));let l={};void 0===this.data_cdlist[s.info.app]?(l=await this.bo_load_cdlist(s.info.app),this.data_cdlist[s.info.app]=l):l=this.data_cdlist[s.info.app],e.form_detail=s,e.data_cdlist=l,e.cmd.visibility=!0,this.setState({design_form_design:e},(()=>{this.func_df_CloseRenameModal(),this.showToast("Open Form",!0)}))}else{let e=this.modal_rename_dataItem.dataItem.newDuplicateForm,t=this.modal_rename_dataItem.dataItem.app;e.info.last_update=this.formatDate(),e.info.form_code=a,e.info.app=i,e.info.title=this.state.modal_rename_state.form.input_confirm.value,e.info.des=this.state.modal_rename_state.form.input_confirm.value,this.bo_saveDuplicate_form(e,this.modal_rename_dataItem.dataItem.old_key_form,t).then((t=>{if("NOT_ERROR"===o.ZP.foGetData("result",t).error_code){let t=this.state.design_form_begin;this.allListForms.splice(this.modal_rename_dataItem.dataItem.index_item+1,0,e),t.search.value="",t.list_forms=this.convert_listForm_dataTemplate(this.allListForms),this.setState({design_form_begin:t},(()=>{this.func_df_CloseRenameModal(),this.showToast(o.ZP.getLang("designForm_btn_duplicate"),!0)}))}else this.func_df_CloseRenameModal(),this.showToast(o.ZP.getLang("designForm_btn_duplicate"),!1)}))}}else{a=this.modal_rename_dataItem.dataItem.key_form,i=this.modal_rename_dataItem.dataItem.app;if(this.allListForms.find((e=>e.info.title===t&&e.info.form_code!==a&&e.info.app===i)))e.form.input_confirm.cmd.error.message=" This name is taken. Try another. ",this.setState({modal_rename_state:e});else{const e=this.allListForms.find((e=>e.info.form_code===a&&e.info.app===i));if(e){e.info.title=t,e.info.last_update=this.formatDate();const a=await this.bo_saveRename_form(e);if("NOT_ERROR"===o.ZP.foGetData("result",a).error_code){let a=this.state.design_form_begin;const i=this.allListForms.findIndex((e=>e.info.form_code===this.modal_rename_dataItem.dataItem.form_code&&e.info.app===this.modal_rename_dataItem.dataItem.app));-1!==i&&(this.allListForms[i].info.title=t,this.allListForms[i].info.last_update=e.info.last_update),a.search.value="",a.list_forms=this.convert_listForm_dataTemplate(this.allListForms),this.setState({design_form_begin:a},(()=>{this.func_df_CloseRenameModal(),this.showToast(o.ZP.getLang("designForm_btn_rename"),!0)}))}else this.func_df_CloseRenameModal(),this.showToast(o.ZP.getLang("designForm_btn_rename"),!1)}}}},this.convert_listForm_dataTemplate=e=>{let t=[];return t=e.length>=this.RENDER_ITEMS_NUMBER?this.list_forms_render_data(e,0,this.RENDER_ITEMS_NUMBER):this.list_forms_render_data(e,0,e.length),t},this.getAllFormByApp=e=>this.allListForms.filter((t=>t.info.app===e)),this.DESIGNFORM_CODE_DATABASE="designForm",this.DESIGNFORM_CODE_TOOL_GROUPS="designToolGroup",this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.DESIGNFORM_CODE_FORM_TEMPLATE="designFormTemplate",this.RENDER_ITEMS_NUMBER=50,this.allListForms=[],this.allDesignToolItems=[],this.allDesignToolGroups=[],this.allListFormTemplate=[],this.allListApp=[],this.form_index=-1,this.DF_Begin_Render=(0,_.Iq)("screen_begin"),this.Modal_Delete_Render=(0,_.Iq)("designFormModal_form_delete"),this.Modal_Rename_Render=(0,_.Iq)("designFormModal_form_rename"),this.modal_rename_dataItem={isCopy:!1,newDuplicateForm:{},old_key_form:""},this.modal_delete_dataItem={},this.modal_delete_component_dataItem={},this.isSearching=!1,this.df_begin_search_settimeout={isTyping:!1,func_setTimeOut:null},this.data_cdlist={},this.state={lang_system:o.ZP.getConfigUserDefault("list_lang_config"),design_form_design:{cmd:{visibility:!1},form_detail:{},form_index:-1,data_cdlist:{}},design_form_begin:{cmd:{visibility:!0},lang_menu:{data:[{title:"English",selected:!0,img:"../rs/global/img/uk.png",dataItem:{aaa:"aaa"}},{title:"Ti\u1ebfng Vi\u1ec7t",img:"../rs/global/img/vietnam.png",dataItem:{aaa:"aaa"}}],abs_Click:this.test},lang:{title:o.ZP.getLang("designForm_title"),powered_by:o.ZP.getLang("designForm_powered_by"),jwebui:"JwebUI",list_form:o.ZP.getLang("designForm_list_form"),more_template:o.ZP.getLang("designForm_more_template"),alt_img:o.ZP.getLang("designForm_alt_img"),last_update:o.ZP.getLang("designForm_last_update"),back_to_home:o.ZP.getLang("designForm_BacktoHome"),title_icon_copy:"copy",title_icon_delete:"delete",title_icon_duplicate:"duplicate",title_icon_rename:"rename"},list_forms_begin:{abs_Click:this.func_Template_Open,data:[]},list_templates:{abs_Click:this.func_Template_Open,abs_TemplateShowMore:this.func_Template_ShowMore,data:[]},search:{placeholder:"Search",value:"",abs_Change:this.func_DF_begin_search},mode_list:{table_column:[o.ZP.getLang("designForm_name"),o.ZP.getLang("designForm_code"),o.ZP.getLang("designForm_last_update"),""]},list_forms:[]},modal_rename_state:{form:{title:o.ZP.getLang("designForm_rename_TitleForm"),list_buttons:[{dataFull:{config:{default:{title:o.ZP.getLang("designForm_btn_cancel"),type:"",icon:""},cmd:{disable:!1,isLoading:!1,isFocus:!1}},abs_Click:this.func_df_CloseRenameModal}},{dataFull:{config:{default:{title:o.ZP.getLang("designForm_btn_save"),type:"primary",icon:""},cmd:{disable:!1,isLoading:!1,isFocus:!1}},abs_Click:this.func_designForm_Rename_Save}}],input_confirm:{title:o.ZP.getLang("rename_input_confirm"),cmd:{error:{message:"",type:"error"}},value:"",placeholder:o.ZP.getLang("designForm_rename_InputConfirm"),abs_Change:this.func_designForm_Rename_Change},form_code:{title:o.ZP.getLang("rename_form_code"),cmd:{visible:!1,error:{message:"",type:"error"}},value:"",placeholder:o.ZP.getLang("designForm_rename_form_code"),abs_Change:this.func_designForm_Rename_Change_form_code},app_code:{dataFull:{config:{default:{search:{placeholder:"Search"},helper:o.ZP.getLang("rename_app_code"),data_status:"No Result",title:o.ZP.getLang("rename_app_code"),class:"col-md-6",required:!1,code_form_component:"app_code"},cmd:{isHelper:!0,disable:!1,visible:!1,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[],search_value:"",abs_Change:this.onChangeValueSelect,abs_search:this.search}}},modal:{title:o.ZP.getLang("designForm_rename_TitleModal"),abs_Close:this.func_df_CloseRenameModal,visibility:!1}},modal_delete_state:{form:{title:o.ZP.getLang("designForm_delete_TitleForm"),list_buttons:[{dataFull:{config:{default:{title:o.ZP.getLang("designForm_btn_cancel"),type:"",icon:""},cmd:{disable:!1,isLoading:!1,isFocus:!1}},abs_Click:this.func_df_CloseDeleteModal}},{dataFull:{config:{default:{title:o.ZP.getLang("designForm_btn_delete"),type:"danger",icon:""},cmd:{disable:!1,isLoading:!1,isFocus:!1}},abs_Click:this.func_df_confirmDelete}}]},modal:{title:o.ZP.getLang("designForm_delete_TitleModal"),abs_Close:this.func_df_CloseDeleteModal,visibility:!1}}}}formatDate(e){return e||(e=(new Date).getTime()),(0,l.FW)(e,"DD/MM/YYYY hh:mm:ss A")}render(){const e=this.DF_Begin_Render,t=this.Modal_Rename_Render,a=this.Modal_Delete_Render;return(0,n.jsx)("div",{className:"d-flex col-12",children:(0,n.jsxs)("div",{className:"main",style:{width:"100%"},children:[(0,n.jsx)(e,{stateData:this.state.design_form_begin}),(0,n.jsx)(t,{stateData:this.state.modal_rename_state}),(0,n.jsx)(a,{stateData:this.state.modal_delete_state}),(0,n.jsx)(m.default,{visibility:this.state.design_form_design.cmd.visibility,bo_save_form:this.bo_save_form,bo_add_fee:this.bo_add_fee,getAllFormByApp:this.getAllFormByApp,showToast:this.showToast,func_ListForm_Close:this.func_ListForm_Close,data:{allDesignToolGroups:this.allDesignToolGroups,allDesignToolItems:this.allDesignToolItems,allListApp:this.allListApp,allListForms:this.allListForms,form_detail:this.state.design_form_design.form_detail,data_cdlist:this.state.design_form_design.data_cdlist,allListReport:this.props.data.allListReport}})]})})}}const r=d}}]);