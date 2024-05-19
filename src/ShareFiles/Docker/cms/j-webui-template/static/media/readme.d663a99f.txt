các hàm cần xử lý:
abs_CheckAll=()=>{
  //khi hàm này chạy, cần set chọn/bỏ chọn tất cả các item
}
abs_Check=(dataItem)=>{
  //trả về dataItem được truyền trong check box, yêu cầu đổi trạng thái của checkbox tổng trong header sang true/false/"-" -> đổi nằm trong table_right/table_left.dataFull.Header.data[2].data.isCheck
} 
 
 getConfigTemplate() {
    return {
      stateData: {
        form: {
          dataFull: {
            config: {
              default: {
                title: "Permissions And Users", //title của uForm
                title_sub: "Relationship between access rigts and users!",
              },
            },
            cmd: { visibility: "" }, // "none" hoặc "" là ẩn hiện form
          },
        },
        search:{
          abs_search:this.search
        },
        role_choose: {
          dataFull: {
            config: {
              default: {
                title: "rrrrrrr",
                type: "text",
                class: "col-md-12",
                code_form_component: "language_default",
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                },
              },
              mode: {
                noTitle: true,
              },
            },
            data: [
              { title: "Viet Nam", value: "123", selected: true },
              { title: "New acc", value: "1234" },
              { title: "New aa", value: "12345" },
              { title: "New pub", value: "122" },
            ],
          },
          abs_Change: this.onChangeValueSelect,
          abs_search: this.onSearch,
        },
        preview: {
          dataFull: {
            config: {
              default: {
                title: "",
                type: "",
                icon: "keyboard_arrow_left",
              },
            },
          },
          abs_Click: this.abs_Click,
        },
        preview_all: {
          dataFull: {
            config: {
              default: {
                icondouble: "keyboard_arrow_left",
              },
            },
          },
          abs_Click: this.abs_Click,
        },
        next_all: {
          dataFull: {
            config: {
              default: {
                type: "",
                icondouble: "keyboard_arrow_right",
              },
            },
          },
          abs_Click: this.abs_Click,
        },
        next: {
          dataFull: {
            config: {
              default: {
                type: "",
                icon: "keyboard_arrow_right",
              },
            },
          },
          abs_Click: this.abs_Click,
        },
        table_left: {
          dataFull: {
            Header: {
              data: [
                {
                  title: "NO.",
                  config: {
                    width: "50px", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },
                {
                  title: "",
                  data: {
                    isCheck: false, //truyền vào true/false/"-"
                    abs_Click: this.abs_CheckAll,
                  },
                  config: {
                    hasCheck: true,
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },
                {
                  title: "Full name",

                  config: {
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },
                {
                  title: "Email",

                  config: {
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },
                {
                  title: "Status",

                  config: {
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
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
        table_left_config: [
          {
            type: "uTableColumnDefault",
            config: {
              mode: "center", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
              isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
            },
          },
          {
            type: "uTableColumnCheckbox",
          },
          {
            type: "uTableColumnDefault",
            config: {
              mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
              isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
            },
          },
          {
            type: "uTableColumnDefault",
            config: {
              mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
              isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
            },
          },
          {
            type: "uTableColumnAction",
          },
        ],
        table_right_config: [
          {
            type: "uTableColumnDefault",
            config: {
              mode: "center", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
              isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
            },
          },
          {
            type: "uTableColumnCheckbox",
          },
          {
            type: "uTableColumnDefault",
            config: {
              mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
              isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
            },
          },

          {
            type: "uTableColumnAction",
          },
        ],
        table_left_data: [
          {
            data:[
            {
              data: "1", //trong trường hợp này data tương ứng với title
            },
            {
              isCheck: false,
              abs_Click: this.abs_Ckeck,
            },
            {
              data: "ACT Manager", //trong trường hợp này data tương ứng với title
            },
            {
              data: "abc@gmail.com", //trong trường hợp này data tương ứng với title
            },
            {
              data: {
                title: "Active", // title của ô
                type: "success", // type hiện tại nhận các giá trị danger/info/success/gray
              },
            },
          ],
          config:{
            isCheck:false
          }
          }
        ],
        table_right: {
          dataFull: {
            Header: {
              data: [
                {
                  title: "NO.",
                  config: {
                    width: "50px", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },
                {
                  title: "",
                  data: {
                    isCheck: false, //truyền vào true/false/"-"
                    abs_Click: this.abs_CheckAll,
                  },
                  config: {
                    hasCheck: true,
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },
                {
                  title: "Full name",

                  config: {
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                    isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                  },
                },

                {
                  title: "Status",

                  config: {
                    width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
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
        table_right_data: [
          {
            data:[
            {
              data: "1", //trong trường hợp này data tương ứng với title
            },
            {
              isCheck: false,
              abs_Click: this.abs_Ckeck,
            },
            {
              data: "ACT Manager", //trong trường hợp này data tương ứng với title
            },

            {
              data: {
                title: "Active", // title của ô
                type: "success", // type hiện tại nhận các giá trị danger/info/success/gray
              },
            },
          ],
          config:{
            isCheck:false
          }
          }
        ],
      },
    };
  }
