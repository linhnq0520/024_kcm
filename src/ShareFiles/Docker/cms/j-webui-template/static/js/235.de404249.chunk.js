(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[235,33,292,293,294,295,296,297,298,435,436],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return i}));var s=a(1313);function l(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function i(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?l(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):l(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},23:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),d=a(593),p=a(6),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var l,i,o,n,c,p,u;Object(s.a)(this,a),(c=t.call(this,e)).abstract_changeDevice=function(e){c.setState({device:e})},c.abs_focus=function(){c.myButton.focus()},c.type_component="uCheckBox",c.code_component="malibu.uCheckBox",c.id_theme_component=Object(r.c)();var m=c.props.dataFull.value;switch(void 0===m&&(m=!1),c.class_desktop="malibu-desktop-uCheckBox",c.class_mobile="malibu-mobile-uCheckBox",m+""){case"false":p="check_box_outline_blank",u="black31";break;case"true":p="check_box",u="blueEC";break;case"-":p="indeterminate_check_box",u="blueEC"}return c._disable=null===(l=c.props.dataFull.config)||void 0===l||null===(i=l.cmd)||void 0===i?void 0:i.disable,c._lock=null===(o=c.props.dataFull.config)||void 0===o||null===(n=o.cmd)||void 0===n?void 0:n.isLock,c.state={device:Object(r.f)(),skin_config:Object(d.configTemplate_getTheme)(),val_checkbox:p,color_checkbox:u,isCheck:m,isChange:!1,isDisMount:"none"},c}return Object(l.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t,a,s,l;this._disable=null===(t=e.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.disable,this._lock=null===(s=this.props.dataFull.config)||void 0===s||null===(l=s.cmd)||void 0===l?void 0:l.isLock,this.props.dataFull.value!==e.dataFull.value&&(!0!==this.state.isChange?this.setState({isChange:!0}):!1!==this.state.isChange&&this.setState({isChange:!1}))}},{key:"check",value:function(){void 0!==this.props.dataFull.abs_Click&&this.props.dataFull.abs_Click(this.props.dataFull.dataItem,this.props.dataFull.value)}},{key:"getValueCheckBox",value:function(e){switch(e){case!0:return"check_box";case!1:return"check_box_outline_blank";default:return"indeterminate_check_box"}}},{key:"getColorCheckBox",value:function(e){switch(e){case!0:return"blueEC";case!1:return"black31";default:return"blueEC"}}},{key:"render",value:function(){var e,t,a,s,l,i,o,n,r,d,u,m,h,v,f,b,_,k,g,y,F,C,x,E,O,w,j,N,P,S,D,M,U,B,L,z,Z,I,T,V,K,R,A=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?!1!==(null===(e=this.props.dataFull.config)||void 0===e||null===(t=e.cmd)||void 0===t?void 0:t.visible)&&c.a.createElement("div",{className:this.class_desktop+"-"+(this.props.dataFull.class?"haveClass malibu-component-margin_top "+this.props.dataFull.class:"")},c.a.createElement("div",{className:this.class_desktop+(this.props.dataFull.title?" hasTitle":"")+((null===(a=this.props.dataFull.config)||void 0===a||null===(s=a.cmd)||void 0===s?void 0:s.disable)?" disable":"")+((null===(l=this.props.dataFull.config)||void 0===l||null===(i=l.cmd)||void 0===i||null===(o=i.error)||void 0===o?void 0:o.message)?" error":"")+(this.state.isChange?" change":"")+((null===(n=this.props.dataFull.config)||void 0===n||null===(r=n.cmd)||void 0===r?void 0:r.isLock)?" lock":""),onClick:function(e){e.preventDefault(),e.stopPropagation(),A._disable||A._lock||A.check()},onFocus:function(){(A._disable||A._lock)&&A.ref_myCheckBox.blur()},onKeyUp:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation(),A._disable||A._lock||A.check())},onKeyPress:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},onKeyDown:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},tabIndex:(null===(d=this.props.dataFull.config)||void 0===d||null===(u=d.cmd)||void 0===u?void 0:u.disable)||(null===(m=this.props.dataFull.config)||void 0===m||null===(h=m.cmd)||void 0===h?void 0:h.isLock)?-1:1,ref:function(e){A.ref_myCheckBox=e}},c.a.createElement(p.default,{val:this.getValueCheckBox(this.props.dataFull.value),isPointer:!(null===(v=this.props.dataFull.config)||void 0===v||null===(f=v.cmd)||void 0===f?void 0:f.disable)&&!(null===(b=this.props.dataFull.config)||void 0===b||null===(_=b.cmd)||void 0===_?void 0:_.isLock)||"disable",title:"check",class:" ",color:this.getColorCheckBox(this.props.dataFull.value)}),this.props.dataFull.title?c.a.createElement("div",{className:this.class_desktop+"-title"},this.props.dataFull.title):null),(null===(k=this.props.dataFull.config)||void 0===k||null===(g=k.cmd)||void 0===g||null===(y=g.error)||void 0===y?void 0:y.message)?c.a.createElement("div",{className:this.class_desktop+"-error-message"},null===(F=this.props.dataFull.config)||void 0===F?void 0:F.cmd.error.message):null):"mobile"===this.state.device?!1!==(null===(C=this.props.dataFull.config)||void 0===C||null===(x=C.cmd)||void 0===x?void 0:x.visible)&&c.a.createElement("div",{className:this.class_desktop+"-"+(this.props.dataFull.class?"haveClass malibu-component-margin_top col-12"+this.props.dataFull.class:"")},c.a.createElement("div",{className:this.class_desktop+(this.props.dataFull.title?" hasTitle col-12":"")+((null===(E=this.props.dataFull.config)||void 0===E||null===(O=E.cmd)||void 0===O?void 0:O.disable)?" disable":"")+((null===(w=this.props.dataFull.config)||void 0===w||null===(j=w.cmd)||void 0===j||null===(N=j.error)||void 0===N?void 0:N.message)?" error":"")+(this.state.isChange?" change":"")+((null===(P=this.props.dataFull.config)||void 0===P||null===(S=P.cmd)||void 0===S?void 0:S.isLock)?" lock":""),onClick:function(e){e.preventDefault(),e.stopPropagation(),A._disable||A._lock||A.check()},onFocus:function(){(A._disable||A._lock)&&A.ref_myCheckBox.blur()},onKeyUp:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation(),A._disable||A._lock||A.check())},onKeyPress:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},onKeyDown:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},tabIndex:(null===(D=this.props.dataFull.config)||void 0===D||null===(M=D.cmd)||void 0===M?void 0:M.disable)||(null===(U=this.props.dataFull.config)||void 0===U||null===(B=U.cmd)||void 0===B?void 0:B.isLock)?-1:1,ref:function(e){A.ref_myCheckBox=e}},c.a.createElement(p.default,{val:this.getValueCheckBox(this.props.dataFull.value),isPointer:!(null===(L=this.props.dataFull.config)||void 0===L||null===(z=L.cmd)||void 0===z?void 0:z.disable)&&!(null===(Z=this.props.dataFull.config)||void 0===Z||null===(I=Z.cmd)||void 0===I?void 0:I.isLock)||"disable",title:"check",class:" ",color:this.getColorCheckBox(this.props.dataFull.value)}),this.props.dataFull.title?c.a.createElement("div",{className:this.class_mobile+"-title"},this.props.dataFull.title):null),(null===(T=this.props.dataFull.config)||void 0===T||null===(V=T.cmd)||void 0===V||null===(K=V.error)||void 0===K?void 0:K.message)?c.a.createElement("div",{className:this.class_desktop+"-error-message"},null===(R=this.props.dataFull.config)||void 0===R?void 0:R.cmd.error.message):null):void 0}}]),a}(n.Component);t.default=u},6:function(e,t,a){"use strict";a.r(t);var s=a(1312),l=a(1),i=a(2),o=a(4),n=a(3),c=a(0),r=a.n(c),d=a(9),p=a(5),u=function(e){Object(o.a)(a,e);var t=Object(n.a)(a);function a(e){var i;Object(l.a)(this,a);var o=(i=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===i.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none"}):"disable"===i.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"pointer"}),i.state={style:o,isZoom:!1,isOpenModal:!1},i}return Object(i.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),s=new Uint8Array(a),l=0;l<t.length;l++)s[l]=t.charCodeAt(l);return new Blob([s],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,l=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=l.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==l.props.viewFile.file_type&&"txt"!==l.props.viewFile.file_type?!(null===(t=l.props.viewFile)||void 0===t?void 0:t.isView)&&l.props.isZoom&&!0!==l.state.isZoom&&l.setState({isZoom:!0}):!0!==l.state.isOpenModal&&l.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(d.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){l.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==l.state.isZoom&&l.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var i,o,n=this.props.val;return p.a.managerTemplate_isDev()?n=n.replace("../",p.a.managerTemplate_getUrlResource()):p.a.managerTemplate_isCordova()&&(n=n.replace("../",p.a.managerTemplate_getUrlCordova())),r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:n,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=l.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==l.props.viewFile.file_type&&"txt"!==l.props.viewFile.file_type?!(null===(t=l.props.viewFile)||void 0===t?void 0:t.isView)&&l.props.isZoom&&!0!==l.state.isZoom&&l.setState({isZoom:!0}):!0!==l.state.isOpenModal&&l.setState({isOpenModal:!0})}}),(null===(i=this.props.viewFile)||void 0===i?void 0:i.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(d.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){l.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==l.state.isZoom&&l.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:n,alt:this.props.title}))))}return r.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(p.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(c.Component);t.default=u},9:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),d=a(593),p=a(6),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var l;return Object(s.a)(this,a),(l=t.call(this,e)).abs_Focus=function(){l.ref_myModal&&l.ref_myModal.focus()},l.class_desktop="malibu-desktop-uModal",l.class_mobile="malibu-mobile-uModal",l.class_header_desktop="malibu-desktop-form-uModalHeader",l.class_header_mobile="malibu-mobile-form-uModalHeader",l.class_mobile_app="malibu-mobile_app-uModal",l.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",l.type_component="uModal",l.code_component="malibu.uModal",l.id_theme_component=Object(r.c)(),l.state={device:Object(r.f)(),class:"",skin_config:Object(d.configTemplate_getTheme)()},l}return Object(l.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?c.a.createElement("div",{className:this.class_desktop+""},c.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},c.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},c.a.createElement("div",{className:this.class_header_desktop+" "},c.a.createElement("div",{className:this.class_header_desktop+"-header"},c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),c.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},c.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),c.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?c.a.createElement("div",{className:this.class_mobile+""},c.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},c.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},c.a.createElement("div",{className:this.class_header_mobile+" "},c.a.createElement("div",{className:this.class_header_mobile+"-header"},c.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),c.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),c.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},c.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),c.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?c.a.createElement("div",{className:this.class_mobile_app+""},c.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},c.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},c.a.createElement("div",{className:this.class_header_mobile_app+" "},c.a.createElement("div",{className:this.class_header_mobile_app+"-header"},c.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),c.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},c.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),c.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u}}]);