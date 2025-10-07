using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Collections;

namespace MangMotChieu
{
    public class cArray
    {
        private int[] a;
        private int n;
        private static int dem = 0;
        public void Dispose() {
            if (a != null) {
                a = null;
                n = 0;
                dem--;
                Console.WriteLine("Da giai phong mot mang");
            }
        }
        public cArray()
        {
            a = null;
            n = 0;
            dem++;
        }
        public cArray(int size)
        {
            while (size <= 0)
            {
                System.Console.Write("Nhap lai so luong phan tu mang > 0: ");
                size = Convert.ToInt32(Console.ReadLine());
            }
            this.n = size;
            a = new int[n];
            Random rng = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rng.Next(0, 1000);
            dem++;
        }
        public cArray(cArray other)
        {
            if (other.n == 0)
            {
                a = null;
                n = 0;
            }
            else
            {
                n = other.n;
                a = new int[n];
                for (int i = 0; i < n; i++)
                    a[i] = other.a[i];
            }
            dem++;
        }
        public int GetN()
        {
            return n;
        }
        public int[] GetA()
        {
            return a;
        }
        public static int GetDem()
        {
            return dem;
        }
        public void Nhap()
        {
            if (a != null)
            {
                a = null;
                n = 0;
            }
            do
            {
                System.Console.Write("Nhap so phan tu cua mang:");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0) System.Console.WriteLine("So luong phan tu phai > 0! Moi ban nhap lai!");
            } while (n <= 0);
            a = new int[n];
            Random rng = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rng.Next(0, 1000);
        }
        public void Xuat()
        {
            if (a == null || n == 0)
            {
                Console.WriteLine("Mang rong");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(a[i] + " ");
                }
                Console.WriteLine();
            }
        }
        public int TongSoLe()
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                if (a[i] % 2 != 0)
                    sum += a[i];
            return sum;
        }
        public int DemSoNguyenTo()
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
                if (IsPrime(a[i]))
                    cnt++;
            return cnt;
        }
        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        public int SoChinhPhuongNhoNhat()
        {
            int res = -1;
            for (int i = 0; i < n; i++)
            {
                int sqrt = (int)Math.Sqrt(a[i]);
                if (sqrt * sqrt == a[i])
                    if (res == -1 || res > a[i])
                        res = a[i];
            }
            return res;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=====KIEM TRA CHUONG TRINH=====");
            Console.WriteLine("Tong So Doi Tuong: " + cArray.GetDem());
            Console.WriteLine("\n1. Nhap so luong phan tu mang:");
            Console.Write("Nhap so phan tu: ");
            int n = Convert.ToInt32(Console.ReadLine());
            cArray arr = new cArray(n);
            Console.Write("Noi dung mang: ");
            arr.Xuat();
            Console.WriteLine("\n2. Tinh tong cac so le:");
            Console.WriteLine("Tong cac so le: " + arr.TongSoLe());
            Console.WriteLine("\n3. Dem so nguyen to:");
            Console.WriteLine("So luong so nguyen to: " + arr.DemSoNguyenTo());

            Console.WriteLine("\n4. Tim so chinh phuong nho nhat:");
            int minSquare = arr.SoChinhPhuongNhoNhat();
            if (minSquare == -1)
                Console.WriteLine("Khong co so chinh phuong trong mang");
            else
                Console.WriteLine("So chinh phuong nho nhat: " + minSquare);

            Console.WriteLine("\nTong so doi tuong khi tao: " + cArray.GetDem());
            arr.Dispose();
            Console.WriteLine("\n=====KET THUC CHUONG TRI=====");
        }
    }
}