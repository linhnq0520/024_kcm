(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[795],{637:function(e,s,t){"use strict";t.r(s);var i=t(1),o=t(2),a=t(4),r=t(3),p=t(0),l=t.n(p),n=t(7),c=function(e){Object(a.a)(t,e);var s=Object(r.a)(t);function t(e){var o;Object(i.a)(this,t);var a=(o=s.call(this,e)).props.sysStyle;return o.class={desktop:"perseus-desktop-uFormTabItem",desktop_small:"perseus-desktop_small-uFormTabItem",tablet:"perseus-tablet-uFormTabItem",mobile:"perseus-mobile-uFormTabItem"},o.state={sysStyle:a},o}return Object(o.a)(t,[{key:"componentDidUpdate",value:function(e){void 0!==this.props.sysStyle&&(void 0===e.sysStyle||this.props.sysStyle.show!==e.sysStyle.show)&&this.setState({sysStyle:this.props.sysStyle})}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.props.device||"desktop_small"===this.props.device||"desktop_small"===this.props.device||"tablet"===this.props.device||"mobile"===this.props.device?l.a.createElement("div",{className:this.class[this.props.device]+"-info "+(this.state.sysStyle.show?this.state.sysStyle.show:""),onClick:function(){e.props.uFormTab_selectItem(e.props.index,e.props.tabInfo.id)}},this.props.tabInfo.title?l.a.createElement("div",{className:this.class[this.props.device]+"-span",style:this.state.style},this.props.tabInfo.img&&l.a.createElement(n.default,{val:this.props.tabInfo.img,style:{width:"18px",height:"18px",fontSize:"18px",marginRight:"8px"}}),l.a.createElement("div",null,this.props.tabInfo.title)):null):l.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),t}(p.Component);s.default=c}}]);