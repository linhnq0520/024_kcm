(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[156,33,212,292,293,294,295,296,297,298,435,436,741],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return l}));var s=a(1313);function i(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function l(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?i(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):i(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},232:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),l=a(4),o=a(3),n=a(0),r=a.n(n),c=a(69),p=a(6),d=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).listKey={},i.state={isEdit:!1,isFocus:!1},i}return Object(i.a)(a,[{key:"render",value:function(){var e,t,a,s,i,l,o,n,d,u,m,h=this;return r.a.createElement("td",{className:"malibu-desktop-uTable-td"+((null===(e=this.props.dataFull.config)||void 0===e?void 0:e.isFrozen)?" frozen":"")+" malibu-desktop-uTableColumnKeyBoardEdit row"+((null===(t=this.props.dataFull.config)||void 0===t||null===(a=t.default)||void 0===a?void 0:a.isEdit)?" malibu-edit":""),"data-title":this.props.dataFull.title_parent},(null===(s=this.props.dataFull.config)||void 0===s||null===(i=s.default)||void 0===i?void 0:i.isEdit)?r.a.createElement(r.a.Fragment,null,r.a.createElement("div",{className:"malibu-desktop-uTableColumnKeyBoardEdit-border"},r.a.createElement(c.default,{dataFull:{data:this.props.dataFull.data}}),r.a.createElement("input",{className:"malibu-desktop-uTableColumnKeyBoardEdit-input"+(this.state.isFocus?" malibu-focus":""),value:"",ref:function(e){h.ref_myInput=e},onChange:function(e){h.props.dataFull.abs_Change(e,h.props.dataFull.dataItem)},onKeyDown:function(e){(h.listKey||0===h.listKey.length)&&(h.listKey={}),h.listKey[e.keyCode]=!0,h.props.dataFull.abs_KeyDown(e,h.props.dataFull.dataItem)},onKeyUp:function(e){delete h.listKey[e.keyCode],0===Object.keys(h.listKey).length&&h.setState({isFocus:!1},(function(){h.ref_myInput.blur()})),h.props.dataFull.abs_KeyUp(e,h.props.dataFull.dataItem)},onKeyPress:function(e){h.props.dataFull.abs_KeyPress(e,h.props.dataFull.dataItem)},onFocus:function(){h.setState({isFocus:!0})},onBlur:function(){h.setState({isFocus:!1})}})),r.a.createElement("div",{className:"malibu-desktop-uTableColumnKeyBoardEdit-icon malibu-icon-cancel",onClick:function(){h.props.dataFull.abs_Cancel(h.props.dataFull.dataItem),h.setState({isEdit:!1})}},r.a.createElement(p.default,{val:"close",style:{width:"28px",height:"28px",fontSize:"28px"}})),r.a.createElement("div",{className:"malibu-desktop-uTableColumnKeyBoardEdit-icon malibu-icon-done",onClick:function(){h.props.dataFull.abs_Submit(h.props.dataFull.dataItem),h.setState({isEdit:!1})}},r.a.createElement(p.default,{val:"done",style:{width:"28px",height:"28px",fontSize:"28px"}})),(null===(l=this.props.dataFull.config)||void 0===l||null===(o=l.cmd)||void 0===o||null===(n=o.error)||void 0===n?void 0:n.message)&&r.a.createElement("div",{className:"malibu-desktop-uTableColumnKeyBoardEdit-error-message"},null===(d=this.props.dataFull.config)||void 0===d||null===(u=d.cmd)||void 0===u||null===(m=u.error)||void 0===m?void 0:m.message)):r.a.createElement(r.a.Fragment,null,r.a.createElement(c.default,{dataFull:{data:this.props.dataFull.data}})," ",r.a.createElement("div",{className:"malibu-desktop-uTableColumnKeyBoardEdit-btn_edit",onClick:function(){h.props.dataFull.abs_Edit(h.props.dataFull.dataItem),h.setState({isEdit:!0})}},this.props.dataFull.btn_edit)))}}]),a}(n.Component);t.default=d},6:function(e,t,a){"use strict";a.r(t);var s=a(1312),i=a(1),l=a(2),o=a(4),n=a(3),r=a(0),c=a.n(r),p=a(9),d=a(5),u=function(e){Object(o.a)(a,e);var t=Object(n.a)(a);function a(e){var l;Object(i.a)(this,a);var o=(l=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===l.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none"}):"disable"===l.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"pointer"}),l.state={style:o,isZoom:!1,isOpenModal:!1},l}return Object(l.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),s=new Uint8Array(a),i=0;i<t.length;i++)s[i]=t.charCodeAt(i);return new Blob([s],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,i=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return c.a.createElement(c.a.Fragment,null,c.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=i.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==i.props.viewFile.file_type&&"txt"!==i.props.viewFile.file_type?!(null===(t=i.props.viewFile)||void 0===t?void 0:t.isView)&&i.props.isZoom&&!0!==i.state.isZoom&&i.setState({isZoom:!0}):!0!==i.state.isOpenModal&&i.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&c.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){i.setState({isOpenModal:!1})}}},c.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==i.state.isZoom&&i.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},c.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var l,o,n=this.props.val;return d.a.managerTemplate_isDev()?n=n.replace("../",d.a.managerTemplate_getUrlResource()):d.a.managerTemplate_isCordova()&&(n=n.replace("../",d.a.managerTemplate_getUrlCordova())),c.a.createElement(c.a.Fragment,null,c.a.createElement("img",{className:this.props.class?this.props.class:"",src:n,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=i.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==i.props.viewFile.file_type&&"txt"!==i.props.viewFile.file_type?!(null===(t=i.props.viewFile)||void 0===t?void 0:t.isView)&&i.props.isZoom&&!0!==i.state.isZoom&&i.setState({isZoom:!0}):!0!==i.state.isOpenModal&&i.setState({isOpenModal:!0})}}),(null===(l=this.props.viewFile)||void 0===l?void 0:l.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&c.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){i.setState({isOpenModal:!1})}}},c.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==i.state.isZoom&&i.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},c.a.createElement("img",{src:n,alt:this.props.title}))))}return c.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(d.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(r.Component);t.default=u},641:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),l=a(4),o=a(3),n=a(0),r=a.n(n),c=a(5),p=a(6),d=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abstract_changeDevice=function(e){i.setState({device:e})},i.type_component="uKeyBoardItem",i.code_component="malibu.uKeyBoardItem",i.class_desktop="malibu-desktop-uKeyBoardItem",i.id_theme_component=Object(c.c)(),i.state={device:Object(c.f)()},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?r.a.createElement("div",{className:this.class_desktop+(this.props.icon?" malibu-icon":"")},this.props.icon&&r.a.createElement(p.default,{val:this.props.icon,style:{width:"14px",height:"14px",fontSize:"14px"},isPointer:!1}),this.props.title&&r.a.createElement("div",null,this.props.title)):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=d},69:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),l=a(4),o=a(3),n=a(0),r=a.n(n),c=a(5),p=a(641),d=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abstract_changeDevice=function(e){i.setState({device:e})},i.type_component="uKeyBoardGroup",i.code_component="malibu.uKeyBoardGroup",i.class_desktop="malibu-desktop-uKeyBoardGroup",i.id_theme_component=Object(c.c)(),i.state={device:Object(c.f)()},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?r.a.createElement("div",{className:this.class_desktop+" row"},this.props.dataFull.data.map((function(e,t){return r.a.createElement(p.default,Object.assign({key:t},e))}))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=d},9:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),l=a(4),o=a(3),n=a(0),r=a.n(n),c=a(5),p=a(593),d=a(6),u=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abs_Focus=function(){i.ref_myModal&&i.ref_myModal.focus()},i.class_desktop="malibu-desktop-uModal",i.class_mobile="malibu-mobile-uModal",i.class_header_desktop="malibu-desktop-form-uModalHeader",i.class_header_mobile="malibu-mobile-form-uModalHeader",i.class_mobile_app="malibu-mobile_app-uModal",i.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",i.type_component="uModal",i.code_component="malibu.uModal",i.id_theme_component=Object(c.c)(),i.state={device:Object(c.f)(),class:"",skin_config:Object(p.configTemplate_getTheme)()},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?r.a.createElement("div",{className:this.class_desktop+""},r.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},r.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_desktop+" "},r.a.createElement("div",{className:this.class_header_desktop+"-header"},r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?r.a.createElement("div",{className:this.class_mobile+""},r.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile+" "},r.a.createElement("div",{className:this.class_header_mobile+"-header"},r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?r.a.createElement("div",{className:this.class_mobile_app+""},r.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile_app+" "},r.a.createElement("div",{className:this.class_header_mobile_app+"-header"},r.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u}}]);