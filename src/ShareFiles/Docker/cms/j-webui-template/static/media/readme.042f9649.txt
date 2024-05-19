Flow BO properties;

VD: <FlowBO stateData={{}} />
trong đó, 
	1.formTabs là array chứa thông tin của từng tab, bao gồm 
		- tabInfo: cấu hình formTab
		- style: đang chọn hay không?, 
		- components: danh sách config của các component trong tab, bản thân 
		các component sẽ có event handler, cần định nghĩa các hàm để xử lí chúng
	2. boTable: config của bảng danh sách flow BO,
	3. saveButton: config button Save
Mẫu stateData của FlowBO:

stateData = {
	formTabs: {
		data: [ 
			{
				tabInfo: {
					title: 'info', //tên tab
					id: 'info' //id tab
				},
				sysStyle: {
					show: 'show'// 2 giá trị, 'show': tab được chọn, '' 
				},
				components: { //danh sách config component trong tab
					txcode: { // mã component
						dataFull: {
							config: {
								default: {
									title: "txCode", 
									type: "text", 
									class: "col-sm-4",
									code_form_component: "txcode",
									required: false, 
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
									textAlign: "right", // giá trị nhận vào là right/left- không nhập gì định dạng là left.
									letterSpacing: "", //giá trị nhận vào "" -> default, không có khoảng cách, và 3 sizes:
									// "S": 1px, "M": 2px, "L": 4px
								},
							},
							data: [], // ở uInput không dùng data
							value: "", // nhận vào các kiểu string/number.
						},
						abs_Change: this.changeInputHandler, 
						// tham số callback: (e, componentCode), trong đó e -> event của component, get được value từ đây, 
						// componentCode -> dataFull.config.default.code_form_component
					},
					txname: {
						dataFull: {
							config: {
								default: {
									title: "txName",
									type: "text", //các loại type nhận vào password/text/number
									class: "col-sm-4",
									code_form_component: "txname",
									required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
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
									textAlign: "right", // giá trị nhận vào là right/left- không nhập gì định dạng là left.
									letterSpacing: "", //giá trị nhận vào "" -> default, không có khoảng cách, và 3 sizes:
									// "S": 1px, "M": 2px, "L": 4px
								},
							},
							data: [], // ở uInput không dùng data
							value: "", // nhận vào các kiểu string/number.
						},
						abs_Change: this.changeInputHandler,
					},
					version: {
						dataFull: {
							config: {
								default: {
									title: "Version",
									type: "text", //các loại type nhận vào password/text/number
									class: "col-sm-4",
									code_form_component: "version",
									required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
								},
								cmd: {
									disable: true,
									visible: true,
									error: {
										message: "",
										type: "",
									},
								},
								mode: {
									textAlign: "right", // giá trị nhận vào là right/left- không nhập gì định dạng là left.
									letterSpacing: "", //giá trị nhận vào "" -> default, không có khoảng cách, và 3 sizes:
									// "S": 1px, "M": 2px, "L": 4px
								},
							},
							data: [], // ở uInput không dùng data
							value: "", // nhận vào các kiểu string/number.
						},
						abs_Change: this.changeInputHandler,
					},
					txtype: {
						dataFull: {
							config: {
								default: {
									title: "txType",
									type: "", // uSelectItem không dùng type,
									class: "col-sm-4",
									code_form_component: "txtype",
									required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
								},
								cmd: {
									disable: false,
									visible: true,
									error: {
										message: "", // message rỗng sẽ không có thông báo
										type: "",
									},
								},
								mode: {},
							},
							data: [
								{ title: "bo", value: "123", selected: true },
								{ title: "system", value: "1234" },
							],
							value: "",
						},
						abs_Change: this.changeSelectHandler,
						// callback select item của dropdown, nhận tham số (value, index, componentCode)
					},
					status: {
						dataFull: {
							config: {
								default: {
									title: "Status",
									type: "", // uSelectItem không dùng type,
									class: "col-sm-4",
									code_form_component: "status",
									required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
								},
								cmd: {
									disable: false,
									visible: true,
									error: {
										message: "", // message rỗng sẽ không có thông báo
										type: "",
									},
								},
								mode: {},
							},
							data: [
								{ title: "Active", value: "A", selected: true },
								{ title: "Inactive", value: "I" },
							],
							value: "",
						},
						abs_Change: this.changeSelectHandler,
					},
					hasRole: {
						dataFull: {
							config: {
								default: {
									title: "Role",
									type: "", // uSelectItem không dùng type,
									class: "col-sm-4",
									code_form_component: "hasRole",
									required: false, //true/false hiển thị dấu * phân biệt bắt buộc nhập
								},
								cmd: {
									disable: false,
									visible: true,
									error: {
										message: "", // message rỗng sẽ không có thông báo
										type: "",
									},
								},
								mode: {},
							},
							data: [
								{ title: "No", value: "123", selected: true },
								{ title: "Yes", value: "1234" },
							],
							value: "",
						},
						abs_Change: this.changeSelectHandler,
					},
				}
			},
			{
				tabInfo: {
					title: "input",
					id: "input",
				},
				sysStyle: {
					show: "",
				},
				components: {
					input: {
						dataFull: {
							config: {
								default: {
									title: "",
									class: "col-md-12",
									code_form_component: "input",
									rows: 10,
									required: false,
								},
								error: {
									message: "",
									type: "",
								},
								cmd: {
									disable: false,
									visible: true,
								},
								mode: {},
							},
							data: [],
							value: "{}",
						},
						abs_Change: this.changeTextAreaHandler,
					},
				},
			},
			{
				tabInfo: {
					title: "actions",
					id: "actions",
				},
				sysStyle: {
					show: "",
				},
				components: {
					actions: {
						dataFull: {
							config: {
								default: {
									title: "",
									class: "col-sm-12",
									rows: 10,
									code_form_component: "actions",
									required: false,
								},
								error: {
									message: "",
									type: "",
								},
								cmd: {
									disable: false,
									visible: true,
								},
								mode: {},
							},
							data: [],
							value: `[{
									"name": ""
								}]`,
						},
						abs_Change: this.changeTextAreaHandler,
					},
				},
			},
			{
				tabInfo: {
					title: "response",
					id: "response",
				},
				sysStyle: {
					show: "",
				},
				components: {
					response: {
						dataFull: {
							config: {
								default: {
									title: "",
									class: "col-md-12",
									rows: 10,
									code_form_component: "response",
									required: false,
								},
								error: {
									message: "",
									type: "",
								},
								cmd: {
									disable: false,
									visible: true,
								},
								mode: {},
							},
							data: [],
							value: `{
									"bo": [
										{
											"txcode": "",
											"input": {}
										}
									]
								}`,
						},
						abs_Change: this.changeTextAreaHandler,
					},
				},
			},
		],
		abs_Change: this.changeTabHandler
	},
	boTable: {
		Header: {
			data: [
				{
					title: "No.",
					id: "order",
					config: {
					width: "20px",
					},
				},{
					title: "txCode",
					id: "txcode",
					config: {
					width: "",
					},
				},{
					title: "txName",
					id: "txname",
					config: {
					width: "",
					},
				},{
					title: "Status",
					id: "status",
					config: {
					width: "",
					},
				},{
					title: "txType",
					id: "txtype",
					config: {
					width: "",
					},
				},{
					title: "Version",
					id: "version",
					config: {
					width: "",
					},
				},{
					title: "Update time",
					id: "updateTime",
					config: {
					width: "",
					},
				},{
					title: "",
					id: "button", // id bắt buộc là button, bên kia xử lí trường này
					config: {
					width: "",
					},
				}
			],
			config: {
				mode: {
					hasSearch: false
				}
			}
		},
		config: {
			mode: '',
			noHeader: false
		},
		data: //data hiển thị lên table, có dạng json, key: id của header khai báo ở trên, value: value hiển thị
		[{
			order: 1,
			txCode: "DPT_CDP",
			txName: "Cash deposit",
			status: "A",
			txType: "AA",
			version: 1,
			updateTime: "20200"
		}],
		button: {
			config: {
				title: 'View',
				icon: 'visibility'
			},
			abs_Click: this.clickViewButtonHandler
			//click view button handler, callback xử lí click nút view, 
			//nhận tham số (rowData), rowData là data từng dòng của nút View
		},
		uPagination: {
        result_total: 5,
        paging_record: [
          {
            number: 5,
            selected: true,
          },
        ],
      },
	},
	saveButton: {
		dataFull: {
			config: {
				default: {
					title: "Save Flow Server",
					type: "primary", // nhận 2 dạng type là "" -> default- có background trắng và "primary" -> có background xanh
					class: "", // độ dài mặc định của uButton là "161px" với button không icon & "96px" với button có icon, nếu muốn thay đổi độ dài thì set .col-* vào class
				},
			},
		},
		abs_Click: this.clickButtonHandler,
		//click handler của component button, có tham số(e, data)
	}
}