stateData:{
          valueModal: {
          dataFull: {
            data: [
              {
                key: "Customer Code",
                value: "0002001999",
              },
              {
                key: "Full Name",
                value: "YEN",
              },
              {
                key: "DOB",
                value: "01/01/1970",
              },
              {
                key: "Address",
                value:
                  "http://localhost:3333/fwcss?isFwCss=true&template=malibu&screen_working=test",
              },
              {
                key: "Identification",
                value: "123456789",
              },
            ],
          },
        },
        img_form:{
          link: "https://kenh14cdn.com/thumb_w/620/2020/6/17/photo-1-15923666129962066313198.jpg",
          title:"Thông điệp ý nghĩa về tình yêu với sách"
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

                error: {
                  message: "",
                  type: "",
                },
              },
            },
            value: "", // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue,
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

                error: {
                  message: "",
                  type: "",
                },
              },
            },
            data: [
              { title: "Single customer", value: "123", selected: true },
              { title: "Company", value: "1234" },
              { title: "Bussiness", value: "12345" },
            ],
          },
          abs_Change: this.onChangeValueSelect,
          abs_search: this.onSearch,
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
            value: "",
          },
          abs_Click: this.abs_Click,
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

                error: {
                  message: "",
                  type: "",
                },
              },
            },
            value: "", // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue,
        },

}