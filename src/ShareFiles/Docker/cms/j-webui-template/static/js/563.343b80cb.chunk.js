(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[563],{145:function(e,t,s){"use strict";s.r(t);var i=s(1),n=s(2),a=s(4),l=s(3),o=s(0),c=s.n(o),p=s(5),r=s(593),u=function(e){Object(a.a)(s,e);var t=Object(l.a)(s);function s(e){var n;Object(i.a)(this,s),(n=t.call(this,e)).abstract_changeDevice=function(e){n.setState({device:e})},n.type_component="uMultiValue",n.code_component="malibu.uMultiValue",n.class_desktop="malibu-desktop-uMultiValue",n.id_theme_component=Object(p.c)();var a=n.props.isLoadingEnd;void 0===a&&(a=!0);var l=n.props.isOpenDefault;void 0===l&&(l=!1);var o=n.props.class;return void 0===o&&(o="col-12"),n.state={device:Object(p.f)(),skin_config:Object(r.configTemplate_getTheme)(),isOpenDefault:a,isOpen:l,class:o,height:0},n}return Object(n.a)(s,[{key:"componentWillUnmount",value:function(){Object(p.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(p.b)(this,this.id_theme_component)}},{key:"componentDidUpdate",value:function(e){void 0!==this.props.isLoadingEnd&&void 0!==e.isLoadingEnd&&this.props.isLoadingEnd!==e.isLoadingEnd&&this.props.isLoadingEnd!==this.state.isOpenDefault&&this.setState({isOpenDefault:this.props.isLoadingEnd})}},{key:"getDisplay",value:function(){if(this.state.isOpenDefault)return this.state.isOpen?"block":"none"}},{key:"renderForDevice",value:function(){return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?this.props.children:"mobile-app"===this.state.device?c.a.createElement("button",{className:"btn btn-success",type:"submit"},"mobile"):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"openMultiValue",value:function(){var e=this,t=this.state.isOpen;t=!t,this.setState({isOpen:t},(function(){var t=e.ref_divElement.clientHeight;16===t&&(t=0),t!==e.state.height&&e.setState({height:t})}))}},{key:"render",value:function(){var e,t=this;return!1===(null===(e=this.props.cmd)||void 0===e?void 0:e.visible)?null:c.a.createElement("div",{className:this.class_desktop+" malibu-component-padding malibu-component-margin_top "+this.state.class,ref:function(e){t.ref_divElement=e},id:this.props.component_code},c.a.createElement("div",{className:this.class_desktop+"-header"+(this.state.isOpen?" expand":""),ref:function(e){return t.ref_header=e},tabIndex:1,onFocus:function(){t.state.isOpen||t.openMultiValue()},onKeyUp:function(e){13===e.keyCode&&t.openMultiValue()},onMouseDown:function(e){e.preventDefault(),t.openMultiValue()}},c.a.createElement("span",null,"[",this.state.isOpen?c.a.createElement("span",null,"-"):c.a.createElement("span",null,"+"),"]"),""!==this.props.title&&c.a.createElement("span",{className:this.class_desktop+"-title"},this.props.title)),c.a.createElement("div",{style:{position:"relative"}},c.a.createElement("fieldset",{className:this.class_desktop+"-border"+(this.state.isOpen?" expand":"")},c.a.createElement("legend",{className:this.class_desktop+"-border-title"},c.a.createElement("span",null,"[",this.state.isOpen?c.a.createElement("span",null,"-"):c.a.createElement("span",null,"+"),"]"),this.props.title)),c.a.createElement("div",{className:this.class_desktop+"-content ",style:{visibility:this.state.isOpenDefault?"":"hidden",display:this.getDisplay()}},this.renderForDevice())))}}]),s}(o.Component);t.default=u}}]);