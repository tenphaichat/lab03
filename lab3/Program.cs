using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab03_OOPAdvanced
{
    class Program
    {
        // Danh sách sinh viên dùng chung cho toàn bộ chương trình (kế thừa SinhVien, đa hình nhiều loại)
        static List<SinhVien> danhSachSinhVien = new List<SinhVien>()
        {
            new SinhVienDaiTra("SV01", "Phan Văn Thắng", new DateTime(2006, 3, 26), 8.8, "Công nghệ phần mềm"),
            new SinhVienChatLuongCao("SV02", "Trần Thị Bình", new DateTime(2004, 9, 3), 7.9, 7.5),
            new SinhVienQuocTe("SV03", "John Smith", new DateTime(2003, 5, 12), 8.2, "Hoa Kỳ"),
            new SinhVienDaiTra("SV04", "Lê Hoàng Cường", new DateTime(2005, 1, 20), 9.4, "Hệ thống thông tin"),
            new SinhVienChatLuongCao("SV05", "Phạm Minh Đức", new DateTime(2004, 11, 15), 5.5, 6.0),
            new SinhVienDaiTra("SV06", "Hoàng Ngọc Ánh", new DateTime(2005, 7, 8), 6.8, "An toàn thông tin")
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int chon = -1;
            while (chon != 0)
            {
                Console.WriteLine("\nCHƯƠNG TRÌNH THỰC HÀNH LAB 3");
                Console.WriteLine("1. Kế thừa Nguoi - SinhVien (sử dụng từ khóa base)");
                Console.WriteLine("2. Ghi đè phương thức hiển thị (virtual / override)");
                Console.WriteLine("3. Lớp trừu tượng NguoiHoc và tính học phí (abstract)");
                Console.WriteLine("4. Interface kiểm tra dữ liệu và in (IValidatable, IPrintable)");
                Console.WriteLine("5. Danh sách đa hình List<NguoiHoc> và tính tổng học phí");
                Console.WriteLine("6. Hệ thống nhân viên và tính lương đa hình (NhanVien)");
                Console.WriteLine("7. Quản lý phương tiện và chi phí vận hành (interface IMove)");
                Console.WriteLine("8. Quản lý tài liệu thư viện (Sach, TapChi, LuanVan)");
                Console.WriteLine("9. Hệ thống thanh toán đa hình (interface IPayment)");
                Console.WriteLine("10. Ứng dụng quản lý sinh viên Console nâng cao (CRUD, xuất file)");
                Console.WriteLine("0. Thoát");
                Console.Write("Mời bạn chọn bài (0-10): ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui lòng nhập số từ 0 đến 10!");
                    continue;
                }

                Console.WriteLine();
                switch (chon)
                {
                    case 1:
                        Bai1();
                        break;
                    case 2:
                        Bai2();
                        break;
                    case 3:
                        Bai3();
                        break;
                    case 4:
                        Bai4();
                        break;
                    case 5:
                        Bai5();
                        break;
                    case 6:
                        Bai6();
                        break;
                    case 7:
                        Bai7();
                        break;
                    case 8:
                        Bai8();
                        break;
                    case 9:
                        Bai9();
                        break;
                    case 10:
                        Bai10();
                        break;
                    case 0:
                        Console.WriteLine("Đã thoát chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }

                if (chon != 0)
                {
                    Console.WriteLine("\nẤn Enter để tiếp tục...");
                    Console.ReadLine();
                }
            }
        }

        // =====================================================================
        // BÀI 1: KẾ THỪA NGUOI - SINHVIEN
        // =====================================================================
        static void Bai1()
        {
            Console.WriteLine("Bài 1: Kế thừa Nguoi - SinhVien (sử dụng base)");
            try
            {
                Console.Write("Nhập mã sinh viên: ");
                string? ma = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ma)) ma = "SV01";

                Console.Write("Nhập họ và tên: ");
                string? ten = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ten)) ten = "Phan Văn Thắng";

                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                string? nsStr = Console.ReadLine();
                DateTime ns = string.IsNullOrWhiteSpace(nsStr) ? new DateTime(2006, 3, 26) : DateTime.ParseExact(nsStr, "dd/MM/yyyy", null);

                Console.Write("Nhập điểm trung bình (0 - 10): ");
                string? dStr = Console.ReadLine();
                double diem = string.IsNullOrWhiteSpace(dStr) ? 8.8 : double.Parse(dStr);

                // Khởi tạo đối tượng SinhVien kế thừa Nguoi, gọi base(ten, ns)
                SinhVien sv = new SinhVien(ma, ten, ns, diem);

                Console.WriteLine("\nKết quả tạo đối tượng:");
                Console.WriteLine("- Thuộc tính từ lớp cha Nguoi: Họ tên = {0}, Ngày sinh = {1:dd/MM/yyyy}", sv.HoTen, sv.NgaySinh);
                Console.WriteLine("- Thuộc tính riêng của SinhVien: Mã SV = {0}, Điểm TB = {1:N2}", sv.MaSV, sv.DiemTB);
                Console.WriteLine("- Tuổi tính từ phương thức lớp cha Nguoi: {0} tuổi", sv.TinhTuoi());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        // =====================================================================
        // BÀI 2: GHI ĐÈ PHƯƠNG THỨC HIỂN THỊ (VIRTUAL / OVERRIDE)
        // =====================================================================
        static void Bai2()
        {
            Console.WriteLine("Bài 2: Ghi đè phương thức hiển thị MoTa() (virtual/override)");

            Nguoi nguoi = new Nguoi("Nguyễn Văn An", new DateTime(1995, 5, 10));
            Console.WriteLine("1. Gọi MoTa() từ đối tượng Nguoi:");
            Console.WriteLine("   " + nguoi.MoTa());

            Console.WriteLine("\n2. Nhập thông tin sinh viên để kiểm tra ghi đè MoTa():");
            Console.Write("Nhập mã SV: ");
            string? ma = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ma)) ma = "SV02";

            Console.Write("Nhập họ tên: ");
            string? ten = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ten)) ten = "Phan Văn Thắng";

            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            string? nsStr = Console.ReadLine();
            DateTime ns = string.IsNullOrWhiteSpace(nsStr) ? new DateTime(2006, 3, 26) : DateTime.ParseExact(nsStr, "dd/MM/yyyy", null);

            Console.Write("Nhập điểm TB: ");
            string? dStr = Console.ReadLine();
            double diem = string.IsNullOrWhiteSpace(dStr) ? 8.5 : double.Parse(dStr);

            SinhVien sv = new SinhVien(ma, ten, ns, diem);
            Console.WriteLine("\n3. Gọi MoTa() từ đối tượng SinhVien (đã override và gọi base.MoTa()):");
            Console.WriteLine("   " + sv.MoTa());

            Console.WriteLine("\n4. Đa hình qua con trỏ lớp cha Nguoi:");
            Nguoi p = sv;
            Console.WriteLine("   Con trỏ Nguoi trỏ đến SinhVien: " + p.MoTa());
        }

        // =====================================================================
        // BÀI 3: LỚP TRỪU TƯỢNG HOCPHI
        // =====================================================================
        static void Bai3()
        {
            Console.WriteLine("Bài 3: Lớp trừu tượng NguoiHoc và phương thức trừu tượng TinhHocPhi()");
            try
            {
                Console.WriteLine("--- 1. Sinh viên Chính quy (Đơn giá: 450.000 VNĐ/tín chỉ) ---");
                Console.Write("Nhập họ tên: ");
                string? tenCQ = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tenCQ)) tenCQ = "Phan Văn Thắng";

                Console.Write("Nhập số tín chỉ đăng ký: ");
                string? tcCQStr = Console.ReadLine();
                int tcCQ = string.IsNullOrWhiteSpace(tcCQStr) ? 18 : int.Parse(tcCQStr);

                SinhVienChinhQuy svCQ = new SinhVienChinhQuy(tenCQ, tcCQ);
                Console.WriteLine("Kết quả: Học phí = {0:N0} VNĐ", svCQ.TinhHocPhi());

                Console.WriteLine("\n--- 2. Sinh viên Liên thông (Đơn giá: 520.000 VNĐ/tín chỉ) ---");
                Console.Write("Nhập họ tên: ");
                string? tenLT = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tenLT)) tenLT = "Trần Thị Bình";

                Console.Write("Nhập số tín chỉ đăng ký: ");
                string? tcLTStr = Console.ReadLine();
                int tcLT = string.IsNullOrWhiteSpace(tcLTStr) ? 15 : int.Parse(tcLTStr);

                SinhVienLienThong svLT = new SinhVienLienThong(tenLT, tcLT);
                Console.WriteLine("Kết quả: Học phí = {0:N0} VNĐ", svLT.TinhHocPhi());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        // =====================================================================
        // BÀI 4: INTERFACE KIỂM TRA VÀ IN DỮ LIỆU
        // =====================================================================
        static void Bai4()
        {
            Console.WriteLine("Bài 4: Interface kiểm tra và in dữ liệu (IValidatable, IPrintable)");

            Console.WriteLine("Nhập thông tin sinh viên để kiểm tra tính hợp lệ qua interface:");
            Console.Write("Nhập mã SV (thử để trống): ");
            string? ma = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            string? ten = Console.ReadLine();

            Console.Write("Nhập điểm TB (thử nhập ngoài [0, 10], ví dụ 15): ");
            string? dStr = Console.ReadLine();
            double.TryParse(dStr, out double diem);

            SinhVien sv = new SinhVien(ma ?? "", ten ?? "", DateTime.Now, diem);

            // Kiểm tra qua interface IValidatable
            IValidatable validator = sv;
            bool hopLe = validator.IsValid(out string msg);

            Console.WriteLine("\nKết quả kiểm tra dữ liệu qua IValidatable:");
            if (hopLe)
            {
                Console.WriteLine("-> Dữ liệu HỢP LỆ!");
            }
            else
            {
                Console.WriteLine("-> Dữ liệu KHÔNG HỢP LỆ! Nguyên nhân: " + msg);
            }

            // In dữ liệu qua interface IPrintable
            IPrintable printable = sv;
            Console.WriteLine("Định dạng hiển thị qua IPrintable: " + printable.ToDisplayText());
        }

        // =====================================================================
        // BÀI 5: DANH SÁCH ĐA HÌNH
        // =====================================================================
        static void Bai5()
        {
            Console.WriteLine("Bài 5: Danh sách đa hình List<NguoiHoc> và tính tổng học phí");

            List<NguoiHoc> ds = new List<NguoiHoc>()
            {
                new SinhVienChinhQuy("Phan Văn Thắng", 20),
                new SinhVienChinhQuy("Nguyễn Thu Trang", 18),
                new SinhVienLienThong("Trần Thị Bình", 15),
                new SinhVienLienThong("Lê Hoàng Cường", 16)
            };

            Console.WriteLine("Bảng tính học phí đa hình:");
            decimal tong = 0;
            foreach (NguoiHoc item in ds)
            {
                decimal hocPhi = item.TinhHocPhi();
                tong += hocPhi;
                item.HienThi();
            }

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("TỔNG HỌC PHÍ THU ĐƯỢC: {0:N0} VNĐ", tong);
        }

        // =====================================================================
        // BÀI 6: HỆ THỐNG NHÂN VIÊN VÀ TÍNH LƯƠNG ĐA HÌNH
        // =====================================================================
        static void Bai6()
        {
            Console.WriteLine("Bài 6: Hệ thống nhân viên và tính lương đa hình");

            List<NhanVien> dsNhanVien = new List<NhanVien>()
            {
                new NhanVienVanPhong("NV01", "Phan Văn Thắng", 7000000m, 24, 730000m),
                new NhanVienKinhDoanh("NV02", "Trần Thị Bình", 5000000m, 120000000m, 0.05),
                new GiangVien("GV01", "TS. Hoàng Minh Trí", 9000000m, 45, 150000m),
                new NhanVienVanPhong("NV03", "Lê Thu Thủy", 6500000m, 26, 730000m),
                new NhanVienKinhDoanh("NV04", "Phạm Quốc Dũng", 5000000m, 85000000m, 0.05)
            };

            Console.WriteLine("DANH SÁCH NHÂN VIÊN VÀ BẢNG LƯƠNG ĐA HÌNH:");
            decimal tongLuong = 0;
            foreach (var nv in dsNhanVien)
            {
                nv.InThongTin();
                tongLuong += nv.TinhLuong();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("TỔNG TIỀN LƯƠNG DOANH NGHIỆP CHI TRẢ: {0:N0} VNĐ", tongLuong);
        }

        // =====================================================================
        // BÀI 7: QUẢN LÝ PHƯƠNG TIỆN (INTERFACE IMOVE)
        // =====================================================================
        static void Bai7()
        {
            Console.WriteLine("Bài 7: Quản lý phương tiện và chi phí vận hành (interface IMove)");

            List<PhuongTien> dsPhuongTien = new List<PhuongTien>()
            {
                new XeMay("Honda SH 150i", "Honda", 120, 150),
                new OTo("Mazda CX-5", "Mazda", 190, 5),
                new XeDap("Giant Escape 2", "Giant", 45, "Đường phố/Thể thao")
            };

            Console.Write("Nhập quãng đường cần mô phỏng vận hành (km): ");
            string? qdStr = Console.ReadLine();
            double quangDuong = string.IsNullOrWhiteSpace(qdStr) ? 50 : double.Parse(qdStr);

            Console.WriteLine("\n--- THÔNG TIN VÀ CHI PHÍ VẬN HÀNH CHO QUÃNG ĐƯỜNG {0} KM ---", quangDuong);
            foreach (var pt in dsPhuongTien)
            {
                pt.InThongTin();
                double chiPhi = pt.TinhChiPhiVanHanh(quangDuong);
                Console.WriteLine("-> Chi phí vận hành dự kiến: {0:N0} VNĐ\n", chiPhi);
            }

            Console.WriteLine("--- MÔ PHỎNG TĂNG TỐC VÀ DỪNG CỦA PHƯƠNG TIỆN ---");
            dsPhuongTien[0].TangToc(60);
            dsPhuongTien[1].TangToc(90);
            dsPhuongTien[2].TangToc(25);
            Console.WriteLine("Xe số 1 phanh dừng:");
            dsPhuongTien[0].Phanh();
        }

        // =====================================================================
        // BÀI 8: QUẢN LÝ TÀI LIỆU THƯ VIỆN
        // =====================================================================
        static void Bai8()
        {
            Console.WriteLine("Bài 8: Quản lý tài liệu thư viện (Sach, TapChi, LuanVan)");

            List<TaiLieu> dsTaiLieu = new List<TaiLieu>()
            {
                new Sach("S01", "Lập trình C# từ cơ bản đến nâng cao", "NXB Thông tin & Truyền thông", 500, "Phan Văn Thắng", 420),
                new Sach("S02", "Nhập môn Trí tuệ Nhân tạo", "NXB Khoa học", 300, "Nguyễn Văn B", 280),
                new TapChi("TC01", "Tạp chí Tin học và Điều khiển", "Viện Hàn lâm KHCN", 150, 12, 10),
                new TapChi("TC02", "Tạp chí Công nghệ Phần mềm", "ĐH Quốc gia", 200, 4, 9),
                new LuanVan("LV01", "Xây dựng ứng dụng quản lý với .NET", "ĐH Công nghệ Đông Á", 10, "Công nghệ phần mềm", "Phan Văn Thắng", 2026),
                new LuanVan("LV02", "Nhận dạng khuôn mặt bằng AI", "ĐH Bách Khoa", 10, "Khoa học máy tính", "Trần Thị Bình", 2025)
            };

            Console.WriteLine("DANH SÁCH TÀI LIỆU TRONG THƯ VIỆN:");
            foreach (var tl in dsTaiLieu) tl.InThongTin();

            Console.WriteLine("\n--- TÌM KIẾM THEO LOẠI TÀI LIỆU ---");
            Console.WriteLine("1. Tìm Sách");
            Console.WriteLine("2. Tìm Tạp chí");
            Console.WriteLine("3. Tìm Luận văn");
            Console.Write("Mời bạn chọn loại (1-3): ");
            string? chonLoai = Console.ReadLine();

            string loaiCanTim = chonLoai switch
            {
                "1" => "Sách",
                "2" => "Tạp chí",
                "3" => "Luận văn",
                _ => ""
            };

            if (string.IsNullOrEmpty(loaiCanTim))
            {
                Console.WriteLine("Lựa chọn không hợp lệ.");
                return;
            }

            var ketQua = dsTaiLieu.Where(x => x.LoaiTaiLieu().Equals(loaiCanTim, StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine("\nKẾT QUẢ TÌM THẤY ({0} tài liệu thuộc loại {1}):", ketQua.Count, loaiCanTim);
            foreach (var tl in ketQua) tl.InThongTin();
        }

        // =====================================================================
        // BÀI 9: HỆ THỐNG THANH TOÁN (INTERFACE IPAYMENT)
        // =====================================================================
        static void Bai9()
        {
            Console.WriteLine("Bài 9: Hệ thống thanh toán đa hình (IPayment)");

            Console.WriteLine("Chọn phương thức thanh toán:");
            Console.WriteLine("1. Thanh toán Tiền mặt");
            Console.WriteLine("2. Chuyển khoản ngân hàng");
            Console.WriteLine("3. Ví điện tử (Momo)");
            Console.Write("Mời chọn phương thức (1-3): ");
            string? pt = Console.ReadLine();

            Console.Write("Nhập số tiền đơn hàng cần thanh toán (VNĐ): ");
            string? stStr = Console.ReadLine();
            decimal soTien = string.IsNullOrWhiteSpace(stStr) ? 350000m : decimal.Parse(stStr);

            IPayment? payment = null;

            switch (pt)
            {
                case "1":
                    Console.Write("Nhập số tiền khách đưa: ");
                    string? kdStr = Console.ReadLine();
                    decimal tienKhachDua = string.IsNullOrWhiteSpace(kdStr) ? 500000m : decimal.Parse(kdStr);
                    payment = new ThanhToanTienMat(soTien, tienKhachDua);
                    break;

                case "2":
                    Console.Write("Nhập ngân hàng (ví dụ: Vietcombank, MB, Techcombank): ");
                    string? nh = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nh)) nh = "Vietcombank";

                    Console.Write("Nhập số tài khoản người gửi: ");
                    string? stkGui = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(stkGui)) stkGui = "102456789";

                    string stkDich = "9988776655";
                    payment = new ChuyenKhoan(soTien, nh, stkGui, stkDich);
                    break;

                case "3":
                    Console.Write("Nhập số điện thoại ví Momo: ");
                    string? sdt = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sdt)) sdt = "0987654321";

                    decimal soDuVi = 1000000m;
                    Console.WriteLine("Số dư ví hiện tại: {0:N0} VNĐ", soDuVi);
                    payment = new ViDienTu(soTien, "Momo", sdt, soDuVi);
                    break;

                default:
                    Console.WriteLine("Phương thức không hợp lệ.");
                    return;
            }

            Console.WriteLine("\n--- THỰC THI THANH TOÁN ---");
            bool thanhCong = payment.ThucHienThanhToan();
            if (thanhCong)
            {
                Console.WriteLine();
                payment.InBienLai();
            }
        }

        // =====================================================================
        // BÀI 10: NÂNG CẤP QUẢN LÝ SINH VIÊN (ĐA HÌNH, XUẤT CSV/JSON)
        // =====================================================================
        static void Bai10()
        {
            int subChon = -1;
            do
            {
                Console.WriteLine("\n--- MENU NÂNG CẤP QUẢN LÝ SINH VIÊN (BÀI 10) ---");
                Console.WriteLine("1. Xem danh sách toàn bộ sinh viên (đa hình các loại)");
                Console.WriteLine("2. Thêm mới sinh viên (Đại trà / Chất lượng cao / Quốc tế)");
                Console.WriteLine("3. Tìm kiếm sinh viên theo tên hoặc mã");
                Console.WriteLine("4. Thống kê số lượng sinh viên theo từng loại");
                Console.WriteLine("5. Thống kê sinh viên theo xếp loại học lực");
                Console.WriteLine("6. Xuất danh sách sinh viên ra file CSV (IExportable)");
                Console.WriteLine("7. Xuất danh sách sinh viên ra file JSON (IExportable)");
                Console.WriteLine("0. Quay về menu chính");
                Console.Write("Mời bạn chọn chức năng (0-7): ");

                if (!int.TryParse(Console.ReadLine(), out subChon))
                {
                    Console.WriteLine("Vui lòng nhập số từ 0 đến 7!");
                    continue;
                }

                Console.WriteLine();
                switch (subChon)
                {
                    case 1:
                        Console.WriteLine("DANH SÁCH SINH VIÊN HIỆN CÓ ({0} sinh viên):", danhSachSinhVien.Count);
                        foreach (var sv in danhSachSinhVien) sv.HienThi();
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("CHỌN LOẠI SINH VIÊN CẦN THÊM:");
                            Console.WriteLine("1. Sinh viên Đại trà");
                            Console.WriteLine("2. Sinh viên Chất lượng cao");
                            Console.WriteLine("3. Sinh viên Quốc tế");
                            Console.Write("Chọn (1-3): ");
                            string? loai = Console.ReadLine();

                            Console.Write("Mã SV: ");
                            string ma = Console.ReadLine()!;
                            if (danhSachSinhVien.Any(x => x.MaSV.Equals(ma.Trim(), StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine("Mã sinh viên đã tồn tại trong hệ thống!");
                                break;
                            }

                            Console.Write("Họ và tên: ");
                            string ten = Console.ReadLine()!;
                            Console.Write("Ngày sinh (dd/MM/yyyy): ");
                            DateTime ns = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", null);
                            Console.Write("Điểm trung bình (0-10): ");
                            double dtb = double.Parse(Console.ReadLine()!);

                            SinhVien? svMoi = null;
                            if (loai == "1")
                            {
                                Console.Write("Chuyên ngành: ");
                                string cn = Console.ReadLine()!;
                                svMoi = new SinhVienDaiTra(ma, ten, ns, dtb, cn);
                            }
                            else if (loai == "2")
                            {
                                Console.Write("Điểm tiếng Anh: ");
                                double ta = double.Parse(Console.ReadLine()!);
                                svMoi = new SinhVienChatLuongCao(ma, ten, ns, dtb, ta);
                            }
                            else if (loai == "3")
                            {
                                Console.Write("Quốc tịch: ");
                                string qt = Console.ReadLine()!;
                                svMoi = new SinhVienQuocTe(ma, ten, ns, dtb, qt);
                            }
                            else
                            {
                                svMoi = new SinhVien(ma, ten, ns, dtb);
                            }

                            if (svMoi.IsValid(out string err))
                            {
                                danhSachSinhVien.Add(svMoi);
                                Console.WriteLine("Thêm sinh viên thành công!");
                            }
                            else
                            {
                                Console.WriteLine("Không thể thêm! Lỗi dữ liệu: " + err);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi khi thêm: " + ex.Message);
                        }
                        break;

                    case 3:
                        Console.Write("Nhập từ khóa tìm kiếm (Mã hoặc Họ tên): ");
                        string keyword = Console.ReadLine()?.Trim().ToLower() ?? "";
                        var timThay = danhSachSinhVien.Where(x => x.MaSV.ToLower().Contains(keyword) || x.HoTen.ToLower().Contains(keyword)).ToList();
                        if (timThay.Count > 0)
                        {
                            Console.WriteLine("Tìm thấy {0} kết quả:", timThay.Count);
                            foreach (var sv in timThay) sv.HienThi();
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy kết quả phù hợp với từ khóa: " + keyword);
                        }
                        break;

                    case 4:
                        Console.WriteLine("THỐNG KÊ SINH VIÊN THEO LOẠI:");
                        var thongKeLoai = danhSachSinhVien.GroupBy(x => x.LoaiSinhVien);
                        foreach (var g in thongKeLoai)
                        {
                            Console.WriteLine("- Loại {0,-20}: {1} sinh viên", g.Key, g.Count());
                        }
                        break;

                    case 5:
                        Console.WriteLine("THỐNG KÊ SINH VIÊN THEO HỌC LỰC:");
                        var thongKeHocLuc = danhSachSinhVien.GroupBy(x => x.XepLoai());
                        foreach (var g in thongKeHocLuc)
                        {
                            Console.WriteLine("- Xếp loại {0,-12}: {1} sinh viên", g.Key, g.Count());
                        }
                        break;

                    case 6:
                        try
                        {
                            string fileName = "DanhSachSinhVien.csv";
                            List<string> lines = new List<string> { "MaSV,HoTen,NgaySinh,DiemTB,LoaiSinhVien,XepLoai" };
                            foreach (var sv in danhSachSinhVien)
                            {
                                lines.Add(sv.ExportToCsv());
                            }
                            File.WriteAllLines(fileName, lines, Encoding.UTF8);
                            Console.WriteLine("Đã xuất danh sách thành công ra file: {0}", Path.GetFullPath(fileName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi xuất file CSV: " + ex.Message);
                        }
                        break;

                    case 7:
                        try
                        {
                            string fileName = "DanhSachSinhVien.json";
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("[");
                            for (int i = 0; i < danhSachSinhVien.Count; i++)
                            {
                                sb.Append("  " + danhSachSinhVien[i].ExportToJson());
                                if (i < danhSachSinhVien.Count - 1) sb.Append(",");
                                sb.AppendLine();
                            }
                            sb.AppendLine("]");
                            File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
                            Console.WriteLine("Đã xuất danh sách thành công ra file: {0}", Path.GetFullPath(fileName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi xuất file JSON: " + ex.Message);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Quay về menu chính.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            } while (subChon != 0);
        }
    }
}
