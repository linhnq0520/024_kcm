  tên form: CCP_Default_Config_tabInput


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
                          data_default: {
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
                          title_name: {
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
                          is_search: {
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
                                    title: "KHO DU LIEU",
                                    required:false
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

                            SD_cdgrp: {
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
                            SD_cdname: {
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
                          config_data: {
                            CD_multiValue: {
                              dataFull: {
                                config: {
                                  default: {
                                    title: "KHO DU LIEU",
                                    required:false
                                  },
                                  cmd: {
                                    visible: true,
                                  },
                                },
                              },
                            },


                            CD_configData: {
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
                            CD_separator: {
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
                          show_table_data: {
                            STD_multiValue: {
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

                            STD_isMultiColumn: {
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
                            STD_dataShow: {
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
                            STD_titleTag: {
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