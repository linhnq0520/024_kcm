(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[44,33,292,293,294,295,296,297,298,435,436],{1312:function(e,t,a){"use strict";a.d(t,"a",(function(){return c}));var s=a(1313);function i(e,t){var a=Object.keys(e);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);t&&(s=s.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),a.push.apply(a,s)}return a}function c(e){for(var t=1;t<arguments.length;t++){var a=null!=arguments[t]?arguments[t]:{};t%2?i(Object(a),!0).forEach((function(t){Object(s.a)(e,t,a[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(a)):i(Object(a)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(a,t))}))}return e}},1313:function(e,t,a){"use strict";function s(e,t,a){return t in e?Object.defineProperty(e,t,{value:a,enumerable:!0,configurable:!0,writable:!0}):e[t]=a,e}a.d(t,"a",(function(){return s}))},332:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),c=a(4),o=a(3),l=a(0),n=a.n(l),r=a(6),m=function(e){Object(c.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).class_chat_system_desktop="malibu-chat_system",i.class_choose_service="choose_service",i.class_chat_person="chat_person",i.class_my_conversations="my_conversations",i.class_my_contacts="my_contacts",i.state={heightHeader:0,heightHeaderActive:0,isOpen:!1,service_id:"",left:0},i}return Object(i.a)(a,[{key:"componentDidMount",value:function(){void 0!==this.myHeader&&this.myHeader.offsetHeight!==this.state.heightHeader&&this.setState({heightHeader:this.myHeader.offsetHeight}),void 0!==this.myChat&&(this.myChat.scrollTop=this.myChat.scrollHeight),void 0!==this.props.stateData.service_id&&this.setState({service_id:this.props.stateData.service_id})}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;void 0!==this.myHeader&&this.myHeader.offsetHeight!==this.state.heightHeader&&this.setState({heightHeader:this.myHeader.offsetHeight}),void 0!==this.myButtonNew&&this.myButtonNew.offsetWidth!==this.state.left&&this.setState({left:this.myButtonNew.offsetWidth}),this.props.stateData.service_id!==e.stateData.service_id&&this.setState({service_id:e.stateData.service_id},(function(){void 0!==t.myHeader&&t.setState({heightHeader:t.myHeader.offsetHeight})}))}},{key:"componentDidUpdate",value:function(){void 0!==this.myChat&&!0!==this._see_more&&(this.myChat.scrollTop=this.myChat.scrollHeight),void 0!==this.my_conversations&&(this.my_conversations.scrollTop=0)}},{key:"render",value:function(){var e,t=this;return n.a.createElement("div",{className:this.class_chat_system_desktop},n.a.createElement("div",{className:this.class_chat_system_desktop+"-icon",onClick:function(){t.setState({isOpen:!t.state.isOpen},(function(){void 0!==t.myHeader&&t.myHeader.offsetHeight!==t.state.heightHeader&&t.setState({heightHeader:t.myHeader.offsetHeight})}))}},n.a.createElement(r.default,{val:"forum",class:"-round",style:{color:"#ffffff",fontSize:"30px",margin:"auto"}})),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat",style:{display:this.state.isOpen?"block":"none"}},n.a.createElement("div",{className:this.class_chat_system_desktop+"-header"},n.a.createElement("div",{className:this.class_chat_system_desktop+"-header-begin",style:{display:"default"===this.state.service_id?"block":"none"},ref:function(e){t.myHeader=e}},n.a.createElement("div",{className:this.class_chat_system_desktop+"-header-begin-title"},this.props.stateData.chat_header.header_begin.title),n.a.createElement("div",{className:this.class_chat_system_desktop+"-header-beign-title_sub"},this.props.stateData.chat_header.header_begin.title_sub)),n.a.createElement("div",{className:this.class_chat_system_desktop+"-header-active row",style:{display:"default"===this.state.service_id?"none":"flex"}},n.a.createElement("div",{style:{height:"20px",margin:"auto 0px"},onClick:function(){void 0!==t.props.stateData.call_back.abs_callBack&&t.props.stateData.call_back.abs_callBack(t.state.service_id)}},n.a.createElement(r.default,{val:"arrow_back_ios",style:{color:"#ffffff",fontSize:"20px",height:"20px",margin:"auto 0px"}})),n.a.createElement("div",{className:this.class_chat_system_desktop+"-header-active-content"},this.props.stateData.chat_header.header_active.img?n.a.createElement(r.default,{val:this.props.stateData.chat_header.header_active.img,style:{color:"#ffffff",fontSize:"40px",width:"40px",height:"40px",margin:"auto 0px",borderRadius:"50%",marginRight:"8px"}}):null,n.a.createElement("div",{className:this.class_chat_system_desktop+"-header-active-content-title"},this.props.stateData.chat_header.header_active.title)),n.a.createElement(r.default,{val:"clear",style:{color:"#ffffff",fontSize:"20px",height:"20px",margin:"auto 0px"}}))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content"},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_choose_service,style:{minHeight:"calc( 496px - "+this.state.heightHeader+"px)",maxHeight:"calc( 496px - "+this.state.heightHeader+"px)",display:"default"===this.state.service_id?"block":"none"}},this.props.stateData.list_service.map((function(e,a){return n.a.createElement("div",{key:a,className:t.class_chat_system_desktop+"-chat-content-"+t.class_choose_service+"-item",onClick:function(){void 0!==e.abs_Click&&e.abs_Click(e.id)}},n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_choose_service+"-item-header"}),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_choose_service+"-item-content"},n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_choose_service+"-item-content-title"},e.title),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_choose_service+"-item-content-button row"},n.a.createElement(r.default,{val:e.img_icon,style:{fontSize:"20px"}}),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_choose_service+"-item-content-button-title"},e.message))))}))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person,style:{display:"chat"===this.state.service_id||"debug"===this.state.service_id?"block":"none"}},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-content",ref:function(e){t.myChat=e}},this.props.stateData.chat_person.see_more.isShow&&n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-content-see_more-div"},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-content-see_more-button row",onClick:function(){t.props.stateData.chat_person.see_more.abs_Click(),t._see_more=!0,setTimeout((function(){t._see_more=!1}),500)}},n.a.createElement("div",{className:"see_more_loading"}),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-content-see_more-button-title"},this.props.stateData.chat_person.see_more.title))),this.props.stateData.chat_person.data.map((function(e,a){var s;return n.a.createElement("div",{className:"col-12"},n.a.createElement("div",{key:a,className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-item row "+e.from+("me"===e.from?" d-flex flex-row-reverse":""),style:{marginBottom:a<t.props.stateData.chat_person.data.length-1&&t.props.stateData.chat_person.data[a+1].from===e.from?"6px":a===t.props.stateData.chat_person.data.length-1?"unset":" 12px"}},"reciever"===e.from?n.a.createElement(r.default,{val:t.props.stateData.chat_person.img_person_chat_with,style:{color:"#ffffff",fontSize:"40px",width:"40px",height:"40px",borderRadius:"50%",marginRight:"12px"}}):null,n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-item-content"},(a>0&&t.props.stateData.chat_person.data[a-1].from!==e.from||0===a)&&n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-time"},e.time),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-item-message",style:{marginBottom:a===t.props.stateData.chat_person.data.length-1&&"me"===e.from?"4px":""}},e.content),a===t.props.stateData.chat_person.data.length-1&&"me"===e.from&&n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-item-message-status"},n.a.createElement("div",null," ",e.status)),void 0!==e.list_button&&e.list_button.length>0&&n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-item-list_button row"+(a>0&&t.props.stateData.chat_person.data[a-1].from!==e.from||0===a?" hasTime":"")+("me"===e.from?" d-flex flex-row-reverse":"")+(a===t.props.stateData.chat_person.data.length-1&&"me"===e.from?" hasStatus":"")},null===(s=e.list_button)||void 0===s?void 0:s.map((function(a,s){return n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_chat_person+"-item-button "+e.from,key:s,title:a.title,onClick:function(e){void 0!==a.abs_Click&&a.abs_Click(a.dataItem)}},n.a.createElement(r.default,{val:a.icon,class:"-round",style:{color:"rgba(73, 79, 89, 0.5)",fontSize:"20px"}}))}))))))}))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-chat"},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-chat-inbox"},n.a.createElement("textarea",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-chat-inbox-textArea",ref:function(e){t.myTextArea=e},placeholder:this.props.stateData.text_inbox.placeholder,onKeyDown:function(e){e.altKey&&t.setState({altKey:!0}),13!==e.keyCode&&13!==e.which||!t.state.altKey||void 0!==t.props.stateData.text_inbox.abs_AltEnter&&t.props.stateData.text_inbox.abs_AltEnter(e)},onChange:function(e){void 0!==t.props.stateData.text_inbox.abs_Change&&t.props.stateData.text_inbox.abs_Change(e)},onKeyUp:function(e){13===e.keyCode&&!1===t.state.altKey&&void 0!==t.props.stateData.text_inbox.abs_Send&&t.props.stateData.text_inbox.abs_Send(e),t.setState({altKey:!1})}},this.props.stateData.text_inbox.value)),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-chat-inbox-icon"},n.a.createElement(r.default,{val:"sentiment_satisfied_alt",style:{fontSize:"20px",marginRight:"12px"}}),n.a.createElement(r.default,{val:"attach_file",style:{fontSize:"20px"}})),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_chat_person+"-chat-inbox-icon-right"+((null===(e=this.myTextArea)||void 0===e?void 0:e.value.length)>0?" hasText":""),onClick:function(){void 0!==t.props.stateData.text_inbox.abs_Send&&(t.props.stateData.text_inbox.abs_Send(t.myTextArea.value),t.myTextArea.value="")}},n.a.createElement(r.default,{val:"send",class:" ",style:{fontSize:"20px"}})))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_conversations,style:{display:"conversations"===this.state.service_id?"block":"none"},ref:function(e){t.my_conversations=e}},n.a.createElement("div",null,this.props.stateData.my_conversations.data.map((function(e,a){return n.a.createElement("div",{key:a,className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_conversations+"-item row"+(e.last_message.unRead&&"me"!==e.last_message.from?" unRead":""),onClick:function(){void 0!==e.abs_Click&&e.abs_Click(e.dataItem)}},n.a.createElement(r.default,{val:e.img,style:{color:"#ffffff",fontSize:"40px",width:"40px",height:"40px",borderRadius:"50%",marginRight:"12px"}}),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_conversations+"-item-content"},n.a.createElement("div",null,n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_conversations+"-item-name"},e.name),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_conversations+"-item-message"+("seen"!==e.last_message.status&&"me"!==e.last_message.from?" unRead":"")},"me"===e.last_message.from?t.props.stateData.my_conversations.lang.you:"",e.last_message.content)),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_conversations+"-item-time"},e.last_message.last_time)))}))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_conversations+"-button"},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_conversations+"-button_new row",onClick:function(){void 0!==t.props.stateData.my_conversations.button_new.abs_Click&&t.props.stateData.my_conversations.button_new.abs_Click()}},n.a.createElement(r.default,{val:"chat",style:{fontSize:"20px"}}),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_conversations+"-button_new-title"},this.props.stateData.my_conversations.button_new.title)))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_contacts,style:{display:"contacts"===this.state.service_id?"block":"none"}},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_contacts+"-search"},n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_contacts+"-search-div"},n.a.createElement(r.default,{val:"search",style:{height:"16px",width:"16px",fontSize:"16px",margin:"11px 12px",color:"#CBD6E2",position:"absolute"}}),n.a.createElement("input",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_contacts+"-search-input",placeholder:this.props.stateData.my_contacts.search.placeholder,value:this.props.stateData.my_contacts.search.value,onChange:function(e){t.props.stateData.my_contacts.search.abs_Change(e)}}))),n.a.createElement("div",{className:this.class_chat_system_desktop+"-chat-content-"+this.class_my_contacts+"-content"},this.props.stateData.my_contacts.data.map((function(e,a){return n.a.createElement("div",{key:a},n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_contacts+"-content-item-header row"},n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_contacts+"-content-item-title"},e.title),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_contacts+"-content-item-hr"})),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_contacts+"-content-item-content"},e.data.map((function(e,a){return n.a.createElement("div",{key:a,className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_contacts+"-content-item_child row"},n.a.createElement("div",{style:{marginRight:"12px",height:"40px"},onClick:function(t){e.abs_Click(e.dataItem)}}," ",n.a.createElement(r.default,{val:e.img,style:{color:"#ffffff",fontSize:"40px",width:"40px",height:"40px",borderRadius:"50%"}})),n.a.createElement("div",{className:t.class_chat_system_desktop+"-chat-content-"+t.class_my_contacts+"-content-item_child-name",onClick:function(t){e.abs_Click(e.dataItem)}},e.name))}))))})))))))}}]),a}(l.Component);t.default=m},6:function(e,t,a){"use strict";a.r(t);var s=a(1312),i=a(1),c=a(2),o=a(4),l=a(3),n=a(0),r=a.n(n),m=a(9),p=a(5),h=function(e){Object(o.a)(a,e);var t=Object(l.a)(a);function a(e){var c;Object(i.a)(this,a);var o=(c=t.call(this,e)).props.style;return void 0===o&&(o={fontSize:"20px"}),o=!1===c.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none"}):"disable"===c.props.isPointer?Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"not-allowed"}):Object(s.a)(Object(s.a)({},o),{},{userSelect:"none",cursor:"pointer"}),c.state={style:o,isZoom:!1,isOpenModal:!1},c}return Object(c.a)(a,[{key:"componentDidUpdate",value:function(e){if(void 0!==this.props.isPointer&&void 0!==e.isPointer&&this.props.isPointer!==e.isPointer){var t=this.state.style;t="disable"===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"not-allowed"}):!1===this.props.isPointer?Object(s.a)(Object(s.a)({},t),{},{cursor:"default"}):Object(s.a)(Object(s.a)({},t),{},{cursor:"pointer"}),this.setState({style:t})}}},{key:"getURL",value:function(){var e,t=this.dataURItoBlob(null===(e=this.props.viewFile)||void 0===e?void 0:e.content);return""!==t?URL.createObjectURL(t):""}},{key:"isBase64",value:function(e){if(""===e||void 0===e||null===e||""===e.trim())return!1;try{return btoa(atob(e))===e}catch(t){return!1}}},{key:"dataURItoBlob",value:function(e){if(this.isBase64(e)){for(var t=window.atob(e),a=new ArrayBuffer(t.length),s=new Uint8Array(a),i=0;i<t.length;i++)s[i]=t.charCodeAt(i);return new Blob([s],{type:this.getFileType()})}return""}},{key:"getFileType",value:function(){switch(this.props.viewFile.file_type){case"pdf":return"application/pdf";case"txt":case"text":case"docx":case"doc":return"text/plain";case"mp4":return"video/mp4";case"mp3":return"audio/mp3";default:return"application/pdf"}}},{key:"renderForCondition",value:function(){var e,t,a,i=this;if(this.props.val.includes("data:image")&&this.props.val.includes(";base64,")||this.props.val.includes("//"))return r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:this.props.val,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=i.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==i.props.viewFile.file_type&&"txt"!==i.props.viewFile.file_type?!(null===(t=i.props.viewFile)||void 0===t?void 0:t.isView)&&i.props.isZoom&&!0!==i.state.isZoom&&i.setState({isZoom:!0}):!0!==i.state.isOpenModal&&i.setState({isOpenModal:!0})}}),(null===(e=this.props.viewFile)||void 0===e?void 0:e.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(m.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){i.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!0!==(null===(t=this.props.viewFile)||void 0===t?void 0:t.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==i.state.isZoom&&i.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:this.props.val,alt:this.props.title}))));if(this.props.val.includes("../")||(null===(a=this.props.val[0])||void 0===a?void 0:a.includes("/"))){var c,o,l=this.props.val;return p.a.managerTemplate_isDev()?l=l.replace("../",p.a.managerTemplate_getUrlResource()):p.a.managerTemplate_isCordova()&&(l=l.replace("../",p.a.managerTemplate_getUrlCordova())),r.a.createElement(r.a.Fragment,null,r.a.createElement("img",{className:this.props.class?this.props.class:"",src:l,alt:this.props.title,style:Object(s.a)(Object(s.a)({},this.state.style),{},{cursor:this.props.isZoom?"zoom-in ":""}),onClick:function(){var e,t;!(null===(e=i.props.viewFile)||void 0===e?void 0:e.isView)||"pdf"!==i.props.viewFile.file_type&&"txt"!==i.props.viewFile.file_type?!(null===(t=i.props.viewFile)||void 0===t?void 0:t.isView)&&i.props.isZoom&&!0!==i.state.isZoom&&i.setState({isZoom:!0}):!0!==i.state.isOpenModal&&i.setState({isOpenModal:!0})}}),(null===(c=this.props.viewFile)||void 0===c?void 0:c.isView)&&("pdf"===this.props.viewFile.file_type||"txt"===this.props.viewFile.file_type)&&r.a.createElement(m.default,{dataFull:{config:{default:{title:"",size:"L"},cmd:{visibility:""!==this.getURL()&&this.state.isOpenModal}},abs_Close:function(){i.setState({isOpenModal:!1})}}},r.a.createElement("iframe",{className:"malibu-reuseImg-viewFile",src:this.getURL()+"#toolbar=0",title:"View File"})),this.props.isZoom&&!(null===(o=this.props.viewFile)||void 0===o?void 0:o.isView)&&r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom",onClick:function(){!1!==i.state.isZoom&&i.setState({isZoom:!1})},title:"Click again to zoom out",style:{display:this.state.isZoom?"flex":"none"}},r.a.createElement("div",{className:"malibu-reuseImg-modal_zoom-content"},r.a.createElement("img",{src:l,alt:this.props.title}))))}return r.a.createElement("i",{className:"material-icons"+(this.props.class?this.props.class:"-outlined")+(this.props.color?" "+this.props.color:""),style:this.state.style},Object(p.d)(this.props.val))}},{key:"render",value:function(){return this.renderForCondition()}}]),a}(n.Component);t.default=h},9:function(e,t,a){"use strict";a.r(t);var s=a(1),i=a(2),c=a(4),o=a(3),l=a(0),n=a.n(l),r=a(5),m=a(593),p=a(6),h=function(e){Object(c.a)(a,e);var t=Object(o.a)(a);function a(e){var i;return Object(s.a)(this,a),(i=t.call(this,e)).abs_Focus=function(){i.ref_myModal&&i.ref_myModal.focus()},i.class_desktop="malibu-desktop-uModal",i.class_mobile="malibu-mobile-uModal",i.class_header_desktop="malibu-desktop-form-uModalHeader",i.class_header_mobile="malibu-mobile-form-uModalHeader",i.class_mobile_app="malibu-mobile_app-uModal",i.class_header_mobile_app="malibu-mobile_app-form-uModalHeader",i.type_component="uModal",i.code_component="malibu.uModal",i.id_theme_component=Object(r.c)(),i.state={device:Object(r.f)(),class:"",skin_config:Object(m.configTemplate_getTheme)()},i}return Object(i.a)(a,[{key:"componentWillUnmount",value:function(){Object(r.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(r.b)(this,this.id_theme_component)}},{key:"UNSAFE_componentWillUpdate",value:function(e){var t=this;this.props.dataFull.config.cmd.visibility!==e.dataFull.config.cmd.visibility&&e.dataFull.config.cmd.visibility&&this.setState({class:" fade-in"},(function(){setTimeout((function(){t.setState({class:""})}),1e3)}))}},{key:"renderForDevice",value:function(){var e=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device?n.a.createElement("div",{className:this.class_desktop+""},n.a.createElement("div",{className:this.class_desktop+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,ref:function(t){e.ref_myModal=t},onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"block":"none"}},n.a.createElement("div",{className:this.class_desktop+"-content"+this.state.class+("S"===this.props.dataFull.config.default.size?" malibu-modal-small":"M"===this.props.dataFull.config.default.size?" malibu-modal-medium":"L"===this.props.dataFull.config.default.size?" malibu-modal-large":""),onClick:function(e){e.preventDefault(),e.stopPropagation()}},n.a.createElement("div",{className:this.class_header_desktop+" "},n.a.createElement("div",{className:this.class_header_desktop+"-header"},n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"100px",height:"100px",left:"131px",top:"58px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_desktop+"-header-title"},this.props.dataFull.config.default.title),n.a.createElement("div",{className:this.class_header_desktop+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},n.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),n.a.createElement("div",{className:this.class_desktop+"-content-content"},this.props.children)))):"mobile"===this.state.device?n.a.createElement("div",{className:this.class_mobile+""},n.a.createElement("div",{className:this.class_mobile+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},n.a.createElement("div",{className:this.class_mobile+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},n.a.createElement("div",{className:this.class_header_mobile+" "},n.a.createElement("div",{className:this.class_header_mobile+"-header"},n.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"42px",height:"42px",left:"224px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"75px",height:"75px",left:"63px",top:"-15px"}}),n.a.createElement("div",{className:this.class_header_mobile+"-header-item",style:{width:"48px",height:"48px",left:"-8px",top:"-18px"}}),n.a.createElement("div",{className:this.class_header_mobile+"-header-title"},this.props.dataFull.config.default.title),n.a.createElement("div",{className:this.class_header_mobile+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},n.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),n.a.createElement("div",{className:this.class_mobile+"-content-content"},this.props.children)))):"mobile-app"===this.state.device?n.a.createElement("div",{className:this.class_mobile_app+""},n.a.createElement("div",{className:this.class_mobile_app+"-background",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},tabIndex:-1,onKeyUp:function(t){"Escape"===t.key&&void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()},style:{display:this.props.dataFull.config.cmd.visibility?"flex":"none"}},n.a.createElement("div",{className:this.class_mobile_app+"-content",onClick:function(e){e.preventDefault(),e.stopPropagation()}},n.a.createElement("div",{className:this.class_header_mobile_app+" "},n.a.createElement("div",{className:this.class_header_mobile_app+"-header"},n.a.createElement("div",{className:this.class_header_mobile_app+"-header-title"},this.props.dataFull.config.default.title),n.a.createElement("div",{className:this.class_header_mobile_app+"-header-close",onClick:function(){void 0!==e.props.dataFull.abs_Close&&e.props.dataFull.abs_Close()}},n.a.createElement(p.default,{val:"close",style:{fontSize:"28px"},title:"close"})))),n.a.createElement("div",{className:this.class_mobile_app+"-content-content"},this.props.children)))):n.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(l.Component);t.default=h}}]);