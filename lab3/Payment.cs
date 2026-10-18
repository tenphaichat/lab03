using System;

namespace Lab03_OOPAdvanced
{
    public interface IPayment
    {
        string MaGiaoDich { get; }
        decimal SoTien { get; }
        DateTime ThoiGian { get; }
        string PhuongThuc { get; }

        bool KiemTraHopLe(out string thongBao);
        bool ThucHienThanhToan();
        void InBienLai();
    }

    public class ThanhToanTienMat : IPayment
    {
        public string MaGiaoDich { get; private set; }
        public decimal SoTien { get; private set; }
        public DateTime ThoiGian { get; private set; }
        public string PhuongThuc => "Tiền mặt tại quầy";
        public decimal TienKhachDua { get; set; }

        public ThanhToanTienMat(decimal soTien, decimal tienKhachDua)
        {
            MaGiaoDich = "CASH_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            SoTien = soTien;
            TienKhachDua = tienKhachDua;
            ThoiGian = DateTime.Now;
        }

        public bool KiemTraHopLe(out string thongBao)
        {
            if (SoTien <= 0)
            {
                thongBao = "Số tiền thanh toán phải lớn hơn 0.";
                return false;
            }
            if (TienKhachDua < SoTien)
            {
                thongBao = string.Format("Tiền khách đưa ({0:N0}đ) không đủ để thanh toán ({1:N0}đ).", TienKhachDua, SoTien);
                return false;
            }
            thongBao = "Hợp lệ.";
            return true;
        }

        public bool ThucHienThanhToan()
        {
            if (KiemTraHopLe(out string msg))
            {
                decimal tienThua = TienKhachDua - SoTien;
                Console.WriteLine("Thanh toán tiền mặt thành công! Tiền thối lại cho khách: {0:N0} VNĐ", tienThua);
                return true;
            }
            Console.WriteLine("Thanh toán thất bại: " + msg);
            return false;
        }

        public void InBienLai()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("BIÊN LAI THANH TOÁN TIỀN MẶT");
            Console.WriteLine("Mã GD: {0}", MaGiaoDich);
            Console.WriteLine("Thời gian: {0:dd/MM/yyyy HH:mm:ss}", ThoiGian);
            Console.WriteLine("Số tiền phải trả: {0:N0} VNĐ", SoTien);
            Console.WriteLine("Tiền khách đưa:   {0:N0} VNĐ", TienKhachDua);
            Console.WriteLine("Tiền thừa trả:    {0:N0} VNĐ", TienKhachDua - SoTien);
            Console.WriteLine("---------------------------------------------");
        }
    }

    public class ChuyenKhoan : IPayment
    {
        public string MaGiaoDich { get; private set; }
        public decimal SoTien { get; private set; }
        public DateTime ThoiGian { get; private set; }
        public string PhuongThuc => "Chuyển khoản ngân hàng";
        public string NganHang { get; set; }
        public string SoTaiKhoanNguon { get; set; }
        public string SoTaiKhoanDich { get; set; }

        public ChuyenKhoan(decimal soTien, string nganHang, string stkNguon, string stkDich)
        {
            MaGiaoDich = "BANK_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            SoTien = soTien;
            NganHang = nganHang;
            SoTaiKhoanNguon = stkNguon;
            SoTaiKhoanDich = stkDich;
            ThoiGian = DateTime.Now;
        }

        public bool KiemTraHopLe(out string thongBao)
        {
            if (SoTien <= 0)
            {
                thongBao = "Số tiền phải lớn hơn 0.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoTaiKhoanNguon) || string.IsNullOrWhiteSpace(SoTaiKhoanDich))
            {
                thongBao = "Số tài khoản không được để trống.";
                return false;
            }
            if (SoTaiKhoanNguon == SoTaiKhoanDich)
            {
                thongBao = "Tài khoản nguồn và đích không được trùng nhau.";
                return false;
            }
            thongBao = "Hợp lệ.";
            return true;
        }

        public bool ThucHienThanhToan()
        {
            if (KiemTraHopLe(out string msg))
            {
                Console.WriteLine("Giao dịch chuyển khoản qua {0} thành công! Đã gửi {1:N0} VNĐ đến STK: {2}", NganHang, SoTien, SoTaiKhoanDich);
                return true;
            }
            Console.WriteLine("Chuyển khoản thất bại: " + msg);
            return false;
        }

        public void InBienLai()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("ỦY NHIỆM CHI / BIÊN LAI CHUYỂN KHOẢN");
            Console.WriteLine("Mã GD: {0}", MaGiaoDich);
            Console.WriteLine("Ngân hàng: {0}", NganHang);
            Console.WriteLine("TK nguồn: {0} -> TK thụ hưởng: {1}", SoTaiKhoanNguon, SoTaiKhoanDich);
            Console.WriteLine("Số tiền chuyển: {0:N0} VNĐ", SoTien);
            Console.WriteLine("Thời gian: {0:dd/MM/yyyy HH:mm:ss}", ThoiGian);
            Console.WriteLine("Trạng thái: GIAO DỊCH THÀNH CÔNG");
            Console.WriteLine("---------------------------------------------");
        }
    }

    public class ViDienTu : IPayment
    {
        public string MaGiaoDich { get; private set; }
        public decimal SoTien { get; private set; }
        public DateTime ThoiGian { get; private set; }
        public string PhuongThuc => "Ví điện tử (Momo / ZaloPay / ShopeePay)";
        public string TenVi { get; set; }
        public string SoDienThoaiVi { get; set; }
        public decimal SoDuVi { get; set; }

        public ViDienTu(decimal soTien, string tenVi, string sdt, decimal soDuVi)
        {
            MaGiaoDich = "EWALLET_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            SoTien = soTien;
            TenVi = tenVi;
            SoDienThoaiVi = sdt;
            SoDuVi = soDuVi;
            ThoiGian = DateTime.Now;
        }

        public bool KiemTraHopLe(out string thongBao)
        {
            if (SoTien <= 0)
            {
                thongBao = "Số tiền phải lớn hơn 0.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(SoDienThoaiVi) || SoDienThoaiVi.Length < 10)
            {
                thongBao = "Số điện thoại ví điện tử không hợp lệ.";
                return false;
            }
            if (SoDuVi < SoTien)
            {
                thongBao = string.Format("Số dư ví {0} ({1:N0}đ) không đủ để thanh toán ({2:N0}đ).", TenVi, SoDuVi, SoTien);
                return false;
            }
            thongBao = "Hợp lệ.";
            return true;
        }

        public bool ThucHienThanhToan()
        {
            if (KiemTraHopLe(out string msg))
            {
                SoDuVi -= SoTien;
                Console.WriteLine("Thanh toán qua ví {0} thành công! Số dư ví còn lại: {1:N0} VNĐ", TenVi, SoDuVi);
                return true;
            }
            Console.WriteLine("Thanh toán ví điện tử thất bại: " + msg);
            return false;
        }

        public void InBienLai()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("BIÊN NHẬN VÍ ĐIỆN TỬ - {0}", TenVi.ToUpper());
            Console.WriteLine("Mã GD: {0}", MaGiaoDich);
            Console.WriteLine("Ví / SĐT: {0}", SoDienThoaiVi);
            Console.WriteLine("Số tiền trừ: {0:N0} VNĐ", SoTien);
            Console.WriteLine("Số dư ví còn: {0:N0} VNĐ", SoDuVi);
            Console.WriteLine("Thời gian: {0:dd/MM/yyyy HH:mm:ss}", ThoiGian);
            Console.WriteLine("---------------------------------------------");
        }
    }
}
