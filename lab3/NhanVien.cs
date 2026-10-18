using System;

namespace Lab03_OOPAdvanced
{
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public decimal LuongCoBan { get; set; }

        public NhanVien(string maNV, string hoTen, decimal luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }

        public abstract decimal TinhLuong();
        public abstract string ChucVu();

        public virtual void InThongTin()
        {
            Console.WriteLine("Mã NV: {0,-6} | Họ tên: {1,-20} | Chức vụ: {2,-22} | Thực lĩnh: {3,12:N0} VNĐ",
                MaNV, HoTen, ChucVu(), TinhLuong());
        }
    }

    public class NhanVienVanPhong : NhanVien
    {
        public int SoNgayCong { get; set; }
        public decimal PhuCapAnTrua { get; set; }

        public NhanVienVanPhong(string maNV, string hoTen, decimal luongCoBan, int soNgayCong, decimal phuCapAnTrua = 730000m)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayCong = soNgayCong;
            PhuCapAnTrua = phuCapAnTrua;
        }

        public override string ChucVu() => "Nhân viên văn phòng";

        public override decimal TinhLuong()
        {
            // Lương = (Lương cơ bản / 26) * Ngày công + Phụ cấp ăn trưa
            return Math.Round((LuongCoBan / 26m) * SoNgayCong + PhuCapAnTrua, 0);
        }

        public override void InThongTin()
        {
            Console.WriteLine("Mã NV: {0,-6} | Họ tên: {1,-20} | Chức vụ: {2,-22} | Ngày công: {3,2} | Thực lĩnh: {4,12:N0} VNĐ",
                MaNV, HoTen, ChucVu(), SoNgayCong, TinhLuong());
        }
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        public decimal DoanhThu { get; set; }
        public double TiLeHoaHong { get; set; } // Ví dụ 0.05 (5%)

        public NhanVienKinhDoanh(string maNV, string hoTen, decimal luongCoBan, decimal doanhThu, double tiLeHoaHong = 0.05)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhThu = doanhThu;
            TiLeHoaHong = tiLeHoaHong;
        }

        public override string ChucVu() => "Nhân viên kinh doanh";

        public override decimal TinhLuong()
        {
            // Lương = Lương cơ bản + Doanh thu * Hoa hồng
            return Math.Round(LuongCoBan + DoanhThu * (decimal)TiLeHoaHong, 0);
        }

        public override void InThongTin()
        {
            Console.WriteLine("Mã NV: {0,-6} | Họ tên: {1,-20} | Chức vụ: {2,-22} | Doanh thu: {3,11:N0}đ | Thực lĩnh: {4,12:N0} VNĐ",
                MaNV, HoTen, ChucVu(), DoanhThu, TinhLuong());
        }
    }

    public class GiangVien : NhanVien
    {
        public int SoTietDay { get; set; }
        public decimal ThuLaoMoiTiet { get; set; }

        public GiangVien(string maNV, string hoTen, decimal luongCoBan, int soTietDay, decimal thuLaoMoiTiet = 150000m)
            : base(maNV, hoTen, luongCoBan)
        {
            SoTietDay = soTietDay;
            ThuLaoMoiTiet = thuLaoMoiTiet;
        }

        public override string ChucVu() => "Giảng viên";

        public override decimal TinhLuong()
        {
            // Lương = Lương cơ bản + Tiết dạy * Đơn giá thù lao
            return Math.Round(LuongCoBan + SoTietDay * ThuLaoMoiTiet, 0);
        }

        public override void InThongTin()
        {
            Console.WriteLine("Mã NV: {0,-6} | Họ tên: {1,-20} | Chức vụ: {2,-22} | Tiết dạy: {3,3} | Thực lĩnh: {4,12:N0} VNĐ",
                MaNV, HoTen, ChucVu(), SoTietDay, TinhLuong());
        }
    }
}
