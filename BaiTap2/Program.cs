using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Collections;

namespace TongSNT
{
    public class cPrimeSum
    {
        private int n;
        private static int dem = 0;
        public void Dispose()
        {
            n = 0;
            dem--;
            System.Console.WriteLine("Da huy mot doi tuong");
        }
        public cPrimeSum()
        {
            n = 0;
            dem++;
        }
        public cPrimeSum(int size)
        {
            while (size <= 0)
            {
                try
                {
                    System.Console.Write("Nhap lai so nguyen duong n > 0: ");
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    size = -1;
                }
            }
            this.n = size;
            dem++;
        }
        public cPrimeSum(cPrimeSum other)
        {
            this.n = other.n;
            dem++;
        }
        public int GetN()
        {
            return n;
        }
        public void SetN(int size)
        {
            while (size <= 0)
            {
                try
                {
                    System.Console.Write("Nhap lai so nguyen duong n > 0: ");
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    size = -1;
                }
            }
            this.n = size;
        }
        public static int GetDem()
        {
            return dem;
        }
        public void Nhap()
        {
            do
            {
                try
                {
                    System.Console.Write("Nhap so nguyen duong n: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n <= 0)
                        System.Console.WriteLine("So n phai > 0! Moi ban nhap lai!");
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    n = -1;
                }
            } while (n <= 0);
        }
        public int TongSoNguyenTo()
        {
            int sum = 0;
            bool[] arr = new bool[n + 1];
            for (int i = 0; i <= n; i++)
                arr[i] = true;
            arr[0] = arr[1] = false;
            for (int i = 2; i <= n; i++)
                if (arr[i] && i * i <= n)
                    for (int j = i * i; j <= n; j += i)
                        arr[j] = false;
            for (int i = 2; i < n; i++)
                if (arr[i])
                    sum += i;
            return sum;
        }
    }
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine("=====CHUONG TRINH TINH TONG SO NGUYEN TO=====");
            System.Console.WriteLine("Tong So Doi Tuong: " + cPrimeSum.GetDem());
            System.Console.WriteLine("\n1. Nhap so nguyen duong n:");
            cPrimeSum primeSum = new cPrimeSum();
            primeSum.Nhap();
            System.Console.WriteLine("\n2. Tinh tong cac so nguyen to < n:");
            int sum = primeSum.TongSoNguyenTo();
            System.Console.WriteLine("Tong cac so nguyen to < {0}: {1}", primeSum.GetN(), sum);
            System.Console.WriteLine("\n3. Thay doi gia tri n bang SetN:");
            primeSum.SetN(Convert.ToInt32(Console.ReadLine()));
            System.Console.WriteLine("Tong cac so nguyen to < {0} (sau khi SetN): {1}", primeSum.GetN(), primeSum.TongSoNguyenTo());
            System.Console.WriteLine("\nTong so doi tuong khi tao: " + cPrimeSum.GetDem());
            primeSum.Dispose();
            System.Console.WriteLine("\n=====KET THUC CHUONG TRINH=====");
        }
    }
}