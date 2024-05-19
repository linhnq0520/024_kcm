this.state = {

      stateData: {
         add: {
          dataFull: {
            config: {
              default: {
                title: "Add",
                type: "primary",
                class: "col-sm-1",
              },
            },
          },
          abs_Click: this.abs_Click,
        },
        table_para: this.getConfigTablePara(),
        table_para_rows: this.getConfigTableParaRows(),
        table_para_rows_config:this.getConfigTableParaRowsCofig(),
      }
    }

 getConfigTableParaRowsCofig() {
    return [
      {
        type: "uTableColumnDefault",
        config: {
          mode: "center",
          isFrozen: false,
        },
      },
      {
        type: "uTableColumnDefault",
        config: {
          mode: "left",
          isFrozen: false,
        },
      },
      {
        type: "uTableColumnEditInput",
      },
      {
        type: "uTableColumnEditInput",
      },
      {
        type: "uTableColumnEditSelect",
      },
      {
        type: "uTableColumnButton",
      },
    ];
  }
getConfigTablePara() {
    return {
      dataFull: {
        Header: {
          data: [
            {
              title: "No.",
              id: "",
              config: {
                //nếu có set width thì truyền vào
                width: "50px",
                isFrozen: false,
              },
            },
            {
              title: "Parameter title",
              id: "",
              config: {
                //nếu có set width thì truyền vào
                width: "",
                isFrozen: false,
              },
            },
            {
              title: "Value",
              id: "",
              config: {
                //nếu có set width thì truyền vào
                width: "",
                isFrozen: false,
              },
            },
            {
              title: "Note",
              id: "",
              config: {
                //nếu có set width thì truyền vào
                width: "",
                isFrozen: false,
              },
            },
            {
              title: "Data type",
              id: "",
              config: {
                //nếu có set width thì truyền vào
                width: "",
                isFrozen: false,
              },
            },
             {
              title: "",
              id: "",
              config: {
                //nếu có set width thì truyền vào
                width: "300px",
                isFrozen: false,
              },
            },
          ],
          config: {
            mode: {
              hasSearch: false,
            },
          },
        },
        config: {
          mode: {
            noHeader: false, //dùng cho trường hợp không sử dụng header
          },
        },
        uPagination: {
          result_total: 6,
          paging_record: [
            {
              number: 5,
              selected: true,
            },
            {
              number: 10,
            },
          ],
        },
      },
    };
  }

getConfigTableParaRows() {
    return [
      [
        {
          data: "1",
        },
        {
          data: "customerMediaFiles",
        },
        {
          value: "abc",
          isUpdate: false,
          dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
          abs_Change: this.table_input_change_detail,
        },
        {
          value: "",
          isUpdate: false,
          dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
          abs_Change: this.table_input_change_detail,
        },
        {
          data: [
            {
              title: "abc",
              selected: true,
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
          ],
          isUpdate: false,
          dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
          abs_Change: this.table_select_change_detail,
        },
        {
          data: [
            {
              dataFull: {
                config: {
                  default: {
                    title: "Save",
                    type: "",
                    class: "",
                  },
                },
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                config: {
                  default: {
                    title: "Save (Amin)",
                    type: "primary",
                    class: "",
                  },
                },
              },
              abs_Click: this.test,
            },
          ],
        },
      ],
      [
        {
          data: "1",
        },
        {
          data: "customerMediaFiles",
        },
        {
          value: "",
          isUpdate: false,
          dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
          abs_Change: this.table_input_change_detail,
        },
        {
          value: "",
          isUpdate: false,
          dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
          abs_Change: this.table_input_change_detail,
        },
        {
          data: [
            {
              title: "abc",
              selected: true,
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
            {
              title: "cds",
            },
            {
              title: "123",
            },

            {
              title: "1234",
            },
          ],
          isUpdate: false,
          dataItem: { abc: "nội dung của dev gửi vào tuỳ ý" },
          abs_Change: this.table_select_change_detail,
        },
        {
          data: [
            {
              dataFull: {
                config: {
                  default: {
                    title: "Save",
                    type: "",
                    class: "",
                  },
                },
              },
              abs_Click: this.test,
            },
            {
              dataFull: {
                config: {
                  default: {
                    title: "Save (Amin)",
                    type: "primary",
                    class: "",
                  },
                },
              },
              abs_Click: this.test,
            },
          ],
        },
      ],
    ];
  }
 <PraraServer stateData={this.state.stateData}></PraraServer>

  table_input_change_detail = (event, dataItem, index_row, index_col) => {
    let data = this.state.stateData;
    data.table_para_rows[index_row][index_col].dataFull.value = event.target.value;
    this.setState({ stateData: data });
  }