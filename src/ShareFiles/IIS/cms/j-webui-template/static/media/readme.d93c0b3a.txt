data:
    code: "uForm"       //dùng khi sử dụng uTab
    dataFull: {
        config: {
            default: {
                title: "Title",     //title của uForm
                title_sub: "Sub_Title",   //giới thiệu ngắn về chức năng form
            },
            mode: {
                    // uForm không dùng mode
            }
        },
        cmd: { visibility: "",isLoading:false }// "none" hoặc "" là ẩn hiện form
    }


<UForm {...this.getConfigTemplate()} abs_change={this.abs_changeInput}></UForm>

//Hàm xử lý ba láp ba xàm
abs_changeInput(event, index, dataItem){
   //event là event mặc định của ...
   //index là...
   //dataItem là ...
}