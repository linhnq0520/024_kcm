(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[434],{18:function(e,a,t){"use strict";t.r(a);var l=t(1),s=t(2),i=t(4),c=t(3),u=t(0),r=t.n(u),d=t(5),n=t(594),o=function(e){Object(i.a)(t,e);var a=Object(c.a)(t);function t(e){var s;return Object(l.a)(this,t),(s=a.call(this,e)).abstract_changeDevice=function(e){s.setState({device:e})},s.type_component="uView",s.code_component="perseus.uView",s.id_theme_component=Object(d.c)(),s.class={desktop:"perseus-desktop-uView",desktop_small:"perseus-desktop_small-uView",tablet:"perseus-tablet-uView",mobile:"perseus-mobile-uView"},s.state={device:Object(d.f)(),skin_config:Object(n.configTemplate_getTheme)()},s}return Object(s.a)(t,[{key:"componentWillUnmount",value:function(){Object(d.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(d.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){var e,a,t,l,s,i,c,u,d,n,o,v,h,m,p,b,f,N,w,g,_,E,F,O,k,j,y,C,S,T;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?r.a.createElement("div",{className:this.class[this.state.device]+""+((null===(e=this.props.dataFull)||void 0===e||null===(a=e.config)||void 0===a||null===(t=a.default)||void 0===t?void 0:t.class)?" "+(null===(l=this.props.dataFull)||void 0===l||null===(s=l.config)||void 0===s||null===(i=s.default)||void 0===i?void 0:i.class):" col-12 col-sm-12 col-md-12 col-xl-12 col-lg-12")+((null===(c=this.props.dataFull)||void 0===c||null===(u=c.config)||void 0===u||null===(d=u.default)||void 0===d?void 0:d.isBorder)?" perseus-view-border":"")},r.a.createElement("div",{className:this.class[this.state.device]+"-content"+((null===(n=this.props.dataFull)||void 0===n||null===(o=n.config)||void 0===o||null===(v=o.default)||void 0===v?void 0:v.isBorder)?" perseus-view-border":"")},(null===(h=this.props.dataFull)||void 0===h||null===(m=h.config)||void 0===m||null===(p=m.default)||void 0===p?void 0:p.title)?r.a.createElement("span",{className:this.class[this.state.device]+"-title"},this.props.dataFull.config.default.title):null,r.a.createElement("div",{className:"row"},this.props.children))):"mobile"===this.state.device?r.a.createElement("div",{className:this.class[this.state.device]+""+((null===(b=this.props.dataFull)||void 0===b||null===(f=b.config)||void 0===f||null===(N=f.default)||void 0===N?void 0:N.class)?" "+(null===(w=this.props.dataFull)||void 0===w||null===(g=w.config)||void 0===g||null===(_=g.default)||void 0===_?void 0:_.class):" col-12 col-sm-12 col-md-12 col-xl-12 col-lg-12")+((null===(E=this.props.dataFull)||void 0===E||null===(F=E.config)||void 0===F||null===(O=F.default)||void 0===O?void 0:O.isBorder)?" perseus-view-border":"")},r.a.createElement("div",{className:this.class[this.state.device]+"-content"+((null===(k=this.props.dataFull)||void 0===k||null===(j=k.config)||void 0===j||null===(y=j.default)||void 0===y?void 0:y.isBorder)?" perseus-view-border":"")},(null===(C=this.props.dataFull)||void 0===C||null===(S=C.config)||void 0===S||null===(T=S.default)||void 0===T?void 0:T.title)?r.a.createElement("span",{className:this.class[this.state.device]+"-title"},this.props.dataFull.config.default.title):null,r.a.createElement("div",{className:"row"},this.props.children))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),t}(u.Component);a.default=o},306:function(e,a,t){"use strict";t.r(a);var l=t(1),s=t(2),i=t(4),c=t(3),u=t(0),r=t.n(u),d=t(47),n=t(18),o=function(e){Object(i.a)(t,e);var a=Object(c.a)(t);function t(e){var s;return Object(l.a)(this,t),(s=a.call(this,e)).test1=function(e,a){console.log(e,a),s.setState({input_value:"New"})},s.state={input_value:void 0},s}return Object(s.a)(t,[{key:"render",value:function(){return r.a.createElement(n.default,null,r.a.createElement("div",{className:"col-12"},r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p c\xf3 2 c\u1ed9t")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},placeholder:"Search",data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{moreColumn:!0},column:[{title:"Code"},{title:"Name"},{title:"Name"}]},data:[{data:["New","12","1234ass444412"],value:"123"},{data:["New","1sss23","12312"],value:"123"},{data:["New","123","12312"],value:"123"},{data:["New","123","12312"],value:"123"},{data:["New","12sssss3","12312"],value:"123"},{data:["New","123","12312"],value:"123"},{data:["New","123","12312"],value:"123"},{data:["New","123","12312"],value:"123"}],search_value:""},abs_Change:this.test1,abs_search:this.search})),r.a.createElement("div",{className:"col-12"},r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p b\xecnh th\u01b0\u1eddng")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"New",value:"123"},{title:"New acc",value:"1234"},{title:"New aa",value:"12345"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New aaaa",value:"122",selected:!0}],search_value:"",input_value:this.state.input_value},abs_Change:this.test1,abs_search:this.search})),r.a.createElement("div",{className:"col-12"},r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p disable")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!0,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"New",value:"123"},{title:"New acc",value:"1234"},{title:"New aa",value:"12345"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New aaaa",value:"122",selected:!0}],search_value:""},abs_Change:this.test1,abs_search:this.search})),r.a.createElement("div",{className:"col-12"},r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p lock")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,isLock:!0,error:{message:"",type:""}},mode:{}},data:[{title:"New",value:"123"},{title:"New acc",value:"1234"},{title:"New aa",value:"12345"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New pub",value:"122"},{title:"New aaaa",value:"122",selected:!0}],search_value:""},abs_Change:this.test1,abs_search:this.search})),r.a.createElement("br",null),r.a.createElement("br",null),r.a.createElement("br",null),r.a.createElement("br",null),r.a.createElement("div",{className:"col-12"}," ",r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p error")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,error:{message:"Error",type:""}},mode:{}},data:[{title:"New",value:"123"},{title:"New aaaa",value:"122",selected:!0}],search_value:""},abs_Change:this.test1,abs_search:this.search})),r.a.createElement("div",{className:"col-12"},r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p c\xf3 search ")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[{title:"New",value:"1aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa23"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"123"},{title:"New",value:"1aaaaaaaaaaaaaaaaaaa23"},{title:"New",value:"123"},{title:"New aaaa",value:"122",selected:!0}],search_value:"",abs_Change:this.test1,abs_search:this.search}})),r.a.createElement("div",{className:"col-12"},r.a.createElement("p",null,r.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p kh\xf4ng c\xf3 d\u1eef li\u1ec7u ")),r.a.createElement(d.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-4",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[],search_value:""},abs_Change:this.test1,abs_search:this.search})))}}]),t}(u.Component);a.default=o}}]);