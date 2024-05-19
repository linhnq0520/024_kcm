list màu cơ bản:
  -warning
  -danger
  -success
  -info
data ====>
stateData: {
  form: {
    dataFull: {
      config: {
        default: {
          title: "Job Process", //title của uForm
        },
      },
      cmd: { visibility: "" }, // "none" hoặc "" là ẩn hiện form
    },
  },
  listButton: [
    {
      dataFull: {
        config: {
          default: {
            title: "Start",
            icon: "play_circle_outline",
          },
        },
      },
      abs_Click: this.abs_Click,
    },
    {
      dataFull: {
        config: {
          default: {
            title: "Stop",
            icon: "pause_circle_outline",
          },
        },
      },
      abs_Click: this.abs_Click,
    },
    {
      dataFull: {
        config: {
          default: {
            title: "Refresh",
            icon: "autorenew",
          },
        },
      },
      abs_Click: this.abs_Click,
    },
  ],
  tab: [
    {
      id: "summary",
      title: "Summary",
    },
    {
      id: "stepSummary",
      title: "Step Summary",
    },
    {
      id: "stepDetail",
      title: "Step Details",
    },
    {
      id: "errorDetail",
      title: "Error Details",
    },
  ],
  summary: {
    date_batch: {
      title: 'Batch Date',
      value: '30/04/1975'
    },
    percent: {
      title: 'Progress',
      value: 0
    }
  },
  stepSummary: {
    run_normal: {
      dataFull: {
        isCheck: false,
        dataItem: { },
        abs_Click: this.test,
      },
    },
    number_run: {
      dataFull: {
        isCheck: false,
        dataItem: { test: "xyz" },
        abs_Click: this.test,
      },
    },
    date_time:{
      dataFull:{
                    config: {
                      default: {
                        class: "col-md-3",
                        // required: true, //true/false hiển thị dấu * phân biệt bắt buộc nhập
                        icon: "", //
                      },
                      cmd: {
                        disable: false,
                        visible: true,

                        error: {
                          message: "", //
                          type: "",
                        },
                      },
                      mode: {
                        noTitle: true,
                      },
                    },
                    data: [], // ở uInput không dùng data
                    value: "", // nhận vào các kiểu string/number.
                  }
    }
    table_header: this.getTableHeaderConfigStepSummary(),
    table_data: this.getTableDataStepSummary(),
    table_config: this.getTableConfigStepSummary(),
  },
  stepDetail: {
    table_header: this.getTableHeaderConfigStepDetail(),
    table_data: this.getTableDataStepDetail(),
    table_config: this.getTableConfigStepDetail(),
  }, 
  errorDetail: {
    table_header: this.getTableHeaderConfigErrorDetail(),
    table_data: this.getTableConfigErrorDetail(),
    table_config: this.getTableConfigErrorDetail()
  }
}

