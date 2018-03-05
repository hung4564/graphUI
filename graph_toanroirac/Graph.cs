using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace graph_toanroirac
{
    class Graph
    {
        int[,] matrix;
        int n;
        /// <summary>
        /// true là vô hướng, false là có hướng
        /// </summary>
        bool IsUndirected;
        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        /// <param name="n">Số đỉnh</param>
        public Graph(int n)
        {
            this.n = n;
            matrix = new int[n, n];
            IsUndirected = true;
        }
        public Graph(int n,bool IsUndirected)
        {
            this.n = n;
            this.IsUndirected = IsUndirected;
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
        /// <summary>
        /// Kiểm tra tính liên thông của ma trận
        /// </summary>
        /// <returns>Trả về đúng nếu liên thông</returns>
        public bool Is_lienthong()
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
                            if (DanhDau[j] == 0 && matrix[i, j] > 0)
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
        /// <returns>
        /// Trả về đúng nếu là ma trận đầy đủ
        /// </returns>
        public bool Is_daydu()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0) return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Duyệt theo chiều sâu
        /// </summary>
        /// <param name="start">đỉnh bắt đầu(mặc định là đỉnh 0)</param>
        public void Travel_Deep(int start = 0)
        {
            bool[] visit = new bool[n];
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count > 0)
            {
                int current = stack.Pop();
                if (!visit[current])
                {
                    visit[current] = true;
                    Console.Write(current + 1 + "->");
                    for (int i = 0; i < n; i++)
                    {
                        // Nếu là đỉnh kề và chưa được ghé thăm
                        if (matrix[current, i] == 1 && !visit[i])
                        {
                            stack.Push(i);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Duyệt theo chiều rộng
        /// </summary>
        /// <param name="start">đỉnh bắt đầu(mặc định là đỉnh 0)</param>
        public void Travel_Breadth(int start = 0)
        {
            bool[] visit = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (!visit[current])
                {
                    visit[current] = true;
                    Console.Write(current + 1 + "->");
                    for (int i = 0; i < n; i++)
                    {
                        // Nếu là đỉnh kề và chưa được ghé thăm
                        if (matrix[current, i] == 1 && !visit[i])
                        {
                            queue.Enqueue(i);
                        }
                    }
                }
            }
        }
    }
}
