<ModalConfirm
              stateData={{
                form: {
                  title: "This action cannot be undone.",
                  title_sub:
                    "Enter “yes” to confirm that you want to permanently delete it.",
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
                            title: "delete", // title của button
                            type: "danger", // nhận 2 dạng type là "" -> default- có background trắng và "primary" -> có background xanh
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
                  input_confirm: {
                    value: "",
                    placeholder: "Type “yes”",
                    abs_Change: this.abs_Change,
                  },
                },

                modal: {
                  title: "Delete item",
                  abs_Close: this.abs_Close,
                  visibility: this.state.visibility,
                },
              }}
            ></ModalConfirm>