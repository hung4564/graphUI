﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace graph_toanroirac
{
    class Program
    {
        /// <summary>
        /// Nhập ma trận vuông đối xứng
        /// </summary>
        /// <param name="a">Mảng chứa dữ liệu</param>
        /// <param name="n">số lượng phần tử</param>
        static void NhapMatrix(int[,] a, out int n)
        {
            Console.Write("Nhap so luong diem:");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Console.Write("a[{0}:{1}]=",i,j);
                    a[i,j] = int.Parse(Console.ReadLine());
                    a[j, i] = a[i, j];
                }
            }
        }
        /// <summary>
        /// Xuất ma trận vuông
        /// </summary>
        /// <param name="a">Mảng chứa dữ liệu</param>
        /// <param name="n">số lượng phần tử</param>
        static void XuatMatrix(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i,j]+" ");
                }
                Console.Write("\n");
            }
        }
        /// <summary>
        /// Đọc ma trận từ file
        /// </summary>
        /// <param name="a">Mảng chứa dữ liệu</param>
        /// <param name="n">số lượng phần tử</param>
        static void ReadMatrix(int[,]a,out int n)
        {
            string path = "matrix.txt";
            if (File.Exists(path))
            {
                n = 0;
                FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var sr = new StreamReader(inFile))
                {
                    // Doc file, lay tung hang roi tach tung cot cho vao ma tran
                    string matrix = sr.ReadToEnd();
                    while(matrix.IndexOf("\r")>0)
                    matrix=matrix.Remove(matrix.IndexOf("\r"), 1);
                    string[] rows = matrix.Split('\n');
                    n = rows.Count();
                    for (int i = 0; i < rows.Count(); i++)
                    {
                        string[] columns = rows[i].Split(' ');
                        for (int j = 0; j < columns.Count(); j++)
                        {
                            a[i, j] = int.Parse(columns[j]);
                        }
                    }
                }
            }
            else
            {
                File.Create(path);
                NhapMatrix(a, out n);                
            }
        }
        /// <summary>
        /// Ghi ma trận vào file
        /// </summary>
        /// <param name="a">Mảng chứa dữ liệu</param>
        /// <param name="n">số lượng phần tử</param>
        static void WriteMarix(int[,] a,out int n)
        {
            string path = "matrix.txt";
            NhapMatrix(a, out n);
            if (File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
            }
            FileStream inFile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            using (var sw = new StreamWriter(inFile))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write(a[i, j].ToString()+ " ");
                    }
                    if(i!=n-1)sw.WriteLine();
                }
            }
        }
        /// <summary>
        /// Kiểm tra tính liên thông của ma trận
        /// </summary>
        /// <param name="A">Ma trân vuông cần kiểm tra</param>
        /// <param name="n">Độ dài cạnh</param>
        /// <returns>Trả về đúng nếu liên thông</returns>
        static bool Is_lienthong(int[,] A, int n)
        {
            int[] DanhDau = new int[n];
            int ThanhCong;
            int Dem = 0;
            DanhDau[0] = 1;         //Đánh dấu đỉnh đầu
            Dem++;              //Đểm số đỉnh đã đánh dấu là 1
            do
            {
                ThanhCong = 1;      //Giả sử không còn khả năng loang
                for (int i = 0; i < n; i++)
                    if (DanhDau[i] == 1)
                    {
                        for (int j = 0; j < n; j++)
                            if (DanhDau[j] == 0 && A[i,j] > 0)
                            {
                                DanhDau[j] = 1;
                                ThanhCong = 0;  //Thực tế còn khả năng loang
                                Dem++;
                                if (Dem == n) return true;
                            }
                    }
            } while (ThanhCong == 0);	//Lặp lại cho đến khi không còn khả năng loang
            return false;
        }
        /// <summary>
        /// Kiểm tra tính đầy đủ của ma trận
        /// </summary>
        /// <param name="a">ma trận cần kiểm tra</param>
        /// <param name="n">số cạnh của ma trận</param>
        /// <returns>Trả về đúng nếu là ma trận đầy đủ</returns>
        static bool Is_daydu(int[,] a,int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] == 0) return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int n=0;
            int[,] matrix = new int[50, 50];
            ReadMatrix(matrix,out n);
            XuatMatrix(matrix, n);
            if (Is_lienthong(matrix,n)) Console.WriteLine("Lien thong"); else Console.WriteLine("Khong lien thong");
            Console.ReadKey();
        }
    }
}
