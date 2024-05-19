tên form: CCP_Default_Config_button
for_grid: {
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
                        icon: {
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
                        color: {
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

                        action: {
                          action_multiValue: {
                            dataFull: {
                              config: {
                                default: {
                                  title: "HÀNH ĐỘNG",
                                },
                                cmd: {
                                  visible: true,
                                },
                              },
                            },
                          },
                          action_callForm: {
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
                                { title: "Không", value: "123", selected: true },
                              ],
                              search_value: "",
                              abs_Change: this.test1,
                              abs_search: this.search,
                            },
                          },
                          action_textarea: {
                            dataFull: {
                              config: {
                                default: {
                                  helper: "test",
                                  title: "Actions", // title của uTextArea
                                  class: "col-md-12", // số cột hiển thị trên view
                                  rows: 10, // độ rộng của textarea
                                  code_form_component: "", // xác định xem đang dùng textarea nào
                                },
                                cmd: {
                                  isHelper: true,
                                  disable: false, // true/false cho phép nhập textarea hay không
                                  visible: true, // true/false cho phép hiển thị textarea hay không
                                  error: {
                                    message: "", // thông báo lỗi
                                    type: "", // kiểu định dạng lỗi: danger, info, success, gray, default
                                  },
                                },
                              },
                              data: [], // ở uInput không dùng data
                              value: "test", // nhận vào các kiểu string/number.
                              abs_Change: this.testTextArea,
                            },
                          },
                        },
                        master_data: {

                          MD_multiValue: {
                            dataFull: {
                              config: {
                                default: {
                                  title: "MASTER DATA",
                                },
                                cmd: {
                                  visible: true,
                                },
                              },
                            },
                          },
                          MD_isMasterData: {
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
                                { title: "Không", value: "123", selected: true },
                              ],
                              search_value: "",
                              abs_Change: this.test1,
                              abs_search: this.search,
                            },
                          },

                        },