using System;

namespace Lab03_OOPAdvanced
{
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi()
        {
            HoTen = "Chưa có tên";
            NgaySinh = DateTime.Now;
        }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual string MoTa()
        {
            return HoTen + " - " + NgaySinh.ToString("dd/MM/yyyy");
        }

        public int TinhTuoi()
        {
            DateTime now = DateTime.Now;
            int tuoi = now.Year - NgaySinh.Year;
            if (now.Month < NgaySinh.Month || (now.Month == NgaySinh.Month && now.Day < NgaySinh.Day))
            {
                tuoi--;
            }
            return tuoi < 0 ? 0 : tuoi;
        }
    }
}
