(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[562],{40:function(e,t,o){"use strict";o.r(t);var i=o(1),a=o(2),s=o(4),n=o(3),l=o(0),c=o.n(l),u=o(5),d=o(593),r=function(e){Object(s.a)(o,e);var t=Object(n.a)(o);function o(e){var a;return Object(i.a)(this,o),(a=t.call(this,e)).abstract_changeDevice=function(e){a.setState({device:e})},a.type_component="uLayout",a.code_component="malibu.uLayout",a.id_theme_component=Object(u.c)(),a.state={device:Object(u.f)(),skin_config:Object(d.configTemplate_getTheme)(),class:a.props.class||"col-12"},a}return Object(a.a)(o,[{key:"componentWillUnmount",value:function(){Object(u.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(u.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?this.props.children:"mobile-app"===this.state.device?c.a.createElement("button",{className:"btn btn-success",type:"submit"},"mobile"):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){var e,t,o,i,a,s,n,l,u,d;return c.a.createElement("div",{className:"malibu-desktop-uLayout row "+this.state.class},""!==(null===(e=this.props.dataFull)||void 0===e||null===(t=e.config)||void 0===t?void 0:t.title)&&c.a.createElement("span",{className:"malibu-desktop-uLayout-title"},null===(o=this.props.dataFull)||void 0===o||null===(i=o.config)||void 0===i?void 0:i.title),this.renderForDevice(),void 0!==(null===(a=this.props.dataFull)||void 0===a||null===(s=a.config)||void 0===s?void 0:s.mode)&&void 0!==(null===(n=this.props.dataFull)||void 0===n||null===(l=n.config)||void 0===l?void 0:l.mode.hasCrossbar)&&!0===(null===(u=this.props.dataFull)||void 0===u||null===(d=u.config)||void 0===d?void 0:d.mode.hasCrossbar)&&c.a.createElement("hr",{className:"malibu-desktop-uLayout-hr"}))}}]),o}(l.Component);t.default=r}}]);