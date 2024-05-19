
getConfigTemplate(){
    return {
          dataFull:
    {
       
        data:{
            icon_data: 
            [                                    
                {
                    icon: "visibility",
                    title: "View",
                },
                {
                    icon: "delete",
                    title: "Delete",
                }
            ],
            title:"",              //nếu sử dụng title thì truyền vào
          
        },
         config:{
            isFrozen:false      //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
        }
        
    }
}
}


<UTableColumnCustom {...this.getConfigTemplate()} abs_select={this.abs_select}></UTableColumnCustom>


//hàm trả về khi click vào icon
abs_select(item){
    // trả về item là đối tượng được click vào.
    // yêu cầu xử lý: thực hiện thao tác logic tương ứng icon đó.
}


