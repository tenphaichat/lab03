using System;

namespace Lab03_OOPAdvanced
{
    public interface IMove
    {
        double TocDoToiDa { get; set; }       // km/h
        double TinhChiPhiVanHanh(double quangDuongKm); // VNĐ cho quãng đường km
        void TangToc(double delta);
        void Phanh();
    }

    public abstract class PhuongTien : IMove
    {
        public string TenPhuongTien { get; set; }
        public string HangSanXuat { get; set; }
        public double TocDoHienTai { get; protected set; }
        public double TocDoToiDa { get; set; }

        public PhuongTien(string ten, string hang, double maxSpeed)
        {
            TenPhuongTien = ten;
            HangSanXuat = hang;
            TocDoToiDa = maxSpeed;
            TocDoHienTai = 0;
        }

        public abstract double TinhChiPhiVanHanh(double quangDuongKm);

        public virtual void TangToc(double delta)
        {
            TocDoHienTai += delta;
            if (TocDoHienTai > TocDoToiDa) TocDoHienTai = TocDoToiDa;
            Console.WriteLine("{0} tăng tốc: +{1} km/h -> Tốc độ hiện tại: {2:N0} km/h", TenPhuongTien, delta, TocDoHienTai);
        }

        public virtual void Phanh()
        {
            TocDoHienTai = 0;
            Console.WriteLine("{0} đã dừng hẳn (0 km/h).", TenPhuongTien);
        }

        public virtual void InThongTin()
        {
            Console.WriteLine("{0,-12} | Hãng: {1,-10} | Max: {2,3} km/h | Đang chạy: {3,3:N0} km/h",
                TenPhuongTien, HangSanXuat, TocDoToiDa, TocDoHienTai);
        }
    }

    public class XeMay : PhuongTien
    {
        public double DungTichXiLanh { get; set; } // cc

        public XeMay(string ten, string hang, double maxSpeed, double dungTich)
            : base(ten, hang, maxSpeed)
        {
            DungTichXiLanh = dungTich;
        }

        public override double TinhChiPhiVanHanh(double quangDuongKm)
        {
            // Xe máy tiêu hao khoảng 2.2 lít / 100km, giá xăng 24,000đ/lít
            double xangTieuThu = (quangDuongKm / 100.0) * 2.2;
            return Math.Round(xangTieuThu * 24000, 0);
        }
    }

    public class OTo : PhuongTien
    {
        public int SoChoNgoi { get; set; }

        public OTo(string ten, string hang, double maxSpeed, int soCho)
            : base(ten, hang, maxSpeed)
        {
            SoChoNgoi = soCho;
        }

        public override double TinhChiPhiVanHanh(double quangDuongKm)
        {
            // Ô tô tiêu hao khoảng 8.5 lít / 100km xăng + phí cầu đường ước lượng 500đ/km
            double xangTieuThu = (quangDuongKm / 100.0) * 8.5;
            double tienXang = xangTieuThu * 24000;
            double phiDuongBo = quangDuongKm * 500;
            return Math.Round(tienXang + phiDuongBo, 0);
        }
    }

    public class XeDap : PhuongTien
    {
        public string LoaiXeDap { get; set; } // Địa hình, Đua, Thể thao

        public XeDap(string ten, string hang, double maxSpeed, string loai)
            : base(ten, hang, maxSpeed)
        {
            LoaiXeDap = loai;
        }

        public override double TinhChiPhiVanHanh(double quangDuongKm)
        {
            // Xe đạp sức người, chỉ tính chi phí hao mòn xích líp bảo dưỡng ~ 150đ/km
            return Math.Round(quangDuongKm * 150, 0);
        }
    }
}
