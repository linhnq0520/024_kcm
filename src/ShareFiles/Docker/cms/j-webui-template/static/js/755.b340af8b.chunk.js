(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[755,322,435,436],{1312:function(e,t,s){"use strict";s.d(t,"a",(function(){return a}));var i=s(1313);function r(e,t){var s=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);t&&(i=i.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),s.push.apply(s,i)}return s}function a(e){for(var t=1;t<arguments.length;t++){var s=null!=arguments[t]?arguments[t]:{};t%2?r(Object(s),!0).forEach((function(t){Object(i.a)(e,t,s[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(s)):r(Object(s)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(s,t))}))}return e}},1313:function(e,t,s){"use strict";function i(e,t,s){return t in e?Object.defineProperty(e,t,{value:s,enumerable:!0,configurable:!0,writable:!0}):e[t]=s,e}s.d(t,"a",(function(){return i}))},668:function(e,t,s){"use strict";s.r(t),s.d(t,"default",(function(){return p}));var i=s(1),r=s(2),a=s(4),o=s(3),n=s(0),c=s.n(n),l=s(8),p=function(e){Object(a.a)(s,e);var t=Object(o.a)(s);function s(e){var r,a;Object(i.a)(this,s),(r=t.call(this,e)).class_desktop="designForm-desktop-uNotification";var o=r.props.item.config;return void 0===o&&(o={}),a=void 0===o.time_out?5e3:o.time_out,r.state={visible:!0,time_out:a,class:""},r._isClose=!1,r}return Object(r.a)(s,[{key:"componentDidMount",value:function(){this.setTimer()}},{key:"setTimer",value:function(){var e=this;null!=this._timer_child&&clearTimeout(this._timer_child),this._timer_child=setTimeout((function(){!1===e._isClose&&e.setState({class:"fade-in"},(function(){setTimeout((function(){e.setState({visible:!1},(function(){e._timer_child=null,e.props.abs_uNotificationItem_DeleteMe(e.props.item.id)}))}),1e3)}))}),this.state.time_out)}},{key:"render",value:function(){var e=this;return this.state.visible&&c.a.createElement("div",{key:this.props.index,className:this.class_desktop+" "+this.state.class+" "+this.props.item.color},c.a.createElement("div",{className:this.class_desktop+"-content row"},c.a.createElement("div",{className:this.class_desktop+"-title-div"},c.a.createElement("div",{className:this.class_desktop+"-title"},this.props.item.title)),c.a.createElement("div",{className:this.class_desktop+"-close",onClick:function(){e._isClose=!0,e.setTimer(),e.setState({class:"fade-out"},(function(){setTimeout((function(){e.setState({visible:!1}),e._timer_child=null}),300)})),e.props.abs_uNotificationItem_DeleteMe(e.props.item.id)}},c.a.createElement(l.default,{val:"close",style:{width:"32px",height:"32px",fontSize:"32px"},title:"close"}))))}}]),s}(n.Component)},8:function(e,t,s){"use strict";s.r(t);var i=s(1312),r=s(1),a=s(2),o=s(4),n=s(3),c=s(0),l=s.n(c),p=s(5),u=function(e){Object(o.a)(s,e);var t=Object(n.a)(s);function s(e){var a;Object(r.a)(this,s);var o=(a=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===a.props.isPointer?Object(i.a)(Object(i.a)({},o),{},{userSelect:"none"}):"disable"===a.props.isPointer?Object(i.a)(Object(i.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(i.a)(Object(i.a)({},o),{},{userSelect:"none",cursor:"pointer"}),a.state={style:o},a}return Object(a.a)(s,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(i.a)(Object(i.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(i.a)(Object(i.a)({},t),{},{cursor:"default"}):Object(i.a)(Object(i.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"renderForCondition",value:function(){var e;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return l.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:this.state.style});if(this.props.val.includes("../")||(null===(e=this.props.val[0])||void 0===e?void 0:e.includes("/"))){var t=this.props.val;return p.a.managerTemplate_isDev()?t=t.replace("../",p.a.managerTemplate_getUrlResource()):p.a.managerTemplate_isCordova()&&(t=t.replace("../",p.a.managerTemplate_getUrlCordova())),l.a.createElement("img",{className:this.props.class?this.props.class:"",src:t,alt:this.props.title,style:this.state.style})}return l.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(p.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),s}(c.Component);t.default=u}}]);