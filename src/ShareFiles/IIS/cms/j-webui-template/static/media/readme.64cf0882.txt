các hàm trả về:
    +abs_search(e) trả về khi người dùng sử dụng thanh search.
        - e là event được trả về.
        - yêu cầu xử lý: set lại dataFull.data để thể hiện data phù hợp với nội dung search
    +abs_select(item) trả về khi người dùng chọn 1 item trong search.
        - item chứa value và title của item được chọn.
        - yêu cầu xử lý: theo value của item được chọn, thêm mở 1 tab trong uTab (sửa data của uTab).
    +abs_Click(item) trả về khi người dùng click vào 1 phần tử con của headerItem
        - item chứa thông tin của item được chọn.
        - yêu cầu xử lý: theo value của item được chọn, chuyển sang liên kết được chọn.

data:
    dataFull:
        {
        

                headerItem:: [

                    {
                        title: "31/10/2019",                    
                        icon: "insert_invitation",

                        class: "col-sm-7"                   //class được truyền vào khi muốn cách đối tượng bên cạnh bao nhiêu
                        data:[
                            {

                                icon: "https://i.imgur.com/YaBL12b.jpg",        // nếu có icon thì truyền vào                      
                                value: "",                                      // value mã định danh của item
                                title_big: "abc@gmail.com",                     // nếu có thì truyền vào  
                                title_sub: "ac05",                              //  nếu không có thì lưu giá trị "Chưa liên kết" - có thể truyền vào hoặc không
                                title:"",                                       // có thể truyền vào hoặc không
                                config: {
                                    isHaveUnderline: true,                      //  mode gạch chân ở dưới item
                                }

                            },
                        ]
                    },
                    {
                        //data của noti hệ thống
                        ...this.getDataNoti(),
                    },
                    ....
                ],
                search_global: {
                    data: [],                                             //dữ liệu được truyền vào của search
                    placeholder:"Search",
                    title_begin: "Hello, search anything!",
                    title_noResult: "Please try different search terms",
                    noResult:" No results !"
                },         //dữ liệu của search
        }
getDataNoti(){
    return:{
        icon:
          "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACQAAAAkCAYAAADhAJiYAAAA00lEQVR4Ae3YEVAEYRjH4YXgIAiCw3yCMDwLwuB8gvDwIDgIgpzDnIMgp3DhMDhYWAgWnjBYaG733fv2Zr9n5vXf/PEtsknCKWZjidmgxg4PqWPmaPzZJV0KC22LVMs8odT2hTXODhVzj8r/vnEzdMyj/TRYDhVzq5sfXEbHzFDq7iM66E5/V5FBb/p7jgwq9fdeRBFjO7agamxBclAOykFHEYSVOKv4mFRRODeMumvQNRrxasz7RG2C76KYDNTaPlMGvWpbpn4yrLFFhRecFNmU/ALuSZJdGT7bowAAAABJRU5ErkJggg==",
        number_unRead: 5,	//số thông báo chưa đọc
        data: [
          {
            title:
              "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",		//tên thông báo
            title_sub: "1 day ago",	//thời gian
            isRead: false,		//false là chưa đọc, true là đọc rồi
            
          },
          {
            title: "Personal Information",
           
            isRead: false,
          },
          {
            title: "Lock Screen",
            
            isRead: true,
          },
          {
            title: "Change Language",
            
            isRead: true,
          },
          {
            title: "Log out",
           
            isRead: true,
          },
        ],
        mode: {
          isNotification: true,	//bắt buộc truyền vào
        },
        headerNoti: {
          title_header: "Notifications (2)",
          title_readAll: "Mark all as read",
        },
        abs_ClickItem: 1,		// hàm xử lý khi click 1 thông báo trả về item.
        abs_ReadAll: 2,		//hàm xử lý đọc hết thông báo. gọi hàm này thì set hết thông báo thành đã đọc.
    }
}