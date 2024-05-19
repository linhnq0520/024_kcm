getConfigTemplate(){
        return {
                dataFull:
                {
                       
                        data:          //trong trường hợp này data dùng là mảng
                        [
                            {
                                
                                val: "apps",             //nhận các giá trị url/icon/data
                                color: "yellow",    // gồm: yellow/blue
                                title: "apps",     // tên icon
                            },
                        
                        ],
                        config:{
                            isFrozen:false,      //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
                        }
                        
                }
        }
}


<UTableColumnIcon {...this.getConfigTemplate()}></UTableColumnIcon>

