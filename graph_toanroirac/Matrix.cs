using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace graph_toanroirac
{
    class Matrix
    {
        int[,] matrix;
        int n;
        public Matrix(int n)
        {
            matrix = new int[n, n];
        }
        public int this[int x,int y]
        {
            get { return matrix[x, y]; }
            set
            {
                matrix[x, y] = value;
            }
        }

        /// <summary>
        /// Nhập ma trận vuông đối xứng
        /// </summary>
        public void NhapMatrix()
        {
            Console.Write("Nhap so luong diem:");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Console.Write("a[{0}:{1}]=", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                    matrix[j, i] = matrix[i, j];
                }
            }
        }
        /// <summary>
        /// Xuất ma trận vuông
        /// </summary>
        public void XuatMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        /// <summary>
        /// Đọc ma trận từ file
        /// </summary>
        public void ReadMatrix()
        {
            string path = "matrix.txt";
            if (File.Exists(path))
            {
                n = 0;
                FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var sr = new StreamReader(inFile))
                {
                    // Doc file, lay tung hang roi tach tung cot cho vao ma tran
                    string file = sr.ReadToEnd();
                    while (file.IndexOf("\r") > 0)
                        file = file.Remove(file.IndexOf("\r"), 1);
                    string[] rows = file.Split('\n');
                    n = rows.Count();
                    for (int i = 0; i < rows.Count(); i++)
                    {
                        string[] columns = rows[i].Split(' ');
                        for (int j = 0; j < columns.Count(); j++)
                        {
                            matrix[i, j] = int.Parse(columns[j]);
                        }
                    }
                }
            }
            else
            {
                File.Create(path);
                NhapMatrix();
            }
        }
        /// <summary>
        /// Ghi ma trận vào file
        /// </summary>
        /// <param name="matrix">Mảng chứa dữ liệu</param>
        /// <param name="n">số lượng phần tử</param>
        public void WriteMarix()
        {
            string path = "matrix.txt";
            NhapMatrix();
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
                        sw.Write(matrix[i, j].ToString() + " ");
                    }
                    if (i != n - 1) sw.WriteLine();
                }
            }
        }
    }
}
