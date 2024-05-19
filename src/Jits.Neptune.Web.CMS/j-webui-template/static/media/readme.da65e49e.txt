//Cấu trúc node cây
{
        title: "...",
        parent_id: "...",
        is_open: false,
        DOM_elm: null,
        id: "...",
        dataItem: {
            test:"Đây là data"
        },
        abs_click: this.abs_select_item_menu,
}
getConfigTemplate() {
    return {
          tree_data: [
            {
              title: "Lá số 1",
              parent_id: "0",
              is_open: false,
              DOM_elm: null,
              id: "1",
              dataItem: {
                test: "Đây là data",
              },
              abs_click: this.abs_select_item_menu,
            },
            {
              title: "Lá số 2",
              parent_id: "1",
              is_open: false,
              DOM_elm: null,
              id: "2",
              dataItem: {
                test: "Đây là data",
              },
              abs_click: this.abs_select_item_menu,
            },
            {
              title: "Lá số 2.2",
              parent_id: "1",
              is_open: false,
              DOM_elm: null,
              id: "2.2",
              dataItem: {
                test: "Đây là data",
              },
              abs_click: this.abs_select_item_menu,
            },
            {
              title: "Lá số 3",
              parent_id: "3",
              is_open: false,
              DOM_elm: null,
              id: "3",
              dataItem: {
                test: "Đây là data",
              },
              abs_click: this.abs_select_item_menu,
            },
          ],
          config: { 
              open_one: true, //cho phép mở một hoặc nhiều
              is_has_dom: false //Có DOM hoặc không
            }, 
        };
  }

abs_select_item_menu =(e , data_item)=>{
    console.log(data_item)
}

<UTreeItem dataFull={this.props.stateData?.listTreeItem}></UTreeItem>