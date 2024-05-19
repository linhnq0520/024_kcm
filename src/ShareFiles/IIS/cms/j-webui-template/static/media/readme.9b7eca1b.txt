Các hàm truyền ra ngoài là:
    +abs_Change(e): trả về của hàm onChange hoạt động khi người dùng gõ.
        + giá trị trả về e là event của thẻ input 
    +abs_Blur(e): trả về của hàm onBlur hoạt động khi người dùng click chuột ra ngoài input.
        + giá trị trả về e là event của thẻ input   
getConfigTemplate(){
    return {
          dataFull:
    {
        config: {
            default: {    
                placeholder:"Search",                      
                title: "Office",
                type: "text",           //các loại type nhận vào password/text/number
                class: "col-md-2",
                required: true,         //true/false hiển thị dấu * phân biệt bắt buộc nhập
                icon:"",                //
            },
            cmd: {
                disable: false,
                visible: true,
                isFocus:false,
                error: {
                    message: "", //
                    type: "",
                }
            },
            mode: {
                
                textAlign:"right",       // giá trị nhận vào là right/left- không nhập gì định dạng là left.
                letterSpacing:""      //giá trị nhận vào "" -> default, không có khoảng cách, và 3 sizes:
                                      // "S": 1px, "M": 2px, "L": 4px            
            }

        },
        mode: {
            isSearch:true,
            readOnly:false,
	    },
        data: [],                       // ở uInput không dùng data
        value: "",                      // nhận vào các kiểu string/number.
        cmd:{
            isLoading:false,
            isLock:false,
        },
        abs_ClickIcon:this.clickIcon,
    },
    }
}

<Input {...this.getConfigTemplate()} abs_change={this.abs_changeInput}/>

//Hàm xử lý ba láp ba xàm
abs_changeInput(event, index, dataItem){
   //event là event mặc định của ...
   //index là...
   //dataItem là ...
}