data===>
getConfigData(){
    return {
        data: [
          {
            title: "Tiếng Việt",
            img: "https://i.imgur.com/OKjHV0p.png",
            dataItem: { test: "1" },
            selected:true
          },
          {
            title: "English",
            img: "https://i.imgur.com/KgdR2xr.png",
            dataItem: { test: "12" },
          },
          {
            title: "Thailand",
            img: "https://i.imgur.com/hZbLszK.png",
            dataItem: { test: "31" },
          },
          {
            title: "Campodia",
            img: "https://i.imgur.com/0TPTEXI.png",
            dataItem: { test: "14" },
          },
          {
            title: "Laos",
            img: "https://i.imgur.com/luz6gpT.png",
            dataItem: { test: "51" },
          },
        ],
        abs_Click: this.test,
    }
}
<UChangeLang dataFull={{...this.getConfigData()}}></UChangeLang>