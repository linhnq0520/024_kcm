"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[3926],{3926:(t,e,a)=>{a.r(e),a.d(e,{default:()=>g});var i=a(7313),l=a(5842),s=a(1896),o=a(9676),_=a(6417);const n=(0,o.Iq)("jwebui_MyDevice");class d extends i.Component{constructor(t){super(t),this.getInfoA=()=>this.stateHidden.infoA,this.getKeyFormAuto=()=>this.key_form,this.callSetHidden=t=>{this.stateHidden.visibility=t,this.setState({reload:!0})},this.changeKeyLanguage=t=>{let e={note:l.ZP.getLang("note"),title:l.ZP.getLang("myDevice_title"),des:l.ZP.getLang("myDevice_des"),stt:l.ZP.getLang("stt"),logout:l.ZP.getLang("device_action"),where_logged_in:l.ZP.getLang("device_where_logged_in"),logout_all_app:l.ZP.getLang("device_logout_all_app"),logout_all_ssn:l.ZP.getLang("device_logout_all_ssn"),see_more:l.ZP.getLang("see_more"),form_btn_close:l.ZP.getLang("form_close_title"),form_btn_add:l.ZP.getLang("form_add_title")};if(void 0!==t)return e;let a=this.stateHidden.infoA;a.title=l.ZP.getLang("myDevice_title"),a.des=l.ZP.getLang("myDevice_des"),a.lang_form.vi=l.ZP.getLang("myDevice_title"),a.lang_form.en=l.ZP.getLang("myDevice_title"),this.stateHidden.infoA=a,this.stateHidden.languages=e,this.changeLanguageTemplate(e)},this.abs_click_logout_all_app=t=>{let e=this.stateHidden.user_info;this.state.stateData.data_device.tab.forEach(((t,a)=>{t.id!==(0,l.Py)()&&this.logout_app(t.id,e)})),this.logout_app((0,l.Py)(),e)},this.abs_Click_logout_session=(t,e,a)=>{var i,o;const _=(null===(i=this.list_app_data.find((t=>t.list_application.list_appliaction_id===this.state.tab_choose)))||void 0===i||null===(o=i.list_application)||void 0===o?void 0:o.list_application_bo_logout)||"#sys:bo-delete-session";(0,s.Yr)([{txcode:_,input:{token_webui:e.token_webui}}],{}).then((t=>{var e=this.state.stateData,a=l.ZP.foGetData("device",t);let i=this.convertDataTemplate(a);e.data_device=i,this.setState({stateData:e},(()=>{}))}),(t=>{}))},this.abs_click_logout_app=()=>{let t=this.stateHidden.user_info;this.logout_app(this.state.tab_choose,t)},this.logout_app=(t,e)=>{var a,i;const o=(null===(a=this.list_app_data.find((e=>e.list_application.list_appliaction_id===t)))||void 0===a||null===(i=a.list_application)||void 0===i?void 0:i.list_application_bo_logout_all)||"#sys:bo-logout-all-default";(0,s.Yr)([{txcode:o,input:{user_id:e.user_id,logout_app:t}}],{}).then((t=>{var e=this.state.stateData,a=l.ZP.foGetData("device",t);let i=this.convertDataTemplate(a);e.data_device=i,this.abs_select(void 0,(0,l.Py)()),this.setState({stateData:e})}),(t=>{}))},this.closeForm=()=>{l.ZP.removeForm(this.key_form)},this.abs_select=(t,e)=>{let a=this.state.stateData;a.data_device.tab.forEach((t=>{t.sysStyle={show:t.id===e?"show":""}})),this.setState({tab_choose:e,stateData:a})},this.convertDataTemplate=t=>{let e={tab:[]},a=(0,l.Py)();e.tab.push({id:a,title:""});for(const i in t){let l=Object.values(t[i]);l.length>0&&(i!==a?e.tab.push({id:i,title:i+`(${l.length})`}):e.tab[0]={id:i,title:i+`(${l.length})`,sysStyle:{show:"show"}},e.abs_select=this.abs_select,e[i]={abs_click_logout_app:this.abs_click_logout_app,data:l.filter((t=>null!==t.info)).map((t=>{let e=JSON.parse(t.info),a=e.my_ip;return null===a&&void 0===a||(a=a.replace("::ffff:","")),{title_main:`Token: ${t.token_webui}`,title_OFD:"",description:`${a} | ${e.osVersion} | ${e.browser} | Logined : ${t.logined}`,widget:this.getDeviceStatus(t.status),dataItem:t,abs_Click:this.abs_Click_logout_session}}))},e[i].data=e[i].data.sort(((t,e)=>e.dataItem.logined-t.dataItem.logined)),l[0]&&(this.stateHidden.user_info=l[0]))}return e},this.key_form="myDevice";let e=this.changeKeyLanguage("start");this.stateHidden={languages:e,infoA:{lang_form:{vi:l.ZP.getLang("myDevice_title"),en:l.ZP.getLang("myDevice_title")},title:l.ZP.getLang("myDevice_title"),des:"Ki\u1ec3m so\xe1t c\xe1c thi\u1ebft b\u1ecb \u0111\xe3 \u0111\u0103ng nh\u1eadp!",openOne:"true",ofModal:!1},visibility:!1,user_info:{}},this.list_app_data={},this.state={tab_choose:(0,l.Py)(),stateData:{form:{dataFull:{config:{default:{title:e.title,title_sub:e.des,icon:"devices_other"}},title_button:{close_button:e.form_btn_close,add_form:e.form_btn_add},mode:{form_min:!1},list_button_on_header:[{dataFull:{config:{default:{title:e.logout_all_app,type:"primary"}},abs_Click:this.abs_click_logout_all_app}}],cmd:{visibility:"",isLoading:!1,isFavorite:!1},abs_Close:this.closeForm,abs_AddMenuBar:this.addMenu}},dataFull:{where_logged_in:e.where_logged_in,log_out_of_all_application:e.logout_all_app,log_out_all_sessions:e.logout_all_ssn,log_out:e.logout,see_more:e.see_more},table:{Header:{data:[{title:"No.",id:"1",config:{width:"20px"}},{title:"Parameter title",id:"2"},{title:"Value",id:"3"},{title:"Note",id:"4"},{title:"Data type",id:"5"},{title:"",id:"6"}]},config:{mode:{noHeader:!0}}},data_device:this.convertDataTemplate(this.props.data),logout_all_app:{data_item:this.stateHidden.user_info,abs_click:this.abs_click_logout_all_app}}}}componentDidMount(){(0,s.Yr)([{txcode:"#sys:bo-projectLogin-listApplication",input:{}}],{}).then((t=>{var e=l.ZP.foGetData("list_application",t);this.list_app_data=e})),l.ZP.addAppAuto(this.key_form,this,this.stateHidden.infoA.ofModal),l.ZP.form_addMapping(this.key_form,this.props.mapping_key)}changeLanguageTemplate(t){let{stateData:e}=this.state;e.form.dataFull.config.default.title=t.title,e.form.dataFull.title_button.close_button=t.form_btn_close,e.form.dataFull.title_button.add_form=t.form_btn_add,e.form.dataFull.config.default.title_sub=t.des,e.dataFull.where_logged_in=t.where_logged_in,e.form.dataFull.list_button_on_header[0].dataFull.config.default.title=t.logout_all_app,e.dataFull.log_out_of_all_application=t.logout_all_app,e.dataFull.log_out_all_sessions=t.logout_all_ssn,e.dataFull.see_more=t.see_more,e.dataFull.log_out=t.logout,this.setState({stateData:e})}getDeviceStatus(t){let e={};switch(t){case"Active":e={type:"success",title:t};break;case"Locked":e={type:"default",title:t}}return e}render(){return"none"===this.stateHidden.visibility?null:(0,_.jsx)(n,{stateData:this.state.stateData})}}const g=d}}]);