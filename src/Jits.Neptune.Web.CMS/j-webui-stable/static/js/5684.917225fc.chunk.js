"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[5684],{5684:(e,t,i)=>{i.r(t),i.d(t,{default:()=>o});var a=i(7313),s=i(9676),l=i(6417);class n extends a.Component{constructor(e){super(e),this.componentDidUpdate=(e,t)=>{if(e.visibility!==this.props.visibility){let{stateData:e}=this.state;e.cmd.visibility=this.props.visibility,this.setState({stateData:e},(()=>{this.iframeURLChange(this.ref_DFPreview.ref_myIframe,(function(e){}))}))}},this.DF_Preview_Render=(0,s.Iq)("screen_preview"),this.dataPreviewForm={form:"BO_006008",from:"designform"},this.state={stateData:{cmd:{visibility:this.props.visibility},back_to_home:{title:"Back to home",abs_Click:this.abs_Click},device_mode:[{title:"desktop",img:"laptop_mac",id:"desktop",abs_Click:this.abs_ClickMode},{title:"tablet",img:"tablet_mac",id:"tablet",abs_Click:this.abs_ClickMode},{title:"mobile",img:"phone_iphone",id:"mobile",abs_Click:this.abs_ClickMode}],templates:{data:[{title:"Theme Malibu-Blue",img:"../rs/global/img/malibu-blue.png",selected:!0,value:"123"},{title:"Theme malibu-green",img:"../rs/global/img/malibu-green.png",value:"123"},{title:"Theme malibu-purple",img:"../rs/global/img/malibu-purple.png",value:"123"}],abs_Click:this.abs_Click},data_view:{title:"Desktop view",link_form:""}}}}iframeURLChange(e,t){var i=null,a=function(){var a=e.contentWindow.location.href;a!==i&&(t(a),i=a)},s=function(){setTimeout(a,0)};function l(){e.contentWindow.removeEventListener("unload",s),e.contentWindow.addEventListener("unload",s)}e.addEventListener("load",(function(){l(),a()})),l()}render(){const e=this.DF_Preview_Render;return(0,l.jsx)(a.Fragment,{children:(0,l.jsx)("div",{className:"d-flex col-12",children:(0,l.jsx)("div",{className:"main",style:{width:"100%"},children:(0,l.jsx)(e,{ref:e=>{this.ref_DFPreview=e},stateData:this.state.stateData})})})})}}const o=n}}]);