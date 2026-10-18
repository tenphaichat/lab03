using System;

namespace Lab03_OOPAdvanced
{
    public abstract class NguoiHoc
    {
        public string HoTen { get; set; } = "";
        public int SoTinChi { get; set; }

        public NguoiHoc() { }

        public NguoiHoc(string hoTen, int soTinChi)
        {
            HoTen = hoTen;
            SoTinChi = soTinChi;
        }

        public abstract decimal TinhHocPhi();

        public virtual void HienThi()
        {
            Console.WriteLine("Học viên: {0,-20} | Số tín chỉ: {1,-3} | Học phí: {2,12:N0} VNĐ", HoTen, SoTinChi, TinhHocPhi());
        }
    }

    public class SinhVienChinhQuy : NguoiHoc
    {
        public SinhVienChinhQuy() { }

        public SinhVienChinhQuy(string hoTen, int soTinChi) : base(hoTen, soTinChi) { }

        public override decimal TinhHocPhi()
        {
            return SoTinChi * 450000m;
        }

        public override void HienThi()
        {
            Console.WriteLine("[Chính quy]   {0,-20} | Số tín chỉ: {1,-3} | Đơn giá: 450.000đ | Học phí: {2,12:N0} VNĐ", HoTen, SoTinChi, TinhHocPhi());
        }
    }

    public class SinhVienLienThong : NguoiHoc
    {
        public SinhVienLienThong() { }

        public SinhVienLienThong(string hoTen, int soTinChi) : base(hoTen, soTinChi) { }

        public override decimal TinhHocPhi()
        {
            return SoTinChi * 520000m;
        }

        public override void HienThi()
        {
            Console.WriteLine("[Liên thông]  {0,-20} | Số tín chỉ: {1,-3} | Đơn giá: 520.000đ | Học phí: {2,12:N0} VNĐ", HoTen, SoTinChi, TinhHocPhi());
        }
    }
}
