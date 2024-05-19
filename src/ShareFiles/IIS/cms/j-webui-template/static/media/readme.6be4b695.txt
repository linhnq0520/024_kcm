==============================
# THAM KHẢO FILE thanhlm.js và jwebui_langManager để xem cách hoạt động.
=================================
getConfigTemplate(){
    return {
        data:"áddasd",         
        isUpdate:false,          //khi sử dụng button update nhớ trả về true
        config:{
            isFrozen:false,      //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
        },
        cmd:{
            disable:false
        },
        dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
        abs_Change: this.table_input_change_detail
    }
}

 <UTableColumnEditInput key={index_col} dataFull={{
                                ...getConfigTemplate,
                                index_row: index_row,           // vị trí hàng thứ mấy
                                index_col: index_col            // vị trí cột thứ mấy
                            }}></UTableColumnEditInput>

//hàm xử lý cho bảng table gồm nhiều cột editInput
table_input_change_detail = (event, dataItem, index_row, index_col) => {
    let data = this.state.stateData;
    data.table_lang_detail_data.data[index_row].all_column[index_col].value = event.target.value;

    this.setState({ stateData: data });
}


