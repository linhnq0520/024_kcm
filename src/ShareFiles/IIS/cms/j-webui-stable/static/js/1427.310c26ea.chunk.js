"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[1427],{1427:(t,e,a)=>{a.r(e),a.d(e,{default:()=>g});var i=a(3063),s=a(7313),l=a(5842),d=a(3745),n=a(9676),o=a(6417);class r extends s.Component{constructor(t){super(t),this.closeForm=()=>{l.ZP.removeForm(this.key_form)},this.table_select_change_detail=(t,e,a,i,s,l)=>{let{stateData:d}=this.state,n=d.table_para_rows[a][i].data.filter((t=>!0===t.selected));n.length>0&&(n[0].selected=!1);let o=d.table_para_rows[a][i].data.filter(((t,e)=>e===l));if(o.length>0){o[0].selected=!0,d.table_para_rows[a][i].value=o[0].value;let{data:t}=this.logicState;t[a][this.mappingIndexToKey[i.toString()]]=o[0].value,this.setState({stateData:d})}},this.table_input_change_detail=(t,e,a,i)=>{let{stateData:s}=this.state;s.table_para_rows[a][i].data=t.target.value,this.setState({stateData:s})},this.table_input_submit_detail=(t,e,a)=>{let{data:i}=this.logicState,{stateData:s}=this.state;i[e][this.mappingIndexToKey[a.toString()]]=s.table_para_rows[e][a].data},this.table_input_cancel_detail=(t,e,a)=>{let{data:i}=this.logicState,{stateData:s}=this.state;s.table_para_rows[e][a].data=i[e][this.mappingIndexToKey[a.toString()]],this.setState({stateData:s})},this.changeKeyLanguage=t=>{let e={note:l.ZP.getLang("note"),para:l.ZP.getLang("paraServer_para"),val:l.ZP.getLang("paraServer_val"),des:l.ZP.getLang("paraServer_des"),type:l.ZP.getLang("paraServer_type"),title:l.ZP.getLang("paraServer_title"),info_des:l.ZP.getLang("paraServer_info_des"),stt:l.ZP.getLang("stt"),btn_save:l.ZP.getLang("btnSave"),btn_cancel:l.ZP.getLang("btn_cancel"),data_the_same:l.ZP.getLang("dataTheSame"),confirm_add:l.ZP.getLang("confirmAdd"),btn_add_new:l.ZP.getLang("btnAddNew"),form_btn_close:l.ZP.getLang("form_close_title"),form_btn_add:l.ZP.getLang("form_add_title")};if(void 0!==t)return e;let a=this.logicState.infoA;a.title=l.ZP.getLang("paraServer_title"),a.des=l.ZP.getLang("paraServer_info_des"),a.lang_form.vi=l.ZP.getLang("paraServer_title"),a.lang_form.en=l.ZP.getLang("paraServer_title"),this.setLogicState({languages:e,infoA:a}),this.changeLanguageTemplate(e)},this.getInfoA=()=>this.logicState.infoA,this.getKeyFormAuto=()=>this.key_form,this.callSetHidden=t=>{this.setLogicState({visibility:t}),this.setState({invokeReload:!this.state.invokeReload})},this.clickAddHandler=()=>{if(!this.logicState.isAddNewItem){let t=prompt(this.logicState.languages.confirm_add,"");if(null!=t&&"yes"===t){this.setLogicState({isAddNewItem:!0});let{stateData:t}=this.state,e={code:"",value:"",des:"",data_type:"s",isAdmin:!1,isAddNewItem:!0};this.logicState.data.unshift(e),t.table_para_rows=this.getConfigTableParaRows(this.logicState.data),this.setState({stateData:t})}}},this.checkValidate=t=>{let e={isSuccess:!0,message:""};if(""===t.code)e.isSuccess=!1,e.message=`${this.logicState.languages.para} is not allow empty!`;else{this.logicState.data.filter((e=>e.code===t.code)).length>1&&(e.isSuccess=!1,e.message=`${this.logicState.languages.para} "${t.code}" ${this.logicState.languages.data_the_same}`)}return e},this.onCancelParameter=(t,e)=>{if(void 0!==e&&void 0!==e.index&&e.index>=0){this.logicState.data=this.removeData(this.logicState.data,e.index),this.logicState.isAddNewItem=!1;let{stateData:t}=this.state;t.table_para_rows=this.getConfigTableParaRows(this.logicState.data),this.setState({stateData:t})}},this.onSaveParaServer=(t,e)=>{if(void 0!==e&&void 0!==e.index&&e.index>=0){let t=this.logicState.data[e.index],a=this.checkValidate(t);if(a.isSuccess){delete t.isAddNewItem,d.ZP.quickPost([{txcode:"#sys:bo-save-paraServer",input:t}],{}),this.logicState.isAddNewItem=!1;let{stateData:a}=this.state;a.table_para_rows[e.index]=this.getEachDataRowConfig(t,e.index,!0),this.setState({stateData:a},(()=>{a.table_para_rows[e.index]=this.getEachDataRowConfig(t,e.index,!1),this.setState({stateData:a})}))}else alert(a.message)}},this.key_form="paraServer";let e=this.props.data;e=e.filter((t=>!1===(null===t||void 0===t?void 0:t.isAdmin)));let a=this.changeKeyLanguage("start");this.paraServerForm=(0,n.Iq)("jwebui_paraServer");let i=[];for(let s=0;s<e.length;s++)e[s].isAdmin&&l.ZP.checkRoleSuperAdmin()?i[i.length]=e[s]:e[s].isAdmin||(i[i.length]=e[s]);i=i.sort(((t,e)=>t.code>e.code?1:e.code>t.code?-1:0)),this.mappingKeyToIndex={code:1,value:2,des:3,data_type:4},this.mappingIndexToKey={1:"code",2:"value",3:"des",4:"data_type"},this.logicState={isAddNewItem:!1,isAdmin:l.ZP.checkRoleSuperAdmin(),visibility:"",infoA:{lang_form:{vi:l.ZP.getLang("paraServer_title"),en:l.ZP.getLang("paraServer_title")},title:l.ZP.getLang("paraServer_title"),des:l.ZP.getLang("paraServer_title"),openOne:"true",form_code:this.key_form,ofModal:!1},data:i,check_screen_width:void 0,languages:a},this.state={invokeReload:!1,stateData:{form:{dataFull:{config:{default:{title:a.title,title_sub:a.info_des,icon:"folder"}},title_button:{close_button:a.form_btn_close,add_form:a.form_btn_add},mode:{form_min:!1},list_button_on_header:[],cmd:{visibility:"",isLoading:!1,isFavorite:!1},abs_Close:this.closeForm,abs_AddMenuBar:this.addMenu}},add:{dataFull:{config:{default:{title:a.btn_add_new,type:"primary",class:"col-sm-1"},cmd:{visible:!1}}},abs_Click:this.clickAddHandler},table_para:{dataFull:{Header:{data:[{title:a.stt,id:"",config:{width:"50px",isFrozen:!1}},{title:a.para,id:"",config:{width:"",isFrozen:!1}},{title:a.val,id:"",config:{width:"",isFrozen:!1}},{title:a.note,id:"",config:{width:"",isFrozen:!1}},{title:a.type,id:"",config:{width:"",isFrozen:!1}},{title:"",id:"",config:{width:"150px",isFrozen:!1}}],config:{mode:{hasSearch:!1}}},config:{mode:{noHeader:!1}}}},table_para_rows:this.getConfigTableParaRows(i),table_para_rows_config:this.getConfigTableParaRowsConfig()}}}getDataOfDataType(){let t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";return[{title:"String",value:"s"},{title:"Number",value:"n"},{title:"Date",value:"d"},{title:"Boolean",value:"b"},{title:"RSA",value:"r"}].map((e=>(0,i.Z)((0,i.Z)({},e),{},{selected:e.value===t})))}getEachDataRowConfig(t,e){let a=arguments.length>2&&void 0!==arguments[2]&&arguments[2],i=[{dataFull:{config:{default:{title:this.logicState.languages.btn_save,type:"primary",class:""},cmd:{disable:!0}},dataItem:{index:e},abs_Click:this.onSaveParaServer}}];return t.isAddNewItem&&i.push({dataFull:{config:{default:{title:this.logicState.languages.btn_cancel,type:"warning",class:""},cmd:{disable:!0}},dataItem:{index:e},abs_Click:this.onCancelParameter}}),[{data:e+1},{data:t.code,isUpdate:a,abs_Change:this.table_input_change_detail,abs_Cancel:this.table_input_cancel_detail,abs_Submit:this.table_input_submit_detail,cmd:{disable:!t.isAddNewItem}},{data:t.value,isUpdate:a,abs_Change:this.table_input_change_detail,abs_Cancel:this.table_input_cancel_detail,abs_Submit:this.table_input_submit_detail,cmd:{disable:!t.isAddNewItem&&!this.logicState.isAdmin}},{data:t.des,isUpdate:a,abs_Change:this.table_input_change_detail,abs_Cancel:this.table_input_cancel_detail,abs_Submit:this.table_input_submit_detail,cmd:{disable:!t.isAddNewItem&&!this.logicState.isAdmin}},{data:this.getDataOfDataType(t.data_type),isUpdate:a,value:t.data_type,abs_Change:this.table_select_change_detail,abs_Cancel:this.onCancelParaServer,cmd:{disable:!t.isAddNewItem&&!this.logicState.isAdmin}},{data:i}]}getConfigTableParaRows(){return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).map(((t,e)=>this.getEachDataRowConfig(t,e)))}getConfigTableParaRowsConfig(){return[{type:"uTableColumnDefault",config:{mode:"center",isFrozen:!1}},{type:"uTableColumnEditInput"},{type:"uTableColumnEditInput"},{type:"uTableColumnEditInput"},{type:"uTableColumnEditSelect"},{type:"uTableColumnButton"}]}changeLanguageTemplate(t){let{stateData:e}=this.state;e.form.dataFull.config.default.title=t.title,e.form.dataFull.title_button.close_button=t.form_btn_close,e.form.dataFull.title_button.add_form=t.form_btn_add,e.form.dataFull.config.default.title_sub=t.info_des,e.add.dataFull.config.default.title=t.btn_add_new,e.table_para.dataFull.Header.data[0].title=t.stt,e.table_para.dataFull.Header.data[1].title=t.para,e.table_para.dataFull.Header.data[2].title=t.val,e.table_para.dataFull.Header.data[3].title=t.note,e.table_para.dataFull.Header.data[4].title=t.type;for(let a=0;a<e.table_para_rows.length;a++)e.table_para_rows[a][5].data[0].dataFull.config.default.title=t.btn_save,2===e.table_para_rows[a][5].data.length&&(e.table_para_rows[a][5].data[1].dataFull.config.default.title=t.btn_cancel);this.setState({stateData:e})}setLogicState(){let t=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};this.logicState=(0,i.Z)((0,i.Z)({},this.logicState),t)}componentDidMount(){l.ZP.addAppAuto(this.key_form,this,this.logicState.infoA.ofModal),l.ZP.form_addMapping(this.key_form,this.props.mapping_key)}removeData(){let t=arguments.length>1?arguments[1]:void 0;return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).filter(((e,a)=>a!==t))}render(){if("none"===this.logicState.visibility)return null;const t=this.paraServerForm;return(0,o.jsx)(t,{stateData:this.state.stateData})}}const g=r}}]);