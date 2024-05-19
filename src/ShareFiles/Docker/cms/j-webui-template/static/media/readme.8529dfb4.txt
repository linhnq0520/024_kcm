getConfigTemplate(){
    return {
          dataFull:
    {
        isCheck: false,      //nhận các giá trị true/ false/ "-" - dùng cho trường hợp check box trên bảng
        dataItem:{},         // tùy người dùng truyền vào
        abs_Click=this.abs_Click,
        config:{
            cmd:{
            disable:false,
            isLock:false,
            error:{
                message:"",
            }
        },
        }
        class:"",
        title:"",
    }
    
}
}


<UCheckBox {...this.getConfigTemplate()}></UCheckBox>

//hàm trả về
abs_Click(dataItem){
    //trả về dataItem do dev truyền vào
    //xử lý gì dó dev quyết định.
}