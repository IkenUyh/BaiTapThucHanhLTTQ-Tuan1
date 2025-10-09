using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Collections;

namespace HomNayLaThuMay
{
    class CDate
    {
        private int ngay, thang, nam;
        private static int dem = 0;
        public void Dispose() {
            --dem;
            System.Console.WriteLine("Da huy mot khoang thoi gian");
        }
        public CDate()
        {
            DateTime now = DateTime.Now;
            ngay = now.Day;
            thang = now.Month;
            nam = now.Year;
            dem++;
        }
        public CDate(int ngay)
        {
            DateTime now = DateTime.Now;
            this.ngay = ngay;
            thang = now.Month;
            nam = now.Year;
            if (ngay < 1 || ngay > SoNgayTrongThang(thang, nam))
                this.ngay = now.Day;
            dem++;
        }
        public CDate(int ngay, int thang)
        {
            DateTime now = DateTime.Now;
            this.ngay = ngay;
            this.thang = thang;
            nam = now.Year;
            if (ngay < 1 || ngay > SoNgayTrongThang(thang, nam))
                this.ngay = now.Day;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            dem++;
        }
        public CDate(int ngay, int thang, int nam)
        {
            DateTime now = DateTime.Now;
            this.ngay = ngay;
            this.thang = thang;
            this.nam = nam;
            if (ngay < 1 || ngay > SoNgayTrongThang(thang, nam))
                this.ngay = now.Day;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            if (nam < 1)
                this.nam = now.Year;
            dem++;
        }
        public CDate(CDate d)
        {
            DateTime now = DateTime.Now;
            this.ngay = d.ngay;
            this.thang = d.thang;
            this.nam = d.nam;
            if (ngay < 1 || ngay > SoNgayTrongThang(thang, nam))
                this.ngay = now.Day;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            if (nam < 1)
                this.nam = now.Year;
            dem++;
        }
        public CDate Assign(CDate d)
        {
            DateTime now = DateTime.Now;
            this.ngay = d.ngay;
            this.thang = d.thang;
            this.nam = d.nam;
            if (ngay < 1 || ngay > SoNgayTrongThang(thang, nam))
                this.ngay = now.Day;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            if (nam < 1)
                this.nam = now.Year;
            return this;
        }
        public int GetNgay()
        {
            return this.ngay;
        }
        public int GetThang()
        {
            return this.thang;
        }
        public int GetNam()
        {
            return this.nam;
        }
        public static int GetDem()
        {
            return dem;
        }
        public void SetNgay(int ngay)
        {
            this.ngay = ngay;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Ngay ban nhap khong hop le!");
                    Console.Write("Moi ban nhap lai: ");
                    this.ngay = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    ngay = -1;
                }
            }
        }
        public void SetThang(int thang)
        {
            this.thang = thang;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Thang ban nhap khong hop le!");
                    Console.Write("Moi ban nhap lai: ");
                    this.thang = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    thang = -1;
                }
            }
        }
        public void SetNam(int nam)
        {
            this.nam = nam;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Nam ban nhap khong hop le!");
                    Console.Write("Moi ban nhap lai: ");
                    this.nam = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    nam = -1;
                }
            }
        }
        public void SetNgayThangNam(int ngay, int thang, int nam)
        {
            this.ngay = ngay;
            this.thang = thang;
            this.nam = nam;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Ngay thang nam ban nhap khong hop le! Moi ban nhap lai:");
                    Console.Write("Nhap ngay: ");
                    this.ngay = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap thang: ");
                    this.thang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap nam: ");
                    this.nam = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    ngay = -1; thang = -1; nam = -1;
                }
            }
        }
        public bool KiemTraHopLe()
        {
            return nam >= 1 && thang >= 1 && thang <= 12 && ngay >= 1 && ngay <= SoNgayTrongThang(thang, nam);
        }
        private static bool NamNhuan(int n)
        {
            return (n % 4 == 0 && n % 100 != 0) || (n % 400 == 0);
        }
        private static int SoNgayTrongThang(int thang, int nam)
        {
            int[] nThang = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (thang == 2 && NamNhuan(nam)) return 29;
            return nThang[thang];
        }
        public string Week(int thu){
            string[] day={"Chu nhat", "Thu hai", "Thu ba",
            "Thu tu", "Thu nam", "Thu sau", "Thu bay"};
            return day[thu];
        }
        int ThuTuTrongNam()
        {
            int dem=ngay;
            for(int i=1; i<thang; i++) dem+=SoNgayTrongThang(i, nam);
            return dem;
        }
        public int ThuTuTrongTuan() {
            int tongngay=(nam-1)*365+(nam-1)/4-(nam-1)/100+(nam-1)/400+ThuTuTrongNam();
            return tongngay%7;
        }
        public void Nhap()
        {
            do
            {
                try
                {
                    System.Console.Write("Nhap ngay: ");
                    ngay = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write("Nhap thang: ");
                    thang = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write("Nhap nam: ");
                    nam = Convert.ToInt32(Console.ReadLine());
                    if (!KiemTraHopLe())
                        System.Console.WriteLine("Ngay thang nam khong hop le! Moi ban nhap lai!");
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    ngay = -1; thang = -1; nam = -1;
                }
            } while (!KiemTraHopLe());
        }
        public static CDate ReadFromConsole()
        {
            CDate d = new CDate();
            do
            {
                try
                {
                    Console.Write("Nhap ngay: ");
                    d.ngay = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap thang: ");
                    d.thang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap nam: ");
                    d.nam = Convert.ToInt32(Console.ReadLine());
                    if (d.nam < 1 || d.thang < 1 || d.thang > 12 || d.ngay < 1 || d.ngay > SoNgayTrongThang(d.thang, d.nam))
                        Console.WriteLine("Ngay thang nam khong hop le moi ban nhap lai:");
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    d.ngay = -1; d.thang = -1; d.nam = -1;
                }
            } while (d.nam < 1 || d.thang < 1 || d.thang > 12 || d.ngay < 1 || d.ngay > SoNgayTrongThang(d.thang, d.nam));
            return d;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====CHUONG TRINH XAC DINH THU TRONG TUAN=====");
            Console.WriteLine("Nhap ngay thang nam de kiem tra:");
            CDate date = CDate.ReadFromConsole();
            Console.WriteLine("Ngay: {0}/{1}/{2}", date.GetNgay(), date.GetThang(), date.GetNam());
            if (date.KiemTraHopLe())
            {
                Console.WriteLine("Ngay thang nam hop le!");
                Console.WriteLine("Thu trong tuan: {0}", date.Week(date.ThuTuTrongTuan()));
            }
            else
                Console.WriteLine("Ngay thang nam khong hop le!");
            date.Dispose();
            Console.WriteLine("=====KET THUC CHUONG TRINH=====");
        }
    }
}