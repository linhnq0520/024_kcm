<ModalConfirm
              stateData={{
                modal: {
                  title: "Config layout",
                  helper:
                    "Lorem Ipsum is simply dummy text of the printing and typesetting about industry simply dummy.  ",
                  abs_Close: this.abs_Close,
                  visibility: this.state.visibility,
                },

                form: {
                  list_buttons: [
                    {
                      dataFull: {
                        config: {
                          default: {
                            title: "cancel", // title của button
                            type: "", // nhận 2 dạng type là "" -> default- có background trắng và "primary" -> có background xanh
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
                    {
                      dataFull: {
                        config: {
                          default: {
                            title: "save", // title của button
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
                  ],

                  config_layout: {
                    title: "Cấu hình layout: layout mới",
                    name_layout: {
                      dataFull: {
                        config: {
                          default: {
                            title: "Tên layout", // title của uSelectItem
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
                    guide_layout: {
                      dataFull: {
                        config: {
                          default: {
                            title: "Hướng dẫn", // title của uSelectItem
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
                    class_layout: {
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
                  },
                  guide_layout: {
                    title: "Tên layout (Ngôn ngữ)",
                    helper: "123",
                    list_guide_inputs: [
                      {
                        dataFull: {
                          config: {
                            default: {
                              title: "Tieng Viet", // title của uSelectItem
                              class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                              required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                              placeholder: "",
                              helper: "abc",
                            },
                            cmd: {
                              isHelper: false,
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
                      {
                        dataFull: {
                          config: {
                            default: {
                              title: "Tieng Anh", // title của uSelectItem
                              class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                              required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                              placeholder: "",
                              helper: "abc",
                            },
                            cmd: {
                              isHelper: false,
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
                    ],
                  },
                  lang_layout: {
                    title: "Hướng dẫn (Ngôn ngữ)",
                    helper: "123",
                    list_lang_inputs: [
                      {
                        dataFull: {
                          config: {
                            default: {
                              title: "Tieng Viet", // title của uSelectItem
                              class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                              required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                              placeholder: "",
                              helper: "abc",
                            },
                            cmd: {
                              isHelper: false,
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
                      {
                        dataFull: {
                          config: {
                            default: {
                              title: "Tieng Anh", // title của uSelectItem
                              class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
                              required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                              placeholder: "",
                              helper: "abc",
                            },
                            cmd: {
                              isHelper: false,
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
                    ],
                  },
                },
              }}
            ></ModalConfirm>
          