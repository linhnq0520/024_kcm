(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[557],{81:function(e,t,i){"use strict";i.r(t);var s=i(1),a=i(2),c=i(4),o=i(3),n=i(0),l=i.n(n),r=i(5),d=i(593),m=function(e){Object(c.a)(i,e);var t=Object(o.a)(i);function i(e){var a;return Object(s.a)(this,i),(a=t.call(this,e)).abstract_changeDevice=function(e,t){a.setState({device:e,window_size:t})},a.GetDataFull=function(){if(a.props.children){var e,t,i;i=a.props.children.length>0?a.props.children[0].props.dataFull:a.props.children.props.dataFull;var s=JSON.parse(JSON.stringify(i));for(var c in i)void 0===s[c]&&(s[c]="this.".concat(c,"()"));return(null===(e=s.config)||void 0===e||null===(t=e.cmd)||void 0===t?void 0:t.visible)||(s.config.cmd.visible=!0),JSON.stringify(s,null,4)}return""},a.type_component="uViewCode",a.code_component="persist.uViewCode",a.id_theme_component=Object(r.c)(),a.className={desktop:"persist-desktop-uViewCode",desktop_small:"persist-desktop-uViewCode",tablet:"persist-tablet-uViewCode",mobile:"persist-mobile-uViewCode"},a.state={device:Object(r.f)(),window_size:Object(r.h)(),skin_config:Object(d.configTemplate_getTheme)(),item_choose_id:"example",isDisMount:"none"},a}return Object(a.a)(i,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"render",value:function(){var e=this;return l.a.createElement("div",{className:"col-md-12 col-lg-12 col-xl-12 "+this.className[this.state.device]},l.a.createElement("div",{className:this.className[this.state.device]+"-header"},l.a.createElement("div",{className:this.className[this.state.device]+"-header-item"+("example"===this.state.item_choose_id?" persist-active":""),onClick:function(){"example"!==e.state.item_choose_id&&e.setState({item_choose_id:"example"})}},"EXAMPLE"),l.a.createElement("div",{className:this.className[this.state.device]+"-header-item"+("view"===this.state.item_choose_id?" persist-active":""),onClick:function(){"view"!==e.state.item_choose_id&&e.setState({item_choose_id:"view"})}},"VIEW DATAFULL/STATEDATA")),l.a.createElement("div",{className:this.className[this.state.device]+"-content row"+("example"===this.state.item_choose_id?" persist-active":"")},this.props.children),l.a.createElement("div",{className:this.className[this.state.device]+"-content persist-view"+("view"===this.state.item_choose_id?" persist-active":"")},l.a.createElement("pre",null,l.a.createElement("code",null,'"dataFull":',this.GetDataFull()))))}}]),i}(n.Component);t.default=m}}]);