"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[8623],{8140:(t,e,s)=>{s.d(e,{Z:()=>_});var a=s(3063),o=s(7313),i=s(5842),n=s(1896),l=s(3745),r=s(9676),g=s(5258),d=s(6417);class u extends o.Component{constructor(t){super(t),this.onLogin=()=>{let t=this.LOGIC_PASSWORD.getPasswordDecode();(0,n.Yr)([{txcode:"#sys:bo-relogin-login",input:{p:t,pin:t}}],{}).then((t=>{this.stausLogin(i.ZP.foGetData("login-status",t))}),(t=>{}))},this.abs_Change=t=>{let{dataFull:e}=this.state;e.PIN.data=this.LOGIC_PASSWORD.setPassword(t.target.value.trim()),this.setState({dataFull:e})},this.startRelogin=()=>{console.log("startRelogin"),this.setState({show:"block"},(()=>{l.ZP.quickPost([{txcode:"#sys:bo-relogin-lockToken",input:{}}],{})}))},this.LOGIC_PASSWORD=new g.y,this.prefixImage="data:image/png;base64,";let e=i.ZP.relogin_getStatus();e=e?"block":"none";let s="../rs/global/img/lock_screen.jpg";i.ZP.getParameterSystem("background_lockScreen")&&(s=i.ZP.getParameterSystem("background_lockScreen")),s=i.ZP.isImage(s)?this.prefixImage+s:s,this.USER_INFO=i.ZP.context_get("user_acc");let a="";if(this.USER_INFO.avatar&&(a=this.USER_INFO.avatar),i.ZP.isImage(a)&&""!==a){let t="data:image/png;base64,";a=a.indexOf(t)>-1?a:t+a}let o=i.ZP.relogin_loginFalseCurrent();this.state={dataFull:{status:{title:this.getStatusTitle()||"getStatusTitle"},PIN:{placeholder:this.getPINPlaceholder(),data:"",abs_Change:this.abs_Change,abs_Submit:this.onLogin},number_import:{title:this.getNumberWrongPassword(o)||"getNumberWrongPassword"},background:{value:s},avatar:{title:this.USER_INFO.user_name||"",value:a},mode:{disable:{status:!1,title:"Your screen is disabled"}}},show:e},this.flag_Unmount=!1}getStatusTitle(){var t;return null===(t=this.USER_INFO)||void 0===t?void 0:t.user_name}getPINPlaceholder(){return i.ZP.getLang("unlock_password_placeholder")}getNumberWrongPassword(t){return`${i.ZP.getLang("number_times_remaining")}: ${i.ZP.relogin_maxLoginFalse()-t}`}stausLogin(t){let{dataFull:e}=this.state;if(e.PIN.data="",this.setState({dataFull:e}),void 0!==t&&void 0!==t.status_login){if("login#127"===t.status_login)return e.number_import.title=this.getNumberWrongPassword(0),this.setState({show:"none",dataFull:e}),i.ZP.relogin_resetCount(),void i.ZP.relogin_setStatus(!1);i.ZP.relogin_up_loginFalse(),e.number_import.title=this.getNumberWrongPassword(i.ZP.relogin_loginFalseCurrent()),this.setState({reloginUserCountCurrent:i.ZP.relogin_loginFalseCurrent(),dataFull:e}),alert(i.ZP.getLang(t.status_login)),i.ZP.relogin_checkOverLoadLoginFalse()&&l.ZP.fo([{txcode:"#sys:fo-goto-pageLogin",input:{}}],{})}}componentWillUnmount(){this.flag_Unmount=!0}componentDidMount(){i.ZP.relogin_setForm(this),"L"===(0,i.TS)()&&(i.ZP.relogin_setStatus(!0),this.startRelogin())}render(){const t=(0,r.RP)("uLockScreen");return(0,d.jsx)(t,{dataFull:(0,a.Z)((0,a.Z)({},this.state.dataFull),{isShow:"none"!==this.state.show})})}}const _=u},8623:(t,e,s)=>{s.r(e),s.d(e,{default:()=>h});var a=s(7313),o=s(6381),i=s(9394),n=s(7483),l=s(3664),r=s(8140),g=s(5842),d=s(6633),u=s(6417);class _ extends a.Component{constructor(t){super(t);const e=g.ZP.context_get("user_acc"),s="Y"!==(null===e||void 0===e?void 0:e.branch_status),a="Y"!==(null===e||void 0===e?void 0:e.bank_status);console.log("user_info",e),this.additionalConfig={dataHeader:{info_server_time:{tooltip:{title_big:g.ZP.getLang("header_desktopO9_workingDate")||"Working date"},title:(0,d.Al)(e.working_date,"YYYY-MM-DDTHH:mm:ss.SSS[Z]","DD/MM/YYYY")||"16/05/2022"},info_server_branch:{tooltip:{title_status:s?g.ZP.getLang("header_desktopO9_branchClose"):g.ZP.getLang("header_desktopO9_branchOpen")},isClose:s,title:`${null===e||void 0===e?void 0:e.branch_name}`,code:`${null===e||void 0===e?void 0:e.branch_code}`},persist_info_user_add:{tooltip:{title_bold:a?`Bank ${g.ZP.getLang("header_isclose")}`:`Bank ${g.ZP.getLang("header_isopen")}`,title_big:g.ZP.context_get("user_jwebui.email")||"admin",title_sub:null===e||void 0===e?void 0:e.user_name,isClose:a}},info_user_app:{logo_app_user:"../rs/global/img/logo_shwebank.png"}}}}render(){return(0,u.jsxs)(a.Fragment,{children:[(0,u.jsx)(r.Z,{}),(0,u.jsx)(l.Z,{}),(0,u.jsx)(o.Z,{additionalConfig:this.additionalConfig}),(0,u.jsx)("div",{className:"d-flex col-12 malibu-desktop-content",children:(0,u.jsxs)("div",{className:"main",style:{width:"100%"},children:[(0,u.jsx)(n.Z,{}),(0,u.jsx)(i.Z,{})]})})]})}}const h=_}}]);