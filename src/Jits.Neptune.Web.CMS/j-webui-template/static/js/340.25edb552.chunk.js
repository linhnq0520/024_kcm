(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[340,585],{18:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),u=a(594),d=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s;return Object(l.a)(this,a),(s=t.call(this,e)).abstract_changeDevice=function(e){s.setState({device:e})},s.type_component="uView",s.code_component="perseus.uView",s.id_theme_component=Object(r.c)(),s.class={desktop:"perseus-desktop-uView",desktop_small:"perseus-desktop_small-uView",tablet:"perseus-tablet-uView",mobile:"perseus-mobile-uView"},s.state={device:Object(r.f)(),skin_config:Object(u.configTemplate_getTheme)()},s}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"renderForDevice",value:function(){var e,t,a,l,s,i,o,n,r,u,d,p,m,v,h,f,k,b,g,_,F,E,y,C,w,x,N,j,O,B;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?c.a.createElement("div",{className:this.class[this.state.device]+""+((null===(e=this.props.dataFull)||void 0===e||null===(t=e.config)||void 0===t||null===(a=t.default)||void 0===a?void 0:a.class)?" "+(null===(l=this.props.dataFull)||void 0===l||null===(s=l.config)||void 0===s||null===(i=s.default)||void 0===i?void 0:i.class):" col-12 col-sm-12 col-md-12 col-xl-12 col-lg-12")+((null===(o=this.props.dataFull)||void 0===o||null===(n=o.config)||void 0===n||null===(r=n.default)||void 0===r?void 0:r.isBorder)?" perseus-view-border":"")},c.a.createElement("div",{className:this.class[this.state.device]+"-content"+((null===(u=this.props.dataFull)||void 0===u||null===(d=u.config)||void 0===d||null===(p=d.default)||void 0===p?void 0:p.isBorder)?" perseus-view-border":"")},(null===(m=this.props.dataFull)||void 0===m||null===(v=m.config)||void 0===v||null===(h=v.default)||void 0===h?void 0:h.title)?c.a.createElement("span",{className:this.class[this.state.device]+"-title"},this.props.dataFull.config.default.title):null,c.a.createElement("div",{className:"row"},this.props.children))):"mobile"===this.state.device?c.a.createElement("div",{className:this.class[this.state.device]+""+((null===(f=this.props.dataFull)||void 0===f||null===(k=f.config)||void 0===k||null===(b=k.default)||void 0===b?void 0:b.class)?" "+(null===(g=this.props.dataFull)||void 0===g||null===(_=g.config)||void 0===_||null===(F=_.default)||void 0===F?void 0:F.class):" col-12 col-sm-12 col-md-12 col-xl-12 col-lg-12")+((null===(E=this.props.dataFull)||void 0===E||null===(y=E.config)||void 0===y||null===(C=y.default)||void 0===C?void 0:C.isBorder)?" perseus-view-border":"")},c.a.createElement("div",{className:this.class[this.state.device]+"-content"+((null===(w=this.props.dataFull)||void 0===w||null===(x=w.config)||void 0===x||null===(N=x.default)||void 0===N?void 0:N.isBorder)?" perseus-view-border":"")},(null===(j=this.props.dataFull)||void 0===j||null===(O=j.config)||void 0===O||null===(B=O.default)||void 0===B?void 0:B.title)?c.a.createElement("span",{className:this.class[this.state.device]+"-title"},this.props.dataFull.config.default.title):null,c.a.createElement("div",{className:"row"},this.props.children))):c.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(n.Component);t.default=d},29:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(5),u=a(594),d=a(7),p=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(e){var s,i,o,n,c;return Object(l.a)(this,a),(c=t.call(this,e)).abstract_changeDevice=function(e){c.setState({device:e})},c.abs_focus=function(){c.myButton.focus()},c.type_component="uCheckBox",c.code_component="perseus.uCheckBox",c.id_theme_component=Object(r.c)(),c.class={desktop:"perseus-desktop-uCheckBox",desktop_small:"perseus-desktop_small-uCheckBox",tablet:"perseus-tablet-uCheckBox",mobile:"perseus-mobile-uCheckBox"},c._disable=null===(s=c.props.dataFull.config)||void 0===s||null===(i=s.cmd)||void 0===i?void 0:i.disable,c._lock=null===(o=c.props.dataFull.config)||void 0===o||null===(n=o.cmd)||void 0===n?void 0:n.isLock,c.state={device:Object(r.f)(),skin_config:Object(u.configTemplate_getTheme)(),isChange:!1,isDisMount:"none"},c}return Object(s.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t,a,l,s;if(this._disable=null===(t=e.dataFull.config)||void 0===t||null===(a=t.cmd)||void 0===a?void 0:a.disable,this._lock=null===(l=this.props.dataFull.config)||void 0===l||null===(s=l.cmd)||void 0===s?void 0:s.isLock,this.props.dataFull.value!==e.dataFull.value){var i=!1;e.dataFull.value&&(i=!0),this.setState({isChange:i})}}},{key:"check",value:function(){void 0!==this.props.dataFull.abs_Click&&this.props.dataFull.abs_Click(this.props.dataFull.dataItem,this.props.dataFull.value)}},{key:"getValueCheckBox",value:function(e){switch(e){case!0:return"done";case!1:return" ";case"-":return"remove";default:return" "}}},{key:"getColorCheckBox",value:function(e){switch(e){case!0:return"perseus-isCheck";case!1:return"";case"-":return"perseus-isCheck";default:return""}}},{key:"render",value:function(){var e,t,a,l,s,i,o,n,r,u,p,m,v,h,f,k,b,g,_,F,E,y=this;return!1!==(null===(e=this.props.dataFull.config)||void 0===e||null===(t=e.cmd)||void 0===t?void 0:t.visible)&&c.a.createElement("div",{className:this.class[this.state.device]+"-"+(this.props.dataFull.class?"haveClass perseus-component-margin_top "+this.props.dataFull.class:"")},c.a.createElement("div",{className:this.class[this.state.device]+(this.props.dataFull.title?" hasTitle":"")+((null===(a=this.props.dataFull.config)||void 0===a||null===(l=a.cmd)||void 0===l?void 0:l.disable)?" disable":"")+((null===(s=this.props.dataFull.config)||void 0===s||null===(i=s.cmd)||void 0===i||null===(o=i.error)||void 0===o?void 0:o.message)?" error":"")+(this.state.isChange?" change":"")+((null===(n=this.props.dataFull.config)||void 0===n||null===(r=n.cmd)||void 0===r?void 0:r.isLock)?" lock":"")},c.a.createElement("div",{className:this.class[this.state.device]+"-icon "+this.getColorCheckBox(this.props.dataFull.value),onClick:function(e){e.preventDefault(),e.stopPropagation(),y._disable||y._lock||y.check()},onFocus:function(){(y._disable||y._lock)&&y.ref_myCheckBox.blur()},onKeyUp:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation(),y._disable||y._lock||y.check())},onKeyPress:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},onKeyDown:function(e){32===e.keyCode&&(e.preventDefault(),e.stopPropagation())},tabIndex:(null===(u=this.props.dataFull.config)||void 0===u||null===(p=u.cmd)||void 0===p?void 0:p.disable)||(null===(m=this.props.dataFull.config)||void 0===m||null===(v=m.cmd)||void 0===v?void 0:v.isLock)?-1:1,ref:function(e){y.ref_myCheckBox=e}},c.a.createElement(d.default,{val:this.getValueCheckBox(this.props.dataFull.value),isPointer:!(null===(h=this.props.dataFull.config)||void 0===h||null===(f=h.cmd)||void 0===f?void 0:f.disable)&&!(null===(k=this.props.dataFull.config)||void 0===k||null===(b=k.cmd)||void 0===b?void 0:b.isLock)||"disable",title:"check",class:" ",style:{fontSize:"14px",width:"14px",height:"14px"}})),this.props.dataFull.title?c.a.createElement("div",{className:this.class[this.state.device]+"-title",onClick:function(e){e.preventDefault(),e.stopPropagation(),y._disable||y._lock||y.check()}},this.props.dataFull.title):null),(null===(g=this.props.dataFull.config)||void 0===g||null===(_=g.cmd)||void 0===_||null===(F=_.error)||void 0===F?void 0:F.message)?c.a.createElement("div",{className:this.class[this.state.device]+"-error-message"},null===(E=this.props.dataFull.config)||void 0===E?void 0:E.cmd.error.message):null)}}]),a}(n.Component);t.default=p},321:function(e,t,a){"use strict";a.r(t);var l=a(1),s=a(2),i=a(4),o=a(3),n=a(0),c=a.n(n),r=a(29),u=a(18),d=function(e){Object(i.a)(a,e);var t=Object(o.a)(a);function a(){return Object(l.a)(this,a),t.apply(this,arguments)}return Object(s.a)(a,[{key:"renderRowInput",value:function(e){return e.map((function(e,t){return c.a.createElement("tr",{key:t},c.a.createElement("td",{className:"perseus-input"},e.default.name),c.a.createElement("td",{style:{textAlign:"center"}},c.a.createElement(r.default,{dataFull:{value:e.constructor,dataItem:e.dataItem,abs_Click:e.abs_Click_constructor}})),c.a.createElement("td",{style:{textAlign:"center"}}))}))}},{key:"renderRowView",value:function(e){var t=this;return e.map((function(e,a){return c.a.createElement(c.a.Fragment,{key:a},c.a.createElement("tr",{key:a},c.a.createElement("td",{className:"perseus-view"},c.a.createElement("div",{className:"row"},c.a.createElement("div",{style:{maxWidth:"calc(100%)"}},e.name))),c.a.createElement("td",{style:{textAlign:"center"}},c.a.createElement(r.default,{dataFull:{value:e.constructor,dataItem:e.dataItem,abs_Click:e.abs_Click_constructor}})),c.a.createElement("td",{style:{textAlign:"center"}})),t.renderRowInput(e.list_input))}))}},{key:"renderRowTable",value:function(){var e=this;return this.props.dataFull.list_layout.map((function(t,a){return c.a.createElement(c.a.Fragment,{key:a},c.a.createElement("tr",{key:a,className:"perseus-layout-tr",style:{background:"#ECF0F8"}},c.a.createElement("td",{className:"perseus-layout"},c.a.createElement("div",{className:"row"},c.a.createElement("div",{style:{maxWidth:"calc(100%)"}},t.name))),c.a.createElement("td",{style:{textAlign:"center"}},c.a.createElement(r.default,{dataFull:{value:t.constructor,dataItem:t.dataItem,abs_Click:t.abs_Click_constructor}})),c.a.createElement("td",{style:{textAlign:"center"}})),e.renderRowView(t.list_view))}))}},{key:"render",value:function(){return c.a.createElement(u.default,{dataFull:{config:{default:{class:"col-12 perseus-jwebui_role_matrix_manager"}}}},c.a.createElement("div",{className:"rows perseus-jwebui_role_matrix_manager-content"},c.a.createElement("div",{className:"row"},c.a.createElement("div",{className:"row",style:{marginBottom:"16px",marginRight:"40px"}},c.a.createElement(r.default,{dataFull:{value:this.props.dataFull.access_function||!1,abs_Click:this.props.dataFull.abs_Click_check_access_function}}),c.a.createElement("span",{style:{margin:"auto",marginLeft:"14px",lineHeight:"18px"}},"Access Function")),c.a.createElement("div",{className:"row",style:{marginBottom:"16px"}},c.a.createElement(r.default,{dataFull:{value:this.props.dataFull.data_monitoring||!1,abs_Click:this.props.dataFull.abs_Click_check_data_monitoring}}),c.a.createElement("span",{style:{margin:"auto",marginLeft:"14px",lineHeight:"18px"}},"Data Monitoring"))),c.a.createElement("div",{className:"col-12 perseus-desktop-uTable perseus-jwebui_role_matrix_manager-content-table ",style:{marginTop:"unset !important"}},c.a.createElement("table",{className:"perseus-desktop-uTable-info col-12"},c.a.createElement("thead",null,c.a.createElement("tr",null,c.a.createElement("th",{className:"perseus-desktop-uTable-th "},c.a.createElement("div",{className:"perseus-desktop-uTable-th-div"})),c.a.createElement("th",{className:"perseus-desktop-uTable-th"},c.a.createElement("div",{className:"perseus-desktop-uTable-th-div"},"Constructor")),c.a.createElement("th",{className:"perseus-desktop-uTable-th"},c.a.createElement("div",{className:"perseus-desktop-uTable-th-div"},"Set up Permission")))),c.a.createElement("tbody",{className:"perseus-desktop-uTable-tbody"},this.renderRowTable())))))}}]),a}(n.Component);t.default=d}}]);