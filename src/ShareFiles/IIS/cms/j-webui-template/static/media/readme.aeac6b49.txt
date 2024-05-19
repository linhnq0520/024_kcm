hàm trả về:
    +abs_add(item) yêu cầu xử lý, add item vào data.
    +abs_delete(item_id) yêu cầu xử lý xóa item trong data có id= item_id

data:
    dataFull:
    {
        
        config: { 
            mode: "toast",                          //có 2 dạng mode- ""-default -> hiển thị ở giữa màn hình phía dưới/ "toast" -> hiển thị ở góc trên bên phải

        },
        data: [
            {
                id: 1,                              // định danh của item
                title: "Successful",                
                color: "success",                   // có 2 dạng color: "success" -> Màu xanh success / "fail" -> màu đỏ error
                config: {
                    // time_out:10000               // time out cho từng noti, không set mặc định là 5s
                }
            },

        ]

    }
  