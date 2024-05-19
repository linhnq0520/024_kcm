tên form: CCP_Default_Config_elearning


data_training: {
                          dataFull: {
                            config: {
                              default: {
                                title: "Tên layout", // title của uSelectItem
                                class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
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