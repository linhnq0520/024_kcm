(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[711,330,435,436,781],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return i}));var s=a(1313);function n(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function i(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?n(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):n(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},17:function(e,t,a){"use strict";a.r(t);var s=a(1),n=a(2),i=a(4),l=a(3),r=a(0),o=a.n(r),u=a(5),c=a(593),m=a(618),d=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(e){var n;return Object(s.a)(this,a),(n=t.call(this,e)).abstract_changeDevice=function(e){n.setState({device:e})},n.chooseAPP=function(e,t){n.closeApp(),n.ref_button.blur(),n.ref_menu_item[t].abs_blur(),n.props.dataFull.abs_select(e)},n.KeyUp=function(e,t){switch(e.keyCode){case 27:n.ref_menu_item[t].abs_blur();break;case 13:n.chooseAPP(n.props.dataFull.appItem[t].dataItem,t);break;case 39:t+1<n.props.dataFull.appItem.length&&n.ref_menu_item[t+1].abs_focus();break;case 37:t-1>=0&&n.ref_menu_item[t-1].abs_focus()}},n.KeyDown=function(e,t){switch(e.keyCode){case 40:t+3<n.props.dataFull.appItem.length&&n.ref_menu_item[t+3].abs_focus();break;case 38:t-3>=0&&n.ref_menu_item[t-3].abs_focus()}},n.type_component="uAppMenu",n.code_component="malibu.uAppMenu",n.id_theme_component=Object(u.c)(),n.ref_menu_item=[],n.state={device:Object(u.f)(),skin_config:Object(c.configTemplate_getTheme)(),show:"",isDisMount:"none"},n}return Object(n.a)(a,[{key:"componentWillUnmount",value:function(){Object(u.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(u.b)(this,this.id_theme_component),this.setState({isDisMount:"block"})}},{key:"UNSAFE_componentWillUpdate",value:function(){this.ref_menu_item=[]}},{key:"renderForDevice",value:function(){var e,t=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"desktop_small"===this.state.device||"mobile"===this.state.device?o.a.createElement(o.a.Fragment,null,o.a.createElement("div",{className:"malibu-uAppMenu-header",style:{userSelect:"none"}},o.a.createElement("div",{tabIndex:1,className:"malibu-uAppMenu-span_btn ",style:{cursor:"pointer"},ref:function(e){t.ref_button=e},onMouseDown:function(e){"expand"===t.state.show&&(t.ref_button.blur(),t.closeApp(),e.preventDefault(),e.stopPropagation())},onFocus:function(e){e.preventDefault(),e.stopPropagation(),t.openApp()},onKeyUp:function(e){40===e.keyCode&&t.ref_menu_item[0].abs_focus(),27===e.keyCode&&t.ref_button.blur()}},o.a.createElement("i",{className:"material-icons"},"apps"))),o.a.createElement("div",{className:"malibu-uAppMenu-list-menu"},o.a.createElement("div",{className:"malibu-uAppMenu-list-menu-ul row",onMouseDown:function(e){e.target.focus(),e.preventDefault()}},null===(e=this.props.dataFull.appItem)||void 0===e?void 0:e.map((function(e,a){return void 0===e.class&&(e.class=""),o.a.createElement(m.default,{ref:function(e){t.ref_menu_item[a]=e},class:e.class,device:t.state.device,val:e.icon,key:a,index:a,title:e.title,sysStyle:e.sysStyle,dataItem:e.dataItem,appItem_Select:t.chooseAPP,abs_KeyUp:t.KeyUp,abs_KeyDown:t.KeyDown})}))))):o.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"openApp",value:function(){"expand"!==this.state.show?(this.setState({show:"expand"}),window.anime({targets:".malibu-uAppMenu-list-menu",translateX:-379,duration:100})):(this.setState({show:""}),window.anime({targets:".malibu-uAppMenu-list-menu",translateX:500,duration:100}))}},{key:"closeApp",value:function(){this.setState({show:""}),window.anime({targets:".malibu-uAppMenu-list-menu",translateX:500,duration:100})}},{key:"render",value:function(){var e=this;return o.a.createElement(o.a.Fragment,null,o.a.createElement("div",{className:"malibu-desktop-appnav "+this.state.show,tabIndex:-1,onBlur:function(t){t.currentTarget.contains(t.relatedTarget)||e.closeApp()}},this.renderForDevice()))}}]),a}(r.Component);t.default=d},19:function(e,t,a){"use strict";a.r(t);var s=a(1),n=a(2),i=a(4),l=a(3),r=a(0),o=a.n(r),u=a(5),c=a(593),m=a(619),d=a(6),p=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(e){var n;Object(s.a)(this,a),(n=t.call(this,e)).abstract_changeDevice=function(e){n.setState({device:e})},n.abs_changeLang=function(e){n.setState({sidebarBody:e})},n.uSidebarMenu_selectItem=function(e){var t,a=n.state.sidebarBody;if(a.length>0)for(var s=0;s<a.length;s++){a[s].sysStyle&&!0===a[s].sysStyle.show&&(t=s),a[s].sysStyle={show:!1};for(var i=0;i<a[s].data.length;i++)a[s].data[i].sysStyle&&!0===a[s].data[i].sysStyle.show&&(t=i),a[s].data[i].sysStyle={show:!1}}e!==t&&(a[e].sysStyle={show:!0}),n.setState({sidebarBody:a})},n.uSidebarMenu_selectItemChild=function(e,t){var a,s=n.state.sidebarBody;if(s.length>0)for(var i=0;i<s.length;i++)for(var l=0;l<s[i].data.length;l++)s[i].data[l].sysStyle&&!0===s[i].data[l].sysStyle.show&&(a=l),s[i].data[l].sysStyle={show:!1};t!==a&&(s[e].data[t].sysStyle={show:!0}),n.setState({sidebarBody:s})},n.checkData=function(){for(var e=n.state.sidebarBody,t=0;t<e.length;t++)void 0===e[t].sysStyle&&(e[t].sysStyle={}),void 0!==e[t].sysStyle.show&&"show"!==e[t].sysStyle.show||(e[t].sysStyle.show="");n.setState({sidebarBody:e})},n.closeNav=function(){n.checkData(),n.setState({show:""}),"mobile"!==n.state.device?window.anime({targets:".malibu-desktop-uSidebarMenu-navbar-list-menu",translateX:-516,duration:100}):window.anime({targets:".malibu-mobile-navbar-list-menu-div",translateX:-500,duration:100})},n.type_component="uSlidebar",n.code_component="malibu.uSidebarMenu",n.id_theme_component=Object(u.c)();var i=n.props.dataFull.sidebarBody;return void 0===i&&(i=[]),n.state={device:Object(u.f)(),skin_config:Object(c.configTemplate_getTheme)(),sidebarBody:i,show:"",isDisMount:"none"},n}return Object(n.a)(a,[{key:"componentWillUnmount",value:function(){Object(u.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(u.b)(this,this.id_theme_component),this.setState({isDisMount:"block"})}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?o.a.createElement(o.a.Fragment,null,o.a.createElement("div",{className:"malibu-desktop-uSidebarMenu "+this.state.show,style:{display:this.state.isDisMount}},o.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-header",style:{userSelect:"none"}},o.a.createElement("div",{tabIndex:0,className:"malibu-desktop-uSidebarMenu-header-button",style:{cursor:"pointer"},onClick:function(){e.openNav()},onBlur:function(){e.closeNav()}},o.a.createElement("i",{className:"material-icons-outlined"},"menu"))),o.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu"},o.a.createElement("ul",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul",onMouseDown:function(e){e.target.focus(),e.preventDefault()}},this.state.sidebarBody.map((function(t,a){return o.a.createElement(m.default,{key:a,index:a,icon:t.icon,title:t.title,value:t.value,device_option:t.device_option,device:e.state.device,data:t.data,sysStyle:t.sysStyle,uSidebarMenu_selectItem:e.props.dataFull.abs_select,uSidebarMenu_chooseItem:e.uSidebarMenu_selectItem,uSidebarMenu_selectItemChild:e.uSidebarMenu_selectItemChild,closeNav:e.closeNav})}))))),o.a.createElement("div",{className:"blank"})):"mobile"===this.state.device?o.a.createElement("div",{className:"malibu-mobile-uSidebarMenu "+this.state.show,style:{display:this.state.isDisMount}},o.a.createElement("div",{className:"malibu-mobile-uSidebarMenu-header",style:{userSelect:"none",background:"unset "}},o.a.createElement("div",{tabIndex:0,className:"malibu-mobile-uSidebarMenu-header-button",style:{cursor:"pointer"},onClick:function(){e.openNav()},onBlur:function(){e.closeNav()}},o.a.createElement("i",{className:"material-icons-outlined"},"menu"))),o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu ",onClick:function(e){e.stopPropagation(),e.preventDefault()}},o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-div",onMouseDown:function(e){e.preventDefault(),e.stopPropagation(),e.target.focus(),e.stopPropagation(),e.preventDefault()}},o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-header"},o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-header-button_close",onClick:function(){e.closeNav()}},o.a.createElement(d.default,{val:"close",style:{fontSize:"28px"}}))),o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-content"},o.a.createElement("ul",{className:"malibu-mobile-uSidebarMenu-list-menu-ul",onMouseDown:function(e){e.target.focus(),e.stopPropagation(),e.preventDefault()},style:{padding:"0px 16px"}},this.state.sidebarBody.map((function(t,a){return o.a.createElement(m.default,{key:a,index:a,icon:t.icon,title:t.title,value:t.value,data:t.data,device_option:t.device_option,sysStyle:t.sysStyle,device:e.state.device,uSidebarMenu_selectItem:e.props.dataFull.abs_select,uSidebarMenu_chooseItem:e.uSidebarMenu_selectItem,uSidebarMenu_selectItemChild:e.uSidebarMenu_selectItemChild,closeNav:e.closeNav})}))))))):o.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"openNav",value:function(){"expand"!==this.state.show?(this.setState({show:"expand"}),"mobile"!==this.state.device?window.anime({targets:".malibu-desktop-uSidebarMenu-navbar-list-menu",translateX:516,duration:100}):window.anime({targets:".malibu-mobile-navbar-list-menu-div",translateX:500,duration:100})):(this.setState({show:""}),"mobile"!==this.state.device?window.anime({targets:".malibu-desktop-uSidebarMenu-navbar-list-menu",translateX:-516,duration:100}):window.anime({targets:".malibu-mobile-navbar-list-menu-div",translateX:-500,duration:100}),this.checkData())}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(r.Component);t.default=p},255:function(e,t,a){"use strict";a.r(t);var s=a(1),n=a(2),i=a(4),l=a(3),r=a(0),o=a.n(r),u=a(22),c=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(){return Object(s.a)(this,a),t.apply(this,arguments)}return Object(n.a)(a,[{key:"render",value:function(){return this.props.stateData.form.cmd.visible&&o.a.createElement("div",{className:"malibu-form-404"},o.a.createElement("div",{className:"malibu-form-404-img"}),o.a.createElement("div",{className:"malibu-form-404-title"},this.props.stateData.form.title),o.a.createElement("div",{className:"malibu-form-404-button"}," ",o.a.createElement(u.default,this.props.stateData.btn_home)))}}]),a}(r.Component);t.default=c},618:function(e,t,a){"use strict";a.r(t);var s=a(1),n=a(2),i=a(4),l=a(3),r=a(0),o=a.n(r),u=a(6),c=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(e){var n;Object(s.a)(this,a),(n=t.call(this,e)).abs_focus=function(){n.ref_item.focus()},n.abs_blur=function(){n.ref_item.blur()};var i={paddingLeft:"8px"};return n.props.icon||(i={}),n.state={style:i,style_icon:{fontSize:"27.98px",float:"left"}},n}return Object(n.a)(a,[{key:"render",value:function(){var e=this;return o.a.createElement("div",{className:"malibu-uAppMenu-item-card-div col-4",tabIndex:1,ref:function(t){e.ref_item=t},onKeyUp:function(t){e.props.abs_KeyUp(t,e.props.index)},onKeyDown:function(t){e.props.abs_KeyDown(t,e.props.index)}},o.a.createElement("div",{className:"malibu-uAppMenu-item-card",style:{userSelect:"none"},onClick:function(t){void 0!==e.props.appItem_Select&&e.props.appItem_Select(e.props.dataItem,e.props.index)}},o.a.createElement("div",{className:"app-item "},o.a.createElement("div",{className:"malibu-uApp-img "},this.props.val?o.a.createElement(u.default,{val:this.props.val,class:" ",style:{width:"50px",height:"50px",fontSize:"50px"},title:""}):null),o.a.createElement("div",{className:"malibu-uApp-title "},this.props.title?o.a.createElement("span",{className:"dHeader-span",style:this.state.style},o.a.createElement("div",{style:this.state.style_title},this.props.title)):null))))}}]),a}(r.Component);t.default=c},619:function(e,t,a){"use strict";a.r(t),a.d(t,"default",(function(){return c}));var s=a(1),n=a(2),i=a(4),l=a(3),r=a(0),o=a.n(r),u=a(5),c=function(e){Object(i.a)(a,e);var t=Object(l.a)(a);function a(e){var n;return Object(s.a)(this,a),(n=t.call(this,e)).state={sysStyle:{show:!1}},n}return Object(n.a)(a,[{key:"componentDidUpdate",value:function(e){void 0!==this.props.sysStyle&&(void 0===e.sysStyle||this.props.sysStyle.show!==e.sysStyle.show)&&this.setState({sysStyle:this.props.sysStyle})}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.props.device||"desktop_small"===this.props.device||"desktop_small"===this.props.device||"tablet"===this.props.device?o.a.createElement("li",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li "+this.state.sysStyle.show},o.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li-title",onClick:function(){0===e.props.data.length&&e.props.closeNav()}},o.a.createElement("span",{"aria-hidden":"true",className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li-icon material-icons-outlined "},Object(u.d)(this.props.icon)),o.a.createElement("label",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-ul-li-item"},this.props.title),this.props.data.length>0&&o.a.createElement("i",{className:"material-icons arrow-item"},"keyboard_arrow_right")),this.props.data.length>0&&o.a.createElement("div",{className:"transparent"}),this.props.data.length>0&&o.a.createElement("ul",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul"},this.props.data.map((function(t,a){return void 0===t.data&&(t.data=[]),void 0===t.sysStyle&&(t.sysStyle={}),void 0===t.sysStyle.show&&(t.sysStyle.show=""),o.a.createElement("li",{key:a,className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul-li ",onClick:function(){0===t.data.length&&(void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(t),e.props.closeNav())}},o.a.createElement("div",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul-li-title"},o.a.createElement("label",{className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-ul-li-item",style:{cursor:"pointer"}},t.title),t.data.length>0&&o.a.createElement("i",{className:"material-icons arrow-item"},"keyboard_arrow_right")),o.a.createElement("div",{className:"transparent-child"}),t.data.length>0&&o.a.createElement("ul",{key:a,className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-child-ul "},t.data.map((function(t,a){return o.a.createElement("li",{key:a,className:"malibu-desktop-uSidebarMenu-navbar-list-menu-child-child-ul-li",onClick:function(){void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(t),e.props.closeNav()},style:{cursor:"pointer"}},t.title)}))))})))):"mobile"===this.props.device?o.a.createElement("li",{className:"malibu-mobile-navbar-list-menu-ul-li "+(this.state.sysStyle.show?"expand":"")},o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-ul-li-title ",onClick:function(){0===e.props.data.length?e.props.closeNav():e.props.uSidebarMenu_chooseItem(e.props.index)}},o.a.createElement("label",{className:"malibu-mobile-navbar-list-menu-ul-li-item"},this.props.title),this.props.data.length>0&&o.a.createElement("i",{className:"material-icons arrow-item malibu-mobile-arrow-item-1"},"keyboard_arrow_right")),this.props.data.length>0&&o.a.createElement("ul",{className:"malibu-mobile-navbar-list-menu-child-ul",style:{display:this.state.sysStyle.show?"block":"none"}},this.props.data.map((function(t,a){return void 0===t.data&&(t.data=[]),void 0===t.sysStyle&&(t.sysStyle={}),void 0===t.sysStyle.show&&(t.sysStyle.show=!1),o.a.createElement("li",{key:a,className:"malibu-mobile-navbar-list-menu-child-ul-li ",onClick:function(){0===t.data.length?(void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(t),e.props.closeNav()):void 0!==e.props.uSidebarMenu_selectItemChild&&e.props.uSidebarMenu_selectItemChild(e.props.index,a)}},o.a.createElement("div",{className:"malibu-mobile-navbar-list-menu-child-ul-li-title "+(t.sysStyle.show?"expand":"")},o.a.createElement("label",{className:"malibu-mobile-navbar-list-menu-child-ul-li-item",style:{cursor:"pointer"}},t.title),t.data.length>0&&o.a.createElement("i",{className:"material-icons arrow-item malibu-mobile-arrow-item-2"},"keyboard_arrow_right")),t.data.length>0&&o.a.createElement("ul",{key:a,className:"malibu-mobile-navbar-list-menu-child-child-ul ",style:{display:t.sysStyle.show?"block":"none"}},t.data.map((function(a,s){return o.a.createElement("li",{key:s,className:"malibu-mobile-navbar-list-menu-child-child-ul-li "+(0===s?"first":"")+(s===t.data.length-1?"last":""),onClick:function(){void 0!==e.props.uSidebarMenu_selectItem&&e.props.uSidebarMenu_selectItem(a),e.props.closeNav()},style:{cursor:"pointer"}},a.title)}))))})))):null}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(r.Component)},726:function(e,t,a){"use strict";a.r(t);var s=a(1312),n=a(1),i=a(2),l=a(4),r=a(3),o=a(0),u=a.n(o),c=a(19),m=a(32),d=a(17),p=a(255),b=function(e){Object(l.a)(a,e);var t=Object(r.a)(a);function a(e){var i;return Object(n.a)(this,a),(i=t.call(this,e)).state={stateData:Object(s.a)({},i.getDataForm())},i}return Object(i.a)(a,[{key:"getDataForm",value:function(){return{form:{cmd:{visible:!0},title:"The webpage you are looking for is not here!"},btn_home:{dataFull:{config:{default:{title:"GO TO HOMEPAGE",type:"",class:""}},abs_Click:this.abs_Click}}}}},{key:"render",value:function(){return u.a.createElement(u.a.Fragment,null,u.a.createElement("div",{className:"d-flex col-12 malibu-desktop-header"},u.a.createElement(c.default,{dataFull:this.props.dataFull.uSlidebarMenu}),u.a.createElement("div",{className:"main",style:{width:"100%"}},u.a.createElement(m.default,{sysCallBack:this.sysCallBack,dataFull:this.props.dataFull.uHeader})),u.a.createElement(d.default,{dataFull:this.props.dataFull.uAppMenu})),u.a.createElement("div",{className:"d-flex col-12 malibu-desktop-content"},u.a.createElement("div",{className:"main",style:{width:"100%"}},u.a.createElement(p.default,{stateData:this.state.stateData}))))}}]),a}(o.Component);t.default=b}}]);