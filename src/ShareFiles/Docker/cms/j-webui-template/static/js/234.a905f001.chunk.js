(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[234,33,292,293,294,295,296,297,298,435,436],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return l}));var s=a(1313);function i(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function l(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?i(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):i(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},179:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),l=a(4),o=a(3),c=a(0),n=a.n(c),r=a(5),p=a(593),d=a(6),m=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abstract_changeDevice=function(e){i.setState({device:e})},i.type_component="uChangeLang",i.code_component="malibu.uChangeLang",i.class_desktop="malibu-desktop-uChangeLang",i.class_tablet="malibu-tablet-uChangeLang",i.class_mobile="malibu-mobile-uChangeLang",i.id_theme_component=Object(r.c)(),i.state={device:Object(r.f)(),skin_config:Object(p.configTemplate_getTheme)(),isDisMount:"none"},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device?n.a.createElement("div",{className:this.class_desktop},n.a.createElement("div",{className:this.class_desktop+"-menu"},this.props.dataFull.data.map((function(t,a){return n.a.createElement("div",{className:e.class_desktop+"-item"+(t.selected?" choose":""),key:a,onClick:function(a){t.selected||void 0!==e.props.dataFull.abs_Click&&e.props.dataFull.abs_Click(t.dataItem)}},n.a.createElement("div",{className:e.class_desktop+"-item-img"},n.a.createElement(d.default,{val:t.img,style:{width:"60px",height:"60px",fontSize:"60px",objectFit:"cover",objectPosition:"center"},isPointer:!t.selected})),n.a.createElement("div",{className:e.class_desktop+"-item-title-div"},n.a.createElement("div",{className:e.class_desktop+"-item-title"},t.title)))})))):"tablet"===this.state.device?n.a.createElement("div",{className:this.class_tablet},n.a.createElement("div",{className:this.class_tablet+"-menu"},this.props.dataFull.data.map((function(t,a){return n.a.createElement("div",{className:e.class_tablet+"-item"+(t.selected?" choose":""),key:a,onClick:function(a){t.selected||void 0!==e.props.dataFull.abs_Click&&e.props.dataFull.abs_Click(t.dataItem)}},n.a.createElement("div",{className:e.class_tablet+"-item-img"},n.a.createElement(d.default,{val:t.img,style:{width:"60px",height:"60px",fontSize:"60px",borderRadius:"50%",margin:"0px auto"},isPointer:!t.selected})),n.a.createElement("div",{className:e.class_tablet+"-item-title-div"},n.a.createElement("div",{className:e.class_tablet+"-item-title"},t.title)))})))):"mobile"===this.state.device?n.a.createElement("div",{className:this.class_mobile},n.a.createElement("div",{className:this.class_mobile+"-menu"},this.props.dataFull.data.map((function(t,a){return n.a.createElement("div",{className:e.class_mobile+"-item row"+(t.selected?" choose":""),key:a,onClick:function(a){t.selected||void 0!==e.props.dataFull.abs_Click&&e.props.dataFull.abs_Click(t.dataItem)}},n.a.createElement("div",{className:e.class_mobile+"-item-img"},n.a.createElement(d.default,{val:t.img,style:{width:"20px",height:"20px",fontSize:"20px",borderRadius:"50%",margin:"0px auto"},isPointer:!t.selected})),n.a.createElement("div",{className:e.class_mobile+"-item-title-div"},n.a.createElement("div",{className:e.class_mobile+"-item-title"},t.title)),t.selected&&n.a.createElement(d.default,{val:"done",style:{marginLeft:"auto",fontSize:"20px"}}))})))):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(c.Component);t.default=m},6:function(e,t,a){"use strict";a.r(t);var s=a(1312),i=a(1),l=a(2),o=a(4),c=a(3),n=a(0),r=a.n(n),p=a(9),d=a(5),m=function(e){Object(o.a)(a,e);var t=Object(c.a)(a);function a(e){var l;Object(i.a)(this,a);var o=(l=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===l.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none"}):"disable"===l.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"pointer"}),l.state={style:o,isZoom:!1,isOpenModal:!1},l}return Object(l.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),s=new Uint8Array(a),i=0;i<t.length;i++)s[i]=t.charCodeAt(i);return new Blob([s],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,i=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=i.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==i.props.viewFile.file_type&&"txt"!==i.props.viewFile.file_type?!(null===(t=i.props.viewFile)||void 0===t?void 0:t.isView)&&i.props.isZoom&&!0!==i.state.isZoom&&i.setState({isZoom:!0}):!0!==i.state.isOpenModal&&i.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){i.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==i.state.isZoom&&i.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var l,o,c=this.props.val;return d.a.managerTemplate_isDev()?c=c.replace("../",d.a.managerTemplate_getUrlResource()):d.a.managerTemplate_isCordova()&&(c=c.replace("../",d.a.managerTemplate_getUrlCordova())),r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:c,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=i.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==i.props.viewFile.file_type&&"txt"!==i.props.viewFile.file_type?!(null===(t=i.props.viewFile)||void 0===t?void 0:t.isView)&&i.props.isZoom&&!0!==i.state.isZoom&&i.setState({isZoom:!0}):!0!==i.state.isOpenModal&&i.setState({isOpenModal:!0})}}),(null===(l=this.props.viewFile)||void 0===l?void 0:l.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){i.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==i.state.isZoom&&i.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:c,alt:this.props.title}))))}return r.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(d.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(n.Component);t.default=m},9:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),l=a(4),o=a(3),c=a(0),n=a.n(c),r=a(5),p=a(593),d=a(6),m=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abs_Focus=function(){i.ref_myModal&&i.ref_myModal.focus()},i.class_desktop="malibu-desktop-uModal",i.class_mobile="malibu-mobile-uModal",i.class_header_desktop="malibu-desktop-form-uModalHeader",i.class_header_mobile="malibu-mobile-form-uModalHeader",i.class_mobile_app="malibu-mobile_app-uModal",i.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",i.type_component="uModal",i.code_component="malibu.uModal",i.id_theme_component=Object(r.c)(),i.state={device:Object(r.f)(),class:"",skin_config:Object(p.configTemplate_getTheme)()},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?n.a.createElement("div",{className:this.class_desktop+""},n.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},n.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},n.a.createElement("div",{className:this.class_header_desktop+" "},n.a.createElement("div",{className:this.class_header_desktop+"-header"},n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),n.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},n.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),n.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?n.a.createElement("div",{className:this.class_mobile+""},n.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},n.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},n.a.createElement("div",{className:this.class_header_mobile+" "},n.a.createElement("div",{className:this.class_header_mobile+"-header"},n.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),n.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),n.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},n.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),n.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?n.a.createElement("div",{className:this.class_mobile_app+""},n.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},n.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},n.a.createElement("div",{className:this.class_header_mobile_app+" "},n.a.createElement("div",{className:this.class_header_mobile_app+"-header"},n.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),n.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},n.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),n.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(c.Component);t.default=m}}]);