getTableHeaderConfigStepSummary() {
  return {
    dataFull: {
      Header: {
        data: [
          {
            title: "Select",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Step Name",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Comment",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Status",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Percent Started",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Status Decs",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Start At",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "End At",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Threads Created",
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Threads Running",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Threads Completed",
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Threads Canceled",
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Threads Failed",
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Total Threads",
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Total Started",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Total Duration",
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Total Remaining",
            config: {
              //nếu có set width thì truyền vào
              width: "",
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
      }
    },
  };
}
getTableConfigStepSummary() {
  return [
    {
      type: "uTableColumnCheckbox",
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "left",
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
      type: "uTableColumnIcon",
    },
    {
      type: "uTableColumnProgressBar",
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "left",
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
      type: "uTableColumnDefault",
      config: {
        mode: "left",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
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
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
  ];
}
getTableDataStepSummary() {
  return {
    data: [
      {
        isCheck: true,
        dataItem: item ,
        abs_Click: this.checkStepHandler, // (dataItem)
      },
      {
        data: 'item.stepname',
      },
      {
        data: 'item.comments',
      },
      {
        //trong trường hợp này data dùng là mảng
        data: [
          {
            val: 'add_circle', //nhận các giá trị url/icon/data
            color: "blue", // gồm: yellow/blue
            title: "warning", // tên icon
            class: "-round",
          },
        ],
      },
      {
        percent: 'item.percentstarted',
      },
      {
        data: 'item.statusdesc',
      },
      {
        data: 'item.startat',
      },
      {
        data: 'item.endat',
      },
      {
        data: 'item.threadscreated',
      },
      {
        data: 'item.threadsrunning',
      },
      {
        data: 'item.threadscompleted',
      },
      {
        data: 'item.threadscanceled',
      },
      {
        data: 'item.threadsfailed',
      },
      {
        data: 'item.totalthreads',
      },
      {
        data: 'item.totalstarted',
      },
      {
        data: 'item.totalduration',
      },
      {
        data: 'item.totalstarted',
      },
    ],
    dataItem: {},
    abs_Click: this.onClickRowTableStepSummary
  };
}

getConfigTableConfigJobProcess() {
  return [
    {
      data:[
      {
        isCheck: item.checked,
        dataItem: { item },
        abs_Click: this.checkDataRightHandler, // (dataItem)
      },
      {
        data: "B_SYS_BOB_EXEC",
      },
      {
        data: "System task before batch processing",
      },
      {
        //trong trường hợp này data dùng là mảng
        data: [
          {
            val: "report_problem", //nhận các giá trị url/icon/data
            color: "yellow", // gồm: yellow/blue
            title: "warning", // tên icon
            class: "-round",
          },
        ],
      },
      {
        percent: 50,
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
      {
        data: "1",
      },
    ],
    dataItem:{abs:"abs"},
    abs_Click:this.click
    }
  ]
}

getTableHeaderConfigStepDetail() {
  return {
    dataFull: {
      Header: {
        data: [
          {
            title: 'languages.job_name',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.step_name',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.status',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.read_count',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.write_count',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.commit_count',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.read_skip_count',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.write_skip_count',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.process_skip_count',
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.rollback_count',
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.exit_code',
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          },
          {
            title: 'languages.exit_message',
            config: {
              //nếu có set width thì truyền vào
              width: "",
              isFrozen: false,
            },
          }
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
      }
    },
  };
}

getTableConfigStepDetail() {
  return [
    {
      type: "uTableColumnDefault",
      config: {
        mode: "left",
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
      type: "uTableColumnDefault",
      config: {
        mode: "left",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "right",
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
      type: "uTableColumnDefault",
      config: {
        mode: "left",
        isFrozen: false,
      },
    },
  ];
}
  
getTableDataStepDetail() {
  return [
      {
        data: 'item.jobname'
      },
      {
        data: 'item.stepname'
      },
      {
        data: 'item.status'
      },
      {
        data: 'item.readcount'
      },
      {
        data: 'item.writecount'
      },
      {
        data: 'item.commitcount'
      },
      {
        data: 'item.readskipcount'
      },
      {
        data: 'item.writeskipcount'
      },
      {
        data: 'item.processskipcount'
      },
      {
        data: 'item.rollbackcount'
      },
      {
        data: 'item.exitcode'
      },
      {
        data: 'item.exitmessage'
      }
    ];
}

getTableHeaderConfigErrorDetail() {
  return {
    dataFull: {
      Header: {
        data: [
          {
            title: "Thread id",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Step name",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Status",
            config: {
              width: "",
              isFrozen: false,
            },
          },
          {
            title: "Status description",
            config: {
              width: "",
              isFrozen: false,
            },
          }
        ]
      },
      config: {
        mode: {
          noHeader: false, //dùng cho trường hợp không sử dụng header
        },
      }
    },
  };
}
getTableConfigErrorDetail() {
  return [
    {
      type: "uTableColumnDefault",
      config: {
        mode: "left",
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
      type: "uTableColumnDefault",
      config: {
        mode: "left",
        isFrozen: false,
      },
    },
    {
      type: "uTableColumnDefault",
      config: {
        mode: "left",
        isFrozen: false,
      },
    }
  ];
}
getTableDataErrorDetail() {
  return [
    {
      data: 'item'
    },
    {
      data: 'item'
    },
    {
      data: 'item'
    },
    {
      data: 'item'
    }
  ]
}

