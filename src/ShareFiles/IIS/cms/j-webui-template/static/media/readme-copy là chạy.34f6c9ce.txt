getConfigTemplate(){
    return {
          dataFull:
    {
        Header:{
            data:[
                {
                    title:"",
                    id:"",
                    config:{                    
                        width:"",               // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                        isFrozen: false,         // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                        textAlign:"center",
                    },
                    value_search:"",
                },
            
            ],
            config:{                        // config của header
                search:{
                    placeholder:"Search",
                },
                mode:{
                    hasSearch: false,      //nếu muốn có search thì truyền vào true
                }
            }
        },
        config:{                             // config của table
            title:"",
            isBorder:false,
            height:"",
            mode:{
                noHeader:false,           //dùng cho trường hợp không sử dụng header- truyền vào true
                modeTitle:"",
                maxHeight:false,
            }
        },
        cmd:{
            isLoading:false
        },
        uPagination:                       // nếu có dùng uPagination (phân trang) thì truyền vào
        { 
            result_total: 6,                // số dữ liệu tổng của bảng
            paging_record:                  // cấu trúc hiển thị của bảng - bao nhiêu dữ liệu được hiển thị lên
            [
                {
                    number: 5,              // số dữ liệu được hiển thị
                    selected: true,         // được chọn thì set true
                },
                {
                    number: 10,
                },
            ],
            mode:{
                noJumpPage:false        //nếu không có jump page thì truyền true
            },
            paging_index={this.props.dataFull.uPagination?.paging_index},
            config:{
                show:"Show",
                in:"in",
                jump_to_page:"Jump to page",
                results:"results",
            },
            abs_PagingActive:this.abs_PagingActive,
            abs_setRecordActive:this.abs_setRecordActive,
        },
    }
}
}

<UTable {...this.getConfigTemplate()}>
    {this.props.children}   //tham khảo ở các folder có dạng uTable*.
</UTable>


//Hàm trả về page đang được chọn
abs_PagingActive(number){
   // trả về number là vị trí trang đang được chọn
   // yêu cầu xử lý trong hàm: lấy và set lại dữ liệu đúng với số trang yêu cầu lại vào bảng.
}
//hàm trả về số dữ liệu được hiển thị trên bản
abs_setRecordActive(index){
    // trả về index là vị trí của record được chọn (bao nhiêu item trên 1 bảng)
    // yêu cầu xử lý: set selected=true cho item có index trả về, các item còn lại set selected=false
} 
