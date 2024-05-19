tên form: CCP_Default_Config_maskInput


is_lookup: {
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
                        get_set: {
                          GS_multiValue: {
                            dataFull: {
                              config: {
                                default: {
                                  title: "GET VÀ SET DỮ LIỆU",
                                },
                                cmd: {
                                  visible: true,
                                },
                              },
                            },
                          },
                          GS_collectionMethod: {
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
                          GS_readData: {
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

                        },
                        mask: {
                          mask_multiValue: {
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
                          mask_typeData: {
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
                          mask_format:{
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
                          mask_formatFromData:{
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

                        data_input: {
                          DI_multiValue: {
                            dataFull: {
                              config: {
                                default: {
                                  title: "NHAP LIEU",
                                },
                                cmd: {
                                  visible: true,
                                },
                              },
                            },
                          },
                          DI_dataDefault:{
                            dataFull: {
                              config: {
                                default: {
                                  helper:"123s",
                                  title: "Office", // title của uSelectItem
                                  class: "col-md-6 ", // hiển thị chiều dài của uSelectItem
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
                          DI_typeData: {
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