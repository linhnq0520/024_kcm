getConfigTemplate(){
    return {
          dataFull:
    {
        data:{
            title:"",           // title của ô
            type:"info"        // type hiện tại nhận các giá trị danger/info/success/gray

        },
        config:{
            isFrozen:false      //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
        }
    }
}
}


<UTableColumnAction {...this.getConfigTemplate()}></UTableColumnAction>


