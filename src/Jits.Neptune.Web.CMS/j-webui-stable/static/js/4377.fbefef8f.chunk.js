"use strict";(self.webpackChunkstable_app=self.webpackChunkstable_app||[]).push([[4377],{4377:(t,e,s)=>{s.r(e),s.d(e,{default:()=>l});var a=s(7313),n=s(9676),i=s(6417);class o extends a.Component{constructor(t){super(t),this.getData=()=>({}),this.loadDataToState=()=>({}),this.componentDidMount=()=>{this.setState({CCP_Default_Essence_config:this.loadDataToState()})},this.onChangeValueSelect=(t,e,s)=>{let{CCP_Default_Essence_config:a}=this.state;if(s){for(const e of a[s].dataFull.data)e.selected=e.value===t;this.setState({CCP_Default_Essence_config:a})}},this.CCP_Default_Essence_textInput=(0,n.Iq)("CCP_Default_Essence_sameMain"),this.DESIGNFORM_CODE_TOOL_ITEMS="designToolItem",this.data=this.readConfig(this.props.configComponent.configItem.property),this.state={CCP_Default_Essence_config:{}}}readConfig(t){var e={};return void 0===t&&(t={}),null!=t.danger?e.danger=t.danger:e.danger="false",null!=t.warning?e.warning=t.warning:e.warning="false",e}render(){const t=this.CCP_Default_Essence_textInput;return(0,i.jsx)(t,{stateData:this.state.CCP_Default_Essence_config})}}const l=o}}]);