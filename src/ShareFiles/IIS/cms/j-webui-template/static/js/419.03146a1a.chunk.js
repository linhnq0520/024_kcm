(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[419,803],{645:function(e,t,i){"use strict";i.r(t),i.d(t,"default",(function(){return u}));var s=i(1),a=i(2),o=i(4),c=i(3),l=i(0),n=i.n(l),r=i(7),u=function(e){Object(o.a)(i,e);var t=Object(c.a)(i);function i(e){var a,o;Object(s.a)(this,i),(a=t.call(this,e)).class={desktop:"perseus-desktop-uNotification",desktop_small:"perseus-desktop_small-uNotification",tablet:"perseus-tablet-uNotification",mobile:"perseus-mobile-uNotification"};var c=a.props.item.config;return void 0===c&&(c={}),o=void 0===c.time_out?5e3:c.time_out,a.state={visible:!0,time_out:o,class:""},a._isClose=!1,a}return Object(a.a)(i,[{key:"componentDidMount",value:function(){this.setTimer()}},{key:"setTimer",value:function(){var e=this;null!=this._timer_child&&clearTimeout(this._timer_child),this._timer_child=setTimeout((function(){!1===e._isClose&&e.setState({class:"fade-in"},(function(){setTimeout((function(){e.setState({visible:!1},(function(){e._timer_child=null,e.props.abs_uNotificationItem_DeleteMe(e.props.item.id)}))}),1e3)}))}),this.state.time_out)}},{key:"render",value:function(){var e=this;return this.state.visible&&n.a.createElement("div",{key:this.props.index,className:this.class[this.props.device]+" "+this.state.class+" perseus-"+this.props.item.color},n.a.createElement("div",{className:this.class[this.props.device]+"-content row"},n.a.createElement("div",{className:this.class[this.props.device]+"-icon-div"},n.a.createElement(r.default,{val:this.props.icon_.val,class:this.props.icon_.class,style:{width:"28px",height:"28px",fontSize:"28px",margin:"auto 0px"},isPointer:!1,title:this.props.icon_.title})),n.a.createElement("div",{className:this.class[this.props.device]+"-title-div"},n.a.createElement("div",{className:this.class[this.props.device]+"-title"},this.props.item.title)),n.a.createElement("div",{className:this.class[this.props.device]+"-close perseus-button_icon",onClick:function(){e._isClose=!0,e.setTimer(),e.setState({class:"fade-out"},(function(){setTimeout((function(){e.setState({visible:!1}),e._timer_child=null}),300)})),e.props.abs_uNotificationItem_DeleteMe(e.props.item.id)}},n.a.createElement(r.default,{val:"close",style:{width:"24px",height:"24px",fontSize:"24px"},title:"close"}))))}}]),i}(l.Component)},91:function(e,t,i){"use strict";i.r(t);var s=i(1),a=i(2),o=i(4),c=i(3),l=i(0),n=i.n(l),r=i(5),u=i(594),d=i(645),p=function(e){Object(o.a)(i,e);var t=Object(c.a)(i);function i(e){var a;Object(s.a)(this,i),(a=t.call(this,e)).abstract_changeDevice=function(e){a.setState({device:e})},a.abs_uNotificationItem_DeleteMe=function(e){void 0!==a.props.dataFull.abs_Delete&&a.props.dataFull.abs_Delete(e)};var o=a.props.dataFull.config;return void 0===o&&(o={}),a.type_component="uNotification",a.code_component="perseus.uNotification",a.class={desktop:"perseus-desktop-uNotification-list",desktop_small:"perseus-desktop_small-uNotification-list",tablet:"perseus-tablet-uNotification-list",mobile:"perseus-mobile-uNotification-list"},a.id_theme_component=Object(r.c)(),a._totalId=a.props.dataFull.data.length,a.state={device:Object(r.f)(),skin_config:Object(u.configTemplate_getTheme)(),config:o},a}return Object(a.a)(i,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"renderByData",value:function(e,t){var i;switch(e.color){case"success":i={val:"check_circle",class:"-round",title:"success"};break;case"info":i={val:"error",class:"-round",title:"info"};break;case"warning":i={val:"report_problem",class:"-round",title:"info"};break;case"":e.color="success",i={val:"check_circle",class:"-round",title:"success"};break;default:e.color="fail",i={val:"cancel",class:"-round",title:"fail"}}return n.a.createElement(d.default,{item:e,device:this.state.device,index:t,key:e.id,icon_:i,mode:this.state.mode,abs_uNotificationItem_DeleteMe:this.abs_uNotificationItem_DeleteMe})}},{key:"componentDidUpdate",value:function(e){var t;void 0!==this.props.dataFull.data&&(void 0!==e.dataFull.data&&this.props.dataFull.data!==e.dataFull.data&&((null===(t=this.props.dataFull.data)||void 0===t?void 0:t.length)>10?this._hasSearch=!0:this._hasSearch=!1))}},{key:"render",value:function(){var e,t,i,s=this;return(null===(e=this.props.dataFull)||void 0===e||null===(t=e.data)||void 0===t?void 0:t.length)>0&&n.a.createElement("div",{className:this.class[this.state.device]},JSON.parse(JSON.stringify(null===(i=this.props.dataFull)||void 0===i?void 0:i.data)).reverse().map((function(e,t){return s.renderByData(e,t)})))}}]),i}(l.Component);t.default=p}}]);