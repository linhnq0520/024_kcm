(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[14,773,804],{638:function(t,e,a){"use strict";a.r(e);var s=a(1),l=a(2),n=a(4),i=a(3),c=a(0),o=a.n(c),r=a(7),d=a(639),u=a(5),h=a(594),p=function(t){Object(n.a)(a,t);var e=Object(i.a)(a);function a(t){var l;return Object(s.a)(this,a),(l=e.call(this,t)).abstract_changeDevice=function(t){l.setState({device:t},(function(){l.render()}))},l.abstract_changeDeviceReal=function(t,e){l.getPaging()},l.renderPaging=function(){for(var t=[],e=0;e<l.state.number_paging;e++)t.push(o.a.createElement("div",{className:l.class[l.state.device]+"-content-paging-circle"+(l.state.paging_active===e?" perseus-active":""),key:e}));return t},l.type_component="uSearchGlobal",l.code_component="perseus.uSearchGlobal",l.class={desktop:"perseus-desktop-uSearchGlobal",desktop_small:"perseus-desktop_small-uSearchGlobal",tablet:"perseus-tablet-uSearchGlobal",mobile:"perseus-mobile-uSearchGlobal"},l.ref_mySearchGlobalContent=o.a.createRef(),l.id_theme_component=Object(u.c)(),l.state={device:Object(u.f)(),skin_config:Object(h.configTemplate_getTheme)(),onFocus:!1,number_paging:0,paging_active:0,lastScrollTop:0,isDisMount:"none"},l}return Object(l.a)(a,[{key:"getPaging",value:function(){if(this.ref_mySearchGlobalContent.current){var t,e,a,s,l=parseInt((null===(t=this.ref_mySearchGlobalContent.current)||void 0===t?void 0:t.scrollHeight)/(null===(e=this.ref_mySearchGlobalContent.current)||void 0===e?void 0:e.offsetHeight));l<parseFloat(((null===(a=this.ref_mySearchGlobalContent.current)||void 0===a?void 0:a.scrollHeight)/(null===(s=this.ref_mySearchGlobalContent.current)||void 0===s?void 0:s.offsetHeight)).toFixed(2))&&l++,this.state.number_paging===l||isNaN(l)||this.setState({number_paging:l})}}},{key:"componentWillUnmount",value:function(){Object(u.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){var t=this;Object(u.b)(this,this.id_theme_component),this.setState({isDisMount:"block"},(function(){t.getPaging()}))}},{key:"UNSAFE_componentWillUpdate",value:function(){var t=this;setTimeout((function(){t.getPaging()}),10)}},{key:"getTabActive",value:function(t){return this.props.dataFull.tab_id_selected===t?" perseus-active":""}},{key:"convertData",value:function(t){return{title:t.info.search.title_1+t.info.search.result+t.info.search.title_2,link:t.info.link,type:t.info.module.type,icon:t.info.icon_img||"live_help",isOpen:t.isOpen,abs_ClickDataItem:this.props.dataFull.abs_ClickDataItem,dataItem:t.dataItem,abs_CallBackHideForm:this.props.dataFull.abs_CallBackHideForm}}},{key:"renderNoData",value:function(){return o.a.createElement("div",{className:this.class[this.state.device]+"-no_result"},this.props.dataFull.title.no_data_title)}},{key:"renderForDevice",value:function(){var t,e,a,s,l=this;return"desktop"===this.state.device?o.a.createElement("div",{className:this.class[this.state.device]},o.a.createElement("div",{className:this.class[this.state.device]+"-field",tabIndex:1,onFocus:function(){l.setState({onFocus:!0},(function(){l.ref_search.focus()}))},onBlur:function(t){t.currentTarget.contains(t.relatedTarget)||l.setState({onFocus:!1})}},o.a.createElement("input",{className:this.class[this.state.device]+"-input",type:"text",placeholder:this.props.dataFull.title.search_input,ref:function(t){l.ref_search=t},autoComplete:"off",value:this.props.dataFull.search_input_value,onChange:function(t){void 0!==l.props.dataFull.abs_Change&&l.props.dataFull.abs_Change(t)},style:{width:(null===(t=this.ref_myValue)||void 0===t?void 0:t.offsetWidth)+"px"},tabIndex:1,onKeyUp:function(t){switch(t.keyCode){case 13:void 0!==l.props.dataFull.abs_Search&&l.props.dataFull.abs_Search(t)}},onKeyDown:function(t){t.keyCode},onFocus:function(t){!0!==l.state.no_select&&(t.target.selectionStart=0,t.target.selectionEnd=-1)},id:"perseus-search-global"}),o.a.createElement("label",{className:this.class[this.state.device]+"-icon",onMouseDown:function(){setTimeout((function(){l.ref_search.focus()}),10)}},o.a.createElement(r.default,{val:"search",style:{fontSize:"28px",width:"28px",height:"28px"}})),o.a.createElement("label",{htmlFor:"perseus-search-global",className:this.class[this.state.device]+"-icon-clear",onMouseDown:function(t){l.props.dataFull.abs_ClearValue(t),setTimeout((function(){l.ref_search.focus(),l.setState({render:"123"})}),10)}},o.a.createElement(r.default,{val:"cancel",class:"-round",style:{fontSize:"20px",width:"20px",height:"20px"}})),o.a.createElement("span",{ref:function(t){l.ref_myValue=t},className:this.class[this.state.device]+"-input-value"},this.props.dataFull.search_input_value?this.props.dataFull.search_input_value:this.props.dataFull.title.search_input)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-tab-div"},o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_all"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_all.tab_id)},tabIndex:1,ref:function(t){l.ref_tabAll=t}},this.props.dataFull.title.tab_all),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_function"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_function.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFunction=t}},this.props.dataFull.title.tab_function),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_fordata"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_fordata.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFordata=t}},this.props.dataFull.title.tab_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_suggestion"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_suggestion.tab_id)},tabIndex:1,ref:function(t){l.ref_tabSuggestion=t}},this.props.dataFull.title.tab_suggestion)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-content",ref:this.ref_mySearchGlobalContent,onScroll:function(){var t=l.ref_mySearchGlobalContent.current.scrollTop,e=l.state.paging_active;t>l.state.lastScrollTop?(t>l.ref_mySearchGlobalContent.current.offsetHeight*(e+1)&&e++,t+l.ref_mySearchGlobalContent.current.offsetHeight===l.ref_mySearchGlobalContent.current.scrollHeight&&e++):(t<l.ref_mySearchGlobalContent.current.offsetHeight*(e-1)&&e--,0===t&&(e=0)),l.setState({paging_active:e,lastScrollTop:t})}},o.a.createElement("div",{className:this.class[this.state.device]+"-content-all",style:{display:"content_all"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_fordata.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_suggestion.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})}))))),o.a.createElement("div",{className:this.class[this.state.device]+"-content-function",style:{display:"content_function"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-fordata",style:{display:"content_fordata"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_fordata.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-suggestion",style:{display:"content_suggestion"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_suggestion.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),this.state.number_paging>1&&o.a.createElement("div",{className:this.class[this.state.device]+"-content-paging"},this.renderPaging()))):"desktop_small"===this.state.device?o.a.createElement("div",{className:this.class[this.state.device]},o.a.createElement("div",{className:this.class[this.state.device]+"-field",tabIndex:1,onFocus:function(){l.setState({onFocus:!0},(function(){l.ref_search.focus()}))},onBlur:function(t){t.currentTarget.contains(t.relatedTarget)||l.setState({onFocus:!1})}},o.a.createElement("input",{className:this.class[this.state.device]+"-input",autoComplete:"off",type:"text",placeholder:this.props.dataFull.title.search_input,ref:function(t){l.ref_search=t},value:this.props.dataFull.search_input_value,onChange:function(t){void 0!==l.props.dataFull.abs_Change&&l.props.dataFull.abs_Change(t)},style:{width:(null===(e=this.ref_myValue)||void 0===e?void 0:e.offsetWidth)+"px"},tabIndex:1,onKeyUp:function(t){switch(t.keyCode){case 13:void 0!==l.props.dataFull.abs_Search&&l.props.dataFull.abs_Search(t)}},onKeyDown:function(t){t.keyCode},onFocus:function(t){!0!==l.state.no_select&&(t.target.selectionStart=0,t.target.selectionEnd=-1)},id:"perseus-search-global"}),o.a.createElement("label",{className:this.class[this.state.device]+"-icon",onMouseDown:function(){setTimeout((function(){l.ref_search.focus()}),10)}},o.a.createElement(r.default,{val:"search",style:{fontSize:"28px",width:"28px",height:"28px"}})),o.a.createElement("label",{htmlFor:"perseus-search-global",className:this.class[this.state.device]+"-icon-clear",onMouseDown:function(t){l.props.dataFull.abs_ClearValue(t),setTimeout((function(){l.ref_search.focus(),l.setState({render:"123"})}),10)}},o.a.createElement(r.default,{val:"cancel",class:"-round",style:{fontSize:"20px",width:"20px",height:"20px"}})),o.a.createElement("span",{ref:function(t){l.ref_myValue=t},className:this.class[this.state.device]+"-input-value"},this.props.dataFull.search_input_value?this.props.dataFull.search_input_value:this.props.dataFull.title.search_input)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-tab-div"},o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_all"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_all.tab_id)},tabIndex:1,ref:function(t){l.ref_tabAll=t}},this.props.dataFull.title.tab_all),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_function"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_function.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFunction=t}},this.props.dataFull.title.tab_function),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_fordata"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_fordata.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFordata=t}},this.props.dataFull.title.tab_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_suggestion"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_suggestion.tab_id)},tabIndex:1,ref:function(t){l.ref_tabSuggestion=t}},this.props.dataFull.title.tab_suggestion)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-content",ref:this.ref_mySearchGlobalContent,onScroll:function(){var t=l.ref_mySearchGlobalContent.current.scrollTop,e=l.state.paging_active;t>l.state.lastScrollTop?(t>l.ref_mySearchGlobalContent.current.offsetHeight*(e+1)&&e++,t+l.ref_mySearchGlobalContent.current.offsetHeight===l.ref_mySearchGlobalContent.current.scrollHeight&&e++):(t<l.ref_mySearchGlobalContent.current.offsetHeight*(e-1)&&e--,0===t&&(e=0)),l.setState({paging_active:e,lastScrollTop:t})}},o.a.createElement("div",{className:this.class[this.state.device]+"-content-all",style:{display:"content_all"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_fordata.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_suggestion.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})}))))),o.a.createElement("div",{className:this.class[this.state.device]+"-content-function",style:{display:"content_function"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-fordata",style:{display:"content_fordata"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_fordata.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-suggestion",style:{display:"content_suggestion"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_suggestion.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),this.state.number_paging>1&&o.a.createElement("div",{className:this.class[this.state.device]+"-content-paging"},this.renderPaging()))):"tablet"===this.state.device?o.a.createElement("div",{className:this.class[this.state.device]},o.a.createElement("div",{className:this.class[this.state.device]+"-field",tabIndex:1,onFocus:function(){l.setState({onFocus:!0},(function(){l.ref_search.focus()}))},onBlur:function(t){t.currentTarget.contains(t.relatedTarget)||l.setState({onFocus:!1})}},o.a.createElement("input",{className:this.class[this.state.device]+"-input",type:"text",autoComplete:"off",placeholder:this.props.dataFull.title.search_input,ref:function(t){l.ref_search=t},value:this.props.dataFull.search_input_value,onChange:function(t){void 0!==l.props.dataFull.abs_Change&&l.props.dataFull.abs_Change(t)},style:{width:(null===(a=this.ref_myValue)||void 0===a?void 0:a.offsetWidth)+"px"},tabIndex:1,onKeyUp:function(t){switch(t.keyCode){case 13:void 0!==l.props.dataFull.abs_Search&&l.props.dataFull.abs_Search(t)}},onKeyDown:function(t){t.keyCode},onFocus:function(t){!0!==l.state.no_select&&(t.target.selectionStart=0,t.target.selectionEnd=-1)},id:"perseus-search-global"}),o.a.createElement("label",{className:this.class[this.state.device]+"-icon",onMouseDown:function(){setTimeout((function(){l.ref_search.focus()}),10)}},o.a.createElement(r.default,{val:"search",style:{fontSize:"28px",width:"28px",height:"28px"}})),o.a.createElement("label",{htmlFor:"perseus-search-global",className:this.class[this.state.device]+"-icon-clear",onMouseDown:function(t){l.props.dataFull.abs_ClearValue(t),setTimeout((function(){l.ref_search.focus(),l.setState({render:"123"})}),10)}},o.a.createElement(r.default,{val:"cancel",class:"-round",style:{fontSize:"20px",width:"20px",height:"20px"}})),o.a.createElement("span",{ref:function(t){l.ref_myValue=t},className:this.class[this.state.device]+"-input-value"},this.props.dataFull.search_input_value?this.props.dataFull.search_input_value:this.props.dataFull.title.search_input)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-tab-div"},o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_all"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_all.tab_id)},tabIndex:1,ref:function(t){l.ref_tabAll=t}},this.props.dataFull.title.tab_all),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_function"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_function.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFunction=t}},this.props.dataFull.title.tab_function),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_fordata"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_fordata.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFordata=t}},this.props.dataFull.title.tab_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_suggestion"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_suggestion.tab_id)},tabIndex:1,ref:function(t){l.ref_tabSuggestion=t}},this.props.dataFull.title.tab_suggestion)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-content",ref:this.ref_mySearchGlobalContent,onScroll:function(){var t=l.ref_mySearchGlobalContent.current.scrollTop,e=l.state.paging_active;t>l.state.lastScrollTop?(t>l.ref_mySearchGlobalContent.current.offsetHeight*(e+1)&&e++,t+l.ref_mySearchGlobalContent.current.offsetHeight===l.ref_mySearchGlobalContent.current.scrollHeight&&e++):(t<l.ref_mySearchGlobalContent.current.offsetHeight*(e-1)&&e--,0===t&&(e=0)),l.setState({paging_active:e,lastScrollTop:t})}},o.a.createElement("div",{className:this.class[this.state.device]+"-content-all",style:{display:"content_all"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_fordata.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_suggestion.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})}))))),o.a.createElement("div",{className:this.class[this.state.device]+"-content-function",style:{display:"content_function"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-fordata",style:{display:"content_fordata"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_fordata.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-suggestion",style:{display:"content_suggestion"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_suggestion.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),this.state.number_paging>1&&o.a.createElement("div",{className:this.class[this.state.device]+"-content-paging"},this.renderPaging()))):"mobile"===this.state.device?o.a.createElement("div",{className:this.class[this.state.device]},o.a.createElement("div",{className:this.class[this.state.device]+"-field",tabIndex:1,onFocus:function(){l.setState({onFocus:!0},(function(){l.ref_search.focus()}))},onBlur:function(t){t.currentTarget.contains(t.relatedTarget)||l.setState({onFocus:!1})}},o.a.createElement("input",{className:this.class[this.state.device]+"-input",type:"text",autoComplete:"off",placeholder:this.props.dataFull.title.search_input,ref:function(t){l.ref_search=t},value:this.props.dataFull.search_input_value,onChange:function(t){void 0!==l.props.dataFull.abs_Change&&l.props.dataFull.abs_Change(t)},style:{width:(null===(s=this.ref_myValue)||void 0===s?void 0:s.offsetWidth)+"px"},tabIndex:1,onKeyUp:function(t){switch(t.keyCode){case 13:void 0!==l.props.dataFull.abs_Search&&l.props.dataFull.abs_Search(t)}},onKeyDown:function(t){t.keyCode},onFocus:function(t){!0!==l.state.no_select&&(t.target.selectionStart=0,t.target.selectionEnd=-1)},id:"perseus-search-global"}),o.a.createElement("label",{className:this.class[this.state.device]+"-icon",onMouseDown:function(){setTimeout((function(){l.ref_search.focus()}),10)}},o.a.createElement(r.default,{val:"search",style:{fontSize:"28px",width:"28px",height:"28px"}})),o.a.createElement("label",{htmlFor:"perseus-search-global",className:this.class[this.state.device]+"-icon-clear",onMouseDown:function(t){l.props.dataFull.abs_ClearValue(t),setTimeout((function(){l.ref_search.focus(),l.setState({render:"123"})}),10)}},o.a.createElement(r.default,{val:"cancel",class:"-round",style:{fontSize:"20px",width:"20px",height:"20px"}})),o.a.createElement("span",{ref:function(t){l.ref_myValue=t},className:this.class[this.state.device]+"-input-value"},this.props.dataFull.search_input_value?this.props.dataFull.search_input_value:this.props.dataFull.title.search_input)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-tab-div"},o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_all"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_all.tab_id)},tabIndex:1,ref:function(t){l.ref_tabAll=t}},this.props.dataFull.title.tab_all),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_function"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_function.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFunction=t}},this.props.dataFull.title.tab_function),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_fordata"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_fordata.tab_id)},tabIndex:1,ref:function(t){l.ref_tabFordata=t}},this.props.dataFull.title.tab_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-tab-item"+this.getTabActive("content_suggestion"),onClick:function(){l.props.dataFull.abs_ClickTab(l.props.dataFull.content_suggestion.tab_id)},tabIndex:1,ref:function(t){l.ref_tabSuggestion=t}},this.props.dataFull.title.tab_suggestion)),this.props.dataFull.search_input_value&&o.a.createElement("div",{className:this.class[this.state.device]+"-content",ref:this.ref_mySearchGlobalContent,onScroll:function(){var t=l.ref_mySearchGlobalContent.current.scrollTop,e=l.state.paging_active;t>l.state.lastScrollTop?(t>l.ref_mySearchGlobalContent.current.offsetHeight*(e+1)&&e++,t+l.ref_mySearchGlobalContent.current.offsetHeight===l.ref_mySearchGlobalContent.current.scrollHeight&&e++):(t<l.ref_mySearchGlobalContent.current.offsetHeight*(e-1)&&e--,0===t&&(e=0)),l.setState({paging_active:e,lastScrollTop:t})}},o.a.createElement("div",{className:this.class[this.state.device]+"-content-all",style:{display:"content_all"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_fordata.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))),this.props.dataFull.content_suggestion.data.length>0&&o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})}))))),o.a.createElement("div",{className:this.class[this.state.device]+"-content-function",style:{display:"content_function"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_function.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_function),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_function.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-fordata",style:{display:"content_fordata"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_fordata.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_fordata),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_fordata.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),o.a.createElement("div",{className:this.class[this.state.device]+"-content-suggestion",style:{display:"content_suggestion"===this.props.dataFull.tab_id_selected?"block":"none"}},this.props.dataFull.content_suggestion.data.length>0?o.a.createElement("div",null,o.a.createElement("div",{className:this.class[this.state.device]+"-search-title-option"},this.props.dataFull.title.tab_content_suggestion.title+" "+this.props.dataFull.title.tab_content_suggestion.result),o.a.createElement("div",{className:this.class[this.state.device]+"-menu-div row"},this.props.dataFull.content_suggestion.data.map((function(t,e){return o.a.createElement(d.default,{key:e,dataFull:l.convertData(t)})})))):this.renderNoData()),this.state.number_paging>1&&o.a.createElement("div",{className:this.class[this.state.device]+"-content-paging"},this.renderPaging()))):o.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(c.Component);e.default=p},639:function(t,e,a){"use strict";a.r(e);var s=a(1),l=a(2),n=a(4),i=a(3),c=a(0),o=a.n(c),r=a(7),d=a(5),u=a(594),h=function(t){Object(n.a)(a,t);var e=Object(i.a)(a);function a(t){var l;return Object(s.a)(this,a),(l=e.call(this,t)).abstract_changeDevice=function(t){l.setState({device:t},(function(){}))},l.type_component="uSearchGlobalItem",l.code_component="perseus.uSearchGlobalItem",l.class={desktop:"perseus-desktop-uSearchGlobalItem",desktop_small:"perseus-desktop_small-uSearchGlobalItem",tablet:"perseus-tablet-uSearchGlobalItem",mobile:"perseus-mobile-uSearchGlobalItem"},l.id_theme_component=Object(d.c)(),l.state={device:Object(d.f)(),skin_config:Object(u.configTemplate_getTheme)(),isDisMount:"none"},l}return Object(l.a)(a,[{key:"componentWillUnmount",value:function(){Object(d.i)(this.id_theme_component)}},{key:"componentDidMount",value:function(){Object(d.b)(this,this.id_theme_component),this.setState({isDisMount:"block"})}},{key:"renderForDevice",value:function(){var t=this;return"desktop"===this.state.device||"desktop_small"===this.state.device||"tablet"===this.state.device||"mobile"===this.state.device?o.a.createElement("div",{className:this.class[this.state.device],tabIndex:1,onMouseDown:function(t){t.preventDefault(),t.stopPropagation()},onClick:function(){t.props.dataFull.abs_CallBackHideForm("menu"),t.props.dataFull.abs_ClickDataItem(t.props.dataFull.dataItem)}},o.a.createElement("div",{className:this.class[this.state.device]+"-icon"},o.a.createElement(r.default,{val:this.props.dataFull.icon||"extension",class:"-round",style:{fontSize:"60px",width:"60px",height:"60px",margin:"auto"}})),o.a.createElement("div",{className:this.class[this.state.device]+"-title"},this.props.dataFull.title),o.a.createElement("div",{className:this.class[this.state.device]+"-type"},this.props.dataFull.type),this.props.dataFull.isOpen&&o.a.createElement("div",{className:this.class[this.state.device]+"-open"})):o.a.createElement("div",null,"Kh\xf4ng h\u1ed7 tr\u1ee3")}},{key:"render",value:function(){return this.renderForDevice()}}]),a}(c.Component);e.default=h}}]);