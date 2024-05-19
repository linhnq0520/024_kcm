
getConfigTemplate(){
        return {
                dataFull:
                {
                        
                        data:"áddasd",          //trong trường hợp này data tương ứng với title
                        config:{
                                mode:"right",        // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                                isFrozen:false,      //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
                        }
                        
                }
        }
}


<UTableColumnDefault {...this.getConfigTemplate()}></UTableColumnDefault>




