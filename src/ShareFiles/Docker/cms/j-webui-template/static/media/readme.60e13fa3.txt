
onChangeValue = (event, code_form_component) => {
    let newdata = this.state.stateData;
    newdata[code_form_component].dataFull.value = event.target.value;
    this.setState({ stateData: newdata })
  }

  
data:
     stateData: {

        full_name: {
          dataFull: {
            config: {
              default: {
                title: "Full name",
                type: "text",
                class: "col-md-12",
                code_form_component: "full_name"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",
          },
          abs_Change: this.onChangeValue
        },
        status: {
          dataFull: {
            config: {
              default: {
                title: "Status",
                type: "text",
                class: "col-md-12",
                code_form_component: "status"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue
        },
        language_default: {
          dataFull: {
            config: {
              default: {
                title: "Language default",
                type: "text",
                class: "col-md-12",
                code_form_component: "language_default"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            data: [
              { title: "Viet Nam", value: "123", selected: true },
              { title: "New acc", value: "1234" },
              { title: "New aa", value: "12345" },
              { title: "New pub", value: "122" },
            ]
          },
          abs_Change: this.onChangeValueSelect,
          abs_search: this.onSearch
        },
        avatar: {
          dataFull: {
            config: {
              default: {
                title: "Avatar",
                type: "text",
                class: "col-md-12",
                code_form_component: "avatar"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue
        },

        lock_screen_image: {
          dataFull: {
            config: {
              default: {
                title: "Lock screen image",
                type: "text",
                class: "col-md-12",
                code_form_component: "lock_screen_image"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue
        },
        update: {
          dataFull:
          {
            config: {
              default: {
                title: "Update",
                type: "primary",
                class: "col-sm-2"

              },

            },
          },
          abs_Click: this.abs_Click
        },
        current_password: {
          dataFull: {
            config: {
              default: {
                title: "Current password",
                type: "password",
                class: "col-md-12",
                code_form_component: "current_password"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue
        },
        new_password: {
          dataFull: {
            config: {
              default: {
                title: "New password",
                type: "password",
                class: "col-md-12",
                code_form_component: "new_password"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue
        },
        confirm_new_password: {
          dataFull: {
            config: {
              default: {
                title: "Comfirm new password",
                type: "password",
                class: "col-md-12",
                code_form_component: "comfirm_new_password"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.
          },
          abs_Change: this.onChangeValue
        },
        save: {
          dataFull:
          {
            config: {
              default: {
                title: "Save",
                type: "primary",
                class: ""

              },

            },
          },
          abs_Click: this.abs_Click
        },
        clear: {
          dataFull:
          {
            config: {
              default: {
                title: "Clear",
                type: "",
                class: ""

              },

            },
          },
          abs_Click: this.abs_Click
        },
        current_PIN: {
          dataFull: {
            config: {
              default: {
                title: "Current PIN",
                type: "password",
                class: "col-md-12",
                code_form_component: "current_PIN"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.

          },
          abs_Change: this.onChangeValue
        },
        new_PIN: {
          dataFull: {
            config: {
              default: {
                title: "New PIN",
                type: "password",
                class: "col-md-6",
                code_form_component: "new_PIN"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.

          },
          abs_Change: this.onChangeValue
        },
        repeat_PIN: {
          dataFull: {
            config: {
              default: {
                title: "Repeat PIN",
                type: "password",
                class: "col-md-6",
                code_form_component: "repeat_PIN"
              },
              cmd: {
                disable: false,
                visible: true,

                error: {
                  message: "",
                  type: "",
                }
              },


            },
            value: "",                      // nhận vào các kiểu string/number.

          },
          abs_Change: this.onChangeValue
        },

      }