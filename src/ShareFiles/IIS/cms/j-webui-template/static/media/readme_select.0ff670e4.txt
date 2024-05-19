 tên form: CCP_Default_Config_select


 collection_method: {
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
                        read_data: {
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
                        data_default: {
                          dataFull: {
                            config: {
                              default: {
                                title: "Hướng dẫn", // title của uSelectItem
                                class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
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
                        config_data: {
                          dataFull: {
                            config: {
                              default: {
                                title: "Class", // title của uSelectItem
                                class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
                                required: true, //true/false hiển thị dấu * phân biệt bắt buộc nhập
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
                        key_data: {
                          dataFull: {
                            config: {
                              default: {
                                title: "Tên layout", // title của uSelectItem
                                class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
                                required: true, //true/false hiển thị dấu * phân biệt bắt buộc nhập
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
                        auto_default: {
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
                        store_data: {
                          SD_multiValue: {
                            dataFull: {
                              config: {
                                default: {
                                  title: "KHO DỮ LIỆU",
                                },
                                cmd: {
                                  visible: true,
                                },
                              },
                            },
                          },
                          SD_typeData: {
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
                          SD_queryData:{
                            dataFull: {
                              config: {
                                default: {
                                  helper:"123s",
                                  title: "Office", // title của uSelectItem
                                  class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
                                  required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                  placeholder: "Search",
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
                          SD_textarea: {
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
                        interface: {
                          interface_multiValue: {
                            dataFull: {
                              config: {
                                default: {
                                  title: "GIAO DIỆN",
                                },
                                cmd: {
                                  visible: true,
                                },
                              },
                            },
                          },
                          interface_formatTable: {
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
                          interface_selectMethod: {
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
                          interface_configColumn:{
                            dataFull: {
                              config: {
                                default: {
                                  helper:"123s",
                                  title: "Office", // title của uSelectItem
                                  class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
                                  required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                  placeholder: "Search",
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
                          interface_renderData:{
                            dataFull: {
                              config: {
                                default: {
                                  helper:"123s",
                                  title: "Office", // title của uSelectItem
                                  class: "col-md-12 ", // hiển thị chiều dài của uSelectItem
                                  required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                                  placeholder: "Search",
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