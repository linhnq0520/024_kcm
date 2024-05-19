"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[8931],{8931:(e,t,a)=>{a.r(t),a.d(t,{default:()=>n});var l=a(3063),s=a(7313),i=a(5842),r=a(3745),h=a(9676),o=a(6417);class c extends s.Component{constructor(e){super(e),this.getUsersNotInRole=function(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:[];if(void 0===t||0===t.length)return e;{let a=[];return e.forEach((e=>{t.includes(e.user.user_id)||a.push(e)})),a}},this.getUsersInRole=function(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],t=arguments.length>1&&void 0!==arguments[1]?arguments[1]:[];if(void 0===t||0===t.length)return[];{let a=[];return e.forEach((e=>{t.includes(e.user.user_id)&&a.push(e)})),a}},this.checkDataLeftHandler=e=>{if(e.index>=0){let t=this.tableKey.left;this.checkOneItemTableHandler(e.index,t.tableKey,t.tableDataKey,t.mappingKeyToIndex.check,t.usersKey,t.checkedUsersNumberKey)}},this.checkOneItemTableHandler=(e,t,a,l,s,i)=>{let r,{stateData:h,number_check_left:o,number_check_right:c}=this.state,n=h[a][e].data[l].value,g=this.logicState[s].length;h[a][e].data[l].value=!n,h[a][e].config.isCheck=!n,"table_left_data"===a?!0===!n?o++:o--:"table_right_data"===a&&(!0===!n?c++:c--),this.setState({stateData:h,number_check_left:o,number_check_right:c}),this.logicState[i]=n?this.logicState[i]-1:this.logicState[i]+1,0===this.logicState[i]?r=!1:this.logicState[i]===g?r=!0:this.logicState[i]<g&&(r="-"),this.setValueCheckboxHeader(t,l,r)},this.setValueCheckboxHeader=(e,t,a)=>{let{stateData:l}=this.state;l[e].dataFull.Header.data[t].data.value=a,this.setState({stateData:l})},this.getCheckboxHeaderValue=(e,t)=>this.state.stateData[e].dataFull.Header.data[t].data.value,this.checkDataRightHandler=e=>{if(e.index>=0){let t=this.tableKey.right;this.checkOneItemTableHandler(e.index,t.tableKey,t.tableDataKey,t.mappingKeyToIndex.check,t.usersKey,t.checkedUsersNumberKey)}},this.checkAllLeftDataHandler=()=>{let e=this.tableKey.left;this.checkAllHandler(e.mappingKeyToIndex.check,e.tableKey,e.tableDataKey,e.usersKey,e.checkedUsersNumberKey)},this.checkAllHandler=(e,t,a,l,s)=>{let{stateData:i}=this.state,r=!0!==this.getCheckboxHeaderValue(t,e);for(let h=0;h<i[a].length;h++)i[a][h].data[e].value=r,i[a][h].config.isCheck=r;this.logicState[s]=r?this.logicState[l].length:0,i[t].dataFull.Header.data[e].data.value=r,this.setState({stateData:i})},this.checkAllRightDataHandler=()=>{let e=this.tableKey.right;this.checkAllHandler(e.mappingKeyToIndex.check,e.tableKey,e.tableDataKey,e.usersKey,e.checkedUsersNumberKey)},this.clickRemoveSelectedUsersHandler=(e,t)=>{let a=this.getSelectedUsers(this.tableKey.right);if(a.length>0){this.logicState.usersLeftTable=this.logicState.usersLeftTable.concat(a),this.logicState.usersRightTable=this.getUnselectedUsers(this.tableKey.right),this.logicState.usersSearchData=this.logicState.usersLeftTable,this.uncheckAllTableData(),this.user_change=a;let{stateData:e}=this.state;e.table_left_data=this.getUsersLeftTableConfig(this.logicState.usersLeftTable),e.table_right_data=this.getUsersRightTableConfig(this.logicState.usersRightTable),this.setState({stateData:e}),this.autoSaveRole(this.logicState.usersRightTable)}},this.clickRemoveAllUsersHander=(e,t)=>{let a=this.logicState.usersRightTable;if(a.length>0){this.logicState.usersLeftTable=this.logicState.usersLeftTable.concat(this.logicState.usersRightTable),this.logicState.usersRightTable=[],this.logicState.usersSearchData=this.logicState.usersLeftTable,this.uncheckAllTableData(),this.user_change=a;let{stateData:e,number_check_right:t,number_check_left:l}=this.state;e.table_left_data=this.getUsersLeftTableConfig(this.logicState.usersLeftTable),e.table_right_data=this.getUsersRightTableConfig(this.logicState.usersRightTable),l=0,t=0,this.setState({stateData:e,number_check_right:t,number_check_left:l}),this.autoSaveRole(this.logicState.usersRightTable)}},this.clickAddSelectedUsersHandler=(e,t)=>{let a=this.getSelectedUsers(this.tableKey.left);if(a.length>0){this.logicState.usersRightTable=this.logicState.usersRightTable.concat(a),this.logicState.usersLeftTable=this.getUnselectedUsers(this.tableKey.left),this.logicState.usersSearchData=this.logicState.usersLeftTable,this.uncheckAllTableData(),this.user_change=a;let{stateData:e,number_check_left:t,number_check_right:l}=this.state;e.table_left_data=this.getUsersLeftTableConfig(this.logicState.usersLeftTable),e.table_right_data=this.getUsersRightTableConfig(this.logicState.usersRightTable),t=0,l=0,this.setState({stateData:e,number_check_left:t,number_check_right:l}),this.autoSaveRole(this.logicState.usersRightTable)}},this.clickAddAllUsersHander=(e,t)=>{let a=this.logicState.usersLeftTable;if(a.length>0){this.logicState.usersRightTable=this.logicState.usersRightTable.concat(this.logicState.usersLeftTable),this.logicState.usersLeftTable=[],this.logicState.usersSearchData=[],this.uncheckAllTableData(),this.user_change=a;let{stateData:e,number_check_left:t,number_check_right:l}=this.state;e.table_left_data=this.getUsersLeftTableConfig(this.logicState.usersLeftTable),e.table_right_data=this.getUsersRightTableConfig(this.logicState.usersRightTable),t=0,l=0,this.setState({stateData:e,number_check_left:t,number_check_right:l}),this.autoSaveRole(this.logicState.usersRightTable)}},this.onSearchDropdown=e=>{let t=e.target.value.trim(),a=[],{stateData:l}=this.state;l.role_choose.dataFull.search_value=t,a=""===t?this.logicState.role_system:this.logicState.role_system.filter((e=>{let a=e.role_system.role_system_name;return i.ZP.searchPerfect(t,a)})),l.role_choose.dataFull.data=this.getDataSelectItem(a,this.selectedRoleId),this.setState({stateData:l})},this.searchUserHandler=e=>{let t=e.target.value,{stateData:a}=this.state;if(""!==t.trim()){let e=this.logicState.usersSearchData,l=[];for(let a=0;a<e.length;a++){let s="";for(let t in e[a])for(let l in e[a][t])"full_name"!==l&&"email"!==l||(s+=e[a][t][l]+" ");s.toLowerCase().includes(t.toLowerCase())&&(l[l.length]=e[a])}this.logicState.usersLeftTable=l,a.table_left_data=this.getUsersLeftTableConfig(this.logicState.usersLeftTable)}else{let e=this.role_all[this.selectedRoleId],t=[];for(let a=0;a<this.logicState.allUsers.length;a++)this.checkUserHasSelect_for_changeRole(this.logicState.allUsers[a].user.user_id,e)&&(t[t.length]=this.logicState.allUsers[a]);this.logicState.usersLeftTable=t,this.logicState.usersSearchData=t,a.table_left_data=this.getUsersLeftTableConfig(t)}this.setState({stateData:a})},this.changeKeyLanguage=e=>{let t={note:i.ZP.getLang("note"),title_:i.ZP.getLang("roleUser_title"),des_:i.ZP.getLang("roleUser_des"),user:i.ZP.getLang("roleUser_user"),search:i.ZP.getLang("roleUser_search"),stt:i.ZP.getLang("stt"),user_has_no_role:i.ZP.getLang("roleUser_userHasNoRole"),double_click_to_move:i.ZP.getLang("roleUser_doubleClickToMove"),full_name:i.ZP.getLang("roleUser_fullName"),status:i.ZP.getLang("roleUser_status"),role:i.ZP.getLang("roleUser_role"),user_belongs_to_the_role:i.ZP.getLang("roleUser_userBelongsToTheRole"),form_btn_close:i.ZP.getLang("form_close_title"),form_btn_add:i.ZP.getLang("form_add_title")};if(void 0!==e)return t;let a=this.logicState.infoA;a.title=i.ZP.getLang("roleUser_title"),a.des=i.ZP.getLang("roleUser_des"),a.lang_form.vi=i.ZP.getLang("roleUser_title"),a.lang_form.en=i.ZP.getLang("roleUser_title"),this.setLogicState({languages:t,infoA:a}),this.changeLanguageTemplate(t)},this.onChangeValueSelect=(e,t,a)=>{this.selectedRoleId=e;let l=[],s=[];void 0!==this.role_all[this.selectedRoleId]?(l=this.getUsersInRole(this.logicState.allUsers,this.role_all[e]),s=this.getUsersNotInRole(this.logicState.allUsers,this.role_all[e])):s=this.logicState.allUsers,this.logicState.usersLeftTable=s,this.logicState.usersRightTable=l;let{stateData:i,number_check_right:r,number_check_left:h}=this.state;i.table_left_data=this.getUsersLeftTableConfig(s),i.table_right_data=this.getUsersRightTableConfig(l);let o=i.role_choose.dataFull.data.filter((e=>!0===e.selected));o.length>0&&(o[0].selected=!1);let c=i.role_choose.dataFull.data.filter(((e,a)=>a===t));c.length>0&&(i.role_choose.dataFull.input_value=c[0].title,c[0].selected=!0),h=0,r=0,this.setState({stateData:i,number_check_left:h,number_check_right:r}),this.logicState.usersSearchData=s,this.uncheckAllTableData()},this.getInfoA=()=>this.logicState.infoA,this.getKeyFormAuto=()=>this.key_form,this.callSetHidden=e=>{this.setLogicState({visibility:e}),this.setState({invokeReload:!this.state.invokeReload})},this.closeForm=()=>{i.ZP.removeForm(this.key_form)},this.key_form="roleUser";let t=this.changeKeyLanguage("start"),a=i.ZP.getData("user");this.roleUserForm=(0,h.Iq)("jwebui_roleUser");let l=i.ZP.getData("role_system");this.selectedRoleId=void 0!==l&&l.length>0?l[0].role_system.role_system_id:"",this.tableKey={left:{mappingKeyToIndex:{check:1},tableKey:"table_left",tableDataKey:"table_left_data",usersKey:"usersLeftTable",checkedUsersNumberKey:"checkedLeftTableNumber"},right:{mappingKeyToIndex:{check:1},tableKey:"table_right",tableDataKey:"table_right_data",usersKey:"usersRightTable",checkedUsersNumberKey:"checkedRightTableNumber"}};let s=this.getUsersNotInRole(a,this.props.data[this.selectedRoleId]);this.logicState={checkedLeftTableNumber:0,checkedRightTableNumber:0,usersSearchData:s,allUsers:a,usersLeftTable:s,usersRightTable:this.getUsersInRole(a,this.props.data[this.selectedRoleId]),role_system:l,data:[],visibility:"",infoA:{lang_form:{vi:i.ZP.getLang("roleUser_title"),en:i.ZP.getLang("roleUser_title")},title:"Permissions And Users",des:"Quan h\u1ec7 gi\u1eefa quy\u1ec1n truy c\u1eadp v\xe0 ng\u01b0\u1eddi d\xf9ng!",openOne:"true",ofModal:!1},languages:t},this.state={invokeReload:!1,number_check_left:0,number_check_right:0,stateData:this.getConfigTemplate(this.logicState.role_system,this.logicState.usersLeftTable,this.logicState.usersRightTable)},this.role_all=this.props.data,this.user_change=[]}getUsersLeftTableConfig(){return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).map(((e,t)=>({data:[{data:t+1},{value:!1,dataItem:{index:t},abs_Click:this.checkDataLeftHandler},{data:e.user.full_name},{data:e.user.email}],config:{isCheck:!1}})))}getUsersRightTableConfig(){return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).map(((e,t)=>({data:[{data:t+1},{value:!1,dataItem:{index:t},abs_Click:this.checkDataRightHandler},{data:e.user.full_name}],config:{isCheck:!1}})))}getDataSelectItem(e,t){return e.map(((e,a)=>({title:e.role_system.role_system_name,value:e.role_system.role_system_id,selected:t===e.role_system.role_system_id})))}getConfigTemplate(){var e,t,a,l;let s=arguments.length>0&&void 0!==arguments[0]?arguments[0]:[],i=arguments.length>1&&void 0!==arguments[1]?arguments[1]:[],r=arguments.length>2&&void 0!==arguments[2]?arguments[2]:[],{languages:h}=this.logicState;return{form:{dataFull:{config:{default:{title:h.title_,title_sub:h.des_,icon:"folder"}},title_button:{close_button:h.form_btn_close,add_form:h.form_btn_add},mode:{form_min:!1},list_button_on_header:[],cmd:{visibility:"",isLoading:!1,isFavorite:!1},abs_Close:this.closeForm,abs_AddMenuBar:this.addMenu}},role:{title:h.role},user:{title:h.user},role_choose:{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No result",title:"",type:"text",class:"col-md-12",code_form_component:"role_choose"},cmd:{disable:!1,visible:!0,error:{message:"",type:""}},mode:{noTitle:!0}},data:this.getDataSelectItem(s,null===(e=s[0])||void 0===e?void 0:e.role_system.role_system_id),input_value:null===(t=s[0])||void 0===t?void 0:t.role_system.role_system_name,search_value:""},abs_Change:this.onChangeValueSelect,abs_search:this.onSearchDropdown},search:{placeholder:h.search,abs_search:this.searchUserHandler},preview:{dataFull:{config:{default:{title:(null===(a=this.state)||void 0===a?void 0:a.number_check_right)||"0",type:"",icon:"keyboard_arrow_left"}}},abs_Click:this.clickRemoveSelectedUsersHandler},preview_all:{dataFull:{config:{default:{title:"0",icondouble:"keyboard_arrow_left"}}},abs_Click:this.clickRemoveAllUsersHander},next_all:{dataFull:{config:{default:{title:i.length,type:"",icondouble:"keyboard_arrow_right"},mode:{isReverse:!0}}},abs_Click:this.clickAddAllUsersHander},next:{dataFull:{config:{default:{title:(null===(l=this.state)||void 0===l?void 0:l.number_check_left)||"0",type:"",icon:"keyboard_arrow_right"},mode:{isReverse:!0}}},abs_Click:this.clickAddSelectedUsersHandler},table_left:{dataFull:{Header:{data:[{title:h.stt,config:{width:"50px",isFrozen:!1}},{title:"",data:{value:!1,abs_Click:this.checkAllLeftDataHandler},config:{hasCheck:!0,width:"",isFrozen:!1}},{title:h.full_name,config:{width:"",isFrozen:!1}},{title:"Email",config:{width:"",isFrozen:!1}}],config:{mode:{hasSearch:!1,isFrozenHeader:!0}}},config:{mode:{noHeader:!1}}}},table_left_config:[{type:"uTableColumnDefault",config:{mode:"center",isFrozen:!1}},{type:"uTableColumnCheckbox"},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnAction"}],table_left_data:this.getUsersLeftTableConfig(i),table_right:{dataFull:{Header:{data:[{title:h.stt,config:{width:"50px",isFrozen:!1}},{title:"",data:{value:!1,abs_Click:this.checkAllRightDataHandler},config:{hasCheck:!0,width:"",isFrozen:!1}},{title:h.full_name,config:{width:"",isFrozen:!1}}],config:{mode:{hasSearch:!1,isFrozenHeader:!0}}},config:{mode:{noHeader:!1}}}},table_right_config:[{type:"uTableColumnDefault",config:{mode:"center",isFrozen:!1}},{type:"uTableColumnCheckbox"},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnAction"}],table_right_data:this.getUsersRightTableConfig(r)}}setLogicState(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:{};this.logicState=(0,l.Z)((0,l.Z)({},this.logicState),e)}uncheckAllTableData(){this.logicState.checkedRightTableNumber=0,this.logicState.checkedLeftTableNumber=0,this.setValueCheckboxHeader(this.tableKey.left.tableKey,this.tableKey.left.mappingKeyToIndex.check,!1),this.setValueCheckboxHeader(this.tableKey.right.tableKey,this.tableKey.right.mappingKeyToIndex.check,!1)}getSelectedUsers(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:this.tableKey.left,t=[];return this.state.stateData[e.tableDataKey].forEach(((a,l)=>{!0===a.config.isCheck&&t.push(this.logicState[e.usersKey][l])})),t}getUnselectedUsers(){let e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:this.tableKey.left,t=[];return this.state.stateData[e.tableDataKey].forEach(((a,l)=>{!1===a.config.isCheck&&t.push(this.logicState[e.usersKey][l])})),t}changeLanguageTemplate(e){let{stateData:t}=this.state;t.form.dataFull.config.default.title=e.title_,t.form.dataFull.config.default.title_sub=e.des_,t.form.dataFull.title_button.close_button=e.form_btn_close,t.form.dataFull.title_button.add_form=e.form_btn_add,t.search.placeholder=e.search,t.role.title=e.role,t.user.title=e.user,t.table_left.dataFull.Header.data[0].title=e.stt,t.table_left.dataFull.Header.data[2].title=e.full_name,t.table_left.dataFull.Header.data[4].title=e.status,t.table_right.dataFull.Header.data[0].title=e.stt,t.table_right.dataFull.Header.data[2].title=e.full_name,t.table_right.dataFull.Header.data[3].title=e.status,this.setState({stateData:t})}checkUserHasSelect_for_changeRole(e,t){for(let a=0;a<t.length;a++)if(t[a]===e)return!1;return!0}autoSaveRole(e){let t=e.map((e=>e.user.user_id));this.role_all[this.selectedRoleId]=t;let a=[];for(let l=0;l<this.user_change.length;l++){let e=[],t=this.user_change[l].user.user_id;for(let a in this.role_all)this.role_all[a].includes(t)&&(e[e.length]=a);let s={};s.user_id=t,s.role=JSON.stringify(e),a[a.length]=s}r.ZP.quickPost([{txcode:"#sys:bo-save-roleUser",input:{list_user_role:a,role_user_all:JSON.stringify(this.role_all)}}],{}),this.user_change=[]}checkData(e,t){for(let a=0;a<t.length;a++)if(void 0!==t[a].user&&t[a].user.user_id===e)return!1;return!0}checkUserHasSelect_OOP(e,t){for(let a=0;a<t.length;a++)if(t[a].user.user_id===e)return!1;return!0}render(){if("none"===this.logicState.visibility)return null;const e=this.roleUserForm;return(0,o.jsx)(e,{stateData:this.state.stateData})}componentDidMount(){i.ZP.addAppAuto(this.key_form,this,this.logicState.infoA.ofModal),i.ZP.form_addMapping(this.key_form,this.props.mapping_key)}componentDidUpdate(){let{stateData:e}=this.state;e.next_all.dataFull.config.default.title===this.logicState.usersLeftTable.length&&e.preview_all.dataFull.config.default.title===this.logicState.usersRightTable.length&&e.next.dataFull.config.default.title===this.state.number_check_left&&e.preview.dataFull.config.default.title===this.state.number_check_right||(e.next_all.dataFull.config.default.title=this.logicState.usersLeftTable.length,e.preview_all.dataFull.config.default.title=this.logicState.usersRightTable.length,e.next.dataFull.config.default.title=this.state.number_check_left,e.preview.dataFull.config.default.title=this.state.number_check_right,this.setState({stateData:e}))}}const n=c}}]);