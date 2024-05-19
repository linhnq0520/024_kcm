Các hàm truyền ra ngoài là:
    +abs_Change(e): trả về của hàm onChange hoạt động khi người dùng gõ.
    + giá trị trả về e là event của thẻ textarea

dataFull:
    {
    config: {
          default: {
            title: "Description", // title của uTextArea
            class: "col-md-6", // số cột hiển thị trên view
            rows: 10, // độ rộng của textarea
            code_form_component:"", // xác định xem đang dùng textarea nào
            required: true,         //true/false hiển thị dấu * phân biệt bắt buộc nhập         
          },
          cmd: {
            disable: false, // true/false cho phép nhập textarea hay không
            visible: true // true/false cho phép hiển thị textarea hay không


          },
          error: {
            message: "Error", // thông báo lỗi
            type: "default", // kiểu định dạng lỗi: danger, info, success, gray, default
          },
          mode: {

          }

        },
        data: [],                       // ở uInput không dùng data
        value: "test",                      // nhận vào các kiểu string/number.
}


<UButton {...this.getConfigTemplate()} abs_change={this.abs_changeInput}></UButton>

//Hàm xử lý ba láp ba xàm
abs_changeInput(event, index, dataItem){
   //event là event mặc định của ...
   //index là...
   //dataItem là ...
}

    