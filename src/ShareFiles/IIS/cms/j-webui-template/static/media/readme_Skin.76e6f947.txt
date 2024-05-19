đây là bản mô tả skin của 1 theme/tempate/component
phải có khi tạo mới, khi end user đổi skin thì các component phải được đổi theo
==================================Thông tin========

=====skin======
dark: Giao diện tối
light: Giao diện sáng

=====device====
desktop: màn hình lớn
tablet: màn hình trung
mobile: màn hình nhỏ

==================================Hàm có trong tất cả theme component==============
request_device là string với tham số thiết bị
changeDevice = (request_device) => {
        //nội dung xử lý do chính theme component xử lý
}