(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[311],{11:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),o=a(4),i=a(3),c=a(0),n=a.n(c),r=a(5),d=a(595),u=a(10),f=function(e){Object(o.a)(a,e);var t=Object(i.a)(a);function a(e){var s,o,i;Object(l.a)(this,a),(i=t.call(this,e)).getItemFocus=function(){var e=!0,t=i.props.dataFull.data;void 0===t&&(t=[],e=!1);for(var a=0;a<t.length;a++)if(!0===t[a].selected&&void 0!==i.ref_list_item){e=!1,i.ref_list_item[a].focus();break}i.setState({foccus:e,isClick:!0})},i.getItemFocusByInput=function(){var e=i.props.dataFull.data;void 0===e&&(e=[]);for(var t=0;t<e.length;t++)if(!0===e[t].selected&&void 0!==i.ref_list_item){i.ref_list_item[t].focus();break}i.setState({foccus:!0,isClick:!0})},i.abs_focus=function(){i.ref_mySelect.focus(),i.getItemFocus()},i.getItemConfig=function(){var e=document.getElementsByClassName("tblBody_DBA");if(void 0!==e&&void 0!==e[0]){var t=e[0].querySelectorAll("tbody >tr:first-child > td"),a=e[0].querySelectorAll("thead >tr:first-child > td"),l=0;if(t.length>0&&a.length>0&&t.length===a.length)for(var s=0;s<t.length;s++){var o=t[s],i=a[s];if(s!==t.length-1)if(i.offsetWidth>o.offsetWidth){var c="tbody > tr> td:nth-child("+(s+1)+")",n=e[0].querySelectorAll(c);if(n.length>0)for(var r=0;r<n.length;r++){n[r].style.paddingRight=i.offsetWidth-o.offsetWidth+16+"px"}l+=i.offsetWidth}else i.style.width=o.offsetWidth+"px",l+=o.offsetWidth;else{var d=(e[0].offsetWidth-l)/e[0].offsetWidth*100;o.style.width=d+"%",i.style.width=d+"%"}}else if(t.length<=0&&a.length>0)for(var u=0;u<a.length;u++){var f=a[u];if(u===a.length-1){var p=(e[0].offsetWidth-l)/e[0].offsetWidth*100;f.style.width=p+"%"}else l+=f.offsetWidth}}},i.type_component="uSelectItem",i.code_component="designForm.uSelectItem",i.class__="designForm-desktop-uSelectItem",i.id_theme_component=Object(r.c)(),i._disable=i.props.dataFull.config.cmd.disable,i._visible=i.props.dataFull.config.cmd.visible,i._lock=null===(s=i.props.dataFull.config)||void 0===s||null===(o=s.cmd)||void 0===o?void 0:o.isLock,i._hasSearch=!1,i.props.dataFull.data.length>=10&&(i._hasSearch=!0);return i.state={device:Object(r.f)(),skin_config:Object(d.configTemplate_getTheme)(),style_required:{paddingLeft:"2px",color:"#E9121D"},val_search:"",foccus:!1,isClick:!1},i}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){var e;Object(r.b)(this,this.id_theme_component),(null===(e=this.props.dataFull.config.cmd)||void 0===e?void 0:e.isFocus)&&(this.ref_mySelect.focus(),this.getItemFocus())}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t,a;this._disable=e.dataFull.config.cmd.disable,this._visible=e.dataFull.config.cmd.visible,this._lock=null===(t=this.props.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.isLock,e.dataFull.data.length>10&&!0!==this._hasSearch&&(this._hasSearch=!0)}},{key:"renderForDevice",value:function(){var e,t,a,l,s,o,i,c,r,d,f,p,m,h,_,v,g,b,F,y,k,C=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?this._visible&&n.a.createElement("div",{className:this.class__+" designForm-desktop-padding-component "+this.props.dataFull.config.default.class},n.a.createElement("div",{style:{width:"100%"}},n.a.createElement("div",{className:this.class__+"-info"+(this.props.dataFull.config.cmd.disable?" disabled":"")+((null===(e=this.props.dataFull.config.cmd.error)||void 0===e?void 0:e.message)?" error":"")+(this.props.dataFull.config.cmd.visible?" visible":"")+((null===(t=this.props.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.isLock)?" lock":""),tabIndex:-1,onBlur:function(e){e.currentTarget.contains(e.relatedTarget)||(C.setState({foccus:!1}),C.state.isClick&&C.setState({isClick:!1}))},ref:function(e){C.ref_select=e}},n.a.createElement("div",{className:this.class__+"-title row"},this.props.dataFull.config.default.title,!0===this.props.dataFull.config.default.required&&n.a.createElement("span",{style:this.state.style_required},"(*)"),this.props.dataFull.config.cmd.isHelper&&n.a.createElement(u.default,{dataFull:{data:this.props.dataFull.config.default.helper}})),n.a.createElement("div",{className:this.class__+"-content"},n.a.createElement("input",{tabIndex:this.props.dataFull.config.cmd.disable||(null===(l=this.props.dataFull.config)||void 0===l||null===(s=l.cmd)||void 0===s?void 0:s.isLock)?-1:1,className:this.class__+"-content-input",type:"text",placeholder:(null===(o=this.props.config)||void 0===o?void 0:o.default.placeholder)||"",value:void 0!==this.props.dataFull.input_value?this.props.dataFull.input_value:(null===(i=this.props.dataFull.data)||void 0===i||null===(c=i.find((function(e){return e.selected})))||void 0===c?void 0:c.title)||"",readOnly:!0,disabled:this._disable||this._lock,onFocus:function(e){!0===C.state.foccus?(C.ref_mySelect.blur(),C.setState({foccus:!1})):(C.getItemConfig(),C.getItemFocusByInput()),e.preventDefault(),e.stopPropagation()},onKeyUp:function(e){switch(e.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1,isClick:!1});break;case 40:void 0!==C.ref_mySearch?C.ref_mySearch.focus():void 0!==C.ref_list_item&&C.ref_list_item.length>0&&C.ref_list_item[0].focus(),e.preventDefault()}void 0!==C.props.dataFull.abs_KeyUp&&C.props.dataFull.abs_KeyUp(e,C.props.dataFull.config.default.code_form_component)},onKeyDown:function(e){e.stopPropagation(),e.preventDefault()},onMouseDown:function(e){void 0!==C.props.dataFull.abs_MouseDown&&C.props.dataFull.abs_MouseDown(e,C.props.dataFull.config.default.code_form_component)},ref:function(e){C.ref_mySelect=e}}),n.a.createElement("fieldset",{className:this.class__+"-border"+(this.props.dataFull.config.cmd.disable?" disabled":"")+((null===(r=this.props.dataFull.config.cmd.error)||void 0===r?void 0:r.message)?" error":"")+(this.props.dataFull.config.cmd.visible?" visible":"")+((null===(d=this.props.dataFull.config)||void 0===d||null===(f=d.cmd)||void 0===f?void 0:f.isLock)?" lock":"")}),(null===(p=this.props.dataFull.config)||void 0===p||null===(m=p.cmd)||void 0===m?void 0:m.isLoading)?null:n.a.createElement("i",{className:this.class__+"-content-drop material-icons md-28",style:{marginTop:(null===(h=this.props.dataFull.config.mode)||void 0===h?void 0:h.noTitle)?"2px":"5px"},onClick:function(e){e.preventDefault(),e.stopPropagation(),C.disable||(!1===C.state.isClick?(C.ref_mySelect.focus(),C.getItemFocus()):(C.ref_mySelect.blur(),C.setState({isClick:!1,foccus:!1})))}},"arrow_drop_down"),!this._disable&&!this._lock&&n.a.createElement("div",{className:this.class__+"-menu"+((null===(_=this.props.dataFull.config.mode)||void 0===_?void 0:_.moreColumn)?" moreColumn":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},this._hasSearch&&n.a.createElement("div",{className:this.class__+"-menu-search-content"},n.a.createElement("div",{className:this.class__+"-menu-search"},n.a.createElement("input",{className:this.class__+"-menu-search-input",type:"text",placeholder:this.props.dataFull.config.default.search.placeholder||"Search",value:this.props.dataFull.search_value||"",onChange:function(e){void 0!==C.props.dataFull.abs_search&&C.props.dataFull.abs_search(e,C.props.dataFull.config.default.code_form_component)},onDoubleClick:function(e){e.target.select()},onKeyUp:function(e){switch(C.ref_mySearch.focus(),e.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1}),C.ref_mySearch.blur();break;case 40:void 0!==C.ref_list_item&&C.ref_list_item.length>0&&null!==C.ref_list_item[0]&&C.ref_list_item[0].focus(),e.preventDefault()}},onFocus:function(e){!0!==C.state.foccus&&C.setState({foccus:!0})},onBlur:function(e){!1!==C.state.foccus&&C.setState({foccus:!1})},ref:function(e){C.ref_mySearch=e}}))),n.a.createElement("ul",{className:this.class__+"-menu-ul",onKeyDown:function(e){e.preventDefault(),e.stopPropagation()}},(null===(v=this.props.dataFull.config.mode)||void 0===v?void 0:v.moreColumn)?n.a.createElement("table",{className:"col-12 tblBody_DBA",style:{borderCollapse:"collapse",color:"rgba(73, 79, 89, 0.5)",minWidth:"100%"}},n.a.createElement("thead",{style:{width:"100%",display:"block"}},n.a.createElement("tr",null,this.props.dataFull.config.column.map((function(e,t){return n.a.createElement("td",{style:{borderRight:t<C.props.dataFull.config.column.length-1?"1px solid #ECF0F4":"none",height:"32px",background:"#F5F6F7",paddingLeft:"16px",paddingRight:"16px",textAlign:"left",fontWeight:"500",position:"sticky",top:"0",zIndex:"1"},key:t},e.title)})))),n.a.createElement("tbody",{className:this.class__+"-table"},this.props.dataFull.data.map((function(e,t){return n.a.createElement("tr",{key:t,className:C.class__+"-tr"+(e.selected?" active":""),ref:function(e){void 0===C.ref_list_item&&(C.ref_list_item=[]),C.ref_list_item[t]=e},tabIndex:0,onClick:function(){C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].focus(),C.ref_list_item[t].blur(),C.ref_select.blur()},onKeyUp:function(a){switch(a.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1}),C.ref_list_item[t].blur();break;case 40:t+1<C.props.dataFull.data.length&&C.ref_list_item[t+1].focus();break;case 38:t-1>=0&&C.ref_list_item[t-1].focus(),0===t&&void 0!==C.ref_mySearch&&C.ref_mySearch.focus();break;case 13:C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].blur(),C.ref_select.blur()}var l;C._hasSearch&&(a.keyCode>=0&&a.keyCode<=47||(l=!1===a.shiftKey?{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode).toLowerCase()}}:{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode)}},void 0!==C.props.dataFull.abs_search&&C.props.dataFull.abs_search(l,C.props.dataFull.config.default.code_form_component),C.setState({val_search:String.fromCharCode(a.keyCode)}),void 0!==C.ref_mySearch&&C.ref_mySearch.focus()))}},e.data.map((function(t,a){return n.a.createElement("td",{key:a,style:{border:"none",borderRight:a<e.data.length-1?"1px solid #ECF0F4":"none",padding:"8px 16px"}},t)})))})))):null===(g=this.props.dataFull.data)||void 0===g?void 0:g.map((function(e,t){return n.a.createElement("li",{key:t,tabIndex:-1,onClick:function(){C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].focus(),C.ref_list_item[t].blur(),C.ref_select.blur()},style:{outline:"none"},ref:function(e){void 0===C.ref_list_item&&(C.ref_list_item=[]),C.ref_list_item[t]=e},onKeyUp:function(a){var l;C._hasSearch&&(a.keyCode>=0&&a.keyCode<=47||(l=!1===a.shiftKey?{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode).toLowerCase()}}:{target:{value:C.props.dataFull.search_value+String.fromCharCode(a.keyCode)}},void 0!==C.props.dataFull.abs_search&&C.props.dataFull.abs_search(l,C.props.dataFull.config.default.code_form_component),C.setState({foccus:!1}),C.ref_list_item[t].blur()));switch(a.keyCode){case 27:C.ref_mySelect.blur(),C.setState({foccus:!1}),C.ref_list_item[t].blur();break;case 40:t+1<C.props.dataFull.data.length&&C.ref_list_item[t+1].focus();break;case 38:t-1>=0&&C.ref_list_item[t-1].focus(),0===t&&void 0!==C.ref_select&&C.ref_select.focus();break;case 13:C.setState({foccus:!1}),void 0!==C.props.dataFull.abs_Change&&C.props.dataFull.abs_Change(e.value,t,C.props.dataFull.config.default.code_form_component),C.ref_mySelect.blur(),C.ref_list_item[t].blur(),C.ref_select.blur()}}},n.a.createElement("label",{className:C.class__+"-menu-title "+(e.selected?"active":""),title:e.title,style:{cursor:"pointer"}},e.title))})),0===this.props.dataFull.data.length&&n.a.createElement("div",{style:{padding:"2px 0px"}},n.a.createElement("li",{className:"no-data",style:{cursor:"default"}},n.a.createElement("label",{className:this.class__+"-menu-title "},this.props.dataFull.config.default.data_status))))),(null===(b=this.props.dataFull.config)||void 0===b||null===(F=b.cmd)||void 0===F?void 0:F.isLoading)&&n.a.createElement("div",{className:"selectItem-loading"},n.a.createElement("div",{className:"selectItem-onclic"}))),""!==(null===(y=this.props.dataFull.config.cmd)||void 0===y||null===(k=y.error)||void 0===k?void 0:k.message)&&n.a.createElement("div",{className:"error-message"},this.props.dataFull.config.cmd.error.message)))):"mobile"===this.state.device?this._visible&&n.a.createElement("div",null):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(c.Component);t.default=f},35:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),o=a(4),i=a(3),c=a(0),n=a.n(c),r=a(5),d=a(595),u=a(8),f=function(e){Object(o.a)(a,e);var t=Object(i.a)(a);function a(e){var s;Object(l.a)(this,a),(s=t.call(this,e)).abstract_changeDevice=function(e){s.setState({device:e})},s.type_component="uMultiValue",s.code_component="designForm.uMultiValue",s.class__="designForm-desktop-uMultiValue",s.id_theme_component=Object(r.c)();var o=s.props.class;return void 0===o&&(o="col-12"),s.state={device:Object(r.f)(),skin_config:Object(d.configTemplate_getTheme)(),show:"",class:o,height:0},s}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?this.props.children:"mobile-app"===this.state.device?n.a.createElement("button",{className:"btn btn-success",type:"submit"},"mobile"):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"openMultiValue",value:function(){var e=this,t=this.state.show;t=""===t?"expand":"",this.setState({show:t},(function(){var t=e.ref_myMultiValue.clientHeight;16===t?e.setState({height:0}):t!==e.state.height&&e.setState({height:t})}))}},{key:"render",value:function(){var e,t,a,l,s=this;return this.props.dataFull.config.cmd.visible&&n.a.createElement("div",{className:this.class__+" "+this.state.class,ref:function(e){s.ref_myMultiValue=e}},n.a.createElement("div",{className:this.class__+"-header row "+this.state.show},n.a.createElement("div",{className:this.class__+"-icon",onClick:function(){s.openMultiValue()}},n.a.createElement(u.default,{val:"expand"===this.state.show?"remove":"add",style:{fontSize:"24px"}})),""!==(null===(e=this.props.dataFull)||void 0===e?void 0:e.config.default.title)&&n.a.createElement("div",{className:this.class__+"-title",onClick:function(){s.openMultiValue()}},null===(t=this.props.dataFull)||void 0===t?void 0:t.config.default.title,(null===(a=this.props.dataFull)||void 0===a||null===(l=a.config.default)||void 0===l?void 0:l.required)&&n.a.createElement("span",{style:{paddingLeft:"4px",color:"#E9121D"}},"(*)"))),n.a.createElement("div",{style:{position:"relative"}},n.a.createElement("div",{className:this.class__+"-content",style:{display:"expand"===this.state.show?"block":"none"}},this.renderForDevice())))}}]),a}(c.Component);t.default=f},352:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),o=a(4),i=a(3),c=a(0),n=a.n(c),r=a(13),d=a(35),u=a(11),f=function(e){Object(o.a)(a,e);var t=Object(i.a)(a);function a(){return Object(l.a)(this,a),t.apply(this,arguments)}return Object(s.a)(a,[{key:"render",value:function(){return n.a.createElement("div",{className:"designForm-desktop-uModal-config_component-tab_child row"},n.a.createElement(r.default,this.props.stateData.collection_method),n.a.createElement(r.default,this.props.stateData.read_data),n.a.createElement(r.default,this.props.stateData.data_default),n.a.createElement("div",{className:"designForm-desktop-uModal-config_component-tab-hr"}),n.a.createElement(d.default,this.props.stateData.CBO_multiValue,n.a.createElement("div",{className:"row"},n.a.createElement(u.default,this.props.stateData.CBO_action),n.a.createElement(r.default,this.props.stateData.CBO_nameConfigLink))),n.a.createElement("div",{className:"designForm-desktop-uModal-config_component-tab-hr"}),n.a.createElement(d.default,this.props.stateData.CE_multiValue,n.a.createElement("div",{className:"row"},n.a.createElement(u.default,this.props.stateData.CE_action),n.a.createElement(r.default,this.props.stateData.CE_nameConfigLink))),n.a.createElement("div",{className:"designForm-desktop-uModal-config_component-tab-hr"}),n.a.createElement(d.default,this.props.stateData.CD_multiValue,n.a.createElement("div",{className:"row"},n.a.createElement(r.default,this.props.stateData.CD_dateBegin),n.a.createElement(r.default,this.props.stateData.CD_dateEnd))))}}]),a}(c.Component);t.default=f}}]);