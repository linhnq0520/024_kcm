(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[592],{90:function(e,t,s){"use strict";s.r(t);var a=s(1),l=s(2),i=s(4),o=s(3),n=s(0),c=s.n(n),r=s(7),d=s(5),u=s(594),p=function(e){Object(i.a)(s,e);var t=Object(o.a)(s);function s(e){var l;return Object(a.a)(this,s),(l=t.call(this,e)).abstract_changeDevice=function(e){l.setState({device:e},(function(){l.render()}))},l.type_component="uMessageGlobal",l.code_component="perseus.uMessageGlobal",l.class_desktop="perseus-desktop-uMessageGlobal",l.class_desktop_small="perseus-desktop_small-uMessageGlobal",l.class_tablet="perseus-tablet-uMessageGlobal",l.class_mobile="perseus-mobile-uMessageGlobal",l.id_theme_component=Object(d.c)(),l.state={device:Object(d.f)(),skin_config:Object(u.configTemplate_getTheme)(),isDisMount:"none"},l}return Object(l.a)(s,[{key:"componentWillUnmount",value:function(){Object(d.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(d.b)(this,this.id_theme_component),this.setState({isDisMount:"block"})}},{key:"convertValue",value:function(e){var t;switch(null===(t=this.props.dataFull)||void 0===t?void 0:t.type){case"danger":return"warning";case"gray":return"error";case"warning":return"report";case"success":default:return"warning"}}},{key:"renderForDevice",value:function(){var e,t,s,a,l,i,o,n,d,u,p,v;return"desktop"===this.state.device?c.a.createElement("div",{className:this.class_desktop},c.a.createElement("div",{className:this.class_desktop+"-content perseus-"+(null===(e=this.props.dataFull)||void 0===e?void 0:e.type)},c.a.createElement(r.default,{val:this.convertValue(null===(t=this.props.dataFull)||void 0===t?void 0:t.type),style:{fontSize:"24px"},class:"-round",title:"",isPointer:!1}),c.a.createElement("div",{className:this.class_desktop+"-title"},null===(s=this.props.dataFull)||void 0===s?void 0:s.title))):"desktop_small"===this.state.device?c.a.createElement("div",{className:this.class_desktop_small},c.a.createElement("div",{className:this.class_desktop_small+"-content perseus-"+(null===(a=this.props.dataFull)||void 0===a?void 0:a.type)},c.a.createElement(r.default,{val:this.convertValue(null===(l=this.props.dataFull)||void 0===l?void 0:l.type),style:{fontSize:"24px"},class:"-round",title:"",isPointer:!1}),c.a.createElement("div",{className:this.class_desktop_small+"-title"},null===(i=this.props.dataFull)||void 0===i?void 0:i.title))):"tablet"===this.state.device?c.a.createElement("div",{className:this.class_tablet},c.a.createElement("div",{className:this.class_tablet+"-content perseus-"+(null===(o=this.props.dataFull)||void 0===o?void 0:o.type)},c.a.createElement(r.default,{val:this.convertValue(null===(n=this.props.dataFull)||void 0===n?void 0:n.type),style:{fontSize:"24px"},class:"-round",title:"",isPointer:!1}),c.a.createElement("div",{className:this.class_tablet+"-title"},null===(d=this.props.dataFull)||void 0===d?void 0:d.title))):"mobile"===this.state.device?c.a.createElement("div",{className:this.class_mobile},c.a.createElement("div",{className:this.class_mobile+"-content perseus-"+(null===(u=this.props.dataFull)||void 0===u?void 0:u.type)},c.a.createElement(r.default,{val:this.convertValue(null===(p=this.props.dataFull)||void 0===p?void 0:p.type),style:{fontSize:"24px"},class:"-round",title:"",isPointer:!1}),c.a.createElement("div",{className:this.class_mobile+"-title"},null===(v=this.props.dataFull)||void 0===v?void 0:v.title))):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),s}(n.Component);t.default=p}}]);