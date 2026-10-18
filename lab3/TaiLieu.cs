using System;

namespace Lab03_OOPAdvanced
{
    public abstract class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }
        public string NhaXuatBan { get; set; }
        public int SoBanPhatHanh { get; set; }

        public TaiLieu(string ma, string ten, string nxb, int soBan)
        {
            MaTaiLieu = ma;
            TenTaiLieu = ten;
            NhaXuatBan = nxb;
            SoBanPhatHanh = soBan;
        }

        public abstract string LoaiTaiLieu();

        public virtual void InThongTin()
        {
            Console.WriteLine("[{0,-8}] Mã: {1,-6} | Tên: {2,-28} | NXB: {3,-15} | Bản: {4,3}",
                LoaiTaiLieu(), MaTaiLieu, TenTaiLieu, NhaXuatBan, SoBanPhatHanh);
        }
    }

    public class Sach : TaiLieu
    {
        public string TenTacGia { get; set; }
        public int SoTrang { get; set; }

        public Sach(string ma, string ten, string nxb, int soBan, string tacGia, int soTrang)
            : base(ma, ten, nxb, soBan)
        {
            TenTacGia = tacGia;
            SoTrang = soTrang;
        }

        public override string LoaiTaiLieu() => "Sách";

        public override void InThongTin()
        {
            Console.WriteLine("[{0,-8}] Mã: {1,-6} | Tên: {2,-28} | Tác giả: {3,-16} | Số trang: {4,3} | Bản: {5,3}",
                LoaiTaiLieu(), MaTaiLieu, TenTaiLieu, TenTacGia, SoTrang, SoBanPhatHanh);
        }
    }

    public class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }

        public TapChi(string ma, string ten, string nxb, int soBan, int soPhatHanh, int thangPhatHanh)
            : base(ma, ten, nxb, soBan)
        {
            SoPhatHanh = soPhatHanh;
            ThangPhatHanh = thangPhatHanh;
        }

        public override string LoaiTaiLieu() => "Tạp chí";

        public override void InThongTin()
        {
            Console.WriteLine("[{0,-8}] Mã: {1,-6} | Tên: {2,-28} | Số PH: {3,2} | Tháng: {4,2}/2026 | Bản: {5,3}",
                LoaiTaiLieu(), MaTaiLieu, TenTaiLieu, SoPhatHanh, ThangPhatHanh, SoBanPhatHanh);
        }
    }

    public class LuanVan : TaiLieu
    {
        public string NganhHoc { get; set; }
        public string SinhVienThucHien { get; set; }
        public int NamTotNghiep { get; set; }

        public LuanVan(string ma, string ten, string nxb, int soBan, string nganh, string sv, int nam)
            : base(ma, ten, nxb, soBan)
        {
            NganhHoc = nganh;
            SinhVienThucHien = sv;
            NamTotNghiep = nam;
        }

        public override string LoaiTaiLieu() => "Luận văn";

        public override void InThongTin()
        {
            Console.WriteLine("[{0,-8}] Mã: {1,-6} | Tên: {2,-28} | SV: {3,-18} | Ngành: {4,-15} | Năm: {5}",
                LoaiTaiLieu(), MaTaiLieu, TenTaiLieu, SinhVienThucHien, NganhHoc, NamTotNghiep);
        }
    }
}
