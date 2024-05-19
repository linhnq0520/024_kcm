hàm trả về:
    +abs_Click(e, this.props.dataFull.dataItem) trả về khi người dùng click vào uButton
        trong đó:
            - e là event của uButton.
            - this.props.dataItem là data logic của người dùng
getConfigTemplate() {
        return {
            dataFull:
            {
                config: {
                    default: {
                        title: "Office", // title của button
                        type: "primary",        // nhận 2 dạng type là "" -> default- có background trắng và "primary" -> có background xanh
                        class:"col-md-2",               // độ dài mặc định của uButton là "161px" với button không icon & "96px" với button có icon, nếu muốn thay đổi độ dài thì set .col-* vào class  
                        icon: "search",        // nếu uButton có icon thì set vào, còn không có thì không dùng
                      
                    },
    
                },
                cmd:{
                    disable:true,                //true/false
                    isLoading:true,              //truyền vào khi loading.
                    isLock:false,
                },
                dataItem:{//truyền vào dữ liệu của dev}
            },
        }
    }

<uButton {...this.getConfigTemplate()} abs_Click={this.abs_Click}></uButton>



