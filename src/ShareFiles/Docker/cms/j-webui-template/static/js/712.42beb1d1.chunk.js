(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[712,332,435,436,781],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return n}));var s=a(1313);function i(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function n(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?i(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):i(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},17:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),n=a(4),l=a(3),o=a(0),r=a.n(o),c=a(5),u=a(593),m=a(618),d=function(e){Object(n.a)(a,e);var t=Object(l.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abstract_changeDevice=function(e){i.setState({device:e})},i.chooseAPP=function(e,t){i.closeApp(),i.ref_button.blur(),i.ref_menu_item[t].abs_blur(),i.props.dataFull.abs_select(e)},i.KeyUp=function(e,t){switch(e.keyCode){case 27:i.ref_menu_item[t].abs_blur();break;case 13:i.chooseAPP(i.props.dataFull.appItem[t].dataItem,t);break;case 39:t+1<i.props.dataFull.appItem.length&&i.ref_menu_item[t+1].abs_focus();break;case 37:t-1>=0&&i.ref_menu_item[t-1].abs_focus()}},i.KeyDown=function(e,t){switch(e.keyCode){case 40:t+3<i.props.dataFull.appItem.length&&i.ref_menu_item[t+3].abs_focus();break;case 38:t-3>=0&&i.ref_menu_item[t-3].abs_focus()}},i.type_component="uAppMenu",i.code_component="malibu.uAppMenu",i.id_theme_component=Object(c.c)(),i.ref_menu_item=[],i.state={device:Object(c.f)(),skin_config:Object(u.configTemplate_getTheme)(),show:"",isDisMount:"none"},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component),this.setState({isDisMount:"block"})}},{key:"UNSAFE_componentWillUpdate",value:function(){this.ref_menu_item=[]}},{key:"renderForDevice",value:function(){var e,t=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"desktop_small"===this.state.device||"mobile"===this.state.device?r.a.createElement(r.a.Fragment,null,r.a.createElement("div",{className:"malibu-uAppMenu-header",style:{userSelect:"none"}},r.a.createElement("div",{tabIndex:1,className:"malibu-uAppMenu-span_btn ",style:{cursor:"pointer"},ref:function(e){t.ref_button=e},onMouseDown:function(e){"expand"===t.state.show&&(t.ref_button.blur(),t.closeApp(),e.preventDefault(),e.stopPropagation())},onFocus:function(e){e.preventDefault(),e.stopPropagation(),t.openApp()},onKeyUp:function(e){40===e.keyCode&&t.ref_menu_item[0].abs_focus(),27===e.keyCode&&t.ref_button.blur()}},r.a.createElement("i",{className:"material-icons"},"apps"))),r.a.createElement("div",{className:"malibu-uAppMenu-list-menu"},r.a.createElement("div",{className:"malibu-uAppMenu-list-menu-ul row",onMouseDown:function(e){e.target.focus(),e.preventDefault()}},null===(e=this.props.dataFull.appItem)||void 0===e?void 0:e.map((function(e,a){return void 0===e.class&&(e.class=""),r.a.createElement(m.default,{ref:function(e){t.ref_menu_item[a]=e},class:e.class,device:t.state.device,val:e.icon,key:a,index:a,title:e.title,sysStyle:e.sysStyle,dataItem:e.dataItem,appItem_Select:t.chooseAPP,abs_KeyUp:t.KeyUp,abs_KeyDown:t.KeyDown})}))))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"openApp",value:function(){"expand"!==this.state.show?(this.setState({show:"expand"}),window.anime({targets:".malibu-uAppMenu-list-menu",translateX:-379,duration:100})):(this.setState({show:""}),window.anime({targets:".malibu-uAppMenu-list-menu",translateX:500,duration:100}))}},{key:"closeApp",value:function(){this.setState({show:""}),window.anime({targets:".malibu-uAppMenu-list-menu",translateX:500,duration:100})}},{key:"render",value:function(){var e=this;return r.a.createElement(r.a.Fragment,null,r.a.createElement("div",{className:"malibu-desktop-appnav "+this.state.show,tabIndex:-1,onBlur:function(t){t.currentTarget.contains(t.relatedTarget)||e.closeApp()}},this.renderForDevice()))}}]),a}(o.Component);t.default=d},19:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),n=a(4),l=a(3),o=a(0),r=a.n(o),c=a(5),u=a(593),m=a(619),d=a(6),p=function(e){Object(n.a)(a,e);var t=Object(l.a)(a);function a(e){var i;Object(s.a)(this,a),(i=t.call(this,e)).abstract_changeDevice=function(e){i.setState({device:e})},i.abs_changeLang=function(e){i.setState({sidebarBody:e})},i.uSidebarMenu_selectItem=function(e){var t,a=i.state.sidebarBody;if(a.length>0)for(var s=0;s<a.length;s++){a[s].sysStyle&&!0===a[s].sysStyle.show&&(t=s),a[s].sysStyle={show:!1};for(var n=0;n<a[s].data.length;n++)a[s].data[n].sysStyle&&!0===a[s].data[n].sysStyle.show&&(t=n),a[s].data[n].sysStyle={show:!1}}e!==t&&(a[e].sysStyle={show:!0}),i.setState({sidebarBody:a})},i.uSidebarMenu_selectItemChild=function(e,t){var a,s=i.state.sidebarBody;if(s.length>0)for(var n=0;n<s.length;n++)for(var l=0;l<s[n].data.length;l++)s[n].data[l].sysStyle&&!0===s[n].data[l].sysStyle.show&&(a=l),s[n].data[l].sysStyle={show:!1};t!==a&&(s[e].data[t].sysStyle={show:!0}),i.setState({sidebarBody:s})},i.checkData=function(){for(var e=i.state.sidebarBody,t=0;t<e.length;t++)void 0===e[t].sysStyle&&(e[t].sysStyle={}),void 0!==e[t].sysStyle.show&&"show"!==e[t].sysStyle.show||(e[t].sysStyle.show="");i.setState({sidebarBody:e})},i.closeNav=function(){i.checkData(),i.setState({show:""}),"mobile"!==i.state.device?window.anime({targets:".malibu-desktop-uSidebarMenu-navbar-list-menu",translateX:-516,duration:100}):window.anime({targets:".malibu-mobile-navbar-list-menu-div",translateX:-500,duration:100})},i.type_component="uSlidebar",i.code_component="malibu.uSidebarMenu",i.id_theme_component=Object(c.c)();var n=i.props.dataFull.sidebarBody;return void 0===n&&(n=[]),i.state={device:Object(c.f)(),skin_config:Object(u.configTemplate_getTheme)(),sidebarBody:n,show:"",isDisMount:"none"},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(c.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(c.b)(this,this.id_theme_component),this.setState({isDisMount:"block"})}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?r.a.createElement(r.a.Fragment,null,r.a.createElement("div",{className:"malibu-desktop-uSidebarMenu "+this.state.show,style:{display:this.state.isDisMount}},r.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-header",style:{userSelect:"none"}},r.a.createElement("div",{tabIndex:0,className:"malibu-desktop-uSidebarMenu-header-button",style:{cursor:"pointer"},onClick:function(){e.openNav()},onBlur:function(){e.closeNav()}},r.a.createElement("i",{className:"material-icons-outlined"},"menu"))),r.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu"},r.a.createElement("ul",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul",onMouseDown:function(e){e.target.focus(),e.preventDefault()}},this.state.sidebarBody.map((function(t,a){return r.a.createElement(m.default,{key:a,index:a,icon:t.icon,title:t.title,value:t.value,device_option:t.device_option,device:e.state.device,data:t.data,sysStyle:t.sysStyle,uSidebarMenu_selectItem:e.props.dataFull.abs_select,uSidebarMenu_chooseItem:e.uSidebarMenu_selectItem,uSidebarMenu_selectItemChild:e.uSidebarMenu_selectItemChild,closeNav:e.closeNav})}))))),r.a.createElement("div",{className:"blank"})):"mobile"===this.state.device?r.a.createElement("div",{className:"malibu-mobile-uSidebarMenu "+this.state.show,style:{display:this.state.isDisMount}},r.a.createElement("div",{className:"malibu-mobile-uSidebarMenu-header",style:{userSelect:"none",background:"unset "}},r.a.createElement("div",{tabIndex:0,className:"malibu-mobile-uSidebarMenu-header-button",style:{cursor:"pointer"},onClick:function(){e.openNav()},onBlur:function(){e.closeNav()}},r.a.createElement("i",{className:"material-icons-outlined"},"menu"))),r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu ",onClick:function(e){e.stopPropagation(),e.preventDefault()}},r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-div",onMouseDown:function(e){e.preventDefault(),e.stopPropagation(),e.target.focus(),e.stopPropagation(),e.preventDefault()}},r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-header"},r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-header-button_close",onClick:function(){e.closeNav()}},r.a.createElement(d.default,{val:"close",style:{fontSize:"28px"}}))),r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-content"},r.a.createElement("ul",{className:"malibu-mobile-uSidebarMenu-list-menu-ul",onMouseDown:function(e){e.target.focus(),e.stopPropagation(),e.preventDefault()},style:{padding:"0px 16px"}},this.state.sidebarBody.map((function(t,a){return r.a.createElement(m.default,{key:a,index:a,icon:t.icon,title:t.title,value:t.value,data:t.data,device_option:t.device_option,sysStyle:t.sysStyle,device:e.state.device,uSidebarMenu_selectItem:e.props.dataFull.abs_select,uSidebarMenu_chooseItem:e.uSidebarMenu_selectItem,uSidebarMenu_selectItemChild:e.uSidebarMenu_selectItemChild,closeNav:e.closeNav})}))))))):r.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"openNav",value:function(){"expand"!==this.state.show?(this.setState({show:"expand"}),"mobile"!==this.state.device?window.anime({targets:".malibu-desktop-uSidebarMenu-navbar-list-menu",translateX:516,duration:100}):window.anime({targets:".malibu-mobile-navbar-list-menu-div",translateX:500,duration:100})):(this.setState({show:""}),"mobile"!==this.state.device?window.anime({targets:".malibu-desktop-uSidebarMenu-navbar-list-menu",translateX:-516,duration:100}):window.anime({targets:".malibu-mobile-navbar-list-menu-div",translateX:-500,duration:100}),this.checkData())}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(o.Component);t.default=p},257:function(e,t,a){"use strict";a.r(t);var s=a(1312),i=a(1),n=a(2),l=a(4),o=a(3),r=a(0),c=a.n(r),u=a(22),m=a(9),d=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var s;return Object(i.a)(this,a),(s=t.call(this,e)).abs_focus=function(e){s.listItem_[e].abs_focus()},s.abs_HookKey=function(e){"Escape"===e.key&&void 0!==s.props.stateData.abs_Close&&s.props.stateData.abs_Close()},s.class_desktop="malibu-desktop-form-jwebui_Confirm",s}return Object(n.a)(a,[{key:"render",value:function(){var e,t=this;return c.a.createElement(m.default,{dataFull:{config:{default:{title:this.props.stateData.title,size:"S"},cmd:{visibility:this.props.stateData.visibility}},abs_Close:this.props.stateData.abs_Close}},c.a.createElement("div",{className:this.class_desktop},c.a.createElement("div",{className:this.class_desktop+"-content"},c.a.createElement("div",{className:this.class_desktop+"-content-title"+(this.props.stateData.main_content?" malibu-align_center row":"")},this.props.stateData.content,this.props.stateData.main_content&&c.a.createElement("div",{className:"row",style:{alignItems:"center"}},c.a.createElement("div",{className:this.class_desktop+"-main_content"},this.props.stateData.main_content),"?")),c.a.createElement("hr",{style:{border:"1px solid #ECF0F4",margin:"unset"}}),c.a.createElement("div",{className:this.class_desktop+"-content-listButton row",onKeyUp:function(e){}},null===(e=this.props.stateData.listButton)||void 0===e?void 0:e.map((function(e,a){return c.a.createElement(u.default,{ref:function(e){void 0===t.listItem_&&(t.listItem_=[]),t.listItem_[a]=e},key:a,dataFull:Object(s.a)(Object(s.a)({},e.dataFull),{},{abs_HookKey:t.abs_HookKey,abs_Click:e.abs_Click})})}))))))}}]),a}(r.Component);t.default=d},618:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),n=a(4),l=a(3),o=a(0),r=a.n(o),c=a(6),u=function(e){Object(n.a)(a,e);var t=Object(l.a)(a);function a(e){var i;Object(s.a)(this,a),(i=t.call(this,e)).abs_focus=function(){i.ref_item.focus()},i.abs_blur=function(){i.ref_item.blur()};var n={paddingLeft:"8px"};return i.props.icon||(n={}),i.state={style:n,style_icon:{fontSize:"27.98px",float:"left"}},i}return Object(i.a)(a,[{key:"render",value:function(){var e=this;return r.a.createElement("div",{className:"malibu-uAppMenu-item-card-div col-4",tabIndex:1,ref:function(t){e.ref_item=t},onKeyUp:function(t){e.props.abs_KeyUp(t,e.props.index)},onKeyDown:function(t){e.props.abs_KeyDown(t,e.props.index)}},r.a.createElement("div",{className:"malibu-uAppMenu-item-card",style:{userSelect:"none"},onClick:function(t){void 0!==e.props.appItem_Select&&e.props.appItem_Select(e.props.dataItem,e.props.index)}},r.a.createElement("div",{className:"app-item "},r.a.createElement("div",{className:"malibu-uApp-img "},this.props.val?r.a.createElement(c.default,{val:this.props.val,class:" ",style:{width:"50px",height:"50px",fontSize:"50px"},title:""}):null),r.a.createElement("div",{className:"malibu-uApp-title "},this.props.title?r.a.createElement("span",{className:"dHeader-span",style:this.state.style},r.a.createElement("div",{style:this.state.style_title},this.props.title)):null))))}}]),a}(o.Component);t.default=u},619:function(e,t,a){"use strict";a.r(t),a.d(t,"default",(function(){return u}));var s=a(1),i=a(2),n=a(4),l=a(3),o=a(0),r=a.n(o),c=a(5),u=function(e){Object(n.a)(a,e);var t=Object(l.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).state={sysStyle:{show:!1}},i}return Object(i.a)(a,[{key:"componentDidUpdate",value:function(e){void 0!==this.props.sysStyle&&(void 0===e.sysStyle||this.props.sysStyle.show!==e.sysStyle.show)&&this.setState({sysStyle:this.props.sysStyle})}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.props.device||"desktop_small"===this.props.device||"desktop_small"===this.props.device||"tablet"===this.props.device?r.a.createElement("li",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li "+this.state.sysStyle.show},r.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li-title",onClick:function(){0===e.props.data.length&&e.props.closeNav()}},r.a.createElement("span",{"aria-hidden":"true",className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li-icon material-icons-outlined "},Object(c.d)(this.props.icon)),r.a.createElement("label",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li-item"},this.props.title),this.props.data.length>0&&r.a.createElement("i",{className:"material-icons arrow-item"},"keyboard_arrow_right")),this.props.data.length>0&&r.a.createElement("div",{className:"transparent"}),this.props.data.length>0&&r.a.createElement("ul",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul"},this.props.data.map((function(t,a){return void 0===t.data&&(t.data=[]),void 0===t.sysStyle&&(t.sysStyle={}),void 0===t.sysStyle.show&&(t.sysStyle.show=""),r.a.createElement("li",{key:a,className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul-li ",onClick:function(){0===t.data.length&&(void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(t),e.props.closeNav())}},r.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul-li-title"},r.a.createElement("label",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul-li-item",style:{cursor:"pointer"}},t.title),t.data.length>0&&r.a.createElement("i",{className:"material-icons arrow-item"},"keyboard_arrow_right")),r.a.createElement("div",{className:"transparent-child"}),t.data.length>0&&r.a.createElement("ul",{key:a,className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-child-ul "},t.data.map((function(t,a){return r.a.createElement("li",{key:a,className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-child-ul-li",onClick:function(){void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(t),e.props.closeNav()},style:{cursor:"pointer"}},t.title)}))))})))):"mobile"===this.props.device?r.a.createElement("li",{className:"malibu-mobile-navbar-list-menu-ul-li "+(this.state.sysStyle.show?"expand":"")},r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-ul-li-title ",onClick:function(){0===e.props.data.length?e.props.closeNav():e.props.uSidebarMenu_chooseItem(e.props.index)}},r.a.createElement("label",{className:"malibu-mobile-navbar-list-menu-ul-li-item"},this.props.title),this.props.data.length>0&&r.a.createElement("i",{className:"material-icons arrow-item malibu-mobile-arrow-item-1"},"keyboard_arrow_right")),this.props.data.length>0&&r.a.createElement("ul",{className:"malibu-mobile-navbar-list-menu-child-ul",style:{display:this.state.sysStyle.show?"block":"none"}},this.props.data.map((function(t,a){return void 0===t.data&&(t.data=[]),void 0===t.sysStyle&&(t.sysStyle={}),void 0===t.sysStyle.show&&(t.sysStyle.show=!1),r.a.createElement("li",{key:a,className:"malibu-mobile-navbar-list-menu-child-ul-li ",onClick:function(){0===t.data.length?(void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(t),e.props.closeNav()):void 0!==e.props.uSidebarMenu_selectItemChild&&e.props.uSidebarMenu_selectItemChild(e.props.index,a)}},r.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-child-ul-li-title "+(t.sysStyle.show?"expand":"")},r.a.createElement("label",{className:"malibu-mobile-navbar-list-menu-child-ul-li-item",style:{cursor:"pointer"}},t.title),t.data.length>0&&r.a.createElement("i",{className:"material-icons arrow-item malibu-mobile-arrow-item-2"},"keyboard_arrow_right")),t.data.length>0&&r.a.createElement("ul",{key:a,className:"malibu-mobile-navbar-list-menu-child-child-ul ",style:{display:t.sysStyle.show?"block":"none"}},t.data.map((function(a,s){return r.a.createElement("li",{key:s,className:"malibu-mobile-navbar-list-menu-child-child-ul-li "+(0===s?"first":"")+(s===t.data.length-1?"last":""),onClick:function(){void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(a),e.props.closeNav()},style:{cursor:"pointer"}},a.title)}))))})))):null}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(o.Component)},727:function(e,t,a){"use strict";a.r(t);var s=a(1312),i=a(1),n=a(2),l=a(4),o=a(3),r=a(0),c=a.n(r),u=a(257),m=a(19),d=a(32),p=a(17),b=function(e){Object(l.a)(a,e);var t=Object(o.a)(a);function a(e){var s;return Object(i.a)(this,a),(s=t.call(this,e)).abs_close=function(){s.setState({visibility:!1})},s.abs_Click=function(){console.log("click butotn"),s.setState({visibility:!1})},s.state={visibility:!1},s}return Object(n.a)(a,[{key:"getDataForm",value:function(){return{title:"Delete selected files?",content:"Are you sure you want to delete selected files?",main_content:"ABC_123",abs_Click:this.click,visibility:this.state.visibility,abs_Close:this.abs_close,listButton:[{dataFull:{config:{default:{title:"Add new",type:"",class:""}}},abs_Click:this.abs_Click},{dataFull:{config:{default:{title:"Add new",type:"primary",class:""}}},abs_Click:this.abs_Click}]}}},{key:"render",value:function(){var e=this;return c.a.createElement(c.a.Fragment,null,c.a.createElement("div",{className:"d-flex col-12 malibu-desktop-header"},c.a.createElement(m.default,{dataFull:this.props.dataFull.uSlidebarMenu}),c.a.createElement("div",{className:"main",style:{width:"100%"}},c.a.createElement(d.default,{sysCallBack:this.sysCallBack,dataFull:this.props.dataFull.uHeader})),c.a.createElement(p.default,{dataFull:this.props.dataFull.uAppMenu})),c.a.createElement("div",{className:"d-flex col-12 malibu-desktop-content"},c.a.createElement("div",{className:"main",style:{width:"100%"}},c.a.createElement("div",{onClick:function(){e.setState({visibility:!0},(function(){e.confim.abs_focus(0)}))}},"aaaaa"),c.a.createElement(u.default,{ref:function(t){e.confim=t},stateData:Object(s.a)({},this.getDataForm())}))))}}]),a}(r.Component);t.default=b}}]);