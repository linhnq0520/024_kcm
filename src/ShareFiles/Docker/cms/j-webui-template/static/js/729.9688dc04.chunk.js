(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[729,287,322,435,436],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return o}));var s=a(1313);function i(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function o(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?i(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):i(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},222:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),o=a(4),r=a(3),n=a(0),l=a.n(n),c=a(8),p=function(e){Object(o.a)(a,e);var t=Object(r.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).class___="designForm-screen_preview",i.state={value:"",mode_id:"desktop",isRotate:!1},i}return Object(i.a)(a,[{key:"render",value:function(){var e,t,a=this;return l.a.createElement("div",{className:this.class___,style:{display:this.props.stateData.cmd.visibility?"block":"none"}},l.a.createElement("div",{className:this.class___+"-header row"},l.a.createElement("div",{className:this.class___+"-header-icon_back",onClick:function(){void 0!==a.props.stateData.back_to_home.abs_Click&&a.props.stateData.back_to_home.abs_Click()}},l.a.createElement(c.default,{val:"keyboard_backspace",style:{fontSize:"28px"}})),l.a.createElement("div",{className:this.class___+"-header-title",onClick:function(){void 0!==a.props.stateData.back_to_home.abs_Click&&a.props.stateData.back_to_home.abs_Click()}},this.props.stateData.back_to_home.title),l.a.createElement("div",{className:this.class___+"-header-mode row"},this.props.stateData.device_mode.map((function(e,t){return l.a.createElement("div",{key:t,title:e.title,className:a.class___+"-header-mode-item"+(a.state.mode_id===e.id?" designForm-choose":""),onClick:function(t){a.state.mode_id!==e.id&&void 0!==e.abs_Click&&(e.abs_Click(e.id),a.setState({mode_id:e.id}))}},l.a.createElement(c.default,{val:e.img,style:{fontSize:"24px",height:"24px",width:"22px",margin:"auto"}}))})),l.a.createElement("div",{className:this.class___+"-header-change_device"+("desktop"===this.state.mode_id?" designForm-desktop":""),onClick:function(e){a.setState({isRotate:!a.state.isRotate})}},l.a.createElement(c.default,{val:"screen_rotation",style:{fontSize:"24px",height:"24px",width:"24px",margin:"auto"}}))),l.a.createElement("div",{className:this.class___+"-header-template"},l.a.createElement("div",{className:"row",onClick:function(e){a.myChooseLang.focus()}},l.a.createElement(c.default,{val:null===(e=this.props.stateData.templates.data.find((function(e){return e.selected})))||void 0===e?void 0:e.img,style:{width:"32px",height:"32px",fontSize:"32px",borderRadius:"50%"}}),l.a.createElement("div",{className:this.class___+"-header-template-title",tabIndex:1,ref:function(e){a.myChooseLang=e}},null===(t=this.props.stateData.templates.data.find((function(e){return e.selected})))||void 0===t?void 0:t.title),l.a.createElement("i",{className:"material-icons md-20",style:{fontSize:"20px",margin:"auto 0px",marginLeft:"8px",cursor:"pointer"},onClick:function(e){a.myChooseLang.focus()}},"expand_more")),l.a.createElement("ul",{className:this.class___+"-header-template-menu ",style:{background:"#FFFFFF"}},this.props.stateData.templates.data.map((function(e,t){return l.a.createElement("li",{key:t,className:a.class___+"-header-template-item row "+(e.selected?"designForm-active":""),onMouseDown:function(s){e.selected||void 0!==a.props.stateData.templates.abs_Click&&a.props.stateData.templates.abs_Click(e.dataItem,t)}},l.a.createElement(c.default,{val:e.img,style:{width:"28px",height:"28px",fontSize:"28px",borderRadius:"50%"}}),l.a.createElement("div",{style:{paddingLeft:"12px",margin:"auto 0px"}},e.title))}))))),l.a.createElement("div",{className:this.class___+"-content"},l.a.createElement("div",{className:this.class___+"-content-"+this.state.mode_id+(this.state.isRotate?" designForm-rotate":"")},l.a.createElement("iframe",{src:this.props.stateData.data_view.link_form,className:this.class___+"-content-"+this.state.mode_id+"-content",title:this.props.stateData.data_view.title,ref:function(e){a.ref_myIframe=e}}))))}}]),a}(n.Component);t.default=p},702:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),o=a(4),r=a(3),n=a(0),l=a.n(n),c=a(222),p=function(e){Object(o.a)(a,e);var t=Object(r.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abs_Change=function(e){console.log(e.target.value)},i.abs_ClickMode=function(){},i.abs_ClickIcon=function(e){console.log(e)},i.abs_Click=function(){console.log("clcock")},i.state={stateData:{cmd:{visibility:!0},back_to_home:{title:"Back to home",abs_Click:i.abs_Click},device_mode:[{title:"desktop",img:"laptop_mac",id:"desktop",abs_Click:i.abs_ClickMode},{title:"tablet",img:"tablet_mac",id:"tablet",abs_Click:i.abs_ClickMode},{title:"mobile",img:"phone_iphone",id:"mobile",abs_Click:i.abs_ClickMode}],templates:{data:[{title:"Theme Malibu-Blue",img:"https://i.imgur.com/IIM8Q1q.png",selected:!0,value:"123"},{title:"Theme malibu-green",img:"https://i.imgur.com/IIM8Q1q.png",value:"123"},{title:"Theme malibu",img:"https://i.imgur.com/IIM8Q1q.png",value:"123"}],abs_Click:i.abs_Click},data_view:{title:"Desktop view",link_form:"http:/localhost:3333/fwcss?template=malibu&screen_working=sw_template_uLogin"}}},i}return Object(i.a)(a,[{key:"render",value:function(){return l.a.createElement(l.a.Fragment,null,l.a.createElement("div",{className:"d-flex col-12"},l.a.createElement("div",{className:"main",style:{width:"100%"}},l.a.createElement(c.default,{stateData:this.state.stateData}))))}}]),a}(n.Component);t.default=p},8:function(e,t,a){"use strict";a.r(t);var s=a(1312),i=a(1),o=a(2),r=a(4),n=a(3),l=a(0),c=a.n(l),p=a(5),m=function(e){Object(r.a)(a,e);var t=Object(n.a)(a);function a(e){var o;Object(i.a)(this,a);var r=(o=t.call(this,e)).props.style;return void 0===r&&(r={fontSize:"20px"}),r=!1===o.props.isPointer?Object(s.a)(Object(s.a)({},r),{},{userSelect:"none"}):"disable"===o.props.isPointer?Object(s.a)(Object(s.a)({},r),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},r),{},{userSelect:"none",cursor:"pointer"}),o.state={style:r},o}return Object(o.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"renderForCondition",value:function(){var e;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return c.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:this.state.style});if(this.props.val.includes("../")||(null===(e=this.props.val[0])||void 0===e?void 0:e.includes("/"))){var t=this.props.val;return p.a.managerTemplate_isDev()?t=t.replace("../",p.a.managerTemplate_getUrlResource()):p.a.managerTemplate_isCordova()&&(t=t.replace("../",p.a.managerTemplate_getUrlCordova())),c.a.createElement("img",{className:this.props.class?this.props.class:"",src:t,alt:this.props.title,style:this.state.style})}return c.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(p.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(l.Component);t.default=m}}]);