tên form: CCP_Default_Config_chart




 query_data: {
                          dataFull: {
                            config: {
                              default: {
                                title: "Class", // title của uSelectItem
                                class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
                                required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                placeholder: "Class",
                                helper: "abc",
                                code_form_component:query_data,
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
                        chart_type: {
                          dataFull: {
                            config: {
                              default: {
                                title: "Class", // title của uSelectItem
                                class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
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
                        height: {
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
                        width: {
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

                        config_column: {
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
                        config_optional: {
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
                        see_more:{
                          title:"Xem them tai day",
                          abs_Click:this.see_more,
                          dataItem:{}
                        }