(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[39,33,220,261,292,293,294,295,296,297,298,435,436],{101:function(e,t,a){"use strict";a.r(t);var s=a(1312),o=a(1),i=a(2),l=a(4),n=a(3),r=a(0),c=a.n(r),p=a(5),d=a(593),u=a(59),m=a(1348),h=a.n(m),f=a(1349),v=a.n(f),b=a(1351),_=a.n(b),F=function(e){Object(l.a)(a,e);var t=Object(n.a)(a);function a(e){var s;return Object(o.a)(this,a),(s=t.call(this,e)).abstract_changeDevice=function(e){s.setState({device:e})},s.abs_ClickTooltip=function(e){void 0!==s.props.dataFull.abs_Copy&&s.props.dataFull.abs_Copy(e)},s.type_component="uTextArea",s.code_component="malibu.uTextArea",s.id_theme_component=Object(p.c)(),s._visible=s.props.dataFull.config.cmd.visible,s._disable=s.props.dataFull.config.cmd.disable,s.state={device:Object(p.f)(),skin_config:Object(d.configTemplate_getTheme)(),tooltip_copy:{value:"",isShow:"",mousePosition:{clientX:0,clientY:0,offset_item:0}}},s}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(p.i)(this.id_theme_component),this.jsoneditor&&this.jsoneditor.destroy()}},{key:"componentDidMount",value:function(){if(Object(p.b)(this,this.id_theme_component),this.props.dataFull.config.default.isJson){var e=Object.assign({},this.props.dataFull.json_config);delete e.json,delete e.text,0===e.modes.length&&delete e.modes,this.jsoneditor=new h.a(this.container,e),"json"in this.props.dataFull.json_config&&this.jsoneditor.set(this.props.dataFull.json_config.json),"text"in this.props.dataFull.json_config&&this.jsoneditor.setText(this.props.dataFull.json_config.text),this.schema=_()(this.props.dataFull.json_config.schema),this.schemaRefs=_()(this.props.dataFull.json_config.schemaRefs)}}},{key:"UNSAFE_componentWillUpdate",value:function(e){this._disable=e.dataFull.config.cmd.disable,this._visible=e.dataFull.config.cmd.visible}},{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.dataFull.config.cmd&&void 0!==e.dataFull.config.cmd&&(this.props.dataFull.config.cmd.disable!==e.dataFull.config.cmd.disable&&(this._disable=this.props.dataFull.config.cmd.disable),this.props.dataFull.config.cmd.visible!==e.dataFull.config.cmd.visible&&(this._visible=this.props.dataFull.config.cmd.visible)),this.props.dataFull.config.default.isJson){"json"in this.props.dataFull.json_config&&this.jsoneditor.update(this.props.dataFull.json_config.json),"text"in this.props.dataFull.json_config&&this.jsoneditor.updateText(this.props.dataFull.json_config.text),"mode"in this.props.dataFull.json_config&&this.jsoneditor.setMode(this.props.dataFull.json_config.mode);var t=!v()(this.props.dataFull.json_config.schema,this.schema),a=!v()(this.props.dataFull.json_config.schemaRefs,this.schemaRefs);(t||a)&&(this.schema=_()(this.props.dataFull.json_config.schema),this.schemaRefs=_()(this.props.dataFull.json_config.schemaRefs),this.jsoneditor.setSchema(this.props.dataFull.json_config.schema,this.props.dataFull.json_config.schemaRefs))}}},{key:"renderForDevice",value:function(){var e,t,a,o,i=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?this._visible&&c.a.createElement("div",{className:this.props.dataFull.config.default.class+" malibu-desktop-uTextArea-component static-component-padding  malibu-component-margin_top"+(this.props.dataFull.config.default.isJson?" malibu-format-json":""),ref:function(e){i.ref_input_component=e},id:this.props.dataFull.config.default.component_code,onMouseLeave:function(e){var t=i.state.tooltip_copy;t.isShow=!1,i.setState({tooltip_copy:t})}},c.a.createElement("div",{className:"malibu-desktop-label "+this.props.dataFull.config.error.type},c.a.createElement("span",null,this.props.dataFull.config.default.title),this.props.dataFull.config.default.required&&c.a.createElement("span",{className:"malibu-desktop-span"},"*")),c.a.createElement("textarea",{value:this.props.dataFull.value,onChange:function(e){void 0===i.props.dataFull.abs_Change||i._disable||i.props.dataFull.abs_Change(e,i.props.dataFull.config.default.code_form_component)},onBlur:function(e){void 0!==i.props.dataFull.abs_Blur&&i.props.dataFull.abs_Blur(e,i.props.dataFull.config.default.code_form_component)},onFocus:function(e){e.target.select()},onClick:function(e){void 0!==i.props.dataFull.abs_Click&&i.props.dataFull.abs_Click(e,i.props.dataFull.config.default.code_form_component)},onKeyUp:function(e){void 0!==i.props.dataFull.abs_KeyUp&&i.props.dataFull.abs_KeyUp(e,i.props.dataFull.config.default.code_form_component)},onMouseDown:function(e){void 0!==i.props.dataFull.abs_MouseDown&&i.props.dataFull.abs_MouseDown(e,i.props.dataFull.config.default.code_form_component)},readOnly:this._disable,className:"malibu-desktop-uTextArea "+this.props.dataFull.config.error.type+(this.props.dataFull.config.cmd.disable?" malibu-textarea-disable":""),rows:this.props.dataFull.config.default.rows,onMouseEnter:function(e){var t=i.state.tooltip_copy;t.isShow=!0,i.setState({tooltip_copy:t})}},this.props.dataFull.value),(this.state.tooltip_copy.isShow||this.props.dataFull.config.default.isCopy)&&c.a.createElement(u.default,{dataFull:Object(s.a)(Object(s.a)({},this.props.dataFull.tooltip_copy),{},{value:this.props.dataFull.config.default.isCopy?this.props.dataFull.value:this.state.tooltip_copy.value,abs_Click:this.abs_ClickTooltip})}),""!==(null===(e=this.props.dataFull.config.error)||void 0===e?void 0:e.message)&&c.a.createElement("div",{className:"error-message"},null===(t=this.props.dataFull.config.error)||void 0===t?void 0:t.message)):"mobile"===this.state.device?this._visible&&c.a.createElement("div",{className:this.props.dataFull.config.default.class+" malibu-desktop-uTextArea-component static-component-padding  malibu-component-margin_top"},c.a.createElement("div",{className:"malibu-desktop-label "+this.props.dataFull.config.error.type},c.a.createElement("span",null,this.props.dataFull.config.default.title),this.props.dataFull.config.default.required&&c.a.createElement("span",{className:"malibu-desktop-span"},"*")),c.a.createElement("textarea",{value:this.props.dataFull.value,onChange:function(e){void 0===i.props.dataFull.abs_Change||i._disable||i.props.dataFull.abs_Change(e,i.props.dataFull.config.default.code_form_component)},id:this.props.dataFull.config.default.component_code,onBlur:function(e){void 0!==i.props.dataFull.abs_Blur&&i.props.dataFull.abs_Blur(e,i.props.dataFull.config.default.code_form_component)},onFocus:function(e){e.target.select()},onClick:function(e){void 0!==i.props.dataFull.abs_Click&&i.props.dataFull.abs_Click(e,i.props.dataFull.config.default.code_form_component)},onKeyUp:function(e){void 0!==i.props.dataFull.abs_KeyUp&&i.props.dataFull.abs_KeyUp(e,i.props.dataFull.config.default.code_form_component)},onMouseDown:function(e){void 0!==i.props.dataFull.abs_MouseDown&&i.props.dataFull.abs_MouseDown(e,i.props.dataFull.config.default.code_form_component)},disabled:this._disable,className:"malibu-desktop-uTextArea "+this.props.dataFull.config.error.type,rows:this.props.dataFull.config.default.rows},this.props.dataFull.value),""!==(null===(a=this.props.dataFull.config.cmd.error)||void 0===a?void 0:a.message)&&c.a.createElement("div",{className:"error-message"},null===(o=this.props.dataFull.config.cmd.error)||void 0===o?void 0:o.message)):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){var e=this;return this.props.dataFull.config.default.isJson?this._visible?c.a.createElement("div",{className:"malibu-component-margin_top"+(this.props.dataFull.config.default.class?" "+this.props.dataFull.config.default.class:"")},c.a.createElement("div",{className:"malibu-desktop-uTextArea-component-title"},this.props.dataFull.config.default.title,":"),c.a.createElement("div",{className:"static-component-padding"},c.a.createElement("div",{className:"jsoneditor-react-container"+(this.props.dataFull.config.cmd.disable?" malibu-textarea-disable":""),ref:function(t){return e.container=t}}))):null:this.renderForDevice()}}]),a}(r.Component);t.default=F},1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return i}));var s=a(1313);function o(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function i(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?o(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):o(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},330:function(e,t,a){"use strict";a.r(t);var s=a(1),o=a(2),i=a(4),l=a(3),n=a(0),r=a.n(n),c=a(101),p=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(){return Object(s.a)(this,a),t.apply(this,arguments)}return Object(o.a)(a,[{key:"render",value:function(){return r.a.createElement(r.a.Fragment,null,r.a.createElement(c.default,{dataFull:this.props.stateData.uTextArea}),r.a.createElement(c.default,{dataFull:this.props.stateData.uTextAreaNormal}))}}]),a}(n.Component);t.default=p},59:function(e,t,a){"use strict";a.r(t);var s=a(1),o=a(2),i=a(4),l=a(3),n=a(0),r=a.n(n),c=a(6),p=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(e){var o;return Object(s.a)(this,a),(o=t.call(this,e)).class_desktop="malibu-tooltip-button",o.state={},o}return Object(o.a)(a,[{key:"getPaddingForm",value:function(){}},{key:"getPosition",value:function(){if(void 0!==this.ref_myToolTipButton&&null!==this.ref_myToolTipButton){var e;(null===(e=this.props.dataFull.mode)||void 0===e?void 0:e.isTable)||(this.ref_myToolTipButton.style.bottom="-19px"),this.setState({render:"render"})}}},{key:"componentDidMount",value:function(){this.getPosition()}},{key:"renderForCondition",value:function(){var e=this;return r.a.createElement("div",{className:this.class_desktop,ref:function(t){e.ref_myToolTipButton=t},onMouseDown:function(t){var a;t.preventDefault(),t.stopPropagation(),(null===(a=e.props.dataFull.mode)||void 0===a?void 0:a.isTable)&&void 0!==e.props.dataFull.abs_Click&&e.props.dataFull.abs_Click(e.props.dataFull.value)},onClick:function(){void 0!==e.props.dataFull.abs_Click&&e.props.dataFull.abs_Click(e.props.dataFull.value)}},r.a.createElement(c.default,{val:this.props.dataFull.icon,style:{width:"18px",height:"18px",fontSize:"18px"}}),r.a.createElement("div",{className:this.class_desktop+"-title"},this.props.dataFull.title))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(n.Component);t.default=p},6:function(e,t,a){"use strict";a.r(t);var s=a(1312),o=a(1),i=a(2),l=a(4),n=a(3),r=a(0),c=a.n(r),p=a(9),d=a(5),u=function(e){Object(l.a)(a,e);var t=Object(n.a)(a);function a(e){var i;Object(o.a)(this,a);var l=(i=t.call(this,e)).props.style;return void 0===l&&(l={fontSize:"20px"}),l=!1===i.props.isPointer?Object(s.a)(Object(s.a)({},l),{},{userSelect:"none"}):"disable"===i.props.isPointer?Object(s.a)(Object(s.a)({},l),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},l),{},{userSelect:"none",cursor:"pointer"}),i.state={style:l,isZoom:!1,isOpenModal:!1},i}return Object(i.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),s=new Uint8Array(a),o=0;o<t.length;o++)s[o]=t.charCodeAt(o);return new Blob([s],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,o=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return c.a.createElement(c.a.Fragment,null,c.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=o.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==o.props.viewFile.file_type&&"txt"!==o.props.viewFile.file_type?!(null===(t=o.props.viewFile)||void 0===t?void 0:t.isView)&&o.props.isZoom&&!0!==o.state.isZoom&&o.setState({isZoom:!0}):!0!==o.state.isOpenModal&&o.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&c.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){o.setState({isOpenModal:!1})}}},c.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==o.state.isZoom&&o.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},c.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var i,l,n=this.props.val;return d.a.managerTemplate_isDev()?n=n.replace("../",d.a.managerTemplate_getUrlResource()):d.a.managerTemplate_isCordova()&&(n=n.replace("../",d.a.managerTemplate_getUrlCordova())),c.a.createElement(c.a.Fragment,null,c.a.createElement("img",{className:this.props.class?this.props.class:"",src:n,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=o.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==o.props.viewFile.file_type&&"txt"!==o.props.viewFile.file_type?!(null===(t=o.props.viewFile)||void 0===t?void 0:t.isView)&&o.props.isZoom&&!0!==o.state.isZoom&&o.setState({isZoom:!0}):!0!==o.state.isOpenModal&&o.setState({isOpenModal:!0})}}),(null===(i=this.props.viewFile)||void 0===i?void 0:i.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&c.a.createElement(p.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){o.setState({isOpenModal:!1})}}},c.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(l=this.props.viewFile)||void 0===l?void 0:l.isView)&&c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==o.state.isZoom&&o.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},c.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},c.a.createElement("img",{src:n,alt:this.props.title}))))}return c.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(d.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(r.Component);t.default=u},9:function(e,t,a){"use strict";a.r(t);var s=a(1),o=a(2),i=a(4),l=a(3),n=a(0),r=a.n(n),c=a(5),p=a(593),d=a(6),u=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(e){var o;return Object(s.a)(this,a),(o=t.call(this,e)).abs_Focus=function(){o.ref_myModal&&o.ref_myModal.focus()},o.class_desktop="malibu-desktop-uModal",o.class_mobile="malibu-mobile-uModal",o.class_header_desktop="malibu-desktop-form-uModalHeader",o.class_header_mobile="malibu-mobile-form-uModalHeader",o.class_mobile_app="malibu-mobile_app-uModal",o.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",o.type_component="uModal",o.code_component="malibu.uModal",o.id_theme_component=Object(c.c)(),o.state={device:Object(c.f)(),class:"",skin_config:Object(p.configTemplate_getTheme)()},o}return Object(o.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?r.a.createElement("div",{className:this.class_desktop+""},r.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},r.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_desktop+" "},r.a.createElement("div",{className:this.class_header_desktop+"-header"},r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?r.a.createElement("div",{className:this.class_mobile+""},r.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile+" "},r.a.createElement("div",{className:this.class_header_mobile+"-header"},r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),r.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?r.a.createElement("div",{className:this.class_mobile_app+""},r.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},r.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},r.a.createElement("div",{className:this.class_header_mobile_app+" "},r.a.createElement("div",{className:this.class_header_mobile_app+"-header"},r.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),r.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),r.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=u}}]);