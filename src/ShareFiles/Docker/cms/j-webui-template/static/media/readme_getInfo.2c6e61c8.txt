 <ModalConfirm
                            stateData={{
                                modal: {
                                    title: "Edit rule function",
                                    helper:
                                        "Lorem Ipsum is simply dummy text of the printing and typesetting about industry simply dummy.  ",
                                    abs_Close: this.abs_Close,
                                    visibility: true,
                                },

                                form: {


                                    rule_getInfo: {
                                        title: "Rule Getinfo",
                                        active: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        title: "Kích hoạt (cách nhau ;)", // title của uSelectItem
                                                        class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                        placeholder: "Tên layout",
                                                        helper: "abc",
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,

                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                },
                                                mode: {
                                                    isSearch: false,
                                                },
                                                value: "Layout mới",
                                                abs_Change: this.testInput,
                                            },
                                        },
                                        action: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        title: "Hành động", // title của uSelectItem
                                                        class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                        placeholder: "Hướng dẫn",
                                                        helper: "abc",
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,

                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                },
                                                mode: {
                                                    isSearch: false,
                                                },
                                                value: "",
                                                abs_Change: this.testInput,
                                            },
                                        },
                                        how_to_set_data: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },


                                        get_data: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        title: "Class", // title của uSelectItem
                                                        class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                        placeholder: "Class",
                                                        helper: "abc",
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,

                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                },
                                                mode: {
                                                    isSearch: false,
                                                },
                                                value: "",
                                                abs_Change: this.testInput,
                                            },
                                        },
                                        type_data: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },
                                        id_API: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        title: "Hành động", // title của uSelectItem
                                                        class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                        placeholder: "Hướng dẫn",
                                                        helper: "abc",
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,

                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                },
                                                mode: {
                                                    isSearch: false,
                                                },
                                                value: "",
                                                abs_Change: this.testInput,
                                            },
                                        },
                                        is_set_back_data: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },
                                        begin: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },
                                        status: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },
                                        status_form: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },
                                        order: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        search: {
                                                            placeholder: "Search",
                                                        },
                                                        helper: "234",
                                                        data_status: "No Result",
                                                        title: "Office", // title của uSelectItem
                                                        class: "col-md-6", // hiển thị chiều dài của uSelectItem
                                                        required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                                    },
                                                    cmd: {
                                                        isHelper: true,
                                                        disable: false, //  true/false cho phép người dụng chọn item
                                                        visible: true, // true/false để hiển thị uSelectItem
                                                        isFocus: false,
                                                        error: {
                                                            message: "", // message rỗng sẽ không có thông báo
                                                            type: "", // hiện tại chưa dùng type
                                                        },
                                                    },
                                                    mode: {
                                                        //hiện tại mode chưa có
                                                    },
                                                },
                                                data: [
                                                    {
                                                        title: "Có",
                                                        value: "1",
                                                    },
                                                    {title: "Không", value: "123", selected: true},
                                                ],
                                                search_value: "",
                                                abs_Change: this.test1,
                                                abs_search: this.search,
                                            },
                                        },
                                        button_save: {
                                            dataFull: {
                                                config: {
                                                    default: {
                                                        title: "Luu rule", // title của button
                                                        type: "primary", // nhận 2 dạng type là "" -> default- có background trắng và "primary" -> có background xanh
                                                        //class: "col-md-1", // độ dài mặc định của uButton là "161px" với button không icon & "96px" với button có icon, nếu muốn thay đổi độ dài thì set .col-* vào class
                                                        icon: "", // nếu uButton có icon thì set vào, còn không có thì không dùng
                                                    },

                                                    cmd: {
                                                        disable: false, //true/false
                                                        isLoading: false, //truyền vào khi loading.
                                                        isFocus: false,
                                                    },
                                                },
                                                abs_Click: this.test3,
                                            },
                                        },
                                    },

                                    list_component:{
                                        title:"Danh sach Component",
                                        helper:"123",
                                        table_config: [
                                            {
                                                type: "UTableColumnDefault",
                                                config: {
                                                    mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                                                    isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
                                                },
                                            },
                                            {
                                                type: "UTableColumnDefault",
                                                config: {
                                                    mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                                                    isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
                                                },
                                            },
                                            {
                                                type: "UTableColumnDefault",
                                                config: {
                                                    mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                                                    isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
                                                },
                                            },

                                            {
                                                type: "UTableColumnDefault",
                                                config: {
                                                    mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                                                    isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
                                                },
                                            },

                                        ],
                                        table_header: {
                                            dataFull: {
                                                Header: {
                                                    data: [
                                                        {
                                                            title: "Layout",

                                                            config: {
                                                                width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                                                                isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                                                            },
                                                        },
                                                        {
                                                            title: "View",

                                                            config: {
                                                                isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                                                            },
                                                        },
                                                        {
                                                            title: "Name",

                                                            config: {
                                                                isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                                                            },
                                                        },
                                                        {
                                                            title: "Code",

                                                            config: {
                                                                isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                                                            },
                                                        },

                                                    ],
                                                    config: {
                                                        // config của header
                                                        mode: {
                                                            hasSearch: false, //nếu muốn có search thì truyền vào true
                                                            isFrozenHeader: true,
                                                        },
                                                    },
                                                },
                                                config: {
                                                    // config của table
                                                    mode: {
                                                        noHeader: false, //dùng cho trường hợp không sử dụng header- truyền vào true
                                                    },
                                                },
                                                // nếu có dùng uPagination (phân trang) thì truyền vào
                                            },
                                        },
                                        table_data: [
                                            {
                                                data: [



                                                    {
                                                        data: "Layout moi", //trong trường hợp này data tương ứng với title
                                                    },

                                                    {
                                                        data: "View moi", //trong trường hợp này data tương ứng với title
                                                    },
                                                    {
                                                        data: "Mau component", //trong trường hợp này data tương ứng với title
                                                    },

                                                    {
                                                        data: "", //trong trường hợp này data tương ứng với title
                                                    },

                                                ],
                                                config: {
                                                    value: false, //truyền true nếu được chọn
                                                },
                                            },
                                        ],
                                    }
                                },
                            }}
                        />