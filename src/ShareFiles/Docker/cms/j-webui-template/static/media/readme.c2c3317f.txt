Các hàm truyền ra ngoài là:
    +abs_Click(this.props.dataFull.data[index].dataItem): trả về của hàm onClick hoạt động khi người dùng click vào 1 item bất kì.
    + giá trị trả về là dataItem mà người dùng truyền vào

uFormNotify:{
        title:"Oops, error. Please try again later.",
        data: [
            {
                title:"test", // tên của lỗi
                dataItem:{name: "test"}, // dataItem
                redirect: "loading1", // Khi click vào lỗi sẽ redirect đi đâu
                time:"3 min ago", // thời gian lỗi xuất hiện trên form
            },
            {
                title:"test",
                dataItem:{name: "test"},
                redirect: "loading2",
                time:"4 min ago",
            },
            {
                title:"test",
                dataItem:{name: "test"},
                redirect: "loading3",
                time:"5 min ago",
            },

        ],                       // ở uInput không dùng data
        value: "test", 
    },