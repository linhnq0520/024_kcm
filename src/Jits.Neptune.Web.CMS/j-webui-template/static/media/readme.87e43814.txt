Các hàm truyền ra ngoài là các hàm:
    -abs_Change(item.value,index, code_component): 
        + hàm gọi sau khi select 1 item,trả về item.value và index của item, code_component để xác định component 
        + yêu cầu hàm xử lý ngoài: * lọc data, set selected=true cho item nào có value = item.value or index= index -> set lại data.
    -abs_search(e,code_component):
        + hàm gọi sau khi search item, trả về event e và code_component
        + yêu cầu hàm xử lý ngoài: * lọc data theo search -> set lại data. 

getConfigTemplate() {
        return {
            dataFull:
            {
               
                config: {
                    default: {  
                         search : {
                            placeholder:"",
                        },
                        data_status:"",                        
                        title: "Office", // title của uSelectItem                      
                        class: "col-md-2", // hiển thị chiều dài của uSelectItem
                        required: true,         //true/false hiển thị dấu * phân biệt bắt buộc nhập
                    },
                    cmd: {
                        disable: false, //  true/false cho phép người dụng chọn item
                        visible: true, // true/false để hiển thị uSelectItem
                    
                        error: {
                            message: "",        // message rỗng sẽ không có thông báo
                            type: "",        // hiện tại chưa dùng type    
                        }
                    },
                    mode: {                     //hiện tại mode chưa có
                        moreColumn:true,        //truyền vào khi muốn sử dụng 2 cột trở lên                
                    },
                    column:[                    //truyền vào khi sử dụng 2 cột trở lên, số phần tử trong mảng này là số cột
                        {
                            title:"Code",
                        },
                        {
                            title:"Name"
                        }
                    ]
                },
                data: [                                                         // lưu ý khi sử dụng 2 cột trở lên thì mỗi phần tử trong {} là từng ô trong bảng
                    {data:[{title:"abc"},{title:"abc"}], selected:true},
                    {data:[{title:"abc"},{title:"abc"}]},
                    {data:[{title:"abc"},{title:"abc"}]}
                ],
                //ví dụ data truyền vào khi sử dụng 2 column trở lên
                data:[
                  {data:["123","abc"],value:"xyz", selected:true},
                   {data:["1231","abc1"],value:"xyz1",},
                ]                      
                value: "",                      // ở uSelectItem không dùng value.
                cmd:{
                    isLoading:false,
                    isLock:false
                }
            },
        }
    }

<uSelectItem {...this.getConfigTemplate()} abs_change={this.abs_changeInput}></uSelectItem>

//Hàm xử lý ba láp ba xàm
abs_changeInput(event, index, dataItem){
   //event là event mặc định của ...
   //index là...
   //dataItem là ...
}
                      