(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[604],{291:function(t,e,a){"use strict";a.r(e);var s=a(1),l=a(2),i=a(4),n=a(3),d=a(0),o=a.n(d),u=a(7),c=function(t){Object(i.a)(a,t);var e=Object(n.a)(a);function a(t){var l;return Object(s.a)(this,a),(l=e.call(this,t)).class_desktop="perseus-uTableColumnEditSelect",l.edit=!1,l.state={edit:l.edit,valueDefault:l.props.dataFull.value,isChange:!1},l}return Object(l.a)(a,[{key:"componentDidUpdate",value:function(t){var e,a;void 0!==this.props.dataFull.data&&void 0!==t.dataFull.data&&this.props.dataFull.value!==t.dataFull.value&&(this.props.dataFull.value!==this.state.valueDefault?this.setState({isChange:!0}):this.setState({isChange:!1})),void 0!==this.props.dataFull.isUpdate&&this.props.dataFull.isUpdate!==t.dataFull.isUpdate&&!0===this.props.dataFull.isUpdate&&this.setState({isChange:!1,valueDefault:null===(e=this.props.dataFull.data)||void 0===e||null===(a=e.find((function(t){return t.selected})))||void 0===a?void 0:a.title})}},{key:"render",value:function(){var t,e,a,s,l,i,n,d,c=this;return o.a.createElement("td",{className:"perseus-uTable-td perseus-uTableColumnEditSelect-td"+((null===(t=this.props.dataFull.config)||void 0===t?void 0:t.isFrozen)?" frozen":""),"data-title":this.props.dataFull.title_parent},o.a.createElement("div",{className:"perseus-uTableColumnEditSelect-div"},this.state.edit?o.a.createElement(o.a.Fragment,null,o.a.createElement("div",{className:this.class_desktop+"-select_content"},o.a.createElement("input",{ref:function(t){c.myInputEdit=t},className:this.class_desktop+"-input "+(this.state.edit?"edit ":"")+(this.state.isChange?"change ":""),value:(null===(e=this.props.dataFull.data.find((function(t){return t.selected})))||void 0===e?void 0:e.title)||"",readOnly:!0,disabled:!!(null===(a=this.props.dataFull.cmd)||void 0===a?void 0:a.disable),onBlur:function(){!0!==c.onFocusSearch&&c.setState({edit:!1},(function(){c.edit=!1}))},style:{width:this.state.edit?"100%":this.props.dataFull.data.find((function(t){return t.selected})).title.length+1+"ch"}}),o.a.createElement("div",{className:this.class_desktop+"-content-icon"},o.a.createElement("i",{className:"material-icons md-18"},"keyboard_arrow_left"))),(null===(s=this.props.dataFull.data)||void 0===s?void 0:s.length)>0&&o.a.createElement("div",{className:this.class_desktop+"-menu col-12"+(this.state.edit?" edit":"")},(null===(l=this.props.dataFull.data)||void 0===l?void 0:l.length)>10&&o.a.createElement("div",{className:this.class_desktop+"-menu-search-content"},o.a.createElement("div",{className:this.class_desktop+"-menu-search"},o.a.createElement("input",{className:this.class_desktop+"-menu-search-input",type:"text",placeholder:"Search",value:this.state.val_search||"",onChange:function(t){c.setState({val_search:t.target.value}),void 0!==c.props.dataFull.abs_search&&c.props.dataFull.abs_search(t,c.props.dataFull.dataItem,c.props.dataFull.index_row,c.props.dataFull.index_col)},onDoubleClick:function(t){t.target.select()},onMouseDown:function(t){c.onFocusSearch=!0,t.stopPropagation(),t.preventDefault(),t.target.focus(),c.onFocusSearch=!1},onBlur:function(){!0!==c.onFocusSearch&&c.setState({edit:!1},(function(){c.edit=!1}))}}))),o.a.createElement("ul",{className:this.class_desktop+"-menu-ul"},null===(i=this.props.dataFull.data)||void 0===i?void 0:i.map((function(t,e){return o.a.createElement("div",{key:e},o.a.createElement("li",{onMouseDown:function(a){var s;c.setState({edit:!1}),void 0===c.props.dataFull.abs_Change||(null===(s=c.props.dataFull.cmd)||void 0===s?void 0:s.disable)||c.props.dataFull.abs_Change(a,c.props.dataFull.dataItem,c.props.dataFull.index_row,c.props.dataFull.index_col,t,e)}},o.a.createElement("label",{className:c.class_desktop+"-menu-title"+(t.selected?" active":""),title:t.title},t.title)))}))))):o.a.createElement("div",{className:this.class_desktop+"-title"+(this.state.isChange?" change":"")},(null===(n=this.props.dataFull.data.find((function(t){return t.selected})))||void 0===n?void 0:n.title)||""),!(null===(d=this.props.dataFull.cmd)||void 0===d?void 0:d.disable)&&o.a.createElement("div",{className:this.class_desktop+"-edit  perseus-button_square"+(this.state.edit?" edit":""),onClick:function(){c.setState({edit:!0},(function(){c.edit=!0,void 0!==c.myInputEdit&&null!==c.myInputEdit&&c.myInputEdit.focus()}))}},o.a.createElement(u.default,{val:"edit",style:{fontSize:"20px"},title:"edit"})),this.state.edit&&o.a.createElement(o.a.Fragment,null,o.a.createElement("div",{className:this.class_desktop+"-icon_button perseus-cancel",onMouseDown:function(){c.props.dataFull.abs_Cancel&&c.props.dataFull.abs_Cancel(c.props.dataFull.dataItem,c.props.dataFull.index_row,c.props.dataFull.index_col)}},o.a.createElement(u.default,{val:"close",style:{fontSize:"20px",height:"20px",width:"20px"}})),o.a.createElement("div",{className:this.class_desktop+"-icon_button perseus-submit",onMouseDown:function(){c.props.dataFull.abs_Submit&&c.props.dataFull.abs_Submit(c.props.dataFull.dataItem,c.props.dataFull.index_row,c.props.dataFull.index_col)}},o.a.createElement(u.default,{val:"done",style:{fontSize:"20px",height:"20px",width:"20px"}})))))}}]),a}(d.Component);e.default=c}}]);