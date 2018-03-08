using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace graph_toanroirac
{
    class Graph
    {
        int n;
        EdgeCollection edgeList;
        NodeCollection nodeList;
        /// <summary>
        /// true là vô hướng, false là có hướng
        /// </summary>
        bool IsUndirected;        
        public Graph(int n)
        {
            this.n = n;
            edgeList = new EdgeCollection();
            nodeList = new NodeCollection();
            IsUndirected = true;
        }
        public Graph(int n,bool IsUndirected)
        {
            this.n = n;
            khoitao();
        }
        public Graph()
        {
            n = 0;
            khoitao();
        }
        public Graph(Matrix matrix)
        {
            khoitao();
            n = matrix.n;
            matrix_convert(matrix);
        }
        void khoitao()
        {
            edgeList = new EdgeCollection();
            nodeList = new NodeCollection();
            this.IsUndirected = false;
        }
        /// <summary>
        /// Kiểm tra tính liên thông của ma trận
        /// </summary>
        /// <returns>Trả về đúng nếu liên thông</returns>
        public bool Is_lienthong()
        {
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
            return false;
        }
        /// <summary>
        /// Duyệt theo chiều sâu
        /// </summary>
        /// <param name="start">đỉnh bắt đầu(mặc định là đỉnh 0)</param>
        public void Travel_Deep(int start = 0)
        {
           
        }
        /// <summary>
        /// Duyệt theo chiều rộng
        /// </summary>
        /// <param name="start">đỉnh bắt đầu(mặc định là đỉnh 0)</param>
        public void Travel_Breadth(int start = 0)
        {
            
        }
        public void matrix_convert(Matrix a)
        {
            n = a.n;
            for (int i = 0; i < n; i++)
            {
                nodeList.Add(new Node(i));
            }
            for (int i = 0; i < n; i++)
            {
                Node start = nodeList[i];
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] != 0)
                    {
                        Node end = nodeList[j];
                        Edge edge = new Edge(start, end, a[i, j]);
                        edgeList.Add(edge);
                    }
                }
            }
        }
        public Matrix graph_convert()
        {
            Matrix matrix = new Matrix(n);
            foreach (Edge item in edgeList)
            {
                matrix[item.start.Index, item.end.Index] = item.weight;
                if(item.IsUndirected) matrix[item.end.Index, item.start.Index] = item.weight;
            }
            return matrix;
        }
    }
}
