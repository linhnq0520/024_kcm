 stateData:{
   form: {
          dataFull: {
            config: {
              default: {
                title: "Roles Profile", //title của uForm
              },
            },
            cmd: { visibility: "" }, // "none" hoặc "" là ẩn hiện form
          },
        },

        tab: [
          {
            id: "column1",
            title: "Role Profile - Invoke - Approve",
          },
          {
            id: "column2",
            title: "Role Profile - Add - Remove",
          },
          {
            id: "column3",
            title: "Role Profile - User - Assignment",
          },
          {
            id: "column4",
            title: "Invoke Limit",
          },
          {
            id: "column5",
            title: "Approve Limit",
          },
        ],
        column1: {
          tree_data: this.getConfigTemplateTree(),
          title_table_up: "OPEARTION",
          table_up: {
            dataFull: {
              Header: {
                data: [
                  {
                    title: "ROLE NAME",
                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "SEFK INVOKE",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "SEARCH",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "ADD",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "VIEW",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "MODIFY",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "DELETE",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "SAVE",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "CLEAR",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "PRINT",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "IMPORT",

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
          table_up_data: [
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
          ],
          table_up_config: [
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
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
          ],
          title_table_down: "VERIFICATION",
          table_down: {
            dataFull: {
              Header: {
                data: [
                  {
                    title: "ROLE NAME",
                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "SEFK INVOKE",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "SEARCH",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "ADD",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "VIEW",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "MODIFY",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "DELETE",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "SAVE",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "CLEAR",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "PRINT",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "IMPORT",

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
          table_down_data: [
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
            [
              {
                data: "UTL", //trong trường hợp này data tương ứng với title
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
              {
                isCheck: false,
                abs_Click: this.abs_Ckeck,
              },
            ],
          ],
          table_down_config: [
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
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
            {
              type: "uTableColumnCheckbox",
            },
          ],
        },
        column4: {
          auto_save: {
            dataFull: {
              isCheck: false,
              dataItem: { test: "abc" },
            },
            abs_Click: this.test,
          },
          listItem: [
            {
              dataFull: {
                title: "aaaa",
                selected: true,
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
          ],
          table: {
            dataFull: {
              Header: {
                data: [
                  {
                    title: "GROUP",
                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "CAPTION",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "USD",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "KHR",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "EUR",

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
          table_data: [
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
          ],
          table_config: [
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
              type: "uTableColumnDefault",
              config: {
                mode: "right", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
            {
              type: "uTableColumnDefault",
              config: {
                mode: "right", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
            {
              type: "uTableColumnDefault",
              config: {
                mode: "right", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
          ],
        },
        column5: {
          auto_save: {
            dataFull: {
              isCheck: false,
              dataItem: { test: "abc" },
            },
            abs_Click: this.test,
          },
          listItem: [
            {
              dataFull: {
                title: "aaaa",
                selected: true,
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                title: "aaaa",
              },
              abs_Click: this.test,
            },
          ],
          table: {
            dataFull: {
              Header: {
                data: [
                  {
                    title: "GROUP",
                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "CAPTION",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "USD",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "KHR",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "EUR",

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
          table_data: [
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
            [
              {
                data: "Accounting", //trong trường hợp này data tương ứng với title
              },
              {
                data: "1186: Free collection", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
              {
                data: "0", //trong trường hợp này data tương ứng với title
              },
            ],
          ],
          table_config: [
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
              type: "uTableColumnDefault",
              config: {
                mode: "right", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
            {
              type: "uTableColumnDefault",
              config: {
                mode: "right", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
            {
              type: "uTableColumnDefault",
              config: {
                mode: "right", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
          ],
        },
        column2: {
          role_name_adding: {
            dataFull: {
              config: {
                default: {
                  title: "Role Name (for adding)",
                  type: "text",
                  class: "col-sm-5",
                  code_form_component: "role_name_adding",
                },
                cmd: {
                  disable: false,
                  visible: true,

                  error: {
                    message: "",
                    type: "",
                  },
                },
              },
              data: "", // nhận vào các kiểu string/number.
            },
            abs_Change: this.onChangeValue,
          },
          listButton: [
            {
              dataFull: {
                config: {
                  default: {
                    title: "Add",
                    icon: "add_circle_outline",
                  },
                },
              },
              abs_Click: this.abs_Click,
            },
            {
              dataFull: {
                config: {
                  default: {
                    title: "Remove",
                    icon: "highlight_off",
                  },
                },
              },
              abs_Click: this.abs_Click,
            },
            {
              dataFull: {
                config: {
                  default: {
                    title: "Save",
                    type: "primary",
                    icon: "check_circle_outline",
                  },
                },
              },
              abs_Click: this.abs_Click,
            },
          ],
          role_name_copying: {
            dataFull: {
              config: {
                default: {
                  title: "Role Name (for copying or deleting)",
                  type: "text",
                  class: "col-sm-5",
                  code_form_component: "role_name_copying",
                },
                cmd: {
                  disable: false,
                  visible: true,

                  error: {
                    message: "",
                    type: "",
                  },
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
        },
        column3: {
          role_choose_left: {
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
          role_choose_right: {
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
                      isCheck: false,
                      abs_Click: this.abs_CheckAll,
                    },
                    config: {
                      hasCheck: true,
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "User Code",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "User Name",

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
                  height: "520px",
                  noHeader: false, //dùng cho trường hợp không sử dụng header- truyền vào true
                },
              },
              // nếu có dùng uPagination (phân trang) thì truyền vào
            },
          },
          table_left_data: [
            {
              data:[
              {
                data: "2", //trong trường hợp này data tương ứng với title
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
            ],
            config:{
              isCheck:false
            }
            }
          ],
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
                      isCheck: false,
                      abs_Click: this.abs_CheckAll,
                    },
                    config: {
                      hasCheck: true,
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },
                  {
                    title: "User code",

                    config: {
                      width: "", // nếu muốn set độ dài cho column thì truyền vào, dữ liệu kiểu "*px" - với * là số.
                      isFrozen: false, // nếu muốn đóng băng cột thì truyền vào true (hiện tại chỉ hoạt động ở cột đầu tiên - sẽ fix lại sau)
                    },
                  },

                  {
                    title: "User Name",

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
                  height: "520px",
                  noHeader: false, //dùng cho trường hợp không sử dụng header- truyền vào true
                },
              },
              // nếu có dùng uPagination (phân trang) thì truyền vào
            },
          },
          table_right_data: [
            {
              data: [
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
                data: "ACT Manager", //trong trường hợp này data tương ứng với title
              },
            ],
            config:{
              isCheck:true
            }
            }
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
              type: "uTableColumnDefault",
              config: {
                mode: "left", // nhận 3 giá trị left/right/center tương ứng cách hiển thị data trong ô
                isFrozen: false, //nếu đóng băng cột thì truyền vào true/ lưu ý hiện tại chỉ đóng băng 1 cột đầu tiên, nên chỉ truyền khi ở cột đầu tiên
              },
            },
          ],
        },
 }
 getConfigTemplateTree() {
    return {
      tree_data: [
        {
          title: "Home",
          parent_id: "0",
          is_open: false,
          DOM_elm: null,
          id: "1",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Customer",
          parent_id: "0",
          is_open: false,
          DOM_elm: null,
          id: "2",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Lá số 2",
          parent_id: "1",
          is_open: false,
          DOM_elm: null,
          id: "1.1",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Customer Profile",
          parent_id: "2",
          is_open: false,
          DOM_elm: null,
          id: "2.1",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Customer Group",
          parent_id: "2",
          is_open: false,
          DOM_elm: null,
          id: "2.2",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Customer Linkage",
          parent_id: "2",
          is_open: false,
          DOM_elm: null,
          id: "2.3",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Lá số 2.2",
          parent_id: "1",
          is_open: false,
          DOM_elm: null,
          id: "1.2",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
        {
          title: "Lá số 3",
          parent_id: "1.1",
          is_open: false,
          DOM_elm: null,
          id: "1.11",
          dataItem: {
            test: "Đây là data",
          },
          abs_click: this.abs_select_item_menu,
        },
      ],
      config: {
        open_one: true, //cho phép mở một hoặc nhiều
        is_has_dom: true, //Có DOM hoặc không
      },
    };
  }

  abs_select_item_menu = (e, data_item) => {
    console.log(data_item);
  };