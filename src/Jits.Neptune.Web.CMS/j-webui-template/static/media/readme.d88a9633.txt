==============================
# THAM KHẢO FILE thanhlm.js và jwebui_langManager để xem cách hoạt động.
=================================
getConfigTemplate(){
    return {
       
        data:[
            {title:"abc",selected:true},
            {title:"axy"}
        ],
        isUpdate:false,          //khi sử dụng button update nhớ trả về true
        config:{
            isFrozen:false,      //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
        },
        cmd:{
            disable:false
        },
        dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
        abs_Change: this.table_input_change
    }
}

 <UTableColumnEditSelect key={index_col} dataFull={{
                                ...getConfigTemplate,
                                index_row: index_row,           // vị trí hàng thứ mấy
                                index_col: index_col            // vị trí cột thứ mấy
                            }}></UTableColumnEditSelect>



