"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[6112],{780:(t,e,a)=>{a.d(e,{Z:()=>g});var i=a(7313),s=a(5842),n=a(2590),o=a(9676),l=a(1896),r=a(6633),d=a(6417);class c extends i.Component{constructor(t){super(t),this.loadDataMore=()=>{this.setState({dataViewCount:this.state.dataViewCount+10})},this.handelRefresh=()=>{this.setState({isLoading:!0},(()=>{const t=this.props.boLoadData;this.getDataActivityPanel(t.txcode,t.input)}))},this.data_menu=s.ZP.cloneJson(n.Z.getMenu(1))||[],this.type_screen="jActivityPanel",this.state={isLoading:!0,data:[],dataViewCount:10,lastUpdate:"--"}}getTimeActive(t){let e=t.activePanelDate,a=t.activePanelTime;return(0,r.FW)(e,"DD/MM/YYYY")+" "+a}getDataActivityPanel(t,e){const a=[{txcode:t,input:e}];(0,l.Yr)(a,{}).then((t=>{var e=s.ZP.foGetData("data",t)||[];let a=[];for(const i of e)a.push({cmd:this.props.getCMD(i),dataItem:i,img:i.activePanelImg,title_bold:i.activePanelBold,title:i.activePanelTitle,time:this.getTimeActive(i),table_more:{header:{dataFull:{Header:{data:i.activePanelFistColumn.map((t=>({title:t,config:{width:""}})))}}},data:i.activePanelSecondColumn.map((t=>({data:t}))),config_row:i.activePanelFistColumn.map((t=>({type:"uTableColumnDefault"})))}});this.setState({data:a,isLoading:!1,lastUpdate:(0,r.FW)((new Date).getTime(),"DD/MM/YYYY HH:mm:ss")})}))}componentDidMount(){const t=this.props.boLoadData;this.getDataActivityPanel(t.txcode,t.input),s.ZP.addScreen(this)}getDataFullTemplate(){const{isLoading:t,lastUpdate:e,dataViewCount:a}=this.state;return{abs_Click:this.props.handelClick,abs_autoCallBackData:this.loadDataMore,cmd:{visibility:this.props.activityVisible,isLoading:t},title:{number_new_notification:0,btn_show:s.ZP.getLang("cpn_jActivityPanel_title_btn_show"),btn_hide:s.ZP.getLang("cpn_jActivityPanel_title_btn_hide"),title_panel:s.ZP.getLang("cpn_jActivityPanel_title_title_panel"),title_header:s.ZP.getLang("cpn_jActivityPanel_title_title_header")},last_update:{title:s.ZP.getLang("cpn_jActivityPanel_lastUpdate_title"),date:e},btn_refresh:{dataFull:{config:{default:{title:s.ZP.getLang("cpn_jActivityPanel_btnRefresh_title"),icon:"cached",type:"primary"},cmd:{disable:t}},abs_Click:this.handelRefresh}},data:this.state.data.slice(0,a)}}render(){const t=(0,o.RP)("uActivity");return(0,d.jsx)(t,{dataFull:this.getDataFullTemplate()})}}const g=c},8140:(t,e,a)=>{a.d(e,{Z:()=>u});var i=a(3063),s=a(7313),n=a(5842),o=a(1896),l=a(3745),r=a(9676),d=a(5258),c=a(6417);class g extends s.Component{constructor(t){super(t),this.onLogin=()=>{let t=this.LOGIC_PASSWORD.getPasswordDecode();(0,o.Yr)([{txcode:"#sys:bo-relogin-login",input:{p:t,pin:t}}],{}).then((t=>{this.stausLogin(n.ZP.foGetData("login-status",t))}),(t=>{}))},this.abs_Change=t=>{let{dataFull:e}=this.state;e.PIN.data=this.LOGIC_PASSWORD.setPassword(t.target.value.trim()),this.setState({dataFull:e})},this.startRelogin=()=>{console.log("startRelogin"),this.setState({show:"block"},(()=>{l.ZP.quickPost([{txcode:"#sys:bo-relogin-lockToken",input:{}}],{})}))},this.LOGIC_PASSWORD=new d.y,this.prefixImage="data:image/png;base64,";let e=n.ZP.relogin_getStatus();e=e?"block":"none";let a="../rs/global/img/lock_screen.jpg";n.ZP.getParameterSystem("background_lockScreen")&&(a=n.ZP.getParameterSystem("background_lockScreen")),a=n.ZP.isImage(a)?this.prefixImage+a:a,this.USER_INFO=n.ZP.context_get("user_acc");let i="";if(this.USER_INFO.avatar&&(i=this.USER_INFO.avatar),n.ZP.isImage(i)&&""!==i){let t="data:image/png;base64,";i=i.indexOf(t)>-1?i:t+i}let s=n.ZP.relogin_loginFalseCurrent();this.state={dataFull:{status:{title:this.getStatusTitle()||"getStatusTitle"},PIN:{placeholder:this.getPINPlaceholder(),data:"",abs_Change:this.abs_Change,abs_Submit:this.onLogin},number_import:{title:this.getNumberWrongPassword(s)||"getNumberWrongPassword"},background:{value:a},avatar:{title:this.USER_INFO.user_name||"",value:i},mode:{disable:{status:!1,title:"Your screen is disabled"}}},show:e},this.flag_Unmount=!1}getStatusTitle(){var t;return null===(t=this.USER_INFO)||void 0===t?void 0:t.user_name}getPINPlaceholder(){return n.ZP.getLang("unlock_password_placeholder")}getNumberWrongPassword(t){return`${n.ZP.getLang("number_times_remaining")}: ${n.ZP.relogin_maxLoginFalse()-t}`}stausLogin(t){let{dataFull:e}=this.state;if(e.PIN.data="",this.setState({dataFull:e}),void 0!==t&&void 0!==t.status_login){if("login#127"===t.status_login)return e.number_import.title=this.getNumberWrongPassword(0),this.setState({show:"none",dataFull:e}),n.ZP.relogin_resetCount(),void n.ZP.relogin_setStatus(!1);n.ZP.relogin_up_loginFalse(),e.number_import.title=this.getNumberWrongPassword(n.ZP.relogin_loginFalseCurrent()),this.setState({reloginUserCountCurrent:n.ZP.relogin_loginFalseCurrent(),dataFull:e}),alert(n.ZP.getLang(t.status_login)),n.ZP.relogin_checkOverLoadLoginFalse()&&l.ZP.fo([{txcode:"#sys:fo-goto-pageLogin",input:{}}],{})}}componentWillUnmount(){this.flag_Unmount=!0}componentDidMount(){n.ZP.relogin_setForm(this),"L"===(0,n.TS)()&&(n.ZP.relogin_setStatus(!0),this.startRelogin())}render(){const t=(0,r.RP)("uLockScreen");return(0,c.jsx)(t,{dataFull:(0,i.Z)((0,i.Z)({},this.state.dataFull),{isShow:"none"!==this.state.show})})}}const u=g},6112:(t,e,a)=>{a.r(e),a.d(e,{default:()=>P});var i=a(3063),s=a(7313),n=a(6381),o=a(9394),l=a(7483),r=a(780),d=a(3664),c=a(8140),g=a(5842),u=a(6633),h=a(1896),_=a(9676),p=a(6417);class m extends s.Component{constructor(t){super(t);let e=g.ZP.context_get("user_acc"),a=g.ZP.getParameterSystem("DATE_FORMAT");const i="Y"!==e.branchstatus,s="Y"!==e.bankstatus;this.additionalConfig={dataHeader:{info_server_time:{tooltip:{title_big:g.ZP.getLang("header_desktopO9_workingDate")},title:(0,u.FW)(null===e||void 0===e?void 0:e.workingdate,a)},info_server_branch:{tooltip:{title_status:i?g.ZP.getLang("header_desktopO9_branchClose"):g.ZP.getLang("header_desktopO9_branchOpen")},isClose:i,title:`${null===e||void 0===e?void 0:e.branchname}`,code:`${null===e||void 0===e?void 0:e.branchcode}`},persist_info_user_add:{tooltip:{title_bold:s?`Bank ${g.ZP.getLang("header_isclose")}`:`Bank ${g.ZP.getLang("header_isopen")}`,title_big:g.ZP.context_get("user_jwebui.email"),title_sub:null===e||void 0===e?void 0:e.usrname,isClose:s}}}},this.ACTIVE_PANEL={boLoadData:{txcode:"bo-getData-activePanel",input:{learn_api:"O9_GET_DATA_ACTIVE_PANEL"}},handelClick:t=>{(0,h.Yr)([{txcode:"#sys:bo-view-dataAPIO9_F8",input:{table_code:"fof_transaction_journal",table_col_key:"",form_key:"@{a.b}",learn_api:"fof_transaction_journal_search_view_get_api_journal_txrefid",fof_transaction_journal:t}}],{})},getCMD:t=>({disable:!g.ZP.checkHasRoleForm("FO_"+t.txcode)})},this.state={isHoverDev:!1}}render(){return(0,p.jsxs)(s.Fragment,{children:[(0,p.jsx)(c.Z,{}),(0,p.jsx)(d.Z,{}),(0,p.jsx)(n.Z,{additionalConfig:this.additionalConfig}),(0,p.jsx)("div",{className:"d-flex col-12 malibu-desktop-content",children:(0,p.jsxs)("div",{className:"main-activity",style:{width:"100%"},children:[(0,p.jsxs)("div",{className:"col",style:{width:"calc(100% - 294px)"},children:[(0,p.jsx)(l.Z,{}),(0,p.jsx)(o.Z,{})]}),!g.ZP.checkIsPublic()&&(0,p.jsxs)("div",{style:{display:"none",position:"fixed",bottom:"20px",left:this.state.isHoverDev?"calc(50vw - 105px)":"calc(50vw - 16px)"},onMouseEnter:()=>{this.setState({isHoverDev:!0})},onMouseLeave:()=>{this.setState({isHoverDev:!1})},children:[(0,p.jsxs)("div",{className:"row",style:{display:this.state.isHoverDev?"":"none"},children:[(0,p.jsx)("div",{style:{width:"50px",height:"50px",background:"#01A6E6",borderRadius:"50%",cursor:"pointer",margin:"10px"},onClick:()=>{(0,_.sX)("krungthai")}}),(0,p.jsx)("div",{style:{width:"50px",height:"50px",background:"#5557E4",borderRadius:"50%",cursor:"pointer",margin:"10px"},onClick:()=>{(0,_.sX)("Majorelle_Blue")}}),(0,p.jsx)("div",{onClick:()=>{(0,_.sX)("Green_Pigment")},style:{width:"50px",height:"50px",background:"#00A950",borderRadius:"50%",cursor:"pointer",margin:"10px"}})]}),(0,p.jsx)("div",{style:{textAlign:"center",width:"max-content",margin:"auto"},children:(0,p.jsx)("i",{className:"material-icons",style:{width:"32px",height:"32px",borderRadius:"50%",border:"1px solid",textAlign:"center",fontSize:"30px",cursor:"pointer"},children:"more_horiz"})})]}),(0,p.jsx)(r.Z,(0,i.Z)({},this.ACTIVE_PANEL))]})})]})}}const P=m}}]);