(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[253,33,292,293,294,295,296,297,298,435,436],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return i}));var s=a(1313);function l(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function i(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?l(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):l(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},6:function(e,t,a){"use strict";a.r(t);var s=a(1312),l=a(1),i=a(2),o=a(4),n=a(3),r=a(0),d=a.n(r),p=a(9),c=a(5),u=function(e){Object(o.a)(a,e);var t=Object(n.a)(a);function a(e){var i;Object(l.a)(this,a);var o=(i=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===i.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none"}):"disable"===i.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"pointer"}),i.state={style:o,isZoom:!1,isOpenModal:!1},i}return Object(i.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),s=new Uint8Array(a),l=0;l<t.length;l++)s[l]=t.charCodeAt(l);return new Blob([s],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,l=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return d.a.createElement(d.a.Fragment,null,d.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=l.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==l.props.viewFile.file_type&&"txt"!==l.props.viewFile.file_type?!(null===(t=l.props.viewFile)||void 0===t?void 0:t.isView)&&l.props.isZoom&&!0!==l.state.isZoom&&l.setState({isZoom:!0}):!0!==l.state.isOpenModal&&l.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&d.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){l.setState({isOpenModal:!1})}}},d.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&d.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==l.state.isZoom&&l.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},d.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},d.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var i,o,n=this.props.val;return c.a.managerTemplate_isDev()?n=n.replace("../",c.a.managerTemplate_getUrlResource()):c.a.managerTemplate_isCordova()&&(n=n.replace("../",c.a.managerTemplate_getUrlCordova())),d.a.createElement(d.a.Fragment,null,d.a.createElement("img",{className:this.props.class?this.props.class:"",src:n,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=l.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==l.props.viewFile.file_type&&"txt"!==l.props.viewFile.file_type?!(null===(t=l.props.viewFile)||void 0===t?void 0:t.isView)&&l.props.isZoom&&!0!==l.state.isZoom&&l.setState({isZoom:!0}):!0!==l.state.isOpenModal&&l.setState({isOpenModal:!0})}}),(null===(i=this.props.viewFile)||void 0===i?void 0:i.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&d.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){l.setState({isOpenModal:!1})}}},d.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&d.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==l.state.isZoom&&l.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},d.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},d.a.createElement("img",{src:n,alt:this.props.title}))))}return d.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(c.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(r.Component);t.default=u},80:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),i=a(4),o=a(3),n=a(0),r=a.n(n),d=a(6),p=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var l;return Object(s.a)(this,a),(l=t.call(this,e)).class_desktop="malibu-desktop-uTableColumnEditInput",l.readOnly=!0,l.state={readOnly:l.readOnly,valueDefault:l.props.dataFull.data,isChange:!1,isChanged:!1},l}return Object(l.a)(a,[{key:"componentDidUpdate",value:function(e){void 0!==this.props.dataFull.data&&void 0!==e.dataFull.data&&this.props.dataFull.data!==e.dataFull.data&&(this.props.dataFull.data!==this.state.valueDefault&&this.state.isChanged?this.setState({isChange:!0}):this.setState({isChange:!1})),void 0!==this.props.dataFull.isUpdate&&this.props.dataFull.isUpdate!==e.dataFull.isUpdate&&!0===this.props.dataFull.isUpdate&&this.setState({isChange:!1,isChanged:!1,valueDefault:this.props.dataFull.data})}},{key:"render",value:function(){var e,t,a,s,l,i,o,n,p,c,u=this;return r.a.createElement("td",{className:"malibu-desktop-uTable-td malibu-uTableColumnEditInput-td"+((null===(e=this.props.dataFull.config)||void 0===e?void 0:e.isFrozen)?" frozen":""),"data-title":this.props.dataFull.title_parent},r.a.createElement("div",{className:"row malibu-uTableColumnEditInput-div"},r.a.createElement("div",{className:this.class_desktop},this.state.readOnly?r.a.createElement("div",{className:this.class_desktop+"-title"+(!1!==this.props.dataFull.hasChange&&this.state.isChange?" change":""),style:{textAlign:(null===(t=this.props.dataFull.default)||void 0===t?void 0:t.textAlign)||"left"},title:this.props.dataFull.data},this.props.dataFull.data):(null===(a=this.props.dataFull.config)||void 0===a?void 0:a.isResize)?r.a.createElement("textarea",{ref:function(e){u.myImgEdit=e},className:this.class_desktop+"-input"+(this.state.readOnly?"":" edit")+(!1!==this.props.dataFull.hasChange&&this.state.isChange?" change":""),value:this.props.dataFull.data||"",readOnly:this.state.readOnly,disabled:!!(null===(s=this.props.dataFull.cmd)||void 0===s?void 0:s.disable),onChange:function(e){var t;void 0===u.props.dataFull.abs_Change||u.readOnly||(null===(t=u.props.dataFull.cmd)||void 0===t?void 0:t.disable)||u.props.dataFull.abs_Change(e,u.props.dataFull.dataItem,u.props.dataFull.index_row,u.props.dataFull.index_col),u.setState({isChanged:!0})},onKeyDown:function(e){var t;void 0===u.props.dataFull.abs_KeyDown||u.readOnly||(null===(t=u.props.dataFull.cmd)||void 0===t?void 0:t.disable)||u.props.dataFull.abs_KeyDown(e,u.props.dataFull.dataItem,u.props.dataFull.index_row,u.props.dataFull.index_col)},onBlur:function(){u.setState({readOnly:!0},(function(){u.readOnly=!0,u.props.dataFull.abs_Submit&&u.props.dataFull.abs_Submit(u.props.dataFull.dataItem,u.props.dataFull.index_row,u.props.dataFull.index_col)}))},style:{width:this.state.readOnly?this.props.dataFull.data.length+3+"ch":"100%",background:(null===(l=this.props.dataFull.cmd)||void 0===l?void 0:l.disabled)?"rgba(227, 228, 229, 0.8)":"transparent",textAlign:(null===(i=this.props.dataFull.default)||void 0===i?void 0:i.textAlign)||"left"}},this.props.dataFull.data||""):r.a.createElement("input",{ref:function(e){u.myImgEdit=e},className:this.class_desktop+"-input"+(this.state.readOnly?"":" edit")+(!1!==this.props.dataFull.hasChange&&this.state.isChange?" change":""),value:this.props.dataFull.data||"",readOnly:this.state.readOnly,disabled:!!(null===(o=this.props.dataFull.cmd)||void 0===o?void 0:o.disable),onChange:function(e){var t;void 0===u.props.dataFull.abs_Change||u.readOnly||(null===(t=u.props.dataFull.cmd)||void 0===t?void 0:t.disable)||u.props.dataFull.abs_Change(e,u.props.dataFull.dataItem,u.props.dataFull.index_row,u.props.dataFull.index_col),u.setState({isChanged:!0})},onKeyDown:function(e){var t;void 0===u.props.dataFull.abs_KeyDown||u.readOnly||(null===(t=u.props.dataFull.cmd)||void 0===t?void 0:t.disable)||u.props.dataFull.abs_KeyDown(e,u.props.dataFull.dataItem,u.props.dataFull.index_row,u.props.dataFull.index_col)},onBlur:function(){u.setState({readOnly:!0},(function(){u.readOnly=!0,u.props.dataFull.abs_Submit&&u.props.dataFull.abs_Submit(u.props.dataFull.dataItem,u.props.dataFull.index_row,u.props.dataFull.index_col)}))},style:{width:this.state.readOnly?this.props.dataFull.data.length+3+"ch":"100%",background:(null===(n=this.props.dataFull.cmd)||void 0===n?void 0:n.disabled)?"rgba(227, 228, 229, 0.8)":"transparent",textAlign:(null===(p=this.props.dataFull.default)||void 0===p?void 0:p.textAlign)||"left"}}),!(null===(c=this.props.dataFull.cmd)||void 0===c?void 0:c.disable)&&r.a.createElement("div",{className:this.class_desktop+"-edit",onClick:function(){u.setState({readOnly:!1},(function(){var e;(u.readOnly=!1,void 0!==u.myImgEdit)&&(u.myImgEdit.focus(),(null===(e=u.props.dataFull.config)||void 0===e?void 0:e.isResize)&&u.myImgEdit.setSelectionRange(u.myImgEdit.value.length,u.myImgEdit.value.length))}))}},r.a.createElement(d.default,{val:"edit",style:{fontSize:"20px"},title:"edit"})))))}}]),a}(n.Component);t.default=p},9:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),i=a(4),o=a(3),n=a(0),r=a.n(n),d=a(5),p=a(593),c=a(6),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var l;return Object(s.a)(this,a),(l=t.call(this,e)).abs_Focus=function(){l.ref_myModal&&l.ref_myModal.focus()},l.class_desktop="malibu-desktop-uModal",l.class_mobile="malibu-mobile-uModal",l.class_header_desktop="malibu-desktop-form-uModalHeader",l.class_header_mobile="malibu-mobile-form-uModalHeader",l.class_mobile_app="malibu-mobile_app-uModal",l.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",l.type_component="uModal",l.code_component="malibu.uModal",l.id_theme_component=Object(d.c)(),l.state={device:Object(d.f)(),class:"",skin_config:Object(p.configTemplate_getTheme)()},l}return Object(l.a)(a,[{key:"componentWillUnmount",value:function(){Object(d.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(d.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?r.a.createElement("div",{className:this.class_desktop+""},r.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},r.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_desktop+" "},r.a.createElement("div",{className:this.class_header_desktop+"-header"},r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(c.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?r.a.createElement("div",{className:this.class_mobile+""},r.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile+" "},r.a.createElement("div",{className:this.class_header_mobile+"-header"},r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(c.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?r.a.createElement("div",{className:this.class_mobile_app+""},r.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile_app+" "},r.a.createElement("div",{className:this.class_header_mobile_app+"-header"},r.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(c.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u}}]);