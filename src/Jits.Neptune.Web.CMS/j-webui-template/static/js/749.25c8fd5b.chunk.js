(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[749,33,292,293,294,295,296,297,298,435,436],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return l}));var i=a(1313);function s(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);t&&(i=i.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,i)}return a}function l(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?s(Object(a),!0).forEach((function(t){Object(i.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):s(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function i(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return i}))},6:function(e,t,a){"use strict";a.r(t);var i=a(1312),s=a(1),l=a(2),o=a(4),n=a(3),r=a(0),c=a.n(r),p=a(9),d=a(5),u=function(e){Object(o.a)(a,e);var t=Object(n.a)(a);function a(e){var l;Object(s.a)(this,a);var o=(l=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===l.props.isPointer?Object(i.a)(Object(i.a)({},o),{},{userSelect:"none"}):"disable"===l.props.isPointer?Object(i.a)(Object(i.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(i.a)(Object(i.a)({},o),{},{userSelect:"none",cursor:"pointer"}),l.state={style:o,isZoom:!1,isOpenModal:!1},l}return Object(l.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(i.a)(Object(i.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(i.a)(Object(i.a)({},t),{},{cursor:"default"}):Object(i.a)(Object(i.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),i=new Uint8Array(a),s=0;s<t.length;s++)i[s]=t.charCodeAt(s);return new Blob([i],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,s=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return c.a.createElement(c.a.Fragment,null,c.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(i.a)(Object(i.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=s.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==s.props.viewFile.file_type&&"txt"!==s.props.viewFile.file_type?!(null===(t=s.props.viewFile)||void 0===t?void 0:t.isView)&&s.props.isZoom&&!0!==s.state.isZoom&&s.setState({isZoom:!0}):!0!==s.state.isOpenModal&&s.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&c.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){s.setState({isOpenModal:!1})}}},c.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==s.state.isZoom&&s.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},c.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var l,o,n=this.props.val;return d.a.managerTemplate_isDev()?n=n.replace("../",d.a.managerTemplate_getUrlResource()):d.a.managerTemplate_isCordova()&&(n=n.replace("../",d.a.managerTemplate_getUrlCordova())),c.a.createElement(c.a.Fragment,null,c.a.createElement("img",{className:this.props.class?this.props.class:"",src:n,alt:this.props.title,style:Object(i.a)(Object(i.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=s.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==s.props.viewFile.file_type&&"txt"!==s.props.viewFile.file_type?!(null===(t=s.props.viewFile)||void 0===t?void 0:t.isView)&&s.props.isZoom&&!0!==s.state.isZoom&&s.setState({isZoom:!0}):!0!==s.state.isOpenModal&&s.setState({isOpenModal:!0})}}),(null===(l=this.props.viewFile)||void 0===l?void 0:l.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&c.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){s.setState({isOpenModal:!1})}}},c.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==s.state.isZoom&&s.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},c.a.createElement("img",{src:n,alt:this.props.title}))))}return c.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(d.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(r.Component);t.default=u},690:function(e,t,a){"use strict";a.r(t);var i=a(1),s=a(2),l=a(4),o=a(3),n=a(0),r=a.n(n),c=a(5),p=a(593),d=a(6),u=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var s,l,o,n;return Object(i.a)(this,a),void 0!==(null===(s=(o=t.call(this,e)).props.dataFull.config)||void 0===s||null===(l=s.default)||void 0===l?void 0:l.icon)&&(n="8px"),o.state={device:Object(c.f)(),skin_config:Object(p.configTemplate_getTheme)(),style_title:n},o}return Object(s.a)(a,[{key:"createRipple",value:function(e){var t=this,a=document.createElement("div");this.myButton.appendChild(a);var i=Math.max(this.myButton.offsetWidth,this.myButton.offsetHeight);a.style.width=a.style.height=i+"px",a.style.left=e.offsetWidth-this.myButton.offsetWidth-i/2+"px",a.style.top=e.offsetHeight-this.myButton.offsetHeight-i/2+"px",a.classList.add("ripple"),setTimeout((function(){void 0!==t.myButton&&t.myButton.removeChild(a)}),1e3)}},{key:"render",value:function(){var e,t,a,i,s,l,o,n,p,u,m,h,f,v,b,_,y=this;return!1!==(null===(e=this.props.dataFull.config)||void 0===e||null===(t=e.cmd)||void 0===t?void 0:t.visible)&&r.a.createElement("div",{className:"malibu-desktop-jwebui_roleProfile_button"+((null===(a=this.props.dataFull.config.default)||void 0===a?void 0:a.type)?" "+this.props.dataFull.config.default.type:"")+((null===(i=this.props.dataFull.config.default)||void 0===i?void 0:i.class)?" "+this.props.dataFull.config.default.class:"")+((null===(s=this.props.dataFull.config)||void 0===s||null===(l=s.default)||void 0===l?void 0:l.icon)?" icon":"")+((null===(o=this.props.dataFull.config)||void 0===o||null===(n=o.cmd)||void 0===n?void 0:n.disable)?" malibu-disable":""),onClick:function(e){var t,a;!0!==(null===(t=y.props.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.disable)&&(y.createRipple(e),void 0!==y.props.dataFull.abs_Click&&y.props.dataFull.abs_Click(e,y.props.dataFull.dataItem))},ref:function(e){y.myButton=e},style:(this.props.dataFull.config.default.class,{})},r.a.createElement("div",{className:"malibu-desktop-jwebui_roleProfile_button-content row"},(null===(p=this.props.dataFull.config.default)||void 0===p?void 0:p.icon)?r.a.createElement(d.default,{val:Object(c.d)(this.props.dataFull.config.default.icon),style:{fontSize:"24px"},isPointer:!0!==(null===(u=this.props.dataFull.config.cmd)||void 0===u?void 0:u.disable),title:(null===(m=this.props.dataFull.config.default)||void 0===m?void 0:m.title)?this.props.dataFull.config.default.title:""}):null,(null===(h=this.props.dataFull.config.default)||void 0===h?void 0:h.icondouble)?r.a.createElement("div",{className:"row"},r.a.createElement("i",{className:"material-icons-outlined",style:{fontSize:"24px",cursor:!0!==(null===(f=this.props.dataFull.config.cmd)||void 0===f?void 0:f.disable)?"pointer":"no-drop"}},null===(v=this.props.dataFull.config.default)||void 0===v?void 0:v.icondouble),r.a.createElement("i",{className:"material-icons-outlined ",style:{fontSize:"24px",marginLeft:"-15px",cursor:!0!==(null===(b=this.props.dataFull.config.cmd)||void 0===b?void 0:b.disable)?"pointer":"no-drop"}},null===(_=this.props.dataFull.config.default)||void 0===_?void 0:_.icondouble)):null))}}]),a}(n.Component);t.default=u},9:function(e,t,a){"use strict";a.r(t);var i=a(1),s=a(2),l=a(4),o=a(3),n=a(0),r=a.n(n),c=a(5),p=a(593),d=a(6),u=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var s;return Object(i.a)(this,a),(s=t.call(this,e)).abs_Focus=function(){s.ref_myModal&&s.ref_myModal.focus()},s.class_desktop="malibu-desktop-uModal",s.class_mobile="malibu-mobile-uModal",s.class_header_desktop="malibu-desktop-form-uModalHeader",s.class_header_mobile="malibu-mobile-form-uModalHeader",s.class_mobile_app="malibu-mobile_app-uModal",s.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",s.type_component="uModal",s.code_component="malibu.uModal",s.id_theme_component=Object(c.c)(),s.state={device:Object(c.f)(),class:"",skin_config:Object(p.configTemplate_getTheme)()},s}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?r.a.createElement("div",{className:this.class_desktop+""},r.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},r.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_desktop+" "},r.a.createElement("div",{className:this.class_header_desktop+"-header"},r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?r.a.createElement("div",{className:this.class_mobile+""},r.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile+" "},r.a.createElement("div",{className:this.class_header_mobile+"-header"},r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?r.a.createElement("div",{className:this.class_mobile_app+""},r.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile_app+" "},r.a.createElement("div",{className:this.class_header_mobile_app+"-header"},r.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u}}]);