(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[588],{153:function(e,t,s){"use strict";s.r(t);var a=s(1),i=s(2),c=s(4),l=s(3),n=s(0),o=s.n(n),r=s(5),m=s(594),d=s(7),u=function(e){Object(c.a)(s,e);var t=Object(l.a)(s);function s(e){var i;return Object(a.a)(this,s),(i=t.call(this,e)).abstract_changeDevice=function(e){i.setState({device:e})},i.class={desktop:"perseus-desktop-uFormNotify",desktop_small:"perseus-desktop_small-uFormNotify",tablet:"perseus-tablet-uFormNotify",mobile:"perseus-mobile-uFormNotify"},i.type_component="uFormNotify",i.code_component="perseus.uFormNotify",i.id_theme_component=Object(r.c)(),i.state={device:Object(r.f)(),skin_config:Object(m.configTemplate_getTheme)()},i}return Object(i.a)(s,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?o.a.createElement("div",{className:this.class[this.state.device]},o.a.createElement("div",{className:this.class[this.state.device]+"-header"},o.a.createElement(d.default,{val:"warning_amber",style:{fontSize:"28px"},class:"-round",isPointer:!1}),o.a.createElement("div",{className:this.class[this.state.device]+"-header-title"},this.props.dataFull.title)),o.a.createElement("div",null,o.a.createElement("ul",{className:this.class[this.state.device]+"-ul"},this.props.dataFull.data.map((function(t,s){return o.a.createElement("span",{key:s,className:e.class[e.state.device]+"-item row"},o.a.createElement("div",{className:e.class[e.state.device]+"-item-circle"}),o.a.createElement("span",{className:e.class[e.state.device]+"-item-title-div"},o.a.createElement("label",{className:e.class[e.state.device]+"-item-title_bold"},t.title),t.time))}))))):o.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),s}(n.Component);t.default=u}}]);