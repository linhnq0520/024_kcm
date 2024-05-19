
getConfigTemplate(){
        return {
                dataFull:
                {
                        title:"aaaaaaaa",     // title của thông báo
                        type:"danger",          //nhận các giá trị danger/gray/warning/success
                }
        }
}


<UDisconnect {...this.getConfigTemplate()} abs_Close={this.abs_Close}></UDisconnect>

abs_Close=(event)=>{
    //event được trả về
    //yêu cầu xử lý: chưa nghĩ ra
}


