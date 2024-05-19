các hàm trả về:
    -abs_close(id) trả về id của item.
            +yêu cầu xử lý: xóa item có id trong data. 
    -abs_select(data,id) trả về  id của item và data.
            + yêu cầu set lại data giống data được trả về.
data:[
    {
        tabInfo:{
            icon:"",
            title:"",      
        },
        sysStyle: { show: "show" },             //nhận giá trị là "show" sẽ được select còn "" thì không
    },
    .....
]