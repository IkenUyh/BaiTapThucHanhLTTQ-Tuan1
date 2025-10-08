using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaTran
{
    class CMatrix
    {
        private int[,] matrix;
        private int n, m; 
        private static int dem = 0;
        public void Dispose()
        {
            --dem;
            Console.WriteLine("Da huy mot ma tran");
        }
        public CMatrix()
        {
            n = 0;
            m = 0;
            matrix = null;
            dem++;
        }
        public CMatrix(int n, int m)
        {
            this.n = n > 0 ? n : 1;
            this.m = m > 0 ? m : 1;
            matrix = new int[this.n, this.m];
            Random rand = new Random();
            for (int i = 0; i < this.n; i++)
                for (int j = 0; j < this.m; j++)
                    matrix[i, j] = rand.Next(-100, 101); 
            dem++;
        }
        public CMatrix(CMatrix other)
        {
            this.n = other.n;
            this.m = other.m;
            this.matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    this.matrix[i, j] = other.matrix[i, j];
            dem++;
        }
        public CMatrix Assign(CMatrix other)
        {
            if (other == null || other.matrix == null)
            {
                this.n = 0;
                this.m = 0;
                this.matrix = null;
                return this;
            }
            this.n = other.n;
            this.m = other.m;
            this.matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    this.matrix[i, j] = other.matrix[i, j];
            return this;
        }
        public int GetSoDong()
        {
            return n;
        }
        public int GetSoCot()
        {
            return m;
        }
        public static int GetDem()
        {
            return dem;
        }
        public void Nhap()
        {
            do
            {
                Console.Write("Nhap so dong n: ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nhap so cot m: ");
                m = Convert.ToInt32(Console.ReadLine());
                if (n < 1 || m < 1)
                    Console.WriteLine("So dong va so cot phai lon hon 0! Moi nhap lai!");
            } while (n < 1 || m < 1);
            matrix = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = rand.Next(-100, 101); 
        }
        public void Xuat()
        {
            if (matrix == null)
            {
                Console.WriteLine("Ma tran rong!");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }
        }
        public void TimMaxMin(out int max, out int min)
        {
            if (matrix == null || n == 0 || m == 0)
            {
                max = min = 0;
                Console.WriteLine("Ma tran rong!");
                return;
            }
            max = matrix[0, 0];
            min = matrix[0, 0];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
        }
        public int TimDongCoTongLonNhat()
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return -1;
            }
            int maxSum = int.MinValue;
            int maxRow = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    sum += matrix[i, j];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = i;
                }
            }
            return maxRow;
        }
        private bool LaSoNguyenTo(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }
        public int TongKhongPhaiSoNguyenTo()
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return 0;
            }
            int sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (!LaSoNguyenTo(matrix[i, j]))
                        sum += matrix[i, j];
            return sum;
        }
        public void XoaDong(int k)
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return;
            }
            if (k < 0 || k >= n)
            {
                Console.WriteLine("Chi so dong k khong hop le!");
                return;
            }
            int[,] newMatrix = new int[n - 1, m];
            for (int i = 0, newI = 0; i < n; i++)
            {
                if (i != k)
                {
                    for (int j = 0; j < m; j++)
                        newMatrix[newI, j] = matrix[i, j];
                    newI++;
                }
            }
            n--;
            matrix = newMatrix;
        }
        public void XoaCotChuaMax()
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return;
            }
            int max = matrix[0, 0];
            int maxCol = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxCol = j;
                    }
            int[,] newMatrix = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0, newJ = 0; j < m; j++)
                {
                    if (j != maxCol)
                    {
                        newMatrix[i, newJ] = matrix[i, j];
                        newJ++;
                    }
                }
            }
            m--;
            matrix = newMatrix;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====CHUONG TRINH XU LY MA TRAN=====");
            Console.WriteLine("Nhap thong tin ma tran:");
            CMatrix mat = new CMatrix();
            mat.Nhap();
            Console.WriteLine("\nMa tran vua nhap:");
            mat.Xuat();
            Console.WriteLine("\nTao ma tran moi va gan gia tri tu ma tran vua nhap:");
            CMatrix mat2 = new CMatrix();
            mat2.Assign(mat);
            Console.WriteLine("Ma tran sau khi gan:");
            mat2.Xuat();
            int max, min;
            mat.TimMaxMin(out max, out min);
            Console.WriteLine($"\nPhan tu lon nhat: {max}");
            Console.WriteLine($"Phan tu nho nhat: {min}");
            int maxRow = mat.TimDongCoTongLonNhat();
            Console.WriteLine($"\nDong co tong lon nhat: {maxRow}");
            int sumNonPrime = mat.TongKhongPhaiSoNguyenTo();
            Console.WriteLine($"\nTong cac so khong phai so nguyen to: {sumNonPrime}");
            Console.Write("\nNhap chi so dong can xoa: ");
            int k = Convert.ToInt32(Console.ReadLine());
            mat.XoaDong(k);
            Console.WriteLine("\nMa tran sau khi xoa dong:");
            mat.Xuat();
            mat.XoaCotChuaMax();
            Console.WriteLine("\nMa tran sau khi xoa cot chua phan tu lon nhat:");
            mat.Xuat();
            mat.Dispose();
            mat2.Dispose();
            Console.WriteLine("=====KET THUC CHUONG TRINH=====");
        }
    }
}