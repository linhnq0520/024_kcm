 getConfigData() {
    return {
      title: "Select the application",
      data: [
        {
          title: "JwebUI",
          img: "https://i.imgur.com/nPCASxM.png",
          title_sub:
            "Lorem Ipsum is simply dummy textof the printing and typesetting industry. ",
          dataItem: { test: "1" },
        },
        {
          title: "System",
          img: "https://i.imgur.com/kkX0w8N.png",
          dataItem: { test: "12" },
        },
        {
          title: "Strong Team",
          img: "https://i.imgur.com/4Srm5iP.png",
          dataItem: { test: "31" },
        },
        {
          title: "Loan System",
          img: "https://i.imgur.com/42cn7nM.png",
          dataItem: { test: "14" },
        },
        {
          title: "O9",
          img: "https://i.imgur.com/ootqGNi.png",
          dataItem: { test: "51" },
        },

        {
          title: "Default",
          img: "https://i.imgur.com/Tdawhxa.png",
          dataItem: { test: "51" },
        },
        {
          title: "E-learning",
          img: "https://i.imgur.com/SYFOIFR.png",
          dataItem: { test: "51" },
        },
      ],
      cmd:{
        isLock:false,
        isLoading:false,
      },
      close_modal: {
        title: "Close",
        abs_Close: this.abs_Close,
      },
      mess_login: {
        title: "Loading Strong Team...", //theo desgin thì có 3 loại title: Loading Strong Team... /Login Succesfully/Login Failed
        type: "fail", // "success" / "fail" / "isLoading"
        app_select_img:"https://i.imgur.com/SYFOIFR.png",
      },
      abs_Click: this.test,
    };
  }
  <UChooseApp dataFull={{ ...this.getConfigData() }}></UChooseApp>