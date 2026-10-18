1. HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY
- Yêu cầu môi trường: Visual Studio 2022 hoặc .NET SDK (>= .NET 8 / .NET 9).
- Mở bằng Visual Studio:
  + Mở file solution: IT3212_Labs.sln
  + Nhấn F5 hoặc Ctrl+F5 để build và chạy ứng dụng Console.
- Chạy bằng dòng lệnh (CLI):
  + Di chuyển vào thư mục lab3:
      cd lab3
  + Chạy lệnh:
      dotnet run --project lab3/Lab03_OOPAdvanced.csproj

2. CẤU TRÚC VÀ TỔ CHỨC MÃ NGUỒN OOP
Toàn bộ mã nguồn được thiết kế chuẩn theo các nguyên lý hướng đối tượng nâng cao (Kế thừa, Đa hình, Lớp trừu tượng, Interface):
- Solution: IT3212_Labs.sln
- Project: lab3/Lab03_OOPAdvanced.csproj
- Interfaces.cs: Chứa các hợp đồng giao tiếp chuẩn IValidatable, IPrintable, IExportable.
- Nguoi.cs: Lớp cơ sở (base class) chứa HoTen, NgaySinh, phương thức ảo MoTa() và TinhTuoi().
- SinhVien.cs: Lớp kế thừa từ Nguoi, thực thi IValidatable, IPrintable, IExportable; cùng các lớp dẫn xuất SinhVienDaiTra, SinhVienChatLuongCao, SinhVienQuocTe.
- NguoiHoc.cs: Lớp trừu tượng NguoiHoc định nghĩa phương thức abstract TinhHocPhi(), được cài đặt bởi SinhVienChinhQuy và SinhVienLienThong.
- NhanVien.cs: Lớp trừu tượng NhanVien định nghĩa TinhLuong(), cài đặt bởi NhanVienVanPhong, NhanVienKinhDoanh, GiangVien.
- PhuongTien.cs: Interface IMove và lớp trừu tượng PhuongTien, cài đặt đa hình bởi XeMay, OTo, XeDap (tính chi phí xăng/vận hành, mô phỏng tăng tốc, phanh).
- TaiLieu.cs: Lớp trừu tượng TaiLieu quản lý thư viện, cài đặt bởi Sach, TapChi, LuanVan; tìm kiếm theo loại tài liệu.
- Payment.cs: Interface IPayment đa hình quản lý quy trình giao dịch thanh toán Tiền mặt (ThanhToanTienMat), Chuyển khoản (ChuyenKhoan), Ví điện tử (ViDienTu).
- Program.cs: Menu tương tác Console đầy đủ cho 10 bài tập.

3. DANH SÁCH BÀI TẬP ĐÃ HOÀN THÀNH
* PHẦN 1: BÀI TẬP CÓ HƯỚNG DẪN (1 - 5)
- Bài 1: Kế thừa Nguoi - SinhVien, gọi constructor lớp cha qua từ khóa base, chia sẻ thuộc tính HoTen, NgaySinh.
- Bài 2: Ghi đè phương thức hiển thị MoTa() (virtual ở Nguoi, override ở SinhVien và gọi base.MoTa()).
- Bài 3: Lớp trừu tượng NguoiHoc với phương thức abstract TinhHocPhi(), tính học phí riêng cho SinhVienChinhQuy (450.000đ/tín chỉ) và SinhVienLienThong (520.000đ/tín chỉ).
- Bài 4: Cài đặt và kiểm tra 2 interface IValidatable (kiểm tra tính hợp lệ dữ liệu) và IPrintable (định dạng hiển thị).
- Bài 5: Danh sách đa hình List<NguoiHoc> chứa các loại sinh viên khác nhau, gọi TinhHocPhi() qua con trỏ lớp cha và tính tổng học phí.

* PHẦN 2: BÀI TẬP TỰ THỰC HIỆN (6 - 10)
- Bài 6: Hệ thống nhân viên và tính lương đa hình (NhanVienVanPhong theo ngày công + phụ cấp, NhanVienKinhDoanh theo doanh số hoa hồng, GiangVien theo số tiết dạy).
- Bài 7: Interface IMove và các lớp phương tiện XeMay, OTo, XeDap mô phỏng tốc độ, tăng tốc, dừng xe và tính chi phí vận hành theo km.
- Bài 8: Quản lý tài liệu thư viện (Sach, TapChi, LuanVan), hiển thị và tìm kiếm phân loại tài liệu.
- Bài 9: Hệ thống thanh toán đa hình IPayment cho ThanhToanTienMat (kiểm tra tiền đưa, tính tiền thừa), ChuyenKhoan (kiểm tra STK nguồn/đích, ngân hàng), ViDienTu (kiểm tra số dư ví Momo).
- Bài 10: Nâng cấp ứng dụng quản lý sinh viên đa hình (Đại trà, Chất lượng cao, Quốc tế), thống kê theo loại/học lực, và xuất dữ liệu ra file CSV/JSON qua interface IExportable.

4. DỮ LIỆU KIỂM THỬ MẪU (TEST CASES)
- Thông tin sinh viên mẫu: Phan Văn Thắng - 24002545 - 26/03/2006.
- Bài 1: Sinh viên SV01 - Phan Văn Thắng - 26/03/2006 -> Tuổi: 20, Điểm TB: 8.80.
- Bài 2: Ghi đè MoTa() gọi base.MoTa() cho kết quả chuỗi hoàn chỉnh.
- Bài 3: SV Chính quy 18 tín chỉ = 8.100.000 VNĐ; SV Liên thông 15 tín chỉ = 7.800.000 VNĐ.
- Bài 4: Kiểm tra nhập điểm 15 -> IValidatable báo lỗi "Điểm sai"; nhập mã trống -> báo "Thiếu mã".
- Bài 5: Danh sách 4 sinh viên đa hình tính ra tổng học phí chính xác.
- Bài 6: Bảng lương đa hình tính lương nhân viên văn phòng, kinh doanh và giảng viên chính xác từng loại.
- Bài 7: Tính chi phí vận hành 50km cho Xe máy (~26.400đ), Ô tô (~127.000đ), Xe đạp (~7.500đ).
- Bài 8: Tìm kiếm lọc theo "Sách", "Tạp chí", "Luận văn" hiển thị đúng nhóm tài liệu.
- Bài 9: Giao dịch thanh toán tiền mặt 350.000đ đưa 500.000đ -> thối lại 150.000đ; chuyển khoản ngân hàng và ví Momo in biên lai chuẩn.
- Bài 10: Quản lý nhiều loại sinh viên, thống kê nhóm và xuất thành công ra file `DanhSachSinhVien.csv` và `DanhSachSinhVien.json`.
