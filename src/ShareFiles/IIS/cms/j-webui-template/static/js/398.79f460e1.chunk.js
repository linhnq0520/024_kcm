(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[398,578],{100:function(t,e,a){"use strict";a.r(e);var s=a(1),l=a(2),i=a(4),o=a(3),c=a(0),n=a.n(c),d=a(5),r=a(593),m=a(66),p=function(t){Object(i.a)(a,t);var e=Object(o.a)(a);function a(t){var l;return Object(s.a)(this,a),(l=e.call(this,t)).abstract_changeDeviceReal=function(t,e){l.setState({device:t,width:e.window_size.width})},l.class_desktop="malibu-desktop-uTableColumnWidget",l.class_tablet="malibu-tablet-uTableColumnWidget",l.class_mobile="malibu-mobile-uTableColumnWidget",l.class={desktop:"malibu-desktop-uTableColumnWidget-border",desktop_small:"malibu-desktop-uTableColumnWidget-border",tablet:"malibu-tablet-uTableColumnWidget-border",mobile:"malibu-mobile-uTableColumnWidget-border"},l.type_component="uTableColumnWidget",l.code_component="malibu.uTableColumnWidget",l.id_theme_component=Object(d.c)(),l.state={device:Object(d.f)(),skin_config:Object(r.configTemplate_getTheme)(),isDisMount:"none"},l}return Object(l.a)(a,[{key:"componentDidMount",value:function(){Object(d.b)(this,this.id_theme_component),void 0!==this.myTitle&&void 0!==this.myLogout&&void 0!==this.myIndex&&(this.myTitle.style.maxWidth="calc(100% - "+(this.myLogout.offsetWidth+this.myIndex.offsetWidth+1)+"px)")}},{key:"componentDidUpdate",value:function(){void 0!==this.myTitle&&void 0!==this.myLogout&&void 0!==this.myIndex&&(this.myTitle.style.maxWidth="calc(100% - "+(this.myLogout.offsetWidth+this.myIndex.offsetWidth+1)+"px)")}},{key:"componentWillUnmount",value:function(){Object(d.i)(this.id_theme_component)}},{key:"renderForDevice",value:function(){var t=this;return"desktop"===this.state.device||"desktop_small"===this.state.device?n.a.createElement("div",null,n.a.createElement("div",{className:this.class_desktop+""},this.props.index+1),n.a.createElement("div",{className:this.class_desktop+"-item"},n.a.createElement("div",{className:this.class_desktop+"-top",title:this.props.dataFull.title_main+this.props.dataFull.title_OFD},this.props.dataFull.title_main," ",this.props.dataFull.title_OFD),n.a.createElement("div",{className:this.class_desktop+"-bottom"},this.props.dataFull.description)),n.a.createElement("div",{className:this.class_desktop+"-left",style:{cursor:"pointer"},onClick:function(e){void 0!==t.props.dataFull.abs_Click&&t.props.dataFull.abs_Click(e,t.props.dataFull.dataItem,t.props.dataFull)}},this.props.log_out),n.a.createElement(m.default,{title:this.props.dataFull.widget.title,type:this.props.dataFull.widget.type})):"tablet"===this.state.device?n.a.createElement("div",{className:this.class_tablet+"-div"},n.a.createElement("div",{className:this.class_tablet+""},this.props.index+1),n.a.createElement("div",{className:this.class_tablet+"-item"},n.a.createElement("div",{className:this.class_tablet+"-item-div row"},n.a.createElement("div",{className:this.class_tablet+"-top"},this.props.dataFull.title_main," ",this.props.dataFull.title_OFD),n.a.createElement("div",{className:this.class_tablet+"-span-hover"},this.props.dataFull.title_main," ",this.props.dataFull.title_OFD),n.a.createElement("div",{className:this.class_tablet+"-status"},n.a.createElement(m.default,{title:this.props.dataFull.widget.title,type:this.props.dataFull.widget.type}))),n.a.createElement("div",{className:this.class_tablet+"-bottom"},this.props.dataFull.description)),n.a.createElement("div",{className:this.class_tablet+"-left",style:{cursor:"pointer"},onClick:function(e){void 0!==t.props.dataFull.abs_Click&&t.props.dataFull.abs_Click(e,t.props.dataFull.dataItem,t.props.dataFull)}},this.props.log_out)):"mobile"===this.state.device?n.a.createElement("div",{className:"row"},n.a.createElement("div",{className:this.class_mobile+"",ref:function(e){t.myIndex=e}},this.props.index+1),n.a.createElement("div",{className:this.class_mobile+"-item",ref:function(e){t.myTitle=e}},n.a.createElement("div",{className:"malibu-mobile-uTableColumnWidger-status-div"},n.a.createElement(m.default,{title:this.props.dataFull.widget.title,type:this.props.dataFull.widget.type})),n.a.createElement("div",{className:this.class_mobile+"-top"},this.props.dataFull.title_main),n.a.createElement("div",{className:this.class_mobile+"-bottom"},this.props.dataFull.description)),n.a.createElement("div",{className:this.class_mobile+"-left",style:{cursor:"pointer"},onClick:function(e){void 0!==t.props.dataFull.abs_Click&&t.props.dataFull.abs_Click(e,t.props.dataFull.dataItem,t.props.dataFull)},ref:function(e){t.myLogout=e}},this.props.log_out)):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return n.a.createElement("td",{className:this.class[this.state.device]},this.renderForDevice())}}]),a}(c.Component);e.default=p},66:function(t,e,a){"use strict";a.r(e);var s=a(1),l=a(2),i=a(4),o=a(3),c=a(0),n=a.n(c),d=function(t){Object(i.a)(a,t);var e=Object(o.a)(a);function a(){return Object(s.a)(this,a),e.apply(this,arguments)}return Object(l.a)(a,[{key:"render",value:function(){return n.a.createElement("div",{className:"malibu-reuseStatus "+this.props.type},n.a.createElement("div",{className:"malibu-reuseStatus-content "+this.props.type},n.a.createElement("div",{className:"malibu-reuseStatus-circle "+this.props.type}),n.a.createElement("span",{className:"malibu-reuseStatus-value "+this.props.type,style:{fontSize:"14px"}},this.props.title)))}}]),a}(c.Component);e.default=d}}]);