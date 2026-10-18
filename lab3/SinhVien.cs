using System;

namespace Lab03_OOPAdvanced
{
    public class SinhVien : Nguoi, IValidatable, IPrintable, IExportable
    {
        public string MaSV { get; set; }
        public double DiemTB { get; set; }

        public SinhVien() : base("Chưa có tên", DateTime.Now)
        {
            MaSV = "SV00";
            DiemTB = 0;
        }

        public SinhVien(string ma, string ten, DateTime ngaySinh, double diem)
            : base(ten, ngaySinh)
        {
            MaSV = ma;
            DiemTB = diem;
        }

        public override string MoTa()
        {
            return base.MoTa() + " - " + MaSV + " - " + DiemTB.ToString("N2");
        }

        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(MaSV))
            {
                message = "Thiếu mã";
                return false;
            }
            if (string.IsNullOrWhiteSpace(HoTen))
            {
                message = "Thiếu họ tên";
                return false;
            }
            if (DiemTB < 0 || DiemTB > 10)
            {
                message = "Điểm sai";
                return false;
            }
            message = "";
            return true;
        }

        public string ToDisplayText()
        {
            return MaSV + " - " + HoTen;
        }

        public string XepLoai()
        {
            if (DiemTB >= 9.0) return "Xuất sắc";
            if (DiemTB >= 8.0) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5.0) return "Trung bình";
            return "Yếu";
        }

        public virtual string LoaiSinhVien => "Cơ bản";

        public virtual string ExportToCsv()
        {
            return $"{MaSV},{HoTen},{NgaySinh:dd/MM/yyyy},{DiemTB:F2},{LoaiSinhVien},{XepLoai()}";
        }

        public virtual string ExportToJson()
        {
            return $"{{\"MaSV\":\"{MaSV}\",\"HoTen\":\"{HoTen}\",\"NgaySinh\":\"{NgaySinh:dd/MM/yyyy}\",\"DiemTB\":{DiemTB:F2},\"Loai\":\"{LoaiSinhVien}\",\"XepLoai\":\"{XepLoai()}\"}}";
        }

        public virtual void HienThi()
        {
            Console.WriteLine("Mã SV: {0} | Họ tên: {1} | Ngày sinh: {2:dd/MM/yyyy} | Điểm TB: {3:N2} | Loại: {4} | Xếp loại: {5}",
                MaSV, HoTen, NgaySinh, DiemTB, LoaiSinhVien, XepLoai());
        }
    }

    // Các lớp con mở rộng cho Bài 10 (Nâng cấp quản lý sinh viên)
    public class SinhVienDaiTra : SinhVien
    {
        public string ChuyenNganh { get; set; }

        public SinhVienDaiTra(string ma, string ten, DateTime ngaySinh, double diem, string chuyenNganh)
            : base(ma, ten, ngaySinh, diem)
        {
            ChuyenNganh = chuyenNganh;
        }

        public override string LoaiSinhVien => "Đại trà";

        public override string MoTa()
        {
            return base.MoTa() + " - " + ChuyenNganh;
        }

        public override void HienThi()
        {
            Console.WriteLine("Mã SV: {0} | Họ tên: {1} | Ngày sinh: {2:dd/MM/yyyy} | Điểm TB: {3:N2} | Chuyên ngành: {4} | Loại: {5} | Xếp loại: {6}",
                MaSV, HoTen, NgaySinh, DiemTB, ChuyenNganh, LoaiSinhVien, XepLoai());
        }
    }

    public class SinhVienChatLuongCao : SinhVien
    {
        public double DiemTiengAnh { get; set; }

        public SinhVienChatLuongCao(string ma, string ten, DateTime ngaySinh, double diem, double diemTiengAnh)
            : base(ma, ten, ngaySinh, diem)
        {
            DiemTiengAnh = diemTiengAnh;
        }

        public override string LoaiSinhVien => "Chất lượng cao";

        public override string MoTa()
        {
            return base.MoTa() + " - Tiếng Anh: " + DiemTiengAnh.ToString("N1");
        }

        public override void HienThi()
        {
            Console.WriteLine("Mã SV: {0} | Họ tên: {1} | Ngày sinh: {2:dd/MM/yyyy} | Điểm TB: {3:N2} | Tiếng Anh: {4:N1} | Loại: {5} | Xếp loại: {6}",
                MaSV, HoTen, NgaySinh, DiemTB, DiemTiengAnh, LoaiSinhVien, XepLoai());
        }
    }

    public class SinhVienQuocTe : SinhVien
    {
        public string QuocTich { get; set; }

        public SinhVienQuocTe(string ma, string ten, DateTime ngaySinh, double diem, string quocTich)
            : base(ma, ten, ngaySinh, diem)
        {
            QuocTich = quocTich;
        }

        public override string LoaiSinhVien => "Quốc tế";

        public override string MoTa()
        {
            return base.MoTa() + " - Quốc tịch: " + QuocTich;
        }

        public override void HienThi()
        {
            Console.WriteLine("Mã SV: {0} | Họ tên: {1} | Ngày sinh: {2:dd/MM/yyyy} | Điểm TB: {3:N2} | Quốc tịch: {4} | Loại: {5} | Xếp loại: {6}",
                MaSV, HoTen, NgaySinh, DiemTB, QuocTich, LoaiSinhVien, XepLoai());
        }
    }
}
