  tên form: CCP_Default_Config_treeView


  title_component: {
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
                                  class: "col-md-12", // hiển thị chiều dài của uSelectItem
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

                          store_data: {
                            SD_multiValue: {
                              dataFull: {
                                config: {
                                  default: {
                                    title: "KHO DU LIEU",
                                    required:true
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
                            SD_addData: {
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
                            SD_keyData: {
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
                            SD_idParent: {
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
                            SD_keyIdParent: {
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
                            SD_keyShowData: {
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
                          },
                          get_data: {
                            GD_multiValue: {
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

                            GD_formatData: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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
                            GD_configData: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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
                            GD_separator: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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
                          interface: {
                            interface_multiValue: {
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

                            interface_iconOpen: {
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
                            interface_iconClose: {
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
                            interface_iconMinData: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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
                          enhance: {
                            enhance_multiValue: {
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

                            enhance_autoChoose: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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
                            enhance_levelMaxChild: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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
                            enhance_idMaxParent: {
                              dataFull: {
                                config: {
                                  default: {
                                    search: {
                                      placeholder: "Search",
                                    },
                                    helper: "234",
                                    data_status: "No Result",
                                    title: "Office", // title của uSelectItem
                                    class: "col-md-12", // hiển thị chiều dài của uSelectItem
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