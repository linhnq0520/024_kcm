let stateData = {
    tab: [
      { title: "Search", id: "1" },
      { title: "Import", id: "2" },
      { title: "Approve", id: "3" },
      { title: "View - Modify", id: "4" },
    ],
    table_config: [
      { type: "uTableColumnCheckbox" },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
      {
        type: "uTableColumnDefault",
        config: { mode: "left", isFrozen: false },
      },
    ],
    table_header: {
      dataFull: {
        Header: {
          data: [
            {
              title: "",
              config: { hasCheck: false, width: "", isFrozen: false },
            },
            { title: "Customer code", config: { width: "", isFrozen: false } },
            { title: "Customer type", config: { width: "", isFrozen: false } },
            { title: "Media name", config: { width: "", isFrozen: false } },
            { title: "Status", config: { width: "", isFrozen: false } },
            { title: "Media type", config: { width: "", isFrozen: false } },
            { title: "Open date", config: { width: "", isFrozen: false } },
            { title: "Last date", config: { width: "", isFrozen: false } },
            { title: "Exprire date", config: { width: "", isFrozen: false } },
            { title: "Other", config: { width: "", isFrozen: false } },
          ],
          config: { mode: { hasSearch: false } },
        },
        config: { mode: { noHeader: false } },
        uPagination: {
          number_show: 0,
          result_total: 6,
          mode: { noJumpPage: false },
          paging_record: [
            { number: 5, selected: true },
            { number: 10, selected: false },
            { number: 15, selected: false },
            { number: 50, selected: false },
          ],
        },
      },
    },
    table_data: [
      {
        data: [
          { isCheck: false },
          { data: "00011000001" },
          { data: "Single customer" },
          { data: "Chartist.png" },
          { data: "Approved" },
          { data: "img" },
          { data: 1572393600000 },
          { data: 1572393600000 },
          { data: "expdt" },
          { data: "other" },
        ],
        dataItem: {
          mediaid: 668,
          customercd: "00011000001",
          reftypect: "Single customer",
          mdname: "Chartist.png",
          caption: "Approved",
          mdtype: "img",
          opndt: 1572393600000,
          lastdt: 1572393600000,
          expdt: "expdt",
          other: "other",
        },
      },
    ],
    img_form: {
      link:
        "https://kenh14cdn.com/thumb_w/620/2020/6/17/photo-1-15923666129962066313198.jpg",
      title: "Thông điệp ý nghĩa về tình yêu với sách",
    },
    code: {
      dataFull: {
        config: {
          default: {
            title: "Code",
            type: "text",
            class: "col-md-12",
            code_form_component: "code",
          },
          cmd: {
            disable: false,
            visible: true,
            error: { message: "", type: "" },
          },
        },
        value: "",
      },
    },
    reference_type: {
      dataFull: {
        config: {
          default: {
            title: "Reference type",
            type: "text",
            class: "col-md-12",
            code_form_component: "reference_type",
          },
          cmd: {
            disable: false,
            visible: true,
            error: { message: "", type: "" },
          },
        },
        data: [
          { title: "Single customer", value: "123", selected: true },
          { title: "Company", value: "1234" },
          { title: "Bussiness", value: "12345" },
        ],
      },
    },
    expireDate: {
      dataFull: {
        config: {
          default: {
            title: "Expire date",
            type: "date",
            class: "col-md-12",
            icon: "",
          },
          cmd: {
            disable: false,
            visible: true,
            error: { message: "", type: "" },
          },
          mode: { textAlign: "right", letterSpacing: "" },
        },
        data: [],
        value: "",
      },
    },
    other: {
      dataFull: {
        config: {
          default: {
            title: "Other",
            type: "text",
            class: "col-md-12",
            code_form_component: "other",
          },
          cmd: {
            disable: false,
            visible: true,
            error: { message: "", type: "" },
          },
        },
        value: "",
      },
    },
    getInfo: {
      dataFull: {
        config: {
          default: {
            title: "Get information",
            type: "default",
            class: "col-sm-2",
          },
        },
      },
    },
    modify: {
      dataFull: {
        config: {
          default: { title: "Modify", type: "default", class: "col-sm-2" },
        },
      },
    },
    saveForm: {
      dataFull: {
        config: {
          default: { title: "Save", type: "submit", class: "col-sm-2" },
        },
      },
    },
  },


<FormMedia {...stateData}
  abs_Search={this.abs_Search} />

abs_Search (e) -> e.target.value la gia tri search