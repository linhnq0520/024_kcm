<UDate
  dataFull={{
    config: {
      default: {
        type: "number",
        title: "Office", // title của uSelectItem
        class: "col-md-12 malibu-component-max_width", // hiển thị chiều dài của uSelectItem
        required: true, //true/false hiển thị dấu * phân biệt bắt buộc nhập
      },
      cmd: {
        disable: false, //  true/false cho phép người dụng chọn item
        visible: true, // true/false để hiển thị uSelectItem
        isFocus: false,

        error: {
          message: "", // message rỗng sẽ không có thông báo
          type: "", // hiện tại chưa dùng type
        },
       
      isLock: false,
   
      },
      mode: {
        //hiện tại mode chưa có
         
        textAlign: "right",
      },
    },
    value: this.state.value,
   
    calendar_data: {
      value_current: "123", //giá trị ban đầu của data, dùng để sử dụng so sánh khi nhấn ESC
      today: {
        title: "Today",
      },
      config: {
        days_title: [
          //title của các ngày. Phải truyền đủ 7 ngày.
          { title: "SUN", type: "gray" },
          { title: "MON", type: "gray" },
          { title: "MON", type: "gray" },
          { title: "MON", type: "gray" },
          { title: "MON", type: "gray" },
          { title: "MON", type: "gray" },
          { title: "SAT", type: "gray" },
        ],
      },
      list_months: [
        //danh sách các tháng, phải truyền đủ 12 tháng
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
        {
          title: "September",
          selected: true,
        },
        {
          title: "September",
        },
        {
          title: "September",
        },
      ],
      list_years: {
        value: 2020,
        data: [
          2011,
          2012,
          2013,
          2014,
          2015,
          2016,
          2017,
          2018,
          2019,
          2020,
          2021,
          2022,
          2023,
          2024,
          2025,
        ],
      },
      list_days: [
        { title: "30", type: "gray" }, //type có 4 giá trị: gray: ngày của tháng khác (tháng trước hoặc tháng sau)/ "": ngày bình thường / "primary": ngày đang được chọn / "inverse": ngày hôm nay.
        { title: "31", type: "gray" },
        { title: "1" },
        { title: "2" },
        { title: "3" },
        { title: "4" },
        { title: "5" },
        { title: "6" },

        { title: "7", type: "primary" },
        { title: "8" , type:"inverse"},
        { title: "9" },
        { title: "10" },
        { title: "11" },
        { title: "12" },
        { title: "13", isDisable: true }, //isDisable là ngày không được chọn
        { title: "14" },
        { title: "15" },
        { title: "16", isDisable: true },

        { title: "17", isDisable: true },
        { title: "18", isDisable: true },
        { title: "19" },
        { title: "20", isDisable: true },
        { title: "21" },
        { title: "22" },
        { title: "23" },
        { title: "24" },
        { title: "25" },
        { title: "26" },

        { title: "27" },
        { title: "28" },
        { title: "29" },
        { title: "30" },
        { title: "1", type: "gray" },
        { title: "2", type: "gray" },
        { title: "3", type: "gray" },
      ],

      
    },
    abs_calendar_changeMonth: this.abs_calendar_changeMonth,
      abs_calendar_submit: this.abs_calendar_submit,
      abs_calendar_chooseYear: this.abs_calendar_chooseYear,
      abs_calendar_changeYear: this.abs_calendar_changeYear,
      abs_calendar_chooseMonth: this.abs_calendar_chooseMonth,
      abs_calendar_openCalendar: this.abs_calendar_openCalendar,
      abs_calendar_changeDay: this.abs_calendar_changeDay,
      abs_calendar_reset: this.abs_calendar_reset,
      abs_calendar_today: this.abs_calendar_today,
  }}
  //abs_Change={this.testInput}
></UDate>;
//hàm được gọi khi click vào button next/ preview
//trả về 1 nếu chọn next -> tăng tháng.
// trả về -1 nếu chọn preview -> giảm tháng.
abs_calendar_changeMonth = (index) => {
  console.log(index);
  let new_Data = this.state.list_days;
  new_Data[4].type = "primary";
  this.setState({ list_days: new_Data });
};
//hàm trả về khi chọn ngày
// khi set value nhớ set lại value_current=value
abs_calendar_submit = (index) => {
  console.log("submit");
};
//hàm trả về khi chọn năm
//trả về giá trị của năm được chọn
abs_calendar_chooseYear = (year) => {
  console.log(year);
};
//hàm trả về khi gõ năm - riêng năm được nhập tay vào
//trả về giá trị của năm được chọn
abs_calendar_changeYear = (e) => {
  console.log(e.target.value);
};
//hàm trả về khi chọn tháng
// trả về index của tháng trong mảng
abs_calendar_chooseMonth = (index) => {
  console.log(index);
};
//hàm gọi để mở calendar
//set dữ liệu ngày vào theo value
//mảng list_days phải truyền đủ 35 ngày
//ngày được chọn theo value phải đổi type sang "primary"
//mảng  list_months phải truyền đủ 12 tháng, tháng được chọn phải set selected=true
//list_years phải set value là năm được chọn
abs_calendar_openCalendar = () => {
  console.log("open");
};
//hàm trả về khi người dùng dùng phím để chọn ngày
//set lại value là ngày được chọn, NHƯNG không set lại value_current
//đây là hàm chạy khi người dùng vọc dữ liệu, khi ấn ESC dữ liệu sẽ quay về giá trị trước đó
//chỉ khi hàm submit được chạy thì value mới được cho là được chọn.
abs_calendar_changeDay = (index) => {
  let new_Data = this.state.list_days;
  new_Data.map((item, index) => (item.type = ""));
  new_Data[index].type = "primary";
  this.setState({ list_days: new_Data });
};
//hàm trả về khi người dùng đang vọc dữ liệu bằng phím và ấn ESC
//reset lại value thành value_current
abs_calendar_reset = () => {
  this.setState({ value: "123" });
};

//hàm được trả về khi click vào phím today.
// set lại value là ngày hiện tại.
abs_calendar_today=()=>{

}


/*========================*/