(this.webpackJsonpframeworkcss=this.webpackJsonpframeworkcss||[]).push([[763,435,436],{1312:function(e,t,r){"use strict";r.d(t,"a",(function(){return o}));var i=r(1313);function n(e,t){var r=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);t&&(i=i.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),r.push.apply(r,i)}return r}function o(e){for(var t=1;t<arguments.length;t++){var r=null!=arguments[t]?arguments[t]:{};t%2?n(Object(r),!0).forEach((function(t){Object(i.a)(e,t,r[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(r)):n(Object(r)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(r,t))}))}return e}},1313:function(e,t,r){"use strict";function i(e,t,r){return t in e?Object.defineProperty(e,t,{value:r,enumerable:!0,configurable:!0,writable:!0}):e[t]=r,e}r.d(t,"a",(function(){return i}))},661:function(e,t,r){"use strict";r.r(t);var i=r(1312),n=r(1),o={structable:"",structable_read:"",data_default:"",data_type:"edit",component_title:"",mask_format:"",mask_data_format:"",value_type:"all",auto_delete:"true",mask_mode:"default",content_style:"",format_value_type_string:"",min_year:"",max_year:"",hasSuggest:!1,keyLoadCache:"",PK_key:"",moreInformation_key:""};t.default=function e(t,r,a){var s=this;Object(n.a)(this,e),this.getProperty=function(){return s.property},this.setCMD=function(e){void 0!==e.visible&&("true"!==e.visible&&"false"!==e.visible||(s.property.cmd.visible=e.visible)),void 0!==e.disabled&&("true"!==e.disabled&&"false"!==e.disabled||(s.property.cmd.disabled=e.disabled)),void 0!==e.block&&("true"!==e.block&&"false"!==e.block||(s.property.cmd.block=e.block))},this.getCMD=function(){return s.property.cmd},this.setCMD_visible=function(e){s.property.cmd.visible=e},this.getCMD_visible=function(){return s.property.cmd.visible},this.setCMD_enable=function(e){s.property.cmd.disabled=e},this.getCMD_enable=function(){return s.property.cmd.disabled},this.combinePrevConfig=function(e){var t=e||s.property.config,r=Object(i.a)({},o);for(var n in r)t[n]&&(""!==t[n]&&""===t[n]||(r[n]=t[n]));return r||{}},this.getDefault=function(){return s.property.default},this.property={inputType:t,config:a,default:r,main:[],position:[],cmd:{visible:"true",disabled:"false",block:"false"}}}}}]);