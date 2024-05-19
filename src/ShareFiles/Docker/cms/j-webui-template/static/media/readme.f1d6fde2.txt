Chứa các ứng dụng làm việc của các team
hàm trả về abs_select(dataItem,e) trong đó: - dataItem là dataItem của item được chọn
                                                - e chứa event.
            Mô tả: xử lý chuyển sang các ứng dụng khác khi chọn.
data:
    dataFull:
    {
            appItem: [

                {

                    icon: "https://i.imgur.com/YaBL12b.jpg",             // hoạt động với icon/img/basc64 , chỉ cần truyền đường dẫn vào
                    title: "Optimal 9",                                 // tên của app.
                    dataItem:{test:"abc"}
                },
                ....
            ],
            abs_select:this.onChange
    }
       