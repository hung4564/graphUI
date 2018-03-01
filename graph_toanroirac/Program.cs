using System;
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
                    string[] rows = matrix.Split('\n');
                    n = rows.Count();
                    for (int i = 0; i < rows.Count(); i++)
                    {
                        string[] columns = rows[i].Split(' ');
                        for (int j = 0; j < columns.Count()-1; j++)//ki tu cuoi la /r??(ko hieu vi sao lai co)
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
        static void Main(string[] args)
        {
            int n=0;
            int[,] matrix = new int[50, 50];
            ReadMatrix(matrix,out n);
            XuatMatrix(matrix, n);
            Console.ReadKey();
        }
    }
}
