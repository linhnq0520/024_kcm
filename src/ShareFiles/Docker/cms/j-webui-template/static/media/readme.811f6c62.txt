dataFull:{
    status:{
        title:"",       // tương ứng với status
    },
    PIN:{
        placeholder:"", //
        data:"",           // chứa value của input
        abs_Change:abs_Change, //hàm xử lý change ở input
        abs_KeyDown:abs_KeyDown // hàm xử lý khi nhấn enter  
    },
    number_import:{
        title:"" 
    },
    background:{
        value:""            //tương ứng với basc64/url
    },
    avatar:{
        value:""            //tương ứng với basc64/url
    },
    mode:{
        disable:{
            status:false,
            title:"",
        }
    }
}

// đối với các đối tượng sử dụng thẻ <img> nên dùng <ReuseImg> trong componentReuse.