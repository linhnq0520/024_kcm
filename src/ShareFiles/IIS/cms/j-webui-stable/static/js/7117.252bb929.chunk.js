"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[7117],{7117:(t,e,a)=>{a.r(e),a.d(e,{default:()=>n});var l=a(3063),o=a(7313),i=a(5842),s=a(3745),c=a(9676),h=a(6417);let r;class g extends o.Component{constructor(t){super(t),this.changeKeyLanguage=t=>{let e={note:i.ZP.getLang("note"),title:i.ZP.getLang("roleBo_title"),des:i.ZP.getLang("roleBo_des"),role_system:i.ZP.getLang("roleSystem"),search:i.ZP.getLang("jselect_search"),all_bo:i.ZP.getLang("roleBo_allbo"),has_role:i.ZP.getLang("roleBo_hasRole"),status:i.ZP.getLang("roleBo_status"),table_status:i.ZP.getLang("status"),btn_delect:i.ZP.getLang("btnDelect"),btn_select_all:i.ZP.getLang("btnSelectAll"),btn_select:i.ZP.getLang("btnSelect")};if(void 0!==t)return e;let a=this.logicState.infoA;a.title=i.ZP.getLang("roleBo_title"),a.des=i.ZP.getLang("roleBo_des"),a.lang_form.vi=i.ZP.getLang("roleBo_title"),a.lang_form.en=i.ZP.getLang("roleBo_title"),this.logicState.languages=e,this.logicState.infoA=a,this.setLanguageTemplate()},this.onClickItemTableLeft=t=>{let e=this.logicState.data_select;void 0===e[this.logicState.role_system_select]&&(e[this.logicState.role_system_select]={}),e[this.logicState.role_system_select][t.txcode]=!1,this.logicState.txbo=this.logicState.txbo.filter((e=>e.txcode!==t.txcode)),this.logicState.all_txcode.push(t),this.logicState.data_select=e,this.actionSaveTxBo(e),this.reloadTable()},this.onClickItemTableRight=t=>{let e=this.logicState.data_select;void 0===e[this.logicState.role_system_select]&&(e[this.logicState.role_system_select]={}),e[this.logicState.role_system_select][t.txcode]=!0,this.logicState.txbo.push(t),this.logicState.all_txcode=this.logicState.all_txcode.filter((e=>e.txcode!==t.txcode)),this.logicState.data_select=e,this.actionSaveTxBo(e),this.reloadTable()},this.onChangeRole=(t,e)=>{let{stateData:a}=this.state;a.role_choose.dataFull.data=this.getConfigRoleSelect(t),a.role_choose.dataFull.input_value=this.logicState.list_role_show[e].title,this.logicState.role_system_select=t,this.changeRoleSystem(t)},this.onSearchRole=t=>{let e=t.target.value.trim(),a=[],{stateData:l}=this.state;l.role_choose.dataFull.search_value=t.target.value,a=""===e?this.logicState.list_role:this.logicState.list_role.filter((t=>i.ZP.searchPerfect(e,t.title))),this.logicState.list_role_show=a,l.role_choose.dataFull.data=this.getConfigRoleSelect(this.logicState.role_system_select),this.setState({stateData:l})},this.onSearchTableRight=(t,e)=>{let a=this.logicState.searchTextRight.filter((t=>t.code===e));if(a.length>0){let l=t.target.value;a[0].search=l.trim();let{stateData:o}=this.state,i=o.table_right.dataFull.Header.data.filter((t=>t.id===e));i.length>0&&(i[0].value_search=l,this.setState({stateData:o},(()=>{this.reloadTable(!1,!0)})))}},this.onSearchTableLeft=(t,e)=>{let a=this.logicState.searchTextLeft.filter((t=>t.code===e));if(a.length>0){let l=t.target.value;a[0].search=l.trim();let{stateData:o}=this.state,i=o.table_left.dataFull.Header.data.filter((t=>t.id===e));i.length>0&&(i[0].value_search=l,this.setState({stateData:o},(()=>{this.reloadTable(!0,!1)})))}},this.onClickSelectAll=()=>{let t=this.logicState.data_select,e=this.logicState.txbo;for(let a=0;a<this.logicState.all_txcode.length;a++){void 0===t[this.logicState.role_system_select]&&(t[this.logicState.role_system_select]={});let l=this.logicState.all_txcode[a];void 0!==l&&(t[this.logicState.role_system_select][l.txcode]=!0,e.push(l))}this.logicState.data_select=t,this.logicState.all_txcode=[],this.actionSaveTxBo(t),this.reloadTable()},this.getInfoA=()=>this.logicState.infoA,this.getKeyFormAuto=()=>this.key_form,this.callSetHidden=t=>{let{stateData:e}=this.state;e.form.dataFull.cmd.visibility=t,this.setState({stateData:e})},r=(0,c.Iq)("jwebui_roleBO"),this.key_form="roleBo";let e=this.changeKeyLanguage("start"),a=i.ZP.getData("role_system"),l=[];if(void 0!==a)for(let i=0;i<a.length;i++){let t=a[i].role_system;l[l.length]={code:t.role_system_id,title:t.role_system_name}}let o=this.props.data;void 0===o&&(o={}),this.columns=["txcode","txname","status","txtype"];let s=this.getHasRole();this.logicState={visibility:"",txbo:[],txbo_show:[],all_txcode:s,all_txcode_show:s,data_select:o,list_role:l,list_role_show:l,searchTextLeft:this.getSearchTextTable(),searchTextRight:this.getSearchTextTable(),role_system_select:l[0].code,infoA:{lang_form:{vi:e.title,en:e.title},title:e.title,des:"",openOne:"true",ofModal:!1},languages:e},this.state={invokeRerender:!1,stateData:this.getStateData(e)}}setLanguageTemplate(){let{stateData:t}=this.state,{languages:e}=this.logicState;t.form.dataFull.config.default.title=e.title,t.form.dataFull.config.default.title_sub=e.des,t.role.title=e.all_bo,t.user.title=e.has_role,t.table_right.dataFull.config.search.placeholder=e.search,t.table_right.dataFull.Header.data[2].title=e.status,t.table_right.dataFull.config.search.placeholder=e.search,t.table_left.dataFull.config.search.placeholder=e.search,t.table_left.dataFull.Header.data[2].title=e.status,t.table_left.dataFull.config.search.placeholder=e.search,t.role_choose.dataFull.config.default.search.placeholder=e.search,t.role_choose.dataFull.config.default.title=e.role_system,this.setState({stateData:t})}getSearchTextTable(){return this.columns.map((t=>({code:t,search:""})))}getConfigRoleSelect(t){return this.logicState.list_role_show.map(((e,a)=>({title:e.title,value:e.code,selected:e.code===t})))}getConfigTableLeftData(){return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).map(((t,e)=>({data:[{data:t.txcode},{data:t.txname},{data:{title:t.status,type:"A"===t.status?"success":"default"}},{data:t.txtype},{data:[{icon_item:"fa-angle-right",title:"Select",dataItem:(0,l.Z)((0,l.Z)({},t),{},{index:e}),abs_Click:this.onClickItemTableLeft}]}],config:{isCheck:!1}})))}getConfigTableRightData(){return(arguments.length>0&&void 0!==arguments[0]?arguments[0]:[]).map(((t,e)=>({data:[{data:[{icon_item:"fa-angle-left",title:"Select",dataItem:(0,l.Z)((0,l.Z)({},t),{},{index:e}),abs_Click:this.onClickItemTableRight}]},{data:t.txcode},{data:t.txname},{data:{title:t.status,type:"A"===t.status?"success":"default"}},{data:t.txtype}],config:{isCheck:!1}})))}invokeRerender(){this.setState({invokeRerender:!this.state.invokeRerender})}getStateData(t){var e;return{form:{dataFull:{config:{default:{title:t.title,title_sub:t.des}},cmd:{visibility:""}}},user:{title:t.has_role},role:{title:t.all_bo},role_choose:{dataFull:{config:{default:{title:t.role_system,type:"text",class:"col-md-2",code_form_component:"language_default",search:{placeholder:t.search}},cmd:{disable:!1,visible:!0,error:{message:"",type:""}},mode:{noTitle:!1}},data:this.getConfigRoleSelect(null===(e=this.logicState.list_role[0])||void 0===e?void 0:e.code),input_value:this.logicState.list_role[0].title,search_value:""},abs_Change:this.onChangeRole,abs_search:this.onSearchRole},preview_all:{dataFull:{config:{default:{icondouble:"keyboard_arrow_left"}}},abs_Click:this.onClickSelectAll},table_left:{dataFull:{abs_search:this.onSearchTableLeft,Header:{data:[{title:"txCode",id:"txcode",config:{isFrozen:!1}},{title:"txName",id:"txname",config:{isFrozen:!1}},{title:t.table_status,id:"status",config:{isFrozen:!1}},{title:"txType",id:"txtype",config:{isFrozen:!1}},{title:"",config:{width:"",isFrozen:!1}}],config:{mode:{hasSearch:!0,isFrozenHeader:!0}}},config:{search:{placeholder:t.search},mode:{noHeader:!1}}}},table_left_config:[{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnAction"},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnButtonHover",config:{mode:"left",isFrozen:!1}}],table_right_config:[{type:"uTableColumnButtonHover",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnAction"},{type:"uTableColumnDefault",config:{mode:"left",isFrozen:!1}},{type:"uTableColumnButtonHover",config:{mode:"left",isFrozen:!1}}],table_left_data:this.getConfigTableLeftData(this.logicState.txbo_show),table_right:{dataFull:{abs_search:this.onSearchTableRight,Header:{data:[{title:"",config:{width:"",isFrozen:!1}},{title:"txCode",id:"txcode",config:{isFrozen:!1}},{title:"txName",id:"txname",config:{isFrozen:!1}},{title:t.table_status,id:"status",config:{isFrozen:!1}},{title:"txType",id:"txtype",config:{isFrozen:!1}}],config:{mode:{hasSearch:!0,isFrozenHeader:!0}}},config:{search:{placeholder:t.search},mode:{noHeader:!1}}}},table_right_data:this.getConfigTableRightData(this.logicState.all_txcode_show)}}getHasRole(){let t=[];for(let e=0;e<this.props.all_txcode.length;e++)void 0!==this.props.all_txcode[e].hasRole&&"true"===this.props.all_txcode[e].hasRole&&(t[t.length]=this.props.all_txcode[e]);return t}changeRoleSystem(t){let e=[],a=[],l=this.getHasRole();for(let o=0;o<l.length;o++)this.hasCheckRole(t,l[o].txcode)?e[e.length]=l[o]:a[a.length]=l[o];this.logicState.all_txcode=a,this.logicState.txbo=e,this.reloadTable()}searchTable(t){return(arguments.length>1&&void 0!==arguments[1]?arguments[1]:[]).filter((e=>{let a=!0;for(let l=0;l<t.length;l++)if(!e[t[l].code].toLowerCase().includes(t[l].search.toLowerCase())){a=!1;break}return a}))}reloadTable(){let t=!(arguments.length>0&&void 0!==arguments[0])||arguments[0],e=!(arguments.length>1&&void 0!==arguments[1])||arguments[1],{stateData:a}=this.state;t&&(this.logicState.txbo_show=this.searchTable(this.logicState.searchTextLeft,this.logicState.txbo),a.table_left_data=this.getConfigTableLeftData(this.logicState.txbo_show)),e&&(this.logicState.all_txcode_show=this.searchTable(this.logicState.searchTextRight,this.logicState.all_txcode),a.table_right_data=this.getConfigTableRightData(this.logicState.all_txcode_show)),this.setState({stateData:a})}hasCheckRole(t,e){return void 0!==this.logicState.data_select&&void 0!==this.logicState.data_select[t]&&void 0!==this.logicState.data_select[t][e]&&this.logicState.data_select[t][e]}actionSaveTxBo(t){void 0!==t&&s.ZP.quickPost([{txcode:"#sys:bo-save-roleTxBo",input:{roletxbo:t}}],{})}render(){return(0,h.jsx)(r,{stateData:this.state.stateData})}componentDidMount(){i.ZP.addAppAuto(this.key_form,this,this.logicState.infoA.ofModal),i.ZP.form_addMapping(this.key_form,this.props.mapping_key),this.changeRoleSystem(this.logicState.role_system_select)}}const n=g}}]);