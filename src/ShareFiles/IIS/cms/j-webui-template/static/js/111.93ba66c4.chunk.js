(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[111,203,230,283,285,322,435,436,618,756],{10:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),o=a(4),r=a(3),i=a(0),n=a.n(i),c=a(8),d=function(e){Object(o.a)(a,e);var t=Object(r.a)(a);function a(){return Object(s.a)(this,a),t.apply(this,arguments)}return Object(l.a)(a,[{key:"render",value:function(){return n.a.createElement("div",{className:"designForm-helper"},n.a.createElement(c.default,{val:"error_outline",style:{fontSize:"16px"}}),n.a.createElement("div",{className:"designForm-helper-content"},this.props.dataFull.data))}}]),a}(i.Component);t.default=d},11:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),o=a(4),r=a(3),i=a(0),n=a.n(i),c=a(5),d=a(595),p=a(10),u=function(e){Object(o.a)(a,e);var t=Object(r.a)(a);function a(e){var l,o,r;Object(s.a)(this,a),(r=t.call(this,e)).getItemFocus=function(){var e=!0,t=r.props.dataFull.data;void 0===t&&(t=[],e=!1);for(var a=0;a<t.length;a++)if(!0===t[a].selected&&void 0!==r.ref_list_item){e=!1,r.ref_list_item[a].focus();break}r.setState({foccus:e,isClick:!0})},r.getItemFocusByInput=function(){var e=r.props.dataFull.data;void 0===e&&(e=[]);for(var t=0;t<e.length;t++)if(!0===e[t].selected&&void 0!==r.ref_list_item){r.ref_list_item[t].focus();break}r.setState({foccus:!0,isClick:!0})},r.abs_focus=function(){r.ref_mySelect.focus(),r.getItemFocus()},r.getItemConfig=function(){var e=document.getElementsByClassName("tblBody_DBA");if(void 0!==e&&void 0!==e[0]){var t=e[0].querySelectorAll("tbody >tr:first-child > td"),a=e[0].querySelectorAll("thead >tr:first-child > td"),s=0;if(t.length>0&&a.length>0&&t.length===a.length)for(var l=0;l<t.length;l++){var o=t[l],r=a[l];if(l!==t.length-1)if(r.offsetWidth>o.offsetWidth){var i="tbody > tr> td:nth-child("+(l+1)+")",n=e[0].querySelectorAll(i);if(n.length>0)for(var c=0;c<n.length;c++){n[c].style.paddingRight=r.offsetWidth-o.offsetWidth+16+"px"}s+=r.offsetWidth}else r.style.width=o.offsetWidth+"px",s+=o.offsetWidth;else{var d=(e[0].offsetWidth-s)/e[0].offsetWidth*100;o.style.width=d+"%",r.style.width=d+"%"}}else if(t.length<=0&&a.length>0)for(var p=0;p<a.length;p++){var u=a[p];if(p===a.length-1){var f=(e[0].offsetWidth-s)/e[0].offsetWidth*100;u.style.width=f+"%"}else s+=u.offsetWidth}}},r.type_component="uSelectItem",r.code_component="designForm.uSelectItem",r.class__="designForm-desktop-uSelectItem",r.id_theme_component=Object(c.c)(),r._disable=r.props.dataFull.config.cmd.disable,r._visible=r.props.dataFull.config.cmd.visible,r._lock=null===(l=r.props.dataFull.config)||void 0===l||null===(o=l.cmd)||void 0===o?void 0:o.isLock,r._hasSearch=!1,r.props.dataFull.data.length>=10&&(r._hasSearch=!0);return r.state={device:Object(c.f)(),skin_config:Object(d.configTemplate_getTheme)(),style_required:{paddingLeft:"2px",color:"#E9121D"},val_search:"",foccus:!1,isClick:!1},r}return Object(l.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){var e;Object(c.b)(this,this.id_theme_component),(null===(e=this.props.dataFull.config.cmd)||void 0===e?void 0:e.isFocus)&&(this.ref_mySelect.focus(),this.getItemFocus())}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t,a;this._disable=e.dataFull.config.cmd.disable,this._visible=e.dataFull.config.cmd.visible,this._lock=null===(t=this.props.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.isLock,e.dataFull.data.length>10&&!0!==this._hasSearch&&(this._hasSearch=!0)}},{key:"renderForDevice",value:function(){var e,t,a,s,l,o,r,i,c,d,u,f,m,A,h,v,b,g,F,k,y,C=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?this._visible&&n.a.createElement("div",{className:this.class__+" designForm-desktop-padding-component "+this.props.dataFull.config.default.class},n.a.createElement("div",{style:{width:"100%"}},n.a.createElement("div",{className:this.class__+"-info"+(this.props.dataFull.config.cmd.disable?" disabled":"")+((null===(e=this.props.dataFull.config.cmd.error)||void 0===e?void 0:e.message)?" error":"")+(this.props.dataFull.config.cmd.visible?" visible":"")+((null===(t=this.props.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.isLock)?" lock":""),tabIndex:-1,onBlur:function(e){e.currentTarget.contains(e.relatedTarget)||(C.setState({foccus:!1}),C.state.isClick&&C.setState({isClick:!1}))},ref:function(e){C.ref_select=e}},n.a.createElement("div",{className:this.class__+"-title row"},this.props.dataFull.config.default.title,!0===this.props.dataFull.config.default.required&&n.a.createElement("span",{style:this.state.style_required},"(*)"),this.props.dataFull.config.cmd.isHelper&&n.a.createElement(p.default,{dataFull:{data:this.props.dataFull.config.default.helper}})),n.a.createElement("div",{className:this.class__+"-content"},n.a.createElement("input",{tabIndex:this.props.dataFull.config.cmd.disable||(null===(s=this.props.dataFull.config)||void 0===s||null===(l=s.cmd)||void 0===l?void 0:l.isLock)?-1:1,className:this.class__+"-content-input",type:"text",placeholder:(null===(o=this.props.config)||void 0===o?void 0:o.default.placeholder)||"",value:void 0!==this.props.dataFull.input_value?this.props.dataFull.input_value:(null===(r=this.props.dataFull.data)||void 0===r||null===(i=r.find((function(e){return e.selected})))||void 0===i?void 0:i.title)||"",readOnly:!0,disabled:this._disable||this._lock,onFocus:function(e){!0===C.state.foccus?(C.ref_mySelect.blur(),C.setState({foccus:!1})):(C.getItemConfig(),C.getItemFocusByInput()),e.preventDefault(),e.stopPropagation()},onKeyUp:function(e){switch(e.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1,isClick:!1});break;case 40:void 0!==C.ref_mySearch?C.ref_mySearch.focus():void 0!==C.ref_list_item&&C.ref_list_item.length>0&&C.ref_list_item[0].focus(),e.preventDefault()}void 0!==C.props.dataFull.abs_KeyUp&&C.props.dataFull.abs_KeyUp(e,C.props.dataFull.config.default.code_form_component)},onKeyDown:function(e){e.stopPropagation(),e.preventDefault()},onMouseDown:function(e){void 0!==C.props.dataFull.abs_MouseDown&&C.props.dataFull.abs_MouseDown(e,C.props.dataFull.config.default.code_form_component)},ref:function(e){C.ref_mySelect=e}}),n.a.createElement("fieldset",{className:this.class__+"-border"+(this.props.dataFull.config.cmd.disable?" disabled":"")+((null===(c=this.props.dataFull.config.cmd.error)||void 0===c?void 0:c.message)?" error":"")+(this.props.dataFull.config.cmd.visible?" visible":"")+((null===(d=this.props.dataFull.config)||void 0===d||null===(u=d.cmd)||void 0===u?void 0:u.isLock)?" lock":"")}),(null===(f=this.props.dataFull.config)||void 0===f||null===(m=f.cmd)||void 0===m?void 0:m.isLoading)?null:n.a.createElement("i",{className:this.class__+"-content-drop material-icons md-28",style:{marginTop:(null===(A=this.props.dataFull.config.mode)||void 0===A?void 0:A.noTitle)?"2px":"5px"},onClick:function(e){e.preventDefault(),e.stopPropagation(),C.disable||(!1===C.state.isClick?(C.ref_mySelect.focus(),C.getItemFocus()):(C.ref_mySelect.blur(),C.setState({isClick:!1,foccus:!1})))}},"arrow_drop_down"),!this._disable&&!this._lock&&n.a.createElement("div",{className:this.class__+"-menu"+((null===(h=this.props.dataFull.config.mode)||void 0===h?void 0:h.moreColumn)?" moreColumn":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},this._hasSearch&&n.a.createElement("div",{className:this.class__+"-menu-search-content"},n.a.createElement("div",{className:this.class__+"-menu-search"},n.a.createElement("input",{className:this.class__+"-menu-search-input",type:"text",placeholder:this.props.dataFull.config.default.search.placeholder||"Search",value:this.props.dataFull.search_value||"",onChange:function(e){void 0!==C.props.dataFull.abs_search&&C.props.dataFull.abs_search(e,C.props.dataFull.config.default.code_form_component)},onDoubleClick:function(e){e.target.select()},onKeyUp:function(e){switch(C.ref_mySearch.focus(),e.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1}),C.ref_mySearch.blur();break;case 40:void 0!==C.ref_list_item&&C.ref_list_item.length>0&&null!==C.ref_list_item[0]&&C.ref_list_item[0].focus(),e.preventDefault()}},onFocus:function(e){!0!==C.state.foccus&&C.setState({foccus:!0})},onBlur:function(e){!1!==C.state.foccus&&C.setState({foccus:!1})},ref:function(e){C.ref_mySearch=e}}))),n.a.createElement("ul",{className:this.class__+"-menu-ul",onKeyDown:function(e){e.preventDefault(),e.stopPropagation()}},(null===(v=this.props.dataFull.config.mode)||void 0===v?void 0:v.moreColumn)?n.a.createElement("table",{className:"col-12 tblBody_DBA",style:{borderCollapse:"collapse",color:"rgba(73, 79, 89, 0.5)",minWidth:"100%"}},n.a.createElement("thead",{style:{width:"100%",display:"block"}},n.a.createElement("tr",null,this.props.dataFull.config.column.map((function(e,t){return n.a.createElement("td",{style:{borderRight:t<C.props.dataFull.config.column.length-1?"1px solid #ECF0F4":"none",height:"32px",background:"#F5F6F7",paddingLeft:"16px",paddingRight:"16px",textAlign:"left",fontWeight:"500",position:"sticky",top:"0",zIndex:"1"},key:t},e.title)})))),n.a.createElement("tbody",{className:this.class__+"-table"},this.props.dataFull.data.map((function(e,t){return n.a.createElement("tr",{key:t,className:C.class__+"-tr"+(e.selected?" active":""),ref:function(e){void 0===C.ref_list_item&&(C.ref_list_item=[]),C.ref_list_item[t]=e},tabIndex:0,onClick:function(){C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].focus(),C.ref_list_item[t].blur(),C.ref_select.blur()},onKeyUp:function(a){switch(a.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1}),C.ref_list_item[t].blur();break;case 40:t+1<C.props.dataFull.data.length&&C.ref_list_item[t+1].focus();break;case 38:t-1>=0&&C.ref_list_item[t-1].focus(),0===t&&void 0!==C.ref_mySearch&&C.ref_mySearch.focus();break;case 13:C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].blur(),C.ref_select.blur()}var s;C._hasSearch&&(a.keyCode>=0&&a.keyCode<=47||(s=!1===a.shiftKey?{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode).toLowerCase()}}:{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode)}},void 0!==C.props.dataFull.abs_search&&C.props.dataFull.abs_search(s,C.props.dataFull.config.default.code_form_component),C.setState({val_search:String.fromCharCode(a.keyCode)}),void 0!==C.ref_mySearch&&C.ref_mySearch.focus()))}},e.data.map((function(t,a){return n.a.createElement("td",{key:a,style:{border:"none",borderRight:a<e.data.length-1?"1px solid #ECF0F4":"none",padding:"8px 16px"}},t)})))})))):null===(b=this.props.dataFull.data)||void 0===b?void 0:b.map((function(e,t){return n.a.createElement("li",{key:t,tabIndex:-1,onClick:function(){C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].focus(),C.ref_list_item[t].blur(),C.ref_select.blur()},style:{outline:"none"},ref:function(e){void 0===C.ref_list_item&&(C.ref_list_item=[]),C.ref_list_item[t]=e},onKeyUp:function(a){var s;C._hasSearch&&(a.keyCode>=0&&a.keyCode<=47||(s=!1===a.shiftKey?{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode).toLowerCase()}}:{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode)}},void 0!==C.props.dataFull.abs_search&&C.props.dataFull.abs_search(s,C.props.dataFull.config.default.code_form_component),C.setState({foccus:!1}),C.ref_list_item[t].blur()));switch(a.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1}),C.ref_list_item[t].blur();break;case 40:t+1<C.props.dataFull.data.length&&C.ref_list_item[t+1].focus();break;case 38:t-1>=0&&C.ref_list_item[t-1].focus(),0===t&&void 0!==C.ref_select&&C.ref_select.focus();break;case 13:C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].blur(),C.ref_select.blur()}}},n.a.createElement("label",{className:C.class__+"-menu-title "+(e.selected?"active":""),title:e.title,style:{cursor:"pointer"}},e.title))})),0===this.props.dataFull.data.length&&n.a.createElement("div",{style:{padding:"2px 0px"}},n.a.createElement("li",{className:"no-data",style:{cursor:"default"}},n.a.createElement("label",{className:this.class__+"-menu-title "},this.props.dataFull.config.default.data_status))))),(null===(g=this.props.dataFull.config)||void 0===g||null===(F=g.cmd)||void 0===F?void 0:F.isLoading)&&n.a.createElement("div",{className:"selectItem-loading"},n.a.createElement("div",{className:"selectItem-onclic"}))),""!==(null===(k=this.props.dataFull.config.cmd)||void 0===k||null===(y=k.error)||void 0===y?void 0:y.message)&&n.a.createElement("div",{className:"error-message"},this.props.dataFull.config.cmd.error.message)))):"mobile"===this.state.device?this._visible&&n.a.createElement("div",null):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(i.Component);t.default=u},1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return o}));var s=a(1313);function l(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function o(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?l(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):l(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},487:function(e,t,a){"use strict";a.r(t);var s=a(1),l=a(2),o=a(4),r=a(3),i=a(0),n=a.n(i),c=a(11),d=function(e){Object(o.a)(a,e);var t=Object(r.a)(a);function a(){return Object(s.a)(this,a),t.apply(this,arguments)}return Object(l.a)(a,[{key:"render",value:function(){return n.a.createElement("div",{className:"designForm-desktop-uModal-config_component-tab_child row"},n.a.createElement(c.default,this.props.stateData.disable),n.a.createElement(c.default,this.props.stateData.visible))}}]),a}(i.Component);t.default=d},595:function(e,t,a){"use strict";a.r(t),a.d(t,"configTemplate_getTheme",(function(){return r})),a.d(t,"configTemplate_getCssMain",(function(){return i})),a.d(t,"configTemplate_getDeviceSupport",(function(){return n}));var s=["desktop","desktop_small","tablet","mobile"],l={light:{isDefault:!0,skin_background:"#1283DA",skin_color:"#FFFFFF",skin_background_hover:"#F3F9FF",skin_color_active:"#8FC6FA",skin_background_uTab_shadow:"0px 3px 4px #A5CAE9",skin_background_click:"rgba(18, 131, 218, 0.6)",skin_modal_circle:"#E0E2E4",uCheckBox_focus:"#0291FF",uLogin_hover:"url('data:image/png;base64,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')"},Majorelle_Blue:{skin_background:"#5557E4",skin_color:"#FFFFFF",skin_background_hover:"#F3F2FF",skin_color_active:"#918FFA",skin_background_uTab_shadow:" 0px 3px 4px rgba(45, 13, 241, 0.3)",skin_background_click:"rgba(85, 87, 228, 0.6)",skin_modal_circle:"#E0E0E4",uCheckBox_focus:"#0004FF",uLogin_hover:"url('data:image/png;base64,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')"},Green_Pigment:{skin_background:"#00A950",skin_color:"#FFFFFF",skin_background_hover:"#EFFFF3",skin_color_active:"#99FDAF",skin_background_uTab_shadow:" 0px 3px 4px rgba(0, 169, 80, 0.4)",skin_background_click:"rgba(0, 169, 80, 0.6)",skin_modal_circle:"#E1E4E4",uCheckBox_focus:"#05DD6B",uLogin_hover:"url('data:image/png;base64,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')"}},o=[{url:"/template/designForm/css/index.scss",type:"content",code_component:"css_component",name:"CSS Component"},{url:"/template/designForm/css/icon.css",type:"content",code_component:"icon",name:"Icon"},{url:"/template/designForm/css/css_default.css",type:"content",code_component:"css_default",name:"CSS Default"},{url:"/template/designForm/css/cssfont.scss",type:"content",code_component:"font",name:"Font"}];function r(){return l}function i(){return o}function n(){return s}},8:function(e,t,a){"use strict";a.r(t);var s=a(1312),l=a(1),o=a(2),r=a(4),i=a(3),n=a(0),c=a.n(n),d=a(5),p=function(e){Object(r.a)(a,e);var t=Object(i.a)(a);function a(e){var o;Object(l.a)(this,a);var r=(o=t.call(this,e)).props.style;return void 0===r&&(r={fontSize:"20px"}),r=!1===o.props.isPointer?Object(s.a)(Object(s.a)({},r),{},{userSelect:"none"}):"disable"===o.props.isPointer?Object(s.a)(Object(s.a)({},r),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},r),{},{userSelect:"none",cursor:"pointer"}),o.state={style:r},o}return Object(o.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"renderForCondition",value:function(){var e;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return c.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:this.state.style});if(this.props.val.includes("../")||(null===(e=this.props.val[0])||void 0===e?void 0:e.includes("/"))){var t=this.props.val;return d.a.managerTemplate_isDev()?t=t.replace("../",d.a.managerTemplate_getUrlResource()):d.a.managerTemplate_isCordova()&&(t=t.replace("../",d.a.managerTemplate_getUrlCordova())),c.a.createElement("img",{className:this.props.class?this.props.class:"",src:t,alt:this.props.title,style:this.state.style})}return c.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(d.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(n.Component);t.default=p}}]);