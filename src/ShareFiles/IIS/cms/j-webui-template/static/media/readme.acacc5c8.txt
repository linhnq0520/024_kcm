 getConfig() {
    return {
      //địa chỉ hình ảnh logo
      img_logo: {
        value: "https://i.imgur.com/9rLBj8c.png",
        hyper_link: "",
      },
      title: "Sign In",                                                             
      title_sub: "Sign in to your account",
      email: {
        title: "Email",
        placeholder: "Enter your email address",
        value:"",
        cmd:{
          error:{
            message:"",
          }
        },
        dataItem:{abs:"abs"},
        abs_Change:this.abs_Change                                                  // trả về (event, dataItem) -> yêu cầu set lại value
      },
      password: {
        title: "Password",
        placeholder: "Enter your password",
         value:"",
         dataItem:{abs:"abs"},
           cmd:{
          error:{
            message:"",
          }
        },
        abs_Change:this.abs_Change                                                   // trả về (event, dataItem) -> yêu cầu set lại value
      },
      button_submit: {
        dataFull: {
          config: {
            default: {
              title: "Sign In",
              type: "primary",
              class: "col-12",
            },
          },
        },
        abs_Click: this.onSubmit,
      },
      lang: {
        data: [
          {
            title: "English",
            selected: true,
            img: "https://i.imgur.com/KgdR2xr.png",
            dataItem: { aaa: "aaa" },
          },
          {
            title: "Tiếng Việt",
            img: "https://i.imgur.com/OKjHV0p.png",
            dataItem: { aaa: "aaa" },
          },
          {
            title: "Thailand",
            img: "https://i.imgur.com/hZbLszK.png",
            dataItem: { aaa: "aaa" },
          },
          {
            title: "Campodia",
            img: "https://i.imgur.com/0TPTEXI.png",
            dataItem: { aaa: "aaa" },
          },
          {
            title: "Laos",
            img: "https://i.imgur.com/luz6gpT.png",
            dataItem: { aaa: "aaa" },
          },
        ],
        abs_Click: this.test,                                                               // trả về (dataItem, item) -> yêu cầu set selected của item được chọn là true, những item còn lại là false 
      },
      app_choose: {
        isChoose: true,                                                                     //truyền true sẽ xuất hiện, false thì không xuất hiện
        img: "apps",
        title: "jwebui",
        dataItem: { abc: "abc" },
        abs_Close: this.Close,
      },
    };
  }
  <ULogin dataFull={this.state.stateData}></ULogin>