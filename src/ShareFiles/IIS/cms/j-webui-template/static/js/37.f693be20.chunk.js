(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[37,33,246,292,293,294,295,296,297,298,393,435,436,560],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return i}));var l=a(1313);function s(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var l=Object.getOwnPropertySymbols(e);t&&(l=l.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,l)}return a}function i(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?s(Object(a),!0).forEach((function(t){Object(l.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):s(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function l(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return l}))},14:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),d=a(593),p=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s,i;return Object(l.a)(this,a),(s=t.call(this,e)).abstract_changeDevice=function(e){s.setState({device:e})},s.type_component="uFormLoading",s.code_component="malibu.uFormLoading",s.id_theme_component=Object(r.c)(),i=void 0===s.props.time_out?1e4:s.props.time_out,s.state={device:Object(r.f)(),skin_config:Object(d.configTemplate_getTheme)(),time_out:i},s}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"render",value:function(){return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?c.a.createElement(c.a.Fragment,null,c.a.createElement("div",{className:"malibu-desktop-uFormLoading ",style:{display:"flex",alignItems:"center",height:"100%",justifyContent:"center",position:"fixed",paddingBottom:"120px",background:"transparent",zIndex:"98",cursor:"wait"}},c.a.createElement("div",null,c.a.createElement("div",{className:"onclic-loading"})))):void 0}}]),a}(n.Component);t.default=p},15:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),d=a(593),p=a(14),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s;Object(l.a)(this,a),(s=t.call(this,e)).abstract_changeDevice=function(e){s.setState({device:e})},s.class_desktop="malibu-desktop-uForm",s.type_component="uForm",s.code_component="malibu.uForm",s.id_theme_component=Object(r.c)();var i=s.props.sysStyle;return void 0===i&&(i={show:""}),s.state={device:Object(r.f)(),skin_config:Object(d.configTemplate_getTheme)(),sysStyle:i,isDisMount:"none"},s}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"componentDidUpdate",value:function(e){void 0!==this.props.sysStyle&&(void 0===e.sysStyle||this.props.sysStyle.show!==e.sysStyle.show)&&this.setState({sysStyle:this.props.sysStyle})}},{key:"renderForDevice",value:function(){var e,t,a,l,s,i,o;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?c.a.createElement("div",{className:this.class_desktop+" "+(this.props.class?this.props.class:"col-12"),style:{display:this.props.dataFull.cmd.visibility}},(null===(e=this.props.dataFull)||void 0===e||null===(t=e.config)||void 0===t||null===(a=t.default)||void 0===a?void 0:a.title)&&"mobile"!==this.state.device?c.a.createElement("div",{className:this.class_desktop+"-title"},this.props.dataFull.config.default.title):null,(null===(l=this.props.dataFull)||void 0===l||null===(s=l.config)||void 0===s||null===(i=s.default)||void 0===i?void 0:i.title_sub)&&"mobile"!==this.state.device?c.a.createElement("div",{className:this.class_desktop+"-title-sub"},this.props.dataFull.config.default.title_sub):null,c.a.createElement("div",{className:this.class_desktop+"-content ",style:{paddingTop:this.props.dataFull.config.default.title?"28px":""}},(null===(o=this.props.dataFull.cmd)||void 0===o?void 0:o.isLoading)?c.a.createElement(p.default,null):null,this.props.children)):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u},183:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),d=a(593),p=a(6),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s,i,o,n,c,p,u;Object(l.a)(this,a),(c=t.call(this,e)).abstract_changeDevice=function(e){c.setState({device:e})},c.abs_focus=function(){c.myButton.focus()},c.type_component="uRadioButton",c.code_component="malibu.uRadioButton",c.id_theme_component=Object(r.c)();var m=c.props.dataFull.value;switch(void 0===m&&(m=!1),c.class_desktop="malibu-desktop-uRadioButton",m+""){case"false":p="radio_button_unchecked",u="black31";break;case"true":p="radio_button_checked",u="blueEC";break;default:p="radio_button_unchecked",u="black31"}return c._disable=null===(s=c.props.dataFull.config)||void 0===s||null===(i=s.cmd)||void 0===i?void 0:i.disable,c._lock=null===(o=c.props.dataFull.config)||void 0===o||null===(n=o.cmd)||void 0===n?void 0:n.isLock,c.state={device:Object(r.f)(),skin_config:Object(d.configTemplate_getTheme)(),val_checkbox:p,color_checkbox:u,isCheck:m,isChange:!1,isDisMount:"none"},c}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t,a,l,s;this._disable=null===(t=e.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.disable,this._lock=null===(l=this.props.dataFull.config)||void 0===l||null===(s=l.cmd)||void 0===s?void 0:s.isLock,this.props.dataFull.value!==e.dataFull.value&&(!0!==this.state.isChange?this.setState({isChange:!0}):!1!==this.state.isChange&&this.setState({isChange:!1}))}},{key:"check",value:function(){void 0!==this.props.dataFull.abs_Click&&this.props.dataFull.abs_Click(this.props.dataFull.dataItem,this.props.dataFull.value)}},{key:"getValueCheckBox",value:function(e){switch(e){case!0:return"radio_button_checked";case!1:default:return"radio_button_unchecked"}}},{key:"getColorCheckBox",value:function(e){switch(e){case!0:return"blueEC";case!1:return"black31";default:return"blueEC"}}},{key:"render",value:function(){var e,t,a,l,s,i,o,n,r,d,u,m,h,v,f,b,_,g,k,y,F,E=this;return!1!==(null===(e=this.props.dataFull.config)||void 0===e||null===(t=e.cmd)||void 0===t?void 0:t.visible)&&c.a.createElement("div",{className:this.class_desktop+"-"+(this.props.dataFull.class?"haveClass malibu-component-margin_top "+this.props.dataFull.class:"")},c.a.createElement("div",{className:this.class_desktop+(this.props.dataFull.title?" hasTitle":"")+((null===(a=this.props.dataFull.config)||void 0===a||null===(l=a.cmd)||void 0===l?void 0:l.disable)?" disable":"")+((null===(s=this.props.dataFull.config)||void 0===s||null===(i=s.cmd)||void 0===i||null===(o=i.error)||void 0===o?void 0:o.message)?" error":"")+(this.state.isChange?" change":"")+((null===(n=this.props.dataFull.config)||void 0===n||null===(r=n.cmd)||void 0===r?void 0:r.isLock)?" lock":""),onClick:function(e){e.preventDefault(),e.stopPropagation(),E._disable||E._lock||E.check()},onFocus:function(){(E._disable||E._lock)&&E.ref_myCheckBox.blur()},onKeyUp:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation(),E._disable||E._lock||E.check())},onKeyPress:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},onKeyDown:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},tabIndex:(null===(d=this.props.dataFull.config)||void 0===d||null===(u=d.cmd)||void 0===u?void 0:u.disable)||(null===(m=this.props.dataFull.config)||void 0===m||null===(h=m.cmd)||void 0===h?void 0:h.isLock)?-1:1,ref:function(e){E.ref_myCheckBox=e}},c.a.createElement(p.default,{val:this.getValueCheckBox(this.props.dataFull.value),isPointer:!(null===(v=this.props.dataFull.config)||void 0===v||null===(f=v.cmd)||void 0===f?void 0:f.disable)&&!(null===(b=this.props.dataFull.config)||void 0===b||null===(_=b.cmd)||void 0===_?void 0:_.isLock)||"disable",title:"check",class:"-round",color:this.getColorCheckBox(this.props.dataFull.value)}),this.props.dataFull.title?c.a.createElement("div",{className:this.class_desktop+"-title"},this.props.dataFull.title):null),(null===(g=this.props.dataFull.config)||void 0===g||null===(k=g.cmd)||void 0===k||null===(y=k.error)||void 0===y?void 0:y.message)?c.a.createElement("div",{className:this.class_desktop+"-error-message"},null===(F=this.props.dataFull.config)||void 0===F?void 0:F.cmd.error.message):null)}}]),a}(n.Component);t.default=u},337:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(183),d=a(15),p=a(28),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s;return Object(l.a)(this,a),(s=t.call(this,e)).test=function(){s.setState({value:!s.state.value})},s.state={value:!1},s}return Object(s.a)(a,[{key:"render",value:function(){return c.a.createElement(d.default,{dataFull:{config:{default:{title:"Test Radio"}},cmd:{visibility:""}}},c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p c\xf3 title")),c.a.createElement(r.default,{dataFull:{value:this.state.value,title:"is Check",abs_Click:this.test}}),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p kh\xf4ng c\xf3 title")),c.a.createElement(r.default,{dataFull:{value:!0}}),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p disable")),c.a.createElement(r.default,{dataFull:{value:!0,title:"is Check",config:{cmd:{disable:!0}}}}),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p lock")),c.a.createElement(r.default,{dataFull:{value:!0,title:"is Check",config:{cmd:{disable:!1,isLock:!0}}}}),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p error")),c.a.createElement(r.default,{dataFull:{value:!1,title:"is Check",config:{cmd:{disable:!1,error:{message:"error message",type:""}}}}}),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p c\xf3 title v\xe0 class")),c.a.createElement(r.default,{dataFull:{value:!0,title:"is Check",class:"col-4"}}),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p n\u1eb1m b\xean ph\u1ea3i 1 uInput or uSelectItem")),c.a.createElement("div",{className:"row"}," ",c.a.createElement(p.default,{dataFull:{config:{default:{search:{placeholder:"Search"},data_status:"No Result",title:"Office",class:"col-md-2 offset-md-1-right",required:!0},cmd:{disable:!1,visible:!0,isFocus:!1,error:{message:"",type:""}},mode:{}},data:[],search_value:""},abs_Change:this.test1,abs_search:this.search}),c.a.createElement(r.default,{dataFull:{value:!1,title:"1234",class:"col-sm-4",config:{cmd:{disable:!1}}}})),c.a.createElement("p",null,c.a.createElement("b",null,"Tr\u01b0\u1eddng h\u1ee3p 2 uCheckBox")),c.a.createElement("div",{className:"row"}," ",c.a.createElement(r.default,{dataFull:{value:!1,title:"1234",class:"col-sm-2",config:{cmd:{disable:!1}}}}),c.a.createElement(r.default,{dataFull:{value:!0,title:"1234",class:"col-sm-2",config:{cmd:{disable:!1}}}})))}}]),a}(n.Component);t.default=u},6:function(e,t,a){"use strict";a.r(t);var l=a(1312),s=a(1),i=a(2),o=a(4),n=a(3),c=a(0),r=a.n(c),d=a(9),p=a(5),u=function(e){Object(o.a)(a,e);var t=Object(n.a)(a);function a(e){var i;Object(s.a)(this,a);var o=(i=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===i.props.isPointer?Object(l.a)(Object(l.a)({},o),{},{userSelect:"none"}):"disable"===i.props.isPointer?Object(l.a)(Object(l.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(l.a)(Object(l.a)({},o),{},{userSelect:"none",cursor:"pointer"}),i.state={style:o,isZoom:!1,isOpenModal:!1},i}return Object(i.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(l.a)(Object(l.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(l.a)(Object(l.a)({},t),{},{cursor:"default"}):Object(l.a)(Object(l.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),l=new Uint8Array(a),s=0;s<t.length;s++)l[s]=t.charCodeAt(s);return new Blob([l],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,s=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(l.a)(Object(l.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=s.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==s.props.viewFile.file_type&&"txt"!==s.props.viewFile.file_type?!(null===(t=s.props.viewFile)||void 0===t?void 0:t.isView)&&s.props.isZoom&&!0!==s.state.isZoom&&s.setState({isZoom:!0}):!0!==s.state.isOpenModal&&s.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(d.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){s.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==s.state.isZoom&&s.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var i,o,n=this.props.val;return p.a.managerTemplate_isDev()?n=n.replace("../",p.a.managerTemplate_getUrlResource()):p.a.managerTemplate_isCordova()&&(n=n.replace("../",p.a.managerTemplate_getUrlCordova())),r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:n,alt:this.props.title,style:Object(l.a)(Object(l.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=s.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==s.props.viewFile.file_type&&"txt"!==s.props.viewFile.file_type?!(null===(t=s.props.viewFile)||void 0===t?void 0:t.isView)&&s.props.isZoom&&!0!==s.state.isZoom&&s.setState({isZoom:!0}):!0!==s.state.isOpenModal&&s.setState({isOpenModal:!0})}}),(null===(i=this.props.viewFile)||void 0===i?void 0:i.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(d.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){s.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==s.state.isZoom&&s.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:n,alt:this.props.title}))))}return r.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(p.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(c.Component);t.default=u},9:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),d=a(593),p=a(6),u=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s;return Object(l.a)(this,a),(s=t.call(this,e)).abs_Focus=function(){s.ref_myModal&&s.ref_myModal.focus()},s.class_desktop="malibu-desktop-uModal",s.class_mobile="malibu-mobile-uModal",s.class_header_desktop="malibu-desktop-form-uModalHeader",s.class_header_mobile="malibu-mobile-form-uModalHeader",s.class_mobile_app="malibu-mobile_app-uModal",s.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",s.type_component="uModal",s.code_component="malibu.uModal",s.id_theme_component=Object(r.c)(),s.state={device:Object(r.f)(),class:"",skin_config:Object(d.configTemplate_getTheme)()},s}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?c.a.createElement("div",{className:this.class_desktop+""},c.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},c.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},c.a.createElement("div",{className:this.class_header_desktop+" "},c.a.createElement("div",{className:this.class_header_desktop+"-header"},c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),c.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},c.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),c.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?c.a.createElement("div",{className:this.class_mobile+""},c.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},c.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},c.a.createElement("div",{className:this.class_header_mobile+" "},c.a.createElement("div",{className:this.class_header_mobile+"-header"},c.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),c.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),c.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),c.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},c.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),c.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?c.a.createElement("div",{className:this.class_mobile_app+""},c.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},c.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},c.a.createElement("div",{className:this.class_header_mobile_app+" "},c.a.createElement("div",{className:this.class_header_mobile_app+"-header"},c.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),c.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},c.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),c.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u}}]);