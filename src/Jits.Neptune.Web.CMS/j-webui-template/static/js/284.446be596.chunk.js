(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[284,322,435,436],{12:function(e,t,o){"use strict";o.r(t);var s=o(1),i=o(2),a=o(4),r=o(3),n=o(0),l=o.n(n),c=o(8),p=function(e){Object(a.a)(o,e);var t=Object(r.a)(o);function o(e){var i;return Object(s.a)(this,o),(i=t.call(this,e)).state={isBottom:!0},i}return Object(i.a)(o,[{key:"renderForCondition",value:function(){var e,t=this;return l.a.createElement("div",{className:"designForm-toolTip"},l.a.createElement("div",{className:"designForm-toolTip-content row"},l.a.createElement("i",{className:"designForm-toolTip-content-item designForm-move-icon material-icons-outlined designForm-move-"+this.props.title,style:{fontSize:"20px"}},"open_with"),l.a.createElement("i",{className:"designForm-toolTip-content-item",onClick:function(e){t.props.toolTip.abs_Copy(t.props.toolTip.dataItem)}},l.a.createElement(c.default,{val:"copy",style:{fontSize:"20px"}})),l.a.createElement("i",{className:"designForm-toolTip-content-item",onClick:function(e){t.props.toolTip.abs_Delete(t.props.toolTip.dataItem)}},l.a.createElement(c.default,{val:"delete",style:{fontSize:"20px"}})),l.a.createElement("i",{className:"designForm-toolTip-content-item",onClick:function(e){t.props.toolTip.abs_Edit(t.props.toolTip.dataItem)}},l.a.createElement(c.default,{val:"edit",style:{fontSize:"20px"}})),l.a.createElement("i",{className:"designForm-toolTip-content-item last",onMouseLeave:function(){t.myChooseLayout.style.visibility="hidden",t.myChooseLayout.style.opacity="0"}},l.a.createElement("i",{className:"material-icons-outlined designForm-toolTip-choose_layout",onMouseOver:function(e){t.myChooseLayout.style.visibility="visible",t.myChooseLayout.style.opacity="1";var o="-17px",s=window.innerHeight-t.myChooseLayout.offsetHeight;e.clientY>s?(o=t.myChooseLayout.offsetHeight+45+"px",t.myChooseLayout.classList.add("designForm-bottom"),t.setState({isBottom:!1})):(t.myChooseLayout.classList.remove("designForm-bottom"),t.setState({isBottom:!0})),t.myChooseLayout.style.bottom=o},style:{fontSize:"20px"}},"view_week"),l.a.createElement("div",{className:"designForm-toolTip-transparent"+(this.state.isBottom?"":" designForm-toolTip-top")}),l.a.createElement("div",{style:{position:"absolute",width:"0px",height:"0px"}},l.a.createElement("div",{className:"designForm-chooseLayout-content",ref:function(e){t.myChooseLayout=e}},l.a.createElement("div",{className:"designForm-chooseLayout-header"},l.a.createElement("div",null,this.props.toolTip.chooseLayout_config.title)),l.a.createElement("div",{className:"designForm-chooseLayout-content-div row"},null===(e=this.props.toolTip.chooseLayout_config.data)||void 0===e?void 0:e.map((function(e,o){return l.a.createElement("div",{className:"designForm-chooseLayout-item",key:o,onClick:function(o){o.stopPropagation(),o.preventDefault(),void 0!==t.props.toolTip.abs_ChooseLayout&&t.props.toolTip.abs_ChooseLayout(t.props.toolTip.dataItem,e),t.myChooseLayout.style.visibility="hidden",t.myChooseLayout.style.opacity="0"}},l.a.createElement(c.default,{val:e.img}))}))))))))}},{key:"render",value:function(){return this.renderForCondition()}}]),o}(n.Component);t.default=p},1312:function(e,t,o){"use strict";o.d(t,"a",(function(){return a}));var s=o(1313);function i(e,t){var o=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),o.push.apply(o,s)}return o}function a(e){for(var t=1;t<arguments.length;t++){var o=null!=arguments[t]?arguments[t]:{};t%2?i(Object(o),!0).forEach((function(t){Object(s.a)(e,t,o[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(o)):i(Object(o)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(o,t))}))}return e}},1313:function(e,t,o){"use strict";function s(e,t,o){return t in e?Object.defineProperty(e,t,{value:o,enumerable:!0,configurable:!0,writable:!0}):e[t]=o,e}o.d(t,"a",(function(){return s}))},8:function(e,t,o){"use strict";o.r(t);var s=o(1312),i=o(1),a=o(2),r=o(4),n=o(3),l=o(0),c=o.n(l),p=o(5),u=function(e){Object(r.a)(o,e);var t=Object(n.a)(o);function o(e){var a;Object(i.a)(this,o);var r=(a=t.call(this,e)).props.style;return void 0===r&&(r={fontSize:"20px"}),r=!1===a.props.isPointer?Object(s.a)(Object(s.a)({},r),{},{userSelect:"none"}):"disable"===a.props.isPointer?Object(s.a)(Object(s.a)({},r),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},r),{},{userSelect:"none",cursor:"pointer"}),a.state={style:r},a}return Object(a.a)(o,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"renderForCondition",value:function(){var e;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return c.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:this.state.style});if(this.props.val.includes("../")||(null===(e=this.props.val[0])||void 0===e?void 0:e.includes("/"))){var t=this.props.val;return p.a.managerTemplate_isDev()?t=t.replace("../",p.a.managerTemplate_getUrlResource()):p.a.managerTemplate_isCordova()&&(t=t.replace("../",p.a.managerTemplate_getUrlCordova())),c.a.createElement("img",{className:this.props.class?this.props.class:"",src:t,alt:this.props.title,style:this.state.style})}return c.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(p.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),o}(l.Component);t.default=u}}]);