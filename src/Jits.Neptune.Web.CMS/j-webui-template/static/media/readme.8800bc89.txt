 Hướng dẫn sử dụng modal config_component
    -   đầu tiên phải khai báo 1 uFormTab là bằng hàm ..._getComponent
    -   vì component uFormTab được truyền theo cú pháp
    <UFormTab dataFull={{...new_data_uFormTab,abs_select:this.abs_select}}/>
    nên ta phải tạo 1 new_data_uFormTab. cú pháp tạo như sau:


    let new_data_uFormTab = [];
    for (const tab of this.props.stateData.form.tab_form.data) {
      new_data_uFormTab.push({
        tabInfo: {
          title: tab.title,
          id: tab.id,
        },
        sysStyle: { show: tab.isShow ? "show" : "" },
        DOM_elm: this.renderTableDevice(tab.id),
      });
    }

    new_data_uFormTab = { data: new_data_uFormTab };


    - hàm các hàm thêm vào được viết như sau:
    renderTableDevice(table_key) {
       return (
          <React.Fragment>
            {table_key === "configComponent_Default" && (
              <div className="designForm-desktop-uModal-config_component-tab">
                <UFormTab dataFull={this.getDataTabFormChild(table_key)}/>
              </div>
            )}
            {table_key === "configComponent_JSON" && (
              <div className="designForm-desktop-uModal-config_component-tab_JSON row">
                {this.props.stateData.form[table_key].CCP_JSON_config.list_text_area.map((item,index)=>{
              return <UTextArea key={index} {...item}/>
            })}
              </div>
            )}
             {table_key === "CCP_Default_Default" && (
             <CCPDefaultDefault stateData={{...this.props.stateData.form[table_key][table_key+"_config"]}}/>
            )}
            {table_key === "CCP_Default_Config" && (
              <CCPDefaultConfig stateData={{...this.props.stateData.form[table_key][table_key+"_config"]}}/>
            )}
             {table_key === "CCP_Default_Role" && (
             <CCPDefaultRole stateData={{...this.props.stateData.form[table_key][table_key+"_config"]}}/>

            )}
            {table_key === "CCP_Default_Essence" && (
            <CCPDefaultEssence stateData={{...this.props.stateData.form[table_key][table_key+"_config"]}}/>

            )}
             {table_key === "CCP_Default_Validate" && (
            <CCPDefaultValidate stateData={{...this.props.stateData.form[table_key][table_key+"_config"]}}/>

            )}
             {table_key === "CCP_Default_Lang" && (

             <CCPDefaultLang stateData={{...this.props.stateData.form[table_key][table_key+"_config"]}}/>


            )}
          </React.Fragment>
        );
      }
      getDataTabFormChild(table_key){
        let new_data_uFormTab_child = [];
        for (const tab of this.props.stateData.form[table_key].tab_form.data) {
          new_data_uFormTab_child.push({
            tabInfo: {
              title: tab.title,
              id: tab.id,
            },
            sysStyle: { show: tab.isShow ? "show" : "" },
            DOM_elm: this.renderTableDevice(tab.id),
          });
        }

        new_data_uFormTab_child = { data: new_data_uFormTab_child };
        return new_data_uFormTab_child;
      }



        - với this.props.stateData.form có cấu trúc data:
         form: {
                            tab_form: {
                              data: [
                                {
                                  title: "Thiết lập thông số",
                                  id: "configComponent_Default",
                                },
                                {
                                  title: "JSON",
                                  id: "configComponent_JSON",
                                },
                              ],
                              abs_select: this.abs_selectTabForm,
                            },
                            configComponent_Default: {
                              tab_form: {
                                data: [
                                  {
                                    title: "Mặc định",
                                    id: "CCP_Default_Default",
                                  },
                                  {
                                    title: "Cấu hình",
                                    id: "CCP_Default_Config",
                                  },
                                  {
                                    title: "Quyền",
                                    id: "CCP_Default_Role",
                                  },
                                  {
                                    title: "Tính chất",
                                    id: "CCP_Default_Essence",
                                  },
                                  {
                                    title: "Validate",
                                    id: "CCP_Default_Validate",
                                  },
                                  {
                                    title: "Ngôn ngữ",
                                    id: "CCP_Default_Lang",
                                  },
                                ],
                                abs_select: this.abs_selectTabForm,
                              },
                            },
                            configComponent_JSON: {
                              CCP_JSON_config: {
                                list_text_area: [
                                  {
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
                                  {
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
                                  {
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
                                  {
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
                                ],
                              },
                            },
                            CCP_Default_Config: {
                              CCP_Default_Config_config: {


                                //PHẦN NÀY LÀ PHẦN DATA ĐỘNG TUỲ THEO FORM


                              },
                            },
                            CCP_Default_Default: {
                              CCP_Default_Default_config: {
                                name_component: {
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
                                code_component: {
                                  dataFull: {
                                    config: {
                                      default: {
                                        title: "Code", // title của uSelectItem
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
                                class_component: {
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
                                permission_component: {
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
                                condition_component: {
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
                                of_group: {
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
                            },
                            CCP_Default_Role: {
                              CCP_Default_Role_config: {
                                disable: {
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
                                        required: true, //true/false hiển thị dấu * phân biệt bắt buộc nhập
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
                                visible: {
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
                                        required: true, //true/false hiển thị dấu * phân biệt bắt buộc nhập
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
                            },
                            CCP_Default_Essence: {
                              CCP_Default_Essence_config: {},
                            },
                            CCP_Default_Validate: {
                              CCP_Default_Validate_config: {
                                is_required: {
                                  dataFull: {
                                    value: false,
                                    title: "Bắt buộc nhập",
                                    class: "col-md-12",
                                    config: {
                                      cmd: {
                                        disable: false,
                                        error: { message: "", type: "" },
                                      },
                                    },
                                  },
                                },
                                min_words: {
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
                                max_words: {
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
                                structure_regex: {
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
                            },

                            CCP_Default_Lang: {
                              CCP_Default_Lang_config: {
                                title: "Ten component theo ngon ngu",
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
                                          helper_description: "abc",
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
                                          helper_description: "abc",
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
                          },


       - trong đó tên của các form dùng để gọi là:
       import CCPDefaultDefault from '../CCP_Default_Default'

       import CCPDefaultConfig from '../CCP_Default_Config_*'

       import CCPDefaultEssence from '../CCP_Default_Essence'

       import CCPDefaultLang from '../CCP_Default_Lang'
       import CCPDefaultRole from '../CCP_Default_Role'
       import CCPDefaultValidate from '../CCP_Default_Validate'

       - Lưu ý form CCPDefaultConfig là form động tuỳ theo component được chọn sẽ được gọi theo tên các form sau:
            - CCP_Default_Config_tableDefault
            - CCP_Default_Config_checkBox
            - CCP_Default_Config_currency
            - CCP_Default_Config_maskInput
            - CCP_Default_Config_multiValue
            - CCP_Default_Config_sameMain
            - CCP_Default_Config_select
            - CCP_Default_Config_tableForm
            - CCP_Default_Config_textInput
       - data readme của từng form sẽ gửi kèm theo sau.




cuối cùng gọi form designFormModal_ConfigComponent theo cú pháp sau
            <ModalConfirm
              stateData={{
                modal: {
                  title: "Config Component",
                  abs_Close: this.abs_Close,
                  visibility: this.state.visibility,
                },
              }}
            >
            <UFormTab dataFull={{...new_data_uFormTab,abs_select:this.abs_select}}/>
            </ModalConfirm>